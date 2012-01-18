using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU;
using iDU.BL;
using iDU.CommonObjects;
using iDU.PLC;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using log4net;
using System.Collections.Generic;

namespace dcf001
{
	public partial class monitoreoIDU
	{
        private PLCIDU accesoplc = new PLCIDU();

        private static readonly ILog logger = LogManager.GetLogger(typeof(monitoreoIDU));

     
        private bool estadoconexion = false;

        public static int NUMERO_PLC_CONECTADO_MODO_MANT = 0;

		public monitoreoIDU()
		{
			this.InitializeComponent();

           /* accesoplc = new PLCIDU();
            //LoadEstadosDeBotonesDesdePLC();
            intervalTimer.Interval = new TimeSpan(0, 0, 1);
            intervalTimer.Start();
            intervalTimer.Tick += new EventHandler(OnTimedEvent);
            accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
            accesoplc.LeerMonitoreo();*/

            switch (homeIDU.modoensayo)
            {
                case 0:
                    tgbHabilitarModo_2.IsEnabled = false;
                    tgbHabilitarModo.IsEnabled = true;                    
                    break;
                case 1:
                    tgbHabilitarModo_2.IsEnabled = true;
                    tgbHabilitarModo.IsEnabled = false;                    
                    break;
                case 2:
                case 3:
                    tgbHabilitarModo_2.IsEnabled = true;
                    tgbHabilitarModo.IsEnabled = true;                    
                    break;
            }

            logger.InfoFormat("El usuario '{0}' ingresó a modo mantenimiento.", WPFiDU.BL.ManagerUsuarios.sfUser.sgu__username);

        }

        void accesoplc_OnPLCEvent(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
        {
            Dispatcher.Invoke( DispatcherPriority.Normal, 
                new PLC.PLCEvent(accesoplc_OnPLCEventX), tags, valores );
        }

        void accesoplc_OnPLCEventX(string[] tags, IVRTKERNELLib.RtkTagValue[] valores)
        {
                try
                {
                    for (int i = 0; i < tags.Length; i++)
                    {

                        if ( tags[i] == PLC.ResolverItem("IDU_ST_CopiaEstadoManual") || tags[i] == PLC.ResolverItem("IDU_ST_CopiaEstadoManual_2"))
                        {
                            
                            if (!Convert.ToInt32(valores[i].Value).Equals(0))
                            {
                                NUMERO_PLC_CONECTADO_MODO_MANT = (tags[i] == PLC.ResolverItem("IDU_ST_CopiaEstadoManual")) ? 1 : 2;
                                HabilitarTodo();
                                
                            }
                            else
                            {
                                NUMERO_PLC_CONECTADO_MODO_MANT = 0;
                                DeshabilitarTodo();
                                
                                return;

                            }

                        }



                        if (valores[i].Value == null)
                            continue;

                        if (isTagOkForCurrentPLC(tags[i] , "IDU_MD_CorrienteMedida"))
                            txtCorriente.Text = valores[i].Value.ToString();
                        else if (isTagOkForCurrentPLC(tags[i], "IDU_MD_VelocidadCalculada"))
                            txtVelocidad.Text = valores[i].Value.ToString();
                        else if (isTagOkForCurrentPLC(tags[i], "IDU_Q_EntradaEstadoElectroVentilador"))                            
                            RealimentarEstados(valores[i].Value, dotElectroventilador);
                        else if (isTagOkForCurrentPLC(tags[i], "IDU_ST_CopiaEstadoODU"))
                            RealimentarEstados(valores[i].Value, dotCompresor);
                        else if (isTagOkForCurrentPLC(tags[i], "IDU_Q_EntradaEstadoValvula4Vias"))
                            RealimentarEstados(valores[i].Value, dotValvula4Vias);
                        else if (isTagOkForCurrentPLC(tags[i], "TCTCIDU"))
                            RealimentarToggleButton(valores[i].Value, tgbSerieTCTC);
                        else if (isTagOkForCurrentPLC(tags[i] , "ControlRemotoMonitoreoIDU") )
                            RealimentarToggleButton(valores[i].Value, tgbControlRemoto);
                        else if (isTagOkForCurrentPLC(tags[i], "IDU_M_ActuacionManualBajaTension"))
                            RealimentarToggleButton(valores[i].Value, tgbBajaTension);
                        else if (isTagOkForCurrentPLC(tags[i] , "IDU_M_ActuacionManualAlimentacionIDU"))
                            RealimentarToggleButton(valores[i].Value, tgbSplitOn);

                        //if (tags[i] == PLC.ResolverItem("IDU_MD_CorrienteMedida") 
                        //    || tags[i] == PLC.ResolverItem("IDU_MD_CorrienteMedida_2"))
                        //    txtCorriente.Text = valores[i].Value.ToString();
                        //else if (tags[i] ==PLC.ResolverItem("IDU_MD_VelocidadCalculada") 
                        //    || tags[i] == PLC.ResolverItem("IDU_MD_VelocidadCalculada_2"))
                        //    txtVelocidad.Text = valores[i].Value.ToString();
                        //else if (tags[i] ==PLC.ResolverItem("IDU_Q_EntradaEstadoElectroVentilador")
                        //    || tags[i] ==PLC.ResolverItem("IDU_Q_EntradaEstadoElectroVentilador_2"))
                        //    RealimentarEstados(valores[i].Value, dotElectroventilador);
                        //else if (tags[i] == PLC.ResolverItem("IDU_ST_CopiaEstadoODU") 
                        //    || tags[i] == PLC.ResolverItem("IDU_ST_CopiaEstadoODU_2"))
                        //    RealimentarEstados(valores[i].Value, dotCompresor);
                        //else if (tags[i] == PLC.ResolverItem("ModoCalorEstadoIDU") 
                        //    || tags[i] == PLC.ResolverItem("ModoCalorEstadoIDU_2"))
                        //    RealimentarEstados(valores[i].Value, dotValvula4Vias);
                        //else if (tags[i] == PLC.ResolverItem("TCTCIDU") 
                        //    || tags[i] == PLC.ResolverItem("TCTCIDU_2"))
                        //    RealimentarToggleButton(valores[i].Value, tgbSerieTCTC);
                        //else if (tags[i] == PLC.ResolverItem("ControlRemotoMonitoreoIDU") || tags[i] == PLC.ResolverItem("ControlRemotoMonitoreoIDU_2"))
                        //    RealimentarToggleButton(valores[i].Value, tgbControlRemoto);
                        //else if (tags[i] == PLC.ResolverItem("IDU_M_ActuacionManualBajaTension") || tags[i] == PLC.ResolverItem("IDU_M_ActuacionManualBajaTension_2"))
                        //     RealimentarToggleButton(valores[i].Value, tgbBajaTension);
                        //else if (tags[i] == PLC.ResolverItem("IDU_M_ActuacionManualAlimentacionIDU") || tags[i] == PLC.ResolverItem("IDU_M_ActuacionManualAlimentacionIDU_2"))
                        //    RealimentarToggleButton(valores[i].Value, tgbSplitOn);
                        else if (tags[i] ==PLC.ResolverItem("IDU_M_ModoMantenimiento"))
                        {
                            RealimentarToggleButton(valores[i].Value, tgbHabilitarModo);

                            if (!Convert.ToInt32(valores[i].Value).Equals(0))
                            {
                                NUMERO_PLC_CONECTADO_MODO_MANT = 1;
                                
                                if (homeIDU.modoensayo.Equals(2) || homeIDU.modoensayo.Equals(3))
                                    accesoplc.Escribir("IDU_M_ModoMantenimiento_2", 0); 
                            }
                        }
                        else if (tags[i] ==PLC.ResolverItem("IDU_M_ModoMantenimiento_2"))
                        {
                            RealimentarToggleButton(valores[i].Value, tgbHabilitarModo_2);
                            
                            if (!Convert.ToInt32(valores[i].Value).Equals(0) )
                            {
                                NUMERO_PLC_CONECTADO_MODO_MANT = 2;
                                
                                if(homeIDU.modoensayo.Equals(2) || homeIDU.modoensayo.Equals(3))
                                    accesoplc.Escribir("IDU_M_ModoMantenimiento", 0);
                            }
                        }

                        /*   else if (tags[i] ==PLC.ResolverItem("IDU_Q_ComandoRemoto1"))
                        {

                            RealimentarToggleButton(valores[i].Value, tgbStartStop1);
                        }

                        else if (tags[i] ==PLC.ResolverItem("IDU_Q_ComandoRemoto2"))
                        {

                            RealimentarToggleButton(valores[i].Value, tgbStartStop2);
                        }

                        else if (tags[i] ==PLC.ResolverItem("IDU_Q_ComandoRemoto3"))
                        {
                            RealimentarToggleButton(valores[i].Value, tgbStartStop3);

                        }

                        else if (tags[i] ==PLC.ResolverItem("IDU_Q_ComandoRemoto4"))
                        {

                            RealimentarToggleButton(valores[i].Value, tgbStartStop4);
                        }
                        */
                       
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

            }

        private bool isTagOkForCurrentPLC(string argTagName, string argDesiredTagName) 
        {
            if (argTagName.Trim().IndexOf(argDesiredTagName) < 0)
                return false;

            if(argTagName.Trim().EndsWith("_2") & NUMERO_PLC_CONECTADO_MODO_MANT!=2)
                return false;

            if (!argTagName.Trim().EndsWith("_2")  & NUMERO_PLC_CONECTADO_MODO_MANT == 2)
                return false;

            return true;
        }

        private void RealimentarEstados(object val, Button btn)
        {
            if (!Convert.ToInt32(val).Equals(0))
                btn.Tag = "green";
            else
                btn.Tag = null;
        }

        private void RealimentarToggleButton(object val, ToggleButton btn)
        {
            if (!Convert.ToInt32(val).Equals(0))
                btn.IsChecked = true;
            else
                btn.IsChecked = false;
        }



       

        private void DeshabilitarTodo()
        {
            btnHabilitarEnsayo.IsEnabled = false;
          //  tgbHabilitarModo.IsEnabled = false;
            btnPruebaLamparas.IsEnabled = false;
            tgbStartStop1.IsEnabled = false;
            tgbStartStop2.IsEnabled = false;
            tgbStartStop3.IsEnabled = false;
            tgbStartStop4.IsEnabled = false;
            tgbSerieTCTC.IsEnabled = false;
            tgbControlRemoto.IsEnabled = false;
            tgbBajaTension.IsEnabled = false;
            tgbSplitOn.IsEnabled = false;
           // tgbHabilitarModo.IsEnabled = false;

        }

        private void HabilitarTodo()
        {
            btnHabilitarEnsayo.IsEnabled = true;
            
            btnPruebaLamparas.IsEnabled = true;
            tgbStartStop1.IsEnabled = true;
            tgbStartStop2.IsEnabled = true;
            tgbStartStop3.IsEnabled = true;
            tgbStartStop4.IsEnabled = true;
            tgbSerieTCTC.IsEnabled = true;
            tgbControlRemoto.IsEnabled = true;
            tgbBajaTension.IsEnabled = true;
            tgbSplitOn.IsEnabled = true;
            
            //tgbHabilitarModo_2.IsEnabled = true;
            //tgbHabilitarModo.IsEnabled = true;
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            

            this.Close();
        }

        private void tgbStartStop1_Click(object sender, RoutedEventArgs e)
        {
            
           // ToggleCMD(tgbStartStop1, "IDU_Q_ComandoRemoto1");
            try
            {

                accesoplc.EscribirItemMonitoreo("IDU_Q_ComandoRemoto1", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("tgbStartStop1_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
           

        }

        private void tgbStartStop2_Click(object sender, RoutedEventArgs e)
        {
           // ToggleCMD(tgbStartStop2,"IDU_Q_ComandoRemoto2");
            try
            {

                accesoplc.EscribirItemMonitoreo("IDU_Q_ComandoRemoto2", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("tgbStartStop2_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }

        private void tgbStartStop3_Click(object sender, RoutedEventArgs e)
        {
            //ToggleCMD(tgbStartStop3,"IDU_Q_ComandoRemoto3"); 
            try
            {

                accesoplc.EscribirItemMonitoreo("IDU_Q_ComandoRemoto3", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("tgbStartStop3_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }

        private void tgbStartStop4_Click(object sender, RoutedEventArgs e)
        {
           // ToggleCMD(tgbStartStop4,"IDU_Q_ComandoRemoto4");
            try
            {

                accesoplc.EscribirItemMonitoreo("IDU_Q_ComandoRemoto4", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("tgbStartStop4_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }

        private void tgbSerieTCTC_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbSerieTCTC,"TCTCIDU"); 
            
        }

        private void tgbControlRemoto_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbControlRemoto,"ControlRemotoMonitoreoIDU");
        }


        private void tgbHabilitarModo_Click(object sender, RoutedEventArgs e)
        {

            ToggleCMD(tgbHabilitarModo, "IDU_M_ModoMantenimiento");
        }

        private void tgbHabilitarModo_2_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbHabilitarModo_2, "IDU_M_ModoMantenimiento_2");
        }

        private void tgbSplitOn_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbSplitOn, "IDU_M_ActuacionManualAlimentacionIDU");

        }

        private void btnHabilitarEnsayo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                accesoplc.EscribirItemMonitoreo("EnsayoEnSegundaParteMonitoreoIDU", 1);
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnHabilitarEnsayo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
            }
        }

        private void btnPruebaLamparas_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                accesoplc.EscribirItemMonitoreo("IDU_M_ActuacionManualPruebaLamparas", 1);

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

        
        //private void btnHabilitarModo_Click(object sender, RoutedEventArgs e)
        //{
        //    string sModoMantenimiento = "IDU_M_ModoMantenimiento";
        //    if (homeIDU.modoensayo.Equals(1) || homeIDU.modoensayo.Equals(3))
        //    {
        //        sModoMantenimiento = "IDU_M_ModoMantenimiento_2";
        //    }
        //    try
        //    {
        //        accesoplc.EscribirItemMonitoreo(sModoMantenimiento, 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.ErrorFormat("btnHabilitarModo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        //       , ex.Message
        //       , ex.StackTrace
        //       , ex.InnerException != null ? ex.InnerException.Message : "");
        //        excepcion formexcepcion = new excepcion(ex);
        //    }
        //}

    
        private void tgbBajaTension_Click(object sender, RoutedEventArgs e)
        {
            ToggleCMD(tgbBajaTension,"IDU_M_ActuacionManualBajaTension");
        }

        private void ToggleCMD(ToggleButton btn, string tagName)
        {
            string mTagName = tagName;

            if (NUMERO_PLC_CONECTADO_MODO_MANT == 2 & !tagName.Trim().EndsWith("_2") & !tagName.Trim().Equals("IDU_M_ModoMantenimiento"))
            {
                mTagName = string.Format("{0}_2", tagName.Trim()); 
            }

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
                accesoplc.EscribirItemMonitoreo(mTagName, iValue);
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


            /*List<string> items = new List<string>();
            items.Add(PLC.ResolverItem("IDU_ST_CopiaEstadoManual"));

            string[] valoresiniciales = accesoplc.LeerItems(items.ToArray());

            if (!Convert.ToInt32(valoresiniciales[0]).Equals(0))
            {
                HabilitarTodo();
            }
            else
            {
                DeshabilitarTodo();

            }
            */

            switch (homeIDU.modoensayo)
            {
                case 0:
                    leerDePLC(1);
                    break;
                case 1:
                    leerDePLC(2);
                    break;
                case 2:
                case 3:
                    leerDePLC(3);
                    break;
            }
        }

        private void leerDePLC(int iPLC) 
        {
            if (accesoplc!=null)
                accesoplc.OnPLCEvent -= new PLC.PLCEvent(accesoplc_OnPLCEvent);
            else
                accesoplc = new PLCIDU();
            accesoplc.OnPLCEvent += new PLC.PLCEvent(accesoplc_OnPLCEvent);
            accesoplc.LeerMonitoreoPorPLC(iPLC);
        }
        

        

    


       

    
      

      
	}
}