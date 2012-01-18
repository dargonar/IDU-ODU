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
	public partial class parametrizacion
	{
        public ParametrosEnsayo mParam = null;
        private ParametrosManager param_man = null;
        private static readonly ILog logger = LogManager.GetLogger(typeof(parametrizacion));


		public parametrizacion()
		{
			this.InitializeComponent();
      param_man = new ParametrosManager();
      LlenarListViewParametros();
		}

        
        
        
        public parametrizacion(ParametrosEnsayo param)
        {
            this.InitializeComponent();
            param_man = new ParametrosManager();
            LlenarListViewParametros();
            mParam = param;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            mParam = null;
            param_man.Dispose();
            this.Close();
        }

  
        private void LlenarListViewParametros()
        {

            try
            {

                ltvEnsayo.Items.Clear();
                ParametrosManager param_man = new ParametrosManager();
                List<ParametrosEnsayo> listaparametros = param_man.LeerParametrosDeBaseDeDatos();

                for (int i = 0; i < listaparametros.Count; i++)
                {

                    ltvEnsayo.Items.Add(listaparametros[i]);
                }

            }
            catch (Exception ex)
            {

                logger.ErrorFormat("LlenarListViewParametros():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
        }

  

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.SuperAdmin))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
            try
            {

                if (ltvEnsayo.SelectedIndex < 0)
                    return;

                if (confirmacioneliminar.Show("Eliminar parametros","Esta seguro que desea eliminar los parametros seleccionados ? ") == false)
                    return;

                ParametrosEnsayo param = ltvEnsayo.SelectedItem as ParametrosEnsayo;
                logger.InfoFormat("btnEliminar_Click(). Referencia de Modelo eliminada desde BBDD: Id=[{0}] Descripción=[{1} - {2}]"
                  , mParam.ID.ToString(), mParam.Descripcion, mParam.Referencia); 
                param_man.EliminarParametros(param);
                LlenarListViewParametros();

            }

            catch (Exception ex)
            {

                logger.ErrorFormat("btnEliminar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();
            }
            
        }

      
        private void btnLeerParametros_Click(object sender, RoutedEventArgs e)
        {
            
          try
          {

              if (ltvEnsayo.SelectedIndex < 0)
                  return;
              mParam = ltvEnsayo.SelectedItem as ParametrosEnsayoIDU; //as ParametrosEnsayo
              param_man.Dispose();
              logger.InfoFormat("btnLeerParametros_Click(). Referencia de Modelo leída desde BBDD: Id=[{0}] Descripción=[{1} - {2}]"
                    , mParam.ID, mParam.Descripcion, mParam.Referencia);
              this.Close();

          }
          catch (Exception ex)
          {
              logger.ErrorFormat("btnLeerParametros_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
           , ex.Message
           , ex.StackTrace
           , ex.InnerException != null ? ex.InnerException.Message : "");
              excepcion formularioexcepciones = new excepcion(ex);
              formularioexcepciones.ShowDialog();
          }
        }

        private void btnSobreescribir_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.SuperAdmin))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
          
          try
          {

            if (ltvEnsayo.SelectedIndex < 0)
                return;

            if (confirmacioneliminar.Show("Sobreescribir parametros", "Esta seguro que desea sobreescribir los parametros ? ") == false)
                return;

            logger.InfoFormat("btnSobreescribir_Click(). Referencia de Modelo sobreescrita desde BBDD: Id=[{0}] Descripción=[{1} - {2}]"
                , mParam.ID, mParam.Descripcion, mParam.Referencia);
            ParametrosEnsayo parametrosviejos = ltvEnsayo.SelectedItem as ParametrosEnsayo;

            param_man.ModificarParametros(parametrosviejos, mParam);
            //LlenarListViewParametros();
            mParam = null;
            param_man.Dispose();
            this.Close();
          }
          catch (Exception ex)
          {
            logger.Error("btnSobreescribir_Click()",ex);
            excepcion formularioexcepciones = new excepcion(ex);
            formularioexcepciones.ShowDialog();
            formularioexcepciones=null;
          }
        }

        private void btnGuardarNuevo_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.SuperAdmin))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
          
          try
          {
            logger.InfoFormat("btnGuardarNuevo_Click(). Referencia de Modelo nueva en BBDD: Id=[?] Descripción=[{1} - {2}]"
                , mParam.Descripcion, mParam.Referencia);
            param_man.GuardarParametrosEnBaseDeDatos(mParam);
            LlenarListViewParametros();
            mParam = null;
            param_man.Dispose();
            this.Close();
                
          }
          catch (Exception ex)
          {
              logger.ErrorFormat("btnGuardarNuevo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
             , ex.Message
                , ex.StackTrace
             , ex.InnerException != null ? ex.InnerException.Message : "");
              excepcion formularioexcepciones = new excepcion(ex);
              formularioexcepciones.ShowDialog();
          }
        }
    }
}