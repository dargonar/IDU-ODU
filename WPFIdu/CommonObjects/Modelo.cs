using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class Modelo
    {
      private int mID;
      
      
      public int  ID
      {
          get { return mID; }
          set { mID = value; }
      }

      private string  mMarca;
      public string Marca
      {
          get { return mMarca; }
          set { mMarca = value; }
      }
      
      private string mNombremodelo;

      public string Nombremodelo
      {
          get { return mNombremodelo; }
          set { mNombremodelo = value; }
      }
  
      private string mBackgroundBulto;

      public string BackgroundBulto
      {
        get { return mBackgroundBulto; }
        set { mBackgroundBulto = value; }
      }

      private string mBackgroundProducto;

      public string BackgroundProducto
      {
        get { return mBackgroundProducto; }
        set { mBackgroundProducto = value; }
      }

      private string mReferencia;

      public string Referencia
      {

          get { return mReferencia; }
          set { mReferencia = value; }
      }
      
      private string mEan13;

      public string Ean13
      {
          get { return mEan13; }
          set { mEan13 = value; }
      }
      
      private int mEtiqueta;

      public int Etiqueta
      {
          get { return mEtiqueta; }
          set { mEtiqueta = value; }
      }
      
      private int mEtiquetaCaja;

      public int EtiquetaCaja
      {
          get { return mEtiquetaCaja; }
          set { mEtiquetaCaja = value; }
      }
      
      private string mLogo;

      public string Logo
      {
          get { return mLogo; }
          set { mLogo = value; }
      }
          
      private string mConjunto;

      public string Conjunto
      {
          get { return mConjunto; }
          set { mConjunto = value; }
      }

          
      private string mCapacidad;
      
      public string Capacidad
      {
          get { return mCapacidad; }
          set { mCapacidad = value; }
      }
  
      private string mCodigo;
      
      public string Codigo
      {
          get { return mCodigo; }
          set { mCodigo = value; }
      }
 
      private string mDescripcion;

      public string Descripcion
      {
          get { return mDescripcion; }
          set { mDescripcion = value; }
      }
          
      private string mDimension;

      public string Dimension
      {
          get { return mDimension; }
          set { mDimension = value; }
      }
          
      private bool mEsIdu;

      public bool EsIdu
      {
          get { return mEsIdu; }
          set { mEsIdu = value; }
      }

  private string mCodigoICSA;
     
      public string CodigoICSA
      {
          get{return mCodigoICSA;}
          set{mCodigoICSA=value;}
      }


    public override string ToString()
    {
        return mNombremodelo;
    }

    public string ReferenciaDescripcion 
    {
      get
      {
        return string.Format("{0} - {1}"
          , Referencia
          , Descripcion);
      }
    } 
    }

    public class ModeloExt : Modelo 
    {
      public override string ToString()
      {
        return string.Format("{0} - {1}"
          , Referencia 
          ,Descripcion);
      }
    }
}
