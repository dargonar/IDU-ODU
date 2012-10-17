using System;
using System.IO;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Forms;
using iDU.CommonObjects;
using iDU.BL;
using log4net;
using System.Configuration;

namespace dcf001
{
	public partial class ensayos
	{
    private EnsayosManager ManejadorEnsayos;
    private static readonly ILog logger = LogManager.GetLogger(typeof(ensayos));
        

		public ensayos()
		{
			this.InitializeComponent();
      ManejadorEnsayos = new EnsayosManager();
      dpkDesde.Value = DateTime.Now.Date;
      dpkHasta.Value = DateTime.Now.Date;

      lblCambiando.Visibility = Visibility.Hidden;
      loadingImg.Visibility = Visibility.Hidden;

      btnReimprimirCaja.IsEnabled = false;
      btnReimprimirProducto.IsEnabled = false;

      LlenarEnsayos(true);
		}

    private void HideLoadingUIComponent()
    {
      lblCambiando.Visibility = Visibility.Hidden;
      loadingImg.Visibility = Visibility.Hidden; 
      
      this.IsEnabled = true;
      this.InvalidateVisual();
      this.InvalidateArrange();
      this.UpdateLayout();
    }

    private void ShowLoadingUIComponent()
    {
      
      lblCambiando.Visibility = Visibility.Visible;
      loadingImg.Visibility = Visibility.Visible;
      this.IsEnabled = false;
      this.InvalidateVisual();
      this.InvalidateArrange();
      this.UpdateLayout();

      System.Windows.Forms.Application.DoEvents();

    }

    private void LlenarEnsayos() {
      LlenarEnsayos(true);
    }

    private void LlenarEnsayos(bool ensayos_del_dia)
    {
      //ShowLoadingUIComponent();
      try
      {
        ltvEnsayos.Items.Clear();

        if (ensayos_del_dia)
        {
          EnsayosManager emgr = new EnsayosManager();
          List<Ensayos> ensayosDelDia = emgr.ObtenerEnsayosPorFecha(DateTime.Today, DateTime.Today.AddHours(24));

          foreach (Ensayos ensayo in ensayosDelDia)
          {
            ltvEnsayos.Items.Add(ensayo);
          }
        }
        else
        {
          foreach (Ensayos ensayo in ListaEnsayos)
          {
            ltvEnsayos.Items.Add(ensayo);
          }
        }

      }
      catch (Exception ex)
      {
        logger.Error("LlenarEnsayos()", ex);
        excepcion formexcepciones = new excepcion(ex);
        formexcepciones.ShowDialog();
        formexcepciones = null;

      }
      //finally{
      //  HideLoadingUIComponent();
      //}
      if (ensayos_del_dia)
        HideLoadingUIComponent();

      if (ensayos_del_dia && ltvEnsayos.Items.Count <= 0)
      {
        excepcion oMsg = new excepcion("Listado de ensayos", "No hay ensayos que mostrar");
        oMsg.ShowDialog();
        oMsg = null;
      }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnEliminarFallas_Click(object sender, RoutedEventArgs e)
    {
      excepcion exc = new excepcion("Eliminar Fallas", "Esta función se encuentra temporalmente deshabilitada.");
      exc.ShowDialog();
      exc = null;
          
      return;
          
      if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Administrador))
      {
        // excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
        // exc.ShowDialog();
        // exc = null;
        // return;
      }
       
      try
        {

            if (confirmacioneliminar.Show("Eliminar fallas", "Esta seguro de que desea eliminar todas las fallas ? ") == false)
                return;

            Teclado tec = new Teclado();

            tec.ShowDialog();

            WPFiDU.BL.ManagerUsuarios usermanager= new WPFiDU.BL.ManagerUsuarios();


            if (tec.Password == usermanager.ObtenerPasswordUsuario("ADMINISTRADOR") || tec.Password == usermanager.ObtenerPasswordUsuario("SUPERADMINISTRADOR"))
            {
                ManejadorEnsayos.EliminarFallas();
                LlenarEnsayos();
            }
            else
            {

                confirmacioneliminar.Show("Password incorrecto");
            }
        }
        catch(Exception  ex)
        {
           
            logger.Error("btnEliminarFallas_Click()", ex);
            excepcion formularioexepciones = new excepcion(ex);
            formularioexepciones.ShowDialog();
            formularioexepciones=null;
        }
    }

    private void btnEliminarRegistro_Click(object sender, RoutedEventArgs e)
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
        if (ltvEnsayos.SelectedIndex < 0)
            return;


        if (confirmacioneliminar.Show("Eliminar Ensayo", "Esta seguro de que desea eliminar el ensayo seleccionado? ") != true)
            return;
        Ensayos ens = ltvEnsayos.SelectedItem as Ensayos;
        
        logger.InfoFormat("btnEliminar_Click(). Ensayo eliminado desde BBDD: Id=[{0}]; Marca=[{1}]; Modelo=[{2}]; NroSerie=[{3}]; OF=[{4}]; FechaEnsayo=[{5}]", ens.ID.ToString(), ens.Marca, ens.Modelo, ens.Serie, ens.OrdenFabricacion, ens.Fecha.ToString());             

        
        ltvEnsayos.Items.Remove(ltvEnsayos.SelectedItem);
        ManejadorEnsayos.EliminarEnsayo(ens.ID);

      }
      catch (Exception ex)
      {
        logger.Error("btnEliminarRegistro_Click()", ex);
  
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones=null;
        
      }
    }

    private void searchEnsayo() 
    {

      if (ListaEnsayos == null)
        return; 
      
      try
      {
        string txt = txtBusqueda.Text.ToLower();
        txt.Trim();

        ltvEnsayos.Items.Clear();
        if (txt == string.Empty)
        {
          LlenarEnsayos();
          return;
        }
        else
        {
          for (int i = 0; i < ListaEnsayos.Count; i++)
          {
            System.Windows.Controls.ListViewItem o = new System.Windows.Controls.ListViewItem();
            Ensayos ensayo = ListaEnsayos[i];

            //bool bMatchUserInput = ensayo.Codigo.ToLower().IndexOf(txt) >= 0;
            //bMatchUserInput = bMatchUserInput|| ensayo.Marca.ToLower().IndexOf(txt) >= 0;
            //bMatchUserInput = bMatchUserInput|| ensayo.Modelo.ToLower().IndexOf(txt) >= 0;
            //bMatchUserInput = bMatchUserInput|| ensayo.Usuario.ToLower().IndexOf(txt) >= 0;
            //bMatchUserInput = bMatchUserInput|| ensayo.DCF.ToLower().IndexOf(txt) >= 0;
            //bMatchUserInput = bMatchUserInput|| ensayo.Serie.ToLower().IndexOf(txt) >= 0;
            bool bMatchUserInput = (ensayo.Codigo.ToLower().IndexOf(txt) >= 0
              || ensayo.Marca.ToLower().IndexOf(txt) >= 0
              || ensayo.Modelo.ToLower().IndexOf(txt) >= 0
              || ensayo.Usuario.ToLower().IndexOf(txt) >= 0
              || ensayo.DCF.ToLower().IndexOf(txt) >= 0
              || ensayo.Serie.ToLower().IndexOf(txt) >= 0);
            if (!String.IsNullOrEmpty(ensayo.OrdenFabricacion)) 
                bMatchUserInput = bMatchUserInput || ensayo.OrdenFabricacion.ToLower().IndexOf(txt) >= 0;
            //bool bMatchUserInput = (ensayo.Codigo.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.Marca.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.Modelo.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.Usuario.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.DCF.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.Serie.ToLower().IndexOf(txt) >= 0
                    //|| ensayo.OrdenFabricacion.ToLower().IndexOf(txt) >= 0);

            if (!bMatchUserInput)
              continue;

            o.Content = ensayo;
            ltvEnsayos.Items.Add(o);
          }
          autosizeColumns();
        }

      }
      catch (Exception ex)
      {
          logger.ErrorFormat("txtBusqueda_TextChanged(object sender , RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
        , ex.Message
          , ex.StackTrace
        , ex.InnerException != null ? ex.InnerException.Message : "");
          excepcion formexepciones = new excepcion(ex);
          formexepciones.ShowDialog();
      }
      ltvEnsayos.InvalidateVisual();
    }

    private void autosizeColumns()
    {
      GridView view = this.ltvEnsayos.View as GridView;
      double width = 0;
      for (int i = 0; i < view.Columns.Count - 1; i++)
      {
        GridViewColumn col = view.Columns[i];
        width += col.ActualWidth;

        //ResizeGridViewColumn(col);
      }
      view.Columns[view.Columns.Count - 1].Width = ltvEnsayos.ActualWidth - width; ;

    }

    private List<Ensayos> ListaEnsayos = null;
    private void btnConsultar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        ltvEnsayos.Items.Clear();
        if (dpkDesde.Value == null || dpkHasta.Value == null)
          return;

        ShowLoadingUIComponent();

        DateTime desde = (DateTime)dpkDesde.Value;
        DateTime hasta = (DateTime)dpkHasta.Value;

        desde = new DateTime(desde.Year, desde.Month, desde.Day, 0, 0, 0);
        hasta = new DateTime(hasta.Year, hasta.Month, hasta.Day, 1, 0, 0);
        hasta = hasta.AddHours(24);

        lblTitleEnsayos.Content = "Ensayos";
        ListaEnsayos = ManejadorEnsayos.ObtenerEnsayosPorFecha(desde, hasta);

        LlenarEnsayos(false);

      }
      catch (Exception ex)
      {
        logger.Error("btnConsultar_Click()", ex);
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones=null;
      }

      HideLoadingUIComponent();
      if (ltvEnsayos.Items.Count <= 0)
      {
        excepcion oMsg = new excepcion("Listado de ensayos", String.Format("Especifique otro rango de fechas.{0}No hay ensayos que mostrar en el rango indicado.", System.Environment.NewLine));
        oMsg.ShowDialog();
        oMsg = null;
      }
    }
    

    private void btnVerAprobados_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        ShowLoadingUIComponent();
        ltvEnsayos.Items.Clear();

        lblTitleEnsayos.Content = "Ensayos aprobados del dia actual";

        List<Ensayos> EnsayosAprobados = ManejadorEnsayos.ObtenerEnsayosAprobados(DateTime.Now);

        foreach (Ensayos ensayo in EnsayosAprobados)
        {
          ltvEnsayos.Items.Add(ensayo);
        }
      }
      catch (Exception ex)
      {
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones=null;
        logger.Error("btnVerAprobados_Click()", ex);
      }

      HideLoadingUIComponent();
      if (ltvEnsayos.Items.Count <= 0)
      {
        excepcion oMsg = new excepcion("Listado de ensayos", "No hay ensayos aprobados que mostrar .");
        oMsg.ShowDialog();
        oMsg = null;
      }
    }

    private void btnVerFallas_Click(object sender, RoutedEventArgs e)
    {

      try
      {

        ShowLoadingUIComponent();

        ltvEnsayos.Items.Clear();

        lblTitleEnsayos.Content = "Ensayos no aprobados del hoy";

        List<Ensayos> EnsayosFallados = ManejadorEnsayos.ObtenerEnsayosFallados(DateTime.Now);

        foreach (Ensayos ensayo in EnsayosFallados)
        {
          ltvEnsayos.Items.Add(ensayo);
        }

      }
      catch (Exception ex)
      {
        logger.Error("btnVerFallas_Click()", ex);
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones = null;
          
      }

      HideLoadingUIComponent();
      if (ltvEnsayos.Items.Count <= 0)
      {
        excepcion oMsg = new excepcion("Listado de ensayos", "No hay ensayos 'NO APROBADOS' que mostrar.");
        oMsg.ShowDialog();
        oMsg = null;
      }
        
    }

    private void btnVer_Click(object sender, RoutedEventArgs e)
    {
      try
      {
          if (ltvEnsayos.SelectedIndex < 0)
              return;


          Ensayos oEnsayo = (Ensayos) ltvEnsayos.SelectedItem;

          detallesensayoodu formulariodetallesidu = new detallesensayoodu(oEnsayo);
          formulariodetallesidu.ShowDialog();

      }
      catch (Exception ex)
      {
         logger.Error("btnVer_Click()", ex);

         excepcion formularioexcepciones = new excepcion(ex);
         formularioexcepciones.ShowDialog();
      }
        
    }

    private void btnReimprimirCaja_Click(object sender, RoutedEventArgs e)
    {
      mostrarVistaPrevia(false);
      return;
    }

    private void btnReimprimirProducto_Click(object sender, RoutedEventArgs e)
    {
      mostrarVistaPrevia(true);
      return;
    }

    private void mostrarVistaPrevia(bool esProducto)
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
        if (ltvEnsayos.SelectedIndex<0)
            return;

        ModelosManager ManejadorModelos = new ModelosManager();
        CaracteristicasTecnicasManager ManejadorCaract_tecnicas = new CaracteristicasTecnicasManager();
        Ensayos ensayoseleccionado = ltvEnsayos.SelectedItem as Ensayos;

        Modelo mModelo = ManejadorModelos.ObtenerModeloPorNombre(ensayoseleccionado.Modelo);
        
        //vistaprevia formvistaprevia = new vistaprevia(netiqueta, nmodelo, ncaract,ensayoseleccionado , true);
        vistaprevia formvistaprevia = new vistaprevia(mModelo, ensayoseleccionado, esProducto);
        formvistaprevia.ShowDialog();
      }
      catch (Exception ex)
      {
        logger.Error("btnReimprimirProducto_Click()", ex);
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones=null;
      }
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      try
      {

          System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start("osk");
      }
      catch (Exception ex)
      {
          logger.Error(" btnTeclado_Click()", ex);
          excepcion formularioexcepciones = new excepcion(ex);
          formularioexcepciones.ShowDialog();
          formularioexcepciones=null;
      }
    }

    private void ltvEnsayos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (ltvEnsayos.SelectedIndex >= 0)
      {
        btnReimprimirCaja.IsEnabled = true;
        btnReimprimirProducto.IsEnabled = true;
      }
      else {
        btnReimprimirCaja.IsEnabled = false;
        btnReimprimirProducto.IsEnabled = false;
      }
    }

    private void txtBusqueda_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
      searchEnsayo();
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      searchEnsayoLikeSerie();
    }

    private void searchEnsayoLikeSerie(){
      if(txtBusqueda.Text.Trim().Length<5){
        excepcion oMsg = new excepcion("Listado de ensayos", String.Format("Para limitar el tráfico con la BBDD,{0}le pedimos que ingrese al menos 5 caracteres del nro . de serie.", System.Environment.NewLine));
        oMsg.ShowDialog();
        oMsg = null;
        return;
      }
      try
      {
        ltvEnsayos.Items.Clear();
        
        ShowLoadingUIComponent();

        lblTitleEnsayos.Content = "Ensayos";
        ListaEnsayos = ManejadorEnsayos.ObtenerEnsayosPorSerie(this.txtBusqueda.Text);

        LlenarEnsayos(false);

      }
      catch (Exception ex)
      {
        logger.Error("btnConsultar_Click()", ex);
        excepcion formularioexepciones = new excepcion(ex);
        formularioexepciones.ShowDialog();
        formularioexepciones = null;
      }

      HideLoadingUIComponent();
      if (ltvEnsayos.Items.Count <= 0)
      {
        excepcion oMsg = new excepcion("Listado de ensayos", String.Format("No hay ensayos que mostrar con le número de serie indicado.", System.Environment.NewLine));
        oMsg.ShowDialog();
        oMsg = null;
      }
    }

    private void imgRefresh_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      searchEnsayoLikeSerie();
    }
	}
}








