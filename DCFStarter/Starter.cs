using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using System.IO;
using log4net;
namespace DCFStarter
{
  public class Starter
  {
    private static readonly ILog logger = LogManager.GetLogger(typeof(Starter));
    
    public void start()
    {
        
      List<StartItem> elements = new List<StartItem>();
      bool bOk = true;
      int iIndex = 1;
      while (bOk)
      {
        string processData = string.Empty;
        try
        {
          processData = System.Configuration.ConfigurationManager.AppSettings[
            string.Format("start{0}", iIndex.ToString())];
        }
        catch (Exception ex)
        {
          logger.ErrorFormat("stack:'{0}';msg:'{1}';index:'{2}';", ex.StackTrace, ex.Message, iIndex.ToString());
          bOk = false;
          break;
        }

        if (string.IsNullOrEmpty(processData))
            break;

        elements.Add(new StartItem(processData));

        iIndex++;
      }

      if (elements.Count < 1)
        return;

      for (int i = 0; i < elements.Count; i++)
      {
          if (i == elements.Count - 1)
              Thread.Sleep(13000);
        startProcess(elements[i]);
      }
    }

    private void startProcess(StartItem argStartItem) 
    {
       
      if(argStartItem.IsApplication())
        startApplication(argStartItem.Name, argStartItem.Path);
      else
        if (argStartItem.IsService())
          startService(argStartItem.Name);
    }

    public static string getBinFullDirectory()
    {
      string path
          = System.Reflection.Assembly.GetExecutingAssembly().Location;
      FileInfo o = new FileInfo(path);
      logger.DebugFormat("DCFStarter Directory:'{0}'", o.Directory.FullName);
      return o.Directory.FullName;
    }


    private void startApplication(string name, string path) 
    {
      if (name.IndexOf('|') > 0)
      {
        string[] names = name.Split('|');
        string[] paths = path.Split('|');


        if (File.Exists(string.Format("{0}\\{1}"
          , Starter.getBinFullDirectory(), paths[0].Trim())))
        {
          name = names[0].Trim();
          path = string.Format("{0}\\{1}", Starter.getBinFullDirectory(), paths[0].Trim());
        }
        else
        {
          name = names[1].Trim();
          path = string.Format("{0}\\{1}", Starter.getBinFullDirectory(), paths[1].Trim());
        }
      }

      logger.DebugFormat("Process Info:: name:'{0}';path:'{1}';", name , path);

      bool bStartProcess = true;
      
      foreach (Process process in Process.GetProcesses())
      {
        try
        {
            if (name.Equals(process.MainModule.ModuleName))
            {
              if (!process.Responding)
              {
                process.Kill();
              }
              else
                bStartProcess = false;
              
              break;
            }
          }
        catch { }
      }

      if (!bStartProcess)
        return;

      ProcessStartInfo infoproceso = new ProcessStartInfo(path);
      //infoproceso.WindowStyle = ProcessWindowStyle.Hidden;

      Process nuevoproceso = new Process();
      nuevoproceso.StartInfo = infoproceso;
      logger.DebugFormat("Process Pre Start:: name:'{0}';path:'{1}';", name, path);
      nuevoproceso.Start();
      logger.DebugFormat("Process OK:: name:'{0}';path:'{1}';", name, path);
      
    }
    
    private void startService(string name) 
    {
      ServiceController[] controllers = ServiceController.GetServices();
      foreach (ServiceController service in controllers)
      {
        if (name.Equals(service.ServiceName))
        {
          if (!service.Status.Equals(ServiceControllerStatus.Running))
          {
            service.Start();

          }
          break;
        }
      }
    }

    
  }
}
