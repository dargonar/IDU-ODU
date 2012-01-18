using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iDU.BL;
using iDU.DAO;
using WPFiDU.BL;
using iDU.PLC;


namespace WPFiDU.Utils
{
  class DBImporter
  {
    #region LOAD DATABASE
    private const string CARRIER_BKP_PREFIX = " - v C1";
    private void loadDDBBEtiquetas()
    {
      iDU.DAO.IDUDb oIDUDb = new IDUDb();
      iDU.DAO.ODUDb oODUDb = new ODUDb();
      // clean actual data base.
      BaseDAO.cleanEtiquetas();

      // idu
      BaseDAO.setOldDB("carrieridu");
      oIDUDb.CargarEtiquetasEnBaseDeDatosNueva("");
      BaseDAO.setOldDB("carrieridu_office");
      oIDUDb.CargarEtiquetasEnBaseDeDatosNueva(CARRIER_BKP_PREFIX);

      //odu
      BaseDAO.setOldDB("carrierodu");
      oODUDb.CargarEtiquetasEnBaseDeDatosNueva("");
      BaseDAO.setOldDB("carrierodu_office");
      oODUDb.CargarEtiquetasEnBaseDeDatosNueva(CARRIER_BKP_PREFIX);
    }

    private void loadDDBBReferencias() // caract tecnicas equipos
    {

      iDU.DAO.IDUDb oIDUDb = new IDUDb();
      iDU.DAO.ODUDb oODUDb = new ODUDb();
      // clean actual data base.
      BaseDAO.cleanCaracteristicasTecnicasEquipos();

      // idu
      BaseDAO.setOldDB("carrieridu");
      oIDUDb.CargarReferenciasEnDBNueva("");
      BaseDAO.setOldDB("carrieridu_office");
      oIDUDb.CargarReferenciasEnDBNueva(CARRIER_BKP_PREFIX);

      //odu
      BaseDAO.setOldDB("carrierodu");
      oODUDb.CargarReferenciasEnDBNueva("");
      BaseDAO.setOldDB("carrierodu_office");
      oODUDb.CargarReferenciasEnDBNueva(CARRIER_BKP_PREFIX);
    }

    private void loadDDBBParametros()
    {
      iDU.DAO.IDUDb oIDUDb = new IDUDb();
      iDU.DAO.ODUDb oODUDb = new ODUDb();
      //Parametros
      // clean actual data base.
      BaseDAO.cleanParametros();

      // idu
      BaseDAO.setOldDB("carrieridu");
      oIDUDb.CargarParametrosEnDBNueva("");
      BaseDAO.setOldDB("carrieridu_office");
      oIDUDb.CargarParametrosEnDBNueva(CARRIER_BKP_PREFIX);

      //odu
      BaseDAO.setOldDB("carrierodu");
      oODUDb.CargarParametrosEnDBNueva("");
      BaseDAO.setOldDB("carrierodu_office");
      oODUDb.CargarParametrosEnDBNueva(CARRIER_BKP_PREFIX);
    }

    private void loadDDBBModelos()
    {
      iDU.DAO.IDUDb oIDUDb = new IDUDb();
      iDU.DAO.ODUDb oODUDb = new ODUDb();
      //Parametros
      // clean actual data base.
      BaseDAO.cleanModelos();

      // idu
      BaseDAO.setOldDB("carrieridu");
      oIDUDb.CargarModelosEnDBNueva("");
      BaseDAO.setOldDB("carrieridu_office");
      oIDUDb.CargarModelosEnDBNueva(CARRIER_BKP_PREFIX);

      //odu
      BaseDAO.setOldDB("carrierodu");
      oODUDb.CargarModelosEnDBNueva("");
      BaseDAO.setOldDB("carrierodu_office");
      oODUDb.CargarModelosEnDBNueva(CARRIER_BKP_PREFIX);
    }

    /*
      try
      {
        this.importarDatos();
      }
      catch (Exception ex) 
      {
        MessageBox.Show( ex.Message);
      }
      return;*/

    private static void importarDatos()
    {

      DBImporter oDBImporter = new DBImporter();
      //ETIQUETAS
      oDBImporter.loadDDBBEtiquetas();


      // Parametros
      oDBImporter.loadDDBBParametros();


      // Referencias
      oDBImporter.loadDDBBReferencias();

      // Modelos
      oDBImporter.loadDDBBModelos();

    }
    #endregion LOAD DATABASE
  }
}
