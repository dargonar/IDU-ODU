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
using iDU.CommonObjects;
using System.Collections.Generic;
using log4net;

namespace dcf001
{
	public partial class mantenimientoreferencias
	{

        private static readonly ILog logger = LogManager.GetLogger(typeof(mantenimientoreferencias));
        private VersionEquiposManager ManejadorVersiones;
        private CaracteristicasTecnicasManager ManejadorCaracteristicasTecnicas;
        private ParametrosManager param_manag;
        private int IDseleccionado;
        private int Opcion;

		public mantenimientoreferencias()
		{
			this.InitializeComponent();
            ManejadorVersiones = new VersionEquiposManager();
            ManejadorCaracteristicasTecnicas = new CaracteristicasTecnicasManager();
            param_manag = new ParametrosManager();
            LlenarListView();
            //LlenarVersiones();
            LlenarCmbParametros();
			
			
		}

        private void LlenarCmbParametros()
        {
            
            List<ParametrosEnsayo> listaparametros = param_manag.LeerParametrosDeBaseDeDatos();

            for (int i = 0; i < listaparametros.Count; i++)
            {
                cmbParametros.Items.Add(listaparametros[i]);
             

            }

            cmbParametros.SelectedIndex = 0;
        }


        /*private void LlenarVersiones()
        {
            VersionEquiposManager ManagerVersiones = new VersionEquiposManager();
            List<VersionEquipo> ListaVersiones = ManagerVersiones.ObtenerVersiones();
            // cmbVersion.Items.AddRange((ListaVersiones.ToArray())); en vs2008 no existe AddRange

            for (int i = 0; i < ListaVersiones.Count; i++)
            {
                cmbVersion.Items.Add(ListaVersiones[i]);

            }

            cmbVersion.SelectedIndex = 0;
        }*/

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (param_manag != null)
                param_manag.Dispose();
            this.Close();
        }

        private void ModoAgregar()
        {

            ModoAgregar(true);
        }


        private void ModoAgregar(bool vaciar)
        {
            if (vaciar)
                VaciarReferenciaSeleccionada();

    
            HabilitarTextBoxs();
          //  cmbVersion.IsEnabled = true;
            cmbParametros.IsEnabled = true;
            
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnAgregar.IsEnabled = false;

            Opcion = 1;
        }

        private void ModoModificar()
        {

           
            HabilitarTextBoxs();
           // cmbVersion.IsEnabled = true;
            cmbParametros.IsEnabled = true;

            btnAgregar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            Opcion = 2;
        }

        private void ModoZero()
        {



            DeshabilitarTextBoxs();

            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnAgregar.IsEnabled = true;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
           // cmbVersion.IsEnabled = false;
            cmbParametros.IsEnabled = false;

        }


        private void VaciarReferenciaSeleccionada()
        {
            txtCapacidadCalor.Text = "";
            txtCapacidadFrio.Text = "";
            txtCorrienteMaxima.Text = "";
            txtCorrNominalC.Text = "";
            txtCorrNominalF.Text = "";
            txtDescripcion1.Text = "";
            txtDescripcion2.Text = "";
            txtDescripcion3.Text = "";
            txtDescripcion4.Text = "";
            txtDescripcion5.Text = "";
            txtDescripcion6.Text = "";
            txtErr.Text = "";
            txtFrecuencia.Text = "";
            txtHCFC22.Text = "";
            txtPeso.Text = "";
            txtPotenciaMaxima.Text = "";
            txtPotNominalC.Text = "";
            txtPotNominalF.Text = "";
            txtPresionAB.Text = "";
            txtReferencias.Text = "";
            txtTensionNominal.Text = "";
          //  cmbVersion.SelectedIndex = 0;
            cmbParametros.SelectedIndex = 0;

        }



        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ModoAgregar();
            return;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (ltvReferencias.SelectedIndex<0)
                return;
            ModoModificar();
            return;
        }


        private void HabilitarTextBoxs()
        {
            txtTensionNominal.IsEnabled = true;
            txtReferencias.IsEnabled = true;
            txtPresionAB.IsEnabled = true;
            txtPotNominalF.IsEnabled = true;
            txtPotNominalC.IsEnabled = true;
            txtPotenciaMaxima.IsEnabled = true;
            txtPeso.IsEnabled = true;
            txtHCFC22.IsEnabled = true;
            txtFrecuencia.IsEnabled = true;
            txtErr.IsEnabled = true;
            txtDescripcion6.IsEnabled = true;
            txtDescripcion5.IsEnabled = true;
            txtDescripcion4.IsEnabled = true;
            txtDescripcion3.IsEnabled = true;
            txtDescripcion2.IsEnabled = true;
            txtDescripcion1.IsEnabled = true;
            txtCorrNominalF.IsEnabled = true;
            txtCorrNominalC.IsEnabled = true;
            txtCorrienteMaxima.IsEnabled = true;
            txtCapacidadFrio.IsEnabled = true;
            txtCapacidadCalor.IsEnabled = true;
           

        }


        private void DeshabilitarTextBoxs()
        {
            txtTensionNominal.IsEnabled = false;
            txtReferencias.IsEnabled = false;
            txtPresionAB.IsEnabled = false;
            txtPotNominalF.IsEnabled = false;
            txtPotNominalC.IsEnabled = false;
            txtPotenciaMaxima.IsEnabled = false;
            txtPeso.IsEnabled = false;
            txtHCFC22.IsEnabled = false;
            txtFrecuencia.IsEnabled = false;
            txtErr.IsEnabled = false;
            txtDescripcion6.IsEnabled = false;
            txtDescripcion5.IsEnabled = false;
            txtDescripcion4.IsEnabled = false;
            txtDescripcion3.IsEnabled = false;
            txtDescripcion2.IsEnabled = false;
            txtDescripcion1.IsEnabled = false;
            txtCorrNominalF.IsEnabled = false;
            txtCorrNominalC.IsEnabled = false;
            txtCorrienteMaxima.IsEnabled = false;
            txtCapacidadFrio.IsEnabled = false;
            txtCapacidadCalor.IsEnabled = false;


        }

        private void MostrarDetallesCaracteristicasTecnicas(int indiceseleccionado)
        {
            try
            {

                CaracteristicasTecnicas oCaracteristicas = (CaracteristicasTecnicas)ltvReferencias.SelectedItem;

                IDseleccionado = oCaracteristicas.ID;
                txtCapacidadCalor.Text = oCaracteristicas.CapacidadCalor;
                txtCapacidadFrio.Text = oCaracteristicas.CapacidadFrio;
                txtCorrienteMaxima.Text = oCaracteristicas.CorrienteMaxima;
                txtCorrNominalC.Text = oCaracteristicas.CorrienteNominalCalor;
                txtCorrNominalF.Text = oCaracteristicas.CorrienteNominalFrio;
                txtDescripcion1.Text = oCaracteristicas.Descripcion1;
                txtDescripcion2.Text = oCaracteristicas.Descripcion2;
                txtDescripcion3.Text = oCaracteristicas.Descripcion3;
                txtDescripcion4.Text = oCaracteristicas.Descripcion4;
                txtDescripcion5.Text = oCaracteristicas.Descripcion5;
                txtDescripcion6.Text = oCaracteristicas.Descripcion6;
                txtErr.Text = oCaracteristicas.Err;
                txtFrecuencia.Text = oCaracteristicas.Frecuencia;
                txtHCFC22.Text = oCaracteristicas.Carga;
                txtPeso.Text = oCaracteristicas.Peso;
                txtPotenciaMaxima.Text = oCaracteristicas.PotenciaMaxima;
                txtPotNominalC.Text = oCaracteristicas.PotenciaNominalCalor;
                txtPotNominalF.Text = oCaracteristicas.PotenciaNominalFrio;
                txtPresionAB.Text = oCaracteristicas.Presion;
                txtReferencias.Text = oCaracteristicas.Nombre;
                txtTensionNominal.Text = oCaracteristicas.TensionNominal;


                /* for (int i = 0; i < cmbVersion.Items.Count; i++)
                 {
                     if (((VersionEquipo)cmbVersion.Items[i]).ID == oCaracteristicas.Version)
                     {
                         cmbVersion.SelectedIndex = i;
                         break;

                     }

                 }*/



                for (int i = 0; i < cmbParametros.Items.Count; i++)
                {
                    if (((ParametrosEnsayo)cmbParametros.Items[i]).ID == oCaracteristicas.IdParametros)
                    {
                        cmbParametros.SelectedIndex = i;
                        break;

                    }

                }

            }
            catch (Exception ex)
            {

                logger.ErrorFormat(" MostrarDetallesCaracteristicasTecnicas(int indiceseleccionado):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();

            }
        }


        private void LlenarListView()
        {

            try
            {



                ltvReferencias.Items.Clear();


                List<CaracteristicasTecnicas> ListaCT = ManejadorCaracteristicasTecnicas.ObtenerCaracteristicasTecnicas();

                foreach (CaracteristicasTecnicas ct in ListaCT)
                {
                   

                    ltvReferencias.Items.Add(ct);

                }

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("(REFERENCIAS)LlenarListView():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();

            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ModoZero();


            if (ltvReferencias.SelectedIndex<0)
                return;
         
            
            MostrarDetallesCaracteristicasTecnicas(ltvReferencias.SelectedIndex);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ltvReferencias.SelectedIndex < 0)
                    return;

   
               if( confirmacioneliminar.Show("Eliminar referencia","¿Esta seguro que desea eliminar la referencia?")==false)
                return;

                CaracteristicasTecnicas oCaracteristicas = (CaracteristicasTecnicas)ltvReferencias.SelectedItem;



                int indiceseleccionado = ltvReferencias.SelectedIndex;
                int cantidaddeitems = ltvReferencias.Items.Count;

                 ManejadorCaracteristicasTecnicas.EliminarCaracteristicaTecnica(oCaracteristicas);
                 LlenarListView();

                if (ltvReferencias.Items.Count == 0)
                {
                    VaciarReferenciaSeleccionada();
                    return;
                }


                else
                {

                    if (indiceseleccionado == cantidaddeitems - 1)
                    {
                        ltvReferencias.SelectedIndex = indiceseleccionado - 1;
                    }
                    else
                    {
                        ltvReferencias.SelectedIndex = indiceseleccionado;
                    }

                }





             
                MostrarDetallesCaracteristicasTecnicas(ltvReferencias.SelectedIndex);


              

            }
            catch(MySql.Data.MySqlClient.MySqlException mysqlex)
            {
                //mysqlex.ErrorCode
                logger.ErrorFormat("btn_Eliminar()::MySqlException:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}', ErrCode:'{3}' "
                    , mysqlex.Message
                    , mysqlex.StackTrace
                    , mysqlex.InnerException != null ? mysqlex.InnerException.Message : ""
                    , mysqlex.ErrorCode);

                excepcion formularioexepciones = new excepcion(mysqlex);
                formularioexepciones.ShowDialog();
            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btn_Eliminar(object sender , RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                 , ex.Message
                  , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();
            }
        }

        private CaracteristicasTecnicas GuardarDatosEnObjeto()
        {
           // try
           // {

                CaracteristicasTecnicas nuevac = new CaracteristicasTecnicas();



                // nuevac.Version = ((VersionEquipo)cmbVersion.SelectedItem).ID;
                nuevac.IdParametros = ((ParametrosEnsayo)cmbParametros.SelectedItem).ID;
                nuevac.Descripcion1 = txtDescripcion1.Text;
                nuevac.Descripcion2 = txtDescripcion2.Text;
                nuevac.Descripcion3 = txtDescripcion3.Text;
                nuevac.Descripcion4 = txtDescripcion4.Text;
                nuevac.Descripcion5 = txtDescripcion5.Text;
                nuevac.Descripcion6 = txtDescripcion6.Text;
                nuevac.TensionNominal = txtTensionNominal.Text;
                nuevac.Frecuencia = txtFrecuencia.Text;
                nuevac.PotenciaMaxima = txtPotenciaMaxima.Text;
                nuevac.CorrienteMaxima = txtCorrienteMaxima.Text;
                nuevac.Carga = txtHCFC22.Text;
                nuevac.Presion = txtPresionAB.Text;
                nuevac.CapacidadFrio = txtCapacidadFrio.Text;
                nuevac.PotenciaNominalCalor = txtPotNominalC.Text;
                nuevac.PotenciaNominalFrio = txtPotNominalF.Text;
                nuevac.CorrienteNominalCalor = txtCorrNominalC.Text;
                nuevac.CorrienteNominalFrio = txtCorrNominalF.Text;
                nuevac.Peso = txtPeso.Text;
                nuevac.CapacidadCalor = txtCapacidadCalor.Text;
                nuevac.Err = txtErr.Text;
                nuevac.Nombre = txtReferencias.Text;
                return nuevac;
         // }
            //catch (Exception ex)
          //  {

           //     logger.ErrorFormat("CaracteristicasTecnicas GuardarDatosEnObjeto():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
           //      , ex.Message
            //      , ex.StackTrace
             //     , ex.InnerException != null ? ex.InnerException.Message : "");
            //    excepcion formexcepcion = new excepcion(ex);
             //   formexcepcion.ShowDialog();


          //  }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
         

           /* if (cmbVersion.SelectedIndex < 0)
            {

                confirmacioneliminar.Show("Debe seleccionar una version");
                return;
            }*/

            if (cmbParametros.SelectedIndex < 0)
            {
                confirmacioneliminar.Show("Debe seleccionar parametros de ensayo");
                return;
            }


            CaracteristicasTecnicas nuevact = GuardarDatosEnObjeto(); 


            switch (Opcion)
            {
                case 1:


                    try
                    {

                        ManejadorCaracteristicasTecnicas.AgregarCaracteristicaTecnica(nuevact);

                        LlenarListView();
                        ModoZero();
                        ltvReferencias.SelectedIndex = ltvReferencias.Items.Count - 1;


                    }

                    catch (Exception ex)
                    {

                        logger.ErrorFormat("(AGREGAR)btnGuardar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                        , ex.Message
                        , ex.StackTrace
                        , ex.InnerException != null ? ex.InnerException.Message : "");
                        
                        excepcion formularioexcepciones = new excepcion(ex);
                        formularioexcepciones.ShowDialog();

                    }


                    break;

                case 2:


                    try
                    {


                        if (ltvReferencias.SelectedIndex < 0)
                            return;



                        nuevact.ID = IDseleccionado;
                        int indiceseleccionado = ltvReferencias.SelectedIndex;

                        ManejadorCaracteristicasTecnicas.ModificarCaracteristicaTecnica(nuevact);
                        LlenarListView();
                        ltvReferencias.SelectedIndex = indiceseleccionado;
                        MostrarDetallesCaracteristicasTecnicas(indiceseleccionado);




                        ModoZero();

                    }
                    catch (Exception ex)
                    {
                        logger.ErrorFormat("(MODIFICAR)btnGuardar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                               , ex.Message
                               , ex.StackTrace
                               , ex.InnerException != null ? ex.InnerException.Message : "");
                        excepcion formularioexepciones = new excepcion(ex);
                        formularioexepciones.ShowDialog();
                    }


                    break;
            }
        }

        private void ltvReferencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ModoZero();

            if (ltvReferencias.SelectedIndex < 0)
                return;
            else
                MostrarDetallesCaracteristicasTecnicas(ltvReferencias.SelectedIndex);
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

   

       

	}
}





