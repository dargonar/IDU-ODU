using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.CommonObjects
{
    public  class NumeroDeSerie
    {
        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }

        }
        
        private char mTipo;

        public char Tipo
        {
            get { return mTipo; }
            set { mTipo = value; }

        }
        
        private int mNumero;

        public int Numero
        {

            get { return mNumero; }
            set { mNumero = value; }
        }
        
        private int mMaximo;

        public int Maximo
        {
            get { return mMaximo; }
            set { mMaximo = value; }

        }
        
        private int mMinimo;

        public int Minimo
        {
            get { return mMinimo; }
            set { mMinimo = value; }


        }
        
        private string mPrefijo;

        public string Prefijo
        {
            get { return mPrefijo; }
            set { mPrefijo = value; }

        }
        
        private int mSufijo;

        public int Sufijo
        {
            get { return mSufijo; }
            set { mSufijo = value; }

        }

    
    
    }
}
