using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using iDU.PLC;
using iDU.Archivo;

namespace iDU.BL
{
    public class ParametrosManager : Manager, IDisposable
    {
        private PLC.PLC AccesoPLC = null;
        private Archivo.Archivo AccesoArchivo = null;

        public ParametrosManager()
        {
            if (this.EsIdu == true)
            {
                AccesoPLC = new PLCIDU();
                AccesoArchivo = new ArchivoIDU();
            }

            else
            {
                AccesoPLC = new PLCODU();
                AccesoArchivo = new ArchivoODU();
            }
        }


        public ParametrosEnsayo LeerParametrosDeArchivo(string archivo)
        {
            return AccesoArchivo.LeerParametrosDeArchivo(archivo);
        }

        public void GuardarParametrosEnArchivo(ParametrosEnsayo parametros , string Archivo)
        {
            AccesoArchivo.GuardarParametrosEnArchivo(parametros,Archivo);

        }

        public ParametrosEnsayo LeerParametrosDeBaseDeDatosPorId(int identificacion)
        {

            return AccesoDatos.LeerParametrosDeBaseDeDatosPorId(identificacion);
        }

        public ParametrosEnsayo LeerParametrosDePLC()
        {
            return AccesoPLC.LeerParametros();
        }

        public int EscribirParametrosEnPLC(ParametrosEnsayo parametros, bool EscribirVersion)
        {
           return AccesoPLC.EscribirParametros(parametros, EscribirVersion);
            
        }

        public List<ParametrosEnsayo> LeerParametrosDeBaseDeDatos()
        {

           return AccesoDatos.ObtenerParametrosEnsayo();
        }

        public void GuardarParametrosEnBaseDeDatos(ParametrosEnsayo parametros)
        {

            AccesoDatos.GuardarParametros(parametros);
        }

        public void EliminarParametros(ParametrosEnsayo parametros)
        {

            AccesoDatos.EliminarParametros(parametros);
        }


        public void ModificarParametros(ParametrosEnsayo parametrosviejos, ParametrosEnsayo parametrosnuevos)
        {

            AccesoDatos.ModificarParametrosEnsayo(parametrosviejos,parametrosnuevos);
        }



        #region Miembros de IDisposable

        public void Dispose()
        {
            base.Dispose();
            AccesoPLC.Dispose();
        }

        #endregion
    }
}
