using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.Configuration;
using iDU.DAO;


namespace iDU.BL
{
    public class CaracteristicasTecnicasManager : Manager
    {
   


       

        public void AgregarCaracteristicaTecnica(iDU.CommonObjects.CaracteristicasTecnicas ct)
        {
            ct.Esidu = EsIdu;
            AccesoDatos.AgregarCaracteristicaTecnica(ct);
            return;
   
        }

        public void ModificarCaracteristicaTecnica(iDU.CommonObjects.CaracteristicasTecnicas ct)
        {

           
            ct.Esidu = EsIdu;
            AccesoDatos.ModificarCaracteristicaTecnica(ct);
            return;
        

        }

        public void EliminarCaracteristicaTecnica(iDU.CommonObjects.CaracteristicasTecnicas ct)
        {

          
            ct.Esidu = EsIdu;
            AccesoDatos.EliminarCaracteristicaTecnica(ct);
            return;
        }

        public List<CaracteristicasTecnicas> ObtenerCaracteristicasTecnicas()
        {
            return AccesoDatos.ObtenerCaracteristicasTecnicas();

        }

        public CaracteristicasTecnicas ObtenerCaracteristicaTecnicaDeModelo(Modelo modelo)
        {
            return AccesoDatos.ObtenerCaracteristicaTecnicaDeModelo(modelo);

        }
    
    }
}
