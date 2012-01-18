using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DCFStarter
{
  static class Program
  {
    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);


      if (args.Length == 0)
        Application.Run(new frmDBRestorer());
      else
        Application.Run(new frmStarter());
      //Application.Run(new frmStarter());
        
    }
  }
}
