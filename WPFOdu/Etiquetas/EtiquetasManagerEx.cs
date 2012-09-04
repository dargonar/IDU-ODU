
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iDU.CommonObjects;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

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

using log4net;
namespace WPFiDU.Etiquetas
{
  class EtiquetasManagerEx
  {
    #region Public Members
    public PosicEtiquetaBulto mPosicEtiquetaBulto = new PosicEtiquetaBulto();
    public PosicEtiquetaProducto mPosicEtiquetaProducto = new PosicEtiquetaProducto();
    public PosicEtiquetaProducto mPosicEtiquetaFalla = new PosicEtiquetaProducto();
    public List<EtiquetaBulto> mEtiquetaBultoList = new List<EtiquetaBulto>();
    public List<EtiquetaProducto> mEtiquetaProductoList = new List<EtiquetaProducto>();
    #endregion Public Members

    #region Private Members
    private static readonly ILog logger = LogManager.GetLogger(typeof(EtiquetasManagerEx));
    private float mFactorCorreccion = 1.0f;
    private const string mBackGroundBulto = "bulto.jpg"; //"bulto.png";
    private const string mBackGroundProducto = "producto.jpg"; //"producto.png";
    private string mBackGroundFalla = "producto_falla.jpg"; //"producto.png";


    private string mBackGroundBulto_tempstar = "bulto_tempstar.jpg"; //"bulto.png";
    private string mBackGroundProducto_tempstar = "producto_tempstar.jpg"; //"producto.png";
    private string mBackGroundBulto_confortmaker = "bulto_confortmaker.jpg"; //"bulto.png";
    private string mBackGroundProducto_confortmaker = "producto_confortmaker.jpg"; //"producto.png";
    private string mBackGroundBulto_springer = "bulto_springer.jpg"; //"bulto.png";
    private string mBackGroundProducto_springer = "producto_springer.jpg"; //"producto.png";

    private string mBackGroundBulto_carrier = "bulto_carrier.jpg"; //"bulto.png";
    private string mBackGroundProducto_carrier = "producto_carrier.jpg"; //"producto.png";

    private string mBackGroundBulto_icp = "bulto_icp.jpg"; //"bulto.png";
    private string mBackGroundProducto_icp = "producto_icp.jpg"; //"producto.png";

    private string mBackGroundBulto_toshiba= "bulto_toshiba.jpg";
    private string mBackGroundProducto_toshiba= "producto_toshiba.jpg";

    private string mBackGroundBulto_pria = "bulto_pria.jpg";
    private string mBackGroundProducto_pria = "producto_pria.jpg"; 
    
    private string mBackGroundProducto_pria_eco = "producto_pria_eco.jpg"; 
    
    #endregion Private Members

    #region Const
    public const string pathBULTO_IDU = "BULTO_IDU.txt";
    public const string pathBULTO_ODU = "BULTO_ODU.txt";
    public const string pathBULTO_POSIC = "BULTO_POSIC.txt";
    public const string pathPRODUCTO_IDU = "PRODUCTO_IDU.txt";
    public const string pathPRODUCTO_ODU = "PRODUCTO_ODU.txt";
    public const string pathPRODUCTO_POSIC = "PRODUCTO_POSIC.txt";
    public const string pathFALLA_PRODUCTO_POSIC = "FALLA_PRODUCTO_POSIC.txt";
    #endregion Const

    #region load Functions
    public EtiquetasManagerEx()
    {
      loadFormatos(false);
    }

    public EtiquetasManagerEx(bool EsIdu)
    {
      loadFormatos(EsIdu);
    }
    public void loadFormatos(bool EsIdu)
    {
      string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
      FileInfo o = new FileInfo(path);
      string file = o.Directory + "\\";

      using (StreamReader sr = new StreamReader(file + pathBULTO_POSIC))
      {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (!line.StartsWith("--"))
            lines.Add(line);
        }
        mPosicEtiquetaBulto = new PosicEtiquetaBulto(lines.ToArray());
      }

      using (StreamReader sr = new StreamReader(file + pathPRODUCTO_POSIC))
      {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (!line.StartsWith("--"))
            lines.Add(line);
        }
        mPosicEtiquetaProducto = new PosicEtiquetaProducto(lines.ToArray());
      }

      using (StreamReader sr = new StreamReader(file + pathFALLA_PRODUCTO_POSIC))
      {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (!line.StartsWith("--"))
            lines.Add(line);
        }
        mPosicEtiquetaFalla = new PosicEtiquetaProducto(lines.ToArray());
      }

      string mModelosDeProductos = file + pathPRODUCTO_IDU;
      string mModelosDeBultos = file + pathBULTO_IDU;

      if (!EsIdu)
      {
        mModelosDeProductos = file + pathPRODUCTO_ODU;
        mModelosDeBultos = file + pathBULTO_ODU;
      }

      using (StreamReader sr = new StreamReader(mModelosDeProductos))
      {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (!line.StartsWith("--"))
            mEtiquetaProductoList.Add(new EtiquetaProducto(line));
        }

      }

      using (StreamReader sr = new StreamReader(mModelosDeBultos))
      {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        List<string> lines = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
          if (!line.StartsWith("--"))
            mEtiquetaBultoList.Add(new EtiquetaBulto(line));
        }

      }
    }
    #endregion load Functions

    public List<IEtiqueta> getFormatos()
    {
      List<IEtiqueta> formatos = new List<IEtiqueta>();
      foreach (EtiquetaBulto o in mEtiquetaBultoList)
        formatos.Add(o);
      foreach (EtiquetaProducto o in mEtiquetaProductoList)
        formatos.Add(o);
      return formatos;
    }

    public Bitmap GenerarBitmapDeEtiquetaFalla(Modelo modelo
      , string EtiquetaModelo
      , Ensayos ens
      , string argFallaDesc)
    {

      EtiquetaProducto mEtiquetaProducto = getEtiquetaProducto(EtiquetaModelo);

      Bitmap MapaDeImagen = new Bitmap(getBackGroundFilePath(this.mBackGroundFalla));
      //MapaDeImagen.PixelFormat
      MapaDeImagen.SetResolution(300, 300);

      using (Graphics gr = Graphics.FromImage(MapaDeImagen))
      {
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //DibujarBackGround(gr, this.mBackGroundProducto);

        DibujarString(gr, mEtiquetaProducto.Conjunto, mPosicEtiquetaFalla.Conjunto_Posic);
        DibujarString(gr, mEtiquetaProducto.Modelo, mPosicEtiquetaFalla.Modelo_Posic);
        string valor = mEtiquetaProducto.NroSerie;
        if (ens != null && ens.Serie != null)
          valor = ens.Serie;

        DibujarString(gr, valor, mPosicEtiquetaFalla.NroSerie_Posic);


        DibujarString(gr, ens.Fecha.ToString("dd-MM-yyyy"), mPosicEtiquetaFalla.Volts_Posic);
        DibujarString(gr, ens.Codigo, mPosicEtiquetaFalla.Hz_Posic);
        if (argFallaDesc.Trim().Length > 30)
        {
          DibujarString(gr, argFallaDesc.Substring(0, 30), mPosicEtiquetaFalla.Potencia_Maxima_Posic);
          DibujarString(gr, argFallaDesc.Substring(30, argFallaDesc.Length - 30), mPosicEtiquetaFalla.Corriente_Maxima_Posic);
        }

      }
      return MapaDeImagen;
      //UNDO
      //return EtiquetasManagerEx.EscalarProducto(MapaDeImagen);
    }

    public Bitmap GenerarBitmapDeEtiqueta(Modelo modelo
      , EtiquetaProducto mEtiquetaProducto
      , Ensayos ens)
    {
      //Bitmap MapaDeImagen = new Bitmap(1230, 2310,System.Drawing.Imaging.PixelFormat.);

      
      string datillo = getBackGroundFilePath(EtiquetasManagerEx.mBackGroundProducto, modelo);
      
      logger.DebugFormat("EtiquetasManagerEx::GenerarBitmapDeEtiqueta mBackGroundProducto:'{0}'", datillo); 
      
      Bitmap MapaDeImagen = new Bitmap(datillo);
      MapaDeImagen.SetResolution(300, 300);
      
      using (Graphics gr = Graphics.FromImage(MapaDeImagen))
      {
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //DibujarBackGround(gr, this.mBackGroundProducto);

        DibujarString(gr, mEtiquetaProducto.Capacidad_Calor, mPosicEtiquetaProducto.Capacidad_Calor_Posic);
        DibujarString(gr, mEtiquetaProducto.Capacidad_Frio, mPosicEtiquetaProducto.Capacidad_Frio_Posic);
        DibujarString(gr, mEtiquetaProducto.Conjunto, mPosicEtiquetaProducto.Conjunto_Posic);
        DibujarString(gr, mEtiquetaProducto.Corriente_Calor, mPosicEtiquetaProducto.Corriente_Calor_Posic);
        DibujarString(gr, mEtiquetaProducto.Corriente_Frio, mPosicEtiquetaProducto.Corriente_Frio_Posic);
        DibujarString(gr, mEtiquetaProducto.Corriente_Maxima, mPosicEtiquetaProducto.Corriente_Maxima_Posic);
        DibujarString(gr, mEtiquetaProducto.Grado_Proteccion, mPosicEtiquetaProducto.Grado_Proteccion_Posic);
        DibujarString(gr, mEtiquetaProducto.Hz, mPosicEtiquetaProducto.Hz_Posic);
        DibujarString(gr, mEtiquetaProducto.Modelo, mPosicEtiquetaProducto.Modelo_Posic);
        string valor = mEtiquetaProducto.NroSerie;
        if (ens != null)
          valor = ens.Serie;
        DibujarString(gr, valor, mPosicEtiquetaProducto.NroSerie_Posic);
        DibujarString(gr, mEtiquetaProducto.Peso, mPosicEtiquetaProducto.Peso_Posic);
        DibujarString(gr, mEtiquetaProducto.Potencia_Calor, mPosicEtiquetaProducto.Potencia_Calor_Posic);
        DibujarString(gr, mEtiquetaProducto.Potencia_Frio, mPosicEtiquetaProducto.Potencia_Frio_Posic);
        DibujarString(gr, mEtiquetaProducto.Potencia_Maxima, mPosicEtiquetaProducto.Potencia_Maxima_Posic);
        DibujarString(gr, mEtiquetaProducto.Presion_Alta, mPosicEtiquetaProducto.Presion_Posic);
        //DibujarString(gr, mEtiquetaProducto.Presion_Baja, mPosicEtiquetaProducto.Presion_Baja_Posic);
        DibujarString(gr, mEtiquetaProducto.R22, mPosicEtiquetaProducto.R22_Posic);
        DibujarString(gr, mEtiquetaProducto.Volts, mPosicEtiquetaProducto.Volts_Posic);

        if (!string.IsNullOrEmpty(mEtiquetaProducto.CodigoAAE))
        {
          //DibujarString(gr, mPosicEtiquetaBulto.FixAAE.FixedText, mPosicEtiquetaBulto.FixAAE);
          DibujarString(gr, mEtiquetaProducto.CodigoAAE, mPosicEtiquetaProducto.AAECode_Posic);
        }

      }
      return MapaDeImagen;
      //UNDO
      //return EtiquetasManagerEx.EscalarProducto(MapaDeImagen);
    }

    public string EAN13(string chaine)
    {
      //V 1.0
      //Paramètres : une chaine de 12 chiffres
      //Parameters : a 12 digits length string
      //Retour : * une chaine qui, affichée avec la police EAN13.TTF, donne le code barre
      //         * une chaine vide si paramètre fourni incorrect
      //Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
      //         * an empty string if the supplied parameter is no good
      int i;
      int first;
      int checksum = 0;
      string CodeBarre = "";
      bool tableA;

      //Vérifier qu'il y a 12 caractères
      //Check for 12 characters
      //Et que ce sont bien des chiffres
      //And they are really digits
      if (System.Text.RegularExpressions.Regex.IsMatch(chaine, "^\\d{12}$"))
      {
        // Calcul de la clé de contrôle
        // Calculation of the checksum
        for (i = 1; i < 12; i += 2)
        {
          System.Diagnostics.Debug.WriteLine(chaine.Substring(i, 1));
          checksum += Convert.ToInt32(chaine.Substring(i, 1));
        }
        checksum *= 3;
        for (i = 0; i < 12; i += 2)
        {
          checksum += Convert.ToInt32(chaine.Substring(i, 1));
        }

        chaine += (10 - checksum % 10) % 10;
        //Le premier chiffre est pris tel quel, le deuxième vient de la table A
        //The first digit is taken just as it is, the second one come from table A
        CodeBarre = chaine.Substring(0, 1) + (char)(65 + Convert.ToInt32(chaine.Substring(1, 1)));
        first = Convert.ToInt32(chaine.Substring(0, 1));
        for (i = 2; i <= 6; i++)
        {
          tableA = false;
          switch (i)
          {
            case 2:
              if (first >= 0 && first <= 3) tableA = true;
              break;
            case 3:
              if (first == 0 || first == 4 || first == 7 || first == 8) tableA = true;
              break;
            case 4:
              if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) tableA = true;
              break;
            case 5:
              if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) tableA = true;
              break;
            case 6:
              if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) tableA = true;
              break;
          }

          if (tableA)
            CodeBarre += (char)(65 + Convert.ToInt32(chaine.Substring(i, 1)));
          else
            CodeBarre += (char)(75 + Convert.ToInt32(chaine.Substring(i, 1)));
        }
        CodeBarre += "*"; //Ajout séparateur central / Add middle separator

        for (i = 7; i <= 12; i++)
        {
          CodeBarre += (char)(97 + Convert.ToInt32(chaine.Substring(i, 1)));
        }
        CodeBarre += "+"; //Ajout de la marque de fin / Add end mark
      }
      return CodeBarre;
    }

    public Bitmap GenerarBitmapDeEtiqueta(Modelo modelo
      , EtiquetaBulto mEtiquetaBulto
      , Ensayos ens)
    {

      string datillo = getBackGroundFilePath(EtiquetasManagerEx.mBackGroundBulto, modelo);

      logger.DebugFormat("EtiquetasManagerEx::GenerarBitmapDeEtiqueta mBackGroundBulto:'{0}'", datillo);

      
      Bitmap MapaDeImagen = new Bitmap(datillo);
      
      MapaDeImagen.SetResolution(300, 300);

      using (Graphics gr = Graphics.FromImage(MapaDeImagen))
      {
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //DibujarBackGround(gr, this.mBackGroundBulto);

        DibujarString(gr, mEtiquetaBulto.Alto, mPosicEtiquetaBulto.Alto_Posic);
        DibujarString(gr, mEtiquetaBulto.Ancho, mPosicEtiquetaBulto.Ancho_Posic);
        DibujarString(gr, mEtiquetaBulto.Capacidad, mPosicEtiquetaBulto.Capacidad_Posic);
        DibujarString(gr, mEtiquetaBulto.CapacidadKcal, mPosicEtiquetaBulto.CapacidadKcal_Posic, mEtiquetaBulto.ForeColor);
        DibujarString(gr, mEtiquetaBulto.Codigo_Conjunto, mPosicEtiquetaBulto.Codigo_Conjunto_Posic);
        bool eanFound = DibujarImagen(gr, mEtiquetaBulto.Codigo_EAN, mPosicEtiquetaBulto.Codigo_EAN_Posic);
        if(!eanFound )
        {
          //DibujarString(gr, EAN13(mEtiquetaBulto.getCodigoEanLimitesByAsterisk()), mPosicEtiquetaBulto.Codigo_EAN_Posic, "Code EAN13");          
          //PosicElement mPosicElementBarCode = (PosicElement)mPosicEtiquetaBulto.Codigo_EAN_Posic.Clone();
          //mPosicElementBarCode.X_INI = Convert.ToDouble(mPosicEtiquetaBulto.Codigo_EAN_Posic.X_INI);
          //mPosicElementBarCode.Font_Size = 30;
          //mPosicElementBarCode.Font_Family="Code EAN13";
          DibujarString(gr, EAN13(mEtiquetaBulto.getCodigoEanLimitesByAsterisk()), mPosicEtiquetaBulto.EANBarCode, "0");          
        }
        //DibujarString(gr, mEtiquetaBulto.Modelo, mPosicEtiquetaBulto.Modelo_Posic);
        DibujarString(gr, "*" + mEtiquetaBulto.Modelo + "*", mPosicEtiquetaBulto.Modelo_Peq_Posic);
        DibujarString(gr, mEtiquetaBulto.Modo, mPosicEtiquetaBulto.Modo_Posic, mEtiquetaBulto.ForeColor);
        DibujarString(gr, mEtiquetaBulto.Modo, mPosicEtiquetaBulto.ModoPeq_Posic);

        if (!string.IsNullOrEmpty(mEtiquetaBulto.Codigo_AAE))
        {
          DibujarString(gr, mPosicEtiquetaBulto.FixAAE.FixedText , mPosicEtiquetaBulto.FixAAE );
          DibujarString(gr, mEtiquetaBulto.Codigo_AAE, mPosicEtiquetaBulto.CodigoAAE);
        }
        
        if(mEtiquetaBulto.HasPosic)
        {
          PosicElement mPosicElement = (PosicElement)mPosicEtiquetaBulto.CodConjuntoBarcode.Clone();
          mPosicElement.X_INI = Convert.ToDouble(mEtiquetaBulto.Posic_CodigoBarraConjunto_X);
          mPosicElement.Font_Size= Convert.ToDouble(mEtiquetaBulto.Posic_CodigoBarraConjunto_FONT_SIZE );
          DibujarString(gr, mEtiquetaBulto.getCodigoConjuntoLimitesByAsterisk(), mPosicElement, "0"); //Free 3 of 9 Extended

          PosicElement mPosicElement2 = (PosicElement)mPosicEtiquetaBulto.Modelo_Posic.Clone();
          mPosicElement2.X_INI = Convert.ToDouble(mEtiquetaBulto.Posic_Modelo_X );
          mPosicElement2.Font_Size = Convert.ToDouble(mEtiquetaBulto.Posic_Modelo_FONT_SIZE);
          DibujarString(gr, mEtiquetaBulto.Modelo, mPosicElement2);
        }
        else
        {
          DibujarString(gr, mEtiquetaBulto.getCodigoModeloLimitesByAsterisk(), mPosicEtiquetaBulto.CodConjuntoBarcode, "Free 3 of 9 Extended");
            DibujarString(gr, mEtiquetaBulto.Modelo, mPosicEtiquetaBulto.Modelo_Posic);
        
        }
        string valor = mEtiquetaBulto.NroSerie;
        if (ens != null)
          valor = ens.Serie;

        DibujarString(gr, valor, mPosicEtiquetaBulto.NroSerie_Posic);
        
        //New Código de barras de Nro de Serie.
        DibujarString(gr, "*" + valor + "*", mPosicEtiquetaBulto.NroSerie_BarCode);
        DibujarString(gr, "*" + valor + "*", mPosicEtiquetaBulto.NroSerie_Small);

        DibujarString(gr, mEtiquetaBulto.Peso, mPosicEtiquetaBulto.Peso_Posic);
        DibujarString(gr, mEtiquetaBulto.Profundidad, mPosicEtiquetaBulto.Profundidad_Posic);


        //Textos Fijos
        DibujarString(gr, mPosicEtiquetaBulto.FixArgentina.FixedText, mPosicEtiquetaBulto.FixArgentina);
        DibujarString(gr, mPosicEtiquetaBulto.FixAvenida.FixedText, mPosicEtiquetaBulto.FixAvenida);
        DibujarString(gr, mPosicEtiquetaBulto.FixCarrier.FixedText, mPosicEtiquetaBulto.FixCarrier);
        DibujarString(gr, mPosicEtiquetaBulto.FixCodigoEAN.FixedText, mPosicEtiquetaBulto.FixCodigoEAN);
        DibujarString(gr, mPosicEtiquetaBulto.FixConjunto.FixedText, mPosicEtiquetaBulto.FixConjunto);
        DibujarString(gr, mPosicEtiquetaBulto.FixDistribuye.FixedText, mPosicEtiquetaBulto.FixDistribuye);
        DibujarString(gr, mPosicEtiquetaBulto.FixFabricado.FixedText, mPosicEtiquetaBulto.FixFabricado);
        DibujarString(gr, mPosicEtiquetaBulto.FixNroSerie.FixedText, mPosicEtiquetaBulto.FixNroSerie);
        DibujarString(gr, mPosicEtiquetaBulto.FixIndArg.FixedText, mPosicEtiquetaBulto.FixIndArg);
        DibujarString(gr, mPosicEtiquetaBulto.FixCapacidadKcal.FixedText, mPosicEtiquetaBulto.FixCapacidadKcal, mEtiquetaBulto.ForeColor);
        DibujarString(gr, mPosicEtiquetaBulto.FixVolt.FixedText, mPosicEtiquetaBulto.FixVolt);
      }
      return MapaDeImagen;
      //UNDO
      //return EtiquetasManagerEx.EscalarBulto( MapaDeImagen);
    }

    public Bitmap GenerarBitmapDeEtiqueta(Modelo modelo
      , string EtiquetaModelo
      , Ensayos ens)
    {

      List<IEtiqueta> etiquetas = this.getFormatos();

      IEtiqueta oIEtiqueta = null;
      foreach (IEtiqueta oIEtiquetaItem in etiquetas)
      {
        if (oIEtiquetaItem.GetCodigo.Trim().Equals(EtiquetaModelo))
        {
          oIEtiqueta = oIEtiquetaItem;
          break;
        }
      }

      if (oIEtiqueta == null)
        return DibujarGrilla();

      if (typeof(EtiquetaProducto).Equals(oIEtiqueta.GetType()))
      {
        EtiquetaProducto oEtiquetaProducto = oIEtiqueta as EtiquetaProducto;
        return this.GenerarBitmapDeEtiqueta(
          modelo
          , oEtiquetaProducto
          , ens);
      }
      else
      {
        EtiquetaBulto oEtiquetaBulto = oIEtiqueta as EtiquetaBulto;
        return this.GenerarBitmapDeEtiqueta(
            modelo
            , oEtiquetaBulto
            , ens);
      }
    }

    private EtiquetaProducto getEtiquetaProducto(string EtiquetaModelo)
    {

      List<IEtiqueta> etiquetas = this.getFormatos();

      IEtiqueta oIEtiqueta = null;
      foreach (IEtiqueta oIEtiquetaItem in etiquetas)
      {
        if (oIEtiquetaItem.GetCodigo.Trim().Equals(EtiquetaModelo))
        {
          oIEtiqueta = oIEtiquetaItem;
          break;
        }
      }

      return oIEtiqueta as EtiquetaProducto;
    }

    #region Funciones de Dibujo de elementos(string, bmp y line) en Lienzo.

    private string getBackGroundFilePath(string fileName)
    {
      string skey = "DIRECTORIO_IMAGENES_EXTRAS";

      string file = ConfigurationManager.AppSettings[skey] + fileName;

      //Corroboramos la direccion de la imagen.
      if (!File.Exists(file))
      {
        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        FileInfo o = new FileInfo(path);
        file = o.Directory + file;
        
        if (!File.Exists(file))
        {
          //No se encontro el path de la imagen.
          return "";
        }
      }
      return file;
    }

    private string getBackGroundFilePath(string ConstBackGroundType, Modelo modelo)
    {
      string file = ConstBackGroundType;
      string logo = modelo.Logo.Trim().ToUpper();
      switch (ConstBackGroundType)
      {
        case EtiquetasManagerEx.mBackGroundBulto:
          if (modelo.Marca.Trim().StartsWith("PRIA"))
            file = this.mBackGroundBulto_pria;
          else
            if (logo.StartsWith("SUR"))
              file = EtiquetasManagerEx.mBackGroundBulto;
            else
              if (logo.StartsWith("TEMP"))
                file = this.mBackGroundBulto_tempstar;
              else
                if (logo.StartsWith("CONF"))
                  file = this.mBackGroundBulto_confortmaker;
                else
                  if (logo.StartsWith("SPR"))
                    file = this.mBackGroundBulto_springer;
                  else
                    if (logo.StartsWith("CAR"))
                      file = this.mBackGroundBulto_carrier;
                    else
                      if (logo.StartsWith("ICP"))
                        file = this.mBackGroundBulto_icp;
                      else
                        if(logo.StartsWith("TOSHI"))
                          file = this.mBackGroundBulto_toshiba;
                        //else
                        //  if (logo.StartsWith("PRIA"))
                        //    file = this.mBackGroundBulto_pria; 
                      
          break;
        case EtiquetasManagerEx.mBackGroundProducto:
          if (modelo.Marca.Trim().StartsWith("PRIA ECO"))
            file = this.mBackGroundProducto_pria_eco; 
            else
            if (modelo.Marca.Trim().StartsWith("PRIA"))
            file = this.mBackGroundProducto_pria; 
            else
            if (logo.StartsWith("SUR"))
              file = EtiquetasManagerEx.mBackGroundProducto;
            else
              if (logo.StartsWith("TEMP"))
                file = this.mBackGroundProducto_tempstar;
              else
                if (logo.StartsWith("CONF"))
                  file = this.mBackGroundProducto_confortmaker;
                else
                  if (logo.StartsWith("SPR"))
                    file = this.mBackGroundProducto_springer;
                  else
                    if (logo.StartsWith("CAR"))
                      file = this.mBackGroundProducto_carrier;
                    else
                      if (logo.StartsWith("ICP"))
                        file = this.mBackGroundProducto_icp;
                      else
                        if (logo.StartsWith("TOSHI"))
                          file = this.mBackGroundProducto_toshiba;
                        //else
                        //  if (logo.StartsWith("PRIA"))
                        //    file = this.mBackGroundProducto_pria;
          file = "square-corner_"+file;
          break;

      }

      return getBackGroundFilePath(file);
    }

    private void DibujarBackGround(Graphics gr, string FileName)
    {
      string file = getBackGroundFilePath(FileName);

      System.Drawing.Image imagen = System.Drawing.Image.FromFile(file);
      //UNDO
      gr.DrawImage(imagen,
        (float)0
        , (float)0
        , (float)imagen.Width / mFactorCorreccion
        , (float)imagen.Height / mFactorCorreccion
        );
      //gr.DrawImage(imagen,
      // (float)0
      // , (float)0
      // , (float)imagen.Width
      // , (float)imagen.Height);
    }

    private void DibujarString(Graphics gr, string mValor, PosicElement mPosicElement)
    {
      DibujarString(gr, mValor, mPosicElement, "0");
    }
    private void DibujarString(Graphics gr, string mValor, PosicElement mPosicElement, string isWhite)
    {
      System.Drawing.Color mForeColor = System.Drawing.Color.Black;
      if (isWhite == "1")
        mForeColor = System.Drawing.Color.White;
      using (SolidBrush brocha = new SolidBrush(mForeColor))
      {
        System.Drawing.FontStyle estilo = new System.Drawing.FontStyle();

        if (mPosicElement.Font_Bold == "1")
          estilo = System.Drawing.FontStyle.Bold;
        else
          estilo = System.Drawing.FontStyle.Regular;

        using (Font fuente = new Font(mPosicElement.Font_Family
                      , (float)mPosicElement.Font_Size
                      , estilo))
          gr.DrawString(mValor
            , fuente
            , brocha
            , (float)mPosicElement.X_INI / mFactorCorreccion
            , (float)mPosicElement.Y_INI / mFactorCorreccion
            );
      }
    }

    private bool DibujarImagen(Graphics gr, string mValor, PosicElement mPosicElement)
    {
      string skey = "DIRECTORIO_IMAGENES_EAN13";

      mValor = mValor.Trim().ToLower().Replace(".wmf", ".jpg");
      string file = ConfigurationManager.AppSettings[skey] + mValor.Trim();

      //Corroboramos la direccion de la imagen.
      if (!File.Exists(file))
      {
        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        FileInfo o = new FileInfo(path);
        file = o.Directory + file;

        if (!File.Exists(file))
        {
          //No se encontro el path de la imagen.
          return false;
        }
      }

      //System.Drawing.Image imagen = System.Drawing.Image.FromFile(file);
      System.Drawing.Bitmap imagen = new Bitmap(file);
      imagen.SetResolution(300, 300);

      ANCHO_COD_EAN = Convert.ToInt32(ConfigurationManager.AppSettings["ANCHO_COD_EAN"]);

      gr.DrawImage(imagen,
      (float)mPosicElement.X_INI / mFactorCorreccion
      , (float)mPosicElement.Y_INI / mFactorCorreccion
      , (float)ANCHO_COD_EAN
      , (float)imagen.Height * ANCHO_COD_EAN / (float)imagen.Width);

      //gr.DrawImage(imagen,
      // (float)mPosicElement.X_INI / mFactorCorreccion
      // , (float)mPosicElement.Y_INI / mFactorCorreccion
      // , (float)mPosicElement.X_FIN / mFactorCorreccion - (float)mPosicElement.X_INI / mFactorCorreccion
      // , (float)mPosicElement.Y_FIN / mFactorCorreccion - (float)mPosicElement.Y_INI / mFactorCorreccion);


      return true;
    }

    #endregion Funciones de Dibujo de elementos(string, bmp y line) en Lienzo.

    #region Funciones GDI32
    [DllImport("gdi32")]
    static extern int DeleteObject(IntPtr o);
    public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
    {
      IntPtr ip = source.GetHbitmap();
      BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty,
      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
      DeleteObject(ip);
      return bs;
    }
    #endregion Funciones GDI32

    #region Funciones Helper
    public Bitmap DibujarGrilla()
    {
      Bitmap MapaDeImagen = new Bitmap(1000, 1000);

      Graphics g = Graphics.FromImage(MapaDeImagen);
      System.Drawing.Pen Lapiz = new System.Drawing.Pen(System.Drawing.Color.Gray);


      //g.DrawLine(Lapiz, 0 + i, 0 + i, MapaDeImagen.Width, MapaDeImagen.Height);

      //dibujar lineas horizontales
      //UNDO
      for (int i = 0; i < MapaDeImagen.Height; i += 38)
      {

        g.DrawLine(Lapiz, 0, i, MapaDeImagen.Width, i);


      }

      //dibujar lineas verticales
      for (int i = 0; i < MapaDeImagen.Width; i += 38)
      {

        g.DrawLine(Lapiz, i, 0, i, MapaDeImagen.Height);


      }

      return MapaDeImagen;
    }
    #endregion Funciones Helper

    #region Funciones de Escalado

    static int ANCHO_PRODUCTO = 190;
    static int ALTO_PRODUCTO = 380;
    static int ANCHO_BULTO = 570;
    static int ALTO_BULTO = 380;

    public static Bitmap EscalarProducto(Bitmap Bitmap)
    {
      ANCHO_PRODUCTO = Convert.ToInt32(ConfigurationManager.AppSettings["ANCHO_PRODUCTO"]);
      ALTO_PRODUCTO = Convert.ToInt32(ConfigurationManager.AppSettings["ALTO_PRODUCTO"]);
      return Escalar(Bitmap
        , ANCHO_PRODUCTO
        , ALTO_PRODUCTO);

    }
    public static Bitmap EscalarBulto(Bitmap Bitmap)
    {
      ANCHO_BULTO = Convert.ToInt32(ConfigurationManager.AppSettings["ANCHO_BULTO"]);
      ALTO_BULTO = Convert.ToInt32(ConfigurationManager.AppSettings["ALTO_BULTO"]);
      return Escalar(Bitmap, ANCHO_BULTO, ALTO_BULTO);
    }

    public static Bitmap Escalar(Bitmap Bitmap, int ancho, int alto)
    {
      int nuevoAncho = ancho;
      int nuevoAlto = alto;
      Bitmap scaledBitmap = new Bitmap(nuevoAncho, nuevoAlto);

      // Scale the bitmap in high quality mode.
      using (Graphics gr = Graphics.FromImage(scaledBitmap))
      {
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
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

    #region impresion

    //public void ImprimirImagen(System.Drawing.Image imagen, string Impresora)
    //{
    //  string sImageDir = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGEN_TEMP"];
    //  string sImageName = sImageDir + DateTime.Now.Ticks.ToString() + "_Etiqueta.jpg";

    //  if (File.Exists(sImageName))
    //    File.Delete(sImageName);
    //  if (!Directory.Exists(sImageDir))
    //    Directory.CreateDirectory(sImageDir);

    //  imagen.Save(sImageName);
    //  PrintDocument printDoc = new PrintDocument();

    //  m_current_image_file = sImageName;
    //  printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
    //  printDoc.PrinterSettings.PrinterName = Impresora;

    //  if (printDoc.PrinterSettings.IsValid)
    //    printDoc.Print();
    //}

    string m_current_image_file = string.Empty;

    void printDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
      System.Drawing.Point ulCorner = new System.Drawing.Point(0, 0);
      //System.Drawing.Image photo = System.Drawing.Image.FromFile(m_current_image_file);
      //e.Graphics.DrawImage(photo, ulCorner);

      Bitmap oBitmap = new Bitmap(m_current_image_file);
      //if (bImprimiendoBulto)
      //  oBitmap.SetResolution(315.0f, 315.0f);
      //else
      //  oBitmap.SetResolution(610.0f, 610.0f);

      if (bImprimiendoBulto)
        oBitmap.SetResolution(DPI_BULTO, DPI_BULTO);
      else
        oBitmap.SetResolution(DPI_PRODUCTO, DPI_PRODUCTO);


      // Como para probar.
      //e.HasMorePages = false;
      //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      //e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
      //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
      //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

      if (bImprimiendoBulto)
        e.Graphics.DrawImage(oBitmap
          , LEFT_BULTO
          , TOP_BULTO);
      else
        e.Graphics.DrawImage(oBitmap
          , LEFT_PRODUCTO
          , TOP_PRODUCTO);
    }

    int TOP_PRODUCTO = 0;
    int LEFT_PRODUCTO = 0;
    int TOP_BULTO = 0;
    int LEFT_BULTO = 0;

    int ANCHO_COD_EAN = 470;

    float DPI_PRODUCTO = 300;
    float DPI_BULTO = 300;

    bool bImprimiendoBulto = false;
    public void ImprimirImagen(Bitmap OBitmap, string Impresora, bool EsBulto)
    {
      ImprimirImagen(OBitmap, Impresora, EsBulto, "");
    }

    public void ImprimirImagen(Bitmap OBitmap, string Impresora, bool EsBulto, string nameDesc)
    {
      bImprimiendoBulto = EsBulto;

      TOP_PRODUCTO = Convert.ToInt32(ConfigurationManager.AppSettings["TOP_PRODUCTO"]);
      LEFT_PRODUCTO = Convert.ToInt32(ConfigurationManager.AppSettings["LEFT_PRODUCTO"]);
      TOP_BULTO = Convert.ToInt32(ConfigurationManager.AppSettings["TOP_BULTO"]);
      LEFT_BULTO = Convert.ToInt32(ConfigurationManager.AppSettings["LEFT_BULTO"]);
      DPI_PRODUCTO = (float)Convert.ToDouble(ConfigurationManager.AppSettings["DPI_PRODUCTO"]);
      DPI_BULTO = (float)Convert.ToDouble(ConfigurationManager.AppSettings["DPI_BULTO"]);

      string sImageDir = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGEN_TEMP"];
      //string sImageName = sImageDir + DateTime.Now.Ticks.ToString() + "_Etiqueta.jpg";
      string sImageName = sImageDir + DateTime.Now.Ticks.ToString() + "_" + nameDesc + "_" + (EsBulto ? "bulto" : "producto") + "_Etiqueta.jpg";
      
      logger.DebugFormat("EtiquetasManagerEx::ImprimirImagen DIR:'{0}', FILE:'{1}'", sImageDir, sImageName);
      
      if (File.Exists(sImageName))
        File.Delete(sImageName);
      if (!Directory.Exists(sImageDir))
        Directory.CreateDirectory(sImageDir);

      GuardarJpg(OBitmap, sImageName);
      //OBitmap.SetResolution(300.0f, 300.0f);
      //OBitmap.Save(sImageName
      //    , System.Drawing.Imaging.ImageFormat.Png);

      PrintDocument printDoc = new PrintDocument();

      m_current_image_file = sImageName;
      printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
      printDoc.PrinterSettings.PrinterName = Impresora;

      if (printDoc.PrinterSettings.IsValid)
        printDoc.Print();
    }

    //public static void GuardarPng(Bitmap OBitmap, string Archivo) 
    //{
    //  OBitmap.SetResolution(300.0f, 300.0f);
    //  OBitmap.Save(Archivo 
    //    , System.Drawing.Imaging.ImageFormat.Png);
    //}

    public static void GuardarJpg(Bitmap OBitmap, string Archivo)
    {
      OBitmap.SetResolution(300.0f, 300.0f);
      OBitmap.Save(Archivo
        , System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    #endregion  impresion
  }
}
