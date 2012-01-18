using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace iDU.Archivo
{
    class ArchivoIDU : Archivo
    {

        public ArchivoIDU()
        {

            Serializador = new XmlSerializer(typeof(ParametrosEnsayoIDU));
        }


        public override void GuardarParametrosEnArchivo(ParametrosEnsayo param, string Archivo)
        {
            ParametrosEnsayoIDU paridu = param as ParametrosEnsayoIDU;
            TextWriter writer = new StreamWriter(Archivo);
            Serializador.Serialize(writer, paridu);
            writer.Close();

        }
        public override ParametrosEnsayo LeerParametrosDeArchivo(string archivo)
        {
            ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();
            FileStream fs = new FileStream(archivo, FileMode.Open);
            paridu = (ParametrosEnsayoIDU)Serializador.Deserialize(fs);
            fs.Close();
            return paridu;

        }
    }
}
