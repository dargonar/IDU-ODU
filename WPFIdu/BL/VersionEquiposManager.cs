using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.BL
{
    class VersionEquiposManager : Manager 
    {
        
        public List<iDU.CommonObjects.VersionEquipo> ObtenerVersiones()
        {
            iDU.DAO.IDUDb AccesoDatos = new iDU.DAO.IDUDb();
            return AccesoDatos.ObtenerVersiones();

        }
    
    }
}
