using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace dcf001
{
	public partial class confirmacioneliminar 
	{
    public bool SI = false;

    public confirmacioneliminar(string titulo, string mensajeamostrar)
		{
			this.InitializeComponent();

      this.Window.AllowsTransparency = WPFiDU.Utils.Utils.Window_AllowsTransparency;
      
      SI = false;
      lblTitleEliminar.Content = titulo;
      lblTexto.Content         = mensajeamostrar;
           
		}

    public confirmacioneliminar(string mensajeamostrar)
    {
      this.InitializeComponent();
      SI = false;
      lblTitleEliminar.Content = "";
      lblTexto.Content = mensajeamostrar;
   }

    public static bool Show(string titulo, string mensajeamostrar)
    {
      confirmacioneliminar msg = new confirmacioneliminar(titulo, mensajeamostrar);
      msg.ShowDialog();
      return msg.SI;
    }

    public static bool Show(string mensajeamostrar)
    {
      confirmacioneliminar msg = new confirmacioneliminar(mensajeamostrar);
      msg.Topmost = true;
      msg.btnCancelar.Visibility = Visibility.Hidden;
      msg.btnNo.Visibility = Visibility.Hidden;
      msg.btnSi.FontSize = 20;
      msg.btnSi.Content = "Salir";
      
      msg.ShowDialog();
      return msg.SI;
    }

    public static bool Show2(string mensajeamostrar)
    {
      confirmacioneliminar msg = new confirmacioneliminar(mensajeamostrar);
      msg.btnCancelar.Visibility = Visibility.Hidden;
      msg.btnSi.FontSize = 20;
      msg.btnNo.FontSize = 20;

      msg.ShowDialog();
      return msg.SI;
    }
        
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void btnCancelar_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void btnNo_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void btnSi_Click(object sender, RoutedEventArgs e)
    {
      SI = true;
      this.Close();
    }
	}
}