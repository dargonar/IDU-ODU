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
using iDU.PLC;
using System.Threading;

using WPFiDU.Utils;

namespace dcf001
{
  public delegate void OnModeloSelectionChanged(object sender, Modelo selectedModelo);
	public partial class modeloafabricar
	{

    private static readonly ILog logger = LogManager.GetLogger(typeof(modeloafabricar));
    public event OnModeloSelectionChanged OnModeloSelectionChanged = null;

    private Modelo mModelo=null;
    private List<Modelo> listamodelos;
    private int mSelectedModeloId = -1;
    public Modelo Modelo
    {
        get { return mModelo; }
        set { mModelo = value; }

    }

		public modeloafabricar()
		{
       this.InitializeComponent();
       listamodelos = new List<Modelo>();                     
       LlenarListView();
       lblCambiando.Visibility = Visibility.Hidden;              						
		}

    public modeloafabricar(int argModeloId)
    {
      this.InitializeComponent();
      listamodelos = new List<Modelo>();
      LlenarListView();
      lblCambiando.Visibility = Visibility.Hidden;
      
      mSelectedModeloId = argModeloId;
      
      
    }

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
      GridView view = this.ltvModelos.View as GridView;
      double width=0;
      for (int i=0; i<view.Columns.Count-1; i++)
      {
        GridViewColumn col =view.Columns[i];
        width += col.ActualWidth;
        
        //ResizeGridViewColumn(col);
      }
      view.Columns[view.Columns.Count - 1].Width = ltvModelos.ActualWidth - width; ;

    }
    
    private void LlenarListView()
    {
        try
        {

            if (listamodelos == null || listamodelos.Count < 1)
            {
                ModelosManager modmag = new ModelosManager();
                listamodelos = modmag.ObtenerModelos();
            }

            for (int i = 0; i < listamodelos.Count; i++)
            {
                ListViewItem o = new ListViewItem();
                o.Content = listamodelos[i];
                o.ToolTip = listamodelos[i].ID.ToString();
                ltvModelos.Items.Add(o);
            }
            autosizeColumns();
        }
        catch (Exception ex)
        {
            logger.ErrorFormat("LlenarListView():: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
          , ex.Message
           , ex.StackTrace
         , ex.InnerException != null ? ex.InnerException.Message : "");
            excepcion formexepciones = new excepcion(ex);
            formexepciones.ShowDialog();

        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        mModelo = null;
        this.Close();
    }

    private void btnCancelar_Click(object sender, RoutedEventArgs e)
    {
        //mModelo = null;
        this.Close();
    }

    private void HideLoadingUIComponent()
    {
        lblCambiando.Visibility = Visibility.Hidden;
        this.InvalidateVisual();
        this.InvalidateArrange();
        this.UpdateLayout();
    }

    private void ShowLoadingUIComponent()
    {
        lblCambiando.Visibility = Visibility.Visible;
       
        this.InvalidateVisual();
        this.InvalidateArrange();
        this.UpdateLayout();

    }

    private void setModeloToPLC() 
    {
        //this.lblCambiando.InvalidateVisual();
        //this.InvalidateVisual();
        //System.Threading.Thread.Sleep(500);
        ShowLoadingUIComponent();

        btnSeleccionar.Cursor = System.Windows.Input.Cursors.Wait;
        btnClose.IsEnabled = false;
        btnSeleccionar.IsEnabled = false;
        btnTeclado.IsEnabled = false;

        try
        {
            System.Windows.Forms.Application.DoEvents();

            Thread oThread = new Thread(new ThreadStart(this.CargarParametrosEnsayo));
            oThread.Start();

            while (oThread.IsAlive)
                System.Windows.Forms.Application.DoEvents();
            oThread = null;

        }
        catch (Exception ex)
        {

            logger.ErrorFormat("btnSeleccionar_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
            , ex.Message
           , ex.StackTrace
           , ex.InnerException != null ? ex.InnerException.Message : "");

            excepcion formexepciones = new excepcion(ex);
            formexepciones.ShowDialog();

            return;
        }

        finally
        {
            btnSeleccionar.Cursor = System.Windows.Input.Cursors.Arrow;

            if (this.OnModeloSelectionChanged != null)
                OnModeloSelectionChanged(this, mModelo);
            this.Close();

        }

        if (CargarParametrosEnsayoFalla != 0)
        {
            logger.ErrorFormat("ModeloAFabricar.xaml::btnSeleccionar_Click(object sender, RoutedEventArgs e):: algun tag no se pudo escribir ");


            confirmacioneliminar.Show("Se produjo un error al escribir al PLC");
        }

        HideLoadingUIComponent();
    }

    private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
    {
        if (ltvModelos.SelectedIndex < 0)
            return;

        ListViewItem o = ltvModelos.SelectedItem as ListViewItem;
        mModelo = new Modelo();
        mModelo = o.Content as Modelo;

        setModeloToPLC();

    }

    public static int CargarParametrosEnsayoFalla = 0;
    private void CargarParametrosEnsayo()
    {

        //TODO: reformular el mertodo de chequeo de conn;
        //bool b = checkConn();
        //if (!b)
        //    throw new Exception("no hay conn al plc!!!");
        CargarParametrosEnsayoFalla = 0;
        try
        {

            ModelosManager manag_modelos = new ModelosManager();
            ParametrosManager manag_parametros = new ParametrosManager();
            CaracteristicasTecnicasManager c = new CaracteristicasTecnicasManager();

            CaracteristicasTecnicas ct = c.ObtenerCaracteristicaTecnicaDeModelo(mModelo);

            ParametrosEnsayo parametros = manag_parametros.LeerParametrosDeBaseDeDatosPorId(ct.IdParametros);
            
            CargarParametrosEnsayoFalla = manag_parametros.EscribirParametrosEnPLC(parametros, true);
            //OPCWrapper oOPCWrapper = new OPCWrapper();
            //oOPCWrapper.Write(parametros);
            //oOPCWrapper = null;
            PLCIDU accesoplc = new PLCIDU();

            if (mModelo.EsIdu == true)
            {
                //if (homeIDU.modoensayo != 1 && homeIDU.modoensayo>-1)
                accesoplc.Escribir("IDU_SP_VModelo", mModelo.ID);
                LastTestedModelManager.setLastTestedModelId(mModelo.ID);
                logger.InfoFormat("CargarParametrosEnsayo(). Modelo cargado: Id=[{0}] Descripción=[{1} - {2}]"
                    , mModelo.ID, mModelo.Marca, mModelo.Referencia);
                //if (homeIDU.modoensayo != 0 && homeIDU.modoensayo > -1) 
                    //accesoplc.Escribir("IDU_SP_VModelo_2", 1);
            }
            
            manag_parametros.Dispose();

            
        }
        catch (Exception ex)
        {
            logger.ErrorFormat("CargarParametrosEnsayo(Modelo m):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
            , ex.Message
            , ex.StackTrace
            , ex.InnerException != null ? ex.InnerException.Message : "");

            excepcion formexcepciones = new excepcion(ex);
            formexcepciones.ShowDialog();
        }
    }

     
    private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
    {

       

    }

    private void searchModelo() 
    {
        try
        {

            string txt = txtBusqueda.Text.ToLower();
            txt.Trim();

            ltvModelos.Items.Clear();

            
            if (txt == string.Empty)
            {
                ltvModelos.Items.Clear();

                LlenarListView();
                return;
            }
            else
            {

                for (int i = 0; i < listamodelos.Count; i++)
                {

                    ListViewItem o = new ListViewItem();
                    Modelo modelo = listamodelos[i];
                    if (!(modelo.Marca.ToLower().IndexOf(txt) >= 0
                        || modelo.Descripcion.ToLower().IndexOf(txt) >= 0
                        || modelo.Nombremodelo.ToLower().IndexOf(txt) >= 0
                        || modelo.Codigo.ToLower().IndexOf(txt) >= 0
                        || modelo.Referencia.ToLower().IndexOf(txt) >= 0))
                        continue;

                    o.Content = modelo;
                    ltvModelos.Items.Add(o);
                }
                autosizeColumns();
                //for (int i = 0; i < ltvModelos.Items.Count; i++)
                //{
                //    ListViewItem item = (ListViewItem)ltvModelos.Items[i];
                //    Modelo modelo = (Modelo)item.Content;

                //    if (!(modelo.Marca.ToLower().IndexOf(txt) >= 0 
                //        || modelo.Descripcion.ToLower().IndexOf(txt) >= 0 
                //        || modelo.Nombremodelo.ToLower().IndexOf(txt) >= 0 
                //        || modelo.Codigo.ToLower().IndexOf(txt) >= 0 
                //        || modelo.Referencia.ToLower().IndexOf(txt) >= 0))
                //        ltvModelos.Items.Remove(item);

                //}

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
        ltvModelos.InvalidateVisual();
    }

    private void txtBusqueda_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
    }

    private void txtBusqueda_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        searchModelo();
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

    private void Window_ContentRendered(object sender, EventArgs e)
    {
      if(mSelectedModeloId<0)
      return;
      ModelosManager manag_modelos = new ModelosManager();
      this.mModelo = manag_modelos.ObtenerModeloPorId(mSelectedModeloId);
      manag_modelos.Dispose();
      manag_modelos = null;
      setModeloToPLC();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      autosizeColumns();
    }

    
  }
}