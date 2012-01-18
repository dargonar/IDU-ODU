using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class Ensayos
    {

        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }

        private string mMarca;

        public string Marca
        {
            get { return mMarca; }
            set { mMarca = value; }
        }

        private string mCodigo;

        public string Codigo
        {
            get { return mCodigo; }
            set { mCodigo = value; }
        }

        private string mModelo;

        public string Modelo
        {
            get { return mModelo; }
            set { mModelo = value; }

        }


        private string mSerie;

        public string Serie
        {
            get { return mSerie; }
            set { mSerie = value; }

        }


        private string mOrdenFabricacion;
        public string OrdenFabricacion
        {
          get { return mOrdenFabricacion; }
          set { mOrdenFabricacion = value; }

        }


        private DateTime mFecha;

        public DateTime Fecha
        {
            get { return mFecha; }
            set { mFecha = value; }
        }


        private bool mAprobado=false; //TUTI
        public bool Aprobado
        {
            get { return mAprobado; }
            set { mAprobado = value; }
        }

        public string AprobadoSINO 
        { 
            get { return mAprobado != false ? "SI"  : "NO"; }
        }

        private string mDCF;

        public string DCF
        {
            get { return mDCF; }
            set { mDCF = value; }

        }

        private string mObservaciones;

        public string Observaciones
        {
            get { return mObservaciones; }
            set { mObservaciones = value; }
        }

        private string mUsuario;

        public string Usuario
        {
            get { return mUsuario; }
            set { mUsuario = value; }

        }
        
        
       
    }
}
