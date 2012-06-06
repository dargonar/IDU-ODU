using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU.BL;
using WPFiDU;
using WPFiDU.BL;
using iDU.PLC;
using System.Windows.Threading;
using iDU.CommonObjects;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Media.Imaging;
using iDU.DAO;
using System.Collections.Generic;
using log4net;
using System.Diagnostics;
using System.Threading;
using WPFiDU.Utils;

// ODU_SP_NumeroModeloCargado

namespace dcf001
{
	public partial class HomeOdu
	{
      #region  Members
      private PLCODU _accesoplc = null;

      private PLCODU accesoplc 
      {
          get 
          {
              if (_accesoplc == null)
              {
                _accesoplc = new PLCODU();
                _accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
              }
              return _accesoplc;
          
          }
      }

      private static readonly ILog logger = LogManager.GetLogger(typeof(HomeOdu));

      /// <summary>
      /// Mantengo el modelo de testeo actual;
      /// </summary>
      private Modelo modeloinfo = null;
      
      private bool fallaconexion = false;

      private bool ModoMantenimientoOn = false;

      private bool EnsayoEnCursoODU = false;
      private bool EnsayoEnCursoODUOld = false;

      private bool EnsayoFallaODU = false;
      private bool EnsayoFallaODUOld = false;

      private bool EnsayoAprobadoODU = false;
      private bool EnsayoAprobadoODUOld = false;
      
      private int LimiteFallas = 0;

      private double TempEntrada = 24;

      private DateTime TiempoInicioEnsayo = DateTime.Now;
      private TimeSpan TiempoTranscurrido = new TimeSpan(0,0,0);

      private DispatcherTimer intervalTimer = new DispatcherTimer();
      private DispatcherTimer esperarResultadosTimer = new DispatcherTimer();

      private static string USUARIO = "N/D";
      private static string USUARIO_NONE = "N/D";
      
      private SolidColorBrush mBrushManualMode = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xF9, 0xFB, 0x52));
      private SolidColorBrush mBrushOkOn = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x35, 0xEB, 0x00));
      private SolidColorBrush mBrushOkOff = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x00, 0xB4, 0xEB));
      
      private SolidColorBrush mForegroundBrushWhite = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF));
      private SolidColorBrush mForegroundBrushRed = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0x00, 0x00));
      private SolidColorBrush mForegroundBrushGreen = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x00, 0xFF, 0x00));
      private SolidColorBrush mForegroundBrushGray = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x99, 0x99, 0x99));
      
      private bool ReadSerialNumberFromScanner = false;
    
      private int iAppCfgTestEndDelayTicks = 3;
      #endregion  Members

    public HomeOdu()
    {
      this.InitializeComponent();

      log4net.Config.XmlConfigurator.Configure();
      log4net.GlobalContext.Properties["Username"] = "N/D";
      log4net.GlobalContext.Properties["DCF"] = System.Environment.MachineName;
      
      
      ReadSerialNumberFromScanner = Convert.ToInt32( ConfigurationManager.AppSettings["ReadSerialNumberFromScanner"])==1;
      try{
        iAppCfgTestEndDelayTicks = Convert.ToInt32(ConfigurationManager.AppSettings["TestEndDelayTicks"]) ;
      }
      catch{
        iAppCfgTestEndDelayTicks = 3;
      }

      setGuiDefaults(ReadSerialNumberFromScanner);

      doLogin();
      
    }

    bool loaded = false;
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      
      if (loaded)
        return;
      loaded = true;
      
      WPFiDU.Utils.OneAppInstanceChecker.KillOldInstance();

      leerEstadosActuales();
      cargarGUIInicial();


      intervalTimer.Interval = new TimeSpan(0, 0, 1);
      intervalTimer.Tick += new EventHandler(TiempoEnsayo_tick);
      esperarResultadosTimer.Interval = new TimeSpan(0, 0, 6);
      esperarResultadosTimer.Tick += new EventHandler(esperarResultadosTimer_tick);
      accesoplc.LeerEstadosPantallaPrincipalAsincronicamente();

      this.Closed += new EventHandler(this_Closed);

      this.lblVersion.Content = System.Environment.MachineName + " | Versión " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

    }

    private void doLogin()
    {
      Teclado2 mTeclado2 = new Teclado2();

      mTeclado2.ShowDialog();
      while (mTeclado2.sfUser == null)
      {
        try
        {
          mTeclado2.ShowDialog();
        }
        catch
        {
          mTeclado2 = null;
          mTeclado2 = new Teclado2();
          mTeclado2.ShowDialog();
        }
      }

      //ManagerUsuarios.sfUser = mTeclado2.sfUser;
      this.lblUsuario.Content = "Usuario: '" + ManagerUsuarios.sfUser.sgu__username + "' [" + Convert.ToString(ManagerUsuarios.sfUser.getRole()) + "]";

      mTeclado2.Close();
      mTeclado2 = null;

    }
    
    #region Process Events

    void accesoplc_OnPLCEvent(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
    {
      Dispatcher.Invoke(DispatcherPriority.Normal
        , new PLC.PLCEvent(accesoplc_OnPLCEventX)
        , tags
        , valores);
    }

    void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
    {
      bool mLeidaActualEnsayoEnCurso = false;
      try
      {
        EnsayoEnCursoODUOld = EnsayoEnCursoODU;
        EnsayoFallaODUOld = EnsayoFallaODU;
        EnsayoAprobadoODUOld = EnsayoAprobadoODU;

        #region Bucle recorrido de Tags
        for (int i = 0; i < tags.Length; i++)
        {
          if (valores[i].Value == null)
            continue;

          if (valores[i].Quality != 192)
            fallaconexion = true;
          else
            fallaconexion = false;

          if (tags[i] == PLC.ResolverItem("ODU_ST_EnsayoAprobado"))
          {
            if (!Convert.ToInt32(valores[i].Value).Equals(0))
              EnsayoAprobadoODU = true;

            else
              EnsayoAprobadoODU = false;
          }
          else
            if (tags[i] == PLC.ResolverItem("ODU_ST_EnsayoFalla"))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                dotFalla.Tag = "red";
              }
            }
            else
              if (tags[i] == PLC.ResolverItem("ODU_I_PulsadorStop") ) //|| tags[i] == PLC.ResolverItem("ODU_I_PulsadorFallaManual"))
              {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                {
                  this.lblPulsadorStop.Visibility = Visibility.Visible;
                }
                else
                {
                  this.lblPulsadorStop.Visibility = Visibility.Hidden;
                }
              }
              else
                if (tags[i] == PLC.ResolverItem("ODU_ST_EnsayoEnCurso"))
                {
                  EnsayoEnCursoODU = !Convert.ToInt32(valores[i].Value).Equals(0);
                  mLeidaActualEnsayoEnCurso = EnsayoEnCursoODU;
                }
                else
                  if (tags[i] == PLC.ResolverItem("ODU_ST_CopiaBitMantenimiento"))
                  {
                    ModoMantenimientoOn = !(Convert.ToInt32(valores[i].Value).Equals(0));
                  }
                  else
                    if (tags[i] == PLC.ResolverItem("ODU_MD_Potencia"))
                    {

                      txtPotencia.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TensionEstado"))
                    {
                      txtTension.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Humedad"))
                    {
                      txtHumedad.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Presion"))
                    {
                      txtPresion.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TempSalida"))
                    {
                      txtTempSalida.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TempEntrada"))
                    {

                      txtTempEntrada.Text = Convert.ToDouble(valores[i].Value).ToString();
                      TempEntrada = Convert.ToDouble(txtTempEntrada.Text);

                      EnvironmentTempManager.setEnvironmentTemp(TempEntrada);

                      CheckEnvironmentTemperature(false);
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Corriente"))
                    {
                      txtCorriente.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Velocidad"))
                    {
                      txtVelocidad.Text = Convert.ToDouble(valores[i].Value).ToString();
                    }
                    //TODO: chequear estado DUMMY
                    else if (tags[i] == PLC.ResolverItem("ODU_ST_DummyPres"))
                    {
                      if (!Convert.ToDouble(valores[i].Value).Equals(0))
                        dotDummy.Tag = "green";
                      else
                        dotDummy.Tag = null;
                    }
                    //TODO : Consultar sobre variables Q .
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_BajaTension"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotBajaTension.Tag = "green";
                      else
                        dotBajaTension.Tag = null;
                    }
                    // TODO : TermistorOk es I2.7 ? 
                    else if (tags[i] == PLC.ResolverItem("ODU_I_TermistorOK"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotTermistorOk.Tag = "green";
                      else
                        dotTermistorOk.Tag = null;
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_M_ModoCalor"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotModoCalor.Tag = "green";
                      else
                        dotModoCalor.Tag = null;
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_TensionNominal"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotTensionNominal.Tag = "green";
                      else
                        dotTensionNominal.Tag = null;
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_M_CierreValvulaLiquido"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotValvulaLiquido.Tag = "green";
                      else
                        dotValvulaLiquido.Tag = null;
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_M_CierreValvulaGas"))
                    {
                      if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        dotValvulaGas.Tag = "green";
                      else
                        dotValvulaGas.Tag = null;
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_ST_CodigoDeFalla"))
                    {
                      int codigo = Convert.ToInt32(valores[i].Value);
                      ChequearFalla(codigo);
                    }


        }

        #endregion Bucle recorrido de Tags

        if (fallaconexion == true)
        {
          
          txtblckInfo.Foreground = mForegroundBrushRed;
          txtblckInfo.Text = "Falla en la conexión con el PLC";

        }
        else
          if (EnsayoEnCursoODU)
          {
            
            txtblckInfo.Foreground = mForegroundBrushGreen;
            txtblckInfo.Text = "Ensayo en curso";
          }
          else
          {
            
            txtblckInfo.Foreground = mForegroundBrushGreen;
            txtblckInfo.Text = "Conexión con PLC OK";
          }


        procesarEnsayofinalizado(mLeidaActualEnsayoEnCurso);
      
      }
      catch (Exception e)
      {
        logger.Error("accesoplc_OnPLCEventX()",e);
        excepcion formexcepcion = new excepcion(e);
        formexcepcion.ShowDialog();
        formexcepcion=null;
      }
    }

    private int iErrorNumberChecker = 0;
    
    /// <summary>
    /// Esta funcion es llamada por el timer, 
    /// luego de que termina el se activa el timer de procesamiento de 
    /// resultado que llama a esta funcion.
    /// </summary>
    private void terminoEnsayo() 
    {
      esperarResultadosTimer.Stop();

      string mSerialNumber = this.txtUltimo.Text.Trim();

      if (ReadSerialNumberFromScanner)
        if (mSerialNumber.ToLower().StartsWith("s") && mSerialNumber.ToLower().Length == 11)
          mSerialNumber = mSerialNumber.Trim().Substring(1);
        else
        {
          excepcion formexcepciones = new excepcion("Ensayo finalizado con errores", "El número de serie es incorrecto. El ensayo no tendrá efecto.");
          formexcepciones.ShowDialog();
          //confirmacioneliminar.Show("Ensayo finalizado con errores","El número de serie es incorrecto. El ensayo no tendrá efecto.");
          ResetEstados();
          return;
        }

      string mOrdenFabricacion = this.txtOrdenFabricacion.Text.Trim();
      if (mOrdenFabricacion.ToLower().StartsWith("f") && mOrdenFabricacion.ToLower().Length > 11)
        mOrdenFabricacion = mOrdenFabricacion.Trim().Substring(1, 7);
      else
      {
        excepcion formexcepciones = new excepcion("Ensayo Finalizado ODU", "La Orden de Fabricación es incorrecta. El ensayo no tendrá efecto.");
        formexcepciones.ShowDialog();
        formexcepciones = null;
        ResetEstados();
        return;
      }
      
      // 1.1.- Ensayo aprobado, termino test.
      if (EnsayoAprobadoODU == true)
      {
        // Logeo.
        // Obtengo objeto con los resultados del ensayo.
        EnsayosODU ensayoaprobado = accesoplc.LeerValoresEnsayo() as EnsayosODU;
        ensayoaprobado.Aprobado = true;
        ensayoaprobado.Marca = txtMarca.Text;
        ensayoaprobado.Modelo = txtModelo.Text;
        ensayoaprobado.Tiempoensayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);
        ensayoaprobado.Fecha = DateTime.Now;
        ensayoaprobado.Codigo = "0";
        ensayoaprobado.OrdenFabricacion = mOrdenFabricacion;
            
        if (ManagerUsuarios.sfUser == null)
          ensayoaprobado.Usuario = HomeOdu.USUARIO;
        else
          ensayoaprobado.Usuario = ManagerUsuarios.sfUser.sgu__username;

        // Salvo el resultado del ensayo.
        EnsayosManager ensmanager = new EnsayosManager();
        if (!ReadSerialNumberFromScanner)
          ensmanager.GuardarValoresEnsayo(ensayoaprobado,null);
        else
        {
          ensmanager.GuardarValoresEnsayo(ensayoaprobado,mSerialNumber);
        }
            
        // Formateo Form acorde al resutado positivo.
        txtblckInfo.Foreground = mForegroundBrushGreen;
        txtblckInfo.Text = "Se terminó el ensayo con éxito";
        //NEW
        dotFalla.Tag = "green";

        txtblckInfoFalla.Foreground = mForegroundBrushWhite;
        txtblckInfoFalla.Text = "Equipo listo para próximo ensayo.";

        // Agrego una pieza OK al resultado parcial de peizas OK.
        WPFiDU.Utils.PiezasOkManager.addPiezaOk();
        txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();
            
        Ensayos infoens = ensayoaprobado;

        if (modeloinfo == null)
        {
          excepcion form_msg= new excepcion("Selección de Modelo", "Usted no seleccionó ningun modelo al iniciar el ensayo");
          form_msg.ShowDialog();
          form_msg = null;
        }
        else
          ImpresionEtiquetas(infoens, null, false);
            
        // Reseteo fallas.
        LimiteFallas = 0;

        // Mando a imprimir etiqueta.
            

      }
      // 1.2.- Ensayo NO aprobado, termino test.
      else
      {
            
        // Obtengo objeto con los resultados del ensayo.
        EnsayosODU ensayofalla = accesoplc.LeerValoresEnsayo() as EnsayosODU;
        ensayofalla.Aprobado = false;
        ensayofalla.Marca = txtMarca.Text;
        ensayofalla.Modelo = txtModelo.Text;
        ensayofalla.Tiempoensayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);
        ensayofalla.OrdenFabricacion = mOrdenFabricacion;
            
        if (ManagerUsuarios.sfUser == null)
          ensayofalla.Usuario = USUARIO;
        else
          ensayofalla.Usuario = ManagerUsuarios.sfUser.sgu__username;
              
        ensayofalla.Fecha = DateTime.Now;
        ensayofalla.Codigo = accesoplc.LeerItem("ODU_ST_CodigoDeFalla") ;

        if (ensayofalla.Codigo.Trim().Equals("0"))
        {
          if (iErrorNumberChecker < iAppCfgTestEndDelayTicks)
          {
            iErrorNumberChecker = iErrorNumberChecker + 1;
            esperarResultadosTimer.Start();
            return;
          }
        }
        iErrorNumberChecker = 0;
        // Salvo el ensayo fallado en BBDD.
        EnsayosManager ensmanager = new EnsayosManager();

        if (!ReadSerialNumberFromScanner)
          ensmanager.GuardarValoresEnsayo(ensayofalla, null);
        else
        {
          ensmanager.GuardarValoresEnsayo(ensayofalla, mSerialNumber);
        }
            
        txtblckInfo.Foreground = mForegroundBrushRed;
        txtblckInfo.Text = "Se terminó el ensayo con fallas";
        //NEW
        dotFalla.Tag = "red";

        LimiteFallas = 0;

        string fallaDesc = getDescripcionDeFalla(Convert.ToInt32(ensayofalla.Codigo));

        ImpresionEtiquetas(ensayofalla, fallaDesc, true);
          
      }

          
      ResetEstados();
      NumeroDeSerieManager seriemanager = new NumeroDeSerieManager();
      seriemanager.GuardarNumeroDeSerie();
      if (!ReadSerialNumberFromScanner)
        txtUltimo.Text = seriemanager.ObtenerUltimoNumeroDeSerie();
      else
        txtUltimo.Text = "";
        
      }

    /// <summary>
    /// Timer para lanzar procesamiento de resultado.
    /// Se utiliza para ermitir a los adquisidores refrescar sus estados.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void esperarResultadosTimer_tick(object source, EventArgs e)
    {
      esperarResultadosTimer.Stop();
      terminoEnsayo();

    }
    
    /// <summary>
    /// Procesa ensayo finalizado.
    /// Chequea si el ensayo efectivamente termino y lanza el timer
    /// de chequeo de resultado de ensayo.
    /// </summary>
    /// <param name="argLeidaActualEnsayoEnCurso"></param>
    private void procesarEnsayofinalizado(bool argLeidaActualEnsayoEnCurso) 
    {
      try
      {
        // 1.- Termino ensayo, sea por aprobado o por falla.
        if ((EnsayoEnCursoODU == false) && (EnsayoEnCursoODUOld == true)
          || EnsayoFallaODU == true)
        {
          // Detengo timer.
          intervalTimer.Stop();
          esperarResultadosTimer.Start();
        }
        //if ((EnsayoEnCursoODU == false) && (EnsayoEnCursoODUOld == true) || EnsayoFallaODU == true) FALSO
        else
        {
          // 2.- Ensayo sigue en curso. 
          // Nuevo para comparar modos y estados
          if (ModoMantenimientoOn)
          {
            // 2.1- ModoMantenimientoOn.
            dotEnsayoEnCurso.Tag = null;
            dotNoTest.Tag = "yellow";
            setColorStates(this.mBrushManualMode);
            intervalTimer.Stop();

          }
          else
            if (EnsayoEnCursoODU)
            {
              // 2.2- EnsayoEnCursoODU & !EnsayoEnCursoODUOld.
          
              txtblckInfoFalla.Text = "";
              dotFalla.Tag = null;
              dotEnsayoEnCurso.Tag = "green";
              dotNoTest.Tag = null;
              setColorStates(this.mBrushOkOn);
              if (argLeidaActualEnsayoEnCurso)
              {
                TiempoInicioEnsayo = DateTime.Now;
              }
              intervalTimer.Start();
            }
            else
            //if (!EnsayoEnCursoODU & EnsayoEnCursoODUOld)
            {
              // 2.3- OK.
              
              EnsayoEnCursoODU = false;
              dotEnsayoEnCurso.Tag = null;
              dotNoTest.Tag = "yellow";
              setColorStates(this.mBrushOkOff);
              intervalTimer.Stop();
              TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
            }
        }
      }
      catch (Exception e)
      {
        logger.Error("procesarEnsayofinalizado()",e);
        excepcion formexcepcion = new excepcion(e);
        formexcepcion.ShowDialog();
        formexcepcion = null;
      }
    
    }

    #endregion Process Events

    #region Timer Events
    private void TiempoEnsayo_tick(object source, EventArgs e)
    {
        TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
        lblTiempoEnsayo.Content = FormatearTiempo(TiempoTranscurrido.TotalSeconds);

    }
    
    #endregion Timer Events

    #region Funciones de inicialización
    
    private void cargarGUIInicial() 
      {
          txtEnsayosOK.Text = "0";
          try
          {
            SolidColorBrush pincel = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();
            NumeroDeSerieManager seriemanager = new NumeroDeSerieManager();
            if (!ReadSerialNumberFromScanner) 
              txtUltimo.Text = seriemanager.ObtenerUltimoNumeroDeSerie();
          }
          catch (Exception ex)
          {
            logger.Error("cargarGUIInicial()", ex);
            excepcion formexcepcion = new excepcion(ex);
            formexcepcion.ShowDialog();
            formexcepcion = null;
          }
          lblVersion.Content = ConfigurationManager.AppSettings["VERSION_ODU"];//System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
          //lblVersion.Content = System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString();
	
      }

    private void leerEstadosActuales(bool argIvisionWasReinitialized) 
    {
      if (_accesoplc!=null)
        _accesoplc.OnPLCEvent -= new PLC.PLCEvent(accesoplc_OnPLCEvent);
      _accesoplc = null;
      leerEstadosActuales();
    }

    private void leerEstadosActuales()
    {
      txtblckInfoFalla.Text = "";
      
      List<string> items = new List<string>();
      items.Add(PLC.ResolverItem("ODU_ST_EnsayoAprobado"));
      items.Add(PLC.ResolverItem("ODU_ST_CodigoDeFalla"));
      items.Add(PLC.ResolverItem("ODU_ST_EnsayoEnCurso"));
      
      string[] valoresiniciales = accesoplc.LeerItems(items.ToArray());

      if (!Convert.ToInt32(valoresiniciales[0]).Equals(0) && !Convert.ToInt32(valoresiniciales[0]).Equals(-1))
      {
          EnsayoAprobadoODU = true;
          //txtblckInfoFalla.Text =  "";
      }
      
      if (!Convert.ToInt32(valoresiniciales[2]).Equals(0) && !Convert.ToInt32(valoresiniciales[0]).Equals(-1))
      {
        EnsayoEnCursoODU = true;
        txtblckInfoFalla.Text =  "";
      }

      if (EnsayoEnCursoODU)
        if (!Convert.ToInt32(valoresiniciales[1]).Equals(0) && !Convert.ToInt32(valoresiniciales[0]).Equals(-1))
        {
            ChequearFalla(int.Parse(valoresiniciales[1]));
        }

      int currentPLCModeloId = LastTestedModelManager.getLastTestedModelId();
      
      if (!EnsayoEnCursoODU && currentPLCModeloId > 0)
      {
        modeloafabricar formcambiarmodelo = new modeloafabricar(currentPLCModeloId);

        formcambiarmodelo.OnModeloSelectionChanged += new OnModeloSelectionChanged(modeloafabricar_OnModeloSelectionChanged);
        formcambiarmodelo.ShowDialog();

        if (formcambiarmodelo.Modelo != null)
        {
          formcambiarmodelo = null;
          return;
        }
      }
    }
    #endregion Funciones de inicialización

    #region Funciones Manager de Fallas
    
    /// <summary>
    /// Obtiene a descripción de la falla en funcion del codigo entregado por el PLC.
    /// </summary>
    /// <param name="codigoError"></param>
    /// <returns></returns>
    private string getDescripcionDeFalla(int codigoError) 
    {
        EnsayosManager manensayo = new EnsayosManager();
        Ensayos e = new Ensayos();
        e.Codigo = codigoError.ToString();
        return manensayo.ObtenerDescripcionFalla(e);
    }

    /// <summary>
    /// Chequea el estado de la falla.
    /// Setea a variable global EnsayoFallaODU si hay falla.
    /// </summary>
    /// <param name="codigo"></param>
    private void ChequearFalla(int codigo)
    {
        //if (!EnsayoEnCursoODU)
        //    return;

        if (codigo <= 0)
        {
          txtblckInfoFalla.Text =  "";
          return ;
        }
        
        txtblckInfoFalla.Foreground = mForegroundBrushRed;
        txtblckInfoFalla.Text =  codigo.ToString() + ": " + getDescripcionDeFalla(codigo);
        EnsayosManager oEnsayosManager = new EnsayosManager();
        if ((oEnsayosManager.ObtenerPrioridadFalla(codigo) == true))
            EnsayoFallaODU = true;
        else
        {
            LimiteFallas++;
            if (LimiteFallas == 2)
              EnsayoFallaODU = true;
        }
        oEnsayosManager = null;
    }
    
    #endregion Funciones Manager de Fallas

    #region Funciones de Reset de Form GUI y miembros

    private void setColorStates(SolidColorBrush argSolidColorBrush) 
    {
      this.rctEstados.Stroke = argSolidColorBrush;
      this.rctEstados.StrokeThickness = 3; 
      this.rctMediciones.Stroke = argSolidColorBrush;
      this.rctMediciones.StrokeThickness = 3;
      this.rctInfo.Stroke = argSolidColorBrush;
      this.rctInfo.StrokeThickness = 3;
    }

    private void ResetEstados()
    {
      // Los reset de los equipos estaba en terminoEnsayo();
      accesoplc.Escribir("ODU_ST_EnsayoAprobado", 0);
      accesoplc.Escribir("ODU_ST_CodigoDeFalla", 0);
      //accesoplc.Escribir("ODU_SP_NumeroModeloCargado", 1); // HACK
      
      EnsayoEnCursoODU = false;
      EnsayoEnCursoODUOld = false;

      EnsayoFallaODU = false;
      EnsayoFallaODUOld = false;

      EnsayoAprobadoODU = false;
      EnsayoAprobadoODUOld = false;
    }
    
    private void cleanForm()
    {
      txtCorriente.Text = "0";
      txtHumedad.Text = "0";
      // txtMarca.Text = "";
      //  txtModelo.Text = "";
      txtPotencia.Text = "0";
      txtPresion.Text = "0";
      //txtReferencia.Text = "";
      txtTempEntrada.Text = "0";
      txtTempSalida.Text = "0";
      txtTension.Text = "0";
      txtUltimo.Text = "";
      txtVelocidad.Text = "0";
      dotBajaTension.Tag = null;
      dotDummy.Tag = null;
      dotModoCalor.Tag = null;
      dotTensionNominal.Tag = null;
      dotTermistorOk.Tag = null;
      dotFalla.Tag = null;
      txtblckInfo.Text = "";

      Storyboard t = null;
      t = (Storyboard)FindResource("tmlOkOff");
      t.AutoReverse = true;
      t.Begin(this);

    }

    private string FormatearTiempo(double tiempo)
    {
        int s = 0;
        int m = 0;

        string segundos = string.Empty;
        string minutos = string.Empty;
        string tiempoformateado = string.Empty;


        for (int i = 0; i < tiempo - 1; i++)
        {

            s++;

            if (s == 60)
            {
                m++;
                s = 0;
            }

        }

        if (s < 10)
            segundos = "0" + s.ToString();
        else
            segundos = s.ToString();


        if (m < 10)
            minutos = "0" + m.ToString();
        else
            minutos = m.ToString();

        tiempoformateado = minutos + ":" + segundos;
        return tiempoformateado;

    }
    #endregion Funciones de Reset de Form GUI y miembros

    #region Impresion de etiquetas

    private void ImpresionEtiquetas(Ensayos infoens, string falla_desc, bool es_falla)
    {
      if (modeloinfo == null)
        return;
      WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerEx = new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
        
      ConfiguracionManager configurador = new ConfiguracionManager();

      if (es_falla)
      {
        if (!configurador.ObtenerPrintErrorTests())
          return;

        if (configurador.ObtenerImpresoraProductoHabilitada())
        {
          Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiquetaFalla(
            modeloinfo
            , modeloinfo.BackgroundProducto.Trim()
            , infoens
            , falla_desc);

          string nombreimpresora = configurador.ObtenerImpresoraProducto();

          WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExProducto =
            new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
          oEtiquetasManagerExProducto.ImprimirImagen(ImagenTemp, nombreimpresora, false);
        }

        return;
      }

      //Impresion Producto
      if (configurador.ObtenerImpresoraProductoHabilitada())
      {
        Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
          , modeloinfo.BackgroundProducto
          , infoens);

        string nombreimpresora = configurador.ObtenerImpresoraProducto();
        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExProd = 
          new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
        
        oEtiquetasManagerExProd.ImprimirImagen(ImagenTemp, nombreimpresora, false, modeloinfo.Nombremodelo + "-" + infoens.Serie);
      }

      //Impresion Bulto
      if (configurador.ObtenerImpresoraBultoHabilitada())
      {


        Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
          , modeloinfo.BackgroundBulto
          , infoens);
        
        string nombreimpresora = configurador.ObtenerImpresoraBulto();

        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExBulto = 
          new WPFiDU.Etiquetas.EtiquetasManagerEx(false);

        oEtiquetasManagerExBulto.ImprimirImagen(ImagenTemp, nombreimpresora, true, modeloinfo.Nombremodelo + "-" + infoens.Serie);
      }

    }
    #endregion Impresion de etiquetas

    #region Manager de Limites de Temperaturas

    private void mFormConfirmacioneliminar_Closed(object sender, EventArgs e) 
    {
      mFormConfirmacioneliminar = null;
    }

    confirmacioneliminar mFormConfirmacioneliminar = null;
    private bool bWasOutOfRange = false;
    private void CheckEnvironmentTemperature(bool reloadConfiguration)
    {
      string sMessageText = string.Empty;
      bool isOutOfRange = EnvironmentTempManager.IsEnvironmentTempOutOfRange(reloadConfiguration, out sMessageText);
      if (isOutOfRange)
      {
        txtTempEntrada.FontWeight = FontWeights.Bold;
        txtTempEntrada.Foreground = mForegroundBrushRed;

        if (!bWasOutOfRange && mFormConfirmacioneliminar == null)
        {
          mFormConfirmacioneliminar = confirmacioneliminar.getMessageBox(string.Format(
                     "Atención : Temperatura ambiente fuera de rango para ensayos. {0}{1}"
                     , Environment.NewLine, sMessageText));
          mFormConfirmacioneliminar.Closed += new EventHandler(mFormConfirmacioneliminar_Closed);
          mFormConfirmacioneliminar.Topmost = true;
          mFormConfirmacioneliminar.Show();
          
        }
        bWasOutOfRange = true;
      }
      else 
      {
        txtTempEntrada.FontWeight = FontWeights.Normal;
        txtTempEntrada.Foreground = mForegroundBrushWhite;
        bWasOutOfRange = false;
      }
      
    }

    #endregion Manager de Limites de Temperaturas

    #region GUI Events
    private void this_Closed(object sender, EventArgs e)
    {
      System.Windows.Forms.Application.Exit();
    }
    private void btnHabilitar_Click(object sender, RoutedEventArgs e)
    {
        doLogin(); 
        
        try
        {
          //  Teclado tec = new Teclado();
          //  tec.Texto = "Ingrese el password";
          //  tec.ShowDialog();

          //  string pass = tec.Password;

          //  ManagerUsuarios oManagerUsuarios = new ManagerUsuarios();
          //  HomeOdu.USUARIO = oManagerUsuarios.ObtenerUsuario(pass);
          
          //if(string.IsNullOrEmpty(HomeOdu.USUARIO) || HomeOdu.USUARIO == HomeOdu.USUARIO_NONE)
          //{
          //  HomeOdu.USUARIO = HomeOdu.USUARIO_NONE;
          //  btnHabilitar.Style = (Style)btnHabilitar.FindResource("styBtnRojo");

          //  this.lblUsuario.Content = HomeOdu.USUARIO_NONE;

          //  excepcion formexcepciones = new excepcion(
          //      new Exception(
          //        string.Format("Usuario no conocido.{0}Inténtelo nuevamente.", Environment.NewLine)));
          //  formexcepciones.ShowDialog();

          //}
          //else
          //{
          //  this.lblUsuario.Content = HomeOdu.USUARIO;
          //  btnHabilitar.Style = (Style)btnHabilitar.FindResource("styBtnVerde");
          //}
        }
        catch (Exception ex)
        {
            logger.Error("btnHabilitar_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones = null;
        }
    }

    private void btnEnsayos_Click(object sender, RoutedEventArgs e)
    {
      if (!ManagerUsuarios.sfUser.IsInRole(Role.Operador))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      } 
      
      try
        {

            ensayos ens = new ensayos();
            ens.ShowDialog();

        }
        catch (Exception ex)
        {
            logger.Error("btnEnsayos_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
        }
    }

    private void btnConfig_Click(object sender, RoutedEventArgs e)
    {
        try
        {

            configuracion formconfiguracion = new configuracion(false);
            bool b = (bool)formconfiguracion.ShowDialog();
            if (b)
                CheckEnvironmentTemperature(true);
        }
        catch (Exception ex)
        {

            logger.Error("btnConfig_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
        }
      
    }

    private void btnMantenProd_Click(object sender, RoutedEventArgs e)
    {
      if (!ManagerUsuarios.sfUser.IsInRole(Role.SuperAdmin))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      } 
      
      try
        {

            mantenimientoproducto mantprod = new mantenimientoproducto();
            mantprod.ShowDialog();

        }
        catch (Exception ex)
        {
            logger.Error("btnMantenProd_Click()", ex);
             excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;  
        }
    }

    private void btnManten_Click(object sender, RoutedEventArgs e)
    {
      if (!ManagerUsuarios.sfUser.IsInRole(Role.Operador))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      } 
      
      try
        {
            mantenimiento mant = new mantenimiento();
            mant.ShowDialog();

        }
        catch (Exception ex)
        {
            logger.Error("btnManten_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
        }
    }

    private void btnFormatos_Click(object sender, RoutedEventArgs e)
    {
      if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Operador))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      } 
      
      try
        {
            formatosetiquetas formetiquetas = new formatosetiquetas();
            formetiquetas.ShowDialog();

        }
        catch (Exception ex)
        {
            logger.Error("btnFormatos_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
        }
    }

    private void btnConexion_Click(object sender, RoutedEventArgs e)
    {
      if (!ManagerUsuarios.sfUser.IsInRole(Role.Operador))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      } 
      
      try
      {

        wndServicesManager owndServicesManager = new wndServicesManager();
        owndServicesManager.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.Error("btnConexion_Click()", ex);

        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }

    /// <summary>
    /// Evento que handlea la seleccion del modelo a  testear.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="selectedModelo"></param>
    private void modeloafabricar_OnModeloSelectionChanged(object sender, Modelo selectedModelo) 
    {
        //Creo que loaded escribe el manager, que es el que me lalma a este evento!!!
        //accesoplc.Escribir("ODU_SP_NumeroModeloCargado", selectedModelo.ID);
        this.txtOrdenFabricacion.Text="";
        this.txtUltimo.Text = "";
        try
        {

            modeloinfo = selectedModelo;
            txtReferencia.Text = modeloinfo.Referencia;
            txtModelo.Text = modeloinfo.Nombremodelo;
            txtMarca.Text = modeloinfo.Marca;
            string PATHLOGO = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_LOGO"];
            string PATHEAN13 = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_EAN13"];

            System.Drawing.Image i = System.Drawing.Image.FromFile(PATHLOGO + modeloinfo.Logo, true);
            Bitmap b = new Bitmap(i);
            Graphics g = Graphics.FromImage(b);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(i, 0, 0, i.Width, i.Height);
            imgLogoModelo.Source = EtiquetaManager.loadBitmap(b);

            System.Drawing.Image i2 = System.Drawing.Image.FromFile(PATHEAN13 + modeloinfo.Ean13, true);
            Bitmap b2 = new Bitmap(i2);
            Graphics g2 = Graphics.FromImage(b2);
            g2.Clear(System.Drawing.Color.White);
            g2.DrawImage(i2, 0, 0, i2.Width, i2.Height);
            imgEan13.Source = EtiquetaManager.loadBitmap(b2);
           // cleanForm();
            
        }

        catch (Exception ex)
        {
            logger.ErrorFormat("modeloafabricar_OnModeloSelectionChanged()", ex);
            excepcion formexcepciones = new excepcion(ex);
            formexcepciones.ShowDialog();
            formexcepciones=null;
        }
    }

    private void btnCambiarModelo_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (EnsayoEnCursoODU == true)
        {
          confirmacioneliminar.Show("No se puede cambiar el modelo mientras se este ensayando un equipo");
          return;
        }
        modeloafabricar formcambiarmodelo = new modeloafabricar();
        formcambiarmodelo.OnModeloSelectionChanged += new OnModeloSelectionChanged(modeloafabricar_OnModeloSelectionChanged);
        formcambiarmodelo.ShowDialog();

        if (formcambiarmodelo != null)    
          if (formcambiarmodelo.Modelo != null)
          {
              //TODO: armar el sub que limpie el form;
              //  cleanForm();
              formcambiarmodelo = null;
              return;
          }
        }
        catch (Exception ex)
        {
            logger.Error("btnCambiarModelo_Click()", ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
            
        }
       
    }

    private void reimprimirEtiquetas() {
      
      //Ensayos oensayos = new Ensayos();
      //ModelosManager oModelosManager = new ModelosManager();
      //bool esIdu = true;
      //string file = "W:\\wdir\\iduodu\\Mantenimiento\\2011\\2011-10-20_reimprimir_etiquetas\\Modelos-Seriales.txt";
      //using (StreamReader sr = new StreamReader(file))
      //{
      //  string line;
      //  // Read and display lines from the file until the end of 
      //  // the file is reached.
      //  List<string> lines = new List<string>();
      //  while ((line = sr.ReadLine()) != null)
      //  {
      //    if (line.StartsWith("--"))
      //      continue;
      //    if (line.StartsWith("#"))
      //    {
      //      esIdu = true;
      //      if (line.Contains("Conden"))
      //        esIdu = false;
      //      oModelosManager.EsIdu = esIdu;
      //      continue;
      //    }

      //    string[] datu = line.Split(',');
      //    oensayos.Aprobado = true;
      //    oensayos.Serie = datu[1].Trim();

      //    modeloinfo = oModelosManager.ObtenerModeloPorNombre(datu[0].Trim());

      //    this.ImpresionEtiquetas(oensayos, null, false);
      //  }
      //}
      //return;

      
      ModelosManager oModelosManager = new ModelosManager();
      oModelosManager.EsIdu = false;
      EnsayosManager ensmanager = new EnsayosManager();
      int iSerieCounter = 501;
      string file = "C:\\dago\\wdir\\carrier\\Mantenimiento\\2012\\2012-01-23_PrintLabels\\Modelos-Seriales.txt";
      using (StreamReader sr = new StreamReader(file))
      {
        string line;
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (line.StartsWith("--"))
            continue;

          string[] datu = line.Split(',');
          
          int cantidad = Convert.ToInt32(datu[0].Trim());
          modeloinfo = oModelosManager.ObtenerModeloPorNombre(datu[1].Trim());

          for(int i = 0; i<cantidad;i++)
          {
            //Serie Starts	4811A99000
            //Date	12/4/2011 23:59
            EnsayosODU ensayoaprobado = accesoplc.LeerValoresEnsayo() as EnsayosODU; 
            
            ensayoaprobado.Fecha = new DateTime(2011, 12, 4, 23, 59, 59);
            ensayoaprobado.Serie = string.Format("4811A{0}", iSerieCounter.ToString("99000"));

            ensayoaprobado.Aprobado = true;
            ensayoaprobado.Marca = modeloinfo.Marca;
            ensayoaprobado.Modelo = modeloinfo.Nombremodelo;
            ensayoaprobado.Tiempoensayo = 99;
            ensayoaprobado.Codigo = "0";
            ensayoaprobado.OrdenFabricacion = "reimpresion_2012-01-26";

            ensmanager.GuardarValoresEnsayo(ensayoaprobado, ensayoaprobado.Serie);
            
            this.ImpresionEtiquetas(ensayoaprobado, null, false);
            iSerieCounter++;
          }
        }
      }
      return;

      
    }    

    private void btnEtiquetas_Click(object sender, RoutedEventArgs e)
    {
      //reimprimirEtiquetas();
      //MessageBox.Show("Listo");
      //return;

      try
      {
        Consultaxaml formconsultaetiquetas = new Consultaxaml();
        formconsultaetiquetas.ShowDialog();
      }
      catch (Exception ex)
      {
          logger.Error("btnEtiquetas_Click()", ex);
          excepcion formularioexcepciones = new excepcion(ex);
          formularioexcepciones.ShowDialog();
          formularioexcepciones=null;
      }
    }

    private void btnTeclado_Click(object sender, RoutedEventArgs e)
    {
        try
        {
          System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start("osk");
        }
        catch (Exception ex)
        {
          logger.Error("btnTeclado_Click()", ex);
          excepcion formularioexcepciones = new excepcion(ex);
          formularioexcepciones.ShowDialog();
          formularioexcepciones=null;  
        }
    }

    private void btnShutDown_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (confirmacioneliminar.Show("Apagar equipo", "¿Está seguro de que desea apagar el equipo?") == false)
        {
          if (confirmacioneliminar.Show("Cerrar Aplicación ODU", "¿Está seguro de que desea cerrar la aplicación?") == true)
          {
            App.Current.Shutdown();
          }

          return;
        }

        btnShutDown.Cursor = System.Windows.Input.Cursors.Wait;
        Process proceso = new Process();
        proceso.StartInfo.UseShellExecute = false;
        proceso.StartInfo.RedirectStandardOutput = true;
        proceso.StartInfo.FileName = "shutdown.exe";
        proceso.StartInfo.Arguments = "-f -s -t 01";
        proceso.Start();

        btnShutDown.Cursor = System.Windows.Input.Cursors.Arrow;

      }
      catch (Exception ex)
      {
        logger.Error("btnShutDown_Click()", ex);
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      if (ManagerUsuarios.sfUser == null)
      {
        excepcion formmsg = new excepcion("Seguridad", "No ha iniciado sesión.");
        formmsg.ShowDialog();
        formmsg = null;

        return;
      }
      try
      {
        WPFiDU.Utils.PiezasOkManager.resetPiezas(ManagerUsuarios.sfUser.sgu__username);
        this.txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();

      }
      catch (Exception ex)
      {
        logger.Error("btnReset_Click()", ex);
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones = null;
      }
      //try
      //{
      //  if (ManagerUsuarios.sfUser == null)
      //  {
      //    confirmacioneliminar.Show("No ha iniciado sesión.");
      //    return;
      //  }
      //  WPFiDU.Utils.PiezasOkManager.resetPiezas(ManagerUsuarios.sfUser.sgu__username);
      //  this.txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();
      //}
      //catch (Exception ex)
      //{
      //  logger.Error("btnReset_Click()", ex);
      //  excepcion formularioexcepciones = new excepcion(ex);
      //  formularioexcepciones.ShowDialog();
      //  formularioexcepciones=null;
      //}
    }
    #endregion GUI Events

    private void btnCleanOrdenFabricacion_Click(object sender, RoutedEventArgs e)
    {
      this.txtOrdenFabricacion.Text = "";
      this.txtOrdenFabricacion.Focus();
    }

    private void btnCleanNroSerie_Click(object sender, RoutedEventArgs e)
    {
      this.txtUltimo.Text = "";
      this.txtUltimo.Focus();
    
    }

    private void txtOrdenFabricacion_GotFocus(object sender, RoutedEventArgs e)
    {
      lblOrdenFabricacion.Foreground = mForegroundBrushGray;
    }

    private void txtOrdenFabricacion_LostFocus(object sender, RoutedEventArgs e)
    {
      txtOrdenFabricacion_TextChanged(txtOrdenFabricacion, null);
    }

    
    private void txtOrdenFabricacion_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (string.IsNullOrEmpty(txtOrdenFabricacion.Text)
        || txtOrdenFabricacion.Text.Trim().Equals("N\\A")
        || !txtOrdenFabricacion.Text.Trim().ToLower().StartsWith("f")
        || txtOrdenFabricacion.Text.Trim().ToLower().Length != 11)
      {
        lblOrdenFabricacion.Foreground = mForegroundBrushRed;
        //this.lblSerialNumberMessage.Visibility = Visibility.Visible;
        if (modeloinfo != null)
          if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != 0)
            accesoplc.Escribir("ODU_SP_NumeroModeloCargado", 0);
      }
      else
      {
        lblOrdenFabricacion.Foreground = mForegroundBrushGreen;
        //this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
        if (modeloinfo != null)
          if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != modeloinfo.ID)
            accesoplc.Escribir("ODU_SP_NumeroModeloCargado", modeloinfo.ID);
      }
    }
    
    private void txtUltimo_GotFocus(object sender, RoutedEventArgs e)
    {
      if (!ReadSerialNumberFromScanner)
        return;
      lblUltimo.Foreground = mForegroundBrushGray;
      
    }

    private void txtUltimo_LostFocus(object sender, RoutedEventArgs e)
    {
      if (!ReadSerialNumberFromScanner)
        return;
      txtUltimo_TextChanged(txtUltimo, null);
      
    }

    bool isSerialnumberAvailable = false;
    private void txtUltimo_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (!ReadSerialNumberFromScanner)
        return;

      if (string.IsNullOrEmpty(txtUltimo.Text)
          || txtUltimo.Text.Trim().Equals("N\\A")
          || !txtUltimo.Text.Trim().ToLower().StartsWith("s")
          || txtUltimo.Text.Trim().ToLower().Length != 11)
      {
        lblUltimo.Foreground = mForegroundBrushRed;
        this.lblSerialNumberMessage.Visibility = Visibility.Visible;
        if (modeloinfo != null)
          if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != 0)
            accesoplc.Escribir("ODU_SP_NumeroModeloCargado", 0);
      }
      else
      {
        if (e != null)
        {
          iDU.DAO.ODUDb mODUDb = new iDU.DAO.ODUDb();
          isSerialnumberAvailable = mODUDb.IsAvailableSerialNumber(txtUltimo.Text.Trim().Substring(1), false);
          mODUDb = null;
          if (!isSerialnumberAvailable)
          {
            lblUltimo.Foreground = mForegroundBrushRed;
            this.lblSerialNumberMessage.Visibility = Visibility.Visible;
            if (modeloinfo != null)
              if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != 0)
                accesoplc.Escribir("ODU_SP_NumeroModeloCargado", 0); 
            excepcion mExcepcion = new excepcion("Número de Serie", String.Format("El número de serie ya ha sido utilizado en otro ensayo aprobado.{0} No puede ser utilizado para un nuevo ensayo.", Environment.NewLine));
            mExcepcion.ShowAndDie(3);
            return;
          }

          if (ConfigurationManager.AppSettings["CHECK_HIPOT"] == "1")
          {
            mODUDb = new iDU.DAO.ODUDb();
            bool misValidHiPot = mODUDb.isValidHiPot(txtUltimo.Text.Trim());
            mODUDb = null; 
            if (!misValidHiPot)
            {
              lblUltimo.Foreground = mForegroundBrushRed;
              this.lblSerialNumberMessage.Visibility = Visibility.Visible;
              if (modeloinfo != null)
                if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != 0)
                  accesoplc.Escribir("ODU_SP_NumeroModeloCargado", 0);
              excepcion mExcepcion = new excepcion("Número de Serie", String.Format("El número de serie no presenta ensayo aprobado de HiPot.{0} No puede ser utilizado para un ensayo.", Environment.NewLine));
              mExcepcion.ShowAndDie(3);
              return;
            }
          }
        }
        if (!isSerialnumberAvailable)
          return;
        
        lblUltimo.Foreground = mForegroundBrushGreen;
        this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
        if (modeloinfo != null)
          if (Convert.ToInt32(accesoplc.LeerItem("ODU_SP_NumeroModeloCargado")) != modeloinfo.ID)
            accesoplc.Escribir("ODU_SP_NumeroModeloCargado", modeloinfo.ID);

        Dictionary<string, string> mDict = WPFiDU.DAO.OFAccess.getOrdenFabricacion(txtUltimo.Text.Trim());
        if (mDict == null)
        {
          logger.DebugFormat("No se encontró OF para Número de Serie:'{0}'", txtUltimo.Text.Trim());
          return;
        }
        string mOrdenFab = mDict[WPFiDU.DAO.OFAccess.OrdenFabricacionFormateado_Key];
        if (String.IsNullOrEmpty(txtOrdenFabricacion.Text))
          this.txtOrdenFabricacion.Text = mOrdenFab;
        else
          if (!String.IsNullOrEmpty(mOrdenFab))
            if (this.txtOrdenFabricacion.Text.Trim() != mOrdenFab)
              if (confirmacioneliminar.Show("Orden de Fabricación",
                "La Orden de Fabricación cargada difiere de la Base de Datos. ¿Desea utilizar la Orden de Fabricación de la Base de Datos?") == false)
              {
                this.txtOrdenFabricacion.Text = mOrdenFab;
              }
      }
      
    }

    private void tgbIngreasrNroSerie_Checked(object sender, RoutedEventArgs e)
    {
      ReadSerialNumberFromScanner = true;
      setGuiDefaults(ReadSerialNumberFromScanner);

    }

    private void tgbIngreasrNroSerie_Unchecked(object sender, RoutedEventArgs e)
    {
      ReadSerialNumberFromScanner = false;
      setGuiDefaults(ReadSerialNumberFromScanner);
    }

    private void setGuiDefaults(bool ReadSerialNumberFromScanner)
    {
      if (ReadSerialNumberFromScanner)
      {
        lblUltimo.FontWeight = FontWeights.Bold;
        lblUltimo.Text = "Número de Serie";
        lblUltimo.Foreground = mForegroundBrushGray;
        txtUltimo.IsEnabled = true;
        txtUltimo.Text = "";
        this.lblSerialNumberMessage.Visibility = Visibility.Visible;
      }
      else
      {
        lblUltimo.FontWeight = FontWeights.Normal;
        lblUltimo.Text = "Ultimo N° de serie";
        lblUltimo.Foreground = mForegroundBrushWhite;
        txtUltimo.IsEnabled = false;
        this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
      }
    }

    private void txtOrdenFabricacion_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      
    }

    private void txtOrdenFabricacion_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      //e.Handled = true; 
      //txtUltimo.Text =  e.SystemText + "|"+e.ControlText + "|"+txtOrdenFabricacion.Text;
      
    }

    private void btnInterrControlada_Click(object sender, RoutedEventArgs e)
    {
      if (!ManagerUsuarios.sfUser.IsInRole(Role.Operador))
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc = null;
        return;
      }

      string mSerialNumber = txtUltimo.Text.Trim();

      if (ReadSerialNumberFromScanner)
      {
        if (mSerialNumber.ToLower().StartsWith("s") && mSerialNumber.Length == 11)
          mSerialNumber = mSerialNumber.Trim().Substring(1);
        else
        {
          excepcion formexcepciones = new excepcion("Interrupción Controlada", "El número de serie es incorrecto. No se puede registrar la Interrupción.");
          formexcepciones.ShowDialog();
          return;
        }
      }
      else
      {
        excepcion formexcepciones = new excepcion("Interrupción Controlada", "Imposible obtener el número de serie. No se puede registrar la Interrupción.");
        formexcepciones.ShowDialog();
        return;
      }

      try
      {

        wndInterrupcionControlada owndInterrupcionControlada = new wndInterrupcionControlada(mSerialNumber);
        owndInterrupcionControlada.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.Error("btnInterrControlada_Click()", ex);

        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    

     
      
    

    

  }
}
