using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class CaracteristicasTecnicas
    {
        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }

        private int mVersion;

        public int Version
        {
            get { return mVersion; }
            set { mVersion = value; }
        }
        
        private string mDescripcion1;

        public string Descripcion1
        {
            get { return mDescripcion1; }
            set { mDescripcion1 = value; }
        }
        
        
        
        private string mDescripcion2;

        public string Descripcion2
        {
            get { return mDescripcion2; }
            set { mDescripcion2 = value; }
        }
        
        
        private string mDescripcion3;

        public string Descripcion3
        {
            get { return mDescripcion3; }
            set { mDescripcion3 = value; }
        }
        
        private string mDescripcion4;

        public string Descripcion4
        {
            get { return mDescripcion4; }
            set { mDescripcion4 = value; }
        }
        
        private string mDescripcion5;

        public string Descripcion5
        {
            get { return mDescripcion5; }
            set { mDescripcion5 = value; }
        }
        

        private string mDescripcion6;

        public string Descripcion6
        {
            get { return mDescripcion6; }
            set { mDescripcion6 = value; }
        }
        
        private string mTensionNominal;

        public string TensionNominal
        {
            get {return mTensionNominal; }
            set { mTensionNominal = value; }
        }

        private string mFrecuencia;

        public string Frecuencia
        {
            get { return mFrecuencia; }
            set { mFrecuencia = value; }
        
        }

        private string mPotenciaMaxima;

        public string PotenciaMaxima
        {
            get { return mPotenciaMaxima; }
            set { mPotenciaMaxima = value; }

        }

        private string mCorrienteMaxima;

        public string CorrienteMaxima
        {
            get { return mCorrienteMaxima; }
            set { mCorrienteMaxima = value; }
        }
        
        private string mCarga;

        public string Carga
        {
            get { return mCarga; }
            set { mCarga = value; }
        }

        private string mPresion;

        public string Presion
        {
            get { return mPresion; }
            set { mPresion = value; }
        }
        
        private string mCapacidadFrio;

        public string CapacidadFrio
        {
            get { return mCapacidadFrio; }
            set { mCapacidadFrio = value; }
        }
        
        private string mPotenciaNominalFrio;

        public string PotenciaNominalFrio
        {
            get { return mPotenciaNominalFrio; }
            set { mPotenciaNominalFrio = value; }
        }
        
        private string mCorrienteNominalFrio;

        public string CorrienteNominalFrio
        {
            get { return mCorrienteNominalFrio; }
            set { mCorrienteNominalFrio = value; }

        }
        
        private string mPeso;

        public string Peso
        {
            get { return mPeso; }
            set { mPeso = value; }
        }
        
        private string mCapacidadCalor;

        public string CapacidadCalor
        {
            get { return mCapacidadCalor; }
            set { mCapacidadCalor = value; }
        }
        
        private string mPotenciaNominalCalor;

        public string PotenciaNominalCalor
        {
            get { return mPotenciaNominalCalor; }
            set { mPotenciaNominalCalor = value; }

        }

        private string mCorrienteNominalCalor;

        public string CorrienteNominalCalor
        {
            get { return mCorrienteNominalCalor; }
            set { mCorrienteNominalCalor = value; }

        }
        
        private string mErr;

        public string Err
        {
            get { return mErr; }
            set { mErr = value; }
        }
        
        private bool mEsidu;


        public bool Esidu
        {
            get { return mEsidu; }
            set { mEsidu = value; }

        }

        private string mNombre;

        public string Nombre
        {
            get { return mNombre; }
            set { mNombre = value; }
        }


        public override string ToString()
        {
            return mNombre;
        }


        private int mIdParametros;

        public int IdParametros
        {
            get { return mIdParametros; }
            set { mIdParametros = value; }

        }
    
    
    }
}
