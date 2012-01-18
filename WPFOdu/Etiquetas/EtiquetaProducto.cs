using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  class EtiquetaProducto : IEtiqueta
  {


    #region IEtiqueta Implementation

    public string GetDescription
    {
      //get { return string.Format("{0} - {1}", Codigo_Etiqueta, Modelo); }
      get { return string.Format("{0} - {1} (Producto - {2})", Marca, Modelo, GetEsIdu ? "IDU" : "ODU"); }
    }
    public string GetCodigo
    {
      get { return Codigo_Etiqueta; }
    }
    public bool GetEsBulto
    {
      get { return true; }
    }
    public bool GetEsIdu { get { return this.EsIdu; } }

    #endregion IEtiqueta Implementation
    
    public string Codigo_Etiqueta= string.Empty;
    public string Marca = string.Empty;
    public string Modelo= string.Empty;
    public string Conjunto= string.Empty;
    public string Volts= string.Empty;
    public string Hz= string.Empty;
    public string Potencia_Maxima = string.Empty;
    public string Corriente_Maxima = string.Empty;
    public string R22= string.Empty;
    public string Presion_Alta= string.Empty;
    public string Presion_Baja= string.Empty;
    public string Capacidad_Frio= string.Empty;
    public string Capacidad_Calor= string.Empty;
    public string Potencia_Frio= string.Empty;
    public string Potencia_Calor= string.Empty;
    public string Corriente_Frio= string.Empty;
    public string Corriente_Calor= string.Empty;
    public string Peso= string.Empty;
    public string Grado_Proteccion = string.Empty;
    public string NroSerie = "XXXXXXXXXXX";
    public bool EsIdu = false;

    public string CodigoAAE = "";
    
    public EtiquetaProducto() 
    {
    
    }

    public EtiquetaProducto(string mParams)
    {
      string[] mParamsArray = mParams.Split(';');
      Codigo_Etiqueta= mParamsArray[0].Trim();
      Marca = mParamsArray[1].Trim();
      Modelo= mParamsArray[2].Trim();
      Conjunto= mParamsArray[3].Trim();
      Volts= mParamsArray[4].Trim();
      Hz= mParamsArray[5].Trim();
      Potencia_Maxima = mParamsArray[6].Trim();
      Corriente_Maxima = mParamsArray[7].Trim();
      R22= mParamsArray[8].Trim();
      Presion_Alta= mParamsArray[9].Trim();
      Capacidad_Frio= mParamsArray[10].Trim();
      Capacidad_Calor= mParamsArray[11].Trim();
      Potencia_Frio= mParamsArray[12].Trim();
      Potencia_Calor= mParamsArray[13].Trim();
      Corriente_Frio= mParamsArray[14].Trim();
      Corriente_Calor= mParamsArray[15].Trim();
      Peso= mParamsArray[16].Trim();
      Grado_Proteccion = mParamsArray[17].Trim();
      this.EsIdu = mParamsArray[18].Trim() == "1";
      if (mParamsArray.Length>19)
        CodigoAAE = mParamsArray[19].Trim();
    }
  }
}
