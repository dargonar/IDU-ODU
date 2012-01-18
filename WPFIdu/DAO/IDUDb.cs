using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using MySql.Data.MySqlClient;
using MySql.Data.Types;


namespace iDU.DAO
{
    public class IDUDb : BaseDAO
    {
        public override List<Ensayos> ObtenerEnsayos()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> listaensayosidu = new List<Ensayos>();
                string sql = "CALL usp_ObtenerEnsayosIDU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    iDU.CommonObjects.EnsayosIDU nuevoensayoidu = new EnsayosIDU();
                    nuevoensayoidu.ID = reader.GetInt32("ensayosrealizadosidu_id");
                    nuevoensayoidu.Marca = reader.GetString("ensayosrealizadosidu_marca");
                    nuevoensayoidu.Observaciones = reader.GetString("ensayosrealizadosidu_observaciones");
                    nuevoensayoidu.Serie = reader.GetString("ensayosrealizadosidu_serie");
                    nuevoensayoidu.TiempoEnsayo = reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
                    nuevoensayoidu.VelocidadBajaTension = reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
                    nuevoensayoidu.VelocidadHigh = reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
                    nuevoensayoidu.VelocidadInicial = reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
                    nuevoensayoidu.VelocidadLow = reader.GetFloat("ensayosrealizadosidu_velocidadlow");
                    nuevoensayoidu.Hipot = reader.GetString("ensayosrealizadosidu_hipot");
                    nuevoensayoidu.Fuga = reader.GetString("ensayosrealizadosidu_fuga");
                    nuevoensayoidu.Fecha = reader.GetDateTime("ensayosrealizadosidu_fecha");
                    nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf");
                    nuevoensayoidu.CorrienteLow = reader.GetFloat("ensayosrealizadosidu_corrientelow");
                    nuevoensayoidu.CorrienteInicial = reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
                    nuevoensayoidu.CorrienteCalorInicial = reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
                    nuevoensayoidu.CorrienteBajaTension = reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
                    nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo");
                    nuevoensayoidu.Modelo = reader.GetString("ensayosrealizadosidu_modelo");
                    nuevoensayoidu.CorrienteHIGH = reader.GetFloat("ensayosrealizadosidu_corrientehigh");
                    nuevoensayoidu.Usuario = reader.GetString("ensayosrealizadosidu_usuario");

                    if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                    {

                        nuevoensayoidu.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayoidu.Aprobado = false;
                    }

                    listaensayosidu.Add(nuevoensayoidu);


                }

                reader.Close();
                return listaensayosidu;
            }
        }

        public override string ObtenerDescripcionFalla(Ensayos e)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                string sql = "CALL usp_ObtenerDescripcionFallaIDU(" + e.Codigo.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                string descripcionfalla = (string)cmd.ExecuteScalar();

                if (descripcionfalla == null || descripcionfalla.Equals(string.Empty))
                    return "Falla desconocida";
                else
                    return descripcionfalla;
            }
        }

      
        public override bool ObtenerPrioridadFalla(int codigo)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ObtenerPrioridadFallaIDU(" + codigo.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                bool prioridadfalla = false;
                
                if(cmd.ExecuteScalar()!= null)
                   prioridadfalla = (bool)cmd.ExecuteScalar();

                return prioridadfalla;

            }
        }


        public override Ensayos ObtenerUltimoEnsayo()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                EnsayosIDU nuevoensayoidu = new EnsayosIDU();
                string sql = "CALL usp_ObtenerUltimoEnsayoIDU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    nuevoensayoidu.ID = reader.GetInt32("ensayosrealizadosidu_id");
                    nuevoensayoidu.Marca = reader.GetString("ensayosrealizadosidu_marca");
                    nuevoensayoidu.Observaciones = reader.GetString("ensayosrealizadosidu_observaciones");
                    nuevoensayoidu.Serie = reader.GetString("ensayosrealizadosidu_serie");
                    nuevoensayoidu.TiempoEnsayo = reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
                    nuevoensayoidu.VelocidadBajaTension = reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
                    nuevoensayoidu.VelocidadHigh = reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
                    nuevoensayoidu.VelocidadInicial = reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
                    nuevoensayoidu.VelocidadLow = reader.GetFloat("ensayosrealizadosidu_velocidadlow");
                    nuevoensayoidu.Hipot = reader.GetString("ensayosrealizadosidu_hipot");
                    nuevoensayoidu.Fuga = reader.GetString("ensayosrealizadosidu_fuga");
                    nuevoensayoidu.Fecha = reader.GetDateTime("ensayosrealizadosidu_fecha");
                    nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf");
                    nuevoensayoidu.CorrienteLow = reader.GetFloat("ensayosrealizadosidu_corrientelow");
                    nuevoensayoidu.CorrienteInicial = reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
                    nuevoensayoidu.CorrienteCalorInicial = reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
                    nuevoensayoidu.CorrienteBajaTension = reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
                    nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo");
                    nuevoensayoidu.Modelo = reader.GetString("ensayosrealizadosidu_modelo");
                    nuevoensayoidu.CorrienteHIGH = reader.GetFloat("ensayosrealizadosidu_corrientehigh");
                    nuevoensayoidu.Usuario = reader.GetString("ensayosrealizadosidu_usuario");

                    if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                    {

                        nuevoensayoidu.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayoidu.Aprobado = false;
                    }




                }

                reader.Close();
                return nuevoensayoidu;
            }
        }
        
        #region BBDD Nueva
        public override void CargarReferenciasEnDBNueva(string nombre_sufijo)
        {
            MySqlConnection conn = ConectarBDAnterior();

            List<CaracteristicasTecnicas> listacaracteristicas = new List<CaracteristicasTecnicas>();
            string sql = "select * from referencias; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CaracteristicasTecnicas nuevact = new CaracteristicasTecnicas();
                nuevact.CapacidadCalor = reader.GetString("CAPACIDAD_C");
                nuevact.CapacidadFrio = reader.GetString("CAPACIDAD");
                nuevact.Carga = reader.GetString("CARGA");
                nuevact.CorrienteMaxima = reader.GetString("CORRIENTEMAX");
                nuevact.CorrienteNominalCalor = reader.GetString("CORRIENTENOM_C");
                nuevact.CorrienteNominalFrio = reader.GetString("CORRIENTENOM");
                nuevact.Descripcion1 = reader.GetString("DESCRI1");
                nuevact.Descripcion2 = reader.GetString("DESCRI2");
                nuevact.Descripcion3 = reader.GetString("DESCRI3");
                nuevact.Descripcion4 = reader.GetString("DESCRI4");
                nuevact.Descripcion5 = reader.GetString("DESCRI5");
                nuevact.Descripcion6 = reader.GetString("DESCRI6");
                nuevact.Err = reader.GetString("ERR");
                nuevact.Esidu = true;
                nuevact.Frecuencia = reader.GetString("FRECUENCIA");
                nuevact.Nombre = reader.GetString("REF") + nombre_sufijo; ;
                nuevact.Peso = reader.GetString("PESO");
                nuevact.PotenciaMaxima = reader.GetString("POTENCIAMAX");
                nuevact.PotenciaNominalCalor = reader.GetString("POTENCIANOM_C");
                nuevact.PotenciaNominalFrio = reader.GetString("POTENCIANOM");
                nuevact.Presion = reader.GetString("PRESION");
                nuevact.TensionNominal = reader.GetString("TENSIONNOM");
                nuevact.Version = reader.GetInt32("VERSION"); ;
                
                listacaracteristicas.Add(nuevact);


            }
            reader.Close();
            conn.Close();
            conn = base.ConectarBaseDeDatos();
            for (int i = 0; i < listacaracteristicas.Count; i++)
            {

                //string sql2 = "select * from parametrosidu where REF = '" + (listacaracteristicas[i].Nombre.Trim() + nombre_sufijo).Trim() + "';";
                string sql2 = "select * from parametrosensayosidu where Parametrosensayosidu_referencia = '" + (listacaracteristicas[i].Nombre.Trim() ).Trim() + "';";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    int idparam = reader2.GetInt32("parametrosensayosidu_id");
                    listacaracteristicas[i].IdParametros = idparam;

                } 

                reader2.Close();
            }
            conn.Close();

            int i_dummy = 0;
            for (int i = 0; i < listacaracteristicas.Count; i++)
            {
                //listacaracteristicas[i].Nombre = listacaracteristicas[i].Nombre + nombre_sufijo;
                if (listacaracteristicas[i].IdParametros < 1)
                {
                    continue;
                }
                /*conn = base.ConectarBaseDeDatos();
                string str = "SELECT caracteristicastecnicasequipos_nombre FROM caracteristicastecnicasequipos where caracteristicastecnicasequipos_nombre = '" + listacaracteristicas[i].Nombre + "' and caracteristicastecnicasequipos_esidu=1;";
                MySqlCommand cmdTmp = new MySqlCommand(str, conn);
                MySqlDataReader readerTmp = cmdTmp.ExecuteReader();
                if (readerTmp.HasRows)
                { 
                    conn.Close(); 
                    continue; 
                } 
                conn.Close();
                */
                
                AgregarCaracteristicaTecnica(listacaracteristicas[i]);

            }
            
            //throw new NotImplementedException();
              
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
                oEtiqueta.EsIDU = true;
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
        public override void CargarParametrosEnDBNueva(string nombre_sufijo)
        {
            List<ParametrosEnsayoIDU> listaparametros = new List<ParametrosEnsayoIDU>();
            MySqlConnection conn = ConectarBDAnterior();
            string sql = "select * from parametrosidu;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                ParametrosEnsayoIDU paramidu = new ParametrosEnsayoIDU();
                /*paramidu.Corrientebajatensionmax = reader.GetInt32("V8") ;
                paramidu.Corrientebajatensionmin = reader.GetInt32("V7");
                paramidu.Corrientemaxmodovelalta = reader.GetInt32("V16");
                paramidu.Corrientemaxmodovelbaja =reader.GetInt32("V12") ;
                paramidu.CorrienteMinModoVelAlta =reader.GetInt32("V15") ;
                paramidu.CorrienteMinModoVelBaja =reader.GetInt32("V11") ;
                paramidu.DCFs =reader.GetInt32("DCFs") ;
                paramidu.Descripcion = reader.GetString("DESCRIPCION").Trim() + nombre_sufijo;
                paramidu.Final =reader.GetInt32("T8") ;
                paramidu.IdVersion = 1;
                paramidu.Modificado = reader.GetDateTime("MODIFICADO");
                paramidu.Referencia = reader.GetString("REF").Trim() + nombre_sufijo;
                paramidu.Retardodesenergizado =reader.GetInt32("V19") ;
                paramidu.Retardostarmitad =reader.GetInt32("T1") ;
                paramidu.Retardostart2bajatension =reader.GetInt32("T3") ;
                paramidu.Retardostopinicial =reader.GetInt32("V17") ;
                paramidu.TiempoApagadoCalorFrio =reader.GetInt32("T7") ;
                paramidu.TiempoMaximoBajaTension =reader.GetInt32("T4") ;
                paramidu.Tiempomodovelocidadalta = reader.GetInt32("T6");
                paramidu.Tiempomodovelocidadbaja =reader.GetInt32("T5") ;
                paramidu.Timeoutcalor =reader.GetInt32("V19") ;
                paramidu.Timeoutfrio =reader.GetInt32("T2") ;
                paramidu.Velocidadbajatensionmax =reader.GetInt32("V6") ; 
                paramidu.Velocidadbajatensionmin =reader.GetInt32("V5") ;
                paramidu.Velocidadmaxmodovelalta =reader.GetInt32("V14");
                paramidu.Velocidadmaxmodovelbaja =reader.GetInt32("V10") ;
                paramidu.Velocidadminmodovelalta =reader.GetInt32("V15") ;
                paramidu.Velocidadminmodovelbaja =reader.GetInt32("V9") ;
                */

                paramidu.Corrientebajatensionmax = reader.GetInt32("V8");
                paramidu.Corrientebajatensionmin = reader.GetInt32("V7");
                paramidu.Corrientemaxmodovelalta = reader.GetInt32("V16");
                paramidu.Corrientemaxmodovelbaja = reader.GetInt32("V12");
                paramidu.CorrienteMinModoVelAlta = reader.GetInt32("V15");
                paramidu.CorrienteMinModoVelBaja = reader.GetInt32("V11");
                paramidu.DCFs = reader.GetInt32("DCFs");
                paramidu.Descripcion = reader.GetString("DESCRIPCION").Trim() + nombre_sufijo;
                paramidu.Final = reader.GetInt32("T8");
                paramidu.IdVersion = 1;
                paramidu.Modificado = reader.GetDateTime("MODIFICADO");
                paramidu.Referencia = reader.GetString("REF").Trim() + nombre_sufijo;
                paramidu.Retardodesenergizado = reader.GetInt32("V19");
                paramidu.Retardostarmitad = reader.GetInt32("T1");
                paramidu.Retardostart2bajatension = reader.GetInt32("T3");
                paramidu.Retardostopinicial = reader.GetInt32("V17");
                paramidu.TiempoApagadoCalorFrio = reader.GetInt32("T7");
                paramidu.TiempoMaximoBajaTension = reader.GetInt32("T4");
                paramidu.Tiempomodovelocidadalta = reader.GetInt32("T6"); // ?
                paramidu.Tiempomodovelocidadbaja = reader.GetInt32("T5");// ?
                paramidu.Timeoutcalor = reader.GetInt32("V18");
                paramidu.Timeoutfrio = reader.GetInt32("T2");
                paramidu.Velocidadbajatensionmax = reader.GetInt32("V6");
                paramidu.Velocidadbajatensionmin = reader.GetInt32("V5");
                paramidu.Velocidadmaxmodovelalta = reader.GetInt32("V14");
                paramidu.Velocidadmaxmodovelbaja = reader.GetInt32("V10");
                paramidu.Velocidadminmodovelalta = reader.GetInt32("V13");
                paramidu.Velocidadminmodovelbaja = reader.GetInt32("V9");


                listaparametros.Add(paramidu);

            }
            reader.Close();
            //    MySqlConnection conn2 = ConectarBaseDeDatos();


            for (int i = 0; i < listaparametros.Count; i++)
            {


                GuardarParametros(listaparametros[i]);

                //   MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                //  cmd2.ExecuteNonQuery();
            }
            // conn2.Close();*/

           
        }
        public override void CargarModelosEnDBNueva(string nombre_sufijo)
        {
            MySqlConnection conn = ConectarBDAnterior();

            List<Modelo> listamodelos = new List<Modelo>();
            List<string> etiquetas = new List<string>();
            List<string> etiquetascaja = new List<string>();

            string sql = "select * from modelos;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Modelo nuevomodelo = new Modelo();
                nuevomodelo.Capacidad = reader.GetString("EXTRA2");
                nuevomodelo.Codigo = reader.GetString("CODIGO");
                nuevomodelo.CodigoICSA = reader.GetString("EXTRA3");
                nuevomodelo.Conjunto = reader.GetString("EXTRA1");
                nuevomodelo.Descripcion = reader.GetString("DESCRIPCION");
                nuevomodelo.Dimension = reader.GetString("DIMEN");
                nuevomodelo.Ean13 = reader.GetString("EAN13");
                nuevomodelo.EsIdu = true;
                // nuevomodelo.Etiqueta = ;
                // nuevomodelo.EtiquetaCaja = ;
                nuevomodelo.ID = reader.GetInt32("ID");
                nuevomodelo.Logo = reader.GetString("LOGO");
                nuevomodelo.Marca = reader.GetString("MARCA");
                nuevomodelo.Nombremodelo = reader.GetString("MODELO").Trim() + nombre_sufijo;
                nuevomodelo.Referencia = reader.GetString("REF") + nombre_sufijo;

                listamodelos.Add(nuevomodelo);
                etiquetas.Add(reader.GetString("ETIQUETA").Trim() + nombre_sufijo);
                etiquetascaja.Add(reader.GetString("ETIQCAJA").Trim() + nombre_sufijo);


            }
            reader.Close();

            MySqlConnection conn2 = ConectarBaseDeDatos();


            for (int i = 0; i < listamodelos.Count; i++)
            {


                string sql2 = "CALL usp_ObtenerEtiquetaPorNombre('" + etiquetas[i] + "')";


                int nuevaetiqueta_Id = 0;
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);

                MySqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    nuevaetiqueta_Id = reader2.GetInt32("etiquetas_id");
                }
                reader2.Close();
                if (nuevaetiqueta_Id < 1)
                    continue;
                listamodelos[i].Etiqueta = nuevaetiqueta_Id;


            }
            //reader2.Close();
            conn2.Close();

            conn2.Open();

            for (int j = 0; j < listamodelos.Count; j++)
            {

                string sql3 = "CALL usp_ObtenerEtiquetaPorNombre('" + etiquetascaja[j] + "')";
                int nuevaetiqueta2_id = 0;
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn2);

                MySqlDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    nuevaetiqueta2_id = reader3.GetInt32("etiquetas_id");
                }
                reader3.Close();

                if (nuevaetiqueta2_id < 1)
                    continue;
                listamodelos[j].EtiquetaCaja = nuevaetiqueta2_id;

            }
            conn2.Close();

            //conn2.Open();

            for (int i = 0; i < listamodelos.Count; i++)

                AgregarModelo(listamodelos[i]);


        }
        #endregion BBDD Nueva

        public override WPFiDU.CommonObjects.NumeroDeSerie ObtenerConfiguracionNumeroDeSerie(int aprobado)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                string sql = "CALL usp_ObtenerConfiguracionNumeroDeSerieIDU(" + aprobado.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                WPFiDU.CommonObjects.NumeroDeSerie ns = new WPFiDU.CommonObjects.NumeroDeSerie();
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    ns.ID = reader.GetInt32("serie_id");
                    ns.Maximo = reader.GetInt32("serie_maximo");
                    ns.Minimo = reader.GetInt32("serie_minimo");
                    ns.Numero = reader.GetInt32("serie_numero");
                    ns.Prefijo = reader.GetString("serie_prefijo");
                    ns.Sufijo = reader.GetInt32("serie_sufijo");
                    ns.Tipo = reader.GetChar("serie_tipo");


                }
                reader.Close();

                return ns;


            }
        }

        public override void AgregarEnsayo(Ensayos e)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                EnsayosIDU eidu = e as EnsayosIDU;
                string sql = "CALL usp_AgregarEnsayoIDU('" + eidu.Marca+"','"+
                    eidu.Modelo+"','"+eidu.Codigo+"','"+eidu.Serie+"','"+BaseDAO.getDate(eidu.Fecha)+"',"+
                    eidu.Aprobado.ToString()+",'"+eidu.DCF+"',"+eidu.TiempoEnsayo.ToString()+","+
                    eidu.VelocidadInicial.ToString()+","+eidu.VelocidadBajaTension.ToString()+","+
                    eidu.VelocidadLow.ToString()+","+eidu.VelocidadHigh.ToString()+","+eidu.CorrienteInicial.ToString()+","+
                    eidu.CorrienteBajaTension.ToString()+","+eidu.CorrienteLow.ToString()+","+
                    eidu.CorrienteHIGH.ToString()+","+eidu.CorrienteCalorInicial.ToString()+","+
                    eidu.Hipot.ToString()+","+eidu.Fuga.ToString()+","+eidu.Observaciones.ToString()+","+ eidu.Usuario+ ")";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }            
        }

        public override void EliminarParametros(ParametrosEnsayo parametros)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarParametrosEnsayoIDU(" + parametros.ID + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        
        public override List<ParametrosEnsayo> ObtenerParametrosEnsayo()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<ParametrosEnsayo> listaparametrosidu = new List<ParametrosEnsayo>();
                string sql = "CALL usp_ObtenerParametrosEnsayoIDU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();
                
                   
                    paridu.Corrientebajatensionmax=reader.GetInt32("parametrosensayosidu_corrientebajatensionmax");
                    paridu.Corrientebajatensionmin=reader.GetInt32("parametrosensayosidu_corrientebajatensionmin");
                    paridu.Corrientemaxmodovelalta=reader.GetInt32("parametrosensayosidu_corrientemaxmodovelalta");
                    paridu.Corrientemaxmodovelbaja=reader.GetInt32("parametrosensayosidu_corrientemaxmodovelbaja");
                    paridu.DCFs=reader.GetInt32("parametrosensayosidu_dcfs");
                    paridu.Descripcion=reader.GetString("parametrosensayosidu_descripcion");
                    paridu.Final=reader.GetInt32("parametrosensayosidu_final");
                    paridu.ID =reader.GetInt32("parametrosensayosidu_id");
                    paridu.Modificado = reader.GetDateTime("parametrosensayosidu_modificado") ;
                    paridu.Referencia = reader.GetString("parametrosensayosidu_referencia");
                    paridu.Retardodesenergizado = reader.GetInt32("parametrosensayosidu_retardodesenergizado");
                    paridu.Retardostarmitad=reader.GetInt32("parametrosensayosidu_retardostartmitad");
                    paridu.Retardostart2bajatension=reader.GetInt32("parametrosensayosidu_retardostart2bajatension");
                    paridu.Retardostopinicial=reader.GetInt32("parametrosensayosidu_retardostopinicial");
                    paridu.TiempoApagadoCalorFrio=reader.GetInt32("parametrosensayosidu_temperatura");
                    paridu.CorrienteMinModoVelAlta = reader.GetInt32("parametrosensayosidu_corrienteminmodovelalta");
                    paridu.Tiempomodovelocidadalta = reader.GetInt32("parametrosensayosidu_tiempomodovelocidadalta");
                    paridu.Tiempomodovelocidadbaja = reader.GetInt32("parametrosensayosidu_tiempomodovelocidadbaja");
                    paridu.Timeoutcalor = reader.GetInt32("parametrosensayosidu_timeoutcalor");
                    paridu.Timeoutfrio = reader.GetInt32("parametrosensayosidu_timeoutfrio");
                    paridu.Velocidadbajatensionmax = reader.GetInt32("parametrosensayosidu_velocidadbajatensionmax");
                    paridu.Velocidadbajatensionmin = reader.GetInt32("parametrosensayosidu_velocidadbajatensionmin");
                    paridu.Velocidadmaxmodovelalta = reader.GetInt32("parametrosensayosidu_velocidadmaxmodovelalta");
                    paridu.Velocidadmaxmodovelbaja = reader.GetInt32("parametrosensayosidu_velocidadmaxmodovelbaja");
                    paridu.Velocidadminmodovelalta = reader.GetInt32("parametrosensayosidu_velocidadminmodovelalta");
                    paridu.Velocidadminmodovelbaja = reader.GetInt32("parametrosensayosidu_velocidadminmodovelbaja");
                    paridu.IdVersion = reader.GetInt32("parametrosensayosidu_idversion");
                    paridu.CorrienteMinModoVelBaja = reader.GetInt32("parametrosensayosidu_corrienteminmodovelbaja");
                    paridu.TiempoMaximoBajaTension = reader.GetInt32("parametrosensayosidu_timeoutbajatension");

                    listaparametrosidu.Add(paridu);


                }

                reader.Close();
                return listaparametrosidu;
            }
        }

        public override void ModificarNumeroDeSerie(WPFiDU.CommonObjects.NumeroDeSerie ns, int aprobado)
        {
            
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ModificarNumeroDeSerieIDU(" +
                    ns.Minimo.ToString() + "," +
                    ns.Maximo.ToString() + "," +
                    ns.Sufijo.ToString() + ",'" +
                    ns.Prefijo.ToString() + "'," + aprobado.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }

        }
        
        public override List<Etiqueta> ObtenerEtiquetas()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 1;
                List<Etiqueta> nuevalista = new List<Etiqueta>();
                string sql = "CALL usp_ListarEtiquetas(" + esidu.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Etiqueta etiqueta = new Etiqueta();
                    etiqueta.Id = reader.GetInt32(0);
                    etiqueta.Nombre = reader.GetString(1);

                    nuevalista.Add(etiqueta);
                }

                reader.Close();
                return nuevalista;
            }
        }

        public override void GuardarEtiqueta(Etiqueta nuevaetiqueta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                
                try
                {
                    int esidu = 1;




                    string sql1 = "CALL usp_AgregarEtiqueta('" + nuevaetiqueta.Nombre + "'," + esidu.ToString() + ")";
                    MySqlCommand cmd = new MySqlCommand(sql1, conn );
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int ultimoid = reader.GetInt32(0);
                    reader.Close();

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
                        
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.ExecuteNonQuery();
                    }

                    
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                finally
                {
                    //TODO: que hacemos?
                }
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

                }
                reader.Close();
                return e;
            }
        }

        public override void AgregarEnsayoReimpresiones(Ensayos ens)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 1;
                int aprobado = -1;

                if (ens.Aprobado == true)
                    aprobado = 1;
                else
                    aprobado = 0;

                string sql = "CALL usp_AgregarEnsayoReimpresiones('" + ens.Marca + "','" +
                    ens.Modelo + "','" + ens.Codigo + "','" + ens.Serie + "','" + BaseDAO.getDateTime(ens.Fecha) + "'," +
                    aprobado.ToString() + ",'" + ens.Observaciones + "',"+esidu.ToString()+")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                
            }
        }

        public override List<Ensayos> ObtenerEnsayosReimpresiones()
        {
            return base.ObtenerEnsayosReimpresiones(true);
        }

        public override void GuardarParametros(ParametrosEnsayo parametros)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {            
                ParametrosEnsayoIDU nuevosparametros  = parametros as ParametrosEnsayoIDU;

                string sqlparametros = "('" + nuevosparametros.Referencia + "','" +
                    nuevosparametros.Descripcion + "'," + nuevosparametros.DCFs.ToString() + ",'" +
                    BaseDAO.getDateTime(nuevosparametros.Modificado) + "'," +
                    nuevosparametros.Retardostopinicial.ToString() + "," +
                    nuevosparametros.Retardostarmitad.ToString() + "," +
                    nuevosparametros.Timeoutcalor.ToString() + "," +
                    nuevosparametros.Timeoutfrio.ToString() + "," +
                    nuevosparametros.Retardostart2bajatension.ToString() + "," +
                    nuevosparametros.Tiempomodovelocidadbaja.ToString() + "," +
                    nuevosparametros.Tiempomodovelocidadalta.ToString() + "," +
                    nuevosparametros.Retardodesenergizado.ToString() + "," +
                    nuevosparametros.Final.ToString() + "," + nuevosparametros.TiempoApagadoCalorFrio.ToString() +
                    "," + nuevosparametros.Velocidadbajatensionmin.ToString() + "," +
                    nuevosparametros.Velocidadbajatensionmax.ToString() + "," +
                    nuevosparametros.Corrientebajatensionmin.ToString() + "," +
                    nuevosparametros.Corrientebajatensionmax.ToString() + "," +
                    nuevosparametros.Velocidadminmodovelbaja.ToString() + "," +
                    nuevosparametros.Velocidadmaxmodovelbaja.ToString() + "," +
                    nuevosparametros.CorrienteMinModoVelBaja.ToString() + "," +
                    nuevosparametros.Corrientemaxmodovelbaja.ToString() + "," +
                    nuevosparametros.Velocidadminmodovelalta.ToString() + "," +
                    nuevosparametros.Velocidadmaxmodovelalta.ToString() + "," +
                    nuevosparametros.CorrienteMinModoVelAlta.ToString() + "," +
                    nuevosparametros.Corrientemaxmodovelalta.ToString() + ","+
                    nuevosparametros.TiempoMaximoBajaTension.ToString()+","+
                    nuevosparametros.IdVersion.ToString()+")";
                    

                    
                string sql = "CALL usp_AgregarParametrosEnsayoIDU" + sqlparametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }
        
        public override List<Modelo> ObtenerModelos()
        {
            return base.ObtenerModelos(true);
        }
        
        public override List<CaracteristicasTecnicas> ObtenerCaracteristicasTecnicas()
        {
            return base.ObtenerCaracteristicasTecnicas(true);
        }

        public override List<Ensayos> ObtenerEnsayosPorFecha(DateTime desde, DateTime hasta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> ensayosiduporfecha = new List<Ensayos>();

                string parametros = "('" + BaseDAO.getDateTime(desde)+ "','" + BaseDAO.getDateTime(hasta) + "')";
                string sql = "CALL usp_ObtenerEnsayosIDUporFecha" + parametros;
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                    MySqlDataReader reader = cmd.ExecuteReader();
                    

                        while (reader.Read())
                        {
                            EnsayosIDU nuevoensayoidu = new EnsayosIDU();

                            nuevoensayoidu.ID = reader.GetInt32("ensayosrealizadosidu_id");
                            nuevoensayoidu.Marca = reader.GetString("ensayosrealizadosidu_marca");
                            nuevoensayoidu.Observaciones = reader.GetString("ensayosrealizadosidu_observaciones");
                            nuevoensayoidu.Serie = reader.GetString("ensayosrealizadosidu_serie");
                            nuevoensayoidu.TiempoEnsayo = reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
                            nuevoensayoidu.VelocidadBajaTension = reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
                            nuevoensayoidu.VelocidadHigh = reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
                            nuevoensayoidu.VelocidadInicial = reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
                            nuevoensayoidu.VelocidadLow = reader.GetFloat("ensayosrealizadosidu_velocidadlow");
                            nuevoensayoidu.Hipot = reader.GetString("ensayosrealizadosidu_hipot");
                            nuevoensayoidu.Fuga = reader.GetString("ensayosrealizadosidu_fuga");
                            nuevoensayoidu.Fecha = reader.GetDateTime("ensayosrealizadosidu_fecha");
                            nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf");
                            nuevoensayoidu.CorrienteLow = reader.GetFloat("ensayosrealizadosidu_corrientelow");
                            nuevoensayoidu.CorrienteInicial = reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
                            nuevoensayoidu.CorrienteCalorInicial = reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
                            nuevoensayoidu.CorrienteBajaTension = reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
                            nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo");
                            nuevoensayoidu.Modelo = reader.GetString("ensayosrealizadosidu_modelo");
                            nuevoensayoidu.CorrienteHIGH = reader.GetFloat("ensayosrealizadosidu_corrientehigh");
                            nuevoensayoidu.Usuario = reader.GetString("ensayosrealizadosidu_usuario");

                            if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                            {

                                nuevoensayoidu.Aprobado = true;
                            }
                            else
                            {
                                nuevoensayoidu.Aprobado = false;
                            }

                            ensayosiduporfecha.Add(nuevoensayoidu);
                        }

                        reader.Close();
                        return ensayosiduporfecha;
                    
                
            }
        }

        public override void ObtenerNroSerieAgregarEnsayo(Ensayos e,string argScannedSerialNumber)
        {
            EnsayosIDU eidu = e as EnsayosIDU;
            eidu.Fuga = "OK";
            eidu.Hipot = "OK";
          
            eidu.Observaciones = "ninguna";

            eidu.DCF = System.Environment.MachineName;

            //init trans


            //ObtenerCaracteristicasTecnicas nro serie llamada al sp
            //guardar llamada al sp
            //commit rollback

            int aprobado = 0;

            if (eidu.Aprobado == true)
                aprobado = 1;

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sql = "CALL usp_ObtenerNumeroSerieAprobadoIDU(" + aprobado.ToString() + ")";
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
                    eidu.Serie = numserie;


                     //eidu.Aprobado.ToString()
                    string sql2 = "CALL usp_AgregarEnsayoIDU_EX('" + eidu.Marca + "','" +
                        eidu.Modelo + "','" + eidu.Codigo + "','" + eidu.Serie + "','" + BaseDAO.getDateTime(eidu.Fecha) + "'," +
                        aprobado.ToString() + ",'" + eidu.DCF + "'," + eidu.TiempoEnsayo.ToString() + "," +
                        eidu.VelocidadInicial.ToString() + "," + eidu.VelocidadBajaTension.ToString() + "," +
                        eidu.VelocidadLow.ToString() + "," + eidu.VelocidadHigh.ToString() + "," + eidu.CorrienteInicial.ToString() + "," +
                        eidu.CorrienteBajaTension.ToString() + "," + eidu.CorrienteLow.ToString() + "," +
                        eidu.CorrienteHIGH.ToString() + "," + eidu.CorrienteCalorInicial.ToString() + ",'" +
                        eidu.Hipot.ToString() + "','" + eidu.Fuga.ToString() + "','" + eidu.Observaciones.ToString()
                        + "','" + eidu.Usuario + "','" + eidu.OrdenFabricacion+ "')";


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

        public override void ModificarParametrosEnsayo(ParametrosEnsayo parametrosviejos, ParametrosEnsayo parametrosnuevos )
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                ParametrosEnsayoIDU paridu = parametrosnuevos as ParametrosEnsayoIDU;

                string sql = "CALL usp_ModificarParametrosEnsayoIDU(" + parametrosviejos.ID + ",'" +
                    parametrosviejos.Referencia + "','" + paridu.Descripcion + "'," + paridu.DCFs + ",'" + BaseDAO.getDateTime(paridu.Modificado) + "'," +
                    paridu.Retardostopinicial + "," + paridu.Retardostarmitad + "," + paridu.Timeoutcalor + "," +
                    paridu.Timeoutfrio + "," + paridu.Retardostart2bajatension + "," + paridu.Tiempomodovelocidadbaja + "," +
                    paridu.Tiempomodovelocidadalta + "," + paridu.Retardodesenergizado + "," +
                    paridu.Final + "," + paridu.TiempoApagadoCalorFrio + "," + paridu.Velocidadbajatensionmin + "," +
                    paridu.Velocidadbajatensionmax + "," + paridu.Corrientebajatensionmin + "," +
                    paridu.Corrientebajatensionmax + "," + paridu.Velocidadminmodovelbaja + "," +
                    paridu.Velocidadmaxmodovelbaja + "," + paridu.CorrienteMinModoVelBaja + "," +
                    paridu.Corrientemaxmodovelbaja + "," + paridu.Velocidadminmodovelalta + "," +
                    paridu.Velocidadmaxmodovelalta + "," + paridu.CorrienteMinModoVelAlta + "," +
                    paridu.Corrientemaxmodovelalta +","+ paridu.TiempoMaximoBajaTension+","+
                    paridu.IdVersion+
                    ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public override ParametrosEnsayo LeerParametrosDeBaseDeDatosPorId(int identificacion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                ParametrosEnsayoIDU paridu = new ParametrosEnsayoIDU();

                string sql = "CALL usp_ObtenerParametrosEnsayoIDUporID(" + identificacion.ToString() + ")";
                //sql = "SELECT * from Parametrosensayosidu where Parametrosensayosidu_id = " + identificacion.ToString() + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    paridu.Corrientebajatensionmax = reader.GetInt32("parametrosensayosidu_corrientebajatensionmax");
                    paridu.Corrientebajatensionmin = reader.GetInt32("parametrosensayosidu_corrientebajatensionmin");
                    paridu.Corrientemaxmodovelalta = reader.GetInt32("parametrosensayosidu_corrientemaxmodovelalta");
                    paridu.Corrientemaxmodovelbaja = reader.GetInt32("parametrosensayosidu_corrientemaxmodovelbaja");
                    paridu.DCFs = reader.GetInt32("parametrosensayosidu_dcfs");
                    paridu.Descripcion = reader.GetString("parametrosensayosidu_descripcion");
                    paridu.Final = reader.GetInt32("parametrosensayosidu_final");
                    paridu.ID = reader.GetInt32("parametrosensayosidu_id");
                    paridu.Modificado = reader.GetDateTime("parametrosensayosidu_modificado");
                    paridu.Referencia = reader.GetString("parametrosensayosidu_referencia");
                    paridu.Retardodesenergizado = reader.GetInt32("parametrosensayosidu_retardodesenergizado");
                    paridu.Retardostarmitad = reader.GetInt32("parametrosensayosidu_retardostartmitad");
                    paridu.Retardostart2bajatension = reader.GetInt32("parametrosensayosidu_retardostart2bajatension");
                    paridu.Retardostopinicial = reader.GetInt32("parametrosensayosidu_retardostopinicial");
                    paridu.TiempoApagadoCalorFrio = reader.GetInt32("parametrosensayosidu_temperatura");
                    paridu.CorrienteMinModoVelAlta = reader.GetInt32("parametrosensayosidu_corrienteminmodovelalta");
                    paridu.Tiempomodovelocidadalta = reader.GetInt32("parametrosensayosidu_tiempomodovelocidadalta");
                    paridu.Tiempomodovelocidadbaja = reader.GetInt32("parametrosensayosidu_tiempomodovelocidadbaja");
                    paridu.Timeoutcalor = reader.GetInt32("parametrosensayosidu_timeoutcalor");
                    paridu.Timeoutfrio = reader.GetInt32("parametrosensayosidu_timeoutfrio");
                    paridu.Velocidadbajatensionmax = reader.GetInt32("parametrosensayosidu_velocidadbajatensionmax");
                    paridu.Velocidadbajatensionmin = reader.GetInt32("parametrosensayosidu_velocidadbajatensionmin");
                    paridu.Velocidadmaxmodovelalta = reader.GetInt32("parametrosensayosidu_velocidadmaxmodovelalta");
                    paridu.Velocidadmaxmodovelbaja = reader.GetInt32("parametrosensayosidu_velocidadmaxmodovelbaja");
                    paridu.Velocidadminmodovelalta = reader.GetInt32("parametrosensayosidu_velocidadminmodovelalta");
                    paridu.Velocidadminmodovelbaja = reader.GetInt32("parametrosensayosidu_velocidadminmodovelbaja");
                    paridu.IdVersion = reader.GetInt32("parametrosensayosidu_idversion");
                    paridu.CorrienteMinModoVelBaja = reader.GetInt32("parametrosensayosidu_corrienteminmodovelbaja");
                    paridu.TiempoMaximoBajaTension = reader.GetInt32("parametrosensayosidu_timeoutbajatension");

                    

                }

                reader.Close();
                return paridu;


            }
        }
        
        public override List<Ensayos> ObtenerEnsayosAprobados(DateTime actual)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> ListaEnsayos = new List<Ensayos>();

                string Parametros = "('" + BaseDAO.getDate(actual) + "')";
                string sql = "CALL usp_VerAprobadosDelDiaIDU" + Parametros;
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    EnsayosIDU nuevoensayoidu = new EnsayosIDU();

                    if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                    {
                        nuevoensayoidu.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayoidu.Aprobado = false;
                    }

                    nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo"); 
                    nuevoensayoidu.CorrienteBajaTension=reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
                    nuevoensayoidu.CorrienteCalorInicial=reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
                    nuevoensayoidu.CorrienteHIGH=reader.GetFloat("ensayosrealizadosidu_corrientehigh");
                    nuevoensayoidu.CorrienteInicial=reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
                    nuevoensayoidu.CorrienteLow=reader.GetFloat("ensayosrealizadosidu_corrientelow");
                    nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf"); 
                    nuevoensayoidu.Fecha=reader.GetDateTime("ensayosrealizadosidu_fecha");
                    nuevoensayoidu.Fuga=reader.GetString("ensayosrealizadosidu_fuga");
                    nuevoensayoidu.Hipot=reader.GetString("ensayosrealizadosidu_hipot");
                    nuevoensayoidu.ID=reader.GetInt32("ensayosrealizadosidu_id");
                    nuevoensayoidu.Marca=reader.GetString("ensayosrealizadosidu_marca");
                    nuevoensayoidu.Modelo=reader.GetString("ensayosrealizadosidu_modelo");
                    nuevoensayoidu.Observaciones=reader.GetString("ensayosrealizadosidu_observaciones");
                    nuevoensayoidu.Serie=reader.GetString("ensayosrealizadosidu_serie");
                    nuevoensayoidu.TiempoEnsayo=reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
                    nuevoensayoidu.VelocidadBajaTension=reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
                    nuevoensayoidu.VelocidadHigh=reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
                    nuevoensayoidu.VelocidadInicial=reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
                    nuevoensayoidu.VelocidadLow=reader.GetFloat("ensayosrealizadosidu_velocidadlow");
                    ListaEnsayos.Add(nuevoensayoidu);
                }

                reader.Close();
                return ListaEnsayos;
            }

        }
        
        public override void ModificarObservacion(Ensayos e,string nuevaobservacion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string Parametros = "('" + nuevaobservacion + "'," + e.ID.ToString() + ")";
                string sql = "CALL usp_ModificarObservacionIDU" + Parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }            
        }
        
        public override List<Ensayos> ObtenerEnsayosFallados(DateTime actual)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<Ensayos> ListaEnsayos = new List<Ensayos>();
               
                string Parametros = "('" + BaseDAO.getDate(actual) + "')";
                string sql = "CALL usp_VerFallasDelDiaIDU" + Parametros;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    EnsayosIDU nuevoensayoidu = new EnsayosIDU();

                    if (reader.GetInt32("ensayosrealizadosidu_aprobado") == 1)
                    {
                        nuevoensayoidu.Aprobado = true;
                    }
                    else
                    {
                        nuevoensayoidu.Aprobado = false;
                    }

                    nuevoensayoidu.Codigo = reader.GetString("ensayosrealizadosidu_codigo");
                    nuevoensayoidu.CorrienteBajaTension = reader.GetFloat("ensayosrealizadosidu_corrientebajatension");
                    nuevoensayoidu.CorrienteCalorInicial = reader.GetFloat("ensayosrealizadosidu_corrientecalorinicial");
                    nuevoensayoidu.CorrienteHIGH = reader.GetFloat("ensayosrealizadosidu_corrientehigh");
                    nuevoensayoidu.CorrienteInicial = reader.GetFloat("ensayosrealizadosidu_corrienteinicial");
                    nuevoensayoidu.CorrienteLow = reader.GetFloat("ensayosrealizadosidu_corrientelow");
                    nuevoensayoidu.DCF = reader.GetString("ensayosrealizadosidu_dcf");
                    nuevoensayoidu.Fecha = reader.GetDateTime("ensayosrealizadosidu_fecha");
                    nuevoensayoidu.Fuga = reader.GetString("ensayosrealizadosidu_fuga");
                    nuevoensayoidu.Hipot = reader.GetString("ensayosrealizadosidu_hipot");
                    nuevoensayoidu.ID = reader.GetInt32("ensayosrealizadosidu_id");
                    nuevoensayoidu.Marca = reader.GetString("ensayosrealizadosidu_marca");
                    nuevoensayoidu.Modelo = reader.GetString("ensayosrealizadosidu_modelo");
                    nuevoensayoidu.Observaciones = reader.GetString("ensayosrealizadosidu_observaciones");
                    nuevoensayoidu.Serie = reader.GetString("ensayosrealizadosidu_serie");
                    nuevoensayoidu.TiempoEnsayo = reader.GetInt32("ensayosrealizadosidu_tiempoensayo");
                    nuevoensayoidu.VelocidadBajaTension = reader.GetFloat("ensayosrealizadosidu_velocidadbajatension");
                    nuevoensayoidu.VelocidadHigh = reader.GetFloat("ensayosrealizadosidu_velocidadhigh");
                    nuevoensayoidu.VelocidadInicial = reader.GetFloat("ensayosrealizadosidu_velocidadinicial");
                    nuevoensayoidu.VelocidadLow = reader.GetFloat("ensayosrealizadosidu_velocidadlow");
                    ListaEnsayos.Add(nuevoensayoidu);
                }

                reader.Close();
                return ListaEnsayos;
            }
        }

        public override int EliminarFallas()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarFallasIDU()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                return i;
            }
        }

    }
}
