using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace iDU.BL
{
    public class ImagenesManager
    {
        private string PATH;

        private string mSearchPattern = "*.wmf";



        public List<string> NombresDirectorioLogos()
        {
            PATH = WPFiDU.Utils.Utils.getBinFullDirectory() +  ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_LOGO"];
            List<string> ListaArchivos = new List<string>();
         
            DirectoryInfo di = new DirectoryInfo(PATH);
            FileInfo [] fi = di.GetFiles(mSearchPattern);

            foreach (FileInfo fitemp in fi)
                ListaArchivos.Add(fitemp.Name);

            return ListaArchivos;
        }
        public List<string> NombresDirectorioExtras()
        {
           
            
            
            PATH = WPFiDU.Utils.Utils.getBinFullDirectory()+ ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_EXTRAS"];
            List<string> ListaArchivos = new List<string>();
            DirectoryInfo di = new DirectoryInfo(PATH);
            FileInfo[] fi = di.GetFiles(mSearchPattern);

            foreach (FileInfo fitemp in fi)
                ListaArchivos.Add(fitemp.Name);

            return ListaArchivos;
        }

        public List<string> NombresDirectorioEAN13()
        {
            PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_EAN13"];
            List<string> ListaArchivos = new List<string>();
            DirectoryInfo di = new DirectoryInfo(PATH);
            FileInfo[] fi = di.GetFiles(mSearchPattern);

            foreach (FileInfo fitemp in fi)
                ListaArchivos.Add(fitemp.Name);

            return ListaArchivos;

        }

        public List<string> NombresDirectorioDimension()
        {
            PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_DIMENSION"];
            List<string> ListaArchivos = new List<string>();
            DirectoryInfo di = new DirectoryInfo(PATH);
            FileInfo[] fi = di.GetFiles(mSearchPattern);

            foreach (FileInfo fitemp in fi)
                ListaArchivos.Add(fitemp.Name);
           
            return ListaArchivos;

        }

        public List<string> NombresDirectorioCapacidad()
        {
            PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_IMAGENES_CAPACIDAD"];
            List<string> ListaArchivos = new List<string>();
            DirectoryInfo di = new DirectoryInfo(PATH);
            FileInfo[] fi = di.GetFiles(mSearchPattern);

            foreach (FileInfo fitemp in fi)
                ListaArchivos.Add(fitemp.Name);

            return ListaArchivos;

        }
    
    }
}
