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
	public partial class mantenimientoproducto
	{
        private static readonly ILog logger = LogManager.GetLogger(typeof(mantenimientoproducto));
		public mantenimientoproducto()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMantenimientoModelos_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                mantenimientomodelos mantmod = new mantenimientomodelos();
                mantmod.ShowDialog();

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnMantenimientoModelos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
        }

        private void btnMantenimientoReferencias_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                mantenimientoreferencias mantref = new mantenimientoreferencias();
                mantref.ShowDialog();

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnMantenimientoReferencias_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
        }
	}
}