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
        
        
        private static void loadEnvironmentTempLimits() 
        {
            if (mMaxEnvironmentTempLimit.Equals(mDummyEnvironmentTempLimitValue))
            { 
             mMaxEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MAX"]) / 10);
            }
            if (mMinEnvironmentTempLimit.Equals(mDummyEnvironmentTempLimitValue))
            {
                mMinEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MIN"]) / 10);
            }
        }

        private static void loadEnvironmentTempLimits(bool argForceLoad)
        {
            if (argForceLoad)
            {
                mMaxEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MAX"]) / 10);
                mMinEnvironmentTempLimit = (double.Parse(ConfigurationManager.AppSettings["TEMP_MIN"]) / 10);
            }
            else
                loadEnvironmentTempLimits();
        }

        public static void setEnvironmentTemp(double argEnvironmentTemp) 
        {
           
            mEnvironmentTemp = argEnvironmentTemp;
            
            return;
        }

        public static bool IsEnvironmentTempOutOfRange(bool argReloadConfiguration)
        {
            EnvironmentTempManager.loadEnvironmentTempLimits(argReloadConfiguration);

            if ((mEnvironmentTemp > 0) //HACK: 0 debe ser def value en iVision.
                    && (mEnvironmentTemp < mMinEnvironmentTempLimit
                    || mEnvironmentTemp > mMaxEnvironmentTempLimit))
            {

                
                if (mEnvironmentTempIsOutOfRange & !argReloadConfiguration)
                    return mEnvironmentTempIsOutOfRange;
                
                logger.DebugFormat("setEnvironmentTemp():: Temperaturas: TempEntrada='{0}'; TempMIN='{1}'; TempMax='{2}';"
                            , mEnvironmentTemp.ToString("0.0")
                            , mMinEnvironmentTempLimit.ToString("0.0")
                            , mMaxEnvironmentTempLimit.ToString("0.0"));


                mEnvironmentTempIsOutOfRange = true;
                string sText = string.Format("Temperatura ='{0}'. Límite Min='{1}'. Límite Max='{2}';"
                            , mEnvironmentTemp.ToString("0.0")
                            , mMinEnvironmentTempLimit.ToString("0.0")
                            , mMaxEnvironmentTempLimit.ToString("0.0"));

                dcf001.confirmacioneliminar.Show(
                    string.Format(
                        "Atencion : Temperatura ambiente fuera de rango para ensayos. {0}{1}"
                        , Environment.NewLine, sText)
                        );

                return mEnvironmentTempIsOutOfRange;
            }
            mEnvironmentTempIsOutOfRange = false;
            return mEnvironmentTempIsOutOfRange;
        }

        //public static bool IsEnvironmentTempOutOfRange(out string argText)
        //{
        //    argText = string.Format("Temperatura ='{0}'. Límite Min='{1}'. Límite Max='{2}';"
        //                    , mEnvironmentTemp.ToString("0.0")
        //                    , mMinEnvironmentTempLimit.ToString("0.0")
        //                    , mMaxEnvironmentTempLimit.ToString("0.0"));
        //    return IsEnvironmentTempOutOfRange();
        //}
    }
}
