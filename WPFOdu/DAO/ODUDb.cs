using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using WPFiDU.CommonObjects;

namespace iDU.DAO
{
    class ODUDb : BaseDAO
    {
        public override List<Ensayos> ObtenerEnsayos()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> listaensayosodu = new List<Ensayos>();

                string sql = "CALL usp_ObtenerEnsayosoODU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                EnsayosODU nuevoensayo = new EnsayosODU();

                while (reader.Read())
                {
                    if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                    {
                        nuevoensayo.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayo.Aprobado = false;
                    }

                    nuevoensayo.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
                    nuevoensayo.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
                    nuevoensayo.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
                    nuevoensayo.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
                    nuevoensayo.DCF = reader.GetString("ensayosrealizadosodu_dcf");
                    nuevoensayo.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
                    nuevoensayo.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
                    nuevoensayo.Fuga = reader.GetString("ensayosrealizadosodu_fuga"); ;
                    nuevoensayo.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
                    nuevoensayo.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
                    nuevoensayo.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
                    nuevoensayo.ID = reader.GetInt32("ensayosrealizadosodu_id");
                    nuevoensayo.Marca = reader.GetString("ensayosrealizadosodu_marca");
                    nuevoensayo.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
                    nuevoensayo.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
                    nuevoensayo.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
                    nuevoensayo.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
                    nuevoensayo.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
                    nuevoensayo.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
                    nuevoensayo.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
                    nuevoensayo.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
                    nuevoensayo.Serie = reader.GetString("ensayosrealizadosodu_serie");
                    nuevoensayo.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambiente");
                    nuevoensayo.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayo.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
                    nuevoensayo.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
                    nuevoensayo.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
                    nuevoensayo.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
                    nuevoensayo.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
                    nuevoensayo.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
                    nuevoensayo.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
                    nuevoensayo.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
                    nuevoensayo.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
                    nuevoensayo.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
                    nuevoensayo.Usuario = reader.GetString("ensayosrealizadosodu_usuario");
                    listaensayosodu.Add(nuevoensayo);
                }

                reader.Close();
                return listaensayosodu;
            }


        }

        public override string ObtenerDescripcionFalla(Ensayos e)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                string sql = "CALL usp_ObtenerDescripcionFallaODU(" + e.Codigo.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                string descripcionfalla = (string)cmd.ExecuteScalar();
                
                if(descripcionfalla == null || descripcionfalla.Equals(string.Empty))
                    return "Falla desconocida";
                else
                return descripcionfalla;
            }
        }

        public override bool ObtenerPrioridadFalla(int codigo)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ObtenerPrioridadFallaODU(" + codigo.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                bool prioridadfalla = false;
                if (cmd.ExecuteScalar() != null)
                    prioridadfalla = (bool)cmd.ExecuteScalar();

                return prioridadfalla;

            }
        }

        public override Ensayos ObtenerUltimoEnsayo()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ObtenerUltimoEnsayoODU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                EnsayosODU nuevoensayo = new EnsayosODU();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    if (reader.GetInt32("ensayosrealizadosodu_aprobado") == 1)
                    {

                        nuevoensayo.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayo.Aprobado = false;
                    }


                    nuevoensayo.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
                    nuevoensayo.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
                    nuevoensayo.Corrienteh = reader.GetFloat("ensayosrealizadosodu_corrientealta");
                    nuevoensayo.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
                    nuevoensayo.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
                    nuevoensayo.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
                    nuevoensayo.Cosfc = reader.GetFloat("ensayosrealizadosodu_factordepotenciacalor");
                    nuevoensayo.DCF = reader.GetString("ensayosrealizadosodu_dcf");
                    nuevoensayo.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
                    nuevoensayo.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
                    nuevoensayo.Fuga = reader.GetString("ensayosrealizadosodu_fuga"); ;
                    nuevoensayo.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
                    nuevoensayo.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
                    nuevoensayo.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
                    nuevoensayo.ID = reader.GetInt32("ensayosrealizadosodu_id");
                    nuevoensayo.Marca = reader.GetString("ensayosrealizadosodu_marca");
                    nuevoensayo.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
                    nuevoensayo.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
                    nuevoensayo.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
                    nuevoensayo.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
                    nuevoensayo.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
                    nuevoensayo.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
                    nuevoensayo.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
                    nuevoensayo.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
                    nuevoensayo.Serie = reader.GetString("ensayosrealizadosodu_serie");
                    nuevoensayo.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambiente");
                    nuevoensayo.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayo.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
                    nuevoensayo.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
                    nuevoensayo.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
                    nuevoensayo.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
                    nuevoensayo.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
                    nuevoensayo.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
                    nuevoensayo.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
                    nuevoensayo.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
                    nuevoensayo.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
                    nuevoensayo.Modelo = reader.GetString("ensayosrealizadosodu_modelo");
                    nuevoensayo.Usuario = reader.GetString("ensayosrealizadosodu_usuario");
                    
                }

                reader.Close();
                return nuevoensayo;



            }


        }
 
        public override WPFiDU.CommonObjects.NumeroDeSerie ObtenerConfiguracionNumeroDeSerie(int aprobado)
        {
           
        

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                string sql = "CALL usp_ObtenerConfiguracionNumeroDeSerie(" + aprobado.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                WPFiDU.CommonObjects.NumeroDeSerie ns = new WPFiDU.CommonObjects.NumeroDeSerie();
                MySqlDataReader reader= cmd.ExecuteReader();
                


                while (reader.Read())
                {
                    ns.ID =reader.GetInt32("serie_id") ;
                    ns.Maximo=reader.GetInt32("serie_maximo");
                    ns.Minimo=reader.GetInt32("serie_minimo");
                    ns.Numero=reader.GetInt32("serie_numero");
                    ns.Prefijo=reader.GetString("serie_prefijo");
                    ns.Sufijo=reader.GetInt32("serie_sufijo");
                    ns.Tipo=reader.GetChar("serie_tipo");


                }
                reader.Close();

                return ns;
                

            }

        
        }

        public override List<Etiqueta> ObtenerEtiquetas()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 0;
                List<Etiqueta> nuevalista = new List<Etiqueta>();
                string sql = "CALL usp_ListarEtiquetas(" + esidu.ToString() + ")";
                //string sql = "CALL usp_ListarEtiquetas(1)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Etiqueta etiqueta = new Etiqueta();
                    etiqueta.Id = reader.GetInt32(0);
                    etiqueta.Nombre = reader.GetString(1);
                    etiqueta.EsBulto = reader.GetInt32("es_bulto")==1;
                    nuevalista.Add(etiqueta);
                }

                reader.Close();
                return nuevalista;
            }
        }

        public override Etiqueta ObtenerEtiqueta(int IDEtiqueta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ObtenerEtiqueta(" + IDEtiqueta + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Etiqueta e = new Etiqueta();

                while (reader.Read())
                {
                    e.Id = reader.GetInt32("etiquetas_id");
                    e.Nombre = reader.GetString("etiquetas_nombre");
                    e.EsBulto = reader.GetInt32("es_bulto") == 1;
                }
                reader.Close();
                return e;
            }
        }


        public override void ModificarNumeroDeSerie(NumeroDeSerie ns, int aprobado)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ModificarNumeroDeSerie(" +
                    ns.Minimo.ToString() + "," +
                    ns.Maximo.ToString() + "," +
                    ns.Sufijo.ToString() + ",'" +
                    ns.Prefijo.ToString() + "'," + aprobado.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }

        }

        public override List<Ensayos> ObtenerEnsayosReimpresiones()
        {
            return base.ObtenerEnsayosReimpresiones(false);
        }

        public override void GuardarEtiqueta(Etiqueta nuevaetiqueta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                //MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int esidu = 0;
                    string sql1 = "CALL usp_AgregarEtiqueta('" + nuevaetiqueta.Nombre + "'," + esidu.ToString() + ")";
                    //MySqlCommand cmd = new MySqlCommand(sql1, conn, trans);
                    MySqlCommand cmd = new MySqlCommand(sql1, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int ultimoid = reader.GetInt32(0)  ;
                    reader.Close();
                    //int ultimoid = (int)cmd.ExecuteScalar();

                    for (int i = 0; i < nuevaetiqueta.Componentes.Count; i++)
                    {
                        string sql2 = "CALL usp_AgregarComponenteEtiqueta('";
                        sql2 = sql2 + nuevaetiqueta.Componentes[i].Font + "'," +
                            nuevaetiqueta.Componentes[i].Size.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Bold.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Italic.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Yinicial.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Xinicial.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Yfinal.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Variable.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Tipo.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Alignh.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Alignv.ToString() + "," +
                            nuevaetiqueta.Componentes[i].Xfinal.ToString() + "," +
                            "'" + nuevaetiqueta.Componentes[i].Param.ToString() + "'," +
                            ultimoid.ToString() + ")";
                        //MySqlCommand cmd2 = new MySqlCommand(sql2, conn, trans);
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                    }

                    //trans.Commit();
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    throw ex;
                }
                finally
                {
                    //TODO: que hacemos?
                }
            }
        }

        public override void AgregarEnsayoReimpresiones(Ensayos ens)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 0;
           
                int aprobado = -1;

                if (ens.Aprobado == true)
                    aprobado = 1;
                else
                    aprobado = 0;
                string sql = "CALL usp_AgregarEnsayoReimpresiones('" + ens.Marca + "','" +
                    ens.Modelo + "','" + ens.Codigo + "','" + ens.Serie + "','" + BaseDAO.getDateTime(ens.Fecha) + "'," +
                    aprobado.ToString() + ",'" + ens.Observaciones + "'," + esidu.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
        }

        public override ParametrosEnsayo LeerParametrosDeBaseDeDatosPorId(int identificacion)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                ParametrosEnsayoODU parodu = new ParametrosEnsayoODU();

                string sql = "CALL usp_ObtenerParametrosEnsayoODUporID(" + identificacion.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    parodu.CorrienteMaxCalor = reader.GetInt32("parametrosensayosodu_corrientemaxcalor");
                    parodu.CorrienteMaxFrio = reader.GetInt32("parametrosensayosodu_corrientemaxfrio");
                    parodu.CorrienteMinCalor = reader.GetInt32("parametrosensayosodu_corrientemincalor");
                    parodu.CorrienteMinFrio = reader.GetInt32("parametrosensayosodu_corrienteminfrio");
                    parodu.DCFs = reader.GetInt32("parametrosensayosodu_dcfs");
                    parodu.DelayArranqueCompresor = reader.GetInt32("parametrosensayosodu_delayarranquecompresor");
                    parodu.DeltaPresionBajaTensionMax = reader.GetInt32("parametrosensayosodu_deltapresionbajatensionmax");
                    parodu.DeltaPresionBajaTensionMin = reader.GetInt32("parametrosensayosodu_deltapresionbajatensionmin");
                    parodu.DeltaPresionEstabilizacionMax = reader.GetInt32("parametrosensayosodu_deltapresionestabilizacionmax");
                    parodu.DeltaPresionEstabilizacionMin = reader.GetInt32("parametrosensayosodu_deltapresionestabilizacionmin");
                    parodu.DeltaTempMaxCalor = reader.GetInt32("parametrosensayosodu_deltatempmaxcalor");
                    parodu.DeltaTempMaxFrio = reader.GetInt32("parametrosensayosodu_deltatempmaxfrio");
                    parodu.DeltaTempMinCalor = reader.GetInt32("parametrosensayosodu_deltatempmincalor");
                    parodu.DeltaTempMinFrio = reader.GetInt32("parametrosensayosodu_deltatempminfrio");
                    parodu.Descripcion = reader.GetString("parametrosensayosodu_descripcion");
                    parodu.TiempoApagadoEntreCalorFrio = reader.GetInt32("parametrosensayosodu_tiempoapagadoentrecaloryfrio");
                    parodu.ID = reader.GetInt32("parametrosensayosodu_id");
                    parodu.Modificado = reader.GetDateTime("parametrosensayosodu_modificado");
                    parodu.PotenciaMaxCalor = reader.GetInt32("parametrosensayosodu_potenciamaxcalor");
                    parodu.PotenciaMaxFrio = reader.GetInt32("parametrosensayosodu_potenciamaxfrio");
                    parodu.PotenciaMinCalor = reader.GetInt32("parametrosensayosodu_potenciamincalor");
                    parodu.PotenciaMinFrio = reader.GetInt32("parametrosensayosodu_potenciaminfrio");
                    parodu.PresionInicialMax = reader.GetInt32("parametrosensayosodu_presioninicialmax");
                    parodu.PresionInicialMin = reader.GetInt32("parametrosensayosodu_presioninicialmin");
                    parodu.PresionMaxFrio = reader.GetInt32("parametrosensayosodu_presionmaxfrio");
                    parodu.PresionMaxRecuperacion = reader.GetInt32("parametrosensayosodu_presionmaxrecuperacion");
                    parodu.PresionMinApagadoCompresor = reader.GetInt32("parametrosensayosodu_presionminapagadocompresor");
                    parodu.PresionMinFrio = reader.GetInt32("parametrosensayosodu_presionminfrio");
                    parodu.Referencia = reader.GetString("parametrosensayosodu_ref");
                    parodu.TiempoBajaTension = reader.GetInt32("parametrosensayosodu_tiempobajatension");
                    parodu.TiempoCierreValvula1 = reader.GetInt32("parametrosensayosodu_tiempocierrevalvula1");
                    parodu.TiempoCierreValvula2 = reader.GetInt32("parametrosensayosodu_tiempocierrevalvula2");
                    parodu.TiempoFinal = reader.GetInt32("parametrosensayosodu_tiempofinal");
                    parodu.TiempoInicialEstabilizacion = reader.GetInt32("parametrosensayosodu_tiempoinicialestabilizacion");
                    parodu.TiempoMaximoEstabilizacion = reader.GetInt32("parametrosensayosodu_tiempomaximoestabilizacion");
                    parodu.TiempoMaximoMedicionCalor = reader.GetInt32("parametrosensayosodu_tiempomaximomedicioncalor");
                    parodu.TiempoMaximoRecuperacionMinima = reader.GetInt32("parametrosensayosodu_tiempomaximorecuperacionminima");
                    parodu.TiempoMedicionCalor = reader.GetInt32("parametrosensayosodu_tiempomedicioncalor");
                    parodu.TiempoMedicionFrio = reader.GetInt32("parametrosensayosodu_tiempomedicionfrio");
                    parodu.TiempoRecuperacionMinima = reader.GetInt32("parametrosensayosodu_tiemporecuperacionminima");
                    parodu.VelocidadBajaTensionMin = reader.GetInt32("parametrosensayosodu_velocidadminbajatension");
                    parodu.VelocidadMaxVentiladorCalor = reader.GetInt32("parametrosensayosodu_velocidadmaxventiladorcalor");
                    parodu.VelocidadMaxVentiladorFrio = reader.GetInt32("parametrosensayosodu_velocidadmaxventiladorfrio");
                    parodu.VelocidadMinVentiladorCalor = reader.GetInt32("parametrosensayosodu_velocidadminventiladorcalor");
                    parodu.VelocidadMinVentiladorFrio = reader.GetInt32("parametrosensayosodu_velocidadminventiladorfrio");
                    parodu.TiempoMaximoBajaTension = reader.GetInt32("parametrosensayosodu_tiempomaximobajatension");
                    parodu.IdVersion = reader.GetInt32("parametrosensayosodu_idversion");


                }

                reader.Close();
                return parodu;

            }
        }

        public override void AgregarEnsayo(Ensayos e)
        {
            throw new NotImplementedException();
        }

        //public override void AgregarEnsayo(Ensayos e)
        //{
            
        //    EnsayosODU eodu = e as EnsayosODU;
        //    eodu.Fuga = "OK";
        //    eodu.Hipot = "OK";
        //    eodu.Vacio = "OK";
        //    eodu.Observaciones = "ninguna";
        //    eodu.DCF = "1";

        //    //init trans
        //    //ObtenerCaracteristicasTecnicas nro serie llamada al sp
        //    //guardar llamada al sp
        //    //commit rollback


        //    int aprobado = -1;

        //    if (eodu.Aprobado == true)
        //        aprobado = 1;
        //    else
        //        aprobado = 0;
        //    using (MySqlConnection conn = ConectarBaseDeDatos())
        //    {
               
        //        string sql = "CALL usp_AgregarEnsayoODU('" + eodu.Marca + "','" +
        //            eodu.Modelo + "','" + eodu.Codigo + "','" + eodu.Serie + "','" +
        //            BaseDAO.getDateTime(eodu.Fecha) + "'," + aprobado.ToString() + ",'" +
        //            eodu.DCF.ToString() + "'," + eodu.Temph.ToString() + ","
        //            + eodu.Tamb.ToString() + "," + eodu.Humedad.ToString() + "," +
        //            eodu.Tensionh.ToString() + "," + eodu.Tensionl.ToString() + "," +
        //            eodu.Corrienteh.ToString() + "," + eodu.Corrientel.ToString() + "," +
        //            eodu.Potenciah.ToString() + "," + eodu.Cosf.ToString() + "," +
        //            eodu.Velocidadh.ToString() + "," +
        //            eodu.Velocidadl.ToString() + "," +
        //            eodu.Presion1.ToString() + "," +
        //            eodu.Presion2.ToString() + "," +
        //            eodu.Presion3.ToString() + "," +
        //            eodu.Presion4.ToString() + "," +
        //            eodu.Flags.ToString()+","+
        //            eodu.Tensionhc.ToString()+","+
        //            eodu.Corrientehc.ToString()+","+
        //            eodu.Cosfc.ToString()+","+
        //            eodu.Potenciahc.ToString() + "," +
        //            eodu.Velocidadhc.ToString() + "," +
        //            eodu.Temphc.ToString() + "," +
        //            eodu.Tambc.ToString() + "," +
        //            eodu.Humedadc.ToString() + "," +
        //            eodu.Presionc.ToString() + ",'" +
        //            eodu.Vacio + "','" + eodu.Hipot + "','" +
        //            eodu.Fuga + "','" + eodu.Observaciones + "'," +
        //            eodu.Tiempoensayo + ")";




        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public override void ObtenerNroSerieAgregarEnsayo(Ensayos e, string argScannedSerialNumber)
        {
            EnsayosODU eodu = e as EnsayosODU;
            eodu.Fuga = "OK";
            eodu.Hipot = "OK";
            eodu.Vacio = "OK";
            eodu.Observaciones = "ninguna";
            //eodu.DCF = "PCTDF007"; // HACK UNHACK System.Environment.MachineName;
            eodu.DCF = System.Environment.MachineName;

            int aprobado = 0;

            if (eodu.Aprobado == true)
                aprobado = 1;
                 
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sql = "CALL usp_ObtenerNumeroSerieAprobado(" + aprobado.ToString() + ")";
                    sql = "CALL usp_GetSerialNumber()";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    string numserie = argScannedSerialNumber;
                    if (string.IsNullOrEmpty(argScannedSerialNumber))
                    {
                      MySqlDataReader reader = cmd.ExecuteReader();

                      // hago el next result porque la primer fila me retorna las variables con las que genero el nro de serie.
                      reader.NextResult();
                      reader.Read();
                      numserie = reader.GetString(0);
                      reader.Close();
                    }
                    eodu.Serie = numserie;


                    string sql2 = "CALL usp_AgregarEnsayoODU_EX('" + eodu.Marca + "','" +
                    eodu.Modelo + "','" + eodu.Codigo + "','" + eodu.Serie + "','" +
                    BaseDAO.getDateTime(eodu.Fecha) + "'," + aprobado.ToString() + ",'" +
                    eodu.DCF.ToString() + "'," + eodu.Temph.ToString() + ","
                    + eodu.Tamb.ToString() + "," + eodu.Humedad.ToString() + "," +
                    eodu.Tensionh.ToString() + "," + eodu.Tensionl.ToString() + "," +
                    eodu.Corrienteh.ToString() + "," + eodu.Corrientel.ToString() + "," +
                    eodu.Potenciah.ToString() + "," + eodu.Cosf.ToString() + "," +
                    eodu.Velocidadh.ToString() + "," +
                    eodu.Velocidadl.ToString() + "," +
                    eodu.Presion1.ToString() + "," +
                    eodu.Presion2.ToString() + "," +
                    eodu.Presion3.ToString() + "," +
                    eodu.Presion4.ToString() + "," +
                    eodu.Flags.ToString() + "," +
                    eodu.Tensionhc.ToString() + "," +
                    eodu.Corrientehc.ToString() + "," +
                    eodu.Cosfc.ToString() + "," +
                    eodu.Potenciahc.ToString() + "," +
                    eodu.Velocidadhc.ToString() + "," +
                    eodu.Temphc.ToString() + "," +
                    eodu.Tambc.ToString() + "," +
                    eodu.Humedadc.ToString() + "," +
                    eodu.Presionc.ToString() + ",'" +
                    eodu.Vacio + "','" + eodu.Hipot + "','" +
                    eodu.Fuga + "','" + eodu.Observaciones + "'," +
                    eodu.Tiempoensayo + ",'" +
                    eodu.Usuario + "','" + eodu.OrdenFabricacion+"')";
                    




                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                   

                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    throw ex;
                }
            }

        }

        public override void ModificarParametrosEnsayo(ParametrosEnsayo parametrosviejos, ParametrosEnsayo parametrosnuevos)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                ParametrosEnsayoODU parodu = parametrosnuevos as ParametrosEnsayoODU;

                string sql = "CALL usp_ModificarParametrosEnsayoODU(" + parametrosviejos.ID + ",'" +
                    parametrosviejos.Referencia + "','" + parodu.Descripcion + "','" + BaseDAO.getDateTime(parodu.Modificado) + "'," +
                    parodu.DCFs.ToString() + "," +
                    parodu.TiempoInicialEstabilizacion.ToString() + "," +
                    parodu.TiempoMaximoEstabilizacion.ToString() + "," +
                    parodu.TiempoBajaTension.ToString() + "," +
                    parodu.TiempoMaximoBajaTension.ToString() + "," +
                    parodu.TiempoMedicionCalor.ToString() + "," +
                    parodu.TiempoMaximoMedicionCalor.ToString() + "," +
                    parodu.TiempoMedicionFrio.ToString() + "," +
                    parodu.TiempoRecuperacionMinima.ToString() + "," +
                    parodu.TiempoMaximoRecuperacionMinima.ToString() + "," +
                    parodu.DelayArranqueCompresor.ToString() + "," +
                    parodu.TiempoApagadoEntreCalorFrio.ToString() + "," +
                    parodu.TiempoCierreValvula1.ToString() + "," +
                    parodu.TiempoCierreValvula2.ToString() + "," +
                    parodu.TiempoFinal.ToString() + "," +
                    parodu.PresionInicialMin.ToString() + "," +
                    parodu.PresionInicialMax.ToString() + "," +
                    parodu.DeltaPresionEstabilizacionMin.ToString() + "," +
                    parodu.DeltaPresionEstabilizacionMax.ToString() + "," +
                    parodu.VelocidadBajaTensionMin.ToString()+","+
                    parodu.DeltaPresionBajaTensionMin.ToString()+","+
                    parodu.DeltaPresionBajaTensionMax.ToString() + "," +
                    parodu.DeltaTempMinCalor.ToString()+","+
                    parodu.DeltaTempMaxCalor.ToString()+","+
                    parodu.CorrienteMinCalor.ToString()+","+
                    parodu.CorrienteMaxCalor.ToString()+","+
                    parodu.PotenciaMinCalor.ToString()+","+
                    parodu.PotenciaMaxCalor.ToString()+","+
                    parodu.VelocidadMaxVentiladorCalor.ToString()+","+
                    parodu.VelocidadMinVentiladorCalor.ToString()+","+
                    parodu.PresionMinApagadoCompresor.ToString()+","+
                    parodu.DeltaTempMinFrio.ToString()+","+
                    parodu.DeltaTempMaxFrio.ToString()+","+
                    parodu.CorrienteMaxFrio.ToString()+","+
                    parodu.CorrienteMinFrio.ToString()+","+
                    parodu.PotenciaMinFrio.ToString()+","+
                    parodu.PotenciaMaxFrio.ToString()+","+
                    parodu.VelocidadMinVentiladorFrio.ToString()+","+
                    parodu.VelocidadMaxVentiladorFrio.ToString()+","+
                    parodu.PresionMinFrio.ToString()+","+
                    parodu.PresionMaxFrio.ToString()+","+
                    parodu.PresionMaxRecuperacion.ToString()+","+
                    parodu.IdVersion.ToString()+")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }            
        }

        public override void EliminarParametros(ParametrosEnsayo parametros)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarParametrosEnsayoODU("+ parametros.ID + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        
        public override List<ParametrosEnsayo> ObtenerParametrosEnsayo()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<ParametrosEnsayo> listaensayosodu = new List<ParametrosEnsayo>();
                string sql = "CALL usp_ObtenerParametrosEnsayoODU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    ParametrosEnsayoODU parodu = new ParametrosEnsayoODU();

                    parodu.CorrienteMaxCalor=reader.GetInt32("parametrosensayosodu_corrientemaxcalor");
                    parodu.CorrienteMaxFrio = reader.GetInt32("parametrosensayosodu_corrientemaxfrio");
                    parodu.CorrienteMinCalor = reader.GetInt32("parametrosensayosodu_corrientemincalor");
                    parodu.CorrienteMinFrio = reader.GetInt32("parametrosensayosodu_corrienteminfrio");
                    parodu.DCFs = reader.GetInt32("parametrosensayosodu_dcfs");
                    parodu.DelayArranqueCompresor = reader.GetInt32("parametrosensayosodu_delayarranquecompresor");
                    parodu.DeltaPresionBajaTensionMax = reader.GetInt32("parametrosensayosodu_deltapresionbajatensionmax");
                    parodu.DeltaPresionBajaTensionMin = reader.GetInt32("parametrosensayosodu_deltapresionbajatensionmin");
                    parodu.DeltaPresionEstabilizacionMax = reader.GetInt32("parametrosensayosodu_deltapresionestabilizacionmax");
                    parodu.DeltaPresionEstabilizacionMin = reader.GetInt32("parametrosensayosodu_deltapresionestabilizacionmin");
                    parodu.DeltaTempMaxCalor = reader.GetInt32("parametrosensayosodu_deltatempmaxcalor");
                    parodu.DeltaTempMaxFrio = reader.GetInt32("parametrosensayosodu_deltatempmaxfrio");
                    parodu.DeltaTempMinCalor = reader.GetInt32("parametrosensayosodu_deltatempmincalor");
                    parodu.DeltaTempMinFrio = reader.GetInt32("parametrosensayosodu_deltatempminfrio");
                    parodu.Descripcion=reader.GetString("parametrosensayosodu_descripcion");
                    parodu.TiempoApagadoEntreCalorFrio = reader.GetInt32("parametrosensayosodu_tiempoapagadoentrecaloryfrio");
                    parodu.ID = reader.GetInt32("parametrosensayosodu_id");
                    parodu.Modificado=reader.GetDateTime("parametrosensayosodu_modificado");
                    parodu.PotenciaMaxCalor = reader.GetInt32("parametrosensayosodu_potenciamaxcalor");
                    parodu.PotenciaMaxFrio = reader.GetInt32("parametrosensayosodu_potenciamaxfrio");
                    parodu.PotenciaMinCalor = reader.GetInt32("parametrosensayosodu_potenciamincalor");
                    parodu.PotenciaMinFrio = reader.GetInt32("parametrosensayosodu_potenciaminfrio");
                    parodu.PresionInicialMax = reader.GetInt32("parametrosensayosodu_presioninicialmax");
                    parodu.PresionInicialMin = reader.GetInt32("parametrosensayosodu_presioninicialmin");
                    parodu.PresionMaxFrio = reader.GetInt32("parametrosensayosodu_presionmaxfrio");
                    parodu.PresionMaxRecuperacion = reader.GetInt32("parametrosensayosodu_presionmaxrecuperacion");
                    parodu.PresionMinApagadoCompresor = reader.GetInt32("parametrosensayosodu_presionminapagadocompresor");
                    parodu.PresionMinFrio = reader.GetInt32("parametrosensayosodu_presionminfrio");
                    parodu.Referencia=reader.GetString("parametrosensayosodu_ref");
                    parodu.TiempoBajaTension = reader.GetInt32("parametrosensayosodu_tiempobajatension");
                    parodu.TiempoCierreValvula1 = reader.GetInt32("parametrosensayosodu_tiempocierrevalvula1");
                    parodu.TiempoCierreValvula2 = reader.GetInt32("parametrosensayosodu_tiempocierrevalvula2");
                    parodu.TiempoFinal = reader.GetInt32("parametrosensayosodu_tiempofinal");
                    parodu.TiempoInicialEstabilizacion = reader.GetInt32("parametrosensayosodu_tiempoinicialestabilizacion");
                    parodu.TiempoMaximoEstabilizacion = reader.GetInt32("parametrosensayosodu_tiempomaximoestabilizacion");
                    parodu.TiempoMaximoMedicionCalor = reader.GetInt32("parametrosensayosodu_tiempomaximomedicioncalor");
                    parodu.TiempoMaximoRecuperacionMinima = reader.GetInt32("parametrosensayosodu_tiempomaximorecuperacionminima");
                    parodu.TiempoMedicionCalor = reader.GetInt32("parametrosensayosodu_tiempomedicioncalor");
                    parodu.TiempoMedicionFrio = reader.GetInt32("parametrosensayosodu_tiempomedicionfrio");
                    parodu.TiempoRecuperacionMinima = reader.GetInt32("parametrosensayosodu_tiemporecuperacionminima");
                    parodu.VelocidadBajaTensionMin = reader.GetInt32("parametrosensayosodu_velocidadminbajatension");
                    parodu.VelocidadMaxVentiladorCalor = reader.GetInt32("parametrosensayosodu_velocidadmaxventiladorcalor");
                    parodu.VelocidadMaxVentiladorFrio = reader.GetInt32("parametrosensayosodu_velocidadmaxventiladorfrio");
                    parodu.VelocidadMinVentiladorCalor = reader.GetInt32("parametrosensayosodu_velocidadminventiladorcalor");
                    parodu.VelocidadMinVentiladorFrio = reader.GetInt32("parametrosensayosodu_velocidadminventiladorfrio");
                    parodu.TiempoMaximoBajaTension = reader.GetInt32("parametrosensayosodu_tiempomaximobajatension");
                    parodu.IdVersion = reader.GetInt32("parametrosensayosodu_idversion");

                    listaensayosodu.Add(parodu);
                }

                reader.Close();
                return listaensayosodu;
            }
        }

        public override void GuardarParametros(ParametrosEnsayo parametros)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                ParametrosEnsayoODU parodu = parametros as ParametrosEnsayoODU;

                string sqlparametros = "('" + parodu.Referencia + "','" + parodu.Descripcion + "','" +
                BaseDAO.getDateTime(parodu.Modificado) + "'," + parodu.DCFs.ToString() + "," +
                parodu.TiempoInicialEstabilizacion.ToString() + "," + parodu.TiempoMaximoEstabilizacion.ToString() + "," +
                parodu.TiempoBajaTension.ToString() + "," + parodu.TiempoMaximoBajaTension.ToString() + "," +
                parodu.TiempoMedicionCalor.ToString() + "," + parodu.TiempoMaximoMedicionCalor.ToString() + "," +
                parodu.TiempoMedicionFrio.ToString() + "," + parodu.TiempoRecuperacionMinima.ToString() + "," +
                parodu.TiempoMaximoRecuperacionMinima.ToString() + "," + parodu.DelayArranqueCompresor.ToString() + "," +
                parodu.TiempoApagadoEntreCalorFrio.ToString() + "," + parodu.TiempoCierreValvula1.ToString() + "," +
                parodu.TiempoCierreValvula2.ToString() + "," + parodu.TiempoFinal.ToString() + "," +
                parodu.PresionInicialMin.ToString() + "," + parodu.PresionInicialMax.ToString() + "," +
                parodu.DeltaPresionEstabilizacionMin.ToString() + "," + parodu.DeltaPresionEstabilizacionMax.ToString() + "," +
                parodu.VelocidadBajaTensionMin.ToString() + "," + parodu.DeltaPresionBajaTensionMin.ToString() + "," +
                parodu.DeltaPresionBajaTensionMax.ToString() + "," + parodu.DeltaTempMinCalor.ToString() + "," +
                parodu.DeltaTempMaxCalor.ToString() + "," + parodu.CorrienteMinCalor.ToString() + "," +
                parodu.CorrienteMaxCalor.ToString() + "," + parodu.PotenciaMinCalor.ToString() + "," +
                parodu.PotenciaMaxCalor.ToString() + "," + parodu.VelocidadMinVentiladorCalor.ToString() + "," +
                parodu.VelocidadMaxVentiladorCalor.ToString() + "," +
                parodu.PresionMinApagadoCompresor.ToString() + "," + parodu.DeltaTempMinFrio.ToString() +
                "," + parodu.DeltaTempMaxFrio.ToString() + "," + parodu.CorrienteMaxFrio.ToString() +
                "," + parodu.CorrienteMinFrio.ToString() + "," + parodu.PotenciaMinFrio.ToString() + "," +
                parodu.PotenciaMaxFrio.ToString() + "," + parodu.VelocidadMinVentiladorFrio.ToString() + "," +
                parodu.VelocidadMaxVentiladorFrio.ToString() + "," + parodu.PresionMinFrio.ToString() +
                "," + parodu.PresionMaxFrio.ToString() + "," + parodu.PresionMaxRecuperacion.ToString() +","+ 
                parodu.IdVersion.ToString()+")";


                string sql = "CALL usp_AgregarParametrosEnsayoODU" + sqlparametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }                

        }

        override public List<Modelo> ObtenerModelos()
        {
            return base.ObtenerModelos(false);
        }

        public override List<CaracteristicasTecnicas> ObtenerCaracteristicasTecnicas()
        {
            return base.ObtenerCaracteristicasTecnicas(false);
        }

        #region BBDD Nueva
        /// <summary>
        /// Carga los modelos de la BBDD vieja y los mete en la nueva.
        /// </summary>
        public override void CargarModelosEnDBNueva(string nombre_sufijo)
        {
            MySqlConnection conn = ConectarBDAnterior();

            List<Modelo> listamodelos = new List<Modelo>();
            List<string> etiquetas = new List<string>();
            List<string> etiquetascaja = new List<string>();

            string sql = "select * from modelos;"; //string sql = "CALL usp_ObtenerModelos('ODU')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Modelo nuevomodelo = new Modelo();
                nuevomodelo.Capacidad =reader.GetString("EXTRA2");
                nuevomodelo.Codigo =reader.GetString("CODIGO");
                nuevomodelo.CodigoICSA=reader.GetString("EXTRA3");
                nuevomodelo.Conjunto =reader.GetString("EXTRA1");
                nuevomodelo.Descripcion =reader.GetString("DESCRIPCION");
                nuevomodelo.Dimension =reader.GetString("DIMEN");
                nuevomodelo.Ean13 =reader.GetString("EAN13");
                nuevomodelo.EsIdu =false;
               // nuevomodelo.Etiqueta = ;
               // nuevomodelo.EtiquetaCaja = ;
                nuevomodelo.ID =reader.GetInt32("ID");
                nuevomodelo.Logo =reader.GetString("LOGO");
                nuevomodelo.Marca =reader.GetString("MARCA");
                nuevomodelo.Nombremodelo = reader.GetString("MODELO").Trim() + nombre_sufijo;
                nuevomodelo.Referencia = reader.GetString("REF").Trim() + nombre_sufijo;

                listamodelos.Add(nuevomodelo);
                etiquetas.Add(reader.GetString("ETIQUETA").Trim() + nombre_sufijo);
                etiquetascaja.Add(reader.GetString("ETIQCAJA").Trim() + nombre_sufijo);
               

            }
            reader.Close();

            MySqlConnection conn2 = ConectarBaseDeDatos();


            for (int i = 0; i < listamodelos.Count; i++)
            {
                
          
                string sql2 = "CALL usp_ObtenerEtiquetaPorNombre('" + etiquetas[i]+ "')";

               
                Etiqueta nuevaetiqueta = new Etiqueta();
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
              
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    nuevaetiqueta.Id = reader2.GetInt32("etiquetas_id");
                }
                reader2.Close();

                listamodelos[i].Etiqueta = nuevaetiqueta.Id;


            }
            //reader2.Close();
            conn2.Close();

            conn2.Open();

            for (int j = 0; j < listamodelos.Count; j++)
            {
               

                string sql3 = "CALL usp_ObtenerEtiquetaPorNombre('" + etiquetascaja[j] + "')";
                Etiqueta nuevaetiqueta2 = new Etiqueta();
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn2);

                MySqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    nuevaetiqueta2.Id = reader3.GetInt32("etiquetas_id");
                }
                reader3.Close();


                listamodelos[j].EtiquetaCaja = nuevaetiqueta2.Id;
             
            }
            conn2.Close();

            //conn2.Open();

            for (int i = 0; i < listamodelos.Count; i++)

                AgregarModelo(listamodelos[i]);

            
        }
        public override void CargarParametrosEnDBNueva(string nombre_sufijo)
        {
            List<ParametrosEnsayoODU> listaparametros = new List<ParametrosEnsayoODU>();
            MySqlConnection conn = ConectarBDAnterior();
            string sql = "select * from parametrosodu;";// "CALL usp_ObtenerParametrosODU()";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                ParametrosEnsayoODU paramodu = new ParametrosEnsayoODU();
                paramodu.CorrienteMaxCalor=reader.GetInt32("ADDMODCAL8");
                paramodu.CorrienteMaxFrio=reader.GetInt32("POTENCIA_MAX");
                paramodu.CorrienteMinCalor=reader.GetInt32("ADDMODCAL9");
                paramodu.CorrienteMinFrio=reader.GetInt32("POTENCIA_MIN");
                paramodu.DCFs=reader.GetInt32("DCFs");
                paramodu.DelayArranqueCompresor=reader.GetInt32("ADDMODCAL1");
                paramodu.DeltaPresionBajaTensionMax=reader.GetInt32("PRESION3_MAX");
                paramodu.DeltaPresionBajaTensionMin=reader.GetInt32("PRESION2_MIN");
                paramodu.DeltaPresionEstabilizacionMax=reader.GetInt32("PRESION2_MAX");
                paramodu.DeltaPresionEstabilizacionMin=reader.GetInt32("PRESION4_MIN");
                paramodu.DeltaTempMaxCalor=reader.GetInt32("ADDMODCAL6");
                paramodu.DeltaTempMaxFrio=reader.GetInt32("CORRIENTE_MAX");
                paramodu.DeltaTempMinCalor=reader.GetInt32("ADDMODCAL7");
                paramodu.DeltaTempMinFrio=reader.GetInt32("CORRIENTE_MIN");
                paramodu.Descripcion = reader.GetString("DESCRIPCION").Trim() + nombre_sufijo;
                paramodu.ID = reader.GetInt32("ID") ;
               // paramodu.IdVersion=;
                paramodu.Modificado=reader.GetDateTime("MODIFICADO");
                paramodu.PotenciaMaxCalor=reader.GetInt32("ADDMODCAL10");
                paramodu.PotenciaMaxFrio=reader.GetInt32("VELOCIDAD_MAX");
                paramodu.PotenciaMinCalor=reader.GetInt32("ADDMODCAL11");
                paramodu.PotenciaMinFrio=reader.GetInt32("VELOCIDAD_MIN");
                paramodu.PresionInicialMax=reader.GetInt32("DELTATEMP_MAX");
                paramodu.PresionInicialMin=reader.GetInt32("DELTATEMP_MIN");
                paramodu.PresionMaxFrio=reader.GetInt32("ADDMODCAL14");
                paramodu.PresionMaxRecuperacion=reader.GetInt32("PRESION4_MAX");
                paramodu.PresionMinApagadoCompresor=reader.GetInt32("ADDMODCAL12");
                paramodu.PresionMinFrio=reader.GetInt32("ADDMODCAL13");
                paramodu.Referencia = reader.GetString("REF").Trim() + nombre_sufijo;
                paramodu.TiempoApagadoEntreCalorFrio=reader.GetInt32("ADDTCTC1");
                paramodu.TiempoBajaTension=reader.GetInt32("T_BAJATENSION");
                if (nombre_sufijo == "") 
                {
                    paramodu.TiempoCierreValvula1 = reader.GetInt32("ADDPROV3.1");
                    paramodu.TiempoCierreValvula2 = reader.GetInt32("ADDPROV3.2");
                
                } 
                else 
                {
                    paramodu.TiempoCierreValvula1 = reader.GetInt32("ADDPROV31");
                    paramodu.TiempoCierreValvula2 = reader.GetInt32("ADDPROV32");
                
                }
                paramodu.TiempoFinal=reader.GetInt32("T_FINAL");
                paramodu.TiempoInicialEstabilizacion=reader.GetInt32("T_INICIAL");
                paramodu.TiempoMaximoBajaTension=reader.GetInt32("T_TOUTBAJA");
                paramodu.TiempoMaximoEstabilizacion=reader.GetInt32("T_TOUTINICIAL");
                paramodu.TiempoMaximoMedicionCalor=reader.GetInt32("ADDMODCAL3");
                paramodu.TiempoMaximoRecuperacionMinima=reader.GetInt32("T_TOUTREC");
                paramodu.TiempoMedicionCalor=reader.GetInt32("ADDMODCAL2");
                paramodu.TiempoMedicionFrio=reader.GetInt32("T_MEDICION");
                paramodu.TiempoRecuperacionMinima=reader.GetInt32("T_RECUPERACION");
             //   paramodu.VelocidadBajatensionMax=reader.GetInt32("");
                paramodu.VelocidadBajaTensionMin=reader.GetInt32("PRESION3_MIN");
                paramodu.VelocidadMaxVentiladorCalor=reader.GetInt32("ADDMODCAL4");
                paramodu.VelocidadMaxVentiladorFrio=reader.GetInt32("PRESION1_MAX");
                paramodu.VelocidadMinVentiladorCalor=reader.GetInt32("ADDMODCAL5");
                paramodu.VelocidadMinVentiladorFrio=reader.GetInt32("PRESION1_MIN");
                
                listaparametros.Add(paramodu);

            }
            reader.Close();
        //    MySqlConnection conn2 = ConectarBaseDeDatos();


             for (int i = 0; i < listaparametros.Count; i++)
                    {


                        GuardarParametros(listaparametros[i]);
                
                     //   MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                      //  cmd2.ExecuteNonQuery();
                    }
                   // conn2.Close();
               
        }
        public override void CargarReferenciasEnDBNueva(string nombre_sufijo)
        {
            MySqlConnection conn = ConectarBDAnterior();

            List<CaracteristicasTecnicas> listacaracteristicas = new List<CaracteristicasTecnicas>();
            string sql = "select * from referencias; ";  //string sql = "CALL usp_ObtenerReferencias()";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                CaracteristicasTecnicas nuevact = new CaracteristicasTecnicas();
                nuevact.CapacidadCalor =reader.GetString("CAPACIDAD_C");
                nuevact.CapacidadFrio =reader.GetString("CAPACIDAD");
                nuevact.Carga =reader.GetString("CARGA");
                nuevact.CorrienteMaxima =reader.GetString("CORRIENTEMAX");
                nuevact.CorrienteNominalCalor =reader.GetString("CORRIENTENOM_C");
                nuevact.CorrienteNominalFrio =reader.GetString("CORRIENTENOM");
                nuevact.Descripcion1 =reader.GetString("DESCRI1");
                nuevact.Descripcion2 =reader.GetString("DESCRI2");
                nuevact.Descripcion3 =reader.GetString("DESCRI3");
                nuevact.Descripcion4 =reader.GetString("DESCRI4");
                nuevact.Descripcion5 =reader.GetString("DESCRI5");
                nuevact.Descripcion6 =reader.GetString("DESCRI6");
                nuevact.Err =reader.GetString("ERR");
                nuevact.Esidu =false;
                nuevact.Frecuencia =reader.GetString("FRECUENCIA");
                nuevact.Nombre = reader.GetString("REF") + nombre_sufijo;
                nuevact.Peso =reader.GetString("PESO");
                nuevact.PotenciaMaxima =reader.GetString("POTENCIAMAX");
                nuevact.PotenciaNominalCalor =reader.GetString("POTENCIANOM_C");
                nuevact.PotenciaNominalFrio =reader.GetString("POTENCIANOM");
                nuevact.Presion =reader.GetString("PRESION");
                nuevact.TensionNominal =reader.GetString("TENSIONNOM");
                nuevact.Version = reader.GetInt32("VERSION"); ;

                listacaracteristicas.Add(nuevact);

                
            }
            reader.Close();
            conn.Close();
            conn = base.ConectarBaseDeDatos();
            for ( int i = 0 ; i< listacaracteristicas.Count;i++)
            {

            //string sql2 = "CALL usp_ObtenerIDParametrosPorReferencia('"+(listacaracteristicas[i].Nombre+nombre_sufijo).Trim()+"')";
            string sql2 = "select * from parametrosensayosodu where Parametrosensayosodu_ref = '" + (listacaracteristicas[i].Nombre.Trim() ).Trim() + "';"; 
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

                while(reader2.Read())
                {
                    int idparam = reader2.GetInt32("Parametrosensayosodu_id");
                    listacaracteristicas[i].IdParametros = idparam;

                }

                reader2.Close();
            }
            conn.Close();
            for ( int i =0 ; i<listacaracteristicas.Count ; i++)
            {

                AgregarCaracteristicaTecnica(listacaracteristicas[i]);

            }



        }
        public void CargarEtiquetasEnBaseDeDatosNueva(string nombre_sufijo)
        {

            MySqlConnection connNew = ConectarBDAnterior();
            string sqlNew = "SELECT distinct(nombre) FROM formatos ;";
            MySqlCommand cmdNEW = new MySqlCommand(sqlNew, connNew);
            MySqlDataReader readerNEW = cmdNEW.ExecuteReader();


            while (readerNEW.Read())
            {
                string nombre_etiqueta = readerNEW.GetString("nombre");
                MySqlConnection conn = ConectarBDAnterior();
                List<EtiquetaItem> listacomponentes = new List<EtiquetaItem>();
                string sql = "select * from formatos where NOMBRE ='" + nombre_etiqueta + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    EtiquetaItem componenteetiqueta = new EtiquetaItem();
                    componenteetiqueta.Yinicial = reader.GetInt32("YINI");
                    componenteetiqueta.Yfinal = reader.GetInt32("YFIN");
                    componenteetiqueta.Xinicial = reader.GetInt32("XINI");
                    componenteetiqueta.Xfinal = reader.GetInt32("XFIN");
                    componenteetiqueta.Variable = reader.GetInt32("VARIABLE");
                    componenteetiqueta.Tipo = reader.GetInt32("TIPO");
                    componenteetiqueta.Size = reader.GetInt32("SIZE");
                    // componenteetiqueta.ParamValue = ;
                    componenteetiqueta.Param = reader.GetString("PARAM");
                    componenteetiqueta.NumeroEtiqueta = 9;
                    componenteetiqueta.Italic = reader.GetInt32("ITALIC");
                    componenteetiqueta.Font = reader.GetString("FONT");
                    componenteetiqueta.Bold = reader.GetInt32("BOLD");
                    componenteetiqueta.Alignv = reader.GetInt32("ALIGNV");
                    componenteetiqueta.Alignh = reader.GetInt32("ALIGNH");

                    listacomponentes.Add(componenteetiqueta);
                }

                reader.Close();




                Etiqueta oEtiqueta = new Etiqueta();
                oEtiqueta.Nombre = nombre_etiqueta.Trim() + nombre_sufijo;
                oEtiqueta.EsIDU = false;
                oEtiqueta.Componentes = listacomponentes;
                this.GuardarEtiqueta(oEtiqueta);
                conn.Close();
                /*MySqlConnection conn2 = ConectarBaseDeDatos();
                for (int i = 0; i < listacomponentes.Count; i++)
                {


                    string sql2 = "CALL usp_AgregarComponenteEtiqueta('";
                    sql2 = sql2 + listacomponentes[i].Font + "'," +
                     listacomponentes[i].Size.ToString() + "," +
                        listacomponentes[i].Bold.ToString() + "," +
                        listacomponentes[i].Italic.ToString() + "," +
                       listacomponentes[i].Yinicial.ToString() + "," +
                       listacomponentes[i].Xinicial.ToString() + "," +
                        listacomponentes[i].Yfinal.ToString() + "," +
                       listacomponentes[i].Variable.ToString() + "," +
                      listacomponentes[i].Tipo.ToString() + "," +
                       listacomponentes[i].Alignh.ToString() + "," +
                       listacomponentes[i].Alignv.ToString() + "," +
                      listacomponentes[i].Xfinal.ToString() + ",'" +
                       listacomponentes[i].Param.ToString() + "'," +
                        listacomponentes[i].NumeroEtiqueta.ToString() + ")";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                    cmd2.ExecuteNonQuery();
                }
                conn2.Close();*/

            }
            readerNEW.Close();
            connNew.Close();

        }

        /* LO DEJO COMENTADO PARA QUE ME QUEDE DE GUIA DESPUES PARA IDU 
         * 
         * public override void CargarEtiquetasEnBaseDeDatosNueva()
           {
            
               /*using*/
        //MySqlConnection conn =ConectarBDAnterior();
        //{
        //  MySqlTransaction trans = conn.BeginTransaction();
        /*  List<EtiquetaItem> listacomponentes = new List<EtiquetaItem>();
          string sql = "CALL usp_ObtenerEtiquetas('" + "PROD_JCI'" + ")";
          MySqlCommand cmd = new MySqlCommand(sql, conn);
          MySqlDataReader reader = cmd.ExecuteReader();


          while (reader.Read())
          {
              EtiquetaItem componenteetiqueta = new EtiquetaItem();
              componenteetiqueta.Yinicial =reader.GetInt32("YINI");
              componenteetiqueta.Yfinal =reader.GetInt32("YFIN");
              componenteetiqueta.Xinicial = reader.GetInt32("XINI");
              componenteetiqueta.Xfinal = reader.GetInt32("XFIN");
              componenteetiqueta.Variable =reader.GetInt32("VARIABLE");
              componenteetiqueta.Tipo =reader.GetInt32("TIPO");
              componenteetiqueta.Size =reader.GetInt32("SIZE");
             // componenteetiqueta.ParamValue = ;
              componenteetiqueta.Param =reader.GetString("PARAM");
              componenteetiqueta.NumeroEtiqueta = 8;
              componenteetiqueta.Italic =reader.GetInt32("ITALIC") ;
              componenteetiqueta.Font =reader.GetString("FONT") ;
              componenteetiqueta.Bold =reader.GetInt32("BOLD") ;
              componenteetiqueta.Alignv =reader.GetInt32("ALIGNV") ;
              componenteetiqueta.Alignh =reader.GetInt32("ALIGNH");

              listacomponentes.Add(componenteetiqueta);
          }
          reader.Close();
         // trans.Commit();
               
         MySqlConnection conn2 = ConectarBaseDeDatos();

            
              for (int i = 0; i < listacomponentes.Count; i++)
              {
                        
                        
                  string sql2 = "CALL usp_AgregarComponenteEtiqueta('";
                  sql2 = sql2 + listacomponentes[i].Font + "'," +
                   listacomponentes[i].Size.ToString() + "," +
                      listacomponentes[i].Bold.ToString() + "," +
                      listacomponentes[i].Italic.ToString() + "," +
                     listacomponentes[i].Yinicial.ToString() + "," +
                     listacomponentes[i].Xinicial.ToString() + "," +
                      listacomponentes[i].Yfinal.ToString() + "," +
                     listacomponentes[i].Variable.ToString() + "," +
                    listacomponentes[i].Tipo.ToString() + "," +
                     listacomponentes[i].Alignh.ToString() + "," +
                     listacomponentes[i].Alignv.ToString() + "," +
                    listacomponentes[i].Xfinal.ToString() + ",'" +
                     listacomponentes[i].Param.ToString() + "'," +
                      listacomponentes[i].NumeroEtiqueta.ToString() + ")";
                  MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                  cmd2.ExecuteNonQuery();
              }
              conn2.Close();
               
     // }
  }*/

        /* public override void ObtenerEtiquetasDBAnterior()
         {
             using (MySqlConnection conn = ConectarBaseDeDatos())
             {
                
                
                 List<Etiqueta> listaetiquetas = new List<Etiqueta>();
                 string sql = "CALL usp_ObtenerEtiquetas()";
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 MySqlDataReader reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {

                     Etiqueta nuevaetiqueta = new Etiqueta();
                     EtiquetaItem nuevoscomponentes = new EtiquetaItem();

                     nuevaetiqueta.Nombre = reader.GetString("NOMBRE");
                     nuevoscomponentes.Alignh=;
                     nuevoscomponentes.Alignv=;
                     nuevoscomponentes.Bold=;
                     nuevoscomponentes.Font=;
                     nuevoscomponentes.Italic = ;
                     nuevoscomponentes.Param=;
                     nuevoscomponentes.ParamValue = ;
                     nuevoscomponentes.Size = ;
                     nuevoscomponentes.Variable = ;
                     nuevoscomponentes.Xfinal = ;
                     nuevoscomponentes.Xinicial = ;
                     nuevoscomponentes.Yfinal = ;
                     nuevoscomponentes.Yinicial=;
                    
                    
                    
                     switch (nuevaetiqueta.Nombre)
                    
                     nuevoscomponentes.NumeroEtiqueta 
                    


                 }
                

             }
         */
        #endregion BBDD Nueva

        public override List<Ensayos> ObtenerEnsayosPorFecha(DateTime desde, DateTime hasta)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> listaensayosodu = new List<Ensayos>();


                string parametros = "('" + BaseDAO.getDateTime(desde) + "','" + BaseDAO.getDateTime(hasta) + "')";
                string sql = "CALL usp_ObtenerEnsayosODUPorFecha" + parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    EnsayosODU nuevoensayo = new EnsayosODU();


                    if (reader.GetInt32("ensayosrealizadosodu_aprobado") == 1)
                    {

                        nuevoensayo.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayo.Aprobado = false;
                    }


                    nuevoensayo.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
                    nuevoensayo.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
                    nuevoensayo.Corrienteh = reader.GetFloat("ensayosrealizadosodu_corrientealta");
                    nuevoensayo.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
                    nuevoensayo.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
                    nuevoensayo.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
                    nuevoensayo.Cosfc = reader.GetFloat("ensayosrealizadosodu_factordepotenciacalor");
                    nuevoensayo.DCF = reader.GetString("ensayosrealizadosodu_dcf");
                    nuevoensayo.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
                    nuevoensayo.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
                    nuevoensayo.Fuga = reader.GetString("ensayosrealizadosodu_fuga"); ;
                    nuevoensayo.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
                    nuevoensayo.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
                    nuevoensayo.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
                    nuevoensayo.ID = reader.GetInt32("ensayosrealizadosodu_id");
                    nuevoensayo.Marca = reader.GetString("ensayosrealizadosodu_marca");
                    nuevoensayo.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
                    nuevoensayo.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
                    nuevoensayo.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
                    nuevoensayo.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
                    nuevoensayo.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
                    nuevoensayo.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
                    nuevoensayo.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
                    nuevoensayo.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
                    nuevoensayo.Serie = reader.GetString("ensayosrealizadosodu_serie");
                    nuevoensayo.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambiente");
                    nuevoensayo.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayo.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
                    nuevoensayo.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
                    nuevoensayo.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
                    nuevoensayo.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
                    nuevoensayo.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
                    nuevoensayo.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
                    nuevoensayo.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
                    nuevoensayo.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
                    nuevoensayo.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
                    nuevoensayo.Modelo = reader.GetString("ensayosrealizadosodu_modelo");
                    nuevoensayo.Usuario = reader.GetString("ensayosrealizadosodu_usuario");
                    listaensayosodu.Add(nuevoensayo);
                }

                reader.Close();
                return listaensayosodu;
            }
        }


        public override List<Ensayos> ObtenerEnsayosAprobados(DateTime actual)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> ensayosodu = new List<Ensayos>();
                string parametros = "('" + BaseDAO.getDate(actual) + "')";
                string sql = "CALL usp_VerAprobadosDelDiaODU" + parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    EnsayosODU nuevoensayoodu = new EnsayosODU();
                    nuevoensayoodu.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
                    nuevoensayoodu.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
                    nuevoensayoodu.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
                    nuevoensayoodu.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
                    nuevoensayoodu.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
                    nuevoensayoodu.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
                    nuevoensayoodu.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
                    nuevoensayoodu.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
                    nuevoensayoodu.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
                    nuevoensayoodu.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
                    nuevoensayoodu.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayoodu.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayoodu.Serie = reader.GetString("ensayosrealizadosodu_serie");
                    nuevoensayoodu.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
                    nuevoensayoodu.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
                    nuevoensayoodu.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
                    nuevoensayoodu.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
                    nuevoensayoodu.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
                    nuevoensayoodu.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
                    nuevoensayoodu.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
                    nuevoensayoodu.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
                    nuevoensayoodu.Modelo = reader.GetString("ensayosrealizadosodu_modelo");
                    nuevoensayoodu.Marca = reader.GetString("ensayosrealizadosodu_marca");
                    nuevoensayoodu.ID = reader.GetInt32("ensayosrealizadosodu_id");
                    nuevoensayoodu.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
                    nuevoensayoodu.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
                    nuevoensayoodu.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
                    nuevoensayoodu.Fuga = reader.GetString("ensayosrealizadosodu_fuga");
                    nuevoensayoodu.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
                    nuevoensayoodu.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
                    nuevoensayoodu.DCF = reader.GetString("ensayosrealizadosodu_dcf");
                    nuevoensayoodu.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
                    nuevoensayoodu.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
                    nuevoensayoodu.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
                    nuevoensayoodu.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
                    nuevoensayoodu.Cosfc = reader.GetFloat("ensayosrealizadosodu_factordepotenciacalor");
                    
                    if(reader.GetInt32("ensayosrealizadosodu_aprobado")==1)
                    {
                    
                    nuevoensayoodu.Aprobado=true;
                    
                    }
                    
                    else
                    
                    {    
                    nuevoensayoodu.Aprobado=false;
                    }

                    ensayosodu.Add(nuevoensayoodu);

                }

                reader.Close();
                return ensayosodu;
            }
        }


        public override void ModificarObservacion(Ensayos e, string nuevaobservacion)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string Parametros = "('" + nuevaobservacion + "'," + e.ID.ToString() + ")";
                string sql = "CALL usp_ModificarObservacionODU" + Parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        
        
        public override List<Ensayos> ObtenerEnsayosFallados(DateTime actual)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> ensayosodu = new List<Ensayos>();
                string parametros = "( '" + BaseDAO.getDate(actual) + "' )";
                string sql = "CALL usp_VerFallasDelDiaODU" + parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    EnsayosODU nuevoensayoodu = new EnsayosODU();
                    nuevoensayoodu.Velocidadl = reader.GetFloat("ensayosrealizadosodu_velocidadbaja");
                    nuevoensayoodu.Velocidadhc = reader.GetFloat("ensayosrealizadosodu_velocidadaltacalor");
                    nuevoensayoodu.Velocidadh = reader.GetFloat("ensayosrealizadosodu_velocidadalta");
                    nuevoensayoodu.Vacio = reader.GetString("ensayosrealizadosodu_vacio");
                    nuevoensayoodu.Tiempoensayo = reader.GetInt32("ensayosrealizadosodu_tiempoensayo");
                    nuevoensayoodu.Tensionl = reader.GetFloat("ensayosrealizadosodu_tensionbaja");
                    nuevoensayoodu.Tensionhc = reader.GetFloat("ensayosrealizadosodu_tensionaltacalor");
                    nuevoensayoodu.Tensionh = reader.GetFloat("ensayosrealizadosodu_tensionalta");
                    nuevoensayoodu.Temphc = reader.GetFloat("ensayosrealizadosodu_temperaturaaltacalor");
                    nuevoensayoodu.Temph = reader.GetFloat("ensayosrealizadosodu_diferenciadetemperatura");
                    nuevoensayoodu.Tambc = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayoodu.Tamb = reader.GetFloat("ensayosrealizadosodu_temperaturaambientecalor");
                    nuevoensayoodu.Serie = reader.GetString("ensayosrealizadosodu_serie");
                    nuevoensayoodu.Presionc = reader.GetFloat("ensayosrealizadosodu_presionbajatensioncalor");
                    nuevoensayoodu.Presion4 = reader.GetFloat("ensayosrealizadosodu_presionrecuperacion");
                    nuevoensayoodu.Presion3 = reader.GetFloat("ensayosrealizadosodu_presionensayo");
                    nuevoensayoodu.Presion2 = reader.GetFloat("ensayosrealizadosodu_presionbajatension");
                    nuevoensayoodu.Presion1 = reader.GetFloat("ensayosrealizadosodu_presioninicial");
                    nuevoensayoodu.Potenciahc = reader.GetFloat("ensayosrealizadosodu_potenciaaltacalor");
                    nuevoensayoodu.Potenciah = reader.GetFloat("ensayosrealizadosodu_potenciaalta");
                    nuevoensayoodu.Observaciones = reader.GetString("ensayosrealizadosodu_observaciones");
                    nuevoensayoodu.Modelo = reader.GetString("ensayosrealizadosodu_modelo");
                    nuevoensayoodu.Marca = reader.GetString("ensayosrealizadosodu_marca");
                    nuevoensayoodu.ID = reader.GetInt32("ensayosrealizadosodu_id");
                    nuevoensayoodu.Humedadc = reader.GetFloat("ensayosrealizadosodu_humedadcalor");
                    nuevoensayoodu.Humedad = reader.GetFloat("ensayosrealizadosodu_humedad");
                    nuevoensayoodu.Hipot = reader.GetString("ensayosrealizadosodu_hipot");
                    nuevoensayoodu.Fuga = reader.GetString("ensayosrealizadosodu_fuga");
                    nuevoensayoodu.Flags = reader.GetFloat("ensayosrealizadosodu_flags");
                    nuevoensayoodu.Fecha = reader.GetDateTime("ensayosrealizadosodu_fecha");
                    nuevoensayoodu.DCF = reader.GetString("ensayosrealizadosodu_dcf");
                    nuevoensayoodu.Cosf = reader.GetFloat("ensayosrealizadosodu_factordepotencia");
                    nuevoensayoodu.Corrientel = reader.GetFloat("ensayosrealizadosodu_corrientebaja");
                    nuevoensayoodu.Corrientehc = reader.GetFloat("ensayosrealizadosodu_corrientealtacalor");
                    nuevoensayoodu.Codigo = reader.GetString("ensayosrealizadosodu_codigo");
                    nuevoensayoodu.Cosfc = reader.GetFloat("ensayosrealizadosodu_factordepotenciacalor");

                    if (reader.GetInt32("ensayosrealizadosodu_aprobado") == 1)
                    {

                        nuevoensayoodu.Aprobado = true;

                    }

                    else
                    {
                        nuevoensayoodu.Aprobado = false;
                    }

                    ensayosodu.Add(nuevoensayoodu);

                }

                reader.Close();
                return ensayosodu;
            }
        }

        public override int EliminarFallas()
        {
          using (MySqlConnection conn = ConectarBaseDeDatos())
          {
              string sql = "CALL usp_EliminarFallasODU()";
              MySqlCommand cmd = new MySqlCommand(sql, conn);
              int i = cmd.ExecuteNonQuery();
              return i;
          }
        }


    }
}
