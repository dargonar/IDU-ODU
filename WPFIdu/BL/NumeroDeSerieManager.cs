using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFiDU.CommonObjects;
using iDU.BL;
using System.Configuration;
using System.IO;
using iDU.CommonObjects;

namespace WPFiDU.BL
{
    public class NumeroDeSerieManager : Manager
    {

        public string ObtenerNumeroDeSerie(int aprobado)
        {
            return AccesoDatos.ObtenerNumeroDeSerie(aprobado);

        }

        public void ModificarNumeroDeSerie(NumeroDeSerie ns,int aprobado)
        {
            AccesoDatos.ModificarNumeroDeSerie(ns,aprobado);

        }


        public NumeroDeSerie ObtenerConfiguracionNumeroDeSerie(int aprobado)
        {

            return AccesoDatos.ObtenerConfiguracionNumeroDeSerie(aprobado);
        }

        public string ObtenerUltimoNumeroDeSerie()
        {
         
            string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_NUMERO_DE_SERIE"] + "numerodeserie.txt";

            if (!File.Exists(PATH))
                return "N\\A";

            StreamReader sr = new StreamReader(PATH);

            
            string numserie = sr.ReadLine();
            sr.Close();

            return numserie;
        }

        public void GuardarNumeroDeSerie()
        {
            string DIR = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["DIRECTORIO_NUMERO_DE_SERIE"];

            if (!Directory.Exists(DIR))
                Directory.CreateDirectory(DIR);

            string PATH = DIR + "numerodeserie.txt";
            StreamWriter sw = new StreamWriter(PATH, false);

            if (!File.Exists(PATH))
                File.CreateText(PATH);

            EnsayosManager managensayos = new EnsayosManager();
            Ensayos ens =  managensayos.ObtenerUltimoEnsayo();
                                                
            sw.Write(ens.Serie);
            sw.Close();
                     
        }
    }
}
