using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using WPFiDU.Utils;
namespace dcf001
{
  /// <summary>
  /// Lógica de interacción para wndServicesManager.xaml
  /// </summary>
  public partial class wndServicesManager : Window
  {
    public wndServicesManager()
    {
      InitializeComponent();
      loadVisualElements();
      loadStatus();
    }

    #region Members

    private Style objStyleOn = null;
    private Style objStyleOff = null;
    private List<RequiredProcessStatus> argApplications = null;
    private List<RequiredProcessStatus> argServices = null;
    List<Control> oControls = null;
    private bool IsLoaded = false;
    #endregion Members

    #region Events
    private void btnDimensionADQManager_Click(object sender, RoutedEventArgs e)
    {
      toggleServiceState(btnDimensionADQManager);
    }

    private void btnDimensionKernel_Click(object sender, RoutedEventArgs e)
    {
      toggleServiceState(btnDimensionKernel);
    }

    private void btnOPCDAServer_Click(object sender, RoutedEventArgs e)
    {
      toggleServiceState(btnOPCDAServer);
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
      loadStatus();
    }
    private void imgRefresh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      loadStatus();
    }
#endregion Events

    #region Functions

    private void toggleServiceState(Control argBtnControl )
    {
      lblCambiando.Visibility = Visibility.Visible;

      try
      {
        Thread oThread = new Thread(toogleServiceStateWrapper);
        oThread.Start(argBtnControl.Tag);

        while (oThread.IsAlive)
          System.Windows.Forms.Application.DoEvents();

        oThread = null;
      }
      catch (Exception ex)
      { }

      loadStatus();

      lblCambiando.Visibility = Visibility.Hidden;

      //AppSrvcsManager.toogleServiceState(argBtnControl.Tag as string);
      //loadStatus();
    }

    private void toogleServiceStateWrapper(object argBtnControlTag)
    {
      AppSrvcsManager.toogleServiceState(argBtnControlTag as string);
    }

    #endregion Functions

    #region Loaders

    private void loadVisualElements() 
    {
      //this.Window.AllowsTransparency = Utils.Utils.WindowsAllowTransparency;
      lblCambiando.Visibility = Visibility.Hidden;
      objStyleOn = (Style)this.FindResource("styBtnVerde"); ;
      objStyleOff = (Style)this.FindResource("styBtnRojo"); ;
    }

    private void loadStatus()
    {

      loadRequieredProcessesNames();

      AppSrvcsManager.getServicesState(ref argApplications
                , ref argServices);
      foreach (RequiredProcessStatus oRequiredProcessStatus in argApplications)
        if (oRequiredProcessStatus.IsRunning)
          oRequiredProcessStatus.Control.Style = objStyleOn;
        else
          oRequiredProcessStatus.Control.Style = objStyleOff;
      
      foreach (RequiredProcessStatus oRequiredProcessStatus in argServices)
        if (oRequiredProcessStatus.IsRunning)
          oRequiredProcessStatus.Control.Style = objStyleOn;
        else
          oRequiredProcessStatus.Control.Style = objStyleOff;
    }
    

    /// <summary>
    /// Carga los nombres de procesos y aplicaciones de los que se requieren saber
    /// los estados y pide los estados de los mismos.
    /// </summary>
    private void loadRequieredProcessesNames()
    {
      if (this.IsLoaded)
        return;
      oControls = new List<Control>() 
        { this.btnDimensionADQManager 
        , this.btnDimensionKernel
        , this.btnOPCDAServer};
      argApplications = new List<RequiredProcessStatus>();
      argServices = new List<RequiredProcessStatus>();

      foreach (Control oControl in oControls)
      {
        RequiredProcessStatus oRequiredProcessStatus = AppSrvcsManager.getRequiredProcessStatus(oControl);
                
        if (oRequiredProcessStatus.IsService)
        { argServices.Add(oRequiredProcessStatus); }
        else
        { argApplications.Add(oRequiredProcessStatus); }
      }
      IsLoaded = true;
    }

    #endregion Loaders

    

    

    

    

    
  }  
}
