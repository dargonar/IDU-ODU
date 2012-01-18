using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;

using log4net;

namespace dcf001.Utils
{
  public class AppSrvcsManager
  {
    private static readonly ILog logger = LogManager.GetLogger(typeof(AppSrvcsManager));

    public static void getServicesState(ref  List<RequiredProcessStatus> argApplications
      , ref List<RequiredProcessStatus> argServices) 
    {

      for (int i = 0; i < argApplications.Count; i++)
        argApplications[i].IsRunning = false;

      for (int i = 0; i < argServices.Count; i++)
          argServices[i].IsRunning=false;
      

      // Processes
      foreach (Process process in Process.GetProcesses())
      {
        try
        {
          for (int i = 0; i < argApplications.Count; i++)
          {
            RequiredProcessStatus oRequiredProcessStatus = argApplications[i];
              if (oRequiredProcessStatus.ToString().Equals(process.MainModule.ModuleName)) 
              { 
                if(process.Responding)
                  argApplications[i].IsRunning = true;
                break;
              }
          }
        }
        catch { }
      }

      // Services 
      ServiceController[] controllers = ServiceController.GetServices();
      foreach (ServiceController service in controllers)
      {
        for (int i = 0; i < argServices.Count; i++)
        {
          RequiredProcessStatus oRequiredProcessStatus = argServices[i];
          if (oRequiredProcessStatus.ToString().Equals(service.ServiceName))
          {

            logger.DebugFormat("AppSrvcsManager.cs::getServicesState(); Servicio:'{0}';Status:'{1}';", service.ServiceName, service.Status.ToString());
            argServices[i].IsRunning = service.Status.Equals(ServiceControllerStatus.Running);
            break;
          }
        }
      }

      return;
    }

    public static string getServicesState() 
    {
      
      // Processes

      StringBuilder str = new StringBuilder();
      str.AppendLine("--Processes");
      foreach (Process process in Process.GetProcesses())
      {
        
        try
        {
          str.AppendLine(process.MainModule.ModuleName);
        }
        catch { }
      }

      // Services 
      str.AppendLine("--Services");
      ServiceController[] controllers = ServiceController.GetServices();
      foreach (ServiceController service in controllers)
      {
        if (service.Status.Equals(ServiceControllerStatus.Running))
          str.AppendLine(service.ServiceName);
      }

      return str.ToString();
    }

    /// <summary>
    /// Retorna una estructura RequiredProcessStatus a partir de un string tag de formato
    /// 'type=service;name=IVAdqMgr' o 'type=service;name=IVRTKernel' o 'type=application;name=OPCDAServer.exe'
    /// </summary>
    /// <param name="tag"></param>
    /// <returns>RequiredProcessStatus</returns>
    public static RequiredProcessStatus getRequiredProcessStatus(string argControlTag)
    {
      string[] tag_data = argControlTag.Trim().Split(';');
      RequiredProcessStatus oRequiredProcessStatus = new RequiredProcessStatus();
      oRequiredProcessStatus.IsService = tag_data[0].Trim().Split('=')[1].Trim() == "service";
      oRequiredProcessStatus.Name = tag_data[1].Trim().Split('=')[1];
      oRequiredProcessStatus.Tag = argControlTag;
     
      return oRequiredProcessStatus;
    }
    public static RequiredProcessStatus getRequiredProcessStatus(Control oControl)
    {
      string tag = oControl.Tag as string;
      RequiredProcessStatus oRequiredProcessStatus = getRequiredProcessStatus(tag);
      oRequiredProcessStatus.Control = oControl;

      return oRequiredProcessStatus;
    }

    public static void toogleServiceState(string argControlTag)
    {
      TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
        , "AppSrvcsManager.cs"
        , "toogleServiceState()"
        , string.Format("oControlTag:'{0}';"
          , argControlTag));

      RequiredProcessStatus oRequiredProcessStatus = getRequiredProcessStatus(argControlTag);

      if (oRequiredProcessStatus.IsService)
      {
        TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
        , "AppSrvcsManager.cs"
        , "toogleServiceState()"
        , string.Format("IsService:'SI';"));
      
        // Get Service.
        ServiceController[] controllers = ServiceController.GetServices();
        foreach (ServiceController service in controllers)
        {
          if (oRequiredProcessStatus.Name.Equals(service.ServiceName))
          {
            logger.DebugFormat("AppSrvcsManager.cs::toogleServiceState(); " + string.Format("Service Found!"));
            TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
              , "AppSrvcsManager.cs"
              , "toogleServiceState()"
              , string.Format("Service Found!"));

            if (!service.Status.Equals(ServiceControllerStatus.Running))
            {
              service.Start();
              logger.DebugFormat("AppSrvcsManager.cs::toogleServiceState(); " + string.Format("Service Started!"));
              TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
                , "AppSrvcsManager.cs"
                , "toogleServiceState()"
                , string.Format("Service Started!"));
            }
            else
            {
              if (!service.Status.Equals(ServiceControllerStatus.Stopped))
                service.Stop();
              logger.DebugFormat("AppSrvcsManager.cs::toogleServiceState(); " + string.Format("Service Stopped!")); 
              TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
                , "AppSrvcsManager.cs"
                , "toogleServiceState()"
                , string.Format("Service Stopped!"));
            }
            break;
          }
        }
      }
      else
      {
        TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
        , "AppSrvcsManager.cs"
        , "toogleServiceState()"
        , string.Format("Is Application!! IsService:'NO';"));
        
        bool mProcessFounded = false;
        // Get Process.
        foreach (Process process in Process.GetProcesses())
        {
          try
          {
            if (oRequiredProcessStatus.Name.Equals(process.MainModule.ModuleName))
            {
              logger.DebugFormat("AppSrvcsManager.cs::toogleServiceState(); " +
                string.Format("Application Process Founded!! Killing it!!")); 
              
              TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
                , "AppSrvcsManager.cs"
                , "toogleServiceState()"
                , string.Format("Application Process Founded!! Killing it!!"));
              mProcessFounded = true;
              process.Kill();
              break;
            }

          }
          catch 
          { }
        }

        if (!mProcessFounded)
        {
          string processPath
            = System.Configuration.ConfigurationManager.AppSettings[
            string.Format("AppSrvcsManager.{0}"
            , oRequiredProcessStatus.Name.Trim())];
          logger.DebugFormat("AppSrvcsManager.cs::toogleServiceState(); " +
                string.Format("Starting Application Process!! Path:'{0}'", processPath)); 
              
          TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
              , "AppSrvcsManager.cs"
              , "toogleServiceState()"
              , string.Format("Starting Application Process!! Path:'{0}'", processPath));

          if (String.IsNullOrEmpty(processPath))
            return;

          ProcessStartInfo infoproceso = new ProcessStartInfo(processPath);
          //infoproceso.WindowStyle = ProcessWindowStyle.Hidden;

          Process nuevoproceso = new Process();
          nuevoproceso.StartInfo = infoproceso;
          nuevoproceso.Start();

          TraceView.SendDebugMessage(TraceView.TMsgType.MsgDebug
              , "AppSrvcsManager.cs"
              , "toogleServiceState()"
              , string.Format("Application Process Started!! Path:'{0}'", processPath));
        }

      }
    }
  }

  public class RequiredProcessStatus
  {
    public bool IsService;
    public string Name;
    public string Tag;
    public bool IsRunning;
    public System.Windows.Controls.Control Control;

    public RequiredProcessStatus()
    {
      IsService = false;
      Name = string.Empty;
      Tag = string.Empty;
      IsRunning = false;
      Control = null;
    }
    public override string ToString()
    {
      return Name;
    }
    public RequiredProcessStatus Clone()
    {
      RequiredProcessStatus oRequiredProcessStatus = new RequiredProcessStatus();
      oRequiredProcessStatus.Control = this.Control;
      oRequiredProcessStatus.IsRunning = this.IsRunning;
      oRequiredProcessStatus.IsService = this.IsService;
      oRequiredProcessStatus.Name = this.Name;
      oRequiredProcessStatus.Tag= this.Tag;
      return oRequiredProcessStatus;
    }
  }

  
    
}
