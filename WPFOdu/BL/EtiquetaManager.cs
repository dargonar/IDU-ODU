using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using System.Configuration;

using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using iDU.BL;



namespace iDU.BL
{
    class EtiquetaManager : Manager
    {

      #region DAO Wrapper
      public List<Etiqueta> ObtenerEtiquetas()
      {

          return AccesoDatos.ObtenerEtiquetas();
      }

      public void EliminarEtiqueta(Etiqueta e)
      {
          AccesoDatos.EliminarEtiqueta(e);
      }

      public void CambiarNombreEtiqueta(Etiqueta e,string nuevonombre)
      {

          AccesoDatos.CambiarNombreEtiqueta(e,nuevonombre);

      }

      public void GuardarEtiqueta(Etiqueta e)
      {

          AccesoDatos.GuardarEtiqueta(e);
      }
      

      public List<Etiqueta> ObtenerEtiquetasConComponentes()
      {

          //return AccesoDatos.ObtenerEtiquetasConComponentes();
          List<Etiqueta> nuevalista = AccesoDatos.ObtenerEtiquetas();

          foreach (Etiqueta e in nuevalista)
              e.Componentes=AccesoDatos.ObtenerComponentesEtiquetas(e.Nombre);

          return nuevalista;
      }


      public void AgregarEnsayoReimpresiones(Ensayos ens)
      {

          AccesoDatos.AgregarEnsayoReimpresiones(ens);
          
      }

      public Etiqueta ObtenerEtiquetaConComponentes(int IDEtiqueta)
      {
          Etiqueta nuevaetiqueta = AccesoDatos.ObtenerEtiqueta(IDEtiqueta);
          nuevaetiqueta.Componentes =AccesoDatos.ObtenerComponentesEtiquetas(nuevaetiqueta.Nombre);

          return nuevaetiqueta;

      }

      public List<Ensayos> ObtenerEnsayosReimpresiones()
      {

          List<Ensayos> listaensayos = AccesoDatos.ObtenerEnsayosReimpresiones();
          return listaensayos;
      }
      #endregion DAO Wrapper
      
      #region Archivo

      public Etiqueta LeerEtiquetaDeArchivo(string archivo)
        {
            ArchivoEtiqueta.ArchivoEtiqueta EtiquetaFile = new iDU.ArchivoEtiqueta.ArchivoEtiqueta();
            return EtiquetaFile.LeerEtiquetaDeArchivo(archivo);
        }

        public void GuardarEtiquetaEnArchivo(Etiqueta e,string archivo)
        {

            ArchivoEtiqueta.ArchivoEtiqueta EtiquetaFile = new iDU.ArchivoEtiqueta.ArchivoEtiqueta();
            EtiquetaFile.GuardarEtiquetaEnArchivo(e,archivo);

        }

        #endregion
        
      #region Manejo de Imagen

        private float mFactorCorreccion = 1.0f;

      public Bitmap GenerarBitmapDeEtiqueta(Etiqueta etiqueta, Modelo modelo, CaracteristicasTecnicas car_tecnicas)
      {
         return GenerarBitmapDeEtiqueta(etiqueta, modelo, car_tecnicas, null);
      }

      /// <summary>
      /// Recorre los elementos que conforman la etiqueta, y setea los valores
      /// que son variables, como numero de serie.
      /// </summary>
      /// <param name="etiqueta"></param>
      /// <param name="modelo"></param>
      /// <param name="car_tecnicas"></param>
      /// <param name="ens"></param>
      /// <returns></returns>
      public Bitmap GenerarBitmapDeEtiqueta(Etiqueta etiqueta,Modelo modelo, CaracteristicasTecnicas car_tecnicas, Ensayos ens)
      {
        foreach (EtiquetaItem item in etiqueta.Componentes)
        {
          if (item.EsVariable())
          {
            string value = ObtenerValorDeColumna(item.Param, modelo, car_tecnicas);
            item.ParamValue = value;
          }
          else
          {
            if (item.Param.Equals("NUMERODESERIE"))
            {
              if(ens != null)
                item.ParamValue = ens.Serie;
            }
            else
            {
              item.ParamValue = item.Param;
            }
          }
        }
        return GenerarBmp(etiqueta, modelo );
      }

      /// <summary>
      /// Obtiene el valor de la columna variable correspondiente. 
      /// Es la funcion soporte de GenerarBitmapDeEtiqueta.
      /// </summary>
      /// <param name="parametro"></param>
      /// <param name="modelo"></param>
      /// <param name="car_tecnicas"></param>
      /// <returns></returns>
      private string ObtenerValorDeColumna(string parametro, Modelo modelo, CaracteristicasTecnicas car_tecnicas)
        {
          parametro = parametro.Trim();
          string value = string.Empty;
          switch ( parametro )
          {
            case "TIPO": 
            case "modelos_esidu":
              value = modelo.EsIdu.ToString(); ;
              break;
            case "MARCA":
            case "modelos_marca":
              value = modelo.Marca;
              break;
            case "MODELO":
            case "modelos_modelo":
              value = modelo.Nombremodelo;
              break;
            case "CODIGO":
            case "modelos_codigo":
              value = modelo.Codigo;
              break;
            case "REF":
            case "modelos_referencia":
              value = modelo.Referencia;
              break;
            case "EAN13":
            case "modelos_ean13":
              value = modelo.Ean13;
              break;
            case "LOGO":
            case "modelos_logo":
              value = modelo.Logo;
              break;
            case "EXTRA1":
            case "modelos_conjunto":
              value = modelo.Conjunto;
              break;
            case "EXTRA2":
            case "modelos_capacidad":
              value = modelo.Capacidad;
              break;
            case "EXTRA3":
            case "modelos_codigoicsa":
              value = modelo.CodigoICSA;
              break;
            case "DIMEN":
            case "modelos_dimensiones":
              value = modelo.Dimension;
              break;
            case "VERSION":
            case "caracteristicastecnicasequipos_version":
              value = car_tecnicas.Version.ToString(); 
              break;
            case "DESCRI1":
            case "caracteristicastecnicasequipos_descripcion1":
              value = car_tecnicas.Descripcion1;
              break;
            case "DESCRI2":
            case "caracteristicastecnicasequipos_descripcion2":
              value = car_tecnicas.Descripcion2;
              break;
            case "DESCRI3":
            case "caracteristicastecnicasequipos_descripcion3":
              value = car_tecnicas.Descripcion3;
              break;
            case "DESCRI4":
            case "caracteristicastecnicasequipos_descripcion4":
              value = car_tecnicas.Descripcion4;
              break;
            case "DESCRI5":
            case "caracteristicastecnicasequipos_descripcion5":
              value = car_tecnicas.Descripcion5;
              break;
            case "DESCRI6":
            case "caracteristicastecnicasequipos_descripcion6":
              value = car_tecnicas.Descripcion6;
              break;
            case "TENSIONNOM":
            case "caracteristicastecnicasequipos_tensionnominal":
              value = car_tecnicas.TensionNominal;
              break;
            case "FRECUENCIA":
            case "caracteristicastecnicasequipos_frecuencia":
              value = car_tecnicas.Frecuencia;
              break;
            case "POTENCIAMAX":
            case "caracteristicastecnicasequipos_potenciamaxima":
              value = car_tecnicas.PotenciaMaxima;
              break;
            case "CORRIENTEMAX":
            case "caracteristicastecnicasequipos_corrientemaxima":
              value = car_tecnicas.CorrienteMaxima;
              break;
            case "CARGA":
            case "caracteristicastecnicasequipos_carga":
              value = car_tecnicas.Carga;
              break;
            case "PRESION":
            case "caracteristicastecnicasequipos_presion":
              value = car_tecnicas.Presion;
              break;
            case "CAPACIDAD":
            case "caracteristicastecnicasequipos_capacidad":
              value = car_tecnicas.CapacidadFrio;
              break;
            case "POTENCIANOM":
            case "caracteristicastecnicasequipos_potencianominalfrio":
              value = car_tecnicas.PotenciaNominalFrio;
              break;
            case "CORRIENTENOM":
            case "caracteristicastecnicasequipos_corrientenominalfrio":
              value = car_tecnicas.CorrienteNominalFrio;
              break;
            case "PESO":
            case "caracteristicastecnicasequipos_peso":
              value = car_tecnicas.Peso;
              break;
            case "CAPACIDAD_C":
            case "caracteristicastecnicasequipos_capacidadcalor":
              value = car_tecnicas.CapacidadCalor;
              break;
            case "POTENCIANOM_C":
            case "caracteristicastecnicasequipos_potencianominalcalor":
              value = car_tecnicas.PotenciaNominalCalor;
              break;
            case "CORRIENTENOM_C":
            case "caracteristicastecnicasequipos_corrientenominalcalor":
              value = car_tecnicas.CorrienteNominalCalor;
              break;
            case "ERR":
            case "caracteristicastecnicasequipos_err":
              value = car_tecnicas.Err;
              break;
            case "NRO. SERIE":
            case "NRO.SERIE":
              value = "1";
              break;

            }

            return value;
        }

      private Bitmap GenerarBmp(Etiqueta etiqueta, Modelo modelo)
      {
        // Obtengo mayores extremos
        /*
        float ancho = (float)0;
        float alto = (float)0;
        foreach (EtiquetaItem item in etiqueta.Componentes)
        { 
          float xdiff = (float)item.Xfinal-(float)item.Xinicial;
          float ydiff = (float)item.Yfinal-(float)item.Yinicial;
          if (xdiff > ancho)
            ancho = xdiff;
          if (ydiff > alto)
            alto = ydiff;
        }
        alto = (float)alto / 10.0f;
        ancho = (float)ancho / 10.0f;
        */
        
        //Bitmap MapaDeImagen = new Bitmap((int) ancho,(int)alto);
        //Bitmap MapaDeImagen = new Bitmap(250, 742);
        Bitmap MapaDeImagen = new Bitmap(1000, 1000);

        // Pinto fondo blanco.
        for (int i = 0; i < MapaDeImagen.Width; i++)
          for (int j = 0; j < MapaDeImagen.Height; j++)
            MapaDeImagen.SetPixel(i,j, System.Drawing.Color.White);

      using (Graphics gr = Graphics.FromImage(MapaDeImagen))
      {
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        if (etiqueta.EsBulto)
        {
          if (!string.IsNullOrEmpty(modelo.BackgroundBulto))
            DibujarBackGround(gr, modelo.BackgroundBulto);
        }
        else
          if (!string.IsNullOrEmpty(modelo.BackgroundProducto))
            DibujarBackGround(gr, modelo.BackgroundProducto);

        foreach (EtiquetaItem item in etiqueta.Componentes)
        {
          switch (item.Tipo)
          {
            case 0:
              //REDO
              DibujarString(gr, item);
              break;
            case 2:
              //UNDO
              //DibujarString(gr, item);
              break;
            case 4:
              //UNDO
              //DibujarImagen(gr, item);
              break;
            case 5:
              //UNDO
              //DibujarLinea(gr, item);
              break;
            }
          }
        }
        return MapaDeImagen;
      }

      #region Funciones de Dibujo de elementos(string, bmp y line) en Lienzo.

      private void DibujarBackGround(Graphics gr, string FileName)
      {
        string skey = "DIRECTORIO_IMAGENES_EXTRAS";

        if (string.IsNullOrEmpty(skey))
          return;

        string file = ConfigurationManager.AppSettings[skey] + FileName;

        //Corroboramos la direccion de la imagen.
        if (!File.Exists(file))
        {
          string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
          FileInfo o = new FileInfo(path);
          file = o.Directory + file;

          if (!File.Exists(file))
          {
            //No se encontro el path de la imagen.
            return;
          }
        }

        System.Drawing.Image imagen = System.Drawing.Image.FromFile(file);
        //UNDO
        gr.DrawImage(imagen,
          (float)0
          , (float)0
          , (float)imagen.Width / 3.0F
          , (float)imagen.Height/ 3.0F
          );
        //gr.DrawImage(imagen,
        // (float)0
        // , (float)0
        // , (float)imagen.Width
        // , (float)imagen.Height);
      }


      private void DibujarString(Graphics gr, EtiquetaItem item)
      {
        using( SolidBrush brocha = new SolidBrush(System.Drawing.Color.Black) )
        {
          System.Drawing.FontStyle estilo = new System.Drawing.FontStyle();

          if (item.Bold == 1)
            estilo = System.Drawing.FontStyle.Bold;
          else
            estilo = System.Drawing.FontStyle.Regular;
          
          using( Font fuente = new Font(item.Font, item.Size,estilo) )
            gr.DrawString(item.ParamValue
              , fuente
              , brocha
              , (float)item.Xinicial / mFactorCorreccion
              , (float)item.Yinicial / mFactorCorreccion);
        }           
      }
 
      private void DibujarImagen(Graphics gr, EtiquetaItem item)
        {
          string skey = string.Empty;
          switch(item.Param.ToUpper()) 
          {
            case "LIRAM.WMF":
            case "LREPARG.WMF":
                skey = "DIRECTORIO_IMAGENES_EXTRAS";
                break;

            case "CAPACIDAD":
            case "caracteristicastecnicasequipos_capacidad":
            case "CAPACIDAD_C":
            case "caracteristicastecnicasequipos_capacidadcalor":
                skey = "DIRECTORIO_IMAGENES_CAPACIDAD";
                break;
            case "LOGO":
            case "modelos_logo":
                skey = "DIRECTORIO_IMAGENES_LOGO";
                break;
            case "DIMEN":
            case "modelos_dimensiones":
                skey = "DIRECTORIO_IMAGENES_DIMENSION";
                break;
            case "EAN13":
            case "modelos_ean13":
                skey = "DIRECTORIO_IMAGENES_EAN13";
                break;
          }
          
          if( string.IsNullOrEmpty(skey ))
            return;

          string file = ConfigurationManager.AppSettings[skey] + item.ParamValue;
          
          //Corroboramos la direccion de la imagen.
          if (!File.Exists(file))
          {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo o = new FileInfo(path);
            file = o.Directory + file;
            
            if (!File.Exists(file))
            {
              //No se encontro el path de la imagen.
              return;
            }
          }

          System.Drawing.Image imagen = System.Drawing.Image.FromFile(file);
          //UNDO
          //gr.DrawImage(imagen,
          //  (float)item.Xinicial / mFactorCorreccion
          //  , (float)item.Yinicial / mFactorCorreccion
          //  , (float)(item.Xfinal / mFactorCorreccion - item.Xinicial / mFactorCorreccion)
          //  , (float)(item.Yfinal / mFactorCorreccion - item.Yinicial / mFactorCorreccion));
          gr.DrawImage(imagen,
           (float)0
           , (float)0
           , (float)imagen.Width
           , (float)imagen.Height);
        }

      private void DibujarLinea(Graphics gr, EtiquetaItem item)
      {
        using (System.Drawing.Pen Lapiz = new System.Drawing.Pen(System.Drawing.Color.Black))
        {
          gr.DrawLine(Lapiz,
            (float)item.Xinicial / mFactorCorreccion,
            (float)item.Yinicial / mFactorCorreccion,
            (float)item.Xfinal / mFactorCorreccion,
            (float)item.Yfinal / mFactorCorreccion);
        }
      }
      
      #endregion Funciones de Dibujo de elementos(string, bmp y line) en Lienzo.

      #region Funciones Helper
      public Bitmap DibujarGrilla()
      {
        Bitmap MapaDeImagen = new Bitmap(1000, 1000);
          
          Graphics g = Graphics.FromImage(MapaDeImagen);
          System.Drawing.Pen Lapiz = new System.Drawing.Pen(System.Drawing.Color.Gray);

          //dibujar lineas horizontales
          //for( int i = 0 ; i < MapaDeImagen.Height;i+=38)
          for (int i = 0; i < MapaDeImagen.Height; i += 10)
          {
              g.DrawLine(Lapiz ,0, i ,MapaDeImagen.Width , i); 
          }

          //dibujar lineas verticales
          //for (int i = 0; i < MapaDeImagen.Width; i+=38)
          for (int i = 0; i < MapaDeImagen.Width; i += 10)
          {

              g.DrawLine(Lapiz, i, 0, i, MapaDeImagen.Height);
           

          }

          return MapaDeImagen;
      }
      #endregion Funciones Helper

      #region Funciones GDI32
        [DllImport("gdi32")]
      static extern int DeleteObject(IntPtr o);
      public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
      {
          IntPtr ip = source.GetHbitmap();
          BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, 
            IntPtr.Zero, 
            Int32Rect.Empty,
          System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
          DeleteObject(ip);
          return bs;
      }
      #endregion Funciones GDI32
        
      #region Funciones de Escalado
      public static Bitmap Escalar(Bitmap Bitmap, float factor)
      {
        
          float ScaleFactorX = factor;
          float ScaleFactorY = factor;

          int scaleWidth = (int)Math.Max(Bitmap.Width * ScaleFactorX, 1.0f);
          int scaleHeight = (int)Math.Max(Bitmap.Height * ScaleFactorY, 1.0f);

          Bitmap scaledBitmap = new Bitmap(scaleWidth, scaleHeight);

          // Scale the bitmap in high quality mode.
          using (Graphics gr = Graphics.FromImage(scaledBitmap))
          {
              gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
              gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
              gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
              gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

              gr.DrawImage(Bitmap, new Rectangle(0, 0, scaleWidth, scaleHeight), new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), GraphicsUnit.Pixel);

          }

          // Copy original Bitmap's EXIF tags to new bitmap.
          foreach (PropertyItem propertyItem in Bitmap.PropertyItems)
          {
              scaledBitmap.SetPropertyItem(propertyItem);
          }



          return scaledBitmap;
      }

      public static Bitmap Escalar(Bitmap Bitmap)
      {
          int nuevoAncho = 130;
          int nuevoAlto = 340;
          Bitmap scaledBitmap = new Bitmap(nuevoAncho,nuevoAlto);

          // Scale the bitmap in high quality mode.
          using (Graphics gr = Graphics.FromImage(scaledBitmap))
          {
              gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
              gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
              gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
              gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

              gr.DrawImage(Bitmap, 
                  new Rectangle(0, 0, nuevoAncho, nuevoAlto), 
                  new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), 
                  GraphicsUnit.Pixel);

          }

          // Copy original Bitmap's EXIF tags to new bitmap.
          foreach (PropertyItem propertyItem in Bitmap.PropertyItems)
          {
              scaledBitmap.SetPropertyItem(propertyItem);
          }



          return scaledBitmap;
      }
      #endregion Funciones de Escalado
      
      #endregion Manejo de Imagen

    }
}
