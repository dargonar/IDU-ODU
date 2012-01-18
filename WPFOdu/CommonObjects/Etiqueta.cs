using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace iDU.CommonObjects
{
    
    [Serializable]
    public class Etiqueta
    {

       //protected XmlSerializer Serializador = new XmlSerializer(typeof(Etiqueta));

        private string mNombre;
        public string Nombre 
        {
            get { return mNombre; }
            set { mNombre = value ; }
        }

        private int mId;
        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        private bool mEsIDU;

        public bool EsIDU
        {
            get { return mEsIDU; }
            set { mEsIDU = value; }
        }

        private bool mEsBulto;

        public bool EsBulto
        {
          get { return mEsBulto; }
          set { mEsBulto = value; }
        }
            

        public override string ToString()
        {
            return mNombre;
        }

        List<EtiquetaItem> mComponentes=null;
        public List<EtiquetaItem> Componentes {
            get { return mComponentes; }
            set { mComponentes = value; }
        }

    }
}
