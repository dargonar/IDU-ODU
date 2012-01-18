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
	public partial class mantenimientomodelos
	{
        private static readonly ILog logger = LogManager.GetLogger(typeof(mantenimientomodelos));
        private int opcion = -1;
        private int IDseleccionado = -1;
        private EtiquetaManager ManejadorEtiquetas;

        private ModelosManager Manejadormodelos;

		public mantenimientomodelos()
		{

            try
            {
           
                


                this.InitializeComponent();
                Manejadormodelos = new ModelosManager();
                ManejadorEtiquetas = new EtiquetaManager();
                CaracteristicasTecnicasManager cart_m = new CaracteristicasTecnicasManager();
                ImagenesManager ManejadorImagenes = new ImagenesManager();


                List<Etiqueta> listaetiquetas = ManejadorEtiquetas.ObtenerEtiquetas();
                List<CaracteristicasTecnicas> listacaracteristicastecnicas = cart_m.ObtenerCaracteristicasTecnicas();
                List<string> listalogos = ManejadorImagenes.NombresDirectorioLogos();
                List<string> listaean13 = ManejadorImagenes.NombresDirectorioEAN13();
                List<string> listacapacidad = ManejadorImagenes.NombresDirectorioCapacidad();
                List<string> listadimensiones = ManejadorImagenes.NombresDirectorioDimension();

                
                

                for (int i = 0; i < listaetiquetas.Count; i++)
                {

                    cmbFormatoEtiqueta.Items.Add(listaetiquetas[i]);
                    cmbEtiquetaCaja.Items.Add(listaetiquetas[i]);
                }




                for (int i = 0; i < listacaracteristicastecnicas.Count; i++)
                {

                    cmbReferencia.Items.Add(listacaracteristicastecnicas[i]);
                }

                for (int i = 0; i < listalogos.Count; i++)
                {

                    cmbLogo.Items.Add(listalogos[i]);
                }

                for (int i = 0; i < listaean13.Count; i++)
                {

                    cmbEan13.Items.Add(listaean13[i]);

                }

                for (int i = 0; i < listacapacidad.Count; i++)
                {
                    cmbCapacidad.Items.Add(listacapacidad[i]);
                }

                for (int i = 0; i < listadimensiones.Count; i++)
                {
                    cmbDimensiones.Items.Add(listadimensiones[i]);
                }


                //LlenarGrilla();
                LlenarListView();

            }

            catch (Exception ex)
            {
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();

            }
        }

        private void LlenarListView()
        {



            try
            {


                //ltvEnsayos.Items.Clear();
                ltvModelos.Items.Clear();


                List<Modelo> ListaModelos = Manejadormodelos.ObtenerModelos();

                foreach (Modelo m in ListaModelos)
                {
                    /*System.Windows.Forms.ListViewItem l = new System.Windows.Forms.ListViewItem(
                      new string[]{ensayo.Marca, ensayo.Modelo,ensayo.Serie,ensayo.Fecha.ToString(),
                      ensayo.Aprobado.ToString(),ensayo.DCF});
                
                      l.Tag = ensayo;*/

                    int i = ltvModelos.Items.Add(m);
                    //ltvModelos.ItemContainerStyle.  
                   

                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("LlenarListView :: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                   , ex.Message
                   , ex.StackTrace
                   , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexepciones = new excepcion(ex);
                formularioexepciones.ShowDialog();

            }
        }


        private void GuardarDatosEnObjeto(Modelo nuevom)
        {
            try
            {

                nuevom.Etiqueta = ((Etiqueta)cmbFormatoEtiqueta.SelectedItem).Id;
                nuevom.EtiquetaCaja = ((Etiqueta)cmbEtiquetaCaja.SelectedItem).Id;
                nuevom.Referencia = ((CaracteristicasTecnicas)cmbReferencia.SelectedItem).Nombre;



                nuevom.Marca = txtMarca.Text;
                nuevom.Nombremodelo = txtModelo.Text;
                nuevom.Codigo = txtCodigo.Text;

                nuevom.Ean13 = cmbEan13.SelectedItem.ToString();
                nuevom.Logo = cmbLogo.SelectedItem.ToString();
                nuevom.Capacidad = cmbCapacidad.SelectedItem.ToString();
                nuevom.CodigoICSA = txtCodigoICSA.Text;
                nuevom.Conjunto = txtConjunto.Text;
                nuevom.Descripcion = txtDescripcion.Text;
                nuevom.Dimension = cmbDimensiones.SelectedItem.ToString();
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("GuardarDatosEnObjeto(Modelo nuevom) :: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                   , ex.Message
                   , ex.StackTrace
                   , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();
            }
        }


        private void MostrarDetallesModelo(int iselectedRowIndex)
        {
            try
            {


                Modelo oModelo = (Modelo)ltvModelos.SelectedItem; //recupero el objeto de la grilla



                IDseleccionado = oModelo.ID;
                txtMarca.Text = oModelo.Marca;
                txtModelo.Text = oModelo.Nombremodelo;
                txtCodigoICSA.Text = oModelo.CodigoICSA;
                txtCodigo.Text = oModelo.Codigo;


                for (int i = 0; i < cmbReferencia.Items.Count; i++)
                {
                    if (((CaracteristicasTecnicas)cmbReferencia.Items[i]).Nombre == oModelo.Referencia)
                    {
                        cmbReferencia.SelectedIndex = i;
                        break;

                    }

                }




                for (int i = 0; i < cmbEan13.Items.Count; i++)
                {
                    if (cmbEan13.Items[i].ToString().ToUpper() == oModelo.Ean13.ToUpper())
                    {

                        cmbEan13.SelectedIndex = i;
                        break;
                    }

                }

                for (int i = 0; i < cmbLogo.Items.Count; i++)
                {

                    if (cmbLogo.Items[i].ToString().ToUpper() == oModelo.Logo.ToUpper())
                    {

                        cmbLogo.SelectedIndex = i;
                        break;
                    }
                }


                txtDescripcion.Text = oModelo.Descripcion;
                txtConjunto.Text = oModelo.Conjunto;



                for (int i = 0; i < cmbCapacidad.Items.Count; i++)
                {

                    if (cmbCapacidad.Items[i].ToString().ToUpper() == oModelo.Capacidad.ToUpper())
                    {

                        cmbCapacidad.SelectedIndex = i;
                        break;
                    }
                }





                for (int i = 0; i < cmbDimensiones.Items.Count; i++)
                {

                    if (cmbDimensiones.Items[i].ToString().ToUpper() == oModelo.Dimension.ToUpper())
                    {

                        cmbDimensiones.SelectedIndex = i;
                        break;
                    }
                }



                for (int i = 0; i < cmbEtiquetaCaja.Items.Count; i++)
                {

                    if (((Etiqueta)cmbEtiquetaCaja.Items[i]).Id == oModelo.EtiquetaCaja)
                    {

                        cmbEtiquetaCaja.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbFormatoEtiqueta.Items.Count; i++)
                {

                    if (((Etiqueta)cmbFormatoEtiqueta.Items[i]).Id == oModelo.Etiqueta)
                    {

                        cmbFormatoEtiqueta.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("MostrarDetallesModelo(int iselectedRowIndex):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                   , ex.Message
                   , ex.StackTrace
                   , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);
                formexcepcion.ShowDialog();

            }
         }

        public void VaciarModeloSeleccionado()
        {

            
            DeshabilitarTextBoxs();
          
            txtCodigoICSA.Text = "";
            txtCodigo.Text = "";
            txtConjunto.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            cmbEan13.SelectedIndex = -1;
            cmbDimensiones.SelectedIndex = -1;
            cmbCapacidad.SelectedIndex = -1;
            cmbEtiquetaCaja.SelectedIndex = -1;
            cmbFormatoEtiqueta.SelectedIndex = -1;
            cmbLogo.SelectedIndex = -1;
            cmbReferencia.SelectedIndex = -1;
            
        }

        private void DeshabilitarTextBoxs()
        {
            txtModelo.IsEnabled = false;
            txtMarca.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            txtConjunto.IsEnabled = false;
            txtCodigoICSA.IsEnabled = false;
            txtCodigo.IsEnabled = false;
            cmbReferencia.IsEnabled = false;
            cmbLogo.IsEnabled = false;
            cmbFormatoEtiqueta.IsEnabled = false;
            cmbEtiquetaCaja.IsEnabled = false;
            cmbEan13.IsEnabled = false;
            cmbDimensiones.IsEnabled = false;
            cmbCapacidad.IsEnabled = false;
            

        }

        private void HabilitarTextBoxs()
        {

            txtModelo.IsEnabled = true;
            txtMarca.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtConjunto.IsEnabled = true;
            txtCodigoICSA.IsEnabled = true;
            txtCodigo.IsEnabled = true;
            cmbReferencia.IsEnabled = true;
            cmbLogo.IsEnabled = true;
            cmbFormatoEtiqueta.IsEnabled = true;
            cmbEtiquetaCaja.IsEnabled = true;
            cmbEan13.IsEnabled =true;
            cmbDimensiones.IsEnabled = true;
            cmbCapacidad.IsEnabled = true;

        }

       // #region MODOSABM

        private void ModoZero()
        {

           
            DeshabilitarTextBoxs();
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            
           
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;
      
            btnAgregar.IsEnabled =true;

        

        }


        private void ModoAgregar()
        {

            ModoAgregar(false);
        }

        private void ModoAgregar(bool vaciar)
        {
            if (vaciar)
                VaciarModeloSeleccionado();
         
            HabilitarTextBoxs();
            
          

            btnGuardar.IsEnabled =true;
            btnCancelar.IsEnabled =true;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled =false;
            btnAgregar.IsEnabled = false;

            opcion = 1;
        }

        private void ModoModificar()
        {

       
            HabilitarTextBoxs();
        
            btnAgregar.IsEnabled =false;
            btnModificar.IsEnabled =false;
            btnEliminar.IsEnabled =false;
            btnGuardar.IsEnabled =true;
            btnCancelar.IsEnabled =true;
            opcion = 2;
        
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ModoAgregar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (ltvModelos.SelectedIndex < 0 )
                return;
            else
                ModoModificar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ltvModelos.SelectedIndex<0)
                    return;


               if( confirmacioneliminar.Show("Eliminar modelo", "¿Esta seguro que desea eliminar el modelo?")==false)

                    return;

                Modelo oModelo = (Modelo)ltvModelos.SelectedItem;



                int indiceseleccionado = ltvModelos.SelectedIndex;
                int cantidaddeitems = ltvModelos.Items.Count;
              
                Manejadormodelos.EliminarModelo(oModelo);
                LlenarListView();

                if (ltvModelos.Items.Count == 0)
                {
                    VaciarModeloSeleccionado();
                    return;
                }


                else
                {

                    if (indiceseleccionado == cantidaddeitems - 1)
                    {
                        ltvModelos.SelectedIndex = indiceseleccionado - 1;
                    }
                    else
                    {
                        ltvModelos.SelectedIndex = indiceseleccionado;
                    }

                }

                

                
             
                MostrarDetallesModelo(ltvModelos.SelectedIndex);


             

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("btnEliminar_Click(Object sender , RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
  
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ModoZero();

            if (ltvModelos.SelectedIndex < 0)
                return;
            //FuncionesGrilla.CambiarIndiceSeleccionadoTabla(Modelosgrid, FuncionesGrilla.IndiceSeleccionado(Modelosgrid));
            MostrarDetallesModelo(ltvModelos.SelectedIndex);

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Modelo nuevom = new Modelo();

            if (cmbFormatoEtiqueta.SelectedIndex < 0)
            {

                confirmacioneliminar.Show("Debe seleccionar un formato de etiqueta para el modelo");
                return;
            }

            if (cmbEtiquetaCaja.SelectedIndex < 0)
            {
                confirmacioneliminar.Show("Debe seleccionar un formato de etiqueta para la caja del modelo");
                return;

            }

            if (cmbReferencia.SelectedIndex < 0)
            {

                confirmacioneliminar.Show("Debe seleccionar una referencia");
                return;
            }

            if (cmbDimensiones.SelectedIndex < 0)
            {
                confirmacioneliminar.Show("Debe seleccionar una dimension");
                return;
            }

            if (cmbCapacidad.SelectedIndex < 0)
            {
                confirmacioneliminar.Show("Debe seleccionar una capacidad");
                return;
            }

            if (cmbEan13.SelectedIndex < 0)
            {

                confirmacioneliminar.Show("Debe seleccionar un EAN13");
                return;
            }

            GuardarDatosEnObjeto(nuevom);


            switch (opcion)
            {
                case 1://insertar modelo


                    try
                    {

                        Manejadormodelos.AgregarModelo(nuevom);



                        //Modelosgrid.Rows.Clear();
                       // ltvModelos.Items.Clear();
                         LlenarListView();
                        ModoZero();
                        //  FuncionesGrilla.CambiarIndiceSeleccionadoTabla(Modelosgrid, Modelosgrid.Rows.Count - 1);
                        ltvModelos.SelectedIndex = ltvModelos.Items.Count - 1;


                    }

                    catch (Exception ex)
                    {
                        logger.ErrorFormat("(AGREGAR)btnGuardar_Click:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
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


                        if (ltvModelos.SelectedIndex < 0)
                            return;



                        nuevom.ID = IDseleccionado;
                        int indiceseleccionado = ltvModelos.SelectedIndex;
                        Manejadormodelos.ModificarModelo(nuevom); 
                        LlenarListView();
                        ltvModelos.SelectedIndex = indiceseleccionado;
                        MostrarDetallesModelo(indiceseleccionado);



    
                        ModoZero();

                    }
                    catch (Exception ex)
                    {
                        logger.ErrorFormat("(MODIFICAR)btnGuardar_Click:: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                      , ex.Message
                      , ex.StackTrace
                      , ex.InnerException != null ? ex.InnerException.Message : "");
                        excepcion formularioexcepciones = new excepcion(ex);
                        formularioexcepciones.ShowDialog();
                    }


                    break;


            }
        }

        private void ltvModelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ModoZero();

            if (ltvModelos.SelectedIndex<0)
                return;
            else
                MostrarDetallesModelo(ltvModelos.SelectedIndex);
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







