using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace WPFiDU.Utils
{
    
    public class LastDCFConnectionManager
    {
        public const string LastDCFConnectionFilePath = @"\LastDCFConnection.txt";

        public static int getLastDCFConnectionComboIndex()
        {
            DirectoryInfo DIR = new DirectoryInfo(WPFiDU.Utils.Utils.getBinFullDirectory());

            if (!DIR.Exists)
            {
                DIR.Create();
            }
            string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + LastDCFConnectionFilePath;
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH);
                StreamWriter sw = new StreamWriter(PATH, false);
                sw.Write("-1");
                sw.Close();
            }
            StreamReader sr = new StreamReader(PATH);

            int iLastDCFConnectionComboIndex = 0;
            string sLastDCFConnectionComboIndex = sr.ReadLine();
            if (!String.IsNullOrEmpty(sLastDCFConnectionComboIndex))
            {
                bool b = int.TryParse(sLastDCFConnectionComboIndex, out iLastDCFConnectionComboIndex);
                if (!b)
                    iLastDCFConnectionComboIndex = 0;
            }
            sr.Close();

            return iLastDCFConnectionComboIndex;
        }

        public static void setLastDCFConnectionComboIndex(int iIndex)
        {

            string PATH = WPFiDU.Utils.Utils.getBinFullDirectory() + LastDCFConnectionFilePath;
            StreamWriter sw = new StreamWriter(PATH, false);
            sw.Write(Convert.ToString(iIndex));
            sw.Close();

            return;
        }

    }
}
