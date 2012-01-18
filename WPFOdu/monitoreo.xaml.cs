using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU.PLC;
using System.Windows.Threading;
using log4net;
using System.Collections.Generic;
using System.Configuration;
using WPFiDU.BL;
namespace dcf001
{
	public partial class monitoreo
	{

    private PLCODU accesoplc = new PLCODU();
    private static readonly ILog logger = LogManager.GetLogger(typeof(monitoreo));
    private bool mediciones = false;

    private DispatcherTimer intervalTimer = new DispatcherTimer();
    private DispatcherTimer medicionestimer = new DispatcherTimer();

    private bool estadoconexion = false;

    private SolidColorBrush mForegroundBrushWhite = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF));
    private SolidColorBrush mForegroundBrushRed = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0x00, 0x00));
    private SolidColorBrush mForegroundBrushGreen = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x00, 0xFF, 0x00));

		public monitoreo()
		{
			this.InitializeComponent();
		}
    void accesoplc_OnPLCEvent(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
    {
        Dispatcher.Invoke(DispatcherPriority.Normal,
            new PLC.PLCEvent(accesoplc_OnPLCEventX), tags, valores);
    }

        void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
        {
            try
            {
                for (int i = 0; i < tags.Length; i++)
                {

                    if (tags[i] == PLC.ResolverItem("ODU_ST_CopiaBitMantenimiento"))
                    {
                        if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        {
                            HabilitarTodo();
                         
                        }
                        else
                        {

                            DeshabilitarTodo();
                            return;

                        }

                    }
              

                    
                    
                    if (valores[i].Value == null)
                        continue;
                    
                    
                    //Actualizacion variables
                    if ( tags[i] == PLC.ResolverItem("ODU_MD_Potencia"))
                        txtPotencia.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TensionEstado"))
                        txtTension.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Humedad"))
                        txtHumedad.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Presion"))
                        txtPresionSuccion.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TempSalida"))
                        txtTempSalida.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_TempEntrada"))
                    {
                      txtTempEntrada.Text = valores[i].Value.ToString();
                      CheckEnvironmentTemperature();
                    }
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Corriente"))
                        txtCorriente.Text = valores[i].Value.ToString();
                    else if (tags[i] == PLC.ResolverItem("ODU_MD_Velocidad"))
                        txtVelVentilador.Text = valores[i].Value.ToString();

                    //Realimentacion de los Estados                    
                    //      else if (tags[i] == PLC.ResolverItem("ODU_I_TermistorOK"))
                    //        RealimentarEstados(valores[i].Value, dotTermistorOk);
                    //  else if (tags[i] == PLC.ResolverItem("ODU_M_ModoCalor"))
                    //    RealimentarEstados(valores[i].Value, dotModoCalor);

                    //Realimentacion de los togglebuttons
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_BajaTension"))
                    {
                        /*  RealimentarToggleButton(valores[i].Value, tgbBaja);
                          if (!Convert.ToInt32(valores[i].Value).Equals(0))
                          {
                              tgbAireOn.IsEnabled = false;
                          }
                          else
                          {

                              tgbAireOn.IsEnabled = true;
                          }*/
                    }

                    else if (tags[i] == PLC.ResolverItem("ODU_Q_ControlRemotoCalor"))
                        RealimentarToggleButton(valores[i].Value, tgb1);
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_ControlRemotoFrioHigh"))
                        RealimentarToggleButton(valores[i].Value, tgb2);
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_ControlRemotoFrioLow"))
                        RealimentarToggleButton(valores[i].Value, tgb3);
                    else if (tags[i] == PLC.ResolverItem("ODU_Q_ControlRemotoStop"))
                        RealimentarToggleButton(valores[i].Value, tgb4);

                    else if (tags[i] == PLC.ResolverItem("ODU_M_ModoManual"))
                        RealimentarToggleButton(valores[i].Value, tgbHabilitarModo);
                    else if (tags[i] == PLC.ResolverItem("ODU_M_ActuacionManualModoCalor"))
                        RealimentarToggleButton(valores[i].Value, tgbModoCalor);
                    else if (tags[i] == PLC.ResolverItem("ODU_M_ActuacionManualAlimenacionODU"))
                    {
                        RealimentarToggleButton(valores[i].Value, tgbAireOn);

                        if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        {
                            tgbBaja.IsEnabled = false;
                        }
                        else
                        {
                            tgbBaja.IsEnabled = true;
                        }
                    }


                    else if (tags[i] == PLC.ResolverItem("ODU_M_ActuacionManualAlimenacionIDU"))
                        RealimentarToggleButton(valores[i].Value, tgbSplitOn);
                    else if (tags[i] == PLC.ResolverItem("ODU_M_ReleAlimentacionPlacaTCTC"))
                        RealimentarToggleButton(valores[i].Value, tgbPlacaTCTC);

                    else if (tags[i] == PLC.ResolverItem("ODU_M_MIDEA"))
                        RealimentarToggleButton(valores[i].Value, tgbMidea);

                    else if (tags[i] == PLC.ResolverItem("ODU_M_ActuacionManualBajaTension"))
                    {
                        RealimentarToggleButton(valores[i].Value, tgbBaja);
                        if (!Convert.ToInt32(valores[i].Value).Equals(0))
                        {
                            tgbAireOn.IsEnabled = false;
                        }
                        else
                        {
                            tgbAireOn.IsEnabled = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.ErrorFormat("accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , e.Message
              , e.StackTrace
              , e.InnerException != null ? e.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(e);
                formexcepcion.ShowDialog();
            }

            try {
                int tempsalida = int.Parse(txtTempSalida.Text);
                int tempentrada = int.Parse(txtTempEntrada.Text);
                int diftemp = Math.Abs(tempsalida - tempentrada);
                txtTempDif.Text = diftemp.ToString();
            }
            catch (Exception e)
            {
                logger.ErrorFormat("accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , e.Message
                , e.StackTrace
                , e.InnerException != null ? e.InnerException.Message : "");
                
                excepcion formexcepcion = new excepcion(e);
                formexcepcion.ShowDialog();
            } 

        }

        private void RealimentarEstados(object val, Button btn)
        {
            if (!Convert.ToInt32(val).Equals(0))
                btn.Tag = "green";
            else
                btn.Tag = null;
        }

        private void CheckEnvironmentTemperature()
        {
          string sMessageText = string.Empty;
          bool isOutOfRange = EnvironmentTempManager.IsEnvironmentTempOutOfRange(false, out sMessageText);
          if (isOutOfRange)
          {
            txtTempEntrada.FontWeight = FontWeights.Bold;
            txtTempEntrada.Foreground = mForegroundBrushRed;
          }
          else
          {
            txtTempEntrada.FontWeight = FontWeights.Normal;
            txtTempEntrada.Foreground = mForegroundBrushWhite;
          }

        }


        private void RealimentarToggleButton(object val, ToggleButton btn)
        {
            if (!Convert.ToInt32(val).Equals(0))
                btn.IsChecked = true;
            else
                btn.IsChecked = false;
        }

        private bool VerificarConexion()
        {
            intervalTimer.Stop();
            bool conectado = false;
            try
            {
                conectado = accesoplc.ProbarConexion();

                if (conectado ==true)
                {
                   /* tgbSplitOn.IsChecked = true;
                    tgbSplitOn.IsEnabled = true;
                    tgbAireOn.IsEnabled = true;
                    tgbAireOn.IsChecked = true;*/
                  //  txtEsperando.Text = "Conectado";
                    return true;

                }
                else
                {
                   /* tgbSplitOn.IsChecked = false;
                    tgbSplitOn.IsEnabled = false;
                    tgbAireOn.IsChecked = false;
                    tgbAireOn.IsEnabled = false;*/
                  //  txtEsperando.Text = "Esperando Respuesta...";
                    return false;
                }
            }
            catch
            {



            }

            intervalTimer.Start();
            return conectado;
        }

        private void DeshabilitarTodo()
        {

           // tgbHabilitarModo.IsEnabled = false;
            btnPruebaLamparas.IsEnabled = false;
            btnRegistrarMediciones.IsEnabled = false;
            tgbBaja.IsEnabled = false;
            tgbModoCalor.IsEnabled = false;
            tgbPlacaTCTC.IsEnabled = false;
            tgbMidea.IsEnabled = false;
            tgbAireOn.IsEnabled = false;
            tgbSplitOn.IsEnabled = false;
            tgb1.IsEnabled = false;
            tgb2.IsEnabled = false;
            tgb3.IsEnabled = false;
            tgb4.IsEnabled = false;
            
        }

        private void HabilitarTodo()
        {
            tgbHabilitarModo.IsEnabled = true;
            btnPruebaLamparas.IsEnabled = true;
            btnRegistrarMediciones.IsEnabled = true;
            tgbBaja.IsEnabled = true;
            tgbModoCalor.IsEnabled = true;
           
            tgbPlacaTCTC.IsEnabled = true;
            tgbMidea.IsEnabled = true;
        
            tgb1.IsEnabled = true;
            tgb2.IsEnabled = true;
            tgb3.IsEnabled = true;
            tgb4.IsEnabled = true;
            tgbSplitOn.IsEnabled = true;
            tgbAireOn.IsEnabled = true;

        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            return;
            if (VerificarConexion() == false)
            {
                if (estadoconexion == true)
                {
                    DeshabilitarTodo();
                    estadoconexion = false;
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (estadoconexion == false)
                {
                    HabilitarTodo();
                    estadoconexion = true;

                }
            }      

        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnPruebaLamparas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                accesoplc.EscribirItemMonitoreo("ODU_M_PruebaLamparas", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnPruebaLamparas_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }
      
        private void tgbBaja_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbBaja, "ODU_M_ActuacionManualBajaTension");
        }

        private void tgb4_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgb4, "ODU_Q_ControlRemotoStop");
        }

        private void tgb3_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgb3, "ODU_Q_ControlRemotoFrioLow");
        }

        private void tgb2_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgb2, "ODU_Q_ControlRemotoFrioHigh");
        }

        private void tgb1_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgb1, "ODU_Q_ControlRemotoCalor");
        }

        private void tgbPlacaTCTC_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbPlacaTCTC, "ODU_M_ReleAlimentacionPlacaTCTC");
        }
 
        private void tgbSplitOn_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbSplitOn, "ODU_M_ActuacionManualAlimenacionIDU");
        }

        private void tgbAireOn_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbAireOn, "ODU_M_ActuacionManualAlimenacionODU");
        }

        private void tgbModoCalor_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbModoCalor, "ODU_M_ActuacionManualModoCalor");
        }

        private void tgbHabilitarModo_Click(object sender, RoutedEventArgs e)
        {
            this.rctPopUpBack.InvalidateVisual();
            ToggleCMD(tgbHabilitarModo, "ODU_M_ModoManual");
        }

        private void ToggleCMD(ToggleButton btn, string tagName)
        {
            int iValue = -1;
            if (btn.IsChecked != true)
            {
                iValue = 0;
            }
            else
            {
                iValue = 1;
            }
            // tgbBaja.IsChecked ? 0 : 1; 
            try
            {
                accesoplc.EscribirItemMonitoreo(tagName, iValue);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("ToggleCMD(ToggleButton btn, string tagName):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            List<string> items = new List<string>();
            items.Add(PLC.ResolverItem("ODU_ST_CopiaBitMantenimiento"));



            string[] valoresiniciales = accesoplc.LeerItems(items.ToArray());

            if (!Convert.ToInt32(valoresiniciales[0]).Equals(0))
            {
                HabilitarTodo();
            }
            else
            {
                DeshabilitarTodo();

            }
            
            //LoadEstadosDeBotonesDesdePLC();
            medicionestimer.Interval = new TimeSpan(0, 0, 10);
            medicionestimer.Tick += new EventHandler(medicionestimer_tick);

            intervalTimer.Interval = new TimeSpan(0, 0, 1);

            intervalTimer.Tick += new EventHandler(OnTimedEvent);
            intervalTimer.Start();

            accesoplc = new PLCODU();
            accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
            accesoplc.LeerMonitoreo();


        }

        private void tgbMidea_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbPlacaTCTC, "ODU_M_MIDEA");
        }

        private void btnRegistrarMediciones_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
                
                
                  mediciones = true;
                  medicionestimer.Start();
              
            }

            catch (Exception ex)
            {

                logger.ErrorFormat("btnRegistrarMediciones_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }
        private void medicionestimer_tick(object source, EventArgs e)
        {
            try
            {
                if(mediciones==false)
                return;

                
                string fic = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["ARCHIVO_MEDICIONES"];
              //  FileStream salida = new FileStream(fic, FileMode.OpenOrCreate, FileAccess.Write);



                StreamWriter sw = new System.IO.StreamWriter(fic, true, System.Text.Encoding.ASCII);
                sw.WriteLine("");
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("Corriente :" + txtCorriente.Text);
                sw.WriteLine("Humedad : " + txtHumedad.Text);
                sw.WriteLine("Potencia : " + txtPotencia.Text);
                sw.WriteLine("Presion : " + txtPresionSuccion.Text);
                sw.WriteLine("Diferencia de Temperatura : " + txtTempDif.Text);
                sw.WriteLine("Temperatura Entrada : " + txtTempEntrada.Text);
                sw.WriteLine("Temperatura Salida : " + txtTempSalida.Text);
                sw.WriteLine("Tension : " + txtTension.Text);
                sw.WriteLine("Velocidad : " + txtVelVentilador.Text);
                
                
                sw.Close();

               
            }

            catch (Exception ex)
            {

                logger.ErrorFormat("btnArchivoGuardar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
            

        }

         

         

       

	}
}