using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using log4net;
namespace dcf001
{
	public partial class cambiarnombre
	{
        public string Nuevonombre;
        private static readonly ILog logger = LogManager.GetLogger(typeof(cambiarnombre));
        public cambiarnombre()
		{
			this.InitializeComponent();
			
			
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Nuevonombre = "";
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Nuevonombre = txtNombre.Text;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Nuevonombre = "";
            this.Close();
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


/*




        public string Nuevonombre;
        
        public CambiarNombreEtiquetaForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Nuevonombre = "";
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            Nuevonombre=NuevoNombretextBox.Text;
            this.Close();
        }


*/