
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

using System.Configuration;
using System.IO;
using System.Net;
using System.Windows;
namespace WPFiDU.Etiquetas
{
  class EtiquetasManagerEx
  {
    private float mFactorCorreccion = 1.0f;
    

    #region impresion

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
    public int TOP_BULTO = 0;
    public int LEFT_BULTO = 0;

    int ANCHO_COD_EAN = 470;

    float DPI_PRODUCTO = 300;
    float DPI_BULTO = 300;

    bool bImprimiendoBulto = false;
    public void ImprimirImagen(string filenameOBitmap, string Impresora, bool EsBulto)
    {
      bImprimiendoBulto = EsBulto;


      if (!File.Exists(filenameOBitmap))
        return;
      
      PrintDocument printDoc = new PrintDocument();

      m_current_image_file = filenameOBitmap;
      printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
      printDoc.PrinterSettings.PrinterName = Impresora;

      if (printDoc.PrinterSettings.IsValid)
        printDoc.Print();
    }

    
    #endregion  impresion
  }
}