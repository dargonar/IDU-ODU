using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using WPFiDU;
using WPFiDU.BL;
using System.Windows.Threading;
using iDU.PLC;
using iDU.CommonObjects;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Media.Imaging;
using log4net;
using System.Collections.Generic;
using iDU.BL;
using System.Diagnostics;
using System.Threading;
using iDU.CommonObjects;
using WPFiDU.Utils;

//IDU_SP_VModelo

namespace dcf001
{
	public partial class homeIDU2
  {
    #region Private Members
    /// <summary>
    /// Mantengo el modelo de testeo actual;
    /// </summary>
    private Modelo modeloinfo = null;

    private int iUltimaCodigoFalla = 0;
    private int iAnteUltimaCodigoFalla = 0;

    private PLCIDU accesoplc = null;

    private int desconexion=0;

    private static readonly ILog logger = LogManager.GetLogger(typeof(homeIDU2));
    
    private bool fallaconexion = true;

    private bool EnsayoEnCursoIDU = false;
    private bool EnsayoEnCursoIDUOld = false;
    private bool EnsayoEnCursoIDU_Parte1 = false;
    private bool EnsayoEnCursoIDU_Parte1_OLD = false;
    
    private bool EnsayoFallaIDU = false;
    private bool EnsayoFallaIDUOld = false;

    private bool EnsayoAprobadoIDU = false;
    private bool EnsayoAprobadoIDUOld = false;

  
    private DateTime TiempoInicioEnsayo = DateTime.Now;
    private TimeSpan TiempoTranscurrido = new TimeSpan(0, 0, 0);

    private DispatcherTimer intervalTimer = new DispatcherTimer();
    private DispatcherTimer ensayoFinalizadoTimer = new DispatcherTimer();

    private int EnsayoAprobadoIDU_Parte1 = -1;

    private bool PrimerLeidaTags = true;

    private bool MODO_MANTENIMIENTO_PLC_1 = false;

    private int LimiteFallas = 0;

    private string USUARIO = "N/A";

    public static int modoensayo = 0;

    private bool mPuedoLeerEstados = false;

    private SolidColorBrush mBrushManualMode = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xF9, 0xFB, 0x52));
    private SolidColorBrush mBrushOkOn = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x35, 0xEB, 0x00));
    private SolidColorBrush mBrushOkOff = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x00, 0xB4, 0xEB));

    private SolidColorBrush mForegroundBrushWhite = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF));
    private SolidColorBrush mForegroundBrushRed = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0x00, 0x00));
    private SolidColorBrush mForegroundBrushGreen = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x00, 0xFF, 0x00));
    private SolidColorBrush mForegroundBrushGray = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x99, 0x99, 0x99));
    private bool ReadSerialNumberFromScanner = false;

    
    #endregion Private Members
    
    #region Public Members
    public bool PuedoLeerEstados
    {
      get { return mPuedoLeerEstados; }
      set { mPuedoLeerEstados = value; }

    }
    #endregion Public Members

    #region Constructor & Initializers

    public homeIDU2()
		{

      this.InitializeComponent();

      WPFiDU.Utils.OneAppInstanceChecker.KillOldInstance();
      log4net.Config.XmlConfigurator.Configure();
      log4net.GlobalContext.Properties["Username"] = "N/D";
      log4net.GlobalContext.Properties["DCF"] = System.Environment.MachineName;
      
      ReadSerialNumberFromScanner = Convert.ToInt32(ConfigurationManager.AppSettings["ReadSerialNumberFromScanner"]) == 1;
      setGuiDefaults(ReadSerialNumberFromScanner);

      doLogin();
      try
      {
        
        NumeroDeSerieManager numserieman = new NumeroDeSerieManager();
        if (!ReadSerialNumberFromScanner) 
          txtUltimo.Text = numserieman.ObtenerUltimoNumeroDeSerie();
        
        accesoplc = new PLCIDU();
        accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
        intervalTimer.Interval = new TimeSpan(0, 0, 1);
        intervalTimer.Tick += new EventHandler(TiempoEnsayoPLC1_tick);
        ensayoFinalizadoTimer.Interval = new TimeSpan(0, 0, 1);
        ensayoFinalizadoTimer.Tick += new EventHandler(ensayoFinalizadoTimer_tick);
        Inicializacion(false);
        LoadInitialData();
          
      }
      catch (Exception ex)
      {
        logger.Error("Inicio de aplicación", ex);
        //logger.ErrorFormat("homeIDU2():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //  , ex.Message
        //  , ex.StackTrace
        //  , ex.InnerException != null ? ex.InnerException.Message : "");

        excepcion formexcepcion = new excepcion(ex);
        formexcepcion.ShowDialog();
      }
    }
    
    private void doLogin(){
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
    private void LoadInitialData()
    {
      try
      {         
        txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();
        lblVersion.Content = System.Environment.MachineName + " | Versión " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
      catch(Exception e)
      {
        logger.Error("LoadInitialData()", e);
        //logger.ErrorFormat("void LoadInitialData():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //  , e.Message
        //  , e.StackTrace
        //  , e.InnerException != null ? e.InnerException.Message : "");

        excepcion formexcepcion = new excepcion(e);
        formexcepcion.ShowDialog();
      }
    }

    private void Inicializacion(bool inicializado)
    {
      if (!inicializado)
      {
        txtblkInfoFalla.Text = "";
        txtblFinalizacionEnsayo.Text = "";
        List<string> items = new List<string>();
        items.Add(PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK"));
        items.Add(PLC.ResolverItem("IDU_ST_EnsayoEnCurso"));
        items.Add(PLC.ResolverItem("IDU_SP_ModoSeleccionado"));
        items.Add(PLC.ResolverItem("IDU_ST_NumeroDeFalla"));

        string[] valoresiniciales = accesoplc.LeerItems(items.ToArray());

        if (!Convert.ToInt32(valoresiniciales[0]).Equals(0) && !Convert.ToInt32(valoresiniciales[0]).Equals(-1))
        {
          EnsayoAprobadoIDU = true;
        }

        if (!Convert.ToInt32(valoresiniciales[1]).Equals(0) 
          && !Convert.ToInt32(valoresiniciales[1]).Equals(-1))
        {
          EnsayoEnCursoIDU = true;
        }

        if (int.Parse(valoresiniciales[2]) != -1)
          modoensayo = int.Parse(valoresiniciales[2]);

        if (EnsayoEnCursoIDU)
          if (int.Parse(valoresiniciales[3]) != -1)
            chequearFalla(int.Parse(valoresiniciales[3]));

        System.Configuration.Configuration config2 = 
            ConfigurationManager.OpenExeConfiguration(
              System.Reflection.Assembly.GetExecutingAssembly().Location);

        //AppSettingsSection app = (AppSettingsSection)config2.GetSection("appSettings");
        //app.Settings.Remove("ModoEnsayoIDU");
        //app.Settings.Add("ModoEnsayoIDU", modoensayo.ToString());
        //config2.Save(ConfigurationSaveMode.Modified);
        //ConfigurationManager.RefreshSection("appSettings");

        if ((modoensayo >= 0) && ConfigurationManager.AppSettings["AUTO_CONEXION_DCF"] == "1")
        {
          conexionplc oconexionplc = new conexionplc(true);
          oconexionplc.conectarDCF(modoensayo, true);
          oconexionplc = null;
          accesoplc = null;
        }

      }

      else
      {

        //System.GC.SuppressFinalize(accesoplc);
        if (accesoplc != null)
        { accesoplc.OnPLCEvent -= new PLC.PLCEvent(accesoplc_OnPLCEvent); }
        accesoplc = null;

        accesoplc = new PLCIDU();
        accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);

      }


      PrimerLeidaTags = true;
      ResetFallasyTimers();
      ResetEstados();
      if (accesoplc == null)
      {
        accesoplc = new PLCIDU();
        accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
      }
      accesoplc.LeerEstadosPantallaPrincipalAsincronicamente();

      desconexion = 0;

      
      //List<string> m_items = new List<string>();
      //m_items.Add(PLC.ResolverItem("IDU_SP_VModelo"));

      //string[] m_valoresiniciales = accesoplc.LeerItems(m_items.ToArray());
      //int currentPLCModeloId = Convert.ToInt32(m_valoresiniciales[0]);
      int currentPLCModeloId = LastTestedModelManager.getLastTestedModelId();
      
      if (!EnsayoEnCursoIDU)
        if (currentPLCModeloId > 0)
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
    
    #endregion Constructor & Initializers
    
    #region Timers Events

    private void TiempoEnsayoPLC1_tick(object source, EventArgs e)
    {
      TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
      lblTiempoEnsayo.Content =FormatearTiempo(TiempoTranscurrido.TotalSeconds);
    }

    #endregion Timers Events

    #region Acquisition Events

    void accesoplc_OnPLCEvent(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
    {
      Dispatcher.Invoke( DispatcherPriority.Normal, 
      new PLC.PLCEvent(accesoplc_OnPLCEventX), tags, valores );
    }
    
    void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
    {
      //bool cambioCantidadEnsayosParteB = false;
      //bool cambioCantidadEnsayosParteB_2 = false;
      try
      {
        EnsayoEnCursoIDUOld           = EnsayoEnCursoIDU;
        EnsayoFallaIDUOld             = EnsayoFallaIDU;
        EnsayoAprobadoIDUOld          = EnsayoAprobadoIDU;
        EnsayoEnCursoIDU_Parte1_OLD   = EnsayoEnCursoIDU_Parte1;

        //EnsayoFallaIDU                = false;
        //EnsayoAprobadoIDU             = false;

        if ((valores[0].Quality != 192))
          fallaconexion = true;
        else
          fallaconexion = false;

        for (int i = 0; i < tags.Length; i++)
        {
            if (valores[i].Value == null)
              continue;
            if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK"))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                EnsayoAprobadoIDU = true;
              else
                EnsayoAprobadoIDU = false;
            }
            //else if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK_2") && (modoensayo == 1 || modoensayo == 2))
            //{
            //  if (!Convert.ToInt32(valores[i].Value).Equals(0))
            //    EnsayoAprobadoIDU = true;
            //  else
            //    EnsayoAprobadoIDU = false;

            //}
            else if (tags[i] == PLC.ResolverItem("IDU_I_PulsadorStop"))
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
            else if (tags[i] == PLC.ResolverItem("IDU_M_ModoMantenimiento"))
                MODO_MANTENIMIENTO_PLC_1 = !Convert.ToInt32(valores[i].Value).Equals(0);
            else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroDeFalla"))
            {
              chequearFalla(Convert.ToInt32(valores[i].Value));
              int codigo = Convert.ToInt32(valores[i].Value);
              if (codigo == 0)
              {
                txtblkInfoFalla.Text= "";
                continue;
              }
              EnsayosManager manensayo = new EnsayosManager();
              Ensayos e = new Ensayos();
              e.Codigo = codigo.ToString();
              txtblkInfoFalla.Text = codigo.ToString() + ": " + manensayo.ObtenerDescripcionFalla(e);
            }
            //else if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoFalla") && modoensayo == 2)
            //{
            //  // chequearFalla(Convert.ToInt32(valores[i].Value));
            //  if (!Convert.ToInt32(valores[i].Value).Equals(0))
            //  {
            //    EnsayoAprobadoIDU_Parte1 = 1;
            //  }
            //  else
            //  {
            //    EnsayoAprobadoIDU_Parte1 = 0;
            //  }
            //}
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EnsayoEnCurso") 
              && (modoensayo == 0 || modoensayo == 3))
            {
              //logger.DebugFormat("OnTagChange() IDU_ST_EnsayoEnCurso::", valores[i].Value.ToString());
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                
                EnsayoEnCursoIDU = true;
                TiempoInicioEnsayo = DateTime.Now;
                intervalTimer.Start();
                txtblkInfoFalla.Text = "";
                txtblFinalizacionEnsayo.Text = "";

              }
              else
              {
                EnsayoEnCursoIDU = false;
                intervalTimer.Stop();
                TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
              }

            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EnsayoEnCurso") && (modoensayo == 2))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                EnsayoEnCursoIDU_Parte1 = true;
              }
              else
              {
                EnsayoEnCursoIDU_Parte1 = false;
              }
            }
            else if (tags[i] == "IDU_MD_CorrienteMedida")
              txtCorriente1.Text = valores[i].Value.ToString();
            else if (tags[i] == "IDU_MD_VelocidadCalculada")
              txtVelocidad1.Text = valores[i].Value.ToString();
            else if (tags[i] == "IDU_ST_CopiaEstadoODU")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotDummy1.Tag = "green";
              else
                dotDummy1.Tag = null;
            }
            else if (tags[i] == "IDU_Q_EntradaEstadoValvula4Vias")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotModoCalor1.Tag = "green";
              else
                dotModoCalor1.Tag = null;
            }
            else if (tags[i] == "IDU_Q_ReleSeleccionBajaTension")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotBajaTension2.Tag = "green";
              else
                dotBajaTension2.Tag = null;
            }
            else if (tags[i] == "IDU_Q_EntradaEstadoElectroVentilador")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotElectro1.Tag = "green";
              else
                dotElectro1.Tag = null;
            }
            else if (tags[i] == "IDU_SP_CopiaEstadoIDU")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotIDUEnergizado1.Tag = "green";
              else
                dotIDUEnergizado1.Tag = null;
            }
            //UNDO
            //else if (tags[i] == "ModoCalorEstadoIDU")
            //{
            //  if (!Convert.ToInt32(valores[i].Value).Equals(0))
            //    dotModoCalor1.Tag = "green";
            //  else
            //    dotModoCalor1.Tag = null;
            //}
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioEnsayoPulsador"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Inicio de ensayo por pulsador";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoCalor"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                  lblPasosEnsayo.Content = "Inicio en modo calor";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoFrio"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Inicio en modo frío";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EsperaMontajePanelFrontal"))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              { 
                lblPasosEnsayo.Content = "Espera montaje panel frontal";
                lblReinicieTest.Visibility = Visibility.Visible;
              }
              else 
              {
                lblReinicieTest.Visibility = Visibility.Hidden;
              }

            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoAltaVelocidad"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Ensayo a alta velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaTension"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Ensayo en baja tensión";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaVelocidad"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Ensayo a baja velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_CierreValvulaLiquido"))
            {
                //if (!Convert.ToInt32(valores[i].Value).Equals(0))
                //    lblPasosEnsayo.Content = "Cierre válvula de líquido";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_FinalizacionEnsayo"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Finalización de ensayo";
            }
            else if (tags[i] == "IDU_SP_EtiquetaPendiente")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    if (accesoplc != null)
                        accesoplc.Escribir("IDU_SP_EtiquetaPendiente", 0);
            }
        }

        PrimerLeidaTags = false;
        FinalizacionEnsayo();

      }
      catch (Exception e)
      {
        logger.Error("accesoplc_OnPLCEventX()", e);
          //logger.ErrorFormat("void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          //, e.Message
          //, e.StackTrace
          //, e.InnerException != null ? e.InnerException.Message : "");
          
          excepcion formexcepcion = new excepcion(e);
          formexcepcion.ShowDialog();
      }
      ActualizarLabels();

    }
    #endregion Acquisition Events
    
    #region Acquisition Functions
    private void chequearFalla(int CodFalla)
    {
      if (CodFalla <= 0)
        return;
      if (!EnsayoEnCursoIDU)
        return;

      if (iUltimaCodigoFalla != 0)
      {
        iAnteUltimaCodigoFalla = iUltimaCodigoFalla;
        iUltimaCodigoFalla = CodFalla;
        LimiteFallas = 2;
        TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
        //this.FinalizacionEnsayo();
        return;
      }
      else
      {
        iUltimaCodigoFalla = CodFalla;
        EnsayosManager manensayos = new EnsayosManager();
        if (manensayos.ObtenerPrioridadFalla(CodFalla) == true)
        {
          LimiteFallas = 2;
          TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
          //FinalizacionEnsayo();
          return;
        }
      }
      return;
    }

    private void ActualizarLabels()
    {
      //Storyboard t = null;
      if (fallaconexion == true && (modoensayo != 1))
      {
        lblInfo.Foreground = mForegroundBrushRed;
        lblInfo.Content = "FALLA CONEXION CON PLC";
        //t = (Storyboard)FindResource("tmlIDU1Off");
        //t.AutoReverse = false;
        //t.Begin(this);
        rctIDU1.Stroke = mBrushOkOff;
      }
      if (fallaconexion == false && (modoensayo != 1))
      {
        lblInfo.Foreground = mForegroundBrushGreen;
        lblInfo.Content = "CONEXION CON PLC OK";
        //t = (Storyboard)FindResource("tmlIDU1On");
        //t.AutoReverse = false;
        //t.Begin(this);
        rctIDU1.Stroke = mBrushOkOn;

      }
      if (!fallaconexion)
      {
        if (MODO_MANTENIMIENTO_PLC_1)
        {
          //t = (Storyboard)FindResource("tmlIDU1ModoMant");
          //t.AutoReverse = false;
          //t.Begin(this);
          rctIDU1.Stroke = mBrushManualMode;
        }
      }
    }

    /// <summary>
    /// Timer de ensayo finaizado
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void ensayoFinalizadoTimer_tick(object source, EventArgs e)
    {
      ensayoFinalizadoTimer.Stop();
      procesarResultadoEnsayo();
    }

    private int iErrorNumberChecker=0;

    private void procesarResultadoEnsayo()
    {
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
        mOrdenFabricacion = mOrdenFabricacion.Trim().Substring(1,7);
      else
      {
        excepcion formexcepciones = new excepcion("Ensayo Finalizado IDU", "La Orden de Fabricación es incorrecta. El ensayo no tendrá efecto.");
        formexcepciones.ShowDialog();
        formexcepciones = null;
        ResetEstados();
        return;
      }
        
      //logger.DebugFormat("procesarResultadoEnsayo():: Entro!");
      if (EnsayoAprobadoIDU == true)
      {

        EnsayosIDU ensayoaprobado = accesoplc.LeerValoresEnsayo() as EnsayosIDU;
        ensayoaprobado.Aprobado = true;
        ensayoaprobado.Marca = txtMarca.Text;
        ensayoaprobado.Modelo = txtModelo.Text;
        ensayoaprobado.TiempoEnsayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);

        ensayoaprobado.Fecha = DateTime.Now;
        ensayoaprobado.Codigo = "0";
        ensayoaprobado.OrdenFabricacion = mOrdenFabricacion;
        
        if (ManagerUsuarios.sfUser == null)
          ensayoaprobado.Usuario = USUARIO;
        else
          ensayoaprobado.Usuario = ManagerUsuarios.sfUser.sgu__username;
        
        
        
        EnsayosManager ensmanager = new EnsayosManager();

        //logger.DebugFormat("procesarResultadoEnsayo():: EnsayosIDU ensayoaprobado='{0}'", ensayoaprobado.ToString());
        if (!ReadSerialNumberFromScanner)
          ensmanager.GuardarValoresEnsayo(ensayoaprobado, null);
        else
        {
          ensmanager.GuardarValoresEnsayo(ensayoaprobado, mSerialNumber);
          //ensmanager.GuardarValoresEnsayo(ensayoaprobado, this.txtUltimo.Text);
        }
        WPFiDU.Utils.PiezasOkManager.addPiezaOk();
        txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();


        if (modoensayo == 0 || modoensayo == 3)
        {
          txtblFinalizacionEnsayo.Foreground = mForegroundBrushGreen;
          txtblFinalizacionEnsayo.Text = "Se terminó el ensayo con éxito";
        }

        Ensayos infoens = ensayoaprobado;

        //TODO: DUDA por que esta aca??!?!
        if (modeloinfo == null)
        {
          excepcion form_msg = new excepcion("Selección de Modelo", "Usted no seleccionó ningun modelo al iniciar el ensayo");
          form_msg.ShowDialog();
          form_msg = null;
          ResetEstados();
        }
        else
          ImpresionEtiquetas(infoens, null, false);
        
      }
      else
      {
        //if ((modoensayo == 0 || modoensayo == 1))


        EnsayosIDU ensayofalla = accesoplc.LeerValoresEnsayo() as EnsayosIDU;
        ensayofalla.Aprobado = false;
        ensayofalla.Marca = txtMarca.Text;
        ensayofalla.Modelo = txtModelo.Text;
        ensayofalla.TiempoEnsayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);
        ensayofalla.Fecha = DateTime.Now;
        ensayofalla.OrdenFabricacion = mOrdenFabricacion;
        
        if (ManagerUsuarios.sfUser == null)
          ensayofalla.Usuario = USUARIO;
        else
          ensayofalla.Usuario = ManagerUsuarios.sfUser.sgu__username;
          
        ensayofalla.Codigo = accesoplc.LeerItem("IDU_ST_NumeroDeFalla");

        //logger.DebugFormat("procesarResultadoEnsayo():: ensayodesaprobado ErrCode='{0}'", ensayofalla.Codigo.ToString());  
        if(ensayofalla.Codigo.Trim().Equals("0"))
        {
          //logger.DebugFormat("procesarResultadoEnsayo():: ensayodesaprobado iErrorNumberChecker='{0}'", iErrorNumberChecker.ToString()); 
          if (iErrorNumberChecker < 3)
          {
            iErrorNumberChecker = iErrorNumberChecker + 1;
            //logger.DebugFormat("procesarResultadoEnsayo():: ensayodesaprobado call::ensayoFinalizadoTimer.Start()"); 
            ensayoFinalizadoTimer.Start();
            return;  
          }
        }
        
        iErrorNumberChecker=0;
        EnsayosManager ensmanager = new EnsayosManager();

        
        
        if (!ReadSerialNumberFromScanner)
          ensmanager.GuardarValoresEnsayo(ensayofalla, null);
        else
        {
          ensmanager.GuardarValoresEnsayo(ensayofalla, mSerialNumber);
          //ensmanager.GuardarValoresEnsayo(ensayofalla, this.txtUltimo.Text);
        }
          

        //logger.DebugFormat("FinalizacionEnsayo():: EnsayosIDU ensayofalla='{0}'", ensayofalla.ToString());


        if (modoensayo == 0)
        {
          txtblFinalizacionEnsayo.Foreground = mForegroundBrushRed;
          txtblFinalizacionEnsayo.Text = "Se terminó el ensayo con fallas";
        }

        string fallaDesc = ensmanager.ObtenerDescripcionFalla(ensayofalla);

        ImpresionEtiquetas(ensayofalla, fallaDesc, true);

      }
      ResetFallasyTimers();
      ResetEstados();
      NumeroDeSerieManager numserman = new NumeroDeSerieManager();
      numserman.GuardarNumeroDeSerie();
      if (!ReadSerialNumberFromScanner)
        txtUltimo.Text = numserman.ObtenerUltimoNumeroDeSerie();
      else
        txtUltimo.Text = "";
      
      //Meta Hack
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0);
      accesoplc.Escribir("IDU_ST_NumeroDeFalla", 0);
    }

    private void FinalizacionEnsayo()
    {
      //logger.DebugFormat("FinalizacionEnsayo():: modoensayo='{0}'", modoensayo.ToString());

      bool bEnsayoFinalizo = false;

      if (((!EnsayoEnCursoIDU) && (EnsayoEnCursoIDUOld))
          || (LimiteFallas == 2))
      {
        bEnsayoFinalizo = true;
        ensayoFinalizadoTimer.Start();
      }
      /*
       if (bEnsayoFinalizo)
        if(modoensayo == 0)
        {
          if (accesoplc != null)
          {
            //accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
            //accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0); 
          }
        }
        else
        {
          //accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
        }
       */
    }

    private void ResetEstados()
    {
      //Estaba al recibir evento del selector de Modelo.
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0);
      accesoplc.Escribir("IDU_ST_NumeroDeFalla", 0); 
      
      EnsayoEnCursoIDU = false;
      EnsayoEnCursoIDUOld = false;
      EnsayoEnCursoIDU_Parte1 = false;
      EnsayoEnCursoIDU_Parte1_OLD = false;

      EnsayoFallaIDU = false;
      EnsayoFallaIDUOld = false;

      EnsayoAprobadoIDU = false;
      EnsayoAprobadoIDUOld = false;
      
      if(ReadSerialNumberFromScanner)
        txtUltimo.Focus();
    }

    private void ResetFallasyTimers()
    {
      this.iUltimaCodigoFalla = 0;
      this.iAnteUltimaCodigoFalla = 0;
      this.EnsayoFallaIDU = false;
      this.EnsayoFallaIDUOld = false;
      intervalTimer.Stop();
    }

    private void cleanPLC1()
    {

      txtCorriente1.Text = "0";
      txtVelocidad1.Text = "0";
      dotBajaTension2.Tag = null;
      dotDummy1.Tag = null;
      dotElectro1.Tag = null;
      dotIDUEnergizado1.Tag = null;
      dotModoCalor1.Tag = null;
      System.Windows.Media.SolidColorBrush pincel = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
      lblInfo.Foreground = pincel;
      lblInfo.Content = "PLC SIN ACTIVIDAD";
      txtblFinalizacionEnsayo.Text = "";
      Storyboard t = null;
      t = (Storyboard)FindResource("tmlIDU1Off");
      t.AutoReverse = false;
      t.Begin(this);
    }
    #endregion Acquisition Functions
    
    #region GUI Events
    /// <summary>
    /// Evento que handlea la seleccion del modelo a  testear.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="selectedModelo"></param>
    private void modeloafabricar_OnModeloSelectionChanged(object sender, Modelo selectedModelo)
    {
      // HACK: ESTO ES PARA LEVANTAR EL ULTIMO MODELO CARGADO. 
      //accesoplc.Escribir("IDU_SP_VModelo", selectedModelo.ID);
      accesoplc.Escribir("IDU_SP_VModelo", 0);
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
      accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0);
      accesoplc.Escribir("IDU_ST_NumeroDeFalla", 0); 
      this.txtOrdenFabricacion.Text="";
      this.txtUltimo.Text = "";
      try
      {
        
        modeloinfo = selectedModelo;


        txtReferencia.Text = modeloinfo.Referencia.Trim();
        txtModelo.Text = modeloinfo.Nombremodelo.Trim();
        txtMarca.Text = modeloinfo.Marca.Trim();
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

        
      }

      catch (Exception ex)
      {
        logger.Error("modeloafabricar_OnModeloSelectionChanged()", ex);
     //   logger.ErrorFormat(" modeloafabricar_OnModeloSelectionChanged(object sender, Modelo selectedModelo):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
     //, ex.Message
     //, ex.StackTrace
     //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formexcepciones = new excepcion(ex);
        formexcepciones.ShowDialog();

      }
    }

    private void btnEnsayos_Click(object sender, RoutedEventArgs e)
    {
      if(!ManagerUsuarios.sfUser.IsInRole(Role.Operador) )
      {
        excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        exc.ShowDialog();
        exc=null;
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
        //logger.ErrorFormat(" btnEnsayos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        // , ex.Message
        //, ex.StackTrace
        // , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnManten_Click(object sender, RoutedEventArgs e)
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

        mantenimiento mant = new mantenimiento();
        mant.ShowDialog();

      }
      catch (Exception ex)
      {

        logger.Error("btnManten_Click()", ex);
      //  logger.ErrorFormat(" btnManten_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //, ex.Message
      //, ex.StackTrace
      // , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnFormatos_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        formatosetiquetas formetiquetas = new formatosetiquetas();
        formetiquetas.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.Error("btnFormatos_Click()", ex);
        //logger.ErrorFormat(" btnFormatos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //, ex.Message
        //, ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnMantenProd_Click(object sender, RoutedEventArgs e)
    {
      if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.SuperAdmin))
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
      // logger.ErrorFormat(" btnMantenProd_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //   , ex.Message
      //, ex.StackTrace
      // , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
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
      }
    }

    private void btnConfig_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        configuracion formconfiguracion = new configuracion(true);
        formconfiguracion.ShowDialog();
        //formconfiguracion.Show();
      }
      catch (Exception ex)
      {
        logger.Error("btnConfig_Click()", ex); 
        //logger.ErrorFormat(" btnConfig_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        // , ex.Message
        // , ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }

    private void btnCambiarModelo_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        if (EnsayoEnCursoIDU == true)
        {
          confirmacioneliminar.Show("No se puede cambiar el modelo mientras se este ensayando un equipo");
          return;
        }


        modeloafabricar formcambiarmodelo = new modeloafabricar();

        formcambiarmodelo.OnModeloSelectionChanged += new OnModeloSelectionChanged(modeloafabricar_OnModeloSelectionChanged);
        formcambiarmodelo.ShowDialog();

        if (formcambiarmodelo.Modelo != null)
        {
          //TODO: armar el sub que limpie el form;
          //cleanForm();
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
        //logger.ErrorFormat(" btnCambiarModelo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //, ex.Message
        //, ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
      }

    }

    private void btnCambiarNroSerie_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        cambionumeroserie formcambiarnumerodeserie = new cambionumeroserie();
        formcambiarnumerodeserie.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.Error("btnCambiarNroSerie_Click()", ex); 
        //logger.ErrorFormat(" btnCambiarNroSerie_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //  , ex.Message
        //  , ex.StackTrace
        //  , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones = null;
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
      //  logger.ErrorFormat(" btnTeclado_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //, ex.Message
      //, ex.StackTrace
      //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones = null;
      }
    }

    private void reimprimirEtiquetas()
    {

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
      oModelosManager.EsIdu = true;
      EnsayosManager ensmanager = new EnsayosManager();
      ensmanager.EsIdu = true;
      int iSerieCounter = 401;
      string file = "C:\\dago\\wdir\\carrier\\Mantenimiento\\2012\\2012-01-23_PrintLabels\\Modelos-Seriales_IDU.txt";
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

          for (int i = 0; i < cantidad; i++)
          {
            //Serie Starts	4811A99000
            //Date	12/4/2011 23:59
            EnsayosIDU ensayoaprobado = accesoplc.LeerValoresEnsayo() as EnsayosIDU;

            ensayoaprobado.Fecha = new DateTime(2011, 12, 4, 23, 59, 59);
            ensayoaprobado.Serie = string.Format("4811A{0}", iSerieCounter.ToString("99000"));

            ensayoaprobado.Aprobado = true;
            ensayoaprobado.Marca = modeloinfo.Marca;
            ensayoaprobado.Modelo = modeloinfo.Nombremodelo;
            ensayoaprobado.TiempoEnsayo= 99;
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
        //logger.ErrorFormat(" btnEtiquetas_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //, ex.Message
        //, ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }

    private void btnHabilitar_Click(object sender, RoutedEventArgs e)
    {
      doLogin(); 
      try
      {
        
        //Teclado tec = new Teclado();
        //tec.Texto = "Ingrese el password";
        //tec.ShowDialog();

        //string pass = tec.Password;

        //ManagerUsuarios manusuarios = new ManagerUsuarios();
        //USUARIO = manusuarios.ObtenerUsuario(pass);
         
      }
      catch (Exception ex)
      {
        logger.Error("btnHabilitar_Click()", ex); 
        //logger.ErrorFormat(" btnHabilitar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //, ex.Message
        //, ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
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
          if (confirmacioneliminar.Show("Cerrar Aplicación IDU", "¿Está seguro de que desea cerrar la aplicación?") == true)
          {
            App.Current.Shutdown();
            //App.Current.MainWindow.Close();
            //this.Close();
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
        //logger.ErrorFormat(" btnShutDown_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //  , ex.Message
        //  , ex.StackTrace
        //  , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      if (ManagerUsuarios.sfUser == null)
      {
        excepcion formmsg = new excepcion("Seguridad","No ha iniciado sesión.");
        formmsg.ShowDialog();
        formmsg=null;
        
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
        //logger.ErrorFormat(" btnReset_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //, ex.Message
        //, ex.StackTrace
        //, ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        formularioexcepciones=null;
      }
    }
    #endregion GUI Events

    #region GUI Functions
    private string FormatearTiempo(double tiempo)
    {
      int m = (int)tiempo / 60;
      int s = (int)tiempo - m;

      string segundos = string.Empty;
      string minutos = string.Empty;
      string tiempoformateado = string.Empty;
     
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
    #endregion GUI Functions

    #region Printing Functions
    private void ImpresionEtiquetas(Ensayos infoens, string falla_desc, bool es_falla)
    {
      if (modeloinfo == null)
        return;
      WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerEx = 
        new WPFiDU.Etiquetas.EtiquetasManagerEx(true);

      ConfiguracionManager configurador = new ConfiguracionManager();

      if (es_falla)
      {

        if(!configurador.ObtenerPrintErrorTests())
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

        //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        //System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        string nombreimpresora = configurador.ObtenerImpresoraProducto();
        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExProd = 
          new WPFiDU.Etiquetas.EtiquetasManagerEx(true);
        oEtiquetasManagerExProd.ImprimirImagen(ImagenTemp, nombreimpresora, false, modeloinfo.Nombremodelo + "-" + infoens.Serie);
      }

      //Impresion Bulto
      if (configurador.ObtenerImpresoraBultoHabilitada())
      {
        Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
          , modeloinfo.BackgroundBulto
          , infoens);
        
        //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        //System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        string nombreimpresora = configurador.ObtenerImpresoraBulto();

        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExBulto = 
          new WPFiDU.Etiquetas.EtiquetasManagerEx(true);
        oEtiquetasManagerExBulto.ImprimirImagen(ImagenTemp, nombreimpresora, true, modeloinfo.Nombremodelo + "-" + infoens.Serie);
      }

    }
    #endregion Printing Functions

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
      if (!WPFiDU.Utils.Utils.IsValidOrdenFabricacion(txtOrdenFabricacion.Text))
      //if (string.IsNullOrEmpty(txtOrdenFabricacion.Text)
      //  || txtOrdenFabricacion.Text.Trim().Equals("N\\A")
      //  || !txtOrdenFabricacion.Text.Trim().ToLower().StartsWith("f")
      //  || txtOrdenFabricacion.Text.Trim().ToLower().Length != 11)
      {
        lblOrdenFabricacion.Foreground = mForegroundBrushRed;
        //this.lblSerialNumberMessage.Visibility = Visibility.Visible;
        if (modeloinfo != null)
          if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != 0)
            accesoplc.Escribir("IDU_SP_VModelo", 0);
      }
      else
      {
        lblOrdenFabricacion.Foreground = mForegroundBrushGreen;
        //this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
        if (!WPFiDU.Utils.Utils.IsValidNumeroSerie(txtUltimo.Text))
        {
          if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != 0)
            accesoplc.Escribir("IDU_SP_VModelo", 0);
          return;
        }
        if (modeloinfo != null)  
          if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != modeloinfo.ID)
            accesoplc.Escribir("IDU_SP_VModelo", modeloinfo.ID);
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

        //if (string.IsNullOrEmpty(txtUltimo.Text)
        //    || txtUltimo.Text.Trim().Equals("N\\A")
        //    || !txtUltimo.Text.Trim().ToLower().StartsWith("s")
        //    || txtUltimo.Text.Trim().ToLower().Length != 11)
        if (!WPFiDU.Utils.Utils.IsValidNumeroSerie(txtUltimo.Text))
        {
          lblUltimo.Foreground = mForegroundBrushRed;
          this.lblSerialNumberMessage.Visibility = Visibility.Visible;
          if (modeloinfo != null)
            if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != 0)
              accesoplc.Escribir("IDU_SP_VModelo", 0);
        }
        else
        {
          // Chequeo que el Nro Serie no fue utilizado
          if (e != null)
          {
            iDU.DAO.IDUDb mIDUDb = new iDU.DAO.IDUDb();
            isSerialnumberAvailable = mIDUDb.IsAvailableSerialNumber(txtUltimo.Text.Trim().Substring(1), true);
            mIDUDb = null;
            if (!isSerialnumberAvailable)
            {
              lblUltimo.Foreground = mForegroundBrushRed;
              this.lblSerialNumberMessage.Visibility = Visibility.Visible;
              if (modeloinfo != null)
                if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != 0)
                  accesoplc.Escribir("IDU_SP_VModelo", 0);
              excepcion mExcepcion = new excepcion("Número de Serie",
                String.Format("El número de serie ya ha sido utilizado en otro ensayo aprobado.{0} No puede ser utilizado para un nuevo ensayo.", Environment.NewLine));
              mExcepcion.ShowAndDie(3);
              
              return;
            }
          }

          if (!isSerialnumberAvailable)
          {
            if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != 0)
              accesoplc.Escribir("IDU_SP_VModelo", 0);
            return;
          }
          
          lblUltimo.Foreground = mForegroundBrushGreen;
          this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
          if (modeloinfo != null)
            if (Convert.ToInt32(accesoplc.LeerItem("IDU_SP_VModelo")) != modeloinfo.ID)
              accesoplc.Escribir("IDU_SP_VModelo", modeloinfo.ID);

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
        txtUltimo.Focus();
        this.lblSerialNumberMessage.Visibility = Visibility.Visible;
      }
      else
      {
        lblUltimo.FontWeight = FontWeights.Normal;
        lblUltimo.Text = "Ultimo N° de Serie";
        lblUltimo.Foreground = mForegroundBrushWhite;
        txtUltimo.IsEnabled = false;
        this.lblSerialNumberMessage.Visibility = Visibility.Hidden;
      }
    }

    private void btnCleanOrdenFabricacion_Click(object sender, RoutedEventArgs e)
    {
      this.txtOrdenFabricacion.Text = "";
    }

    private void btnCleanNroSerie_Click(object sender, RoutedEventArgs e)
    {
      this.txtUltimo.Text="";
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