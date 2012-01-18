using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace DCFStarter
{
  class RestoreBatExecuter
  {
      public static bool ExecuteBatchFile(string batchFileName, string[] argumentsToBatchFile, out string data)
    {
        data = "ARGS = ";
      string argumentsString = string.Empty;
      try
      {
        //Add up all arguments as string with space separator between the arguments
        if (argumentsToBatchFile != null)
        {
          for (int count = 0; count < argumentsToBatchFile.Length; count++)
          {
            argumentsString += " ";
            argumentsString += "\"" + argumentsToBatchFile[count] + "\"";
            //argumentsString += "\"";
            
          }
        }
          data += argumentsString;
        data += Environment.NewLine;
        //Create process start information
        System.Diagnostics.ProcessStartInfo DBProcessStartInfo = new System.Diagnostics.ProcessStartInfo(batchFileName, argumentsString);

          

        //Redirect the output to standard window
        DBProcessStartInfo.RedirectStandardOutput = true;

        //The output display window need not be falshed onto the front.
        DBProcessStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        DBProcessStartInfo.UseShellExecute = false;

        //Create the process and run it
        System.Diagnostics.Process dbProcess;
        dbProcess = System.Diagnostics.Process.Start(DBProcessStartInfo);

        //Catch the output text from the console so that if error happens, the output text can be logged.
        System.IO.StreamReader standardOutput = dbProcess.StandardOutput;

        /* Wait as long as the DB Backup or Restore or Repair is going on. 
        Ping once in every 2 seconds to check whether process is completed. */
        while (!dbProcess.HasExited)
          dbProcess.WaitForExit(2000);

        if (dbProcess.HasExited)
        {
            data += standardOutput.ReadToEnd();
            data += Environment.NewLine;

        }

        return true;
      }
      // Catch the SQL exception and throw the customized exception made out of that
      catch (MySqlException ex)
      {

        throw ex;
      }
      // Catch all general exceptions
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
