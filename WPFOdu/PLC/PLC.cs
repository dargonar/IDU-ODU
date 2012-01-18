using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using iDU.CommonObjects;
using IVRTKERNELLib;
using WPFiDU;
using log4net;

namespace iDU.PLC
{
   public abstract class PLC : IDisposable
   {
        protected IVRTKERNELLib.RTRuntimeClass rt = null;
        public delegate void PLCEvent(string[] tags, RtkTagValue[] valores);
        public event PLCEvent OnPLCEvent;
        private static readonly ILog logger = LogManager.GetLogger(typeof(PLC));
        protected string[] tagsAsync = null;

        private bool IsReading = false;

        public PLC()
        {
            rt = new RTRuntimeClass();
            rt.OnTagChange += new DIRTRuntimeEvents_OnTagChangeEventHandler(rt_OnTagChange);
            
        }

        void rt_OnTagChange(ref int[] nIds, ref RtkTagValue[] Values)
        {
            if (OnPLCEvent == null)
                return;

            if( tagsAsync != null && nIds != null )
            {
                List<string> tags = new List<string>();
                for (int i = 0; i < nIds.Length; i++)
                    tags.Add(tagsAsync[nIds[i]]);

                OnPLCEvent(tags.ToArray(), Values);
            }
        }

        private bool mEsIdu;
        public bool EsIdu
        {
            get { return mEsIdu; }
            set { mEsIdu = value; }
        }

        public abstract ParametrosEnsayo LeerParametros();
        public abstract int EscribirParametros(ParametrosEnsayo parametros, bool EscribirVersion);
        public abstract void /*string[]*/ LeerMonitoreo();
        public abstract void EscribirItemMonitoreo(string item, int valor);
        //public abstract List<VariablePLC> ObtenerNombresVariables();
        public abstract string[] LeerEstadoInicialModos();
        public abstract void LeerEstadosPantallaPrincipalAsincronicamente();
        public abstract bool ProbarConexion();
        public abstract Ensayos LeerValoresEnsayo();
        public abstract void ResetearEnsayo();
       

        #region Helpers 1

        public static string ResolverItem(string var)
        {
            return var;
        }


        public void LeerItemsAsync(string[] items)
        {
            if (IsReading)
            {
                rt.stopReadTagsAsync();
                rt.stopReadAlarmsAsync();
            }
            int[] errs = null;
            
            int[] ids = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
                ids[i] = i;

            tagsAsync = items;
            int n = rt.readTagsAsync(ref items, ref ids, ref errs);

            IsReading = true;
        }

        public void DetenerLecturaAsincronica()
        {
            if (rt == null)
                return;
            if (!IsReading)
                return;
            rt.stopReadTagsAsync();
            rt.stopReadAlarmsAsync();
        }
     


        public string[] LeerItems(string[] items)
        {
            RtkTagValue[] values = new RtkTagValue[items.Length];
            int[] errs = new int[items.Length];

            int n = rt.readTags(ref items, ref values, ref errs);

            string[] datavalue;
            datavalue = new string[items.Length];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Value == null)
                    datavalue[i] = "-1";
                else
                {
                    datavalue[i] = values[i].Value.ToString();
                    
                    if (datavalue[i] == "False")
                        datavalue[i] = "0";
                    else if (datavalue[i] == "True")
                        datavalue[i] = "1";
                }
            }

            return datavalue;
        }

        public Dictionary<string,string> LeerItemsEx(string[] items)
        {
            RtkTagValue[]   values  = null;
            int[]           errs    = null;

            int n = rt.readTags(ref items, ref values, ref errs);
            Dictionary<string, string> retVals = new Dictionary<string, string>();
            for (int i = 0; i < items.Length; i++)
            {
                retVals[items[i]] = "-1";
                if (errs[i] != 0)
                    continue;

                if (values[i].Value == null)
                    retVals[items[i]] = "-1";
                else
                {
                    string val = values[i].Value.ToString();

                    if ( val == "False")
                        val = "0";
                    else if (val  == "True")
                        val = "1";

                    retVals[items[i]] = val;
                }
            }

            return retVals;
        }

        public bool ProbarConexion(string item, int valor)
        {
            Escribir(item, valor);
            string resultado = LeerItem(item);

            if (resultado.Equals(valor.ToString()))
                return true;
            else
                return false;
        }

        public string LeerItem(string Item)
        {

            string[] tagname = new string[] { Item };
            //int[] tagid = new int[]{1};
            RtkTagValue[] values = new RtkTagValue[1];
            int[] errs = new int[] { 1 };
            int i = rt.readTags(ref tagname, ref values, ref errs);


            if (values[0].Value == null)
                return "-1";

            return values[0].Value.ToString();

        }

        public void Escribir(string item, object value)
        {

            string[] tagname = new string[] { item };
            object[] valor = new object[] { value };
            int[] aE = null;

            int err = rt.writeTags(ref tagname, ref valor, ref aE);

            if (err != 0 )
              if (aE!=null && aE[0] != 0)
            {
                logger.ErrorFormat("PLC::Escribir(string item, object value) No se pudo escribir tag:'{0}'. Value:'{1}'. ErrorCode:'{2}'. OutErrCode:'{3}'"
                    , item, Convert.ToString(valor), err.ToString(), aE[0].ToString());
                
            }
        }

        public int Escribir(string[] items, object[] values)
        {
            int falla = 0;

            for (int i = 0; i < items.Length; i++)
            {
                string [] stringtemp  = { items[i]  };
                object [] valuetemp   = { values[i] };
                int    [] aErr        = null;

                int err = rt.writeTags(ref stringtemp, ref valuetemp, ref aErr);

                if (err != 0 || aErr[0] != 0)
                {
                    logger.ErrorFormat("PLC::Escribir(string[] items, object[] values) No se pudo escribir tag:'{0}'. Value:'{1}'. ErrorCode:'{2}'. OutErrCode:'{3}'"
                        , items[i], Convert.ToString(valuetemp), err.ToString(), aErr[0].ToString());
                    falla = -1;
                    break;
                }
            }

            return falla;
        }

        public void Escribir(VariablePLC var, string value)
        {
            int[] aE = null;
            string[] tagname = new string[] { var.NombreVariable };

           


            object[] valor = new object[] { value };

            rt.writeTags(ref tagname, ref valor, ref aE);
        }

        public RtkTagValue[] LeerRTKTagValue(string item)
        {
            RtkTagValue[] values = new RtkTagValue[1];
            int[] errs = new int[1];
            string[] tags = new string[1];
            tags[0] = item;
            int n = rt.readTags(ref tags, ref values, ref errs);
            
            return values;
        }

        
        #endregion

        #region Miembros de IDisposable

        public void Dispose()
        {
            return;
           // System.Runtime.InteropServices.Marshal.ReleaseComObject(rt);
        }

        #endregion
    }
}
