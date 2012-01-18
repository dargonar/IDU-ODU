using System;
using System.Collections.Generic;
using System.Text;
using iDU.DAO;
using iDU.CommonObjects;
using System.Configuration;


namespace iDU.BL
{
    class ModelosManager : Manager
    {
        

      
        public void AgregarModelo(Modelo m) 
        {
            m.EsIdu = EsIdu;
            AccesoDatos.AgregarModelo(m);

        }

        public void ModificarModelo(Modelo m)
        {
            m.EsIdu = EsIdu;
            AccesoDatos.ModificarModelo(m);
         

        }

        public bool EliminarModelo(Modelo m)
        {
            m.EsIdu = EsIdu;
            int i = AccesoDatos.EliminarModelo(m);
            return i == 1;

        }

        public List<Modelo> ObtenerModelos()
        {

           return  AccesoDatos.ObtenerModelos();
           

        }

        public Modelo ObtenerModeloPorNombre(string nombre)
        {

            return AccesoDatos.ObtenerModeloPorNombre(nombre);
        }

        public Modelo ObtenerModeloPorId(int nombreId)
        {

            return AccesoDatos.ObtenerModeloPorId(nombreId);
        }
        

    }
}
