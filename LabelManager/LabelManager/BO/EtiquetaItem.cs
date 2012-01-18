using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace iDU.CommonObjects
{
    [Serializable]
    
    public class EtiquetaItem
    {
       
        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        
        private string mFont;
        
        public string Font
        {
            get { return mFont; }
            set { mFont = value; }
        }
        
        
        private float mSize;
        
        public float Size
        {
            get { return mSize; }
            set { mSize = value; }
        }
        
        private int mBold;
        
        public int Bold
        {
            get { return mBold; }
            set { mBold = value; }
        }
        
        
        private int mItalic;
        
        public int Italic
        {
            get { return mItalic; }
            set { mItalic = value; }      
        
        }        
        
        private double mYinicial;
        
        
        public double Yinicial
        {
            get { return mYinicial; }
            set { mYinicial = value; }
        }
        
        
        private double mXinicial;
        
        
        public double Xinicial
        {
            get { return mXinicial; }
            set { mXinicial = value; }
        }
        
        private double mYfinal;
        
        public double Yfinal
        {
            get { return mYfinal; }
            set { mYfinal = value; }
        }
        
        private double mXfinal;
        
        
        public double Xfinal
        {
            get { return mXfinal; }
            set { mXfinal = value; }
        }
        
        private int mVariable;
        
        
        public int Variable
        {
            get { return mVariable; }
            set { mVariable = value; }
        }
        
        private int mTipo;
        
        
        public int  Tipo
        {
            get { return mTipo; }
            set { mTipo = value; }
        }
        
        private int mAlignh;
        
        
        public int Alignh
        {
            get { return mAlignh; }
            set { mAlignh = value; }
        }
        
        
        private int mAlignv;
        
        public int Alignv
        {
            get { return mAlignv; }
            set { mAlignv = value; }
        }
        
        private string mParam;
        
        public string Param
        {
            get { return mParam; }
            set { mParam = value; }
        }


        private string mParamValue;

        public string ParamValue
        {
            get { return mParamValue; }
            set { mParamValue = value; }
        }
        


        private int mNumeroEtiqueta;
        
        public int NumeroEtiqueta
        {
            get { return mNumeroEtiqueta; }
            set { mNumeroEtiqueta = value; }
        }

        public bool EsVariable() { 
            return (mVariable!=0);
        }
 
    }
}
