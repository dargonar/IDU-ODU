using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  class PosicEtiquetaProducto
  {
    //public PosicElement Codigo_Etiqueta_Posic =  new PosicElement();
    //public PosicElement Marca_Posic =  new PosicElement();
    public PosicElement Modelo_Posic =  new PosicElement();
    public PosicElement Conjunto_Posic =  new PosicElement();
    public PosicElement Volts_Posic =  new PosicElement();
    public PosicElement Hz_Posic =  new PosicElement();
    public PosicElement Potencia_Maxima_Posic =  new PosicElement();
    public PosicElement Corriente_Maxima_Posic =  new PosicElement();
    public PosicElement R22_Posic =  new PosicElement();
    public PosicElement Presion_Posic = new PosicElement();
    public PosicElement Capacidad_Frio_Posic =  new PosicElement();
    public PosicElement Capacidad_Calor_Posic =  new PosicElement();
    public PosicElement Potencia_Frio_Posic =  new PosicElement();
    public PosicElement Potencia_Calor_Posic =  new PosicElement();
    public PosicElement Corriente_Frio_Posic =  new PosicElement();
    public PosicElement Corriente_Calor_Posic =  new PosicElement();
    public PosicElement Peso_Posic =  new PosicElement();
    public PosicElement Grado_Proteccion_Posic =  new PosicElement();
    public PosicElement NroSerie_Posic = new PosicElement();

    public PosicEtiquetaProducto() 
    {
    
    }

    public PosicEtiquetaProducto(string[] fileLines)
    {
      if (fileLines == null || fileLines.Length < 17)
        return;
      //this.Codigo_Etiqueta_Posic = new PosicElement(fileLines[0]);
      //this.Marca_Posic = new PosicElement(fileLines[1]);
      this.Modelo_Posic = new PosicElement(fileLines[0]);
      this.Conjunto_Posic = new PosicElement(fileLines[1]);
      this.Volts_Posic = new PosicElement(fileLines[2]);
      this.Hz_Posic = new PosicElement(fileLines[3]);
      this.Potencia_Maxima_Posic = new PosicElement(fileLines[4]);
      this.Corriente_Maxima_Posic = new PosicElement(fileLines[5]);
      this.R22_Posic = new PosicElement(fileLines[6]);
      this.Presion_Posic = new PosicElement(fileLines[7]);
      this.Capacidad_Frio_Posic = new PosicElement(fileLines[8]);
      this.Capacidad_Calor_Posic = new PosicElement(fileLines[9]);
      this.Potencia_Frio_Posic = new PosicElement(fileLines[10]);
      this.Potencia_Calor_Posic = new PosicElement(fileLines[11]);
      this.Corriente_Frio_Posic = new PosicElement(fileLines[12]);
      this.Corriente_Calor_Posic = new PosicElement(fileLines[13]);
      this.Peso_Posic = new PosicElement(fileLines[14]);
      this.Grado_Proteccion_Posic = new PosicElement(fileLines[15]);
      this.NroSerie_Posic = new PosicElement(fileLines[16]);

    }
  
  }
}
