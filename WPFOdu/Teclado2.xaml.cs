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
using log4net;
using dcf001;

using WPFiDU.BL;
using iDU.CommonObjects;

namespace WPFiDU
{
    /// <summary>
    /// Lógica de interacción para Teclado2.xaml
    /// </summary>
    public partial class Teclado2 : Window
    {
            private static readonly ILog logger = LogManager.GetLogger(typeof(Teclado2));
            public string Usuario;
            public sfUser sfUser = null;

        
            public Teclado2()
            {
                InitializeComponent();
                loadUsers();
            }
            
            private void loadUsers(){
              
              this.cmbUser.Items.Clear();
              
              ManagerUsuarios mManagerUsuarios = new ManagerUsuarios();
              List<string> users = mManagerUsuarios.ListUsers();


              for (int i = 0; i < users.Count; i++)
              {
                this.cmbUser.Items.Add(users[i]);

              }

              cmbUser.SelectedIndex = 0;
              mManagerUsuarios.Dispose();
              mManagerUsuarios=null;
            }            

            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
              if(this.sfUser==null)
                return;
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
              if (String.IsNullOrEmpty(txtPassword.Password))
                return;

              int iLen = txtPassword.Password.Length;

              if (iLen == 0)
                txtPassword.Password = "";

              txtPassword.Password = txtPassword.Password.Substring(0, iLen - 1);
              return;

            }

            private void button0_Click(object sender, RoutedEventArgs e)
            {
                txtPassword.Password = txtPassword.Password + "0";
                return;

            }

            private void buttonNumeral_Click(object sender, RoutedEventArgs e)
            {

              this.txtPassword.Password = "";

            }

            private void btnOK_Click(object sender, RoutedEventArgs e)
            {

              if (cmbUser.SelectedItem == null)
              {
                excepcion frm = new excepcion("Iniciar sesión", "Seleccione un Usuario.");
                frm.ShowDialog();
                frm=null;
                return;
              }

              if (String.IsNullOrEmpty(txtPassword.Password))
              {
                excepcion frm = new excepcion("Iniciar sesión", "Ingrese una contraseña válida.");
                frm.ShowDialog();
                frm = null;
                return;
              }

              ManagerUsuarios mManagerUsuarios = new ManagerUsuarios();
              sfUser msfUser = mManagerUsuarios.Login(cmbUser.SelectedItem.ToString(), txtPassword.Password);
              mManagerUsuarios.Dispose();
              mManagerUsuarios = null;

              this.sfUser = null;
              if (msfUser == null)
              {
                excepcion frm = new excepcion("Iniciar sesión", "Usuario y/o password incorrecto.");
                frm.ShowDialog();
                frm = null;
                logger.InfoFormat("El usuario '{0}' intentó ingresar al sistema con el password '{1}'.", this.cmbUser.Text, this.txtPassword.Password);
                this.txtPassword.Password="";
                log4net.GlobalContext.Properties["Username"] = "N/D";
                return;
              }

              this.sfUser = msfUser;
              this.Visibility = Visibility.Hidden;
              log4net.GlobalContext.Properties["Username"] = ManagerUsuarios.sfUser.sgu__username;
              logger.InfoFormat("El usuario '{0}' ingresó al sistema.", this.cmbUser.Text);
              
            }

            private void btnTecladoEnPantalla_Click(object sender, RoutedEventArgs e)
            {
                try
                {

                    System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start("osk");
                }
                catch (Exception ex)
                {
                  logger.Error("btnTecladoEnPantalla_Click()", ex);
                  //  logger.ErrorFormat(" btnTecladoEnPantalla_Click Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                  //, ex.Message
                  //, ex.StackTrace
                  //, ex.InnerException != null ? ex.InnerException.Message : "");
                    excepcion formularioexcepciones = new excepcion(ex);
                    formularioexcepciones.ShowDialog();
                }
            }

            private void btnRefresh_Click(object sender, RoutedEventArgs e)
            {
              loadUsers();
            }

            
            private void image1_MouseDown(object sender, MouseButtonEventArgs e)
            {
              //if (String.IsNullOrEmpty(this.txtPassword.Password))
              //  return;
              //if (String.IsNullOrEmpty(this.txtPassword.Password.Trim()))
              //  return;
              
              //this.txtPassword.Password = this.txtPassword.Password.Substring(0, (this.txtPassword.Password.Length-1));
            }


        }
    
}
