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
using System.Collections.Generic;
using log4net;

namespace dcf001
{
	public partial class Consultaxaml
	{
        private static readonly ILog logger = LogManager.GetLogger(typeof(Consultaxaml));
		public Consultaxaml()
		{
            try
            {

                this.InitializeComponent();
                LlenarListView();
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("Consultaxaml():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();

            }
			
			
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LlenarListView()
        {
            try
            {

                EtiquetaManager etiquetas_manag = new EtiquetaManager();
                List<Ensayos> listaensayos = etiquetas_manag.ObtenerEnsayosReimpresiones();

                for (int i = 0; i < listaensayos.Count; i++)
                {

                    ltvConsulta.Items.Add(listaensayos[i]);
                }
            }
            catch (Exception ex)
            {
                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();

                logger.ErrorFormat("LlenarListView():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

            }
        }
    }
}