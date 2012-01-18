using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using System.Configuration;

namespace iDU.PLC
{
    public class PLCIDU : PLC
    {
        public PLCIDU() : base() { }


        public override ParametrosEnsayo LeerParametros()
        {
            ParametrosEnsayoIDU parametros = new ParametrosEnsayoIDU();
            List<string> items = new List<string>();

            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialFrio"));
            items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialCalor"));
            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_TiempoEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_TiempoEnsayoAltaVelocidad"));
            items.Add(ResolverItem("TiempoApagadoCalorFrio"));
            items.Add(ResolverItem("IDU_SP_RetardoComandoInicial4"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoComandoBajaTension"));
            items.Add(ResolverItem("IDU_SP_RetardoComandoInicialMitad"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoAvisoFinal"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoFinalizacionEnsayo"));
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_TimeoutEnsayoBajaTension"));

            //TODO: ver si va
            items.Add(ResolverItem("IDU_SP_CantidadDeEnsayosParteB"));
            items.Add(ResolverItem("IDU_SP_EtiquetaPendiente"));
            
			      items.Add(ResolverItem("IDU_VERSION"));
			
            int modoensayo = int.Parse(ConfigurationManager.AppSettings["ModoEnsayoIDU"]);
            if (modoensayo == 1)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = items[i] + "_2";

                }

            }
            
            string[] arrayitems  = items.ToArray();

            string[] arrayvaloresstr = null;
            arrayvaloresstr = LeerItems(arrayitems);
          
            int[] arrayvalores = new int[arrayvaloresstr.Length];

            for (int i = 0; i < arrayvalores.Length; i++)
                arrayvalores[i] = int.Parse(arrayvaloresstr[i]);

            parametros.IdVersion                = arrayvalores[25];
            parametros.TiempoMaximoBajaTension  = arrayvalores[22];
            parametros.Corrientebajatensionmax  = arrayvalores[21];   
            parametros.Corrientebajatensionmin  = arrayvalores[20];     
            parametros.Corrientemaxmodovelalta  = arrayvalores[19];      
            parametros.Corrientemaxmodovelbaja  = arrayvalores[18];    
            parametros.CorrienteMinModoVelAlta  = arrayvalores[17];     
            parametros.CorrienteMinModoVelBaja  = arrayvalores[16];     
            parametros.Final                    = arrayvalores[15];                      
            parametros.Retardodesenergizado     = arrayvalores[14];       
            parametros.Retardostarmitad         = arrayvalores[13];            
            parametros.Retardostart2bajatension = arrayvalores[12];    
            parametros.Retardostopinicial       = arrayvalores[11];         
            parametros.TiempoApagadoCalorFrio   = arrayvalores[10];       
            parametros.Tiempomodovelocidadalta  = arrayvalores[9];     
            parametros.Tiempomodovelocidadbaja  = arrayvalores[8];
            parametros.Velocidadminmodovelbaja  = arrayvalores[7];
            parametros.Timeoutcalor             = arrayvalores[6];                 
            parametros.Timeoutfrio              = arrayvalores[5];                  
            parametros.Velocidadbajatensionmax  = arrayvalores[4];      
            parametros.Velocidadbajatensionmin  = arrayvalores[3];     
            parametros.Velocidadmaxmodovelalta  = arrayvalores[2];      
            parametros.Velocidadmaxmodovelbaja  = arrayvalores[1];      
            parametros.Velocidadminmodovelalta  = arrayvalores[0];
            
            return parametros;
        }

        public override bool ProbarConexion()
        {
          /*  string item = ResolverItem("VelocidadTempIDU");
            
            int valor = 2;

            return ProbarConexion(item, valor);*/
            return true;
        }

        public override void ResetearEnsayo()
        {
            //throw new NotImplementedException();
        }

        public override void LeerEstadosPantallaPrincipalAsincronicamente()
        {
            List<string> items = new List<string>();
            int modoensayo = int.Parse(ConfigurationManager.AppSettings["ModoEnsayoIDU"]);

                        
            if (modoensayo == 0)
            {
              items.Add(ResolverItem("IDU_Q_EntradaEstadoValvula4Vias"));
                items.Add("IDU_SP_CopiaEstadoIDU");
                items.Add("IDU_ST_CopiaEstadoODU");
                items.Add("ModoCalorEstadoIDU");
                items.Add("IDU_Q_ReleSeleccionBajaTension");
                items.Add("IDU_MD_VelocidadCalculada");
                items.Add("IDU_MD_CorrienteMedida");
                items.Add("IDU_Q_EntradaEstadoElectroVentilador");
                items.Add("IDU_ST_EquipoEnsayadoOK");
                items.Add("IDU_ST_EnsayoEnCurso");
                items.Add("IDU_ST_EquipoEnsayadoFalla");
                items.Add("IDU_PLC");
                items.Add("IDU_ST_NumeroMaximoFichas");
                items.Add("IDU_SP_ModoSeleccionado");
                items.Add("IDU_ST_NumeroDeFalla");
                items.Add("IDU_M_InicioEnsayoPulsador");
                items.Add("IDU_M_InicioModoCalor");
                items.Add("IDU_M_InicioModoFrio");
                items.Add("IDU_M_EsperaMontajePanelFrontal");
                items.Add("IDU_M_EnsayoBajaTension");
                items.Add("IDU_M_EnsayoAltaVelocidad");
                items.Add("IDU_M_EnsayoBajaVelocidad");
                items.Add("IDU_M_CierreValvulaLiquido");
                items.Add("IDU_M_FinalizacionEnsayo");

                items.Add("IDU_SP_CantidadDeEnsayosParteB");
                items.Add("IDU_SP_EtiquetaPendiente");
                items.Add("IDU_ST_CopiaEstadoManual");
                items.Add("IDU_M_ModoMantenimiento");
                items.Add("IDU_I_PulsadorStop");
            }


            if (modoensayo == 1)
            {

                items.Add("IDU_SP_CopiaEstadoIDU_2");
                items.Add("IDU_ST_CopiaEstadoODU_2");
                items.Add("ModoCalorEstadoIDU_2");
                items.Add("IDU_Q_ReleSeleccionBajaTension_2");
                items.Add("IDU_MD_VelocidadCalculada_2");
                items.Add("IDU_MD_CorrienteMedida_2");
                items.Add("IDU_Q_EntradaEstadoElectroVentilador_2");
                items.Add("IDU_ST_EquipoEnsayadoOK_2");
                items.Add("IDU_ST_EnsayoEnCurso_2");
                items.Add("IDU_ST_EquipoEnsayadoFalla_2");
                items.Add("IDU_PLC_2");
                items.Add("IDU_ST_NumeroMaximoFichas_2");
                items.Add("IDU_SP_ModoSeleccionado_2");
                items.Add("IDU_ST_NumeroDeFalla_2");
                items.Add("IDU_M_InicioEnsayoPulsador_2");
                items.Add("IDU_M_InicioModoCalor_2");
                items.Add("IDU_M_InicioModoFrio_2");
                items.Add("IDU_M_EsperaMontajePanelFrontal_2");
                items.Add("IDU_M_EnsayoBajaTension_2");
                items.Add("IDU_M_EnsayoAltaVelocidad_2");
                items.Add("IDU_M_EnsayoBajaVelocidad_2");
                items.Add("IDU_M_CierreValvulaLiquido_2");
                items.Add("IDU_M_FinalizacionEnsayo_2");
                items.Add("IDU_SP_CantidadDeEnsayosParteB_2");
                items.Add("IDU_SP_EtiquetaPendiente_2");
                items.Add("IDU_ST_CopiaEstadoManual_2");
                items.Add("IDU_M_ModoMantenimiento_2");
            }

            if(modoensayo == 2 || modoensayo == 3)
            {
                items.Add("IDU_SP_CopiaEstadoIDU");
                items.Add("IDU_ST_CopiaEstadoODU");
                items.Add("ModoCalorEstadoIDU");
                items.Add("IDU_Q_ReleSeleccionBajaTension");
                items.Add("IDU_MD_VelocidadCalculada");
                items.Add("IDU_MD_CorrienteMedida");
                items.Add("IDU_Q_EntradaEstadoElectroVentilador");
                items.Add("IDU_ST_EquipoEnsayadoOK");
                items.Add("IDU_ST_EnsayoEnCurso");
                items.Add("IDU_ST_EquipoEnsayadoFalla");
                items.Add("IDU_PLC");
                items.Add("IDU_ST_NumeroMaximoFichas");
                items.Add("IDU_SP_ModoSeleccionado");
                items.Add("IDU_ST_NumeroDeFalla");
                items.Add("IDU_M_InicioEnsayoPulsador");
                items.Add("IDU_M_InicioModoCalor");
                items.Add("IDU_M_InicioModoFrio");
                items.Add("IDU_M_EsperaMontajePanelFrontal");
                items.Add("IDU_M_EnsayoAltaVelocidad");
                items.Add("IDU_M_EnsayoBajaTension");
                items.Add("IDU_M_EnsayoBajaVelocidad");
                items.Add("IDU_M_CierreValvulaLiquido");
                items.Add("IDU_M_FinalizacionEnsayo");

                items.Add("IDU_SP_CantidadDeEnsayosParteB");
                items.Add("IDU_SP_EtiquetaPendiente");
                items.Add("IDU_ST_CopiaEstadoManual");
                items.Add("IDU_M_ModoMantenimiento");

                items.Add("IDU_SP_CopiaEstadoIDU_2");
                items.Add("IDU_ST_CopiaEstadoODU_2");
                items.Add("ModoCalorEstadoIDU_2");
                items.Add("IDU_Q_ReleSeleccionBajaTension_2");
                items.Add("IDU_MD_VelocidadCalculada_2");
                items.Add("IDU_MD_CorrienteMedida_2");
                items.Add("IDU_Q_EntradaEstadoElectroVentilador_2");
                items.Add("IDU_ST_EquipoEnsayadoOK_2");
                items.Add("IDU_ST_EnsayoEnCurso_2");
                items.Add("IDU_ST_EquipoEnsayadoFalla_2");
                items.Add("IDU_PLC_2");
                items.Add("IDU_ST_NumeroMaximoFichas_2");
                items.Add("IDU_SP_ModoSeleccionado_2");
                items.Add("IDU_ST_NumeroDeFalla_2");
                items.Add("IDU_M_InicioEnsayoPulsador_2");
                items.Add("IDU_M_InicioModoCalor_2");
                items.Add("IDU_M_InicioModoFrio_2");
                items.Add("IDU_M_EnsayoBajaTension_2");
                items.Add("IDU_M_EsperaMontajePanelFrontal_2");
                items.Add("IDU_M_EnsayoAltaVelocidad_2");
                items.Add("IDU_M_EnsayoBajaVelocidad_2");
                items.Add("IDU_M_CierreValvulaLiquido_2");
                items.Add("IDU_M_FinalizacionEnsayo_2");

                items.Add("IDU_SP_CantidadDeEnsayosParteB_2");
                items.Add("IDU_SP_EtiquetaPendiente_2");
                items.Add("IDU_ST_CopiaEstadoManual_2");
                items.Add("IDU_M_ModoMantenimiento_2");
            }
            
            tagsAsync = items.ToArray();

            LeerItemsAsync(tagsAsync);
            return;
        }

        public override string[] LeerEstadoInicialModos()
        {
            //throw new NotImplementedException();
            return null;
        }

        public override Ensayos LeerValoresEnsayo()
        {
            EnsayosIDU ensayo = new EnsayosIDU();
            List<string> items = new List<string>();

            items.Add(ResolverItem("HipotEnsayoIDU"));    
            items.Add(ResolverItem("FugaEnsayoIDU")); 
            //items.Add(ResolverItem("TiempoEnsayoIDU")); 
            items.Add(ResolverItem("IDU_VelocidadInicialEnsayo")); 
            items.Add(ResolverItem("IDU_E_VelocidadBajaTension")); 
            items.Add(ResolverItem("IDU_E_VelocidadLow")); 
            items.Add(ResolverItem("IDU_E_VelocidadHigh")); 
            items.Add(ResolverItem("IDU_E_CorrienteBajaTension")); 
            items.Add(ResolverItem("IDU_E_CorrienteLow")); 
            items.Add(ResolverItem("IDU_E_CorrienteHigh"));
            items.Add(ResolverItem("IDU_E_CorrienteInicialModoFrio"));
            items.Add(ResolverItem("IDU_E_CorrienteInicialModoCalor"));
            items.Add(ResolverItem("IDU_ST_NumeroDeFalla"));
        //    items.Add(ResolverItem("IDU_ST_EquipoEnsayadoOK")); 


            int modoensayo = int.Parse(ConfigurationManager.AppSettings["ModoEnsayoIDU"]);
            if (modoensayo == 1 || modoensayo == 2)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = items[i] + "_2";

                }

            }
            
            string[] arrayitems = items.ToArray();

            string[] arrayvaloresstr = null;
            arrayvaloresstr = LeerItems(arrayitems);

            int[] arrayvalores = new int[arrayvaloresstr.Length];

            for (int i = 0; i < arrayvalores.Length; i++)
                arrayvalores[i] = int.Parse(arrayvaloresstr[i]);


            ensayo.Hipot = arrayvalores[0].ToString();
            ensayo.Fuga = arrayvalores[1].ToString();
           // ensayo.TiempoEnsayo = arrayvalores[2];
            ensayo.VelocidadInicial = arrayvalores[2];
            ensayo.VelocidadBajaTension = arrayvalores[3];
            ensayo.VelocidadLow = arrayvalores[4];
            ensayo.VelocidadHigh = arrayvalores[5];
            ensayo.CorrienteBajaTension = arrayvalores[6];
            ensayo.CorrienteLow = arrayvalores[7];
            ensayo.CorrienteHIGH = arrayvalores[8];
            ensayo.CorrienteInicial = arrayvalores[9];
            ensayo.CorrienteCalorInicial = arrayvalores[10];
            ensayo.Codigo = arrayvalores[11].ToString(); 
       
            

            return ensayo;
        }

        public override void EscribirItemMonitoreo(string item, int valor)
        {
            string mItem = ResolverItem(item);
            int modoensayo =int.Parse( ConfigurationManager.AppSettings["ModoEnsayoIDU"]);

            if (modoensayo == 1 || modoensayo == 3)
                mItem = mItem + "_2";
            
            Escribir(mItem, valor);
        }

        public override /*override string[]*/ void LeerMonitoreo()
        {
            List<string> items = new List<string>();

            items.Add(ResolverItem("IDU_MD_CorrienteMedida"));
            items.Add(ResolverItem("IDU_MD_VelocidadCalculada"));
            items.Add(ResolverItem("IDU_Q_EntradaEstadoCompresor"));
            items.Add(ResolverItem("IDU_Q_EntradaEstadoValvula4Vias"));
			items.Add(ResolverItem("IDU_Q_EntradaEstadoElectroVentilador"));
            items.Add(ResolverItem("IDU_M_ActuacionManualBajaTension"));
            items.Add(ResolverItem("IDU_M_ModoMantenimiento"));
            items.Add(ResolverItem("ControlRemotoMonitoreoIDU"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto1"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto2"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto3"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto4"));
            items.Add(ResolverItem("TCTCIDU"));
            items.Add(ResolverItem("IDU_ST_CopiaEstadoManual"));
            items.Add(ResolverItem("IDU_M_ActuacionManualAlimentacionIDU"));
            items.Add(ResolverItem("ModoCalorEstadoIDU"));
            items.Add(ResolverItem("IDU_ST_CopiaEstadoODU"));


            int modoensayo = int.Parse(ConfigurationManager.AppSettings["ModoEnsayoIDU"]);
            if (modoensayo == 1 || modoensayo == 3)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = items[i] + "_2";

                }

            }


            string[] arrayitems = items.ToArray();
       
            LeerItemsAsync(arrayitems);


        }

        /// <summary>
        /// 1=PLC_1
        /// 2=PLC_2
        /// 3=PLC_1 y PLC_2
        /// </summary>
        /// <param name="iNumeroPLC"></param>
        public void LeerMonitoreoPorPLC(int iNumeroPLC)
        {
            List<string> items = new List<string>();

            items.Add(ResolverItem("IDU_MD_CorrienteMedida"));
            items.Add(ResolverItem("IDU_MD_VelocidadCalculada"));
            items.Add(ResolverItem("IDU_Q_EntradaEstadoCompresor"));
            items.Add(ResolverItem("IDU_Q_EntradaEstadoValvula4Vias"));
            items.Add(ResolverItem("IDU_Q_EntradaEstadoElectroVentilador"));
            items.Add(ResolverItem("IDU_M_ActuacionManualBajaTension"));
            items.Add(ResolverItem("IDU_M_ModoMantenimiento"));
            items.Add(ResolverItem("ControlRemotoMonitoreoIDU"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto1"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto2"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto3"));
            items.Add(ResolverItem("IDU_Q_ComandoRemoto4"));
            items.Add(ResolverItem("TCTCIDU"));
            items.Add(ResolverItem("IDU_ST_CopiaEstadoManual"));
            items.Add(ResolverItem("IDU_M_ActuacionManualAlimentacionIDU"));
            items.Add(ResolverItem("ModoCalorEstadoIDU"));
            items.Add(ResolverItem("IDU_ST_CopiaEstadoODU"));


            if (iNumeroPLC==2)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = items[i] + "_2";

                }

            }
            else
                if (iNumeroPLC == 3)
                {
                    int iCount = items.Count;
                    for (int i = 0; i < iCount; i++)
                    {
                        items.Add(items[i] + "_2");
                    }
                }

            string[] arrayitems = items.ToArray();

            LeerItemsAsync(arrayitems);
        }

        public override int EscribirParametros(ParametrosEnsayo parametros, bool EscribirVersion)
        {
            ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();
            paridu = parametros as ParametrosEnsayoIDU;
            List<string> items = new List<string>();

     
            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoAltaVelocidad"));
            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialFrio"));
            items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialCalor"));
            items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_TiempoEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_TiempoEnsayoAltaVelocidad"));
            items.Add(ResolverItem("TiempoApagadoCalorFrio"));
            items.Add(ResolverItem("IDU_SP_RetardoComandoInicial4"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoComandoBajaTension"));
            items.Add(ResolverItem("IDU_SP_RetardoComandoInicialMitad"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoAvisoFinal"));
            items.Add(ResolverItem("IDU_SP_TiempoRetardoFinalizacionEnsayo"));
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoAltaVelocidad")); 
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaVelocidad"));  
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoAltaVelocidad")); 
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaTension"));
            items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaVelocidad"));
            items.Add(ResolverItem("IDU_SP_TimeoutEnsayoBajaTension"));

            if (EscribirVersion)
              items.Add(ResolverItem("IDU_VERSION"));

            string []arrayitems=items.ToArray();
            List<object> values = new List<object>();

            
            
          
          values.Add(paridu.Velocidadminmodovelalta);
            values.Add(paridu.Velocidadmaxmodovelbaja);
            values.Add(paridu.Velocidadmaxmodovelalta);
            values.Add(paridu.Velocidadbajatensionmin);
            values.Add(paridu.Velocidadbajatensionmax);
            values.Add(paridu.Timeoutfrio);
            values.Add(paridu.Timeoutcalor);
            values.Add(paridu.Velocidadminmodovelbaja);
            values.Add(paridu.Tiempomodovelocidadbaja);
            values.Add(paridu.Tiempomodovelocidadalta);
            values.Add(paridu.TiempoApagadoCalorFrio);
            values.Add(paridu.Retardostopinicial);
            values.Add(paridu.Retardostart2bajatension);
            values.Add(paridu.Retardostarmitad);
            values.Add(paridu.Retardodesenergizado);
            values.Add(paridu.Final);
            values.Add(paridu.CorrienteMinModoVelAlta);
            values.Add(paridu.Corrientemaxmodovelbaja);
            values.Add(paridu.Corrientemaxmodovelalta);
            values.Add(paridu.Corrientebajatensionmin);
            values.Add(paridu.Corrientebajatensionmax);
            values.Add(paridu.CorrienteMinModoVelBaja);
            values.Add(paridu.TiempoMaximoBajaTension);
            if (EscribirVersion) 
              values.Add(paridu.IdVersion);

            object[] arrayvalores = values.ToArray();


           return  Escribir(arrayitems, arrayvalores);
        }

        public int GetParametrosAEscribir(ParametrosEnsayo parametros
          ,out List<string> tagnamesList
          ,out List<object> valuesList)
        {
          ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();
          paridu = parametros as ParametrosEnsayoIDU;
          List<string> items = new List<string>();

          
          
          items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoAltaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoAltaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaTension"));
          items.Add(ResolverItem("IDU_SP_MaximaVelocidadAdmisibleEnsayoBajaTension"));
          items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialFrio"));
          items.Add(ResolverItem("IDU_SP_TimeoutArranqueInicialCalor"));
          items.Add(ResolverItem("IDU_SP_MinimaVelocidadAdmisibleEnsayoBajaVelocidad"));
          items.Add(ResolverItem("IDU_SP_TiempoEnsayoBajaVelocidad"));
          items.Add(ResolverItem("IDU_SP_TiempoEnsayoAltaVelocidad"));
          items.Add(ResolverItem("TiempoApagadoCalorFrio"));
          items.Add(ResolverItem("IDU_SP_RetardoComandoInicial4"));
          items.Add(ResolverItem("IDU_SP_TiempoRetardoComandoBajaTension"));
          items.Add(ResolverItem("IDU_SP_RetardoComandoInicialMitad"));
          items.Add(ResolverItem("IDU_SP_TiempoRetardoAvisoFinal"));
          items.Add(ResolverItem("IDU_SP_TiempoRetardoFinalizacionEnsayo"));
          items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoAltaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoAltaVelocidad"));
          items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaTension"));
          items.Add(ResolverItem("IDU_SP_MaximaCorrienteAdmisibleEnsayoBajaTension"));
          items.Add(ResolverItem("IDU_SP_MinimaCorrienteAdmisibleEnsayoBajaVelocidad"));
          items.Add(ResolverItem("IDU_SP_TimeoutEnsayoBajaTension"));

          List<object> values = new List<object>();


          
          
          
          values.Add(paridu.Velocidadminmodovelalta);
          values.Add(paridu.Velocidadmaxmodovelbaja);
          values.Add(paridu.Velocidadmaxmodovelalta);
          values.Add(paridu.Velocidadbajatensionmin);
          values.Add(paridu.Velocidadbajatensionmax);
          values.Add(paridu.Timeoutfrio);
          values.Add(paridu.Timeoutcalor);
          values.Add(paridu.Velocidadminmodovelbaja);
          values.Add(paridu.Tiempomodovelocidadbaja);
          values.Add(paridu.Tiempomodovelocidadalta);
          values.Add(paridu.TiempoApagadoCalorFrio);
          values.Add(paridu.Retardostopinicial);
          values.Add(paridu.Retardostart2bajatension);
          values.Add(paridu.Retardostarmitad);
          values.Add(paridu.Retardodesenergizado);
          values.Add(paridu.Final);
          values.Add(paridu.CorrienteMinModoVelAlta);
          values.Add(paridu.Corrientemaxmodovelbaja);
          values.Add(paridu.Corrientemaxmodovelalta);
          values.Add(paridu.Corrientebajatensionmin);
          values.Add(paridu.Corrientebajatensionmax);
          values.Add(paridu.CorrienteMinModoVelBaja);
          values.Add(paridu.TiempoMaximoBajaTension);


          tagnamesList = items;
          valuesList = values;

          return values.Count;
        }

    }
}
