using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFiDU.CommonObjects
{
    public class Usuario
    {

        private int mID;

        public int ID
        {
            get { return mID; }
            set { mID = value; }
        }
        
        private int mPassword;

        public int Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        private string mDescripcion;

        public string Descripcion
        {
            get { return mDescripcion; }
            set { mDescripcion = value; }
        }
    
    }
}
