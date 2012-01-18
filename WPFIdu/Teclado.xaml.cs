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
using dcf001;

namespace WPFiDU
{
    /// <summary>
    /// Lógica de interacción para Teclado.xaml
    /// </summary>
    public partial class Teclado : Window
    {

        public string TextoPassword
        {
            get { return txtPassword.Password;}
            set {txtPassword.Password =value;}

        }
        public string Texto 
        {
            get { return lblPassword.Content.ToString(); }
            set {lblPassword.Content = value; }
        }

        private string mPassword;

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        
        public Teclado()
        {
            InitializeComponent();
            
            
        }


        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
            this.Visibility = Visibility.Hidden;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
           
                txtPassword.Password = txtPassword.Password + "1";
                return;
           

          
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtPassword.Password + "2";
            
           
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
          
                txtPassword.Password = txtPassword.Password + "3";
                return;
           
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
                txtPassword.Password = txtPassword.Password + "4";
                return;
            

          
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
           
                txtPassword.Password = txtPassword.Password + "5";
                return;
          
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            
                txtPassword.Password = txtPassword.Password + "6";
                return;
          
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
          
                txtPassword.Password = txtPassword.Password + "7";
                return;
         
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
                txtPassword.Password = txtPassword.Password + "8";
                return;
          
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
                txtPassword.Password = txtPassword.Password + "9";
                return;
            
        }

        private void buttonAst_Click(object sender, RoutedEventArgs e)
        {
            
                txtPassword.Password = txtPassword.Password + "*";
                return;
           
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
                txtPassword.Password = txtPassword.Password + "0";
                return;
         
        }

        private void buttonNumeral_Click(object sender, RoutedEventArgs e)
        {
            
                txtPassword.Password = txtPassword.Password + "1";
                return;
           
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Password = txtPassword.Password;
            //this.Close();
            this.Visibility = Visibility.Hidden;
        }

        private void btnTecladoEnPantalla_Click(object sender, RoutedEventArgs e)
        {
          try
          {

            System.Diagnostics.Process myProcess
              = System.Diagnostics.Process.Start("osk");
          }
          catch (Exception ex)
          {
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
          }
        }

       
    }
}
