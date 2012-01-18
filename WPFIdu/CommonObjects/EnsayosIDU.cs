using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class EnsayosIDU : Ensayos
    {

        
        
        private int mTiempoEnsayo;

        public int TiempoEnsayo
        {
            get { return mTiempoEnsayo; }
            set { mTiempoEnsayo = value; }
        }
        
        private float mVelocidadInicial;

        public float VelocidadInicial
        {
            get { return mVelocidadInicial; }
            set { mVelocidadInicial = value; }
        }
        
        private float mVelocidadBajaTension;


        public float VelocidadBajaTension
        {
            get { return mVelocidadBajaTension; }
            set { mVelocidadBajaTension = value; }
            
        }
        
        private float mVelocidadLow;

        public float VelocidadLow
        {
            get { return mVelocidadLow; }
            set { mVelocidadLow = value; }

        
        }
        
        
        private float mVelocidadHigh;

        public float VelocidadHigh
        {
            get { return mVelocidadHigh; }
            set { mVelocidadHigh = value; }
        
        }
        
        private float mCorrienteInicial;

        public float CorrienteInicial
        {
            get { return mCorrienteInicial; }
            set { mCorrienteInicial = value; }
        
        }
        
        private float mCorrienteBajaTension;

        public float CorrienteBajaTension
        {
            get { return mCorrienteBajaTension; }
            set { mCorrienteBajaTension = value; }
        
        }
        
        private float mCorrienteLow;

        public float CorrienteLow
        {
            get { return mCorrienteLow; }
            set { mCorrienteLow = value; }
        
        }

        private float mCorrienteHIGH;

        public float CorrienteHIGH
        {
            get { return mCorrienteHIGH; }
            set { mCorrienteHIGH = value; }
        }


        private float mCorrienteCalorInicial;

        public float CorrienteCalorInicial
        {
            get { return mCorrienteCalorInicial; }
            set { mCorrienteCalorInicial = value; }
        
        }
        
        private string mHipot;

        public string Hipot
        {
            get { return mHipot; }
            set { mHipot = value; }
        
        }
        
        
        private string mFuga;

        public string Fuga
        {
            get { return mFuga; }
            set { mFuga = value; }
        }
        
     

        
    
    }
}
