using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.PLC
{
    public class VariablePLC
    {
        private string mTipoDeDato;
        private string mDescripcion;
        private string mNombreVariable;

        public string TipoDeDato
        {
            get { return mTipoDeDato; }
            set { mTipoDeDato = value; }
        }

        public string NombreVariable
        {
            get { return mNombreVariable; }
            set { mNombreVariable = value; }
        }

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
