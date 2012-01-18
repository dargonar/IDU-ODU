using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  class PosicElement:ICloneable
  {
    public double X_INI=0;
    public double X_FIN=0;
    public double Y_INI=0;
    public double Y_FIN=0;

    public double Font_Size = 10;
    public string Font_Family = "Arial";
    public string Font_Bold = "0"; 
    public string Font_Italic = "0";
    public string Align_H = "0"; // L=0 C=1 R=2
    public string Align_V = "0"; // T=0 C=1 B=2

    public string FixedText = "";

    public PosicElement() { }
    public PosicElement(string mParams)
    {
      string[] mParamsArray = mParams.Split(';');
      this.X_INI=Convert.ToDouble(mParamsArray[1].Trim());
      this.X_FIN=Convert.ToDouble(mParamsArray[2].Trim());
      this.Y_INI=Convert.ToDouble(mParamsArray[3].Trim());
      this.Y_FIN = Convert.ToDouble(mParamsArray[4].Trim());
      if (!(mParamsArray.Length > 5))
        return;
      double tmp = Convert.ToDouble(mParamsArray[5].Trim());
      if(tmp>20)
        tmp = Convert.ToDouble(mParamsArray[5].Trim().Replace(".", ","));
      this.Font_Size = tmp;
      this.Font_Family = mParamsArray[6].Trim();
      this.Font_Bold = mParamsArray[7].Trim();
      this.Font_Italic = mParamsArray[8].Trim();
      this.Align_H = mParamsArray[9].Trim(); // L=0 C=1 R=2
      this.Align_V = mParamsArray[10].Trim(); // T=0 C=1 B=2
      if(mParamsArray.Length > 11)
        this.FixedText = mParamsArray[11].Trim();
    }

    public override string ToString()
    {
      return this.FixedText;
    }

    #region ICloneable Members

    public object Clone()
    {
      PosicElement cloned = new PosicElement();
      cloned.X_INI = this.X_INI;
      cloned.X_FIN = this.X_FIN;
      cloned.Y_INI=this.Y_INI;
      cloned.Y_FIN=this.Y_FIN;
      cloned.Font_Size = this.Font_Size;
      cloned.Font_Family = this.Font_Family;
      cloned.Font_Bold = this.Font_Bold; 
      cloned.Font_Italic = this.Font_Italic;
      cloned.Align_H = this.Align_H; // L=0 C=1 R=2
      cloned.Align_V = this.Align_V; // T=0 C=1 B=2
      cloned.FixedText = this.FixedText;
      return cloned;
    }

    #endregion

     
  }
}
