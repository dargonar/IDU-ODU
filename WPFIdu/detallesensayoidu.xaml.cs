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
	public partial class detallesensayoidu
	{

        EnsayosIDU mEnsayosIDU = null;
        private EnsayosManager ManejadorEnsayo;
        private static readonly ILog logger = LogManager.GetLogger(typeof(detallesensayoidu));


		public detallesensayoidu(Ensayos ensayo)
		{
			this.InitializeComponent();
                      
            ManejadorEnsayo = new EnsayosManager();

            mEnsayosIDU = (EnsayosIDU)ensayo;
            loadEnsayo(mEnsayosIDU);
			
			
		}


        private void loadEnsayo(EnsayosIDU mEnsayosIDU)
        {
            if (mEnsayosIDU.Aprobado)
                //AprobadotextBox.Text = "SI";
                txtAprobado.Text = "SI";
            else
                txtAprobado.Text = "NO";


           // CodigotextBox.Text = mEnsayosIDU.Codigo;
           txtCodigo.Text = mEnsayosIDU.Codigo;
           txtCorrBajaTension.Text = mEnsayosIDU.CorrienteBajaTension.ToString();
           txtCorrInicialCalor.Text = mEnsayosIDU.CorrienteCalorInicial.ToString();
           txtCorrInicialFrio.Text = mEnsayosIDU.CorrienteInicial.ToString();
           txtCorrLow.Text = mEnsayosIDU.CorrienteLow.ToString();

           txtFechaEnsayo.Text = mEnsayosIDU.Fecha.ToString();
           txtFuga.Text = mEnsayosIDU.Fuga;
           txtHipot.Text = mEnsayosIDU.Hipot;

           txtMarca.Text = mEnsayosIDU.Marca;
           txtModelo.Text = mEnsayosIDU.Modelo;
           txtObservaciones.Text = mEnsayosIDU.Observaciones;
           txtSerie.Text = mEnsayosIDU.Serie;
           txtTiempoEnsayo.Text = FormatearTiempo(mEnsayosIDU.TiempoEnsayo);
           txtVelBajaTension.Text = mEnsayosIDU.VelocidadBajaTension.ToString();
           txtVelHigh.Text  = mEnsayosIDU.VelocidadHigh.ToString();
           txtVelInicial.Text = mEnsayosIDU.VelocidadInicial.ToString();
           txtVelLow.Text = mEnsayosIDU.VelocidadLow.ToString();
           txtCorrHigh.Text  = mEnsayosIDU.CorrienteHIGH.ToString();
           txtDescripcionFalla.Text = ManejadorEnsayo.ObtenerDescripcionFalla(mEnsayosIDU);
           txtUsuario.Text = mEnsayosIDU.Usuario;
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string FormatearTiempo(int tiempo)
        {
            int s = 0;
            int m = 0;

            string segundos = string.Empty;
            string minutos = string.Empty;
            string tiempoformateado = string.Empty;


            for (int i = 0; i < tiempo-1; i++)
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


        private void btnGuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ManejadorEnsayo.ModificarObservacion(mEnsayosIDU, txtObservaciones.Text);
            }
            
            catch (Exception ex)
            {
                logger.ErrorFormat("btnGuardarCambios_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();

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


