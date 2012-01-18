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
using iDU.PLC;

using System.Text;

namespace dcf001
{
	public partial class ajusteparametrosodu
	{
        private ParametrosManager ManejadorParametros;
        private static readonly ILog logger = LogManager.GetLogger(typeof(ajusteparametrosodu));
       
        
        public ajusteparametrosodu()
		{
			this.InitializeComponent();
           
            LlenarComboBoxVersiones();

            InicializarToolTips();
            ManejadorParametros = new ParametrosManager();
           
		}


        private void InicializarToolTips()
        {
            System.Windows.Controls.ToolTip t1 = new System.Windows.Controls.ToolTip();
            t1.Content = "ODU_SP_TimerEnsayoBajaTension";
            txtBajaTension.ToolTip = t1;

               System.Windows.Controls.ToolTip t2 = new System.Windows.Controls.ToolTip();
               t2.Content = "ODU_SP_MaximaCorrienteEnsayoCalor";
            txtCorrODUModoCalorMax.ToolTip = t2 ;
            
               System.Windows.Controls.ToolTip t3 = new System.Windows.Controls.ToolTip();
               t3.Content = "ODU_SP_MinimaCorrienteEnsayoCalor";

            txtCorrODUModoCalorMin.ToolTip = t3;
            
               System.Windows.Controls.ToolTip t4 = new System.Windows.Controls.ToolTip();
               t4.Content = "ODU_SP_MaximaCorrienteEnsayoFrio";
            txtCorrODUModoFrioMax.ToolTip =t4;
            
               System.Windows.Controls.ToolTip t5 = new System.Windows.Controls.ToolTip();
               t5.Content = "ODU_SP_MinimaCorrienteEnsayoFrio";
            
            txtCorrODUModoFrioMin.ToolTip = t5;
            
               System.Windows.Controls.ToolTip t6 = new System.Windows.Controls.ToolTip();
               t6.Content = "ODU_SP_TimerDelayArranqueCompresor";

            txtDelayArranque.ToolTip = t6;
           
               System.Windows.Controls.ToolTip t7 = new System.Windows.Controls.ToolTip();
               t7.Content = "ODU_SP_MaximaDiferenciaPresionCompresor";

            txtDifPresionBajaTensionMax.ToolTip = t7;
            
               System.Windows.Controls.ToolTip t8 = new System.Windows.Controls.ToolTip();
               t8.Content = "ODU_SP_MinimaDiferenciaPresionCompresor";
            
            txtDifPresionBajaTensionMin.ToolTip = t8;
            
               System.Windows.Controls.ToolTip t9 = new System.Windows.Controls.ToolTip();
               t9.Content = "ODU_SP_MaximaDiferenciaPresionInicio";
            
            txtDifPresionEstMax.ToolTip = t9;
            
               System.Windows.Controls.ToolTip t10 = new System.Windows.Controls.ToolTip();
               t10.Content = "ODU_SP_MinimaDiferenciaPresionInicio";

            txtDifPresionEstMin.ToolTip=t10;
            
               System.Windows.Controls.ToolTip t11 = new System.Windows.Controls.ToolTip();
               t11.Content = "ODU_SP_MaximaDiferenciaTemperaturaCalor";
            
            txtDifTempModoCalorMax.ToolTip=t11;
            
               System.Windows.Controls.ToolTip t12 = new System.Windows.Controls.ToolTip();
               t12.Content = "ODU_SP_MinimaDiferenciaTemperaturaCalor";
            
            txtDifTempModoCalorMin.ToolTip=t12;
            
               System.Windows.Controls.ToolTip t13 = new System.Windows.Controls.ToolTip();
               t13.Content = "ODU_SP_MaximaDiferenciaTemperaturaEnsayoFrio";
            
            txtDifTempModoFrioMax.ToolTip =t13;
            
               System.Windows.Controls.ToolTip t14 = new System.Windows.Controls.ToolTip();
               t14.Content = "ODU_SP_MinimaDiferenciaTemperaturaEnsayoFrio";
            
            txtDifTempModoFrioMin.ToolTip = t14;
            
               System.Windows.Controls.ToolTip t15 = new System.Windows.Controls.ToolTip();
               t15.Content = "ODU_SP_DelayAntesIndicFinalizado";
            
            
            txtFinal.ToolTip = t15;
            
               System.Windows.Controls.ToolTip t16 = new System.Windows.Controls.ToolTip();
               t16.Content = "ODU_SP_TimerEnsayoCalor";
            
            txtMedicionModoCalor.ToolTip = t16;
            
               System.Windows.Controls.ToolTip t17 = new System.Windows.Controls.ToolTip();
               t17.Content = "ODU_SP_TimerEnsayoFrio";
            
            txtMedicionModoFrio.ToolTip = t17;
            
               System.Windows.Controls.ToolTip t18 = new System.Windows.Controls.ToolTip();
               t18.Content = "ODU_SP_MaximaPotenciaEnsayoCalor";
            
            txtPotODUModoCalorMax.ToolTip = t18;
            
               System.Windows.Controls.ToolTip t19 = new System.Windows.Controls.ToolTip();
               t19.Content = "ODU_SP_MinimaPotenciaEnsayoCalor";
            
            txtPotODUModoCalorMin.ToolTip = t19;
            
               System.Windows.Controls.ToolTip t20 = new System.Windows.Controls.ToolTip();
               t20.Content = "ODU_SP_MaximaPotenciaEnsayoFrio";
            
            txtPotODUModoFrioMax.ToolTip = t20;
            
               System.Windows.Controls.ToolTip t21 = new System.Windows.Controls.ToolTip();
               t21.Content = "ODU_SP_MinimaPotenciaEnsayoFrio";
            
            txtPotODUModoFrioMin.ToolTip = t21;
            
               System.Windows.Controls.ToolTip t22 = new System.Windows.Controls.ToolTip();
               t22.Content = "ODU_SP_MinimaDiferenciaPresionCompresor";
            
            txtPresionApagCompMin.ToolTip = t22;
            
               System.Windows.Controls.ToolTip t23 = new System.Windows.Controls.ToolTip();
               t23.Content = "ODU_SP_MaximaPresionAdmisibleInicio";
            
            txtPresionInicialMax.ToolTip = t23;
            
               System.Windows.Controls.ToolTip t24 = new System.Windows.Controls.ToolTip();
               t24.Content = "ODU_SP_MinimaPresionAdmisibleInicio";
            
            txtPresionInicialMin.ToolTip = t24;
            
               System.Windows.Controls.ToolTip t25 = new System.Windows.Controls.ToolTip();
               t25.Content = "ODU_SP_MaximaPresionEnsayoFrio";
            
            txtPresionModoFrioMax.ToolTip = t25;
            
               System.Windows.Controls.ToolTip t26 = new System.Windows.Controls.ToolTip();
               t26.Content = "ODU_SP_MinimaPresionEnsayoFrio";
            
            txtPresionModoFrioMin.ToolTip = t26;
            
               System.Windows.Controls.ToolTip t27 = new System.Windows.Controls.ToolTip();
               t27.Content = "ODU_SP_MaximaPresionAdmisibleRecuperacionRefrigerante";
            
            txtPresionRecupMax.ToolTip = t27;
            
               System.Windows.Controls.ToolTip t28 = new System.Windows.Controls.ToolTip();
               t28.Content = "ODU_SP_TimerRecuperacionRefrigerante";
            
            txtRecupMinima.ToolTip = t28;
            
               System.Windows.Controls.ToolTip t29 = new System.Windows.Controls.ToolTip();
               t29.Content = "ODU_SP_TimerDelayCierreValvula1";
            
            txtTCierreValv1.ToolTip = t29;
            
               System.Windows.Controls.ToolTip t30 = new System.Windows.Controls.ToolTip();
               t30.Content = "ODU_SP_TimerDelayCierreValvula2";
            
            txtTCierreValv2.ToolTip = t30;
               
            System.Windows.Controls.ToolTip t31 = new System.Windows.Controls.ToolTip();
            t31.Content = "ODU_SP_TimerEstabilizacionPresiones";
            
            
            txtTiempoInicial.ToolTip = t31;
            
               System.Windows.Controls.ToolTip t32 = new System.Windows.Controls.ToolTip();
               t32.Content = "ODU_SP_TimeoutBajaTension";
            
            txtTimeOutBajaTension.ToolTip = t32;
            
               System.Windows.Controls.ToolTip t33 = new System.Windows.Controls.ToolTip();
               t33.Content = "ODU_SP_TimeoutPresionInicial";
            
            txtTimeOutEst.ToolTip = t33;
            
               System.Windows.Controls.ToolTip t34 = new System.Windows.Controls.ToolTip();
               t34.Content = "ODU_SP_TimeoutModoCalor";
            
            txtTimeOutModoCalor.ToolTip = t34;
               System.Windows.Controls.ToolTip t35 = new System.Windows.Controls.ToolTip();
               t35.Content = "ODU_SP_TimeoutRecuperacion";
            
            txtTimeOutRecup.ToolTip = t35;
            
               System.Windows.Controls.ToolTip t36 = new System.Windows.Controls.ToolTip();
               t36.Content = "ODU_SP_TiempoIDUOFFEntreFrioCalor";
            
            txtTODUentreCyF.ToolTip = t36;
            
               System.Windows.Controls.ToolTip t37 = new System.Windows.Controls.ToolTip();
               t37.Content = "ODU_SP_MinimaVelocidadCompresor";
            
            txtVelBajaTensionMax.ToolTip = t37;
            
               System.Windows.Controls.ToolTip t38 = new System.Windows.Controls.ToolTip();
               t38.Content = "ODU_SP_MinimaVelocidadCompresor";
            
            txtVelBajaTensionMin.ToolTip = t38;
            
               System.Windows.Controls.ToolTip t39 = new System.Windows.Controls.ToolTip();
               t39.Content = "ODU_SP_MaximaVelocidadEnsayoCalor";
            
            txtVelVentModoCalorMax.ToolTip = t39;
            
               System.Windows.Controls.ToolTip t40 = new System.Windows.Controls.ToolTip();
               t40.Content = "ODU_SP_MinimaVelocidadEnsayoCalor";
            txtVelVentModoCalorMin.ToolTip = t40;
            
               System.Windows.Controls.ToolTip t41 = new System.Windows.Controls.ToolTip();
               t41.Content = "ODU_SP_MaximaVelocidadEnsayoFrio";
            
            txtVelVentModoFrioMax.ToolTip = t41;
            
               System.Windows.Controls.ToolTip t42 = new System.Windows.Controls.ToolTip();
               t42.Content = "ODU_SP_MinimaVelocidadEnsayoFrio";
            txtVelVentModoFrioMin.ToolTip = t42;


        }


        private void LlenarComboBoxVersiones()
        {
            VersionEquiposManager ManagerVersiones = new VersionEquiposManager();
            List<VersionEquipo> ListaVersiones = ManagerVersiones.ObtenerVersiones();
            //VersioncomboBox.Items.AddRange((ListaVersiones.ToArray()));
            cmbVersion.Items.Clear();
            for (int i = 0; i < ListaVersiones.Count; i++)
            {
                cmbVersion.Items.Add(ListaVersiones[i]);

            }

            cmbVersion.SelectedIndex = 0;


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ManejadorParametros != null)
                    ManejadorParametros.Dispose();

                this.Close();
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnClose_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
             , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");

            }
        }

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

                paramGuardarDatosEnObjeto = GuardarDatosEnObjeto();
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
               
                logger.Error("btnPLCEscribir_Click())", ex);

                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
                formularioexepciones=null;

            }
            HideLoadingUIComponent();
        }
        private static int  EscribirEnPLCError = 0;
        private static ParametrosEnsayoODU paramGuardarDatosEnObjeto = null;
        
        private void EscribirEnPLC()
        {
            EscribirEnPLCError = 0;
            try 
            {

              EscribirEnPLCError = ManejadorParametros.EscribirParametrosEnPLC(paramGuardarDatosEnObjeto, false);
              //OPCWrapper oOPCWrapper = new OPCWrapper();
              //oOPCWrapper.Write(paramGuardarDatosEnObjeto);
              //oOPCWrapper = null;

              logger.DebugFormat("btnPLCEscribir_Click(object sender, RoutedEventArgs):: corrientemaxcalor : {0}," +
              "CorrienteMaxCalor : {1},CorrienteMaxFrio : {2}," +
              "CorrienteMinCalor : {3},CorrienteMinFrio : {4}," +
              "DCFs : {5},DelayArranqueCompresor : {6}," +
              "DeltaPresionBajaTensionMax : {7},DeltaPresionBajaTensionMin : {8}," +
              "DeltaPresionEstabilizacionMax: {9}, DeltaPresionEstabilizacionMin: {10}," +
              "DeltaTempMaxCalor: {11},DeltaTempMaxFrio : {12}," +
              "DeltaTempMinCalor : {13},DeltaTempMinFrio : {14},PotenciaMaxCalor : {15}," +
              "PotenciaMaxFrio : {16},PotenciaMinCalor : {17}," +
              "PotenciaMinFrio : {18},PresionInicialMax: {19}," +
              "PresionInicialMin : {20},PresionMaxFrio : {21}," +
              "PresionMaxRecuperacion : {22},PresionMinApagadoCompresor : {23}," +
              "PresionMinFrio : {24}, TiempoApagadoEntreCalorFrio : {25}," +
              "TiempoBajaTension : {26},TiempoCierreValvula1 : {27}," +
              "TiempoCierreValvula2 : {28}, TiempoFinal : {29}," +
              "TiempoInicialEstabilizacion : {30}, TiempoMaximoBajaTension : {31}," +
              "TiempoMaximoEstabilizacion : {32}, TiempoMaximoMedicionCalor : {33}," +
              "TiempoMaximoRecuperacionMinima : {34}, TiempoMedicionCalor : {35}," +
              "TiempoMedicionFrio : {36}, TiempoRecuperacionMinima : {37}," +
              "VelocidadBajatensionMax : {38}, VelocidadBajaTensionMin : {39}," +
              "VelocidadMaxVentiladorCalor : {40}, VelocidadMaxVentiladorFrio : {41}," +
              "VelocidadMinVentiladorCalor : {42}, VelocidadMinVentiladorFrio : {43} , Falla al escribir : {44}",
              paramGuardarDatosEnObjeto.CorrienteMaxCalor, paramGuardarDatosEnObjeto.CorrienteMaxCalor, paramGuardarDatosEnObjeto.CorrienteMaxFrio,
              paramGuardarDatosEnObjeto.CorrienteMinCalor, paramGuardarDatosEnObjeto.CorrienteMinFrio,
              paramGuardarDatosEnObjeto.DCFs, paramGuardarDatosEnObjeto.DelayArranqueCompresor,
              paramGuardarDatosEnObjeto.DeltaPresionBajaTensionMax, paramGuardarDatosEnObjeto.DeltaPresionBajaTensionMin,
              paramGuardarDatosEnObjeto.DeltaPresionEstabilizacionMax, paramGuardarDatosEnObjeto.DeltaPresionEstabilizacionMin,
              paramGuardarDatosEnObjeto.DeltaTempMaxCalor, paramGuardarDatosEnObjeto.DeltaTempMaxFrio,
              paramGuardarDatosEnObjeto.DeltaTempMinCalor, paramGuardarDatosEnObjeto.DeltaTempMinFrio, paramGuardarDatosEnObjeto.PotenciaMaxCalor,
              paramGuardarDatosEnObjeto.PotenciaMaxFrio, paramGuardarDatosEnObjeto.PotenciaMinCalor,
              paramGuardarDatosEnObjeto.PotenciaMinFrio, paramGuardarDatosEnObjeto.PresionInicialMax,
              paramGuardarDatosEnObjeto.PresionInicialMin, paramGuardarDatosEnObjeto.PresionMaxFrio,
              paramGuardarDatosEnObjeto.PresionMaxRecuperacion, paramGuardarDatosEnObjeto.PresionMinApagadoCompresor,
              paramGuardarDatosEnObjeto.PresionMinFrio, paramGuardarDatosEnObjeto.TiempoApagadoEntreCalorFrio,
              paramGuardarDatosEnObjeto.TiempoBajaTension, paramGuardarDatosEnObjeto.TiempoCierreValvula1,
              paramGuardarDatosEnObjeto.TiempoCierreValvula2, paramGuardarDatosEnObjeto.TiempoFinal,
              paramGuardarDatosEnObjeto.TiempoInicialEstabilizacion, paramGuardarDatosEnObjeto.TiempoMaximoBajaTension,
              paramGuardarDatosEnObjeto.TiempoMaximoEstabilizacion, paramGuardarDatosEnObjeto.TiempoMaximoMedicionCalor,
              paramGuardarDatosEnObjeto.TiempoMaximoRecuperacionMinima, paramGuardarDatosEnObjeto.TiempoMedicionCalor,
              paramGuardarDatosEnObjeto.TiempoMedicionFrio, paramGuardarDatosEnObjeto.TiempoRecuperacionMinima,
              paramGuardarDatosEnObjeto.VelocidadBajatensionMax, paramGuardarDatosEnObjeto.VelocidadBajaTensionMin,
              paramGuardarDatosEnObjeto.VelocidadMaxVentiladorCalor, paramGuardarDatosEnObjeto.VelocidadMaxVentiladorFrio,
              paramGuardarDatosEnObjeto.VelocidadMinVentiladorCalor, paramGuardarDatosEnObjeto.VelocidadMinVentiladorFrio, EscribirEnPLCError);

            }catch(Exception ex)
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

        private void VericarValorNulo(System.Windows.Controls.Control w)
        {
            if (w.GetType() == typeof(WPFiDU.NumericTextBox))
            {
                WPFiDU.NumericTextBox c = (WPFiDU.NumericTextBox)w;
                if (c.Text.Equals(string.Empty))
                c.Text = "0";
                // confirmacioneliminar.Show( string.Format("{0} es un label", w.Name)) ;

            }


            //confirmacioneliminar.Show(this.OwnedWindows.Count.ToString());
            return;
        }

        private ParametrosEnsayoODU GuardarDatosEnObjeto()
        {
            ParametrosEnsayoODU parodu = new ParametrosEnsayoODU();

            ForEachControlRecursive(this, VericarValorNulo);

            parodu.CorrienteMaxCalor=int.Parse(txtCorrODUModoCalorMax.Text);
            parodu.CorrienteMaxFrio=int.Parse(txtCorrODUModoFrioMax.Text);
            parodu.CorrienteMinCalor=int.Parse(txtCorrODUModoCalorMin.Text);
            parodu.CorrienteMinFrio=int.Parse(txtCorrODUModoFrioMin.Text);
           // parodu.DCFs=;
            parodu.DelayArranqueCompresor=int.Parse(txtDelayArranque.Text);
            parodu.DeltaPresionBajaTensionMax=int.Parse(txtDifPresionBajaTensionMax.Text);
            parodu.DeltaPresionBajaTensionMin=int.Parse(txtDifPresionBajaTensionMin.Text);
            parodu.DeltaPresionEstabilizacionMax=int.Parse(txtDifPresionEstMax.Text);
            parodu.DeltaPresionEstabilizacionMin=int.Parse(txtDifPresionEstMin.Text);
            parodu.DeltaTempMaxCalor=int.Parse(txtDifTempModoCalorMax.Text);
            parodu.DeltaTempMaxFrio=int.Parse(txtDifTempModoFrioMax.Text);
            parodu.DeltaTempMinCalor=int.Parse(txtDifTempModoCalorMin.Text);
            parodu.DeltaTempMinFrio=int.Parse(txtDifTempModoFrioMin.Text);
            parodu.Descripcion=txtDescripcion.Text;
            parodu.ID=int.Parse(txtIDenDCF.Text);
            parodu.Modificado=DateTime.Now;
            parodu.PotenciaMaxCalor=int.Parse(txtPotODUModoCalorMax.Text);
            parodu.PotenciaMaxFrio=int.Parse(txtPotODUModoFrioMax.Text);
            parodu.PotenciaMinCalor=int.Parse(txtPotODUModoCalorMin.Text);
            parodu.PotenciaMinFrio=int.Parse(txtPotODUModoFrioMin.Text);
            parodu.PresionInicialMax=int.Parse(txtPresionInicialMax.Text);
            parodu.PresionInicialMin=int.Parse(txtPresionInicialMin.Text);
            parodu.PresionMaxFrio=int.Parse(txtPresionModoFrioMax.Text);
            parodu.PresionMaxRecuperacion=int.Parse(txtPresionRecupMax.Text);
            parodu.PresionMinApagadoCompresor=int.Parse(txtPresionApagCompMin.Text);
            parodu.PresionMinFrio=int.Parse(txtPresionModoFrioMin.Text);
            parodu.Referencia = string.IsNullOrEmpty(txtReferencia.Text) ? "" : txtReferencia.Text;
            parodu.TiempoApagadoEntreCalorFrio=int.Parse(txtTODUentreCyF.Text);
            parodu.TiempoBajaTension=int.Parse(txtBajaTension.Text);
            parodu.TiempoCierreValvula1=int.Parse(txtTCierreValv1.Text);
            parodu.TiempoCierreValvula2=int.Parse(txtTCierreValv2.Text);
            parodu.TiempoFinal=int.Parse(txtFinal.Text);
            parodu.TiempoInicialEstabilizacion=int.Parse(txtTiempoInicial.Text);
            parodu.TiempoMaximoBajaTension=int.Parse(txtTimeOutBajaTension.Text);
            parodu.TiempoMaximoEstabilizacion=int.Parse(txtTimeOutEst.Text);
            parodu.TiempoMaximoMedicionCalor=int.Parse(txtTimeOutModoCalor.Text);
            parodu.TiempoMaximoRecuperacionMinima=int.Parse(txtTimeOutRecup.Text);
            parodu.TiempoMedicionCalor=int.Parse(txtMedicionModoCalor.Text);
            parodu.TiempoMedicionFrio=int.Parse(txtMedicionModoFrio.Text);
            parodu.TiempoRecuperacionMinima=int.Parse(txtRecupMinima.Text);
            parodu.VelocidadBajatensionMax =int.Parse( txtVelBajaTensionMax.Text);
            parodu.VelocidadBajaTensionMin=int.Parse(txtVelBajaTensionMin.Text);
            parodu.VelocidadMaxVentiladorCalor=int.Parse(txtVelVentModoCalorMax.Text);
            parodu.VelocidadMaxVentiladorFrio=int.Parse(txtVelVentModoFrioMax.Text);
            parodu.VelocidadMinVentiladorCalor=int.Parse(txtVelVentModoCalorMin.Text);
            parodu.VelocidadMinVentiladorFrio=int.Parse(txtVelVentModoFrioMin.Text);

            parodu.IdVersion = ((VersionEquipo)cmbVersion.SelectedItem).ID;

            return parodu;

        }

        private string getRawData(){
          StringBuilder str = new StringBuilder();
          str.AppendFormat("'{0}':{1}; ", lblCorrODUModoCalor.Content + " mínima", txtCorrODUModoCalorMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblCorrODUModoCalor.Content + " máxima", txtCorrODUModoCalorMax.RawText);

          str.AppendFormat("'{0}':{1}; ", lblCorrODUModoFrio.Content + " mínima", txtCorrODUModoFrioMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblCorrODUModoFrio.Content + " máxima", txtCorrODUModoFrioMax.RawText); 
          str.AppendFormat("'{0}':{1}; ", lblDelayArranque.Content, txtDelayArranque.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifPresionBajaTension.Content + " mínima", txtDifPresionBajaTensionMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifPresionBajaTension.Content + " máxima", txtDifPresionBajaTensionMax.RawText);

          str.AppendFormat("'{0}':{1}; ", lblDifPresionEst.Content + " mínima", txtDifPresionEstMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifPresionEst.Content + " máxima", txtDifPresionEstMax.RawText);

          str.AppendFormat("'{0}':{1}; ", lblDifTempModoCalor.Content + " mínima", txtDifTempModoCalorMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifTempModoCalor.Content + " máxima", txtDifTempModoCalorMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifTempModoFrio.Content + " mínima", txtDifTempModoFrioMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblDifTempModoFrio.Content + " máxima", txtDifTempModoFrioMax.RawText);
          
          str.AppendFormat("'{0}':{1}; ", lblDescripcion.Content, txtDescripcion.Text);
          str.AppendFormat("'{0}':{1}; ", lblIDenDCF.Content, txtIDenDCF.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPotODUModoCalor.Content + " mínima", txtPotODUModoCalorMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPotODUModoCalor.Content + " máxima", txtPotODUModoCalorMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPotODUModoFrio.Content + " mínima", txtPotODUModoFrioMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPotODUModoFrio.Content + " máxima", txtPotODUModoFrioMax.RawText);
          
          str.AppendFormat("'{0}':{1}; ", lblPresionInicial.Content + " mínima", txtPresionInicialMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPresionInicial.Content + " máxima", txtPresionInicialMax.RawText);

          str.AppendFormat("'{0}':{1}; ", lblPresionModoFrio.Content + " mínima", txtPresionModoFrioMin.RawText); 
          str.AppendFormat("'{0}':{1}; ", lblPresionModoFrio.Content + " máxima", txtPresionModoFrioMax.RawText);
          
          str.AppendFormat("'{0}':{1}; ", lblPresionRecup.Content + " máxima", txtPresionRecupMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblPresionApagComp.Content + " mínima", txtPresionApagCompMin.RawText);
          
          str.AppendFormat("'{0}':{1}; ", lblReferencia.Content, txtReferencia.Text);
          str.AppendFormat("'{0}':{1}; ", lblTODUentreCyF.Content, txtTODUentreCyF.RawText);
          str.AppendFormat("'{0}':{1}; ", lblBajaTension.Content, txtBajaTension.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTCierreValv1.Content, txtTCierreValv1.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTCierreValv2.Content, txtTCierreValv2.RawText);
          str.AppendFormat("'{0}':{1}; ", lblFinal.Content, txtFinal.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTiempoInicial.Content, txtTiempoInicial.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTimeOutBajaTension.Content, txtTimeOutBajaTension.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTimeOutEst.Content, txtTimeOutEst.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTimeOutModoCalor.Content, txtTimeOutModoCalor.RawText);
          str.AppendFormat("'{0}':{1}; ", lblTimeOutRecup.Content, txtTimeOutRecup.RawText);
          str.AppendFormat("'{0}':{1}; ", lblMedicionModoCalor.Content, txtMedicionModoCalor.RawText);
          str.AppendFormat("'{0}':{1}; ", lblMedicionModoFrio.Content, txtMedicionModoFrio.RawText);
          str.AppendFormat("'{0}':{1}; ", lblRecupMinima.Content, txtRecupMinima.RawText);

          str.AppendFormat("'{0}':{1}; ", lblVelBajaTension.Content + " mínima", txtVelBajaTensionMin.RawText); 
          str.AppendFormat("'{0}':{1}; ", lblVelBajaTension.Content + " máxima", txtVelBajaTensionMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblVelVentModoCalor.Content + " mínima", txtVelVentModoCalorMin.RawText); 
          str.AppendFormat("'{0}':{1}; ", lblVelVentModoCalor.Content + " máxima", txtVelVentModoCalorMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblVelVentModoFrio.Content + " mínima", txtVelVentModoFrioMin.RawText);
          str.AppendFormat("'{0}':{1}; ", lblVelVentModoFrio.Content + " máxima", txtVelVentModoFrioMax.RawText);
          str.AppendFormat("'{0}':{1}; ", lblVersion.Content, ((VersionEquipo)cmbVersion.SelectedItem).Descripcion);
          
          return str.ToString();
        
        }

        private void btnPLCLeer_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Operador))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
            
              try
              {

                LeerDePLC();
                
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

            ParametrosEnsayoODU param = ManejadorParametros.LeerParametrosDePLC() as ParametrosEnsayoODU;
            LeerDeObjeto(param);
            txtReferencia.Text = "";
            txtDescripcion.Text = "";
            txtIDenDCF.Text = "0";

            logger.DebugFormat("LeerDePLC():: corrientemaxcalor : {0}," +
            "CorrienteMaxCalor : {1},CorrienteMaxFrio : {2}," +
            "CorrienteMinCalor : {3},CorrienteMinFrio : {4}," +
            "DCFs : {5},DelayArranqueCompresor : {6}," +
            "DeltaPresionBajaTensionMax : {7},DeltaPresionBajaTensionMin : {8}," +
            "DeltaPresionEstabilizacionMax: {9}, DeltaPresionEstabilizacionMin: {10}," +
            "DeltaTempMaxCalor: {11},DeltaTempMaxFrio : {12}," +
            "DeltaTempMinCalor : {13},DeltaTempMinFrio : {14},PotenciaMaxCalor : {15}," +
            "PotenciaMaxFrio : {16},PotenciaMinCalor : {17}," +
            "PotenciaMinFrio : {18},PresionInicialMax: {19}," +
            "PresionInicialMin : {20},PresionMaxFrio : {21}," +
            "PresionMaxRecuperacion : {22},PresionMinApagadoCompresor : {23}," +
            "PresionMinFrio : {24}, TiempoApagadoEntreCalorFrio : {25}," +
            "TiempoBajaTension : {26},TiempoCierreValvula1 : {27}," +
            "TiempoCierreValvula2 : {28}, TiempoFinal : {29}," +
            "TiempoInicialEstabilizacion : {30}, TiempoMaximoBajaTension : {31}," +
            "TiempoMaximoEstabilizacion : {32}, TiempoMaximoMedicionCalor : {33}," +
            "TiempoMaximoRecuperacionMinima : {34}, TiempoMedicionCalor : {35}," +
            "TiempoMedicionFrio : {36}, TiempoRecuperacionMinima : {37}," +
            "VelocidadBajatensionMax : {38}, VelocidadBajaTensionMin : {39}," +
            "VelocidadMaxVentiladorCalor : {40}, VelocidadMaxVentiladorFrio : {41}," +
            "VelocidadMinVentiladorCalor : {42}, VelocidadMinVentiladorFrio : {43}",




            param.CorrienteMaxCalor, param.CorrienteMaxCalor, param.CorrienteMaxFrio,
            param.CorrienteMinCalor, param.CorrienteMinFrio,
            param.DCFs, param.DelayArranqueCompresor,
            param.DeltaPresionBajaTensionMax, param.DeltaPresionBajaTensionMin,
            param.DeltaPresionEstabilizacionMax, param.DeltaPresionEstabilizacionMin,
            param.DeltaTempMaxCalor, param.DeltaTempMaxFrio,
            param.DeltaTempMinCalor, param.DeltaTempMinFrio, param.PotenciaMaxCalor,
            param.PotenciaMaxFrio, param.PotenciaMinCalor,
            param.PotenciaMinFrio, param.PresionInicialMax,
            param.PresionInicialMin, param.PresionMaxFrio,
            param.PresionMaxRecuperacion, param.PresionMinApagadoCompresor,
            param.PresionMinFrio, param.TiempoApagadoEntreCalorFrio,
            param.TiempoBajaTension, param.TiempoCierreValvula1,
            param.TiempoCierreValvula2, param.TiempoFinal,
            param.TiempoInicialEstabilizacion, param.TiempoMaximoBajaTension,
            param.TiempoMaximoEstabilizacion, param.TiempoMaximoMedicionCalor,
            param.TiempoMaximoRecuperacionMinima, param.TiempoMedicionCalor,
            param.TiempoMedicionFrio, param.TiempoRecuperacionMinima,
            param.VelocidadBajatensionMax, param.VelocidadBajaTensionMin,
            param.VelocidadMaxVentiladorCalor, param.VelocidadMaxVentiladorFrio,
            param.VelocidadMinVentiladorCalor, param.VelocidadMinVentiladorFrio);
           
        }

        private void LeerDeObjeto(ParametrosEnsayoODU param)
        {

            txtIDenDCF.Text = param.ID.ToString();
            txtPresionInicialMin.Text  = param.PresionInicialMin.ToString();
            txtPresionInicialMax.Text  = param.PresionInicialMax.ToString();
            txtDifPresionEstMin.Text = param.DeltaPresionEstabilizacionMin.ToString();
            txtDifPresionEstMax.Text = param.DeltaPresionEstabilizacionMax.ToString();
            txtVelBajaTensionMin.Text = param.VelocidadBajaTensionMin.ToString();
            txtVelBajaTensionMax.Text= param.VelocidadBajaTensionMin.ToString();
            txtDifPresionBajaTensionMin.Text = param.DeltaPresionBajaTensionMin.ToString();
            txtDifPresionBajaTensionMax.Text = param.DeltaPresionBajaTensionMax.ToString();
            txtDifTempModoCalorMin.Text = param.DeltaTempMinCalor.ToString();
            txtDifTempModoCalorMax.Text = param.DeltaTempMaxCalor.ToString();
            txtCorrODUModoCalorMin.Text = param.CorrienteMinCalor.ToString();
            txtCorrODUModoCalorMax.Text = param.CorrienteMaxCalor.ToString();
            txtPotODUModoCalorMin.Text = param.PotenciaMinCalor.ToString();
            txtPotODUModoCalorMax.Text = param.PotenciaMaxCalor.ToString();
            txtVelVentModoCalorMin.Text = param.VelocidadMinVentiladorCalor.ToString();
            txtVelVentModoCalorMax.Text = param.VelocidadMaxVentiladorCalor.ToString();
            txtPresionApagCompMin.Text = param.PresionMinApagadoCompresor.ToString();
            txtDifTempModoFrioMin.Text = param.DeltaTempMinFrio.ToString();
            txtDifTempModoFrioMax.Text = param.DeltaTempMaxFrio.ToString();
            txtCorrODUModoFrioMin.Text = param.CorrienteMinFrio.ToString();
            txtCorrODUModoFrioMax.Text = param.CorrienteMaxFrio.ToString();
            txtPotODUModoFrioMin.Text = param.PotenciaMinFrio.ToString();
            txtPotODUModoFrioMax.Text = param.PotenciaMaxFrio.ToString();
            txtVelVentModoFrioMin.Text = param.VelocidadMinVentiladorFrio.ToString();
            txtVelVentModoFrioMax.Text =  param.VelocidadMaxVentiladorFrio.ToString();
            txtPresionModoFrioMin.Text = param.PresionMinFrio.ToString();
            txtPresionModoFrioMax.Text = param.PresionMaxFrio.ToString();
            txtPresionRecupMax.Text = param.PresionMaxRecuperacion.ToString();
           // Valoresgrid[15, 2].Value = param.PresionMaxRecuperacion;

            txtReferencia.Text = param.Referencia;
            txtDescripcion.Text = param.Descripcion;
            


            txtTiempoInicial.Text = param.TiempoInicialEstabilizacion.ToString();
            txtTimeOutBajaTension.Text = param.TiempoMaximoBajaTension.ToString();
            txtTimeOutModoCalor.Text = param.TiempoMaximoMedicionCalor.ToString();
            txtTimeOutEst.Text = param.TiempoMaximoEstabilizacion.ToString();
            txtTimeOutRecup.Text = param.TiempoMaximoRecuperacionMinima.ToString();
            txtBajaTension.Text = param.TiempoBajaTension.ToString();
            txtMedicionModoCalor.Text = param.TiempoMedicionCalor.ToString();
            txtMedicionModoFrio.Text = param.TiempoMedicionFrio.ToString();
            txtRecupMinima.Text = param.TiempoRecuperacionMinima.ToString();

            txtDelayArranque.Text = param.DelayArranqueCompresor.ToString();
            txtTODUentreCyF.Text = param.TiempoApagadoEntreCalorFrio.ToString();
            txtTCierreValv1.Text = param.TiempoCierreValvula1.ToString();
            txtTCierreValv2.Text = param.TiempoCierreValvula2.ToString();
            txtFinal.Text = param.TiempoFinal.ToString();

            for (int i = 0; i < cmbVersion.Items.Count; i++)
            {
              if (((VersionEquipo)cmbVersion.Items[i]).ID == param.IdVersion)
              {
                cmbVersion.SelectedIndex = i;
                break;
              }



            }

        }

        private void btnArchivoAbrir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog selectorarchivo = new OpenFileDialog();
                DialogResult resultado = selectorarchivo.ShowDialog();
                string nombreArchivo;

                if (resultado ==System.Windows.Forms.DialogResult.Cancel)
                    return;
                nombreArchivo = selectorarchivo.FileName;

                ParametrosEnsayoODU parodu = ManejadorParametros.LeerParametrosDeArchivo(nombreArchivo) as ParametrosEnsayoODU;
                LeerDeObjeto(parodu);
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

        private void btnArchivoGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog selectorarchivo = new SaveFileDialog();
                DialogResult resultado = selectorarchivo.ShowDialog();
                string nombreArchivo;

                selectorarchivo.CheckFileExists = false;

                if (resultado ==System.Windows.Forms.DialogResult.Cancel)
                    return;


                nombreArchivo = selectorarchivo.FileName;

            
                ParametrosEnsayoODU parodu = GuardarDatosEnObjeto();
                ManejadorParametros.GuardarParametrosEnArchivo(parodu, nombreArchivo);
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

        private void btnBDLeer_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ParametrosEnsayoODU param = GuardarDatosEnObjeto();
                parametrizacion formparametros = new parametrizacion(param);
                formparametros.ShowDialog();
                if (formparametros.mParam == null)
                    return;

                ParametrosEnsayoODU paramform = formparametros.mParam as ParametrosEnsayoODU;
                LeerDeObjeto(paramform);

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("btnDBLeer_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
             , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();

            }
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
            //this.btnArchivoAbrir.IsEnabled = argEnabled;
            //this.btnArchivoGuardar.IsEnabled = argEnabled;
            this.btnBDLeer.IsEnabled = argEnabled;
            this.btnClose.IsEnabled = argEnabled;
            this.btnPLCEscribir.IsEnabled = argEnabled;
            this.btnPLCLeer.IsEnabled = argEnabled;
            this.btnTeclado.IsEnabled = argEnabled;
            this.txtBajaTension.IsEnabled = argEnabled;
            this.txtCorrODUModoCalorMax.IsEnabled = argEnabled;
            this.txtCorrODUModoCalorMin.IsEnabled = argEnabled;
            this.txtCorrODUModoFrioMax.IsEnabled = argEnabled;
            this.txtCorrODUModoFrioMin.IsEnabled = argEnabled;
            this.txtDelayArranque.IsEnabled = argEnabled;
            this.txtDescripcion.IsEnabled = argEnabled;
            this.txtDifPresionBajaTensionMax.IsEnabled = argEnabled;
            this.txtDifPresionBajaTensionMin.IsEnabled = argEnabled;
            this.txtDifPresionEstMax.IsEnabled = argEnabled;
            this.txtDifPresionEstMin.IsEnabled = argEnabled;
            this.txtDifTempModoCalorMax.IsEnabled = argEnabled;
            this.txtDifTempModoCalorMin.IsEnabled = argEnabled;
            this.txtDifTempModoFrioMax.IsEnabled = argEnabled;
            this.txtDifTempModoFrioMin.IsEnabled = argEnabled;
            this.txtFinal.IsEnabled = argEnabled;
            this.txtIDenDCF.IsEnabled = argEnabled;
            this.txtMedicionModoCalor.IsEnabled = argEnabled;
            this.txtMedicionModoFrio.IsEnabled = argEnabled;
            this.txtPotODUModoCalorMax.IsEnabled = argEnabled;
            this.txtPotODUModoCalorMin.IsEnabled = argEnabled;
            this.txtPotODUModoFrioMax.IsEnabled = argEnabled;
            this.txtPotODUModoFrioMin.IsEnabled = argEnabled;
            this.txtPresionApagCompMin.IsEnabled = argEnabled;
            this.txtPresionInicialMax.IsEnabled = argEnabled;
            this.txtPresionInicialMin.IsEnabled = argEnabled;
            this.txtPresionModoFrioMax.IsEnabled = argEnabled;
            this.txtPresionModoFrioMin.IsEnabled = argEnabled;
            this.txtPresionRecupMax.IsEnabled = argEnabled;
            this.txtRecupMinima.IsEnabled = argEnabled;
            this.txtReferencia.IsEnabled = argEnabled;
            this.txtTCierreValv1.IsEnabled = argEnabled;
            this.txtTCierreValv2.IsEnabled = argEnabled;
            this.txtTiempoInicial.IsEnabled = argEnabled;
            this.txtTimeOutBajaTension.IsEnabled = argEnabled;
            this.txtTimeOutEst.IsEnabled = argEnabled;
            this.txtTimeOutModoCalor.IsEnabled = argEnabled;
            this.txtTimeOutRecup.IsEnabled = argEnabled;
            this.txtTODUentreCyF.IsEnabled = argEnabled;
            this.txtVelBajaTensionMax.IsEnabled = argEnabled;
            this.txtVelBajaTensionMin.IsEnabled = argEnabled;
            this.txtVelVentModoCalorMax.IsEnabled = argEnabled;
            this.txtVelVentModoCalorMin.IsEnabled = argEnabled;
            this.txtVelVentModoFrioMax.IsEnabled = argEnabled;
            this.txtVelVentModoFrioMin.IsEnabled = argEnabled;

        }

	}
}























