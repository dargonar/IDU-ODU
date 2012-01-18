using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;


namespace ImagePosition
{
  public partial class frmMain : Form
  {
    public frmMain()
    {
      InitializeComponent();
      
      this.comboBox1.Items.Clear();
      for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
      {
        string pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
        comboBox1.Items.Add(pkInstalledPrinters);
      }
    }

    private void btnSelectFile_Click(object sender, EventArgs e)
    {
      DialogResult o = this.openFileDialog1.ShowDialog(this);
      if(o!=DialogResult.OK)
      {
        MessageBox.Show(this,"Seleccione un archivo.");
        return;
      }
      
      
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      string file = this.openFileDialog1.FileName;
      //MessageBox.Show(this, file);

      WPFiDU.Etiquetas.EtiquetasManagerEx oMngr = new WPFiDU.Etiquetas.EtiquetasManagerEx();
      oMngr.TOP_BULTO = Convert.ToInt32(this.nudTOP.Value);
      oMngr.LEFT_BULTO = Convert.ToInt32(this.nudLEFT.Value);
      oMngr.ImprimirImagen(file, comboBox1.Text, true);
    }
  }
}
