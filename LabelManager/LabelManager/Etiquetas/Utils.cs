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
      string file = o.Directory.FullName;
      return file;
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
  }
}
