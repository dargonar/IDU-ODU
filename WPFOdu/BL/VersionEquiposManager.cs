using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.BL
{
    class VersionEquiposManager : Manager 
    {
        
        public List<iDU.CommonObjects.VersionEquipo> ObtenerVersiones()
        {
            iDU.DAO.ODUDb AccesoDatos = new iDU.DAO.ODUDb();
            return AccesoDatos.ObtenerVersiones();

        }
    
    }
}
