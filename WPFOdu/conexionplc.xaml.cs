using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using iDU.PLC;
using log4net;


namespace dcf001
{
	public partial class conexionplc
	{
        private bool mStarted = false;
        private bool mDisconnect =false;

        public static bool UserMadeChanges = false;

        private static readonly ILog logger = LogManager.GetLogger(typeof(conexionplc));


        public bool IsDisconnect
        {

            get { return mDisconnect;}
        }
        public bool IsStarted
        {
            get { return mStarted; }
        }

        private bool boolEsIDU = false;
		public conexionplc(bool esidu)
		{
			this.InitializeComponent();
            lblCambiando.Visibility = Visibility.Hidden;

            boolEsIDU = esidu;
            if (esidu == true)
            {
                cmbConexion.Items.Add("IDU N1 SOLO");
                cmbConexion.Items.Add("IDU N2 SOLO");
                cmbConexion.Items.Add("IDU N1 Y N2");
                cmbConexion.Items.Add("IDU N2 Y N1");

               cmbConexion.SelectedIndex = int.Parse(ConfigurationManager.AppSettings["ModoEnsayoIDU"]);
               
              
            }
            else
            {
                string versiondcf = "DCF" + ConfigurationManager.AppSettings["version_dcf"];
                cmbConexion.Items.Add(versiondcf);

            }

            UserMadeChanges = false;
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideLoadingUIComponent() 
        {
            lblCambiando.Visibility = Visibility.Hidden;
            this.InvalidateVisual();
            this.InvalidateArrange();
            this.UpdateLayout();
        }
        
        private void ShowLoadingUIComponent() {
            lblCambiando.Visibility = Visibility.Visible;
            this.InvalidateVisual();
            this.InvalidateArrange();
            this.UpdateLayout();

        }
        
        private void EjecutarBatConexion()
        {

            /*
                cmbConexion.Items.Add("IDU N1 SOLO");
                cmbConexion.Items.Add("IDU N2 SOLO");
                cmbConexion.Items.Add("IDU N1 Y N2");
                cmbConexion.Items.Add("IDU N2 Y N1");
             */
            bool salidelproceso = false;
            string  directorio = "";
            if (boolEsIDU)
            { 
                if (iComboSelectedIndex >= 0) 
                { 
                    string changeDBMainBatPath = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_BATS"] ;

                    switch (iComboSelectedIndex) 
                    {
                        case 0:
                            changeDBMainBatPath += "plc1.bat";
                            break;
                        case 1:
                            changeDBMainBatPath += "plc2.bat";
                            break;
                        case 2:
                        case 3:
                            changeDBMainBatPath += "plc12.bat";
                            break;
                    }

                    // change dbmain
                    ProcessStartInfo batCambioDBMain = new ProcessStartInfo(changeDBMainBatPath);
                    batCambioDBMain.WindowStyle = ProcessWindowStyle.Hidden;
                    Process batCambioDBMainProcess = new Process();
                    batCambioDBMainProcess.StartInfo = batCambioDBMain;
                    batCambioDBMainProcess.Start();
                    


                    do
                    {
                        //btnDesconectar.IsEnabled = false;
                        //btnClose.IsEnabled = false;
                        salidelproceso = batCambioDBMainProcess.HasExited;
                        Thread.Sleep(1000);
                    } while (salidelproceso == false);

                }
            }
                // Restart Ivision
                directorio = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_BATS"] + "IVStart.bat";
                ProcessStartInfo infoproceso = new ProcessStartInfo(directorio);
                infoproceso.WindowStyle = ProcessWindowStyle.Hidden;
                Process nuevoproceso = new Process();
                nuevoproceso.StartInfo = infoproceso;
                nuevoproceso.Start();
                salidelproceso = false;
                do
                {
                    //btnDesconectar.IsEnabled = false;
                    //btnClose.IsEnabled = false;
                    salidelproceso = nuevoproceso.HasExited;
                    Thread.Sleep(1000);
                } while (salidelproceso == false);
       
            

            //try
            //{

                 

                 
                
            //    PLCIDU plc = new PLCIDU();
            //    if (cmbConexion.SelectedIndex != -1)
            //    {
            //        plc.Escribir("IDU_SP_VModelo", 1);
            //        plc.Escribir("IDU_SP_VModelo_2", 1);

            //        if (cmbConexion.SelectedIndex == 0 || cmbConexion.SelectedIndex == 1)
            //        {
            //            plc.Escribir("IDU_SP_ModoSeleccionado", 0);
            //            plc.Escribir("IDU_SP_ModoSeleccionado_2", 0);
                       
            //        }

            //        if (cmbConexion.SelectedIndex == 2)
            //        {
            //            plc.Escribir("IDU_SP_ModoSeleccionado", 1);
            //            plc.Escribir("IDU_SP_ModoSeleccionado_2", 2);

            //        }

            //        if(cmbConexion.SelectedIndex == 3 )
            //        {
            //            plc.Escribir("IDU_SP_ModoSeleccionado", 2);
            //            plc.Escribir("IDU_SP_ModoSeleccionado_2", 1);
            //        }

            //        System.Configuration.Configuration config2 =
            //        ConfigurationManager.OpenExeConfiguration(
            //        ConfigurationUserLevel.None);

            //        AppSettingsSection app = (AppSettingsSection)config2.GetSection("appSettings");
            //        app.Settings.Remove("ModoEnsayoIDU");
            //        app.Settings.Add("ModoEnsayoIDU",cmbConexion.SelectedIndex.ToString());          

            //        // Save the configuration file.
            //        config2.Save(ConfigurationSaveMode.Modified);

            //        // Force a reload of the changed section.
            //        ConfigurationManager.RefreshSection("appSettings");
            //    }
                
            //    mStarted = true;

            //}
            //catch (Exception ex)
            //{
            //    logger.ErrorFormat("btnConectar_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
            // , ex.Message
            // , ex.StackTrace
            // , ex.InnerException != null ? ex.InnerException.Message : "");
            //    excepcion formexcepcion = new excepcion(ex);
            //    formexcepcion.ShowDialog();
            //}
            //finally
            //{
            //    btnConectar.Cursor = System.Windows.Input.Cursors.Arrow;
            //    btnDesconectar.IsEnabled = true;
            //    btnClose.IsEnabled = true;
                
                
            //}

            //HideLoadingUIComponent();
      

        }

        private void EjecutarBatDesconexion()
        {
            bool salidadelproceso = false;
            string directorio = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_BATS"] + "IVStop.bat";

            ProcessStartInfo infoproceso = new ProcessStartInfo(directorio);
            infoproceso.WindowStyle = ProcessWindowStyle.Hidden;

            Process nuevoproceso = new Process();
            nuevoproceso.StartInfo = infoproceso;
            nuevoproceso.Start();


            do
            {
                salidadelproceso = nuevoproceso.HasExited;
                Thread.Sleep(1000);
            } while (salidadelproceso == false);
            nuevoproceso.Close();

        }

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            conectarDCF(cmbConexion.SelectedIndex, boolEsIDU);
            UserMadeChanges = true;
        }

        private static int iComboSelectedIndex = -1;


        public void conectarDCF(int argISelectedModoIndex, bool argEsIdu) 
        {
            if (argISelectedModoIndex == -1)
                return;

            lblCambiando.Content = "...Conectando"; 
            ShowLoadingUIComponent();
            iComboSelectedIndex = -1;
            iComboSelectedIndex = argISelectedModoIndex;
            
            try
            {
                DeshabilitarControles(true);
                System.Windows.Forms.Application.DoEvents();

                Thread oThread = new Thread(new ThreadStart(this.EjecutarBatDesconexion ));
                oThread.Start();

                while (oThread.IsAlive)
                    System.Windows.Forms.Application.DoEvents();

                oThread = null;

                oThread = new Thread(new ThreadStart(this.EjecutarBatConexion));
                oThread.Start();

                while (oThread.IsAlive)  
                    System.Windows.Forms.Application.DoEvents();

                oThread = null;


                mStarted = true;

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnConectar_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
             , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");
                //excepcion formexcepcion = new excepcion(ex);
                //formexcepcion.ShowDialog();
            }
            finally
            {
               
                HabilitarControles(true);
                
               // btnConectar.Cursor = System.Windows.Input.Cursors.Arrow;
                
                
            }

           
            HideLoadingUIComponent();
            WPFiDU.Utils.LastDCFConnectionManager.setLastDCFConnectionComboIndex(this.cmbConexion.SelectedIndex);
            this.Hide();
        }

        private void DeshabilitarControles(bool conectar)
        {

            if (conectar == true)
                btnConectar.Cursor = System.Windows.Input.Cursors.Wait;
            else
                btnDesconectar.Cursor = System.Windows.Input.Cursors.Wait;

            btnConectar.IsEnabled = false;
            btnDesconectar.IsEnabled = false;
            btnClose.IsEnabled = false;
            cmbConexion.IsEnabled = false;


            this.btnDesconectar.InvalidateVisual();
            this.btnClose.InvalidateVisual();

        }


        //private void DetenerServicios()
        //{

        //    //Thread nuevothread = new Thread(DetenerServicios);
        //    //nuevothread.Start();
         
        //}


        private void btnDesconectar_Click(object sender, RoutedEventArgs e)
        {
            ShowLoadingUIComponent();
            lblCambiando.Content = "Desconectando...";
            try
            {

                DeshabilitarControles(false);

                
              //btnDesconectar.Cursor = System.Windows.Input.Cursors.Wait;

                Thread oThread = new Thread(new ThreadStart(this.EjecutarBatDesconexion));
                oThread.Start();

                while (oThread.IsAlive)
                    System.Windows.Forms.Application.DoEvents();

                oThread = null;

                mStarted = false;
                mDisconnect = true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnDesconectar_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
             , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();
            }
            finally
            {
                HabilitarControles(false);
                //btnDesconectar.Cursor = System.Windows.Input.Cursors.Arrow;
                
            }
            HideLoadingUIComponent();
            UserMadeChanges = true;    
        }

        private void HabilitarControles(bool conectar)
        {
            if (conectar == true)
                btnConectar.Cursor = System.Windows.Input.Cursors.Arrow;
            else
                btnDesconectar.Cursor = System.Windows.Input.Cursors.Arrow;
            
            btnConectar.IsEnabled = true;
            btnClose.IsEnabled = true;
            btnDesconectar.IsEnabled = true;
            cmbConexion.IsEnabled = true;
        }
	}
}
