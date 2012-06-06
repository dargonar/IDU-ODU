using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Forms;
using iDU.BL;
using iDU.CommonObjects;
using System.Collections.Generic;
using log4net;

using System.Threading;
using System.Text;

namespace dcf001
{
    public partial class ajusteparametrosidu
    {
        private ParametrosManager ManejadorParametros;
        private static readonly ILog logger = LogManager.GetLogger(typeof(ajusteparametrosidu));

        public ajusteparametrosidu()
        {
            this.InitializeComponent();
            ManejadorParametros = new ParametrosManager();
            LlenarComboBoxVersiones();
            InicializarToolTips();
        }

        private void InicializarToolTips()
        {
            System.Windows.Controls.ToolTip t1 = new System.Windows.Controls.ToolTip();
            t1.Content = "IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaTension";
            txtCorrBajaTensionMax.ToolTip=t1;

            System.Windows.Controls.ToolTip t2 = new System.Windows.Controls.ToolTip();
            t2.Content = "IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaTension";
            txtCorrBajaTensionMin.ToolTip=t2;

           

            System.Windows.Controls.ToolTip t3 = new System.Windows.Controls.ToolTip();
            t3.Content = "IDU_SP_MinimaCorrienteAdmisibleEnsayoAltaVelocidad";
            txtCorrienteHIGHMin.ToolTip=t3;

            System.Windows.Controls.ToolTip t4 = new System.Windows.Controls.ToolTip();
            t4.Content = "IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaVelocidad";
            txtCorrienteLOWMax.ToolTip=t4;
          
            System.Windows.Controls.ToolTip t5 = new System.Windows.Controls.ToolTip();
            t5.Content = "IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaVelocidad";
            txtCorrienteLOWMin.ToolTip = t5;


            System.Windows.Controls.ToolTip t6 = new System.Windows.Controls.ToolTip();
            t6.Content = "IDU_SP_TiempoEnsayoBajaVelocidad";
            txtEnsayoLOW.ToolTip=t6;

            System.Windows.Controls.ToolTip t7 = new System.Windows.Controls.ToolTip();
            t7.Content = "IDU_SP_TiempoRetardoFinalizacionEnsayo";
            txtFinal.ToolTip = t7;

            System.Windows.Controls.ToolTip t8 = new System.Windows.Controls.ToolTip();
            t8.Content = "IDU_SP_TiempoEnsayoAltaVelocidad";
            txtlEnsayoHIGH.ToolTip=t8;

            
            System.Windows.Controls.ToolTip t9 = new System.Windows.Controls.ToolTip();
            t9.Content = "IDU_SP_TiempoRetardoAvisoFinal";
            txtRetardoDesenerg.ToolTip=t9;
            
            System.Windows.Controls.ToolTip t10 = new System.Windows.Controls.ToolTip();
            t10.Content = "IDU_SP_RetardoComandoInicialMitad";
            txtRetardoStart12.ToolTip = t10;

            System.Windows.Controls.ToolTip t11 = new System.Windows.Controls.ToolTip();
            t11.Content = "IDU_SP_TiempoRetardoComandoBajaTension";
            txtRetardoStart2BT.ToolTip = t11;
            
            System.Windows.Controls.ToolTip t12 = new System.Windows.Controls.ToolTip();
            t12.Content = "IDU_SP_RetardoComandoInicial4";
            txtRetardoStopInicial.ToolTip = t12;
            
            
            System.Windows.Controls.ToolTip t13 = new System.Windows.Controls.ToolTip();
            t13.Content = "TiempoApagadoCalorFrio";
            txtTIDUentreCyF.ToolTip = t13;
            
            
            System.Windows.Controls.ToolTip t14 = new System.Windows.Controls.ToolTip();
            t14.Content = "IDU_SP_TimeoutEnsayoBajaTension";
            txtTimeoutBajaTension.ToolTip = t14;
            
            System.Windows.Controls.ToolTip t15 = new System.Windows.Controls.ToolTip();
            t15.Content = "IDU_SP_TimeoutArranqueInicialCalor";
            txtTOArranqueC.ToolTip = t15;
            
            
            System.Windows.Controls.ToolTip t16 = new System.Windows.Controls.ToolTip();
            t16.Content = "IDU_SP_TimeoutArranqueInicialFrio";
            txtTOArranqueF.ToolTip = t16;
            
            
            System.Windows.Controls.ToolTip t17 = new System.Windows.Controls.ToolTip();
            t17.Content = "IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaTension";
            txtVelBajaTensionMax.ToolTip = t17;
            
            
            System.Windows.Controls.ToolTip t18 = new System.Windows.Controls.ToolTip();
            t18.Content = "IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaTension";
            txtVelBajaTensionMin.ToolTip = t18;

            System.Windows.Controls.ToolTip t19 = new System.Windows.Controls.ToolTip();
            t19.Content = "IDU_SP_MaximaVelocidadAdmisibleEnsayoAltaVelocidad";
            txtVelocidadHIGHMax.ToolTip = t19;



            System.Windows.Controls.ToolTip t20 = new System.Windows.Controls.ToolTip();
            t20.Content = "IDU_SP_MinimaVelocidadAdmisibleEnsayoAltaVelocidad";
            txtVelocidadHIGHMin.ToolTip = t20;


            System.Windows.Controls.ToolTip t21 = new System.Windows.Controls.ToolTip();
            t21.Content = "IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaVelocidad";
            txtVelocidadLOWMax.ToolTip = t21;


            System.Windows.Controls.ToolTip t22 = new System.Windows.Controls.ToolTip();
            t22.Content = "IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaVelocidad";
            txtVelocidadLOWMin.ToolTip = t22;

            System.Windows.Controls.ToolTip t23 = new System.Windows.Controls.ToolTip();
            t23.Content = "IDU_SP_MaximaCorrienteAdmisibleEnsayoAltaVelocidad";
            txtCorrienteHIGHMax.ToolTip = t23;

            
     
            
            
            
            
            
            
           

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ManejadorParametros != null)
                    ManejadorParametros.Dispose();

                this.Close();
            }
            catch(Exception ex)
            {
                logger.ErrorFormat("btnClose_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
            }
        }

        private void LlenarComboBoxVersiones()
        {
            try
            {

                VersionEquiposManager ManagerVersiones = new VersionEquiposManager();
                List<VersionEquipo> ListaVersiones = ManagerVersiones.ObtenerVersiones();


                for (int i = 0; i < ListaVersiones.Count; i++)
                {
                    cmbVersion.Items.Add(ListaVersiones[i]);

                }

                cmbVersion.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("LlenarComboBoxVersiones():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }

        }

        private void btnArchivoAbrir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog selectorarchivo = new OpenFileDialog();
                DialogResult resultado = selectorarchivo.ShowDialog();
                string nombreArchivo;

                if (resultado == System.Windows.Forms.DialogResult.Cancel)
                    return;
                nombreArchivo = selectorarchivo.FileName;

                ParametrosEnsayoIDU paridu = ManejadorParametros.LeerParametrosDeArchivo(nombreArchivo) as ParametrosEnsayoIDU;
                LeerDeObjeto(paridu);
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnArchivoAbrir_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private void LeerDeObjeto(ParametrosEnsayoIDU paridu)
        {
            
            txtCorrBajaTensionMax.Text = paridu.Corrientebajatensionmax.ToString();
            txtCorrBajaTensionMin.Text = paridu.Corrientebajatensionmin.ToString();
            txtCorrienteHIGHMax.Text = paridu.Corrientemaxmodovelalta.ToString();
            txtCorrienteHIGHMin.Text = paridu.CorrienteMinModoVelAlta.ToString();
            txtCorrienteLOWMax.Text = paridu.Corrientemaxmodovelbaja.ToString();
            txtCorrienteLOWMin.Text = paridu.CorrienteMinModoVelBaja.ToString();
            txtDescripcion.Text = paridu.Descripcion;
            txtEnsayoLOW.Text = paridu.Tiempomodovelocidadbaja.ToString();
            txtFinal.Text = paridu.Final.ToString();
            txtIDenDCF.Text = paridu.ID.ToString();
            txtlEnsayoHIGH.Text = paridu.Tiempomodovelocidadalta.ToString();
      
            txtRetardoDesenerg.Text = paridu.Retardodesenergizado.ToString();
            txtRetardoStart12.Text = paridu.Retardostarmitad.ToString();
            txtRetardoStart2BT.Text = paridu.Retardostart2bajatension.ToString();
            txtRetardoStopInicial.Text = paridu.Retardostopinicial.ToString();
            txtTIDUentreCyF.Text = paridu.TiempoApagadoCalorFrio.ToString();
            txtTOArranqueC.Text = paridu.Timeoutcalor.ToString();
            txtTOArranqueF.Text = paridu.Timeoutfrio.ToString();
            txtVelBajaTensionMax.Text = paridu.Velocidadbajatensionmax.ToString();
            txtVelBajaTensionMin.Text = paridu.Velocidadbajatensionmin.ToString();
            txtVelocidadHIGHMax.Text = paridu.Velocidadmaxmodovelalta.ToString();
            txtVelocidadHIGHMin.Text = paridu.Velocidadminmodovelalta.ToString();
            txtVelocidadLOWMax.Text = paridu.Velocidadmaxmodovelbaja.ToString();
            txtVelocidadLOWMin.Text = paridu.Velocidadminmodovelbaja.ToString();
            txtTimeoutBajaTension.Text = paridu.TiempoMaximoBajaTension.ToString();

            for (int i = 0; i < cmbVersion.Items.Count; i++)
            {
                if (((VersionEquipo)cmbVersion.Items[i]).ID == paridu.IdVersion)
                {
                    cmbVersion.SelectedIndex = i;
                    break;
                }



            }
        }

        private void btnArchivoGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog selectorarchivo = new SaveFileDialog();
                DialogResult resultado = selectorarchivo.ShowDialog();
                string nombreArchivo;

                selectorarchivo.CheckFileExists = false;

                if (resultado == System.Windows.Forms.DialogResult.Cancel)
                    return;


                nombreArchivo = selectorarchivo.FileName;


                ParametrosEnsayoIDU paridu = GuardarDatosEnObjeto();
                ManejadorParametros.GuardarParametrosEnArchivo(paridu, nombreArchivo);
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnArchivoGuardar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private string getRawData()
        {
            
            StringBuilder str = new StringBuilder();
            
            str.AppendFormat("'{1}':{0}; ",txtVelocidadLOWMin.RawText,lblVelocidadLOW.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtVelocidadLOWMax.RawText, lblVelocidadLOW.Content + " máxima"); 
            str.AppendFormat("'{1}':{0}; ", txtVelocidadHIGHMin.RawText, lblVelocidadHIGH.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtVelocidadHIGHMax.RawText, lblVelocidadHIGH.Content + " máxima");
            str.AppendFormat("'{1}':{0}; ", txtVelBajaTensionMin.RawText, lblVelBajaTension.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtVelBajaTensionMax.RawText, lblVelBajaTension.Content + " máxima");
            str.AppendFormat("'{1}':{0}; ",txtTOArranqueF.RawText,lblTOArranqueF.Content);
            str.AppendFormat("'{1}':{0}; ", txtTOArranqueC.RawText, lblTOArranqueC.Content);
            str.AppendFormat("'{1}':{0}; ", txtEnsayoLOW.RawText, lblEnsayoLOW.Content);
            str.AppendFormat("'{1}':{0}; ", txtlEnsayoHIGH.RawText, lblEnsayoHIGH.Content);
            str.AppendFormat("'{1}':{0}; ", txtTIDUentreCyF.RawText, lblTIDUentreCyF.Content);
            str.AppendFormat("'{1}':{0}; ", txtRetardoStopInicial.RawText, lblRetardoStopInicial.Content);
            str.AppendFormat("'{1}':{0}; ", txtRetardoStart2BT.RawText, lblRetardoStart2BT.Content);
            str.AppendFormat("'{1}':{0}; ", txtRetardoStart12.RawText, lblRetardoStart12.Content);
            str.AppendFormat("'{1}':{0}; ", txtRetardoDesenerg.RawText, lblRetardoDesenerg.Content);
            str.AppendFormat("'{1}':{0}; ", txtFinal.RawText,lblFinal.Content);
            str.AppendFormat("'{1}':{0}; ", txtDescripcion.Text==null?"":txtDescripcion.Text, lblDescripcion.Content);
            str.AppendFormat("'{1}':{0}; ", txtCorrienteLOWMin.RawText, lblCorrienteLOW.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtCorrienteLOWMax.RawText, lblCorrienteLOW.Content + " máxima");
            str.AppendFormat("'{1}':{0}; ", txtCorrienteHIGHMin.RawText, lblCorrienteHIGH.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtCorrienteHIGHMax.RawText, lblCorrienteHIGH.Content + " máxima");
            str.AppendFormat("'{1}':{0}; ", txtCorrBajaTensionMin.RawText, lblCorrBajaTension.Content + " mínima");
            str.AppendFormat("'{1}':{0}; ", txtCorrBajaTensionMax.RawText, lblCorrBajaTension.Content + " máxima");
            str.AppendFormat("'{1}':{0}; ",txtTimeoutBajaTension.RawText,lblTimeoutBajaTension.Content);
            str.AppendFormat("'{1}':{0}; ",((VersionEquipo)cmbVersion.SelectedItem).Descripcion, lblVersion.Content);

            return str.ToString();

        }
        private ParametrosEnsayoIDU GuardarDatosEnObjeto()
        {

            ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();
     
            ForEachControlRecursive(this, VericarValorNulo);

            paridu.Referencia = txtDescripcion.Text.Trim();
            paridu.Velocidadminmodovelbaja = int.Parse(txtVelocidadLOWMin.Text);
            paridu.Velocidadminmodovelalta = int.Parse(txtVelocidadHIGHMin.Text);
            paridu.Velocidadmaxmodovelbaja = int.Parse(txtVelocidadLOWMax.Text);
            paridu.Velocidadmaxmodovelalta = int.Parse(txtVelocidadHIGHMax.Text);
            paridu.Velocidadbajatensionmin = int.Parse(txtVelBajaTensionMin.Text);
            paridu.Velocidadbajatensionmax = int.Parse(txtVelBajaTensionMax.Text);
            paridu.Timeoutfrio = int.Parse(txtTOArranqueF.Text);
            paridu.Timeoutcalor = int.Parse(txtTOArranqueC.Text);
            paridu.Tiempomodovelocidadbaja = int.Parse(txtEnsayoLOW.Text);
            paridu.Tiempomodovelocidadalta = int.Parse(txtlEnsayoHIGH.Text);
            paridu.TiempoApagadoCalorFrio = int.Parse(txtTIDUentreCyF.Text);
            paridu.Retardostopinicial = int.Parse(txtRetardoStopInicial.Text);
            paridu.Retardostart2bajatension = int.Parse(txtRetardoStart2BT.Text);
            paridu.Retardostarmitad = int.Parse(txtRetardoStart12.Text);
            paridu.Retardodesenergizado = int.Parse(txtRetardoDesenerg.Text);
     
            paridu.Modificado = DateTime.Now;
            //   paridu.ID = int.Parse(txtIDenDCF.Text) ;
            paridu.Final = int.Parse(txtFinal.Text);
            paridu.Descripcion = txtDescripcion.Text;
            // paridu.DCFs = txtIDenDCF.Text ;
            paridu.CorrienteMinModoVelBaja = int.Parse(txtCorrienteLOWMin.Text);
            paridu.CorrienteMinModoVelAlta = int.Parse(txtCorrienteHIGHMin.Text);
            paridu.Corrientemaxmodovelbaja = int.Parse(txtCorrienteLOWMax.Text);
            paridu.Corrientemaxmodovelalta = int.Parse(txtCorrienteHIGHMax.Text);
            paridu.Corrientebajatensionmin = int.Parse(txtCorrBajaTensionMin.Text);
            paridu.Corrientebajatensionmax = int.Parse(txtCorrBajaTensionMax.Text);
            paridu.TiempoMaximoBajaTension = int.Parse(txtTimeoutBajaTension.Text);
            paridu.IdVersion = ((VersionEquipo)cmbVersion.SelectedItem).ID;

            return paridu;

        }

        private void btnPLCLeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                LeerDePLC();
                txtDescripcion.Text = "";
             
                txtIDenDCF.Text = "0";

            }

            catch (Exception ex)
            {

                logger.ErrorFormat("btnPLCLeer_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");


                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private void LeerDePLC()
        {

            ParametrosEnsayoIDU param = ManejadorParametros.LeerParametrosDePLC() as ParametrosEnsayoIDU;
            
            txtRetardoDesenerg.Text = param.Retardodesenergizado.ToString();
            txtRetardoStopInicial.Text = param.Retardostopinicial.ToString();
            txtRetardoStart12.Text = param.Retardostarmitad.ToString();
            txtTOArranqueF.Text = param.Timeoutfrio.ToString();
            txtTOArranqueC.Text = param.Timeoutcalor.ToString();
            txtRetardoStart2BT.Text = param.Retardostart2bajatension.ToString();
            txtEnsayoLOW.Text = param.Tiempomodovelocidadbaja.ToString();
            txtlEnsayoHIGH.Text = param.Tiempomodovelocidadalta.ToString();
            txtFinal.Text = param.Final.ToString();
            txtTIDUentreCyF.Text = param.TiempoApagadoCalorFrio.ToString();
            txtVelBajaTensionMin.Text = param.Velocidadbajatensionmin.ToString();
            txtVelBajaTensionMax.Text = param.Velocidadbajatensionmax.ToString();
            txtCorrBajaTensionMin.Text = param.Corrientebajatensionmin.ToString();
            txtCorrBajaTensionMax.Text = param.Corrientebajatensionmax.ToString();
            txtVelocidadLOWMin.Text = param.Velocidadminmodovelbaja.ToString();
            txtVelocidadLOWMax.Text = param.Velocidadmaxmodovelbaja.ToString();
            txtCorrienteLOWMin.Text = param.CorrienteMinModoVelBaja.ToString();
            txtCorrienteLOWMax.Text = param.Corrientemaxmodovelbaja.ToString();
            txtVelocidadHIGHMin.Text = param.Velocidadminmodovelalta.ToString();
            txtVelocidadHIGHMax.Text = param.Velocidadmaxmodovelalta.ToString();
            txtCorrienteHIGHMin.Text = param.CorrienteMinModoVelAlta.ToString();
            txtCorrienteHIGHMax.Text = param.Corrientemaxmodovelalta.ToString();
            txtTimeoutBajaTension.Text = param.TiempoMaximoBajaTension.ToString();

            int mIdVersion = param.IdVersion ;
            for (int i = 0; i < cmbVersion.Items.Count; i++)
            {
              if (((VersionEquipo)cmbVersion.Items[i]).ID == mIdVersion)
              {
                cmbVersion.SelectedIndex = i;
                break;
              }
            }


            logger.DebugFormat("LeerDePLC():: retardodesenergizado:'{0}',retardostopinicial'{1}'," +
                "retardostartmitad'{2}', timeoutfrio '{3}',timeoutcalor'{4}',retardostart2bajatension'{5}'," +
                "tiempomodovelocidadbaja'{6}',tiempomodovelocidadalta'{7}',final'{8}',tiempoapagadoentrecaloryfrio'{9}'" +
                "velocidadbajatensionmin'{10}',velocidadbajatensionmax'{11}',corrientebajatensionmin'{12}',corrientebajatensionmax'{13}'" +
                "velocidadminmodovelbaja'{14}',velocidadmaxmodovelbaja'{15}',corrienteminmodovelbaja'{16}'" +
                "corrientemaxmodovelbaja'{17}',velocidadminmodovelalta'{18}',velocidadmaxmodovelalta'{19}',corrientemaxmodovelalta'{20}' tiempomaximobajatension {21}",
                param.Retardodesenergizado.ToString(), param.Retardostopinicial.ToString(),
                param.Retardostarmitad.ToString(), param.Timeoutfrio.ToString(),
                param.Timeoutcalor.ToString(), param.Retardostart2bajatension.ToString(),
                param.Tiempomodovelocidadbaja.ToString(), param.Tiempomodovelocidadalta.ToString(),
                param.Final.ToString(), param.TiempoApagadoCalorFrio.ToString(),
                param.Velocidadbajatensionmin.ToString(), param.Velocidadbajatensionmax.ToString(),
                param.Corrientebajatensionmin.ToString(), param.Corrientebajatensionmax.ToString(),
                param.Velocidadminmodovelbaja.ToString(), param.Velocidadmaxmodovelbaja.ToString(),
                param.CorrienteMinModoVelBaja.ToString(), param.Corrientemaxmodovelbaja.ToString(),
                param.Velocidadminmodovelalta.ToString(), param.Velocidadmaxmodovelalta.ToString(),
                param.CorrienteMinModoVelAlta.ToString(), param.Corrientemaxmodovelalta.ToString(), param.TiempoMaximoBajaTension.ToString());

        }

        private static int EscribirEnPLCError = 0;
        private static ParametrosEnsayoIDU pariduParaEscribirEnPLC = null;
        private void btnPLCEscribir_Click(object sender, RoutedEventArgs e)
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
              btnPLCEscribir.Cursor = System.Windows.Input.Cursors.Wait;
              lblCambiando.Content = "...Escribiendo";
              ShowLoadingUIComponent();
              pariduParaEscribirEnPLC = new ParametrosEnsayoIDU();
              pariduParaEscribirEnPLC = GuardarDatosEnObjeto();

              logger.InfoFormat("CargarParametrosEnsayo(). Modelo cargado: Id=[{0}] Descripción=[{1} - {2}]"
                    , pariduParaEscribirEnPLC);
              
              logger.InfoFormat("El usuario '{0}' ingresó a modo mantenimiento.", WPFiDU.BL.ManagerUsuarios.sfUser.sgu__username);
              
              Thread oThread = new Thread(new ThreadStart(this.EscribirEnPLC));
              oThread.Start();

              while (oThread.IsAlive)
                System.Windows.Forms.Application.DoEvents();

              oThread = null;
              
              btnPLCEscribir.Cursor = System.Windows.Input.Cursors.Arrow;

              logger.InfoFormat("Se escribieron parámetros al PLC. {0}", getRawData());
              
              if (EscribirEnPLCError != 0)
              {

                logger.Error("btnPLCEscribir_Click() Escritura en PLC: Se produjo un error al escribir al PLC");
                excepcion msg = new excepcion("Escritura en PLC", "Se produjo un error al escribir al PLC");
                msg.ShowDialog();
                msg = null;
                  
              }
              
          }
          catch (Exception ex)
          {

              logger.ErrorFormat("btnPLCEscribir_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
             , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");

              excepcion formularioexepciones = new excepcion(ex);
              formularioexepciones.ShowDialog();
          }
          HideLoadingUIComponent();
        }


        private void EscribirEnPLC()
        {
            EscribirEnPLCError = 0;
            try
            {
        
                EscribirEnPLCError = ManejadorParametros.EscribirParametrosEnPLC(pariduParaEscribirEnPLC, false);
                //iDU.PLC.OPCWrapper oOPCWrapper = new iDU.PLC.OPCWrapper();
                //oOPCWrapper.Write(pariduParaEscribirEnPLC);
                //oOPCWrapper = null;
                
                //logger.DebugFormat("EscribirEnPLC():: corrientebajatensionmax : {0}," +
                //"corrientebajatensionmin : {1}, corrientemaxmodovelalta : {2}," +
                //"corrienteminmodovelalta : {3}, , corrienteminmodovelbaja : {4}," +
                //"final : {5} , modificado: {6}, referencia : {7}, retardodesenergizado { 8 }," +
                //"retardostartmitad : {9} , Retardostart2bajatension : {10},Retardostopinicial : {11}," +
                //"TiempoApagadoCalorFrio : {12},Tiempomodovelocidadalta : {13}," +
                //"Tiempomodovelocidadbaja : {14},Timeoutcalor : {15}," +
                // "Timeoutfrio : {15},Velocidadbajatensionmax : {16}," +
                // "Velocidadbajatensionmin : {17},Velocidadmaxmodovelalta : {18}," +
                // "Velocidadmaxmodovelbaja : {18},Velocidadminmodovelalta : {19},Velocidadminmodovelbaja : {20} TimeoutBajatension : {21} Falla al escribir : {22}",
                // pariduParaEscribirEnPLC.Corrientebajatensionmax, pariduParaEscribirEnPLC.Corrientebajatensionmin,
                // pariduParaEscribirEnPLC.Corrientemaxmodovelalta, pariduParaEscribirEnPLC.CorrienteMinModoVelAlta,
                // pariduParaEscribirEnPLC.CorrienteMinModoVelBaja, pariduParaEscribirEnPLC.Final, pariduParaEscribirEnPLC.Modificado,
                // pariduParaEscribirEnPLC.Referencia, pariduParaEscribirEnPLC.Retardodesenergizado,
                // pariduParaEscribirEnPLC.Retardostarmitad, pariduParaEscribirEnPLC.Retardostart2bajatension,
                // pariduParaEscribirEnPLC.Retardostopinicial, pariduParaEscribirEnPLC.TiempoApagadoCalorFrio,
                // pariduParaEscribirEnPLC.Tiempomodovelocidadalta, pariduParaEscribirEnPLC.Tiempomodovelocidadbaja,
                // pariduParaEscribirEnPLC.Timeoutcalor, pariduParaEscribirEnPLC.Timeoutfrio, pariduParaEscribirEnPLC.Velocidadbajatensionmax,
                // pariduParaEscribirEnPLC.Velocidadbajatensionmin, pariduParaEscribirEnPLC.Velocidadmaxmodovelalta,
                // pariduParaEscribirEnPLC.Velocidadmaxmodovelbaja, pariduParaEscribirEnPLC.Velocidadminmodovelalta, pariduParaEscribirEnPLC.Velocidadminmodovelbaja, pariduParaEscribirEnPLC.TiempoMaximoBajaTension, EscribirEnPLCError);


                

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnPLCEscribir_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");

                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();

            }

        }

        private static void ForEachControlRecursive(object root, Action<System.Windows.Controls.Control> action)
        {
            System.Windows.Controls.Control control = root as System.Windows.Controls.Control;
            if (control != null)
            {
                action(control);
            }

            if (root is DependencyObject)
            {
                foreach (object child in LogicalTreeHelper.GetChildren((DependencyObject)root))
                {
                    ForEachControlRecursive(child, action);
                }
            }
        }

        private void btnBDLeer_Click(object sender, RoutedEventArgs e)
        {

          try
          {
            ParametrosEnsayoIDU param = GuardarDatosEnObjeto();
            parametrizacion formparametros = new parametrizacion(param);

            logger.InfoFormat("btnBDLeer_Click(). Parámetros enviados como argumento. {0}", getRawData());

            formparametros.ShowDialog();
            if (formparametros.mParam == null)
              return;

            ParametrosEnsayoIDU paramform = formparametros.mParam as ParametrosEnsayoIDU;
            LeerDeObjeto(paramform);
            return;
          }
          catch (Exception ex)
          {
              logger.Error("btnBDLeer_Click()", ex);
              excepcion formularioexcepciones = new excepcion(ex);
              formularioexcepciones.ShowDialog();
              formularioexcepciones = null;
          }
        }

        private void VericarValorNulo(System.Windows.Controls.Control w)
        {
            if (w.GetType() == typeof(WPFiDU.NumericTextBox))
            {
                WPFiDU.NumericTextBox c = (WPFiDU.NumericTextBox)w;
                
                if(c.Text.Equals(string.Empty))
                    c.Text = "0";
                // confirmacioneliminar.Show( string.Format("{0} es un label", w.Name)) ;

            }


            //confirmacioneliminar.Show(this.OwnedWindows.Count.ToString());
            return;
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

        private void HideLoadingUIComponent()
        {
            HabilitarControles(true); 
            lblCambiando.Visibility = Visibility.Hidden;
            this.InvalidateVisual();
            this.InvalidateArrange();
            this.UpdateLayout();
        }

        private void ShowLoadingUIComponent()
        {
            HabilitarControles(false);
            lblCambiando.Visibility = Visibility.Visible;
            this.InvalidateVisual();
            this.InvalidateArrange();
            this.UpdateLayout();

        }

        private void HabilitarControles(bool argEnabled)
        {
            this.btnArchivoAbrir.IsEnabled = argEnabled;
            this.btnArchivoGuardar.IsEnabled = argEnabled;
            this.btnBDLeer.IsEnabled = argEnabled;
            this.btnClose.IsEnabled = argEnabled;
            this.btnPLCEscribir.IsEnabled = argEnabled;
            this.btnPLCLeer.IsEnabled = argEnabled;
            this.btnTeclado.IsEnabled = argEnabled;
            this.cmbVersion.IsEnabled = argEnabled;
            this.txtCorrBajaTensionMax.IsEnabled = argEnabled;
            this.txtCorrBajaTensionMin.IsEnabled = argEnabled;
            this.txtCorrienteHIGHMax.IsEnabled = argEnabled;
            this.txtCorrienteHIGHMin.IsEnabled = argEnabled;
            this.txtCorrienteLOWMax.IsEnabled = argEnabled;
            this.txtCorrienteLOWMin.IsEnabled = argEnabled;
            this.txtDescripcion.IsEnabled = argEnabled;
            this.txtEnsayoLOW.IsEnabled = argEnabled;
            this.txtFinal.IsEnabled = argEnabled;
            this.txtIDenDCF.IsEnabled = argEnabled;
            this.txtlEnsayoHIGH.IsEnabled = argEnabled;
            this.txtRetardoDesenerg.IsEnabled = argEnabled;
            this.txtRetardoStart12.IsEnabled = argEnabled;
            this.txtRetardoStart2BT.IsEnabled = argEnabled;
            this.txtRetardoStopInicial.IsEnabled = argEnabled;
            this.txtTIDUentreCyF.IsEnabled = argEnabled;
            this.txtTimeoutBajaTension.IsEnabled = argEnabled;
            this.txtTOArranqueC.IsEnabled = argEnabled;
            this.txtTOArranqueF.IsEnabled = argEnabled;
            this.txtVelBajaTensionMax.IsEnabled = argEnabled;
            this.txtVelBajaTensionMin.IsEnabled = argEnabled;
            this.txtVelocidadHIGHMax.IsEnabled = argEnabled;
            this.txtVelocidadHIGHMin.IsEnabled = argEnabled;
            this.txtVelocidadLOWMax.IsEnabled = argEnabled;
            this.txtVelocidadLOWMin.IsEnabled = argEnabled;
            
        }

       

         

    }
}