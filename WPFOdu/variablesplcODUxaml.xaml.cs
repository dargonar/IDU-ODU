using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU.BL;
using iDU.PLC;
using System.Collections.Generic;
using iDU;
using log4net;
using WPFiDU;

namespace dcf001
{
	public partial class variablesplcodu
	{
        private static readonly ILog logger = LogManager.GetLogger(typeof(variablesplcodu));
        PLCODU clienteopc = new PLCODU();
		
        public variablesplcodu()
		    {
			    this.InitializeComponent();
                InicializarLista();
    			
    			
		    }

        private void InicializarLista()
        {
            try
            {

                VariablesPLCManager managerplc = new VariablesPLCManager();
                List<VariablePLC> listavariables = managerplc.ObtenerNombresVariables();

                
                for (int i = 0; i < listavariables.Count; i++)
                {
                    ltbVariables.Items.Add(listavariables[i]);

                }

            }

            catch (Exception ex)
            {
                logger.ErrorFormat("InicializarLista():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                  , ex.Message
                  , ex.StackTrace
                  , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexepcion = new excepcion(ex);
                formexepcion.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ltbVariables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (ltbVariables.SelectedIndex < 0)
                    return;

                VariablePLC variableseleccionada = ltbVariables.SelectedItem as VariablePLC;
                txtNombre.Text = variableseleccionada.NombreVariable;

                for (int i = 0; i < ltbVariables.Items.Count; i++)
                {
                    if (ltbVariables.Items[i].ToString() == variableseleccionada.TipoDeDato)
                    {

                        ltbVariables.SelectedIndex = i;
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("ltbVariables_SelectionChanged(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
            , ex.Message
            , ex.StackTrace
            , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexepcion = new excepcion(ex);
                formexepcion.ShowDialog();
            }
        }

        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {
            
         
            try
            {
              string value = clienteopc.LeerItem(txtNombre.Text);
              double dbl = double.Parse(value);
              txtValor.RawText = dbl.ToString(txtValor.mNumberFormat);
                
               
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnLeer_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
                 excepcion formexepcion = new excepcion(ex);
                formexepcion.ShowDialog();
            }
             
        }

        private void btnEscribir_Click(object sender, RoutedEventArgs e)
        {
            
          try
          {
            btnEscribir.Cursor = System.Windows.Input.Cursors.Wait;
            PLCODU clienteopc = new PLCODU();
            VariablePLC variableseleccionada = new VariablePLC();
            variableseleccionada.NombreVariable = txtNombre.Text;

            double value = 0;
            if(Convert.ToDouble("1.1") > Convert.ToDouble("1,1"))
              value = Convert.ToDouble(txtValor.RawText.Replace('.', ',')); 
            else
              value = Convert.ToDouble(txtValor.RawText.Replace(',', '.')); 

            clienteopc.Escribir(variableseleccionada.NombreVariable, value);
            clienteopc.Dispose();
            btnEscribir.Cursor = System.Windows.Input.Cursors.Arrow;
          }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnEscribir_Click():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexepcion = new excepcion(ex);
                formexepcion.ShowDialog();
            }
             
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clienteopc.Dispose();
        }

        private void btnTeclado_Click(object sender, RoutedEventArgs e)
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

        //clienteopc.Dispose();


    }
}






