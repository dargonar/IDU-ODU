using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  class PosicEtiquetaBulto
  {
    //public PosicElement Codigo_Etiqueta_Posic = new PosicElement();
    //public PosicElement Marca_Comercial_Posic = new PosicElement();
    public PosicElement Modelo_Posic = new PosicElement();
    public PosicElement Modelo_Peq_Posic = new PosicElement(); 
    public PosicElement Capacidad_Posic = new PosicElement();
    public PosicElement Modo_Posic = new PosicElement();
    public PosicElement Peso_Posic = new PosicElement();
    public PosicElement Alto_Posic = new PosicElement();
    public PosicElement Ancho_Posic = new PosicElement();
    public PosicElement Profundidad_Posic = new PosicElement();
    public PosicElement Codigo_Conjunto_Posic = new PosicElement();
    public PosicElement Codigo_EAN_Posic = new PosicElement();
    public PosicElement CapacidadKcal_Posic = new PosicElement();
    public PosicElement NroSerie_Posic = new PosicElement();
    public PosicElement ModoPeq_Posic = new PosicElement();

    public PosicElement FixNroSerie = new PosicElement();
    public PosicElement FixCodigoEAN = new PosicElement();
    public PosicElement FixConjunto = new PosicElement();
    public PosicElement FixDistribuye = new PosicElement();
    public PosicElement FixCarrier = new PosicElement();
    public PosicElement FixAvenida = new PosicElement();
    public PosicElement FixArgentina = new PosicElement();
    public PosicElement FixFabricado = new PosicElement();
    public PosicElement FixIndArg = new PosicElement();
    public PosicElement FixCapacidadKcal = new PosicElement();
    public PosicElement FixVolt = new PosicElement();

    public PosicElement CodConjuntoBarcode= new PosicElement();  
    
    public PosicEtiquetaBulto() 
    {
    
    }

    public PosicEtiquetaBulto(string[] fileLines)
    {
      if (fileLines == null || fileLines.Length < 13)
        return;
      //this.Codigo_Etiqueta_Posic = new PosicElement(fileLines[0]);
      //this.Marca_Comercial_Posic = new PosicElement(fileLines[1]);
      this.Modelo_Posic = new PosicElement(fileLines[0]);
      this.Modelo_Peq_Posic = new PosicElement(fileLines[1]);
      this.Capacidad_Posic = new PosicElement(fileLines[2]);
      this.Modo_Posic = new PosicElement(fileLines[3]);
      this.Peso_Posic = new PosicElement(fileLines[4]);
      this.Alto_Posic = new PosicElement(fileLines[5]);
      this.Ancho_Posic = new PosicElement(fileLines[6]);
      this.Profundidad_Posic = new PosicElement(fileLines[7]);
      this.Codigo_Conjunto_Posic = new PosicElement(fileLines[8]);
      this.Codigo_EAN_Posic = new PosicElement(fileLines[9]);
      this.CapacidadKcal_Posic = new PosicElement(fileLines[10]);
      this.ModoPeq_Posic = new PosicElement(fileLines[11]);
      this.NroSerie_Posic = new PosicElement(fileLines[12]);


      this.FixNroSerie = new PosicElement(fileLines[13]);
      this.FixCodigoEAN = new PosicElement(fileLines[14]);
      this.FixConjunto = new PosicElement(fileLines[15]);
      this.FixDistribuye = new PosicElement(fileLines[16]);
      this.FixCarrier = new PosicElement(fileLines[17]);
      this.FixAvenida = new PosicElement(fileLines[18]);
      this.FixArgentina = new PosicElement(fileLines[19]);
      this.FixFabricado = new PosicElement(fileLines[20]);
      this.FixIndArg = new PosicElement(fileLines[21]);
      this.FixCapacidadKcal = new PosicElement(fileLines[22]);
      this.FixVolt = new PosicElement(fileLines[23]);
      this.CodConjuntoBarcode = new PosicElement(fileLines[24]);
    }
  }
}
