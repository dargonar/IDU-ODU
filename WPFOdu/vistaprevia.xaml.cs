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

using WPFiDU.Etiquetas;

namespace dcf001
{
	public partial class vistaprevia
	{

    private static readonly ILog logger = LogManager.GetLogger(typeof(vistaprevia));
    private Bitmap ImagenTemp = null;
    private bool esProducto = false;
    private Modelo mPrintedModelo;
    private Ensayos mPrintedEnsayo;
    public vistaprevia(Modelo mModelo, Ensayos mEnsayo, bool esProducto)
		{
      mPrintedModelo = mModelo;
      mPrintedEnsayo = mEnsayo;

      try
      {
        this.InitializeComponent();
        this.esProducto = esProducto;

        string mEtiquetaKey = mModelo.BackgroundBulto;
        if(esProducto)
          mEtiquetaKey = mModelo.BackgroundProducto;

        EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(mModelo.EsIdu);

        ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(
          mModelo
          , mEtiquetaKey.Trim()
          , mEnsayo);

        imgEtiqueta.Source = EtiquetaManager.loadBitmap(ImagenTemp);
        imgEtiqueta.Stretch = Stretch.Uniform;

        btnImprimir.IsEnabled = true;
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
        btnImprimir.IsEnabled = false;
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
        
        string nombreimpresora = ConfigurationManager.AppSettings["ImpresoraProducto"];
        
        if (!this.esProducto)
        {
          nombreimpresora = ConfigurationManager.AppSettings["ImpresoraBulto"];
        }

        EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(true);
        oEtiquetasManagerEx.ImprimirImagen(ImagenTemp , nombreimpresora, !this.esProducto);

        logger.InfoFormat("Reimpresión de Etiqueta. {0}; Nro de Serie:'{1}'; Fecha Ensayo:'{2}';", mPrintedModelo.ToString2(), mPrintedEnsayo.Serie, mPrintedEnsayo.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
        
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







