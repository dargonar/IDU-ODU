using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU.BL;
using log4net;

namespace dcf001
{
	public partial class mantenimiento
	{
        private Manager Manejador;
        private static readonly ILog logger = LogManager.GetLogger(typeof(mantenimiento));
        
        public mantenimiento()
		{
			this.InitializeComponent();
            Manejador = new Manager();
			
			// Insert code required on object creation below this point.
		}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAjustesParametros_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Operador))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
          
            try
            {

              ajusteparametrosidu formularioparametros = new ajusteparametrosidu();
              formularioparametros.ShowDialog();
              return;
              
            }
            catch (Exception ex)
            {
                logger.ErrorFormat(" btnAjustesParametros_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
               , ex.Message
               , ex.StackTrace
               , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();

            }
        }

        private void confirmarMantenerModoMantenimientoIdu() 
        {
            if(monitoreoIDU.NUMERO_PLC_CONECTADO_MODO_MANT==0)
            { 
                return;
            }

            string sTagModoMantenimiento = "IDU_M_ModoMantenimiento";
            if (monitoreoIDU.NUMERO_PLC_CONECTADO_MODO_MANT == 2)
            {
                sTagModoMantenimiento = "IDU_M_ModoMantenimiento_2";
            }
            iDU.PLC.PLCIDU accesoplc = new iDU.PLC.PLCIDU();
            string sModoMantenimiento = accesoplc.LeerItem(sTagModoMantenimiento);
            bool bModoMantenimiento = false;
            if (!bool.TryParse(sModoMantenimiento, out bModoMantenimiento))
            {
                accesoplc.Dispose();
                accesoplc = null;
                return;
            }
            
            bool bMantenerModoMantenimiento = false;
            
            if (bModoMantenimiento)
            {
                bMantenerModoMantenimiento = confirmacioneliminar.Show2("Desea continuar en Modo Mantenimiento al salir de la pantalla?");
                if (bMantenerModoMantenimiento)
                {
                    accesoplc.Dispose();
                    accesoplc = null;
                    return;
                }
            }

            try
            {
                //IDU_M_ModoMantenimiento
                accesoplc.EscribirItemMonitoreo(sTagModoMantenimiento, 0); 
                //accesoplc.EscribirItemMonitoreo("IDU_ST_CopiaEstadoManual", 0);
                accesoplc.Dispose();
                accesoplc = null;
                
                return;
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnClose_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);

            }
            accesoplc = null;
                
        }
        
        /// <summary>
        /// pop up de confirmacion si mantiene modo mantenimiento.
        /// </summary>
        private void confirmarMantenerModoMantenimientoOdu() 
        {
            iDU.PLC.PLCODU accesoplc = new iDU.PLC.PLCODU();
            string sModoMantenimiento = accesoplc.LeerItem("ODU_ST_CopiaBitMantenimiento");
            bool bModoMantenimiento = false;
            if (!bool.TryParse(sModoMantenimiento, out bModoMantenimiento))
            {
                accesoplc.Dispose();
                accesoplc = null;
                return;
            }

            bool bMantenerModoMantenimiento = false;

            if (bModoMantenimiento)
            {
                bMantenerModoMantenimiento = confirmacioneliminar.Show2("Desea continuar en Modo Mantenimiento al salir de la pantalla?");
                if (bMantenerModoMantenimiento)
                {
                    accesoplc.Dispose();
                    accesoplc = null;
                    return;
                }
            }

            // Aqui tengo que bajar el modo mantenimiento a 0(cero).
            try
            {
                accesoplc.Escribir("ODU_M_ModoManual", 0);
                //accesoplc.Escribir("ODU_ST_CopiaBitMantenimiento", 0);
                    accesoplc.Dispose();
                    accesoplc = null;
                    return;
                 
            }

            catch (Exception ex)
            {
                logger.ErrorFormat("btnClose_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
                , ex.Message
                , ex.StackTrace
                , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formexcepcion = new excepcion(ex);

            }
            accesoplc = null;
                    
        }

        private void btnMonitoreo_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.Operador))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
          
            try
            {
              monitoreoIDU formulariomonitoreo = new monitoreoIDU();
              formulariomonitoreo.ShowDialog();
              confirmarMantenerModoMantenimientoIdu();
            }
            catch (Exception ex)
            {
               logger.ErrorFormat(" btnMonitoreo_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
              , ex.Message
              , ex.StackTrace
              , ex.InnerException != null ? ex.InnerException.Message : "");
                excepcion formularioexcepciones = new excepcion(ex);
                formularioexcepciones.ShowDialog();

            }
        }

        private void btnVariablesPLC_Click(object sender, RoutedEventArgs e)
        {
          if (!WPFiDU.BL.ManagerUsuarios.sfUser.IsInRole(iDU.CommonObjects.Role.SuperAdmin))
          {
            excepcion exc = new excepcion("Seguridad", "Usted no está autorizado a acceder a esta sección.");
            exc.ShowDialog();
            exc = null;
            return;
          }
           
          try
          {

              variablesplcodu formplc = new variablesplcodu();
              formplc.ShowDialog();

          }
          catch (Exception ex)
          {
              logger.ErrorFormat(" btnVariablesPLC_Click(object sender, RoutedEventArgs e):: Message:'{0}', StackTrace:'{1}', InnerException:'{2}' "
            , ex.Message
            , ex.StackTrace
            , ex.InnerException != null ? ex.InnerException.Message : "");
              excepcion formularioexcepciones = new excepcion(ex);
              formularioexcepciones.ShowDialog();

          }
        }
	}
}