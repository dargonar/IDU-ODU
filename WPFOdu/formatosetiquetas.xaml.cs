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
using System.Windows.Forms;
using System.Drawing;
using log4net;
using System.Drawing.Printing;

using WPFiDU.Etiquetas;
namespace dcf001
{
	public partial class formatosetiquetas
	{
    private Bitmap ImagenTemp = null;
            
    private Bitmap ImagenTemplineas = null;
    private static readonly ILog logger = LogManager.GetLogger(typeof(formatosetiquetas));
    private EtiquetaManager ManejadorEtiquetas;

		public formatosetiquetas()
		{
		  this.InitializeComponent();
			
      ManejadorEtiquetas = new EtiquetaManager();
      LlenarListBoxs();

      //Grilla
      imgLineas.Visibility = Visibility.Hidden;
      ImagenTemplineas = ManejadorEtiquetas.DibujarGrilla();

      //float c1 = (float)(imgLineas.Height / ImagenTemplineas.Height);
      //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemplineas, c1);
      //imgLineas.Source = EtiquetaManager.loadBitmap(escalada);
      imgLineas.Source = EtiquetaManager.loadBitmap(ImagenTemplineas);

      String pkInstalledPrinters;

      logger.DebugFormat("formatosetiquetas():: Cantidad e impresoras disponibles en la PC: '{0}'"
        , PrinterSettings.InstalledPrinters.Count.ToString());
      
      for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
      {
        pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
        cmbImpresora1.Items.Add(pkInstalledPrinters);
      }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void LlenarListBoxFormatos()
    {
      //try
      //{
        
      //  ltvInstalados.Items.Clear();
      //  EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(false);
      //  List<IEtiqueta> list = oEtiquetasManagerEx.getFormatos();
      //  for (int i = 0; i < list.Count; i++)
      //  {
      //    ltvInstalados.Items.Add(list[i]);
      //  }
      //}
      //catch (Exception ex)
      //{
      //  logger.ErrorFormat("LlenarListBoxFormatos:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //    , ex.Message
      //    , ex.StackTrace
      //    , ex.InnerException != null ? ex.InnerException.Message : "");
      //  excepcion formularioexepciones = new excepcion(ex);
      //  formularioexepciones.ShowDialog();

      //}
    }

    private void LlenarListBoxModelos()
    {
      try
      {
        ModelosManager ManejadorModelos = new ModelosManager();
        List<Modelo> ListaModelos = ManejadorModelos.ObtenerModelos();
        //List<ModeloExt> ListaModelos = ManejadorModelos.ObtenerModelosExt(); 
        for (int i = 0; i < ListaModelos.Count; i++)
        {
          ltvModelos.Items.Add(ListaModelos[i]);
        }
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("LlenarListBoxModelos:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
      }
    }

    private void LlenarListBoxs()
    {
      LlenarListBoxFormatos();
      LlenarListBoxModelos();
    }

    private void ltvInstalados_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //try
      //{
      //  if (ltvInstalados.SelectedIndex < 0 || ltvModelos.SelectedIndex < 0)
      //    return;

      //  CargarImagen();
      //}
      //catch (Exception ex)
      //{
      //  logger.ErrorFormat("ltvInstalados_SelectionChanged(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //     , ex.Message
      //     , ex.StackTrace
      //     , ex.InnerException != null ? ex.InnerException.Message : "");
      //  excepcion formexcepcion = new excepcion(ex);
      //  formexcepcion.ShowDialog();
      //}
    }

    private void ltvModelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {


      try
      {
        if (ltvModelos.SelectedIndex < 0)
          return;

        CargarImagenFromModelo();
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("ltvModelos_SelectionChanged(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
         , ex.Message
         , ex.StackTrace
         , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formexcepcion = new excepcion(ex);
        formexcepcion.ShowDialog();
      }
       
    }

     
    private void CargarImagenFromModelo()
    {

      if (ltvModelos==null)
        return;
      if (ltvModelos.SelectedItem==null)
        return;
        
      try
      {

        Modelo oModelo = ltvModelos.SelectedItem as Modelo;
        Ensayos infoens = new Ensayos();
        infoens.Aprobado = true;
        infoens.Serie = "XXXXXXXXXXX";
        //infoens.Serie = oModelo.Modelo;

        string mEtiquetaKey = oModelo.BackgroundBulto;
        if(this.tbtnEtiquetaProducto.IsChecked == true)
          mEtiquetaKey = oModelo.BackgroundProducto;
        
        EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(oModelo.EsIdu); 
        
        ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(
            oModelo
            , mEtiquetaKey.Trim() 
            , infoens);
            
        // Imagen cruda.
        imgEtiqueta.Source = EtiquetaManager.loadBitmap(ImagenTemp);
        imgEtiqueta.Stretch = Stretch.Uniform;
      }
      catch (Exception ex)
      {
        logger.Error("CargarImagenFromModelo()", ex);
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
      }
    }
    
    bool EsBulto = false;
    
    private void CargarImagen()
    {
      //try
      //{
      //  Modelo oModelo = ltvModelos.SelectedItem as Modelo;
      //  IEtiqueta oIEtiqueta = ltvInstalados.SelectedItem as IEtiqueta;

      //  EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(false);
      //  if (typeof(EtiquetaProducto).Equals(oIEtiqueta.GetType()))
      //  {
      //    EtiquetaProducto oEtiquetaProducto = oIEtiqueta as EtiquetaProducto;
          
            
      //    ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(
      //      oModelo
      //      , oEtiquetaProducto
      //      , null);
      //    EsBulto = false;
 
      //  }
      //  else{
      //    EtiquetaBulto oEtiquetaBulto = oIEtiqueta as EtiquetaBulto;
          
           
      //    ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(
      //        oModelo
      //        , oEtiquetaBulto
      //        , null
      //        );
      //    EsBulto = true;
      //  }
 
        
      //  // Imagen cruda.
      //  imgEtiqueta.Source = EtiquetaManager.loadBitmap(ImagenTemp);
      //  imgEtiqueta.Stretch = Stretch.Uniform;
      //}
      //catch (Exception ex)
      //{
      //  logger.ErrorFormat("CargarImagen():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //    , ex.Message
      //    , ex.StackTrace
      //    , ex.InnerException != null ? ex.InnerException.Message : "");
      //  excepcion formularioexepciones = new excepcion(ex);
      //  formularioexepciones.ShowDialog();
      //}
    }

    private void btnImprimir_Click(object sender, RoutedEventArgs e)
    {
      
      try
      {
        Imprimir();
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("btnImprimir_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
        
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();

      }
    }
    
    private Modelo getSelectedModelo()
    {
      if (ltvModelos.SelectedIndex < 0)
        return null;
      return (Modelo)ltvModelos.SelectedItem;
    }
    
    private void Imprimir()
    {
      if (ImagenTemp == null)
      {
        excepcion oExcepcion = new excepcion(new Exception("Configure una etiqueta para imprimir."));
        oExcepcion.ShowDialog();
        return; 
      }
      if (cmbImpresora1.SelectedIndex < 0 || string.IsNullOrEmpty(cmbImpresora1.SelectedItem.ToString()))
      {

        excepcion oExcepcion = new excepcion(new Exception("Seleccione una impresora."));
        oExcepcion.ShowDialog();
        return; 
      }

      ////Genero la imagen
      //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
      //System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;
      //if (imagenaimprimir == null)
      //  return;
      //Modelo mModseloSeleccionado = getSelectedModelo();
      //if (mModseloSeleccionado == null)
      //  return;
      EtiquetasManagerEx oEtiquetasManagerEx = new EtiquetasManagerEx(false);
      oEtiquetasManagerEx.ImprimirImagen(ImagenTemp
        , cmbImpresora1.SelectedItem.ToString(), EsBulto);
    }

    private void btnImportar_Click(object sender, RoutedEventArgs e)
    {
      
      try
      {
        OpenFileDialog selectorarchivo = new OpenFileDialog();
        DialogResult resultado = selectorarchivo.ShowDialog();
        string nombreArchivo;

        if (resultado == System.Windows.Forms.DialogResult.Cancel)
            return;
        nombreArchivo = selectorarchivo.FileName;

        Etiqueta nuevaetiqueta = ManejadorEtiquetas.LeerEtiquetaDeArchivo(nombreArchivo) as Etiqueta;// .LeerParametrosDeArchivo(nombreArchivo) as ParametrosEnsayoIDU;
   
        ManejadorEtiquetas.GuardarEtiqueta(nuevaetiqueta);
        LlenarListBoxFormatos();
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("btnImportar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();

      }
    }

    private void btnExportar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (ltvModelos.SelectedIndex < 0)
          return;

        Modelo oModelo = ltvModelos.SelectedItem as Modelo;
        string nombreArchivo = WPFiDU.Utils.Utils.Slugify(oModelo.Nombremodelo + "_" + oModelo.Marca) + "_" + DateTime.Now.Ticks.ToString() + "_" + (oModelo.EsIdu ? "IDU" : "ODU") + "_" + (EsBulto ? "caja" : "equipo") + ".jpg";
  
        SaveFileDialog selectorarchivo = new SaveFileDialog();
        selectorarchivo.Filter = "Archivo jpg (*.jpg)|*.jpg";
        selectorarchivo.FileName = nombreArchivo;
        DialogResult resultado = selectorarchivo.ShowDialog();
        

        selectorarchivo.CheckFileExists = false;

        if (resultado ==System.Windows.Forms.DialogResult.Cancel)
          return;
        
        nombreArchivo = selectorarchivo.FileName;
         
        EtiquetasManagerEx.GuardarJpg(ImagenTemp, nombreArchivo.Replace("etiqueta.png", "etiqueta.jpg"));
      }

      catch (Exception ex)
      {
        logger.ErrorFormat("btnExportar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
      }
    }

    // ============================================================================================== //
    // Botonera Nueva y vieja.                                                                        //
    // ============================================================================================== //
    private void btnEliminarEtiqueta_Click(object sender, RoutedEventArgs e)
    {
      //try
      //{
      //  if (ltvInstalados.SelectedIndex < 0)
      //    return;

      //  Etiqueta etiquetaseleccionada = ltvInstalados.SelectedItem as Etiqueta;

      //  if (confirmacioneliminar.Show("Eliminar etiqueta", "Esta seguro que desea eliminar la etiqueta seleccionada ? ") == false)
      //    return;

      //  ManejadorEtiquetas.EliminarEtiqueta(etiquetaseleccionada);
      //  ltvInstalados.Items.Remove(etiquetaseleccionada);
      //}
      //catch (Exception ex)
      //{
      //  logger.ErrorFormat("btnEliminar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //    , ex.Message
      //    , ex.StackTrace
      //    , ex.InnerException != null ? ex.InnerException.Message : "");

      //  excepcion formularioexepciones = new excepcion(ex);
      //  formularioexepciones.ShowDialog();
      //}
    }
    
    private void btnCambiarNombreEtiqueta_Click(object sender, RoutedEventArgs e)
    {
      
      //try
      //{
      //  if (ltvInstalados.SelectedIndex < 0)
      //      return;
        
      //  Etiqueta etiquetaseleccionada = ltvInstalados.SelectedItem as Etiqueta;

      //  cambiarnombre nuevoform = new cambiarnombre();
      //  nuevoform.ShowDialog();

      //  string nuevonombre = nuevoform.Nuevonombre;
      //  if (nuevonombre == "")
      //      return;
      //  ManejadorEtiquetas.CambiarNombreEtiqueta(etiquetaseleccionada, nuevonombre);
      //  ltvInstalados.Items.Clear();
      //  LlenarListBoxFormatos();
      //}
      //catch (Exception ex)
      //{
      //  logger.ErrorFormat("btnCambiarNombre_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      //    , ex.Message
      //    , ex.StackTrace
      //    , ex.InnerException != null ? ex.InnerException.Message : "");
      //  excepcion formularioexepciones = new excepcion(ex);
      //  formularioexepciones.ShowDialog();

      //}
    }

    private void tgbGrilla1x1_Click(object sender, RoutedEventArgs e)
    {
      //LlenarListBoxs();
      //return;
      if (imgLineas.Visibility == Visibility.Hidden)
        imgLineas.Visibility = Visibility.Visible;
      else
        imgLineas.Visibility = Visibility.Hidden;
    }

    private void tbtnEtiquetaBulto_Checked(object sender, RoutedEventArgs e)
    {
      if (tbtnEtiquetaProducto!=null)
        tbtnEtiquetaProducto.IsChecked=false;
      EsBulto = true;
      CargarImagenFromModelo();
    }

    private void tbtnEtiquetaProducto_Checked(object sender, RoutedEventArgs e)
    {
      tbtnEtiquetaBulto.IsChecked = false;
      EsBulto = false;
      CargarImagenFromModelo();
    }

    

     
	}
}



