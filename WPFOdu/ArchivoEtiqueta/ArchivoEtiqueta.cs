using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using iDU.CommonObjects;

namespace iDU.ArchivoEtiqueta
{
    
    
    
    class ArchivoEtiqueta
    {
        private XmlSerializer Serializador;

        public ArchivoEtiqueta()
        {
            Serializador = new XmlSerializer(typeof(Etiqueta));

        }


        public void GuardarEtiquetaEnArchivo(Etiqueta etiqueta,string archivo)
        {
            
            TextWriter writer = new StreamWriter(archivo);
            Serializador.Serialize(writer, etiqueta);
            writer.Close();

        }

        public Etiqueta LeerEtiquetaDeArchivo(string archivo)
        {
            Etiqueta e = new Etiqueta();
            FileStream fs = new FileStream(archivo, FileMode.Open);
            e = (Etiqueta)Serializador.Deserialize(fs);
            fs.Close();
            return e;

        }
    }
}
