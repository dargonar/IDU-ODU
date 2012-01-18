using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  class EtiquetaBulto : IEtiqueta
  {


    #region IEtiqueta Implementation

    public string GetDescription
    {
      get { return string.Format("{0} - {1}", Codigo_Etiqueta, Modelo); }
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

    public string Codigo_Etiqueta = string.Empty;
    public string Marca_Comercial = string.Empty;
    public string Modelo = string.Empty;
    public string Capacidad = string.Empty;
    public string Modo = string.Empty;
    public string Peso = string.Empty;
    public string Alto = string.Empty;
    public string Ancho = string.Empty;
    public string Profundidad = string.Empty;
    public string Codigo_Conjunto = string.Empty;
    public string Codigo_EAN = string.Empty;
    public string CapacidadKcal = string.Empty;
    public string NroSerie = "XXXXXXXXXXX";
    public bool EsIdu = false;

    public string CodEan = "";
    public string ForeColor = "0";



    public EtiquetaBulto()
    {

    } 

    public EtiquetaBulto(string mParams)
    {
      string[] mParamsArray = mParams.Split(';');
      this.Codigo_Etiqueta = mParamsArray[0].Trim();
      this.Marca_Comercial = mParamsArray[1].Trim();
      this.Modelo = mParamsArray[2].Trim();
      this.Capacidad = mParamsArray[3].Trim();
      this.Modo = mParamsArray[4].Trim();
      this.Peso = mParamsArray[5].Trim();
      this.Alto = mParamsArray[6].Trim();
      this.Ancho = mParamsArray[7].Trim();
      this.Profundidad = mParamsArray[8].Trim();
      this.Codigo_Conjunto = mParamsArray[9].Trim();
      this.Codigo_EAN = mParamsArray[10].Trim();
      this.CapacidadKcal = mParamsArray[11].Trim();
      this.EsIdu = mParamsArray[12].Trim() == "1";
      this.CodEan = mParamsArray[13].Trim();
      this.ForeColor = mParamsArray[14].Trim();

    }
    
    public string getCodigoConjuntoLimitesByAsterisk()
    {
      return string.Format("*{0}*",this.Codigo_Conjunto.Trim());
    }
  }
}
