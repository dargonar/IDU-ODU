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

namespace dcf001
{
	public partial class homeIDU
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

    private static readonly ILog logger = LogManager.GetLogger(typeof(homeIDU));

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
    private DispatcherTimer intervalTimer2 = new DispatcherTimer();

    private int EnsayoAprobadoIDU_Parte1 = -1;

    private bool PrimerLeidaTags = true;

    private bool MODO_MANTENIMIENTO_PLC_1 = false;
    private bool MODO_MANTENIMIENTO_PLC_2 = false;

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
    
    #endregion Private Members
    
    #region Public Members
    public bool PuedoLeerEstados
    {
      get { return mPuedoLeerEstados; }
      set { mPuedoLeerEstados = value; }

    }
    #endregion Public Members

    #region Constructor & Initializers

    public homeIDU()
		{

      this.InitializeComponent();
      WPFiDU.Utils.OneAppInstanceChecker.KillOldInstance();
      log4net.Config.XmlConfigurator.Configure();
        
      try
      {
        NumeroDeSerieManager numserieman = new NumeroDeSerieManager();
        txtUltimo.Text = numserieman.ObtenerUltimoNumeroDeSerie();
        
        accesoplc = new PLCIDU();
        accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
        intervalTimer.Interval = new TimeSpan(0, 0, 1);
        intervalTimer.Tick += new EventHandler(TiempoEnsayoPLC1_tick);

        intervalTimer2.Interval = new TimeSpan(0, 0, 1);
        intervalTimer2.Tick += new EventHandler(TiempoEnsayoPLC2_tick);

        Inicializacion(false);
        LoadInitialData();
          
      }
      catch (Exception ex)
      {

        logger.ErrorFormat("homeIDU():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");

        excepcion formexcepcion = new excepcion(ex);
        formexcepcion.ShowDialog();
      }
		}

    private void LoadInitialData()
    {
      try
      {         
        txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();
        lblVersion.Content = "Versión " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
      catch(Exception e)
      {
        logger.ErrorFormat("void LoadInitialData():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , e.Message
          , e.StackTrace
          , e.InnerException != null ? e.InnerException.Message : "");

        excepcion formexcepcion = new excepcion(e);
        formexcepcion.ShowDialog();
      }

    }

    private void Inicializacion(bool inicializado)
    {
      if (!inicializado)
      {
        lblinfofalla.Content = "";
        lblinfofalla2.Content = "";
        txtblFinalizacionEnsayo.Text = "";
        txtblFinalizacionEnsayo2.Text = "";
        List<string> items = new List<string>();
        items.Add(PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK"));
        items.Add(PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK_2"));
        items.Add(PLC.ResolverItem("IDU_ST_EnsayoEnCurso"));
        items.Add(PLC.ResolverItem("IDU_ST_EnsayoEnCurso_2"));
        items.Add(PLC.ResolverItem("IDU_SP_ModoSeleccionado"));
        items.Add(PLC.ResolverItem("IDU_SP_ModoSeleccionado_2"));
        items.Add(PLC.ResolverItem("IDU_ST_NumeroDeFalla"));
        items.Add(PLC.ResolverItem("IDU_ST_NumeroDeFalla_2"));

        string[] valoresiniciales = accesoplc.LeerItems(items.ToArray());

        if ((!Convert.ToInt32(valoresiniciales[0]).Equals(0) 
          && !Convert.ToInt32(valoresiniciales[0]).Equals(-1))
            || (valoresiniciales[1]!=null && (!Convert.ToInt32(valoresiniciales[1]).Equals(0) 
            && !Convert.ToInt32(valoresiniciales[1]).Equals(-1))))
        {
          EnsayoAprobadoIDU = true;
        }

        if ((!Convert.ToInt32(valoresiniciales[2]).Equals(0) && !Convert.ToInt32(valoresiniciales[2]).Equals(-1))
            || (valoresiniciales[3]!=null &&
              (!Convert.ToInt32(valoresiniciales[3]).Equals(0) && !Convert.ToInt32(valoresiniciales[3]).Equals(-1))))
        {
          EnsayoEnCursoIDU = true;
        }

        if (int.Parse(valoresiniciales[4]) != -1)
          modoensayo = int.Parse(valoresiniciales[4]);
        else if (valoresiniciales[5]!=null && int.Parse(valoresiniciales[5]) != -1)
          modoensayo = int.Parse(valoresiniciales[5]);

        if (EnsayoEnCursoIDU)
          if (int.Parse(valoresiniciales[6]) != -1)
            chequearFalla(int.Parse(valoresiniciales[6]));
          else if (valoresiniciales[7]!=null && int.Parse(valoresiniciales[7]) != -1)
            chequearFalla(int.Parse(valoresiniciales[7]));

        System.Configuration.Configuration config2 =
        ConfigurationManager.OpenExeConfiguration(
        System.Reflection.Assembly.GetExecutingAssembly().Location);

        AppSettingsSection app = (AppSettingsSection)config2.GetSection("appSettings");
        app.Settings.Remove("ModoEnsayoIDU");
        app.Settings.Add("ModoEnsayoIDU", modoensayo.ToString());
        config2.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");

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
    }
    
    #endregion Constructor & Initializers
    
    #region Timers Events
    private void TiempoEnsayoPLC1_tick(object source, EventArgs e)
    {
      TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
      lblTiempoEnsayo.Content ="Tiempo de Ensayo : " + FormatearTiempo(TiempoTranscurrido.TotalSeconds);
    }

    private void TiempoEnsayoPLC2_tick(object source, EventArgs e)
    {
      TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
      lblTiempoEnsayo2.Content ="Tiempo de Ensayo : " + FormatearTiempo(TiempoTranscurrido.TotalSeconds);
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

        EnsayoFallaIDU                = false;
        EnsayoAprobadoIDU             = false;

        if ((valores[0].Quality != 192))
          fallaconexion = true;
        else
          fallaconexion = false;

        for (int i = 0; i < tags.Length; i++)
        {
            if (valores[i].Value == null)
              continue;
            if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK") && (modoensayo == 0 || modoensayo == 3))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                EnsayoAprobadoIDU = true;
              else
                EnsayoAprobadoIDU = false;
            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoOK_2") && (modoensayo == 1 || modoensayo == 2))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                EnsayoAprobadoIDU = true;
              else
                EnsayoAprobadoIDU = false;

            }
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
            else if (tags[i] == PLC.ResolverItem("IDU_M_ModoMantenimiento_2"))
                MODO_MANTENIMIENTO_PLC_2 = !Convert.ToInt32(valores[i].Value).Equals(0);
            else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroMaximoFichas_2"))
            {
              if (homeIDU.modoensayo > 1)
                accesoplc.Escribir("IDU_ST_NumeroMaximoFichas", valores[i].Value);
            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroMaximoFichas"))
            {
              if (homeIDU.modoensayo > 1)
                accesoplc.Escribir("IDU_ST_NumeroMaximoFichas_2", valores[i].Value);
            }
            else if (tags[i] == PLC.ResolverItem("IDU_SP_CantidadDeEnsayosParteB"))
            {
              txtA1.Text = valores[i].Value.ToString();
              //cambioCantidadEnsayosParteB = true;
              if (modoensayo > 1)
                if (accesoplc != null)
                  if (accesoplc.LeerItem("IDU_SP_CantidadDeEnsayosParteB_2") != valores[i].Value.ToString())
                    accesoplc.Escribir("IDU_SP_CantidadDeEnsayosParteB_2", valores[i].Value);

            }
            else if (tags[i] == PLC.ResolverItem("IDU_SP_ModoSeleccionado"))
              txtB1.Text = valores[i].Value.ToString();
            else if (tags[i] == PLC.ResolverItem("IDU_PLC"))
              txtC1.Text = valores[i].Value.ToString();
            else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroDeFalla"))
            {
              chequearFalla(Convert.ToInt32(valores[i].Value));
              int codigo = Convert.ToInt32(valores[i].Value);
              if (codigo == 0)
              {
                lblinfofalla.Content = "";
                continue;
              }
              EnsayosManager manensayo = new EnsayosManager();
              Ensayos e = new Ensayos();
              e.Codigo = codigo.ToString();
              lblinfofalla.Content = codigo.ToString() + ": " + manensayo.ObtenerDescripcionFalla(e);
            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroDeFalla_2"))
            {
              chequearFalla(Convert.ToInt32(valores[i].Value));
              int iCodigoFalla = Convert.ToInt32(valores[i].Value);
              if (iCodigoFalla == 0)
              {
                lblinfofalla2.Content = "";
                continue;
              }
              EnsayosManager manensayo = new EnsayosManager();
              Ensayos e = new Ensayos();
              e.Codigo = iCodigoFalla.ToString();
              lblinfofalla2.Content = iCodigoFalla.ToString() + " : " + manensayo.ObtenerDescripcionFalla(e);

            }
            else if (tags[i] == PLC.ResolverItem("IDU_PLC_2"))
              txtC2.Text = valores[i].Value.ToString();
            //else if (tags[i] == PLC.ResolverItem("IDU_ST_NumeroMaximoFichas_2"))
            else if (tags[i] == PLC.ResolverItem("IDU_SP_CantidadDeEnsayosParteB_2"))
            {
              txtA2.Text = valores[i].Value.ToString();
              //cambioCantidadEnsayosParteB_2 = true;
              if (modoensayo > 1)
                if (accesoplc != null)
                  if (accesoplc.LeerItem("IDU_SP_CantidadDeEnsayosParteB") != valores[i].Value.ToString())
                    accesoplc.Escribir("IDU_SP_CantidadDeEnsayosParteB", valores[i].Value);
            }
            else if (tags[i] == PLC.ResolverItem("IDU_SP_ModoSeleccionado_2"))
              txtB2.Text = valores[i].Value.ToString();
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoFalla") && modoensayo == 2)
            {
              // chequearFalla(Convert.ToInt32(valores[i].Value));
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                EnsayoAprobadoIDU_Parte1 = 1;
              }
              else
              {
                EnsayoAprobadoIDU_Parte1 = 0;
              }
            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EquipoEnsayadoFalla_2") && modoensayo == 3)
            {
              //chequearFalla(Convert.ToInt32(valores[i].Value));
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                EnsayoAprobadoIDU_Parte1 = 1;
              }
              else
              {
                EnsayoAprobadoIDU_Parte1 = 0;
              }
            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EnsayoEnCurso") && (modoensayo == 0 || modoensayo == 3))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                EnsayoEnCursoIDU = true;
                TiempoInicioEnsayo = DateTime.Now;
                intervalTimer.Start();
                lblinfofalla.Content = "";
                txtblFinalizacionEnsayo.Text = "";

              }
              else
              {
                EnsayoEnCursoIDU = false;
                intervalTimer.Stop();
                TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
              }

            }
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EnsayoEnCurso_2") && (modoensayo == 1 || modoensayo == 2))
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
              {
                EnsayoEnCursoIDU = true;
                TiempoInicioEnsayo = DateTime.Now;
                intervalTimer2.Start();
                lblinfofalla2.Content = "";
                txtblFinalizacionEnsayo2.Text = "";
              }
              else
              {
                EnsayoEnCursoIDU = false;
                intervalTimer2.Stop();
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
            else if (tags[i] == PLC.ResolverItem("IDU_ST_EnsayoEnCurso_2") && (modoensayo == 3))
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
            else if (tags[i] == "ModoCalorEstadoIDU")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotModoCalor1.Tag = "green";
              else
                dotModoCalor1.Tag = null;
            }
            else if (tags[i] == "IDU_MD_CorrienteMedida_2")
              txtCorriente2.Text = valores[i].Value.ToString();
            else if (tags[i] == "IDU_MD_VelocidadCalculada_2")
              txtVelocidad2.Text = valores[i].Value.ToString();
            else if (tags[i] == "IDU_ST_CopiaEstadoODU_2")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotDummy2.Tag = "green";
              else
                dotDummy2.Tag = null;
            }
            else if (tags[i] == "IDU_Q_ReleSeleccionBajaTension_2")
            {
              if (!Convert.ToInt32(valores[i].Value).Equals(0))
                dotBajaTension2_Copy.Tag = "green";
              else
                dotBajaTension2_Copy.Tag = null;
            }
            else if (tags[i] == "IDU_Q_EntradaEstadoElectroVentilador_2")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    dotElectro2.Tag = "green";
                else
                    dotElectro2.Tag = null;
            }
            else if (tags[i] == "IDU_SP_CopiaEstadoIDU_2")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    dotIDUEnergizado2.Tag = "green";
                else
                    dotIDUEnergizado2.Tag = null;
            }
            else if (tags[i] == "ModoCalorEstadoIDU_2")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    dotModoCalor2.Tag = "green";
                else
                    dotModoCalor2.Tag = null;
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioEnsayoPulsador"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Inicio de ensayo por pulsador";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioEnsayoPulsador_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = "Inicio de ensayo por pulsador";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoCalor"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Inicio en modo calor";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoCalor_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = "Inicio en modo calor";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoFrio"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Inicio en modo frío";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_InicioModoFrio_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = "Inicio en modo frío";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EsperaMontajePanelFrontal"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Espera montaje panel frontal";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EsperaMontajePanelFrontal_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = "Espera montaje panel frontal";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoAltaVelocidad"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = " Ensayo a alta velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoAltaVelocidad_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = " Ensayo a alta velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaTension"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = " Ensayo en baja tensión";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaTension_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = " Ensayo en baja tensión";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaVelocidad"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = " Ensayo a baja velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_EnsayoBajaVelocidad_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = " Ensayo a baja velocidad";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_CierreValvulaLiquido"))
            {
                //if (!Convert.ToInt32(valores[i].Value).Equals(0))
                //    lblPasosEnsayo.Content = "Cierre válvula de líquido";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_CierreValvulaLiquido_2"))
            {
                //if (!Convert.ToInt32(valores[i].Value).Equals(0))
                //    lblPasosEnsayo2.Content = "Cierre válvula de líquido";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_FinalizacionEnsayo"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo.Content = "Finalización de ensayo";
            }
            else if (tags[i] == PLC.ResolverItem("IDU_M_FinalizacionEnsayo_2"))
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    lblPasosEnsayo2.Content = "Finalización de ensayo";
            }
            //items.Add("IDU_SP_EtiquetaPendiente");
            else if (tags[i] == "IDU_SP_EtiquetaPendiente")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    if (accesoplc != null)
                        accesoplc.Escribir("IDU_SP_EtiquetaPendiente", 0);
            }
            if (tags[i] == "IDU_SP_EtiquetaPendiente_2")
            {
                if (!Convert.ToInt32(valores[i].Value).Equals(0))
                    if (accesoplc != null)
                        accesoplc.Escribir("IDU_SP_EtiquetaPendiente_2", 0);
            }
        }

        //if (modoensayo > 1)
        //{
        //    if (cambioCantidadEnsayosParteB)
        //    { 
        //        accesoplc.Escribir("")
        //    }
        //    else
        //        if (cambioCantidadEnsayosParteB_2) 
        //        {
        //        }
        //}
        PrimerLeidaTags = false;
        FinalizacionEnsayo();

      }
      catch (Exception e)
      {
          logger.ErrorFormat("void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , e.Message
          , e.StackTrace
          , e.InnerException != null ? e.InnerException.Message : "");
          
          excepcion formexcepcion = new excepcion(e);
          formexcepcion.ShowDialog();
      }
      ActualizarLabels();

    }
    #endregion Acquisition Events

    #region GUI Events
    /// <summary>
    /// Evento que handlea la seleccion del modelo a  testear.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="selectedModelo"></param>
    private void modeloafabricar_OnModeloSelectionChanged(object sender, Modelo selectedModelo)
    {
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
        if (homeIDU.modoensayo != 1 && homeIDU.modoensayo > -1)
          accesoplc.Escribir("IDU_SP_VModelo", 1);
        if (homeIDU.modoensayo != 0 && homeIDU.modoensayo > -1)
          accesoplc.Escribir("IDU_SP_VModelo_2", 1);
      }

      catch (Exception ex)
      {
        logger.ErrorFormat(" modeloafabricar_OnModeloSelectionChanged(object sender, Modelo selectedModelo):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
     , ex.Message
     , ex.StackTrace
     , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formexcepciones = new excepcion(ex);
        formexcepciones.ShowDialog();

      }
    }

    private void btnEnsayos_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        ensayos ens = new ensayos();
        ens.ShowDialog();

      }
      catch (Exception ex)
      {


        logger.ErrorFormat(" btnEnsayos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
         , ex.Message
        , ex.StackTrace
         , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnManten_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        mantenimiento mant = new mantenimiento();
        mant.ShowDialog();

      }
      catch (Exception ex)
      {


        logger.ErrorFormat(" btnManten_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      , ex.Message
      , ex.StackTrace
       , ex.InnerException != null ? ex.InnerException.Message : "");
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
        logger.ErrorFormat(" btnFormatos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnMantenProd_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        mantenimientoproducto mantprod = new mantenimientoproducto();
        mantprod.ShowDialog();

      }
      catch (Exception ex)
      {
       logger.ErrorFormat(" btnMantenProd_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
         , ex.Message
      , ex.StackTrace
       , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }

    }

    private void wndComunicacion_OnModoEnsayoIDU(int argModoEnsayoIDU) 
    {
      Dispatcher.Invoke(DispatcherPriority.Normal,
        new OnModoEnsayoIDU(wndComunicacion_OnModoEnsayoIDU_Invoked), argModoEnsayoIDU);
    }

    private void wndComunicacion_OnModoEnsayoIDU_Invoked(int argModoEnsayoIDU)
    {
      Inicializacion(true);

      modoensayo = argModoEnsayoIDU;

      if (modoensayo == 0)
        cleanPLC2();
      if (modoensayo == 1)
        cleanPLC1();

      if (accesoplc != null)
        if (modoensayo != 1)
          accesoplc.Escribir("IDU_MD_VelocidadCalculada", DateTime.Now.Millisecond + (DateTime.Now.Second * 1000));
        else
          accesoplc.Escribir("IDU_MD_VelocidadCalculada_2", DateTime.Now.Millisecond + (DateTime.Now.Second * 1000));
    }

    private void btnConexion_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        wndComunicacion owndComunicacion = new wndComunicacion();
        owndComunicacion.OnModoEnsayoIDU += new OnModoEnsayoIDU(wndComunicacion_OnModoEnsayoIDU);
        owndComunicacion.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.ErrorFormat("btnConexion_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
       , ex.Message
       , ex.StackTrace
       , ex.InnerException != null ? ex.InnerException.Message : "");

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
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();

        logger.ErrorFormat(" btnConfig_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
         , ex.Message
         , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
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
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        logger.ErrorFormat(" btnCambiarModelo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
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
        logger.ErrorFormat(" btnCambiarNroSerie_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
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
        logger.ErrorFormat(" btnTeclado_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      , ex.Message
      , ex.StackTrace
      , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnEtiquetas_Click(object sender, RoutedEventArgs e)
    {
      try
      {

        Consultaxaml formconsultaetiquetas = new Consultaxaml();
        formconsultaetiquetas.ShowDialog();

      }
      catch (Exception ex)
      {
        logger.ErrorFormat(" btnEtiquetas_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnHabilitar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        Teclado tec = new Teclado();
        tec.Texto = "Ingrese el password";
        tec.ShowDialog();

        string pass = tec.Password;

        ManagerUsuarios manusuarios = new ManagerUsuarios();
        USUARIO = manusuarios.ObtenerUsuario(pass);
        /*if pass = pass guardado 
         * habilito distintas cosas
         *
         */
      }
      catch (Exception ex)
      {
        logger.ErrorFormat(" btnHabilitar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnShutDown_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (confirmacioneliminar.Show("Apagar equipo", "¿Está seguro de que desea apagar el equipo?") == false)
        {
          if (confirmacioneliminar.Show("Apagar PCB SCADA", "¿Está seguro de que desea apagar la aplicación?") == true)
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

        logger.ErrorFormat(" btnShutDown_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
      try
      {


        //ManagerResetEnsayos manensayos = new ManagerResetEnsayos();

        //manensayos.ResetearEnsayos(DateTime.Now, USUARIO);
        Teclado2 tec2 = new Teclado2();
        tec2.ShowDialog();

        ManagerUsuarios usuariosman = new ManagerUsuarios();

        if (usuariosman.ExisteUsuario(tec2.txtUsuario.Text) == false)
        {
          confirmacioneliminar.Show("No existe el usuario");
          return;
        }


        WPFiDU.Utils.PiezasOkManager.resetPiezas(tec2.Usuario);
        this.txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();

      }
      catch (Exception ex)
      {
        logger.ErrorFormat(" btnReset_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
        , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
      }
    }
    #endregion GUI Events

    #region Acquisition Functions
    private void chequearFalla(int CodFalla)
    {
      if (CodFalla <= 0)
        return;
      if (!EnsayoEnCursoIDU | !EnsayoEnCursoIDU_Parte1)
        return;

      if (iUltimaCodigoFalla != 0)
      {
        iAnteUltimaCodigoFalla = iUltimaCodigoFalla;
        iUltimaCodigoFalla = CodFalla;
        LimiteFallas = 2;
        TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
        this.FinalizacionEnsayo();
      }
      else
      {
        iUltimaCodigoFalla = CodFalla;
        EnsayosManager manensayos = new EnsayosManager();
        if (manensayos.ObtenerPrioridadFalla(CodFalla) == true)
        {
          LimiteFallas = 2;
          TiempoTranscurrido = TimeSpan.FromTicks(DateTime.Now.Ticks - TiempoInicioEnsayo.Ticks);
          FinalizacionEnsayo();
        }
      }
    }

    private void ActualizarLabels()
    {
      Storyboard t = null;
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
      if (fallaconexion == true && (modoensayo != 0))
      {
        lblInfo2.Foreground = mForegroundBrushRed;
        lblInfo2.Content = "FALLA CONEXION CON PLC";
        //t = (Storyboard)FindResource("tmlIDU2Off");
        //t.AutoReverse = false;
        //t.Begin(this);
        rctIDU2.Stroke = mBrushOkOff;

      }
      if (fallaconexion == false && (modoensayo != 0))
      {
        lblInfo2.Foreground = mForegroundBrushGreen;
        lblInfo2.Content = "CONEXION CON PLC OK";
        //t = (Storyboard)FindResource("tmlIDU2On");
        //t.AutoReverse = false;
        //t.Begin(this);
        rctIDU2.Stroke = mBrushOkOn;
      }
      if (!fallaconexion)
      {
        if (MODO_MANTENIMIENTO_PLC_2)
        {
          //t = (Storyboard)FindResource("tmlIDU2ModoMant");
          //t.AutoReverse = false;
          //t.Begin(this);
          rctIDU2.Stroke = mBrushManualMode;
        }
        if (MODO_MANTENIMIENTO_PLC_1)
        {
          //t = (Storyboard)FindResource("tmlIDU1ModoMant");
          //t.AutoReverse = false;
          //t.Begin(this);
          rctIDU1.Stroke = mBrushManualMode;
        }
      }
    }

    private void FinalizacionEnsayo()
    {
      logger.DebugFormat("FinalizacionEnsayo():: modoensayo='{0}'", modoensayo.ToString());

      bool bEnsayoFinalizo = false;

      if (((!EnsayoEnCursoIDU) && (EnsayoEnCursoIDUOld))
          || (LimiteFallas == 2))
      {
        bEnsayoFinalizo = true;
        ResetFallasyTimers();

        if (EnsayoAprobadoIDU == true)
        {
          EnsayosIDU ensayoaprobado = accesoplc.LeerValoresEnsayo() as EnsayosIDU;
          ensayoaprobado.Aprobado = true;
          ensayoaprobado.Marca = txtMarca.Text;
          ensayoaprobado.Modelo = txtModelo.Text;
          ensayoaprobado.TiempoEnsayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);

          ensayoaprobado.Fecha = DateTime.Now;
          ensayoaprobado.Codigo = "0";
          ensayoaprobado.Usuario = USUARIO;
          EnsayosManager ensmanager = new EnsayosManager();

          logger.DebugFormat("FinalizacionEnsayo():: EnsayosIDU ensayoaprobado='{0}'", ensayoaprobado.ToString());
          ensmanager.GuardarValoresEnsayo(ensayoaprobado, null);

          WPFiDU.Utils.PiezasOkManager.addPiezaOk();
          txtEnsayosOK.Text = WPFiDU.Utils.PiezasOkManager.getPiezasOk().ToString();


          if (modoensayo == 0 || modoensayo == 3)
          {
            txtblFinalizacionEnsayo.Foreground = mForegroundBrushGreen;
            txtblFinalizacionEnsayo.Text = "Se termino el ensayo con exito";
          }
          else
          {
            txtblFinalizacionEnsayo2.Foreground = mForegroundBrushGreen;
            txtblFinalizacionEnsayo2.Text = "Se termino el ensayo con exito";
          }

          Ensayos infoens = ensayoaprobado;

          //TODO: DUDA por que esta aca??!?!
          if (modeloinfo == null)
          {
            confirmacioneliminar.Show("Usted no selecciono ningun modelo al iniciar el ensayo");
            ResetEstados();
            return;
          }
          ImpresionEtiquetas(infoens);
          accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
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
          ensayofalla.Usuario = USUARIO;

          EnsayosManager ensmanager = new EnsayosManager();

          ensmanager.GuardarValoresEnsayo(ensayofalla, null);
          logger.DebugFormat("FinalizacionEnsayo():: EnsayosIDU ensayofalla='{0}'", ensayofalla.ToString());


          if (modoensayo == 0 || modoensayo == 3)
          {
            txtblFinalizacionEnsayo.Foreground = mForegroundBrushRed;
            txtblFinalizacionEnsayo.Text = "Se termino el ensayo con fallas";
          }

          else
          {
            txtblFinalizacionEnsayo2.Foreground = mForegroundBrushRed;
            txtblFinalizacionEnsayo2.Text = "Se termino el ensayo con fallas";
          }

        }
        ResetEstados();
        NumeroDeSerieManager numserman = new NumeroDeSerieManager();
        numserman.GuardarNumeroDeSerie();
        txtUltimo.Text = numserman.ObtenerUltimoNumeroDeSerie();
      }


      if ((EnsayoAprobadoIDU_Parte1 == 1)
          && (modoensayo == 2 || modoensayo == 3)
          && (EnsayoEnCursoIDU_Parte1_OLD == true)
          && (EnsayoEnCursoIDU_Parte1 == false))
      {
        bEnsayoFinalizo = true;

        ResetEstados();
        ResetFallasyTimers();

        EnsayosIDU ensayofalla = accesoplc.LeerValoresEnsayo() as EnsayosIDU;
        ensayofalla.Aprobado = false;
        ensayofalla.Marca = txtMarca.Text;
        ensayofalla.Modelo = txtModelo.Text;
        ensayofalla.TiempoEnsayo = Convert.ToInt32(TiempoTranscurrido.TotalSeconds);
        ensayofalla.Fecha = DateTime.Now;

        EnsayosManager ensmanager = new EnsayosManager();
        ensmanager.GuardarValoresEnsayo(ensayofalla, null);

        NumeroDeSerieManager numserman = new NumeroDeSerieManager();
        numserman.GuardarNumeroDeSerie();
        txtUltimo.Text = numserman.ObtenerUltimoNumeroDeSerie();

        logger.DebugFormat("FinalizacionEnsayo():: EnsayosIDU ensayofalla='{0}'", ensayofalla.ToString());
        if (modoensayo == 2)
        {
          txtblFinalizacionEnsayo.Foreground = mForegroundBrushRed;
          txtblFinalizacionEnsayo.Text = "Se termino el ensayo con fallas";
        }
        else
        {
          txtblFinalizacionEnsayo2.Foreground = mForegroundBrushRed;
          txtblFinalizacionEnsayo2.Text = "Se termino el ensayo con fallas";
        }
      }

      //if (bEnsayoFinalizo)
      //  if (modoensayo == 0)
      //  {
      //    if (accesoplc != null)
      //    {
      //      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
      //      //accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0); 
      //    }
      //  }
      //  else
      //    if (modoensayo == 1)
      //    {
      //      if (accesoplc != null)
      //      {
      //        accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK_2", 0);
      //        //accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla_2", 0);
      //      }
      //    }
      //    else
      //    {
      //      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK", 0);
      //      //accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla", 0);
      //      accesoplc.Escribir("IDU_ST_EquipoEnsayadoOK_2", 0);
      //      //accesoplc.Escribir("IDU_ST_EquipoEnsayadoFalla_2", 0);
      //    }
    }

    private void ResetEstados()
    {
      EnsayoEnCursoIDU = false;
      EnsayoEnCursoIDUOld = false;
      EnsayoEnCursoIDU_Parte1 = false;
      EnsayoEnCursoIDU_Parte1_OLD = false;

      EnsayoFallaIDU = false;
      EnsayoFallaIDUOld = false;

      EnsayoAprobadoIDU = false;
      EnsayoAprobadoIDUOld = false;
    }

    private void ResetFallasyTimers()
    {
      this.iUltimaCodigoFalla = 0;
      this.iAnteUltimaCodigoFalla = 0;
      this.EnsayoFallaIDU = false;
      this.EnsayoFallaIDUOld = false;
      intervalTimer.Stop();
      intervalTimer2.Stop();
    }

    private void cleanPLC2()
    {
      txtA2.Text = "";
      txtB2.Text = "";
      txtC2.Text = "";
      txtCorriente2.Text = "0";
      txtVelocidad2.Text = "0";
      dotBajaTension2_Copy.Tag = null;
      dotDummy2.Tag = null;
      dotElectro2.Tag = null;
      dotIDUEnergizado2.Tag = null;
      dotModoCalor2.Tag = null;
      System.Windows.Media.SolidColorBrush pincel = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
      lblInfo2.Foreground = pincel;
      lblInfo2.Content = "PLC SIN ACTIVIDAD";
      Storyboard t = null;
      t = (Storyboard)FindResource("tmlIDU2Off");
      t.AutoReverse = false;
      t.Begin(this);
      txtblFinalizacionEnsayo2.Text = "";

    }

    private void cleanPLC1()
    {

      txtA1.Text = "";
      txtB1.Text = "";
      txtC1.Text = "";
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
    private void ImpresionEtiquetas(Ensayos infoens)
    {
      CaracteristicasTecnicasManager ctmanager = new CaracteristicasTecnicasManager();
      CaracteristicasTecnicas infocartecnica = ctmanager.ObtenerCaracteristicaTecnicaDeModelo(modeloinfo);

      ConfiguracionManager configurador = new ConfiguracionManager();

      //Impresion Producto
      if (configurador.ObtenerImpresoraProductoHabilitada())
      {


        EtiquetaManager etiqmanager = new EtiquetaManager();
        Etiqueta infoetiqueta = etiqmanager.ObtenerEtiquetaConComponentes(modeloinfo.Etiqueta);
        Bitmap ImagenTemp = etiqmanager.GenerarBitmapDeEtiqueta(infoetiqueta, modeloinfo, infocartecnica, infoens);

        Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        string nombreimpresora = configurador.ObtenerImpresoraProducto();

        //ImpresorEtiqueta imp = new ImpresorEtiqueta();


        //imp.ImprimirImagen(imagenaimprimir, nombreimpresora);
      }

      //Impresion Bulto
      if (configurador.ObtenerImpresoraBultoHabilitada())
      {


        EtiquetaManager etiqmanager = new EtiquetaManager();
        Etiqueta infoetiqueta = etiqmanager.ObtenerEtiquetaConComponentes(modeloinfo.EtiquetaCaja);
        Bitmap ImagenTemp = etiqmanager.GenerarBitmapDeEtiqueta(infoetiqueta, modeloinfo, infocartecnica, infoens);

        Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        int ALTO = int.Parse(ConfigurationManager.AppSettings["ALTURA_ETIQUETA_PRODUCTO_IDU"]);
        int ANCHO = int.Parse(ConfigurationManager.AppSettings["ANCHO_ETIQUETA_PRODUCTO_IDU"]);
        string nombreimpresora = configurador.ObtenerImpresoraBulto();

        //ImpresorEtiqueta imp = new ImpresorEtiqueta();

        //imp.ImprimirImagen(imagenaimprimir, nombreimpresora);
      }

    }
    #endregion Printing Functions
  }
}