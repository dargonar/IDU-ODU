using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{
    public class VersionEquipo
    {
      public VersionEquipo() { }

      public VersionEquipo(int id, string description)
      {
        this.Descripcion = description;
        this.ID = id;
      }

      private int mID;

      public int ID
      {
          get { return mID; }
          set { mID = value; }
      }

      private string mDescripcion;

      public string Descripcion
      {
          get { return mDescripcion; }
          set { mDescripcion = value; }
      }

      public override string ToString()
      {
          return mDescripcion;
      }
    


    }
}
