using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

using log4net;

namespace WPFiDU.Utils
{
  class LastTestedModelManager
  {
    private static readonly ILog logger = LogManager.GetLogger(typeof(LastTestedModelManager));
    
    private static string getFilePath()
    {
      return WPFiDU.Utils.Utils.getBinFullDirectory() + "\\LastTestedModelId.txt";
    }
    public static int getLastTestedModelId()
    {
      string path = LastTestedModelManager.getFilePath();
      
      if (!File.Exists(path))
        return 0;
        
      StreamReader sr = new StreamReader(path);

      int iLastTestedModelId = 0;
      string sLastTestedModelId = sr.ReadLine();
      if (!String.IsNullOrEmpty(sLastTestedModelId))
      {
        bool b = int.TryParse(sLastTestedModelId, out iLastTestedModelId);
        if (!b)
          iLastTestedModelId = 0;
      }
      sr.Close();

      return iLastTestedModelId;
    }

    public static void setLastTestedModelId(int argModelId)
    {
      string path = LastTestedModelManager.getFilePath();
      StreamWriter sw = null;
      try
      {
        if (File.Exists(path))
        {
          File.Delete(path);
        }
          
        sw = new StreamWriter(path, false);
        sw.WriteLine(Convert.ToString(argModelId));
        sw.Flush();
        
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("getLastTestedModelId():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
          , ex.StackTrace
          , ex.InnerException != null ? ex.InnerException.Message : "");
      }
      finally
      {
        if (sw != null)
          sw.Close();
      }
    }

  }
}
