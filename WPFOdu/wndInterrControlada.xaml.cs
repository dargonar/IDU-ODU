using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using log4net;
using iDU.PLC;
using System.Configuration;
using System.Collections.Generic;
using iDU.CommonObjects;
namespace dcf001
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class wndInterrupcionControlada: Window
  {

    iDU.DAO.BaseDAO oDAO = null;
    
    private static List<Dictionary<string, string>> listInterrupciones = null ;
    private string SerialNumber = "";

    public wndInterrupcionControlada(string argSerialNumber)
    {
      InitializeComponent();
      this.SerialNumber = argSerialNumber;
      oDAO = new iDU.DAO.ODUDb();
      loadInterrupciones();
    }

    private void loadInterrupciones() {
      listInterrupciones = null;
      this.cmbInterrupciones.Items.Clear();

      if (wndInterrupcionControlada.listInterrupciones == null)
        wndInterrupcionControlada.listInterrupciones = this.oDAO.ListFallasControladas();
      
      if (listInterrupciones != null && listInterrupciones.Count > 0)
      {
        for (int i = 0; i < listInterrupciones.Count; i++)
        {

          cmbInterrupciones.Items.Add(new VersionEquipo(Convert.ToInt32(wndInterrupcionControlada.listInterrupciones[i]["id"]),
                                                      wndInterrupcionControlada.listInterrupciones[i]["descripcion"])
                                                      );
        }
      }
    }

    private void btnRefresh_Click(object sender, RoutedEventArgs e)
    {
      loadInterrupciones();
    }

    private void imgRefresh_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      loadInterrupciones();
    }

    private void btnGuardar_Click(object sender, RoutedEventArgs e)
    {
      if (String.IsNullOrEmpty(this.SerialNumber))
      {
        excepcion formularioexepciones = new excepcion("Interrupciones controladas", "Número de serie inválido.");
        formularioexepciones.ShowDialog();

        this.Close();
      }

      if (cmbInterrupciones.SelectedItem == null)
      {
        excepcion formularioexepciones = new excepcion("Interrupciones controladas", "Debe seleccionar una interrupción.");
        formularioexepciones.ShowDialog();
        return;
      }

      int interr_id = ((VersionEquipo)cmbInterrupciones.SelectedItem).ID;
      //bool ok = this.oDAO.GuardarInterrupcionControlada(this.SerialNumber,interr_id);
      bool ok = this.oDAO.GuardarInterrupcionControlada(this.SerialNumber, interr_id, Convert.ToInt32(WPFiDU.BL.ManagerUsuarios.sfUser.u__id), System.Environment.MachineName);

      if (!ok)
      {
        excepcion formularioexepciones = new excepcion("Interrupciones controladas", "No se pudo registrar la interrupción. Inténtelo nuevamente.");
        formularioexepciones.ShowDialog();
        return;
      }

      excepcion formularioexepcion = new excepcion("Interrupciones controladas", "Interrupción registrada satisfactoriamente.", true);
      formularioexepcion.ShowDialog();
      this.Close();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    

  }
}
