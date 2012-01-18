using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using log4net;
namespace DCFStarter
{
  public partial class frmStarter : Form
  {
    public frmStarter()
    {
      InitializeComponent();
      log4net.Config.XmlConfigurator.Configure();
    }

    private void frmStarter_Load(object sender, EventArgs e)
    {
      Starter oStarter = new Starter();
      oStarter.start();
      oStarter = null;
      this.Close();
    }

    
  }
}
