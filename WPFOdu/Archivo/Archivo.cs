using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace iDU.Archivo
{
    public abstract class Archivo
    {

        public abstract void GuardarParametrosEnArchivo(ParametrosEnsayo param,string archivo);
        public abstract ParametrosEnsayo LeerParametrosDeArchivo(string archivo);
        protected XmlSerializer Serializador;
       

    
    }
}
