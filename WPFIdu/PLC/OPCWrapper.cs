using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Runtime.InteropServices;
using IVRTKERNELLib;
using OPC.Common;
using OPC.Data.Interface;
using OPC.Data;
using log4net;
using iDU.CommonObjects;
namespace iDU.PLC
{      
    class OPCWrapper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(OPCWrapper));
        const string serverProgID = "S7200.OPCServer";
        private OpcServer theSrv;
        private OpcGroup theGrp;
                
        public void Write(ParametrosEnsayo parametros)
        {
          string[] tagnames; double[] valores;

            List<OPCItemDef> itemDefsList = new List<OPCItemDef>();
            List<int> handlesSrvList = new List<int>();
            List<object> itemValuesList = new List<object>();
            List<string> tagnamesList = new List<string>();

            // For Debug only.
            //EnsayoDebugWriter mEnsayoDebugWriter = new EnsayoDebugWriter();
            PLCIDU oPLCIDU = new PLCIDU();
            oPLCIDU.GetParametrosAEscribir(parametros, out tagnamesList, out itemValuesList);
            
            for (int i = 0; i < tagnamesList.Count; i++)
            {
              handlesSrvList.Add(i);
              //mEnsayoDebugWriter.AppendText(tagnames[i]
              //    , valueCrudo
              //    , factor
              //    , value);
            }


            //mEnsayoDebugWriter.Flush();
            //mEnsayoDebugWriter.Dispose();
            //mEnsayoDebugWriter = null;

            theSrv = new OpcServer();
            theSrv.Connect(serverProgID);                        
            theGrp = theSrv.AddGroup("OPCCSharp-Group", false, 900);
        
            object[] itemValues = itemValuesList.ToArray();
            int[] handlesSrv = handlesSrvList.ToArray();

            for (int i = 0; i < itemValues.Length; i++)
            {
                itemDefsList.Add(new OPCItemDef("MicroWin.PLCodu." + tagnamesList[i], false, i, VarEnum.VT_EMPTY));
            }            

            OPCItemDef[] itemDefs = itemDefsList.ToArray();                                
            OPCItemResult[] rItm;
            theGrp.AddItems(itemDefs, out rItm);
            if (rItm == null)
                return;
            for(int i=0;i<rItm.Length;i++)
            {
                if (HRESULTS.Failed(rItm[i].Error))
                {
                    logger.ErrorFormat(" OPC Tester: AddItems - some failed");              
                    Console.WriteLine("OPC Tester: AddItems - some failed");
                    theGrp.Remove(true); 
                    theSrv.Disconnect(); 
                    return;
                }                                      
            }
                        
            for (int i = 0; i < handlesSrv.Length; i++)
                handlesSrv[i] = rItm[i].HandleServer;                        
            
            int[] itemErrors;
            if(theGrp.Write(handlesSrv,itemValues,out itemErrors)!=true)
            {
                logger.ErrorFormat("OPC Tester: Write FAILED");              
                Console.WriteLine("OPC Tester: Write FAILED");
            }

            for (int i=0;i<itemErrors.Length;i++)
            {
                if(HRESULTS.Failed(itemErrors[i]))
                {
                    Console.WriteLine("OPC Tester: WriteItem FAILED--> item:"+tagnamesList[i] );
                    logger.ErrorFormat("OPC Tester: WriteItem FAILED--> item:" + tagnamesList[i] );
                }
            }                
            
            theGrp.RemoveItems(handlesSrv, out itemErrors);
            theGrp.Remove(false);
            theSrv.Disconnect();
            theGrp = null;
            theSrv = null;
        }         
    }
    }
