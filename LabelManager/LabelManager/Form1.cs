using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iDU.CommonObjects;
using System.Configuration;

namespace LabelManager
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.loadCombos();
    }


    private void loadCombos()
    {
      DAO mDAO = new DAO();
      List<Modelo> dtModelos = mDAO.ObtenerModelos(true);
      List<Modelo> dtModelos2 = mDAO.ObtenerModelos(false);
      
      foreach(Control oCtrl in this.groupBox1.Controls)
      {
        if(!oCtrl.GetType().Equals(typeof(ComboBox)))
          continue;
        ComboBox cmb = oCtrl as ComboBox;
        cmb.Items.Clear();
        cmb.Items.AddRange(dtModelos.ToArray());
        cmb.Items.AddRange(dtModelos2.ToArray()); 
      }

      this.cmbModeloFilter.Items.Clear();
      this.cmbModeloFilter.Items.AddRange(dtModelos.ToArray());
      this.cmbModeloFilter.Items.AddRange(dtModelos2.ToArray()); 
      //this.cmbModelosFamilia.Items.Clear();
      //this.cmbModelosFamilia.Items.AddRange(new string[] { "TEMPSTAR", "COMFORTMAKER", "ICP", "SPRINGER", "CARRIER" });
    
      //cmb.ItemsDataSource = dtModelos;
      //cmb.DisplayMember = "modelos_codigo";
      //cmb.ValueMember = "modelos_id";
      //cmb.SelectedIndex = 0;
      
      this.cmbImprimirDesde.Items.Clear();
      string impresora_bulto_idu = ConfigurationManager.AppSettings["ImpresoraBultoIDU"];
      string impresora_bulto_odu = ConfigurationManager.AppSettings["ImpresoraBultoODU"];
      this.cmbImprimirDesde.Items.AddRange(new string[] { impresora_bulto_idu, impresora_bulto_odu });
      this.cmbImprimirDesde.SelectedIndex = 0;
    }

    private void btnSelectEnsayos_Click(object sender, EventArgs e)
    {
      DAO mDAO = new DAO();
      
      DataTable data = mDAO.getEnsayos(this.dtDesde.Value, this.dtHasta.Value, this.chkEsIdu.Checked
                  , getModelo(this.cmbModeloFilter));
      dtgEnsayos.DataSource = data;
      try
      {
        lblCantidad.Text = string.Format("Cantidad: {0}", data.Rows.Count);
      }
      catch
      {
        lblCantidad.Text = string.Format("Cantidad: 0 - [ERROR]");
      }
    }

    private string getModelo(ComboBox cmb)
    {
      try{
      return ((Modelo)(cmb.SelectedItem)).Nombremodelo;}
      catch{return "";}
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      if(dtgEnsayos.SelectedRows.Count<1 )
        return;
      
      DAO mDao = new DAO();
      foreach(DataGridViewRow oRow in dtgEnsayos.SelectedRows)
      {
        Modelo mModelo = null;
        Ensayos mEnsayo = null;
        mModelo = mDao.getModeloFromRow(oRow);
        
        
        if(chkEsIdu.Checked)
        {  
          mEnsayo = mDao.getEnsayoIduFromRow(oRow);
          this.ImpresionEtiquetasIDU(mEnsayo, mModelo);
        }
        else
        {  
          mEnsayo = mDao.getEnsayoOduFromRow(oRow);
          this.ImpresionEtiquetasODU(mEnsayo, mModelo);
        }
        
      }
    }
    
    #region Impresion
    private void ImpresionEtiquetasIDU(Ensayos infoens, Modelo modeloinfo )
    {
      if (modeloinfo == null)
        return;
      
      WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerEx =
      new WPFiDU.Etiquetas.EtiquetasManagerEx(true);

      if (this.chkPrintProducto.Checked)
      {
        //Impresion Producto
        Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
          , modeloinfo.BackgroundProducto
          , infoens);

        //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        //System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        string nombreimpresora = ConfigurationManager.AppSettings["ImpresoraProducto"]; 
        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExProd =
          new WPFiDU.Etiquetas.EtiquetasManagerEx(true);
        oEtiquetasManagerExProd.ImprimirImagen(ImagenTemp, nombreimpresora, false);
      } 
      
      if (this.chkPrintBulto.Checked)
      {
        //Impresion Bulto
        Bitmap ImagenTemp2 = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
          , modeloinfo.BackgroundBulto
          , infoens);

        //Bitmap escalada = EtiquetaManager.Escalar(ImagenTemp);
        //System.Drawing.Image imagenaimprimir = escalada;//imgEtiqueta as System.Drawing.Image;

        string nombreimpresora = this.cmbImprimirDesde.Text;//ConfigurationManager.AppSettings["ImpresoraBulto"]; 

        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExBulto =
          new WPFiDU.Etiquetas.EtiquetasManagerEx(true);
        oEtiquetasManagerExBulto.ImprimirImagen(ImagenTemp2, nombreimpresora, true);
       }

    }

    private void ImpresionEtiquetasODU(Ensayos infoens, Modelo modeloinfo )
    {

      if (modeloinfo == null)
        return;
      
      WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerEx = new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
       
      if (this.chkPrintProducto.Checked)
      {//PRODUCTO
        Bitmap ImagenTemp = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
            , modeloinfo.BackgroundProducto
            , infoens);

        string nombreimpresora = ConfigurationManager.AppSettings["ImpresoraProducto"];
        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExProd =
          new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
        oEtiquetasManagerExProd.ImprimirImagen(ImagenTemp, nombreimpresora, false);
      }
      
      //bulto
      if (this.chkPrintBulto.Checked)
      {
        Bitmap ImagenTemp2 = oEtiquetasManagerEx.GenerarBitmapDeEtiqueta(modeloinfo
            , modeloinfo.BackgroundBulto
            , infoens);

        
        string nombreimpresora = this.cmbImprimirDesde.Text;//ConfigurationManager.AppSettings["ImpresoraBulto"]; 

        WPFiDU.Etiquetas.EtiquetasManagerEx oEtiquetasManagerExBulto =
          new WPFiDU.Etiquetas.EtiquetasManagerEx(false);
        oEtiquetasManagerExBulto.ImprimirImagen(ImagenTemp2, nombreimpresora, true);
      }
    }
    #endregion Impresion

    private void btnconvertModelos_Click(object sender, EventArgs e)
    {
      string text = string.Format("Está seguro de convertir los ensayos entre las fechas '{0}' y '{1}'",
        this.dtDesde.Value.ToString(), 
        this.dtHasta.Value.ToString()) ;
      if(MessageBox.Show(this,text,"Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
        
        processCombos(this.cmbModelosFrom1,this.cmbModelosTo1);
        processCombos(this.cmbModelosFrom2, this.cmbModelosTo2);
        processCombos(this.cmbModelosFrom3, this.cmbModelosTo3);
        processCombos(this.cmbModelosFrom4, this.cmbModelosTo4);
    }

    private void processCombos(ComboBox cmbFrom,ComboBox cmbTo)
    {
      if (string.IsNullOrEmpty(cmbFrom.Text) || string.IsNullOrEmpty(cmbTo.Text))
        return;
      
      DAO mDao = new DAO();
      mDao.updateEnsayos(this.dtDesde.Value
        , this.dtHasta.Value
        , this.chkEsIdu.Checked
        , getModelo(cmbFrom) 
        ,  getModelo(cmbTo));
       
    }

    private void chkEsIdu_CheckedChanged(object sender, EventArgs e)
    {
      
    }
  }
}
