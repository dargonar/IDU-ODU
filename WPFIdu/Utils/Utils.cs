using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WPFiDU.Utils
{

    public class Utils
    {
      public static bool Window_AllowsTransparency = false;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getBinFullDirectory()
        {
            string path 
                = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo o = new FileInfo(path);
            string file = o.Directory.FullName ;
            return file ;
        }

        /// <summary>
        /// retorna el archivo parametrizado concatnado a 
        /// el directorio bin.
        /// </summary>
        /// <param name="argFilePath"></param>
        /// <returns></returns>
        public static string getBinFullDirectory(string argFilePath)
        {
            string path = getBinFullDirectory();
            path = path + argFilePath;

            return path;
        }

        public static bool IsValidOrdenFabricacion(string s) 
        {
          return (!string.IsNullOrEmpty(s) && !s.Trim().Equals("N\\A") && s.Trim().ToLower().StartsWith("f") && s.Trim().ToLower().Length == 11);
        }

        public static bool IsValidNumeroSerie(string s)
        {
          return (!string.IsNullOrEmpty(s) && !s.Trim().Equals("N\\A") && s.Trim().ToLower().StartsWith("s") && s.Trim().ToLower().Length == 11);
        }
    }
}
