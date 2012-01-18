using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

using System.Data;
using System.Data.SqlClient;

using  iDU.CommonObjects;

using System.Configuration;
namespace LabelManager
{
  class DAO
  {
    #region Generic
    public DataTable getEnsayos(DateTime desde, DateTime hasta, bool EsIdu, string modelo)
    {
    
      string mTableName = "ensayosrealizadosidu";
      string mTable_FechaField = "ensayosrealizadosidu_fecha";
      string mTable_ModeloField = "ensayosrealizadosidu_modelo";
      string mTable_AprobadoField = "ensayosrealizadosidu_aprobado";
      if(!EsIdu)
      {
        mTableName = "ensayosrealizadosodu";
        mTable_FechaField = "ensayosrealizadosodu_fecha";
        mTable_ModeloField = "ensayosrealizadosodu_modelo";
        mTable_AprobadoField = "ensayosrealizadosodu_aprobado";
      
      }  
      MySqlConnection sqlCnn = this.ConectarBaseDeDatos();
      StringBuilder sqlString = new StringBuilder();

      sqlString.Append(" SELECT * ");
      sqlString.Append(" FROM " + mTableName);
      sqlString.Append("  INNER JOIN modelos");
      sqlString.Append("  ON " + mTableName + "." + mTable_ModeloField + "= modelos.modelos_modelo ");
      sqlString.Append("  WHERE "+mTable_FechaField+" >= '" + desde.ToString(DateFormat) + "'");
      sqlString.Append("  AND "+mTable_FechaField+" <= '" + hasta.ToString(DateFormat) + "'");
      sqlString.Append("  AND " + mTable_AprobadoField + " = 1 ");
      if(!string.IsNullOrEmpty( modelo))
        sqlString.Append("  AND " + mTableName + "." + mTable_ModeloField + "= '"+modelo+"'");
        
      try
      {
        //MySqlCommand command = new MySqlCommand(sqlString.ToString(), sqlCnn);
        //command.CommandTimeout = 6000;
         
        //MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlString.ToString(), sqlCnn);
        DataTable dtTable = new DataTable();
        sqlAdapter.Fill(dtTable);

        return dtTable;
      }
      catch (SystemException ex)
      {
        
        throw ex;
      }
      finally
      {
        sqlCnn.Close();
      }
    }

    public DataTable getModelos()
    {

      
      MySqlConnection sqlCnn = this.ConectarBaseDeDatos();
      StringBuilder sqlString = new StringBuilder();



      sqlString.Append(" SELECT * FROM modelos ");
      sqlString.Append(" WHERE es_activo = 1 ");
      
      try
      {
        MySqlCommand command = new MySqlCommand(sqlString.ToString(), sqlCnn);
        command.CommandTimeout = 6000;
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);
         
        DataTable dtTable = new DataTable();
        sqlAdapter.Fill(dtTable);

        return dtTable;
      }
      catch (SystemException ex)
      {

        throw ex;
      }
      finally
      {
        sqlCnn.Close();
      }
    }

    protected MySqlConnection ConectarBaseDeDatos()
    {
      //string connStr = "server=172.29.29.44;uid=root;pwd=248;database=idu_odu_min;pooling=false;";
      string connStr = ConfigurationManager.AppSettings["DDBBConnString"]; ;
      MySqlConnection conn = new MySqlConnection(connStr);
      conn.Open();
      return conn;
    }
    #endregion Generic
    
    #region IDU
    public List<Ensayos> ObtenerEnsayosIDUPorFecha(DateTime desde, DateTime hasta)
    {
      using (MySqlConnection conn = ConectarBaseDeDatos())
      {
        List<Ensayos> ensayosiduporfecha = new List<Ensayos>();

        string parametros = "('" + desde.ToString(DateFormat) + "','" + hasta.ToString(DateFormat) + "')";
        string sql = "CALL usp_ObtenerEnsayosIDUporFecha" + parametros;
        MySqlCommand cmd = new MySqlCommand(sql, conn);

        MySqlDataReader reader = cmd.ExecuteReader();


        while (reader.Read())
        {
          EnsayosIDU nuevoensayoidu = new EnsayosIDU();

          nuevoensayoidu.ID = reader.GetInt32("ensayosrealizadosidu_id");
          nuevoensayoidu.Marca = reader.GetString("ensayosrealizadosidu_marca");
          nuevoensayoidu.Observaciones = reader.GetString("ensayosrealizadosidu_observaciones");
          nuevoensayoidu.Serie = reader.GetString("ensayosrealizadosidu_serie");
          nuevoensayoidu.TiempoEnsayo = reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
          nuevoensayoidu.VelocidadBajaTension = reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
          nuevoensayoidu.VelocidadHigh = reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
          nuevoensayoidu.VelocidadInicial = reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
          nuevoensayoidu.VelocidadLow = reader.GetFloat("ensayosrealizadosidu_velocidadlow");
          nuevoensayoidu.Hipot = reader.GetString("ensayosrealizadosidu_hipot");
          nuevoensayoidu.Fuga = reader.GetString("ensayosrealizadosidu_fuga");
          nuevoensayoidu.Fecha = reader.GetDateTime("ensayosrealizadosidu_fecha");
          nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf");
          nuevoensayoidu.CorrienteLow = reader.GetFloat("ensayosrealizadosidu_corrientelow");
          nuevoensayoidu.CorrienteInicial = reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
          nuevoensayoidu.CorrienteCalorInicial = reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
          nuevoensayoidu.CorrienteBajaTension = reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
          nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo");
          nuevoensayoidu.Modelo = reader.GetString("ensayosrealizadosidu_modelo");
          nuevoensayoidu.CorrienteHIGH = reader.GetFloat("ensayosrealizadosidu_corrientehigh");
          nuevoensayoidu.Usuario = reader.GetString("ensayosrealizadosidu_usuario");
 
          if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
          {

            nuevoensayoidu.Aprobado = true;
          }
          else
          {
            nuevoensayoidu.Aprobado = false;
          }

          ensayosiduporfecha.Add(nuevoensayoidu);
        }

        reader.Close();
        return ensayosiduporfecha;


      }
    }
    #endregion
    
    #region ODU
    public List<Ensayos> ObtenerEnsayosODUPorFecha(DateTime desde, DateTime hasta)
    {

      using (MySqlConnection conn = ConectarBaseDeDatos())
      {
        List<Ensayos> listaensayosodu = new List<Ensayos>();


        string parametros = "('" + desde.ToString(this.DateFormat) + "','" + hasta.ToString(this.DateFormat) + "')";
        string sql = "CALL usp_ObtenerEnsayosODUPorFecha" + parametros;
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader reader = cmd.ExecuteReader();


        while (reader.Read())
        {
          EnsayosODU nuevoensayo = new EnsayosODU();


          if (reader.GetInt32("ensayosrealizadosodu_aprobado") == 1)
          {

            nuevoensayo.Aprobado = true;
          }
          else
          {
            nuevoensayo.Aprobado = false;
          }


          nuevoensayo.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
          nuevoensayo.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
          nuevoensayo.Corrienteh = reader.GetFloat("ensayosrealizadosodu_corrientealta");
          nuevoensayo.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
          nuevoensayo.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
          nuevoensayo.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
          nuevoensayo.Cosfc = reader.GetFloat("ensayosrealizadosodu_factordepotenciacalor");
          nuevoensayo.DCF = reader.GetString("ensayosrealizadosodu_dcf");
          nuevoensayo.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
          nuevoensayo.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
          nuevoensayo.Fuga = reader.GetString("ensayosrealizadosodu_fuga"); ;
          nuevoensayo.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
          nuevoensayo.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
          nuevoensayo.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
          nuevoensayo.ID = reader.GetInt32("ensayosrealizadosodu_id");
          nuevoensayo.Marca = reader.GetString("ensayosrealizadosodu_marca");
          nuevoensayo.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
          nuevoensayo.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
          nuevoensayo.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
          nuevoensayo.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
          nuevoensayo.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
          nuevoensayo.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
          nuevoensayo.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
          nuevoensayo.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
          nuevoensayo.Serie = reader.GetString("ensayosrealizadosodu_serie");
          nuevoensayo.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambiente");
          nuevoensayo.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
          nuevoensayo.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
          nuevoensayo.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
          nuevoensayo.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
          nuevoensayo.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
          nuevoensayo.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
          nuevoensayo.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
          nuevoensayo.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
          nuevoensayo.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
          nuevoensayo.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
          nuevoensayo.Modelo = reader.GetString("ensayosrealizadosodu_modelo");
          nuevoensayo.Usuario = reader.GetString("ensayosrealizadosodu_usuario");
          listaensayosodu.Add(nuevoensayo);
        }

        reader.Close();
        return listaensayosodu;
      }
    }
    #endregion
    
    #region Modelos
    public List<Modelo> ObtenerModelos(bool idu)
    {
      using (MySqlConnection conn = ConectarBaseDeDatos())
      {
        int esidu = 1;

        if (idu == false)
        {
          esidu = 0;
        }

        List<Modelo> nuevalista = new List<Modelo>();
        string sql = "CALL usp_ObtenerModelos(" + esidu.ToString() + ")";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.CommandTimeout = 600;
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
          Modelo nuevomodelo = new Modelo();
          nuevomodelo.ID = reader.GetInt32("modelos_id");
          nuevomodelo.Marca = reader.GetString("modelos_marca");
          nuevomodelo.Nombremodelo = reader.GetString("modelos_modelo");
          nuevomodelo.Referencia = reader.GetString("modelos_referencia");
          nuevomodelo.Ean13 = reader.GetString("modelos_ean13");
          nuevomodelo.Etiqueta = reader.GetInt32("modelos_etiqueta");
          nuevomodelo.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
          nuevomodelo.Logo = reader.GetString("modelos_logo");
          nuevomodelo.Conjunto = reader.GetString("modelos_conjunto");
          nuevomodelo.Capacidad = reader.GetString("modelos_capacidad");
          nuevomodelo.Codigo = reader.GetString("modelos_codigo");
          nuevomodelo.Descripcion = reader.GetString("modelos_descripcion");
          nuevomodelo.Dimension = reader.GetString("modelos_dimensiones");
          nuevomodelo.BackgroundBulto = reader.GetString("background_bulto");
          nuevomodelo.BackgroundProducto = reader.GetString("background_producto");


          if (reader.GetInt32("modelos_esidu") == 1)
          {
            nuevomodelo.EsIdu = true;
          }
          else
          {
            nuevomodelo.EsIdu = false;
          }


          nuevomodelo.CodigoICSA = reader.GetString("modelos_codigoicsa");
          nuevalista.Add(nuevomodelo);
        }

        reader.Close();
        return nuevalista;
      }

    }

    public Modelo ObtenerModeloPorNombre(string modelo, bool es_idu)
    {
      using (MySqlConnection conn = ConectarBaseDeDatos())
      {
        StringBuilder sqlString = new StringBuilder();

        sqlString.Append(" select modelos_id,modelos_marca,modelos_modelo, ");
        sqlString.Append(" modelos_codigo,modelos_referencia, modelos_ean13, modelos_etiqueta, modelos_etiquetacaja, modelos_logo, ");
        sqlString.Append(" modelos_conjunto, modelos_capacidad, modelos_codigoicsa, modelos_descripcion, modelos_dimensiones, ");
        sqlString.Append(" modelos_esidu from modelos");
        sqlString.Append(" where modelos_modelo = '" + modelo + "' ");
        sqlString.Append(" and es_activo = 1 ");
        sqlString.Append(" and modelos_esidu= " + (es_idu?"1":"0"));
        
        MySqlCommand cmd = new MySqlCommand(sqlString.ToString(), conn);
        MySqlDataReader reader = cmd.ExecuteReader();
        Modelo m = new Modelo();

        while (reader.Read())
        {

          m.Capacidad = reader.GetString("modelos_capacidad");
          m.Codigo = reader.GetString("modelos_codigo");
          m.CodigoICSA = reader.GetString("modelos_codigoicsa");
          m.Conjunto = reader.GetString("modelos_conjunto");
          m.Descripcion = reader.GetString("modelos_descripcion");
          m.Dimension = reader.GetString("modelos_dimensiones");
          m.Ean13 = reader.GetString("modelos_ean13");

          if (reader.GetInt32("modelos_esidu") == 1)
            m.EsIdu = true;
          else
            m.EsIdu = false;

          m.Etiqueta = reader.GetInt32("modelos_etiqueta");
          m.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
          m.ID = reader.GetInt32("modelos_id");
          m.Logo = reader.GetString("modelos_logo");
          m.Marca = reader.GetString("modelos_marca");
          m.Nombremodelo = reader.GetString("modelos_modelo");
          m.Referencia = reader.GetString("modelos_referencia");

        }

        reader.Close();
        return m;
      }
    }
    #endregion
   
    #region Grid Management
    public Ensayos getEnsayoOduFromRow(System.Windows.Forms.DataGridViewRow oRow )
    {
      EnsayosODU nuevoensayo = new EnsayosODU();
      if (Convert.ToInt32(oRow.Cells["ensayosrealizadosodu_aprobado"].Value) == 1)
      {
       nuevoensayo.Aprobado = true;
      }
      else
      {
        nuevoensayo.Aprobado = false;
      }

      nuevoensayo.Codigo = Convert.ToString(oRow.Cells["ensayosrealizadosodu_codigo"].Value);
      nuevoensayo.ID = Convert.ToInt32(oRow.Cells["ensayosrealizadosodu_id"].Value);
      nuevoensayo.Marca = Convert.ToString(oRow.Cells["ensayosrealizadosodu_marca"].Value);
      nuevoensayo.Serie = Convert.ToString(oRow.Cells["ensayosrealizadosodu_serie"].Value);
      nuevoensayo.Modelo = Convert.ToString(oRow.Cells["ensayosrealizadosodu_modelo"].Value);
      return nuevoensayo;
    }
    public Ensayos getEnsayoIduFromRow(System.Windows.Forms.DataGridViewRow oRow )
    {
      EnsayosIDU nuevoensayoidu = new EnsayosIDU();

      nuevoensayoidu.ID = Convert.ToInt32(oRow.Cells["ensayosrealizadosidu_id"].Value);
      nuevoensayoidu.Marca = Convert.ToString(oRow.Cells["ensayosrealizadosidu_marca"].Value);
      nuevoensayoidu.Serie = Convert.ToString(oRow.Cells["ensayosrealizadosidu_serie"].Value);
      nuevoensayoidu.TiempoEnsayo = Convert.ToInt32(oRow.Cells["ensayosrealizadosidu_tiempoensayo"].Value);
      nuevoensayoidu.VelocidadBajaTension = float.Parse(oRow.Cells["ensayosrealizadosidu_velocidadbajatension"].Value.ToString());
      nuevoensayoidu.Codigo = Convert.ToString(oRow.Cells["ensayosrealizadosidu_codigo"].Value);
      nuevoensayoidu.Modelo = Convert.ToString(oRow.Cells["ensayosrealizadosidu_modelo"].Value);

      if (Convert.ToInt32(oRow.Cells["ensayosrealizadosidu_aprobado"].Value) == 1)
      {

        nuevoensayoidu.Aprobado = true;
      }
      else
      {
        nuevoensayoidu.Aprobado = false;
      }

      return nuevoensayoidu ; 
    }
    
    public Modelo getModeloFromRow(System.Windows.Forms.DataGridViewRow oRow )
    {
      Modelo nuevomodelo = new Modelo();
      nuevomodelo.ID = Convert.ToInt32(oRow.Cells["modelos_id"].Value);
      nuevomodelo.Marca = Convert.ToString(oRow.Cells["modelos_marca"].Value);
      nuevomodelo.Nombremodelo = Convert.ToString(oRow.Cells["modelos_modelo"].Value);
      nuevomodelo.Referencia = Convert.ToString(oRow.Cells["modelos_referencia"].Value);
      nuevomodelo.Ean13 = Convert.ToString(oRow.Cells["modelos_ean13"].Value);
      nuevomodelo.Etiqueta = Convert.ToInt32(oRow.Cells["modelos_etiqueta"].Value);
      nuevomodelo.EtiquetaCaja = Convert.ToInt32(oRow.Cells["modelos_etiquetacaja"].Value);
      nuevomodelo.Logo = Convert.ToString(oRow.Cells["modelos_logo"].Value);
      nuevomodelo.Conjunto = Convert.ToString(oRow.Cells["modelos_conjunto"].Value);
      nuevomodelo.Capacidad = Convert.ToString(oRow.Cells["modelos_capacidad"].Value);
      nuevomodelo.Codigo = Convert.ToString(oRow.Cells["modelos_codigo"].Value);
      nuevomodelo.Descripcion = Convert.ToString(oRow.Cells["modelos_descripcion"].Value);
      nuevomodelo.Dimension = Convert.ToString(oRow.Cells["modelos_dimensiones"].Value);
      nuevomodelo.BackgroundBulto = Convert.ToString(oRow.Cells["background_bulto"].Value);
      nuevomodelo.BackgroundProducto = Convert.ToString(oRow.Cells["background_producto"].Value);
      if (Convert.ToInt32(oRow.Cells["modelos_esidu"].Value) == 1)
      {
        nuevomodelo.EsIdu = true;
      }
      else
      {
        nuevomodelo.EsIdu = false;
      }
      nuevomodelo.CodigoICSA = Convert.ToString(oRow.Cells["modelos_codigoicsa"].Value);
      return nuevomodelo;
    }
   
   
   #endregion
    
    #region Updater
   public void updateEnsayos(DateTime desde, DateTime hasta, bool EsIdu, string modeloFrom, string modeloTo)
    {
    
      string mTableName = "ensayosrealizadosidu";
      string mTable_FechaField = "ensayosrealizadosidu_fecha";
      string mTable_ModeloField = "ensayosrealizadosidu_modelo";
      string mTable_AprobadoField = "ensayosrealizadosidu_aprobado";
      if(!EsIdu)
      {
        mTableName = "ensayosrealizadosodu";
        mTable_FechaField = "ensayosrealizadosodu_fecha";
        mTable_ModeloField = "ensayosrealizadosodu_modelo";
        mTable_AprobadoField = "ensayosrealizadosodu_aprobado";
      
      }  
      MySqlConnection sqlCnn = this.ConectarBaseDeDatos();
      StringBuilder sqlString = new StringBuilder();

      sqlString.Append(" UPDATE " + mTableName);
      sqlString.Append("  SET " + mTable_ModeloField + " = '" + modeloTo + "'");
      sqlString.Append("  WHERE " + mTable_FechaField + " >= '" + desde.ToString(DateFormat) + "'");
      sqlString.Append("  AND " + mTable_FechaField + " <= '" + hasta.ToString(DateFormat) + "'");
      sqlString.Append("  AND " + mTable_ModeloField + " = '" + modeloFrom + "'");

      try
      {
        MySqlCommand cmd = new MySqlCommand(sqlString.ToString(), sqlCnn);
        int iCount = cmd.ExecuteNonQuery ();
      }
      catch (SystemException ex)
      {
        throw ex;
      }
      finally
      {
        sqlCnn.Close();
      }
    }
    #endregion
    
    private string DateFormat = "yyyy-MM-dd HH:mm:ss";
  }
}
