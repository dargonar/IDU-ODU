using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace iDU.CommonObjects
{
    
    [Serializable]
    public class ParametrosEnsayo
    {
        private int mID;
        //protected XmlSerializer Serializador=new XmlSerializer(typeof(ParametrosEnsayo));

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }


        private string mReferencia;

        public string Referencia
        {
            get { return mReferencia; }
            set { mReferencia = value; }
        }

        private string mDescripcion;

        public string Descripcion
        {
            get { return mDescripcion; }
            set { mDescripcion = value; }
        }

        private int mDCFs;

        public int DCFs
        {

            get { return mDCFs; }
            set { mDCFs = value; }
        }


        private DateTime mModificado;

        public DateTime Modificado
        {
            get { return mModificado; }
            set { mModificado = value; }

        }


        private int mIdVersion;

        public int IdVersion
        {

            get { return mIdVersion; }
            set { mIdVersion = value; }
        }

        public override string ToString()
        {
          return Referencia + " - " + mDescripcion;
        }
    
    }
}
