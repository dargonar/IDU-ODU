using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;

namespace iDU.PLC
{
    public class PLCODU : PLC
    {

        public PLCODU() : base() { }
        public override ParametrosEnsayo LeerParametros()
        {
            lock (rt)
            {
                ParametrosEnsayoODU parodu = new ParametrosEnsayoODU();
                List<string> items = new List<string>();


                items.Add(ResolverItem("ODU_SP_MaximaPresionAdmisibleInicio"));
                items.Add(ResolverItem("ODU_SP_MinimaDiferenciaPresionInicio"));
                items.Add(ResolverItem("ODU_SP_TimeoutModoCalor"));
                items.Add(ResolverItem("ODU_SP_TimerRecuperacionRefrigerante"));
                items.Add(ResolverItem("ODU_SP_TimerEnsayoBajaTension"));
                items.Add(ResolverItem("ODU_SP_TimerEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_TimerEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_TimerEstabilizacionPresiones"));
                items.Add(ResolverItem("ODU_SP_TimeoutRecuperacion"));
                items.Add(ResolverItem("ODU_SP_TimeoutPresionInicial"));
                items.Add(ResolverItem("ODU_SP_MinimaCorrienteEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_MaximaCorrienteEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_MinimaDiferenciaTemperaturaCalor"));
                items.Add(ResolverItem("ODU_SP_MaximaDiferenciaTemperaturaCalor"));
                items.Add(ResolverItem("ODU_SP_MinimaDiferenciaPresionCompresor"));
                items.Add(ResolverItem("ODU_SP_MaximaDiferenciaPresionCompresor"));
                items.Add(ResolverItem("ODU_SP_MinimaVelocidadCompresor"));
                items.Add(ResolverItem("ODU_SP_MaximaDiferenciaPresionInicio"));
                items.Add(ResolverItem("ODU_SP_DelayAntesIndicFinalizado"));
                items.Add(ResolverItem("ODU_SP_MinimaPresionAdmisibleInicio"));
                items.Add(ResolverItem("ODU_SP_TiempoIDUOFFEntreFrioCalor"));
                items.Add(ResolverItem("ODU_SP_TimerDelayArranqueCompresor"));
                items.Add(ResolverItem("ODU_SP_TimerDelayCierreValvula1"));
             
                items.Add(ResolverItem("ODU_SP_MaximaPresionAdmisibleRecuperacionRefrigerante"));
                items.Add(ResolverItem("ODU_SP_MaximaPresionEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaCorrienteEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MaximaCorrienteEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MaximaDiferenciaTemperaturaEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaDiferenciaTemperaturaEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaPresionAdmisibleDesactivarValvula4Vias"));
                items.Add(ResolverItem("ODU_SP_MaximaVelocidadEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_MinimaVelocidadEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_MaximaPotenciaEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_MinimaPresionEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MaximaVelocidadEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaVelocidadEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MaximaPotenciaEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaPotenciaEnsayoFrio"));
                items.Add(ResolverItem("ODU_SP_MinimaPotenciaEnsayoCalor"));
                items.Add(ResolverItem("ODU_SP_TimerDelayCierreValvula2"));
                items.Add(ResolverItem("ODU_SP_TimeoutBajaTension"));
        
                string[] arrayitems = items.ToArray();

        
                Dictionary<string,string> valores = LeerItemsEx(arrayitems);


                parodu.TiempoMaximoBajaTension      = int.Parse(valores["ODU_SP_TimeoutBajaTension"]);
                parodu.TiempoCierreValvula2         = int.Parse(valores["ODU_SP_TimerDelayCierreValvula2"]);
                parodu.PotenciaMinCalor             = int.Parse(valores["ODU_SP_MinimaPotenciaEnsayoCalor"]);
                parodu.PotenciaMinFrio              = int.Parse(valores["ODU_SP_MinimaPotenciaEnsayoFrio"]);
                parodu.PotenciaMaxFrio              = int.Parse(valores["ODU_SP_MaximaPotenciaEnsayoFrio"]);
                parodu.VelocidadMinVentiladorFrio   = int.Parse(valores["ODU_SP_MinimaVelocidadEnsayoFrio"]);
                parodu.VelocidadMaxVentiladorFrio   = int.Parse(valores["ODU_SP_MaximaVelocidadEnsayoFrio"]);
                parodu.PresionMinFrio               = int.Parse(valores["ODU_SP_MinimaPresionEnsayoFrio"]);
                parodu.PotenciaMaxCalor             = int.Parse(valores["ODU_SP_MaximaPotenciaEnsayoCalor"]);
                parodu.VelocidadMinVentiladorCalor  = int.Parse(valores["ODU_SP_MinimaVelocidadEnsayoCalor"]);
                parodu.VelocidadMaxVentiladorCalor  = int.Parse(valores["ODU_SP_MaximaVelocidadEnsayoCalor"]);
                parodu.PresionMinApagadoCompresor   = int.Parse(valores["ODU_SP_MinimaPresionAdmisibleDesactivarValvula4Vias"]);
                parodu.DeltaTempMinFrio             = int.Parse(valores["ODU_SP_MinimaDiferenciaTemperaturaEnsayoFrio"]);
                parodu.DeltaTempMaxFrio             = int.Parse(valores["ODU_SP_MaximaDiferenciaTemperaturaEnsayoFrio"]);
                parodu.CorrienteMaxFrio             = int.Parse(valores["ODU_SP_MaximaCorrienteEnsayoFrio"]);
                parodu.CorrienteMinFrio             = int.Parse(valores["ODU_SP_MinimaCorrienteEnsayoFrio"]);
                parodu.PresionMaxFrio               = int.Parse(valores["ODU_SP_MaximaPresionEnsayoFrio"]);
                parodu.PresionMaxRecuperacion       = int.Parse(valores["ODU_SP_MaximaPresionAdmisibleRecuperacionRefrigerante"]);
                parodu.TiempoCierreValvula1         = int.Parse(valores["ODU_SP_TimerDelayCierreValvula1"]);
                parodu.DelayArranqueCompresor       = int.Parse(valores["ODU_SP_TimerDelayArranqueCompresor"]);
                
                //parodu.Descripcion = LeerItem(ResolverItem("Descripcion"));

                parodu.TiempoApagadoEntreCalorFrio      = int.Parse(valores["ODU_SP_TiempoIDUOFFEntreFrioCalor"]);
                parodu.PresionInicialMin                = int.Parse(valores["ODU_SP_MinimaPresionAdmisibleInicio"]);
                parodu.TiempoFinal                      = int.Parse(valores["ODU_SP_DelayAntesIndicFinalizado"]);
                parodu.DeltaPresionEstabilizacionMax    = int.Parse(valores["ODU_SP_MaximaDiferenciaPresionInicio"]);
                parodu.VelocidadBajaTensionMin          = int.Parse(valores["ODU_SP_MinimaVelocidadCompresor"]);
                parodu.DeltaPresionBajaTensionMax       = int.Parse(valores["ODU_SP_MaximaDiferenciaPresionCompresor"]);
                parodu.DeltaPresionBajaTensionMin       = int.Parse(valores["ODU_SP_MinimaDiferenciaPresionCompresor"]);
                parodu.DeltaTempMaxCalor                = int.Parse(valores["ODU_SP_MaximaDiferenciaTemperaturaCalor"]);
                parodu.DeltaTempMinCalor                = int.Parse(valores["ODU_SP_MinimaDiferenciaTemperaturaCalor"]);
                parodu.CorrienteMinCalor                = int.Parse(valores["ODU_SP_MinimaCorrienteEnsayoCalor"]);
                parodu.CorrienteMaxCalor                = int.Parse(valores["ODU_SP_MaximaCorrienteEnsayoCalor"]);
                parodu.TiempoMaximoEstabilizacion       = int.Parse(valores["ODU_SP_TimeoutPresionInicial"]);
                parodu.TiempoMaximoRecuperacionMinima   = int.Parse(valores["ODU_SP_TimeoutRecuperacion"]);
                parodu.TiempoInicialEstabilizacion      = int.Parse(valores["ODU_SP_TimerEstabilizacionPresiones"]);
                parodu.TiempoMedicionCalor              = int.Parse(valores["ODU_SP_TimerEnsayoCalor"]);
                parodu.TiempoMedicionFrio               = int.Parse(valores["ODU_SP_TimerEnsayoFrio"]);
                parodu.TiempoBajaTension                = int.Parse(valores["ODU_SP_TimerEnsayoBajaTension"]);
                parodu.TiempoRecuperacionMinima         = int.Parse(valores["ODU_SP_TimerRecuperacionRefrigerante"]);
                parodu.TiempoMaximoMedicionCalor        = int.Parse(valores["ODU_SP_TimeoutModoCalor"]);
                parodu.DeltaPresionEstabilizacionMin    = int.Parse(valores["ODU_SP_MinimaDiferenciaPresionInicio"]);
                parodu.PresionInicialMax                = int.Parse(valores["ODU_SP_MaximaPresionAdmisibleInicio"]);
             

                return parodu;
            }
        }

        public override Ensayos LeerValoresEnsayo()
        {
            lock (rt)
            {
                EnsayosODU ensodu = new EnsayosODU();

                List<string> items = new List<string>();


                items.Add(ResolverItem("ODU_ST_CodigoDeFalla")); //0
                items.Add(ResolverItem("ODU_E_Vel_Baja"));    //1
                items.Add(ResolverItem("ODU_E_Vel_Alta_Calor"));//2
                items.Add(ResolverItem("ODU_E_Vel_Alta_Frio"));//3
                items.Add(ResolverItem("ODU_E_TiempoEnsayo"));//4
                items.Add(ResolverItem("ODU_E_Ten_Baja"));//5
                items.Add(ResolverItem("ODU_E_Ten_Alta_Calor"));//6
                items.Add(ResolverItem("ODU_E_Ten_Alta_Frio"));//7
                items.Add(ResolverItem("ODU_E_TempAltaCalor"));//8
                items.Add(ResolverItem("ODU_E_TempAltaFrio"));//9
                items.Add(ResolverItem("ODU_E_TempAmbiente_Calor"));//10
                items.Add(ResolverItem("ODU_E_TempAmbiente_Frio"));//11
                items.Add(ResolverItem("ODU_E_Pres_Calor"));//12
                items.Add(ResolverItem("ODU_E_Pres_Recuperacion"));//13
                items.Add(ResolverItem("ODU_E_Pres_Frio"));//14
                items.Add(ResolverItem("ODU_E_Pres_BajaTension"));//15
                items.Add(ResolverItem("ODU_E_Pres_Inicial"));//16
                items.Add(ResolverItem("ODU_E_Pot_Alta_Calor"));//17
                items.Add(ResolverItem("ODU_E_Pot_Alta_Frio"));//18
                items.Add(ResolverItem("ODU_E_Hum_Calor"));//19
                items.Add(ResolverItem("ODU_E_Hum_Frio"));//20
                items.Add(ResolverItem("ODU_E_Cosf_Calor"));//21
                items.Add(ResolverItem("ODU_E_Cosf_Frio"));//22
                items.Add(ResolverItem("ODU_E_Cor_BajaFrio"));//23
                items.Add(ResolverItem("ODU_E_Cor_TempAltaCalor"));//24
                items.Add(ResolverItem("ODU_E_Cor_TempAltaFrio"));//25
              
            //    items.Add(ResolverItem("EnsayoAprobadoODU"));
            //    items.Add(ResolverItem("EnsayoFallaODU"));

             
                string[] arrayitems = items.ToArray();


                string[] arrayvaloresstr = LeerItems(arrayitems);
                int[] arrayvalores = new int[arrayvaloresstr.Length];

                for (int i = 0; i < arrayvalores.Length; i++)
                    arrayvalores[i] = int.Parse(arrayvaloresstr[i]);

                /*     ensodu.Aprobado = arrayvalores[29] ;
                 ensodu.Fuga=arrayvalores[28];
                     ensodu.Hipot=arrayvalores[27]; 
                 * ensodu.Vacio=arrayvalores[26];
                 */
               // if (arrayvalores[25] == "True")
                 //   ensodu.Aprobado = true;
               // else
             //       ensodu.Aprobado = false;
                
                ensodu.Corrienteh=arrayvalores[25];
                ensodu.Corrientehc=arrayvalores[24];
                ensodu.Corrientel=arrayvalores[23];
                ensodu.Cosf=arrayvalores[22];
                ensodu.Cosfc=arrayvalores[21];
                
                ensodu.Humedad=arrayvalores[20];
                ensodu.Humedadc=arrayvalores[19];
                ensodu.Potenciah=arrayvalores[18];
                ensodu.Potenciahc=arrayvalores[17];
                ensodu.Presion1=arrayvalores[16];
                ensodu.Presion2=arrayvalores[15];
                ensodu.Presion3=arrayvalores[14];
                ensodu.Presion4=arrayvalores[13];
                ensodu.Presionc=arrayvalores[12];
                ensodu.Tamb=arrayvalores[11];
                ensodu.Tambc=arrayvalores[10];
                ensodu.Temph=arrayvalores[9];
                ensodu.Temphc=arrayvalores[8];
                ensodu.Tensionh=arrayvalores[7];
                ensodu.Tensionhc=arrayvalores[6];
                ensodu.Tensionl=arrayvalores[5];
                ensodu.Tiempoensayo=arrayvalores[4];
                
                ensodu.Velocidadh=arrayvalores[3];
                ensodu.Velocidadhc=arrayvalores[2];
                ensodu.Velocidadl=arrayvalores[1];
                ensodu.Codigo =arrayvalores[0].ToString();

                return ensodu;
            }
        }

        public override bool ProbarConexion()
        {
            /*TODO : variable que no se utilize en ODU*/
           /* string item = ResolverItem("VelocidadTempODU");

            int valor = 0;

            return ProbarConexion(item, valor);*/
            return true;
        }

        public override void LeerEstadosPantallaPrincipalAsincronicamente()
        {
            List<string> items = new List<string>();

            items.Add(ResolverItem("ODU_Q_TensionNominal"));
            items.Add(ResolverItem("ODU_ST_DummyPres"));
            items.Add(ResolverItem("ODU_M_ModoCalor"));
            items.Add(ResolverItem("ODU_Q_BajaTension"));
            items.Add(ResolverItem("ODU_MD_Velocidad"));
            items.Add(ResolverItem("ODU_MD_Corriente"));
            items.Add(ResolverItem("ODU_I_TermistorOK"));
            items.Add(ResolverItem("ODU_MD_TempEntrada"));
            items.Add(ResolverItem("ODU_MD_TempSalida"));
            items.Add(ResolverItem("ODU_MD_Presion"));
            items.Add(ResolverItem("ODU_MD_Humedad"));
            items.Add(ResolverItem("ODU_MD_TensionEstado"));
            items.Add(ResolverItem("ODU_MD_Potencia"));
            items.Add(ResolverItem("ODU_ST_EnsayoEnCurso"));
            items.Add(ResolverItem("ODU_ST_CodigoDeFalla"));
            items.Add(ResolverItem("ODU_ST_EnsayoAprobado"));
            items.Add(ResolverItem("ODU_ST_EnsayoFalla"));
            items.Add(ResolverItem("ODU_M_CierreValvulaLiquido"));
            items.Add(ResolverItem("ODU_M_CierreValvulaGas"));
            items.Add(ResolverItem("ODU_ST_CodigoDeFalla"));

            items.Add(ResolverItem("ODU_ST_CopiaBitMantenimiento"));

            tagsAsync = items.ToArray();

            

            LeerItemsAsync(tagsAsync);
            return;
        }

        public override void EscribirItemMonitoreo(string item, int valor)
        {
            string mItem = ResolverItem(item);
            Escribir(mItem, valor);
        }


        public override void ResetearEnsayo()
        {
            throw new NotImplementedException();
        }

        public override /*string[]*/ void LeerMonitoreo()
        {
            List<string> items = new List<string>();


            items.Add(ResolverItem("ODU_MD_TempEntrada"));
            items.Add(ResolverItem("ODU_MD_TempSalida"));
            items.Add(ResolverItem("ODU_MD_Humedad"));
            items.Add(ResolverItem("ODU_MD_Presion"));
            items.Add(ResolverItem("ODU_MD_TensionEstado"));
            items.Add(ResolverItem("ODU_MD_Corriente"));
            items.Add(ResolverItem("ODU_MD_Potencia"));
            items.Add(ResolverItem("ODU_MD_Velocidad"));
            items.Add(ResolverItem("ODU_Q_BajaTension"));
            items.Add(ResolverItem("ODU_I_TermistorOK"));
            items.Add(ResolverItem("ODU_M_ModoCalor"));
            items.Add(ResolverItem("ODU_Q_ControlRemotoCalor"));
            items.Add(ResolverItem("ODU_Q_ControlRemotoFrioHigh"));
            items.Add(ResolverItem("ODU_Q_ControlRemotoFrioLow"));
            items.Add(ResolverItem("ODU_Q_ControlRemotoStop"));
            items.Add(ResolverItem("ODU_M_ReleAlimentacionPlacaTCTC"));
            
            items.Add(ResolverItem("ODU_M_ActuacionManualAlimenacionIDU"));
            items.Add(ResolverItem("ODU_M_ActuacionManualAlimenacionODU"));
            items.Add(ResolverItem("ODU_M_ActuacionManualModoCalor"));
            items.Add(ResolverItem("ODU_M_ActuacionManualBajaTension"));
            items.Add(ResolverItem("ODU_M_ModoManual"));
            
            items.Add(ResolverItem("ODU_ST_CopiaBitMantenimiento"));

            string[] arrayitems = items.ToArray();
            LeerItemsAsync(arrayitems);
        }

        public override string[] LeerEstadoInicialModos()
        {
            throw new NotImplementedException();
        }

        public override int EscribirParametros(ParametrosEnsayo parametros, bool EscribirVersion)
        {
           ParametrosEnsayoODU parodu= new ParametrosEnsayoODU();
           parodu = parametros as ParametrosEnsayoODU;

           List<string> items = new List<string>();
           
        
            items.Add(ResolverItem("ODU_SP_MaximaPresionAdmisibleInicio"));
            items.Add(ResolverItem("ODU_SP_MinimaDiferenciaPresionInicio"));
            items.Add(ResolverItem("ODU_SP_TimeoutBajaTension"));
            items.Add(ResolverItem("ODU_SP_TimeoutModoCalor"));
            items.Add(ResolverItem("ODU_SP_TimerRecuperacionRefrigerante"));
            items.Add(ResolverItem("ODU_SP_TimerEnsayoBajaTension"));
            items.Add(ResolverItem("ODU_SP_TimerEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_TimerEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_TimerEstabilizacionPresiones"));
            items.Add(ResolverItem("ODU_SP_TimeoutRecuperacion"));
            items.Add(ResolverItem("ODU_SP_TimeoutPresionInicial"));
            items.Add(ResolverItem("ODU_SP_MinimaCorrienteEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_MaximaCorrienteEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_MinimaDiferenciaTemperaturaCalor"));
            items.Add(ResolverItem("ODU_SP_MaximaDiferenciaTemperaturaCalor"));
            items.Add(ResolverItem("ODU_SP_MinimaDiferenciaPresionCompresor"));
            items.Add(ResolverItem("ODU_SP_MaximaDiferenciaPresionCompresor"));
            items.Add(ResolverItem("ODU_SP_MinimaVelocidadCompresor"));
            items.Add(ResolverItem("ODU_SP_MaximaDiferenciaPresionInicio"));
            items.Add(ResolverItem("ODU_SP_DelayAntesIndicFinalizado"));
            items.Add(ResolverItem("ODU_SP_MinimaPresionAdmisibleInicio"));
            items.Add(ResolverItem("ODU_SP_TiempoIDUOFFEntreFrioCalor"));
            items.Add(ResolverItem("ODU_SP_TimerDelayArranqueCompresor"));
            items.Add(ResolverItem("ODU_SP_TimerDelayCierreValvula1"));
            
            items.Add(ResolverItem("ODU_SP_MaximaPresionAdmisibleRecuperacionRefrigerante"));
            items.Add(ResolverItem("ODU_SP_MaximaPresionEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaCorrienteEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MaximaCorrienteEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MaximaDiferenciaTemperaturaEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaDiferenciaTemperaturaEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaPresionAdmisibleDesactivarValvula4Vias"));
            items.Add(ResolverItem("ODU_SP_MaximaVelocidadEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_MinimaVelocidadEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_MaximaPotenciaEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_MinimaPresionEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MaximaVelocidadEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaVelocidadEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MaximaPotenciaEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaPotenciaEnsayoFrio"));
            items.Add(ResolverItem("ODU_SP_MinimaPotenciaEnsayoCalor"));
            items.Add(ResolverItem("ODU_SP_TimerDelayCierreValvula2"));
            string[] arrayitems = items.ToArray();

            //object[]values;
            List<object> values = new List<object>();
            //values = new object[41];
            values.Add(parodu.PresionInicialMax);
            values.Add(parodu.DeltaPresionEstabilizacionMin);
            values.Add(parodu.TiempoMaximoBajaTension);
            values.Add(parodu.TiempoMaximoMedicionCalor);
            values.Add(parodu.TiempoRecuperacionMinima);
            values.Add(parodu.TiempoBajaTension);
            values.Add(parodu.TiempoMedicionFrio);
            values.Add(parodu.TiempoMedicionCalor);
            values.Add(parodu.TiempoInicialEstabilizacion);
            values.Add(parodu.TiempoMaximoRecuperacionMinima);
            values.Add(parodu.TiempoMaximoEstabilizacion);
            values.Add(parodu.CorrienteMinCalor);
            values.Add(parodu.CorrienteMaxCalor);
            values.Add(parodu.DeltaTempMinCalor);
            values.Add(parodu.DeltaTempMaxCalor);
            values.Add(parodu.DeltaPresionBajaTensionMin);
            values.Add(parodu.DeltaPresionBajaTensionMax); 
            values.Add(parodu.VelocidadBajaTensionMin);
            values.Add(parodu.DeltaPresionEstabilizacionMax);
            values.Add(parodu.TiempoFinal);
            values.Add(parodu.PresionInicialMin);
            values.Add(parodu.TiempoApagadoEntreCalorFrio);
            values.Add(parodu.DelayArranqueCompresor);
            values.Add(parodu.TiempoCierreValvula1);
           
            values.Add(parodu.PresionMaxRecuperacion);
            values.Add(parodu.PresionMaxFrio);
            values.Add(parodu.CorrienteMinFrio);
            values.Add(parodu.CorrienteMaxFrio);
            values.Add(parodu.DeltaTempMaxFrio);
            values.Add(parodu.DeltaTempMinFrio);
            values.Add(parodu.PresionMinApagadoCompresor);
            values.Add(parodu.VelocidadMaxVentiladorCalor);
            values.Add(parodu.VelocidadMinVentiladorCalor);
            values.Add(parodu.PotenciaMaxCalor);
            values.Add(parodu.PresionMinFrio);
            values.Add(parodu.VelocidadMaxVentiladorFrio);
            values.Add(parodu.VelocidadMinVentiladorFrio);
            values.Add(parodu.PotenciaMaxFrio);
            values.Add(parodu.PotenciaMinFrio);
            values.Add(parodu.PotenciaMinCalor);
            values.Add(parodu.TiempoCierreValvula2);
           

            object[] arrayvalues = values.ToArray();

           return  Escribir(arrayitems,arrayvalues);

       }
    }
}
