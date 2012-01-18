using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.Etiquetas
{
  interface IEtiqueta
  {
    string GetDescription { get; } 
    string GetCodigo { get; } 
    bool GetEsBulto { get; } 
    bool GetEsIdu { get; } 
  }
}
