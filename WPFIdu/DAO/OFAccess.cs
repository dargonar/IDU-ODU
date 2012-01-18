using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

using log4net;
using System.Configuration;

namespace WPFiDU.DAO
{
  public class OFAccess
  {
    private static readonly ILog logger = LogManager.GetLogger(typeof(OFAccess));
    
    public const string OrdenFabricacion_Key            = "orden_fabricacion";
    public const string CodigoModelo_Key                = "codigo_modelo";
    public const string NumeroSerie_Key                 = "numero_serie";
    public const string OrdenFabricacionFormateado_Key  = "formatted_orden_fabricacion";
    
    /// <summary>
    /// A partir de un numero de Serie, busca en BBDD y retorna un dictionary con:
    /// Crudo:  "orden_fabricacion"
    /// Crudo:  "codigo_modelo"
    /// Crudo:  "numero_serie"
    /// Format: "formatted_orden_fabricacion"
    /// </summary>
    /// <param name="argSerialNumber"></param>
    /// <returns>Dictionary{"orden_fabricacion", "codigo_modelo", "numero_serie", "formatted_orden_fabricacion"}</returns>
    public static Dictionary<string, string> getOrdenFabricacion(string argSerialNumber){
      if(String.IsNullOrEmpty(argSerialNumber))
        return null;
      string strAccessConn = ConfigurationManager.AppSettings["DDBB_FOConnString"];
      if (String.IsNullOrEmpty(strAccessConn))
        return null;
      //"DDBB_FOConnString"="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\\wdir\\iduodu\\OF_DBAccess\\ODU\\MQCregister.mdb";
      string mSerialNumber = argSerialNumber.Trim().StartsWith("S") ? argSerialNumber.Trim().Substring(1): argSerialNumber.Trim();
      string strAccessSelect =
        string.Format("SELECT ordNo, prodCode, serialNo FROM testHDR WHERE serialNo = '{0}'", mSerialNumber);

      // Create the dataset and add the Categories table to it:
      //DataSet myDataSet = new DataSet();
      OleDbConnection myAccessConn = null;
      try
      {
        myAccessConn = new OleDbConnection(strAccessConn);
        myAccessConn.Open();
      }
      catch (Exception ex)
      {
        logger.Error("getOrdenFabricacion() SerialNumber:['"+mSerialNumber+"']", ex);  
        if(myAccessConn!=null)
          if(myAccessConn.State != ConnectionState.Closed)
            myAccessConn.Close();
        myAccessConn=null;
        return null;
      }

      OleDbCommand myAccessCommand = null; 
      OleDbDataReader mReader= null;
      
      try
      {
        myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
        mReader= myAccessCommand.ExecuteReader();
        //OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
        //myDataAdapter.Fill(myDataSet, "Categories");
        bool bThereIsData = mReader.Read();
        if(!bThereIsData )
          return null;
        Dictionary<string, string> data = new Dictionary<string,string>();
        data.Add(OFAccess.OrdenFabricacion_Key, Convert.ToString(mReader.GetInt32(0)));
        data.Add(OFAccess.CodigoModelo_Key, mReader.GetString(1).Trim());
        data.Add(OFAccess.NumeroSerie_Key, mReader.GetString(2).Trim());
        //string formattedOF = string.Format("F{0}{1}", data[OFAccess.OrdenFabricacion_Key], data[OFAccess.CodigoModelo_Key]);
        string formattedOF = string.Format("F{0}", data[OFAccess.OrdenFabricacion_Key]);
        data.Add(OFAccess.OrdenFabricacionFormateado_Key, formattedOF);
        
        return data;        
      }
      catch (Exception ex)
      {
        logger.Error("getOrdenFabricacion() [Error: Failed to retrieve the required data from the DataBase]", ex);  
        return null;
      }
      finally
      {
        if (myAccessConn != null)
          if (myAccessConn.State != ConnectionState.Closed)
            myAccessConn.Close();
        myAccessConn.Close(); 
        if (mReader != null)
          mReader.Close();
        mReader           = null;
        myAccessConn      = null;
        myAccessCommand   = null;
      }
 
    }
  }
}
