using System;
using System.Collections.Generic;
using System.Text;
using iDU.DAO;
using iDU.CommonObjects;
using System.Configuration;

namespace iDU.BL
{
    class EnsayosManager : Manager
    {
      public List<Ensayos> ObtenerEnsayosPorSerie(string Serie)
      {

        return AccesoDatos.ObtenerEnsayosPorSerie(Serie);
        //return null;
      }
        public void EliminarEnsayo(int identificacion)
        {
            //'iDU.DAO.IDUDb AccesoDatos = new IDUDb();

            if (this.EsIdu)
            {
                AccesoDatos.EliminarEnsayoIDU(identificacion);
            }
            else
            {
                AccesoDatos.EliminarEnsayoODU(identificacion);
            }
        }

        public List<Ensayos> ObtenerEnsayosPorFecha(DateTime desde, DateTime hasta)
        {
            
            return AccesoDatos.ObtenerEnsayosPorFecha(desde, hasta);
            //return null;
        }

       /* public void VerDetallesDelEnsayo(Ensayos ne)
        {

        }*/

        public int EliminarFallas()
        {
            return AccesoDatos.EliminarFallas();
        }


        public List<Ensayos> ObtenerEnsayosAprobados(DateTime ahora)
        {
            
       
            return AccesoDatos.ObtenerEnsayosAprobados(ahora);

        }

        public List<Ensayos> ObtenerEnsayosFallados(DateTime ahora)
        {
            
            return AccesoDatos.ObtenerEnsayosFallados(ahora);

        }

        public void ModificarObservacion(Ensayos e, string nuevaobservacion)
        {

            AccesoDatos.ModificarObservacion(e, nuevaobservacion);
        }

        public void GuardarValoresEnsayo(Ensayos e, string argScannedSerialNumber)
        {
          AccesoDatos.ObtenerNroSerieAgregarEnsayo(e, argScannedSerialNumber);
        }
      
        public void AsignarNumeroDeSerieAprobadoEnsayo(Ensayos e)
        {

            string ndeserie = AccesoDatos.ObtenerNumeroDeSerie(1);
            e.Serie = ndeserie;
        }

        public void AsignarNumeroDeSerieNoAprobadoEnsayo(Ensayos e)
        {

            string ndeserie = AccesoDatos.ObtenerNumeroDeSerie(0);
            e.Serie = ndeserie;

        }

        public string ObtenerDescripcionFalla(Ensayos e)
        {
            if (e.Aprobado == true)
                return "Ensayo OK";
            else
                return AccesoDatos.ObtenerDescripcionFalla(e);

        }

        public bool ObtenerPrioridadFalla(int codigo)
        {
            return AccesoDatos.ObtenerPrioridadFalla(codigo);

        }

        public Ensayos ObtenerUltimoEnsayo()
        {

            return AccesoDatos.ObtenerUltimoEnsayo();

        }
    }
}
