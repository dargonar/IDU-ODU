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
using iDU.CommonObjects;
using log4net;

namespace dcf001
{
	public partial class detallesensayoodu
	{
        EnsayosODU mEnsayosODU = null;
        private EnsayosManager ManejadorEnsayo;
        private static readonly ILog logger = LogManager.GetLogger(typeof(detallesensayoodu));
        

		public detallesensayoodu(Ensayos ensayo)
		{
			this.InitializeComponent();
            ManejadorEnsayo = new EnsayosManager();

            mEnsayosODU = (EnsayosODU)ensayo;
            loadEnsayo(mEnsayosODU);
			
			// Insert code required on object creation below this point.
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        


        private void loadEnsayo(EnsayosODU ensayo)
        {
            txtAprobado.Text = ensayo.AprobadoSINO;
            txtCodigo.Text = ensayo.Codigo;
            txtCorrienteAltaC.Text = ensayo.Corrientehc.ToString();
            txtCorrienteAltaF.Text = ensayo.Corrienteh.ToString();
            txtCorrienteBaja.Text = ensayo.Corrientel.ToString();
            txtDCFEnsayo.Text = ensayo.DCF.ToString();
            txtDifTempC.Text = ensayo.Temphc.ToString();
            txtDifTempF.Text = ensayo.Temph.ToString();
            txtFactorPotenciaC.Text = ensayo.Cosfc.ToString();
            txtFactorPotenciaF.Text = ensayo.Cosf.ToString();
            txtFechaEnsayo.Text = ensayo.Fecha.ToString();
            txtFuga.Text = ensayo.Fuga;
        //    txtHipot.Text = ensayo.Hipot;
            txtHumedadC.Text = ensayo.Humedadc.ToString();
            txtHumedadF.Text = ensayo.Humedad.ToString();
            txtMarca.Text = ensayo.Marca;
            txtModelo.Text = ensayo.Modelo;
            txtObservaciones.Text = ensayo.Observaciones;
            txtPotenciaAltaC.Text = ensayo.Potenciahc.ToString();
            txtPotenciaAltaF.Text = ensayo.Potenciah.ToString();
            //txtPresionAltaC_Copy.Text = ensayo.presion
            txtPresionBajaTension.Text = ensayo.Presion2.ToString();
            txtPresionEnsayoC.Text = ensayo.Presionc.ToString();
            txtPresionEnsayoF.Text = ensayo.Presion3.ToString();
            txtPresionInicial.Text = ensayo.Presion1.ToString();
            txtPresionRecuperacion.Text = ensayo.Presion4.ToString();
            txtSerie.Text = ensayo.Serie;
            txtTempAmbienteC.Text = ensayo.Tambc.ToString();
            txtTempAmbienteF.Text = ensayo.Tamb.ToString();
            txtTensionAltaC.Text = ensayo.Tensionhc.ToString();
            txtTensionAltaF.Text = ensayo.Tensionh.ToString();
            txtTensionBaja.Text = ensayo.Tensionl.ToString();
            txtTiempoEnsayo.Text = FormatearTiempo(ensayo.Tiempoensayo); //ensayo.Tiempoensayo.ToString();
            txtVacio.Text = ensayo.Vacio;
            txtVelocidadAltaF.Text = ensayo.Velocidadh.ToString();
            txtVelocidadBaja.Text = ensayo.Velocidadl.ToString();
            txtPresionAltaC_Copy.Text = ensayo.Velocidadhc.ToString();
            txtDescripcionFalla.Text = ManejadorEnsayo.ObtenerDescripcionFalla(ensayo);
            txtUsuario.Text = ensayo.Usuario;
            
            

        }

        private string FormatearTiempo(int segundos)
        {
            TimeSpan ts = TimeSpan.FromSeconds(segundos);
            return string.Format("{0:0#} : {1:0#}", ts.Minutes, ts.Seconds);
        }

        private void btnGuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ManejadorEnsayo.ModificarObservacion(mEnsayosODU, txtObservaciones.Text);
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnGuardarCambios_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();

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

	}
}






