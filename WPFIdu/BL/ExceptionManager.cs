using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.BL
{
    public class ExceptionManager
    {
        public static string GetHelpText(Exception ex)
        {
            if (ex.GetType() == typeof(MySql.Data.MySqlClient.MySqlException))
            {
                return GetHelpText((MySql.Data.MySqlClient.MySqlException)ex);
            }
            else
            {
                return "";
            }
        }

        private static string GetHelpText(MySql.Data.MySqlClient.MySqlException ex)
        {
            string helpText = string.Empty;

            switch (ex.ErrorCode)
            {
                case 0:
                    helpText = "no se";
                    break;
                case 1045:
                    helpText = "Invalid username/password, please try again";
                    break;
                case 1042:
                    helpText = "Servidor de BBDD caido/host inaccesible.";
                    break;
                case 1044:
                    helpText = "Acceso denegado";
                    break;
                default:
                    helpText = string.Format("Error {0}", ex.ErrorCode);
                    break;
            }

            return helpText;
        }
    }
}
