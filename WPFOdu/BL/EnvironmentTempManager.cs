using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
namespace WPFiDU.BL
{

    class EnvironmentTempManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(EnvironmentTempManager)); 
        
        private static double mEnvironmentTemp = -1;
        private const double mDummyEnvironmentTempLimitValue = -99999;
        private static double mMaxEnvironmentTempLimit = mDummyEnvironmentTempLimitValue;
        private static double mMinEnvironmentTempLimit = mDummyEnvironmentTempLimitValue;

        private static bool mEnvironmentTempIsOutOfRange = false;
        private static System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.GetCultureInfo("en-US");// InvariantCulture;
        
        private static void loadEnvironmentTempLimits() 
        {
          
            if (mMaxEnvironmentTempLimit.Equals(mDummyEnvironmentTempLimitValue))
            {
              mMaxEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MAX"], provider));
            }
            if (mMinEnvironmentTempLimit.Equals(mDummyEnvironmentTempLimitValue))
            {
              mMinEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MIN"], provider));
            }
        }

        private static void loadEnvironmentTempLimits(bool argForceLoad)
        {
            if (argForceLoad)
            {
              mMaxEnvironmentTempLimit 
                = (double.Parse(ConfigurationManager.AppSettings["TEMP_MAX"], provider));
              mMinEnvironmentTempLimit 
                = (double.Parse(ConfigurationManager.AppSettings["TEMP_MIN"], provider));
            }
            else
                loadEnvironmentTempLimits();
        }

        public static void setEnvironmentTemp(double argEnvironmentTemp) 
        {
           
            mEnvironmentTemp = argEnvironmentTemp / 10;
            
            return;
        }

        public static bool IsEnvironmentTempOutOfRange(bool argReloadConfiguration, out string argMessageText)
        {
          argMessageText = string.Empty;
          EnvironmentTempManager.loadEnvironmentTempLimits(argReloadConfiguration);

          if ((mEnvironmentTemp > 0) //HACK: 0 debe ser def value en iVision.
                    && (mEnvironmentTemp < mMinEnvironmentTempLimit
                    || mEnvironmentTemp > mMaxEnvironmentTempLimit))
          {

                
            if (mEnvironmentTempIsOutOfRange & !argReloadConfiguration)
                return mEnvironmentTempIsOutOfRange;
            
            logger.DebugFormat("setEnvironmentTemp():: Temperaturas: TempEntrada='{0}'; TempMIN='{1}'; TempMax='{2}';"
                        , mEnvironmentTemp.ToString("0.0")
                        , (mMinEnvironmentTempLimit).ToString("0.0")
                        , (mMaxEnvironmentTempLimit).ToString("0.0"));


            mEnvironmentTempIsOutOfRange = true;
            string sText = string.Format("Temperatura ='{0}'. Límite Min='{1}'. Límite Max='{2}';"
                        , (mEnvironmentTemp > 100 ? (mEnvironmentTemp / 10) : mEnvironmentTemp).ToString() //ToString("0.0")
                        ,(mMinEnvironmentTempLimit > 100 ? (mMinEnvironmentTempLimit / 10) : mMinEnvironmentTempLimit).ToString()
                        , (mMaxEnvironmentTempLimit > 100 ? (mMaxEnvironmentTempLimit / 10) : mMaxEnvironmentTempLimit).ToString() //ToString("0.0")
                        );

            argMessageText = sText;
            return mEnvironmentTempIsOutOfRange;
          }
          mEnvironmentTempIsOutOfRange = false;
          return mEnvironmentTempIsOutOfRange;
        }
    }
}
