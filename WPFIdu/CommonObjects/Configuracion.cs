using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class Configuracion
    {

        private string mCadenaDeConexion;

        public string CadenaDeConexion
        {
            get { return mCadenaDeConexion; }
            set { mCadenaDeConexion = value; }
        }

        private string mValidarHipot;
        public string ValidarHipot
        {
          get { return mValidarHipot; }
          set { mValidarHipot = value; }
        }

      private bool mReadSerialNumberFromScanner=false;

      public bool ReadSerialNumberFromScanner{
        get { return mReadSerialNumberFromScanner; }
        set { mReadSerialNumberFromScanner = value; }
      }
        

        private bool mImpresoraProductoHabilitada;

        public bool ImpresoraProductoHabilitada
        {
          get { return mImpresoraProductoHabilitada; }
          set { mImpresoraProductoHabilitada = value; }
        }

        private bool mImpresoraBultoHabilitada;

        public bool ImpresoraBultoHabilitada
        {
          get { return mImpresoraBultoHabilitada; }
          set { mImpresoraBultoHabilitada = value; }

        }

        private string mImpresoraProducto;

        public string ImpresoraProducto
        {
            get { return mImpresoraProducto; }
            set { mImpresoraProducto = value; }
        }
        
        private string mImpresoraBulto;

        public string ImpresoraBulto
        {
            get { return mImpresoraBulto; }
            set { mImpresoraBulto = value; }

        }

        private string mTempMin;

        public string TempMin
        {
            get { return mTempMin; }
            set { mTempMin = value; }
        }

        private string mTempMax;

        public string TempMax
        {
            get { return mTempMax; }
            set { mTempMax = value; }

        }

        bool mPrintErrorTests = false;
        public bool PrintErrorTests
        {
          get { return mPrintErrorTests; }
          set { mPrintErrorTests = value; }

        }
    }
}
