using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
namespace WPFiDU.Utils
{
    class PiezasOkManager
    {
      public static int getPiezasOk() 
      {
        DirectoryInfo DIR = new DirectoryInfo(WPFiDU.Utils.Utils.getBinFullDirectory() + "\\EnsayosOK");

        if (!DIR.Exists)
        {
          DIR.Create();
        }
        string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["ARCHIVO_ENSAYOSOK_ODU"];
        if (!File.Exists(PATH))
        {
          StreamWriter sw = new StreamWriter(PATH, false);
          sw.WriteLine("0");
          sw.Flush();
          sw.Close();
        }
            
        StreamReader sr = new StreamReader(PATH);

        int iPiezasOk = 0;
        string sPiezasOk = sr.ReadLine();
        if (!String.IsNullOrEmpty(sPiezasOk))
        {
          bool b = int.TryParse(sPiezasOk, out iPiezasOk);
          if (!b)
            iPiezasOk = 0;
        }
        sr.Close();

        return iPiezasOk;
      }
        
        public static void addPiezaOk() 
        {
            int cantensayos = getPiezasOk();
            
            string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["ARCHIVO_ENSAYOSOK_ODU"];
            StreamWriter sw = new StreamWriter(PATH, false);
            sw.Write(Convert.ToString(cantensayos + 1));
            sw.Flush(); 
			      sw.Close();

            return;
        }
        
        public static void resetPiezas(string argUserName) 
        {
            // Salvo la info actual.
            IDU_ODU.InfoEnsayosResetManager o = new IDU_ODU.InfoEnsayosResetManager();
            InfoEnsayosReset infoens = new InfoEnsayosReset();

            infoens.Fecha = DateTime.Now;
            infoens.PC = System.Environment.MachineName;
            infoens.Usuario = argUserName;
            infoens.NumeroEnsayosOK = getPiezasOk();
            infoens.EsIDU = true;

            o.addInfoEnsayosReset(infoens);

            // reseteo el contador.
            string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + ConfigurationManager.AppSettings["ARCHIVO_ENSAYOSOK_ODU"];
            StreamWriter sw = new StreamWriter(PATH, false);
            sw.Write("0");
			      sw.Flush();
            sw.Close();

            return;
        }
    }
}
