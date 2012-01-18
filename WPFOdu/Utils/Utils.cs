using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WPFiDU.Utils
{
    public class Utils
    {
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

        public static string Slugify(string phrase)
        {
          return Utils.Slugify(phrase, 50);
        }

        public static string Slugify(string phrase, int maxLength)
        {
            string str = phrase.ToLower();
            
            // invalid chars, make into spaces
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");  
            // convert multiple spaces/hyphens into one space       
            str = Regex.Replace(str, @"[\s-]+", " ").Trim(); 
            // cut and trim it
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim(); 
            // hyphens
            str = Regex.Replace(str, @"\s", "-"); 

            return str;
        }
    }
}
