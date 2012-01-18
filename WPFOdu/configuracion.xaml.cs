using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iDU.BL;
using iDU.CommonObjects;
using System.Drawing.Printing;
using log4net;
using WPFiDU.BL;
using WPFiDU.CommonObjects;
using WPFiDU;
using System.Configuration;

namespace dcf001
{
	public partial class configuracion
	{

    private ConfiguracionManager configurador;
    private static readonly ILog logger = LogManager.GetLogger(typeof(configuracion));
    private bool mEsidu = false;
    
    public const string NRO_SERIE_AUTO_GENERADO ="AUTO GENERADO";
    public const string NRO_SERIE_LEIDO_POR_SCANNER =  "LEIDO POR SCANNER" ;

		public configuracion(bool esidu)
		{
            this.InitializeComponent();
            if (!esidu)
            {
                txtTempMax.Visibility = System.Windows.Visibility.Visible;
                txtTempMin.Visibility = System.Windows.Visibility.Visible;
            }
            else
                mEsidu = true;
            configurador = new ConfiguracionManager();
            CargarTextBox();
		}

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            this.Close();
            
        }

        private void CargarTextBox()
        {

            try
            {

                txtCadena.Text = configurador.ObtenerCadenaDeConexion();
                NumeroDeSerieManager numserieman = new NumeroDeSerieManager();
                NumeroDeSerie numseriea = numserieman.ObtenerConfiguracionNumeroDeSerie(1);
                NumeroDeSerie numserienoa = numserieman.ObtenerConfiguracionNumeroDeSerie(2);

                txtPrefijoId.Text = numserienoa.Prefijo;
                txtPrefijoNum.Text = numseriea.Prefijo;
                txtSufijoId.Text = numserienoa.Sufijo.ToString();
                txtSufijoNum.Text = numseriea.Sufijo.ToString();
                txtMinimoNum.Text = numseriea.Minimo.ToString();
                txtMaximoNum.Text = numseriea.Maximo.ToString();
                txtMaximoId.Text = numserienoa.Maximo.ToString();
                txtMinimoId.Text = numserienoa.Minimo.ToString();
                
                String pkInstalledPrinters;
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                    cmbImpresora1.Items.Add(pkInstalledPrinters);
                    cmbImpresora2.Items.Add(pkInstalledPrinters);
                }

                cmbImpresora1.Text = configurador.ObtenerImpresoraProducto();
                cmbImpresora2.Text = configurador.ObtenerImpresoraBulto();

                cmbImpresora1.IsEnabled = configurador.ObtenerImpresoraProductoHabilitada ();
                cmbImpresora2.IsEnabled = configurador.ObtenerImpresoraBultoHabilitada();


                if (!mEsidu)
                {
                    txtTempMax.Text = ConfigurationManager.AppSettings["TEMP_MAX"];
                    txtTempMin.Text = ConfigurationManager.AppSettings["TEMP_MIN"];
                }
                this.cmbPrintErrorTests.Items.Clear();
                this.cmbPrintErrorTests.Items.Add("SI");
                this.cmbPrintErrorTests.Items.Add("NO");

                if (configurador.ObtenerPrintErrorTests())
                  this.cmbPrintErrorTests.SelectedIndex = 0;
                else
                  this.cmbPrintErrorTests.SelectedIndex = 1;
        

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("CargarTextBox:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();

            }

            this.cmbNroSerie.Items.Clear();
            this.cmbNroSerie.Items.Add(NRO_SERIE_AUTO_GENERADO);
            this.cmbNroSerie.Items.Add(NRO_SERIE_LEIDO_POR_SCANNER);

          if (configurador.ReadSerialNumberFromScanner )
            this.cmbNroSerie.SelectedIndex = 1;
          else
            this.cmbNroSerie.SelectedIndex = 0;

        }

        private void btnProbarConexion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (configurador.ProbarConexion(txtCadena.Text))
            {
                confirmacioneliminar.Show("Conexion OK");
            }
            else
            {
                confirmacioneliminar.Show("Error en la conexion");
            }
        }

        private void btnGuardarCambios_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Administrador))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          } 
          
          try
            {


                if ((!mEsidu) && (txtTempMax.Text.Equals(string.Empty) || txtTempMin.Equals(string.Empty)))
                {
                    confirmacioneliminar.Show("Debe ingresar valores de temperatura maxima y minima");
                    return;
                }


                //Guardamos toda la configuracion

                NumeroDeSerie seriea = new NumeroDeSerie();
                seriea.Maximo=int.Parse(txtMaximoNum.Text);
                seriea.Minimo=int.Parse(txtMinimoNum.Text);
                seriea.Prefijo=txtPrefijoNum.Text;
                seriea.Sufijo=int.Parse(txtSufijoNum.Text);
                
                NumeroDeSerie serienoa = new NumeroDeSerie();
                serienoa.Maximo = int.Parse(txtMaximoId.Text);
                serienoa.Minimo = int.Parse(txtMinimoId.Text);
                serienoa.Prefijo = txtPrefijoId.Text;
                serienoa.Sufijo = int.Parse(txtSufijoId.Text);
                
                NumeroDeSerieManager numserieman = new NumeroDeSerieManager();
                


                numserieman.ModificarNumeroDeSerie(seriea, 1);
                numserieman.ModificarNumeroDeSerie(serienoa, 2);
                configurador.SetearCadenaDeConexion(txtCadena.Text);
                configurador.ReadSerialNumberFromScanner = cmbNroSerie.SelectedIndex == 1;
       

                if (cmbImpresora2.SelectedIndex != -1)
                    configurador.SetearImpresoraBulto(
                      cmbImpresora2.SelectedItem.ToString());

                if (cmbImpresora1.SelectedIndex != -1)
                    configurador.SetearImpresoraProducto(cmbImpresora1.SelectedItem.ToString());

                if (!mEsidu)
                {
                    configurador.SetearTempMin(txtTempMin.Text);
                    configurador.SetearTempMax(txtTempMax.Text);

                }


                configurador.GuardarConfiguracion();

                confirmacioneliminar.Show("Cambios Guardados satisfactoriamente!");
                this.DialogResult = true;
                //this.Close();
            }

           catch (Exception ex)
            {
                logger.ErrorFormat("btnGuardarCambios_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
                this.DialogResult = false; 
           }
        }

        private void VaciarTextBox()
        {
            txtPrefijoNum.Text = "";
            txtPrefijoId.Text = "";
            txtSufijoNum.Text = "";
            txtSufijoId.Text = "";
            txtMaximoId.Text = "";
            txtMaximoNum.Text = "";
            txtMinimoId.Text = "";
            txtMinimoNum.Text = "";
            cmbImpresora1.IsEnabled = false;
            cmbImpresora2.IsEnabled = false;
            tgbImpresora1.IsEnabled = false;
            tgbImpresora2.IsEnabled = false;


        }

        private void tgbImpresora1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cmbImpresora1.IsEnabled = !cmbImpresora1.IsEnabled;
            configurador.SetearImpresoraProductoHabilitada(cmbImpresora1.IsEnabled);
            
        }

        private void tgbImpresora2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            cmbImpresora2.IsEnabled = !cmbImpresora2.IsEnabled;
            configurador.SetearImpresoraBultoHabilitada(cmbImpresora2.IsEnabled);
        }

        private void btnPassAdm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {


                ManagerUsuarios manag_usuarios = new ManagerUsuarios();


                Teclado tec = new Teclado();
                tec.Texto = "Password viejo";

                tec.ShowDialog();
                string pass1 = tec.Password;

                tec.TextoPassword = "";

                tec.Texto = "Password nuevo";
                tec.ShowDialog();

                string pass2 = tec.Password;

                tec.TextoPassword = "";

                tec.Texto = "Retipear Password";
                tec.ShowDialog();
                string pass3 = tec.Password;



                if ((pass1 != manag_usuarios.ObtenerPasswordUsuario("ADMINISTRADOR")) || (pass2 != pass3))
                {
                    confirmacioneliminar.Show("Password incorrecto");
                    return;
                }
                else
                {

                    manag_usuarios.SetearPasswordUsuario(pass2, "ADMINISTRADOR");
                }
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnPassAdm_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private void btnPassSupAdm_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {

                ManagerUsuarios manag_usuarios = new ManagerUsuarios();

                Teclado tec = new Teclado();
                tec.Texto = "Password viejo";

                tec.ShowDialog();
                string pass1 = tec.Password;

                tec.TextoPassword = "";

                tec.Texto = "Password nuevo";
                tec.ShowDialog();

                string pass2 = tec.Password;

                tec.TextoPassword = "";

                tec.Texto = "Retipear Password";
                tec.ShowDialog();
                string pass3 = tec.Password;



                if ((pass1 != manag_usuarios.ObtenerPasswordUsuario("SUPERADMINISTRADOR")) || (pass2 != pass3))
                {
                    confirmacioneliminar.Show("Password incorrecto");
                    return;
                }
                else
                {

                    manag_usuarios.SetearPasswordUsuario(pass2, "SUPERADMINISTRADOR");
                }
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnPassSupAdm_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private void btnTeclado_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {

                System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start("osk");
            }
            catch (Exception ex)
            {
                logger.ErrorFormat(" btnTeclado_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
        }

       
    }
}




