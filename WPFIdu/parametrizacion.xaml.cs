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
      mParam = param;
      LlenarListViewParametros();
          
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        mParam = null;
        param_man.Dispose();
        this.Close();
    }

    List<ParametrosEnsayo> listaparametros = null;
    private void LlenarListViewParametros()
    {
      try
      {
        ltvEnsayo.Items.Clear();
        ParametrosManager param_man = new ParametrosManager();
        listaparametros = param_man.LeerParametrosDeBaseDeDatos();

        for (int i = 0; i < listaparametros.Count; i++)
        {
          ltvEnsayo.Items.Add(listaparametros[i]);
          if (mParam!=null)
            if(mParam.ID==listaparametros[i].ID)
              ltvEnsayo.SelectedIndex=i;
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
      autosizeColumns();
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

    #region resize columns
        private void ResizeGridViewColumn(GridViewColumn column)
        {
          if (double.IsNaN(column.Width))
          {
            column.Width = column.ActualWidth;
          }

          column.Width = double.NaN;
        }

        private void autosizeColumns()
        {
          GridView view = this.ltvEnsayo.View as GridView;
          double width = 0;
          for (int i = 0; i < view.Columns.Count - 1; i++)
          {
            GridViewColumn col = view.Columns[i];
            width += col.ActualWidth;

            //ResizeGridViewColumn(col);
          }
          view.Columns[view.Columns.Count - 1].Width = this.ltvEnsayo.ActualWidth - width; ;

        }
    #endregion resize columns

    private string tgbSelectedSearchString = "";
    private void tgbModelos2012_Checked(object sender, RoutedEventArgs e)
    {
      tgbSelectedSearchString = "2012";
      tgbModelos2010.IsChecked = false;
      tgbModelos2011.IsChecked = false;
      tgbModelosTodos.IsChecked = false;
      filterView();
    }

    private void tgbModelos2011_Checked(object sender, RoutedEventArgs e)
    {
      tgbSelectedSearchString = "2011";
      tgbModelos2010.IsChecked = false;
      tgbModelos2012.IsChecked = false;
      tgbModelosTodos.IsChecked = false;
      filterView();
    }

    private void tgbModelos2010_Checked(object sender, RoutedEventArgs e)
    {
      tgbSelectedSearchString = "2010";
      tgbModelos2012.IsChecked = false;
      tgbModelos2011.IsChecked = false;
      tgbModelosTodos.IsChecked = false;
      filterView();
    }

    private void tgbModelosTodos_Checked(object sender, RoutedEventArgs e)
    {
      tgbModelos2010.IsChecked = false;
      tgbModelos2011.IsChecked = false;
      tgbModelos2012.IsChecked = false;
      tgbSelectedSearchString = "";
      filterView();
    }

    private void filterView()
    {
      try
      {
        ltvEnsayo.Items.Clear();
        if (listaparametros!=null) 
          for (int i = 0; i < listaparametros.Count; i++)
          {
            ListViewItem o = new ListViewItem();
            ParametrosEnsayo oParametrosEnsayo = listaparametros[i];
                
            if (!string.IsNullOrEmpty(tgbSelectedSearchString))
            {
              bool bMatchVersion = (oParametrosEnsayo.Referencia.ToLower().IndexOf(tgbSelectedSearchString) >= 0);
              if (tgbSelectedSearchString == "2010")
              {
                if ((oParametrosEnsayo.Referencia.ToLower().IndexOf("2012") >= 0) || (oParametrosEnsayo.Referencia.ToLower().IndexOf("2011") >= 0))
                  continue;
              }
              else
              {
                if (!bMatchVersion)
                  continue;
              }
            }

            o.Content = oParametrosEnsayo;
            ltvEnsayo.Items.Add(o);
          }
      }
      catch (Exception ex)
      {
        logger.ErrorFormat("filterView() :: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
      , ex.Message
        , ex.StackTrace
      , ex.InnerException != null ? ex.InnerException.Message : "");
        excepcion formexepciones = new excepcion(ex);
        formexepciones.ShowDialog();

      }
      autosizeColumns(); 
      ltvEnsayo.InvalidateVisual();

    }
  }
}