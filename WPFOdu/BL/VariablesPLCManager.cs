using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using iDU.BL;
using iDU.PLC;

namespace iDU.BL
{
    public class VariablesPLCManager : Manager
    {
         public List<VariablePLC> ObtenerNombresVariables()
         {

            List<VariablePLC> listavariables = new List<VariablePLC>();

            foreach (string s in ConfigurationManager.AppSettings.AllKeys)
          {
              if (!s.StartsWith("VPLCO"))
                  continue;


              VariablePLC nuevavariable = new VariablePLC();
              string[] parts = ConfigurationManager.AppSettings[s].Split('/');
              if (parts.Length != 3)
                  continue;

              nuevavariable.NombreVariable = parts[0];
              nuevavariable.Descripcion = parts[1];
              nuevavariable.TipoDeDato = parts[2];

              listavariables.Add(nuevavariable);

          }


            return listavariables;
            

        }
    
    }
}
