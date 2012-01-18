using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Runtime.InteropServices;
using System.Drawing;
using iDU.BL;
using iDU.CommonObjects;
using log4net;
using System.Configuration;


namespace dcf001
{
	public partial class vistaprevia
	{

        private static readonly ILog logger = LogManager.GetLogger(typeof(vistaprevia));
        private Bitmap ImagenTemp = null;
        private EtiquetaManager ManejadorEtiquetas;
        private Ensayos mEnsayo = null;
        private bool mProducto = true;
        private bool mImprimirIDU = true;

        public bool Producto
        {
            get { return mProducto; }
            set { mProducto = value; }

        }

        public bool ImprimirIDU
        {
            get { return mImprimirIDU; }
            set { mImprimirIDU = value; }
        }


		public vistaprevia(Etiqueta e, Modelo m , CaracteristicasTecnicas ct,Ensayos ens , bool esProducto)
		{
            try
            {
                
                this.InitializeComponent();
                ManejadorEtiquetas = new EtiquetaManager();
                mEnsayo = ens;
                ImagenTemp = ManejadorEtiquetas.GenerarBitmapDeEtiqueta(e, m, ct,ens);
                float c1 = (float)(imgEtiqueta.Height / ImagenTemp.Height);
                Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp,c1);
                imgEtiqueta.Source = EtiquetaManager.loadBitmap(escalada);
                Producto = esProducto;

                if (!m.EsIdu)
                    ImprimirIDU = false;

                /* ImagenTemp = ManejadorEtiquetas.GenerarBitmapDeEtiqueta(etiquetaseleccionada, modeloseleccionado, caracteristicas);
                float c1 = (float)(imgEtiqueta.Height / ImagenTemp.Height);
                Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp, c1);
                imgEtiqueta.Source = EtiquetaManager.loadBitmap(escalada);
               */
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("vistaprevia(Etiqueta e, Modelo m, CaracteristicasTecnicas ct, Ensayos ens):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                 , ex.Message
                 , ex.StackTrace
                 , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexepcion = new excepcion(ex);
                excepcion formexcepciones = new excepcion(ex);
                formexcepciones.ShowDialog();
            }
			
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                 if (ImagenTemp == null)
                    return;


                System.Drawing.Image imagenaimprimir = ImagenTemp;
                ImpresorEtiqueta imp = new ImpresorEtiqueta();
                int ALTO = int.Parse(ConfigurationManager.AppSettings["ALTURA_ETIQUETA_PRODUCTO_IDU"]);
                int ANCHO =int.Parse(ConfigurationManager.AppSettings["ANCHO_ETIQUETA_PRODUCTO_IDU"]);
                string nombreimpresora = ConfigurationManager.AppSettings["ImpresoraProducto"];


                if (!ImprimirIDU)
                {

                    ALTO =int.Parse(ConfigurationManager.AppSettings["ALTURA_ETIQUETA_PRODUCTO_ODU"]);
                    ANCHO =int.Parse(ConfigurationManager.AppSettings["ANCHO_ETIQUETA_PRODUCTO_ODU"]);
                }
                
                if (!Producto)
                {

                    nombreimpresora = ConfigurationManager.AppSettings["ImpresoraBulto"];

                }     
                

                //UNDO
                //imp.ImprimirImagen(imagenaimprimir, nombreimpresora);
                
                //ManejadorEtiquetas.AgregarEnsayoReimpresiones(mEnsayo);
                

                this.Close();

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnImprimir_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                 , ex.Message
                 , ex.StackTrace
                 , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexepcion = new excepcion(ex);
                excepcion formexcepciones = new excepcion(ex);
                formexcepciones.ShowDialog();
            }

       
        }

      
	}
}







