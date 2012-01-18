using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace iDU.Archivo
{
    class ArchivoODU : Archivo
    {

        public ArchivoODU()
        {

            Serializador = new XmlSerializer(typeof(ParametrosEnsayoODU));
        }



        public override void GuardarParametrosEnArchivo(ParametrosEnsayo param,string archivo)
        {
            ParametrosEnsayoODU parodu = param as ParametrosEnsayoODU;
            TextWriter writer = new StreamWriter(archivo);
            Serializador.Serialize(writer, parodu);
            writer.Close();

        }

        public override ParametrosEnsayo LeerParametrosDeArchivo(string archivo)
        {
            ParametrosEnsayoODU parodu = new ParametrosEnsayoODU();
            FileStream fs = new FileStream(archivo, FileMode.Open);
            parodu = (ParametrosEnsayoODU)Serializador.Deserialize(fs);
            fs.Close();
            return parodu;

        }
    
    }
}
