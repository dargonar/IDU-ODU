using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using iDU.CommonObjects;
using log4net;

namespace iDU.BL
{
    public class ConfiguracionManager : Manager 
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConfiguracionManager));
        private Configuracion config;
        
        public Configuracion LeerConfiguracion()
        {
            CommonObjects.Configuracion config = ObtenerConfiguracion();
            return config;
        }

        public ConfiguracionManager()
        {

            config = new Configuracion();
            
            config.CadenaDeConexion = ConfigurationManager.AppSettings["DDBBConnString"];
            config.ImpresoraBulto = ConfigurationManager.AppSettings["ImpresoraBulto"];
            config.ImpresoraProducto = ConfigurationManager.AppSettings["ImpresoraProducto"];
            config.ImpresoraProductoHabilitada = Convert.ToInt32(ConfigurationManager.AppSettings["ImpresoraProductoHabilitada"])!=0;
            config.ImpresoraBultoHabilitada = Convert.ToInt32(ConfigurationManager.AppSettings["ImpresoraBultoHabilitada"]) != 0;
            config.ReadSerialNumberFromScanner = Convert.ToInt32(ConfigurationManager.AppSettings["ReadSerialNumberFromScanner"]) == 1;
            config.PrintErrorTests = Convert.ToInt32(ConfigurationManager.AppSettings["PrintErrorTests"]) == 1;
            
            logger.DebugFormat("ConfiguracionManager():: Se levanto la config. CadenaDeConexion:'{0}', ImpresoraBulto:'{1}', ImpresoraProducto:'{2}' "
                , config.CadenaDeConexion
                , config.ImpresoraBulto
                , config.ImpresoraProducto);
        
        }

        public Configuracion ObtenerConfiguracion()
        {

            return config;
        }

        public string ObtenerCadenaDeConexion()
        {
            return config.CadenaDeConexion;
            
        }


        public bool ProbarConexion(string cadena)
        {

            if (config.CadenaDeConexion != cadena)
            {
                return false;
            }
            else
            {
                try
                {
                    AccesoDatos.ObtenerVersiones();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }



        public void SetearCadenaDeConexion(string nuevacadena)
        {
            config.CadenaDeConexion = nuevacadena;
        }


        public bool ReadSerialNumberFromScanner
        {
          get { return config.ReadSerialNumberFromScanner; }
          set { config.ReadSerialNumberFromScanner = value; }
        }

        public string ObtenerImpresoraProducto()
        {
            return config.ImpresoraProducto;
        }

        public string ObtenerImpresoraBulto()
        {
            return config.ImpresoraBulto;
        }

        public bool ObtenerImpresoraProductoHabilitada()
        {
          return config.ImpresoraProductoHabilitada;
        }

        public bool ObtenerImpresoraBultoHabilitada()
        {
          return config.ImpresoraBultoHabilitada;
        }


        public void SetearImpresoraProductoHabilitada(bool b)
        {
          config.ImpresoraProductoHabilitada = b;
        }

        public void SetearImpresoraBultoHabilitada(bool b)
        {
          config.ImpresoraBultoHabilitada= b;
        }

        public void SetearImpresoraProducto(string impresora)
        {
            config.ImpresoraProducto = impresora;
        }

        public void SetearImpresoraBulto(string impresora)
        {
            config.ImpresoraBulto = impresora;
        }

        public void SetearTempMin(string temperatura)
        {

            config.TempMin = temperatura;
        }

        public void SetearTempMax(string temperatura)
        {
            config.TempMax = temperatura;

        }


        public bool ObtenerPrintErrorTests()
        {
          return config.PrintErrorTests;
        }


        public void SetearPrintErrorTests(bool b)
        {
          config.PrintErrorTests = b;
        }

        public void GuardarConfiguracion()
        {
            // Get the configuration file.
            System.Configuration.Configuration config2 =
            ConfigurationManager.OpenExeConfiguration(
            System.Reflection.Assembly.GetExecutingAssembly().Location);

            AppSettingsSection app = (AppSettingsSection)config2.GetSection("appSettings");


            app.Settings.Remove("DDBBConnString");
            app.Settings.Add("DDBBConnString", config.CadenaDeConexion);

            app.Settings.Remove("ImpresoraBultoHabilitada");
            app.Settings.Add("ImpresoraBultoHabilitada", (config.ImpresoraBultoHabilitada?1:0).ToString() );

            app.Settings.Remove("ImpresoraProductoHabilitada");
            app.Settings.Add("ImpresoraProductoHabilitada", (config.ImpresoraProductoHabilitada?1:0).ToString());

            app.Settings.Remove("ImpresoraBulto");
            app.Settings.Add("ImpresoraBulto", config.ImpresoraBulto);

            app.Settings.Remove("ImpresoraProducto");
            app.Settings.Add("ImpresoraProducto", config.ImpresoraProducto);

            app.Settings.Remove("TEMP_MIN");
            app.Settings.Add("TEMP_MIN", config.TempMin);

            app.Settings.Remove("TEMP_MAX");
            app.Settings.Add("TEMP_MAX", config.TempMax);

            app.Settings.Remove("ReadSerialNumberFromScanner");
            app.Settings.Add("ReadSerialNumberFromScanner", config.ReadSerialNumberFromScanner ? "1" : "0");

            app.Settings.Remove("PrintErrorTests");
            app.Settings.Add("PrintErrorTests", config.PrintErrorTests? "1" : "0");

            // Save the configuration file.
            config2.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section.
            ConfigurationManager.RefreshSection("appSettings");


            logger.DebugFormat("ConfiguracionManager():: Guardarconfiguracion Se guardo la config. CadenaDeConexion:'{0}', ImpresoraBulto:'{1}', ImpresoraProducto:'{2}' "
                , config.CadenaDeConexion
                , config.ImpresoraBulto
                , config.ImpresoraProducto);
        }
    }
}
