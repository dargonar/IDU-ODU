using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace dcf001
{
	public partial class excepcion
	{
		public excepcion(Exception ex)
		{
			this.InitializeComponent();
            lblTexto.Content = ex.Message;
			
			// Insert code required on object creation below this point.
		}

    public excepcion(string title, string message)
    {
      this.InitializeComponent();
      lblTexto.Content = message;
      lblTitleEliminar.Content = title;

      // Insert code required on object creation below this point.
    }

    public excepcion(string title, string message, bool isOk)
    {
      this.InitializeComponent();
      lblTexto.Content = message;
      lblTitleEliminar.Content = title;

      this.btnClose.Style = (Style)this.btnClose.FindResource("styBtnVerde");
    }
        public excepcion(MySql.Data.MySqlClient.MySqlException ex)
        {
            this.InitializeComponent();
            //-2147467259
            if (ex.ErrorCode == -2147467259)
                lblTexto.Content = "No se puede eliminar el registro debido a que esta siendo utilizado en otro lugar";
            else
            {
                lblTexto.Content = ex.Message;
                lblTexto.ToolTip = ex.Message;
            }
            
            // Insert code required on object creation below this point.
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private DispatcherTimer intervalTimer = new DispatcherTimer();
        public void ShowAndDie(int secs)
        {
          this.Show();
          if (secs == 0)
            secs = 3;
          intervalTimer.Interval = new TimeSpan(0, 0, secs);
          intervalTimer.Tick += new EventHandler(TimerTickHandler);
          intervalTimer.Start();
        }

        private void TimerTickHandler(object source, EventArgs e)
        {
          intervalTimer.Stop();
          intervalTimer = null;
          Dispatcher.Invoke(DispatcherPriority.Normal, new EventHandler(CloseWindowHandler), source, e);
        }

        void CloseWindowHandler(object source, EventArgs e)
        {
          this.Close();
        }
	}
}