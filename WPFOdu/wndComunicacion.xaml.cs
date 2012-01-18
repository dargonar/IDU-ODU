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
using iDU.PLC;
using System.Configuration;

namespace dcf001
{
   
	public partial class wndComunicacion
	{
    private static readonly ILog logger = LogManager.GetLogger(typeof(wndComunicacion));
     
		public wndComunicacion()
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
        conexionplc formplc = new conexionplc(true);
        formplc.ShowDialog();


        if (!conexionplc.UserMadeChanges)
        {
          formplc.Close();
          formplc = null;
          return;
        }

         
        formplc.Close();
        formplc = null;
      }
      catch (Exception ex)
      {
        excepcion formularioexcepciones = new excepcion(ex);
        formularioexcepciones.ShowDialog();
        logger.ErrorFormat(" btnMantenimientoModelos_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
         , ex.Message
         , ex.StackTrace
         , ex.InnerException != null ? ex.InnerException.Message : "");
      }
     
    }

    private void btnMantenimientoReferencias_Click(object sender, RoutedEventArgs e)
        {
            try
            {

              wndServicesManager owndServicesManager = new wndServicesManager();
              owndServicesManager.ShowDialog();

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