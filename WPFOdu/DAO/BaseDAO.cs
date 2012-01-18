using System;
using System.Collections.Generic;
using System.Text;
using iDU.CommonObjects;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using WPFiDU.CommonObjects;

namespace iDU.DAO
{

    public abstract class BaseDAO //:IDisposable
    {
        #region Conexion

        protected MySqlConnection ConectarBaseDeDatos()
        {
            string connStr = ConfigurationManager.AppSettings["DDBBConnString"];//"server=localhost;uid=root;pwd=root;database=iduodudiventi";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        private static MySqlConnection ConectarBaseDeDatosEx()
        {
            string connStr = ConfigurationManager.AppSettings["DDBBConnString"];//"server=localhost;uid=root;pwd=root;database=iduodudiventi";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static void cleanEtiquetas() 
        {
            MySqlConnection connNew = BaseDAO.ConectarBaseDeDatosEx();
            string sqlNew = "delete from componentesetiquetas ;";
            sqlNew += "delete from etiquetas ;";
            MySqlCommand cmdNEW = new MySqlCommand(sqlNew, connNew);
            cmdNEW.ExecuteNonQuery();
            cmdNEW.Dispose();
            try { connNew.Close(); }
            catch { }
        }

        public static void cleanModelos() 
        {
            MySqlConnection connNew = BaseDAO.ConectarBaseDeDatosEx();
            string sqlNew = "delete from modelos;";
            MySqlCommand cmdNEW = new MySqlCommand(sqlNew, connNew);
            cmdNEW.ExecuteNonQuery();
            cmdNEW.Dispose();
            try { connNew.Close(); }
            catch { }
        }

        public static void cleanParametros() 
        {
            MySqlConnection connNew = BaseDAO.ConectarBaseDeDatosEx();
            string sqlNew = "delete from parametrosensayosidu ;";
            sqlNew += "delete from parametrosensayosodu ;";
            MySqlCommand cmdNEW = new MySqlCommand(sqlNew, connNew);
            cmdNEW.ExecuteNonQuery();
            cmdNEW.Dispose();
            try { connNew.Close(); }
            catch { }
        }

        public static void cleanCaracteristicasTecnicasEquipos()
        {
            MySqlConnection connNew = BaseDAO.ConectarBaseDeDatosEx();
            string sqlNew = "delete from caracteristicastecnicasequipos ;";
            MySqlCommand cmdNEW = new MySqlCommand(sqlNew, connNew);
            cmdNEW.ExecuteNonQuery();
            cmdNEW.Dispose();
            try { connNew.Close(); }
            catch { }
        }


        public static void setOldDB(string name) 
        {
            OldConnStr = "server=localhost;uid=root;pwd=248;database=" + name;
        }

        private static string OldConnStr = "server=localhost;uid=root;pwd=248;database=carrierodu";

        public MySqlConnection ConectarBDAnterior()
        {
            //string connStr = "server=localhost;uid=root;pwd=248;database=carrieridu";
            //string connStr = "server=localhost;uid=root;pwd=248;database=carrieridu_bkp";
            //string connStr = "server=localhost;uid=root;pwd=248;database=carrierodu";
            //string connStr = "server=localhost;uid=root;pwd=248;database=carrierodu_bkp"; 
            MySqlConnection conn = new MySqlConnection(BaseDAO.OldConnStr);
            conn.Open();
            return conn;

        }

        
        #endregion 
        #region Etiquetas


       /* public void GuardarEtiqueta(Etiqueta nuevaetiqueta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int esidu = -1;

                    if(nuevaetiqueta.EsIDU ==false)
                        esidu=0;
                    else
                        esidu=1;


                    string sql1 = "CALL usp_AgregarEtiqueta('" + nuevaetiqueta.Nombre + "',"+esidu.ToString()+")";
                    MySqlCommand cmd = new MySqlCommand(sql1, conn, trans);
                    int ultimoid = cmd.ExecuteNonQuery();

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
                            nuevaetiqueta.Componentes[i].Param.ToString() + "," +
                            ultimoid.ToString() + ")";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn, trans);
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                finally
                {
                    //TODO: que hacemos?
                }
            }
        }*/
        public abstract void  GuardarEtiqueta(Etiqueta NuevaEtiqueta);
        public abstract List<Etiqueta> ObtenerEtiquetas();
        public abstract Etiqueta ObtenerEtiqueta(int IDEtiqueta);
        public abstract bool ObtenerPrioridadFalla(int codigo);
        public abstract Ensayos ObtenerUltimoEnsayo();
      


        public string ObtenerUsuario(string password)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {

                string sql = "CALL usp_ObtenerUsuario('" + password + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                string usuario = (string)cmd.ExecuteScalar();
                return usuario;

            }

        }

      /*  public List<Etiqueta> ObtenerEtiquetasConComponentes()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())();

            List<Etiqueta> nuevalista = new List<Etiqueta>();
            string sql = "CALL usp_ListarEtiquetas()";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Etiqueta etiqueta = new Etiqueta();
                etiqueta.Id = reader.GetInt32(0);
                etiqueta.Nombre = reader.GetString(1);

                //try { etiqueta.Componentes = ObtenerComponentesEtiquetas(etiqueta.Nombre,false); }
                //catch { }

                nuevalista.Add(etiqueta);
            }

            reader.Close();
            Desusing (MySqlConnection conn = ConectarBaseDeDatos())();
            return nuevalista;


        }*/

   /*     public List<Etiqueta> ObtenerEtiquetasConComponentes()
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())();
            List<Etiqueta> nuevalista = new List<Etiqueta>();
            string sql = "CALL usp_ObtenerEtiquetasConComponentes()";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {

                Etiqueta nuevaetiqueta = new Etiqueta();
                nuevaetiqueta.Id =reader.GetInt32(0);
                nuevaetiqueta.Nombre=reader.GetString(1);

        }*/

        public abstract void ObtenerNroSerieAgregarEnsayo(Ensayos e, string argScannedSerialNumber);

        public abstract void AgregarEnsayoReimpresiones(Ensayos ens);


        public abstract string ObtenerDescripcionFalla(Ensayos e);
      


        

        public void CambiarNombreEtiqueta(Etiqueta e,string nuevonombre)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_CambiarNombreEtiqueta(" + e.Id.ToString() + ",'" + nuevonombre + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Es el que se usaba antes para solo obtener ensayo nrode serie.
        /// </summary>
        /// <param name="aprobado"></param>
        /// <returns></returns>
        public string ObtenerNumeroDeSerie(int aprobado)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                MySqlTransaction trans = conn.BeginTransaction();


                try
                {

                    string sql = "CALL usp_ObtenerNumeroSerieAprobado(" + aprobado.ToString() + ")";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    reader.NextResult();
                    reader.Read();
                    string numserie = reader.GetString(0);
                    reader.Close();

                    trans.Commit();


                    return numserie;

                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    throw ex;
                }
            }

        }


        public abstract NumeroDeSerie ObtenerConfiguracionNumeroDeSerie(int aprobado);
        
        
        public abstract void ModificarNumeroDeSerie(NumeroDeSerie ns , int aprobado);

       

    

        public void SetearPasswordUsuario(string nuevopassword,string descripcion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_SetearPassWordUsuario('" + nuevopassword + "','" +
                    descripcion + "')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
        
        }

        public string ObtenerPasswordUsuario(string descripcion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_ObtenerPasswordUsuario('" + descripcion + "')";
                MySqlCommand cmd= new MySqlCommand(sql, conn);

                string password = (string)cmd.ExecuteScalar();



                return password;

                

            }

        }

        public abstract List<Ensayos> ObtenerEnsayosReimpresiones();
        
        protected List<Ensayos> ObtenerEnsayosReimpresiones(bool idu)
        {

            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 1;

                if (idu == false)
                {
                    esidu = 0;
                }

                List<Ensayos> listaensayos = new List<Ensayos>();
                string sql = "CALL usp_ObtenerEnsayosReimpresiones("+esidu.ToString()+")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {

                    Ensayos nuevoensayo = new Ensayos();
                    nuevoensayo.ID =reader.GetInt32("reimpresiones_id");
                    nuevoensayo.Marca=reader.GetString("reimpresiones_marca");
                    nuevoensayo.Modelo=reader.GetString("reimpresiones_modelo");
                    nuevoensayo.Observaciones=reader.GetString("reimpresiones_observaciones");
                    nuevoensayo.Serie=reader.GetString("reimpresiones_serie");
                    nuevoensayo.Fecha=reader.GetDateTime("reimpresiones_fecha");
                    listaensayos.Add(nuevoensayo);

                }
                reader.Close();
                return listaensayos;
            }

        }


        public abstract void CargarModelosEnDBNueva(string nombre_sufijo);
        public abstract void CargarParametrosEnDBNueva(string nombre_sufijo);
        public abstract void CargarReferenciasEnDBNueva(string nombre_sufijo);

        public List<EtiquetaItem> ObtenerComponentesEtiquetas(string etiqueta)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                List<EtiquetaItem> nuevalista = new List<EtiquetaItem>();
                string sql = "CALL usp_ObtenerComponentesEtiquetas";
                string param = etiqueta;
                sql = sql + "('" + param + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EtiquetaItem etiquetaitem = new EtiquetaItem();
                    etiquetaitem.ID = reader.GetInt32("Componentesetiquetas_id");
                    etiquetaitem.Font = reader.GetString("Componentesetiquetas_font");
                    etiquetaitem.Size = reader.GetFloat("Componentesetiquetas_size");
                    etiquetaitem.Bold = reader.GetInt32("Componentesetiquetas_bold");
                    etiquetaitem.Italic = reader.GetInt32("Componentesetiquetas_italic");
                    etiquetaitem.NumeroEtiqueta = reader.GetInt32("Componentesetiquetas_numeroetiqueta");
                    etiquetaitem.Param = reader.GetString("Componentesetiquetas_param");
                    etiquetaitem.Tipo = reader.GetInt32("Componentesetiquetas_tipo");
                    etiquetaitem.Variable = reader.GetInt32("Componentesetiquetas_variable");
                    etiquetaitem.Xfinal = reader.GetDouble("Componentesetiquetas_xfinal");
                    etiquetaitem.Xinicial = reader.GetDouble("Componentesetiquetas_xinicial");
                    etiquetaitem.Yfinal = reader.GetDouble("Componentesetiquetas_yfinal");
                    etiquetaitem.Yinicial = reader.GetDouble("Componentesetiquetas_yinicial");
                    etiquetaitem.Alignh = reader.GetInt32("Componentesetiquetas_alignh");
                    etiquetaitem.Alignv = reader.GetInt32("Componentesetiquetas_alignv");



                    nuevalista.Add(etiquetaitem);
                }

                reader.Close();
                return nuevalista;
            }

        }

     //   public abstract void ObtenerEtiquetasDBAnterior();
        #endregion
        #region Modelos

        public void AgregarModelo(Modelo m)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "";
                string parametros = "('";
                parametros += m.Marca + "','" + m.Nombremodelo + "','" + m.Codigo + "','"
                + m.Referencia + "','" + m.Ean13 + "'," + m.Etiqueta.ToString() + ","
                + m.EtiquetaCaja.ToString() + ",'" + m.Logo + "','" + m.Conjunto + "','" + m.Capacidad
                + "','" + m.CodigoICSA + "','" + m.Descripcion + "','" + m.Dimension + "',"
                + (m.EsIdu ? "1" : "0") + ")";

                sql = "CALL usp_AgregarModelo " + parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

   


        public void ModificarModelo(Modelo m)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "";
                string parametros = "('";
                parametros = parametros + m.ID + "','" + m.Marca + "','" + m.Nombremodelo + "','" + m.Codigo + "','"
                + m.Referencia + "','" + m.Ean13 + "'," + m.Etiqueta.ToString() + ","
                + m.EtiquetaCaja.ToString() + ",'" + m.Logo + "','" + m.Conjunto + "','" + m.Capacidad
                + "','" + m.CodigoICSA + "','" + m.Descripcion + "','" + m.Dimension + "',"
                + (m.EsIdu ? "1" : "0") + ")";
                sql = "CALL usp_ModificarModelo " + parametros;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }


        public int EliminarModelo(Modelo m)
        {
            int afectadas = 0;
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarModelo(" + m.ID.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                afectadas = cmd.ExecuteNonQuery();
                return afectadas;
            }
        }

        public abstract List<Modelo> ObtenerModelos();
        protected List<Modelo> ObtenerModelos(bool idu)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 1;

                if (idu == false)
                {
                    esidu = 0;
                }

                List<Modelo> nuevalista = new List<Modelo>();
                string sql = "CALL usp_ObtenerModelos(" + esidu.ToString() + ")";

                //sql = "select modelos_id,modelos_marca,modelos_modelo,modelos_codigo,modelos_referencia,modelos_ean13,modelos_etiqueta,modelos_etiquetacaja,modelos_logo,modelos_conjunto,modelos_capacidad,modelos_codigoicsa,modelos_descripcion,modelos_dimensiones,modelos_esidu, background_bulto,background_producto from modelos where modelos_esidu=0 and es_activo = 1 ORDER BY modelos_modelo ASC;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Modelo nuevomodelo = new Modelo();
                    nuevomodelo.ID = reader.GetInt32("modelos_id");
                    nuevomodelo.Marca = reader.GetString("modelos_marca");
                    nuevomodelo.Nombremodelo = reader.GetString("modelos_modelo");
                    nuevomodelo.Referencia = reader.GetString("modelos_referencia");
                    nuevomodelo.Ean13 = reader.GetString("modelos_ean13");
                    nuevomodelo.Etiqueta = reader.GetInt32("modelos_etiqueta");
                    nuevomodelo.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
                    nuevomodelo.Logo = reader.GetString("modelos_logo");
                    nuevomodelo.Conjunto = reader.GetString("modelos_conjunto");
                    nuevomodelo.Capacidad = reader.GetString("modelos_capacidad");
                    nuevomodelo.Codigo = reader.GetString("modelos_codigo");
                    nuevomodelo.Descripcion = reader.GetString("modelos_descripcion");
                    nuevomodelo.Dimension = reader.GetString("modelos_dimensiones");
                    nuevomodelo.BackgroundBulto = reader.GetString("background_bulto");
                    nuevomodelo.BackgroundProducto= reader.GetString("background_producto");


                    if (reader.GetInt32("modelos_esidu") == 1)
                    {
                        nuevomodelo.EsIdu = true;
                    }
                    else
                    {
                        nuevomodelo.EsIdu = false;
                    }


                    nuevomodelo.CodigoICSA = reader.GetString("modelos_codigoicsa");
                    nuevalista.Add(nuevomodelo);
                }

                reader.Close();
                return nuevalista;
            }

        }


        public Modelo ObtenerModeloPorNombre(string modelo)
        {
          //using (MySqlConnection conn = ConectarBaseDeDatos())
          //{
          //    string sql = "CALL usp_ObtenerModeloPorNombre('" + modelo + "')";
          //    MySqlCommand cmd = new MySqlCommand(sql, conn);
          //    MySqlDataReader reader = cmd.ExecuteReader();
          //    Modelo m = new Modelo();

          //    while (reader.Read())
          //    {

          //        m.Capacidad = reader.GetString("modelos_capacidad");
          //        m.Codigo = reader.GetString("modelos_codigo");
          //        m.CodigoICSA = reader.GetString("modelos_codigoicsa");
          //        m.Conjunto = reader.GetString("modelos_conjunto");
          //        m.Descripcion = reader.GetString("modelos_descripcion");
          //        m.Dimension = reader.GetString("modelos_dimensiones");
          //        m.Ean13 = reader.GetString("modelos_ean13");

          //        if (reader.GetInt32("modelos_esidu") == 1)
          //            m.EsIdu = true;
          //        else
          //            m.EsIdu = false;

          //        m.Etiqueta = reader.GetInt32("modelos_etiqueta");
          //        m.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
          //        m.ID = reader.GetInt32("modelos_id");
          //        m.Logo = reader.GetString("modelos_logo");
          //        m.Marca = reader.GetString("modelos_marca");
          //        m.Nombremodelo = reader.GetString("modelos_modelo");
          //        m.Referencia = reader.GetString("modelos_referencia");

          //    }

          //    reader.Close();
          //    return m;
          //}

          using (MySqlConnection conn = ConectarBaseDeDatos())
          {
            string sql = "select * from modelos where modelos_modelo = '" + modelo.Trim() + "' and es_activo=1;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            Modelo m = new Modelo();

            while (reader.Read())
            {

              m.ID = reader.GetInt32("modelos_id");
              m.Marca = reader.GetString("modelos_marca");
              m.Nombremodelo = reader.GetString("modelos_modelo");
              m.Referencia = reader.GetString("modelos_referencia");
              m.Ean13 = reader.GetString("modelos_ean13");
              m.Etiqueta = reader.GetInt32("modelos_etiqueta");
              m.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
              m.Logo = reader.GetString("modelos_logo");
              m.Conjunto = reader.GetString("modelos_conjunto");
              m.Capacidad = reader.GetString("modelos_capacidad");
              m.Codigo = reader.GetString("modelos_codigo");
              m.Descripcion = reader.GetString("modelos_descripcion");
              m.Dimension = reader.GetString("modelos_dimensiones");
              m.BackgroundBulto = reader.GetString("background_bulto");
              m.BackgroundProducto = reader.GetString("background_producto");


              if (reader.GetInt32("modelos_esidu") == 1)
              {
                m.EsIdu = true;
              }
              else
              {
                m.EsIdu = false;
              }


              m.CodigoICSA = reader.GetString("modelos_codigoicsa");

            }

            reader.Close();
            return m;
          }
        }
       
        public Modelo ObtenerModeloPorId(int modeloId)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "select * from modelos where modelos_id = " + modeloId.ToString() + " and es_activo=1;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                Modelo m = new Modelo();

                while (reader.Read())
                {

                    //m.Capacidad = reader.GetString("modelos_capacidad");
                    //m.Codigo = reader.GetString("modelos_codigo");
                    //m.CodigoICSA = reader.GetString("modelos_codigoicsa");
                    //m.Conjunto = reader.GetString("modelos_conjunto");
                    //m.Descripcion = reader.GetString("modelos_descripcion");
                    //m.Dimension = reader.GetString("modelos_dimensiones");
                    //m.Ean13 = reader.GetString("modelos_ean13");

                    //if (reader.GetInt32("modelos_esidu") == 1)
                    //    m.EsIdu = true;
                    //else
                    //    m.EsIdu = false;

                    //m.Etiqueta = reader.GetInt32("modelos_etiqueta");
                    //m.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
                    //m.ID = reader.GetInt32("modelos_id");
                    //m.Logo = reader.GetString("modelos_logo");
                    //m.Marca = reader.GetString("modelos_marca");
                    //m.Nombremodelo = reader.GetString("modelos_modelo");
                    //m.Referencia = reader.GetString("modelos_referencia");
                    //m.BackgroundBulto = reader.GetString("background_bulto");
                    //m.BackgroundProducto = reader.GetString("background_producto");

                    m.ID = reader.GetInt32("modelos_id");
                    m.Marca = reader.GetString("modelos_marca");
                    m.Nombremodelo = reader.GetString("modelos_modelo");
                    m.Referencia = reader.GetString("modelos_referencia");
                    m.Ean13 = reader.GetString("modelos_ean13");
                    m.Etiqueta = reader.GetInt32("modelos_etiqueta");
                    m.EtiquetaCaja = reader.GetInt32("modelos_etiquetacaja");
                    m.Logo = reader.GetString("modelos_logo");
                    m.Conjunto = reader.GetString("modelos_conjunto");
                    m.Capacidad = reader.GetString("modelos_capacidad");
                    m.Codigo = reader.GetString("modelos_codigo");
                    m.Descripcion = reader.GetString("modelos_descripcion");
                    m.Dimension = reader.GetString("modelos_dimensiones");
                    m.BackgroundBulto = reader.GetString("background_bulto");
                    m.BackgroundProducto = reader.GetString("background_producto");


                    if (reader.GetInt32("modelos_esidu") == 1)
                    {
                      m.EsIdu = true;
                    }
                    else
                    {
                      m.EsIdu = false;
                    }


                    m.CodigoICSA = reader.GetString("modelos_codigoicsa");
                }

                reader.Close();
                return m;
            }
        }
        
        
        #endregion
        #region Ensayos

        public abstract List<Ensayos> ObtenerEnsayosPorFecha(DateTime desde, DateTime hasta);
        public abstract List<Ensayos> ObtenerEnsayosAprobados(DateTime actual);
        public abstract List<Ensayos> ObtenerEnsayosFallados(DateTime actual);
        public abstract int EliminarFallas();
        public abstract void ModificarObservacion(Ensayos e, string nuevaobservacion);
        public abstract void AgregarEnsayo(Ensayos e);

        public bool IsAvailableSerialNumber(string serialNumber, bool esIdu)
        {
          using (MySqlConnection conn = ConectarBaseDeDatos())
          {
            string sql = "select count(*) from ensayosrealizadosidu where ensayosrealizadosidu_serie = '" + serialNumber.Trim() + "' and ensayosrealizadosidu_aprobado=1;";
            if (!esIdu)
              sql = "select count(*) from ensayosrealizadosodu where ensayosrealizadosodu_serie = '" + serialNumber.Trim() + "' and ensayosrealizadosodu_aprobado=1;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            Object obj = cmd.ExecuteScalar();
            bool isAvailable = Convert.ToInt32(obj) < 1;

            cmd.Dispose();
            return isAvailable;
          }
        }
        #endregion
        #region ParametrosEnsayo
        public abstract List<ParametrosEnsayo> ObtenerParametrosEnsayo();
        public abstract void GuardarParametros(ParametrosEnsayo parametros);
        public abstract void EliminarParametros(ParametrosEnsayo parametros);
        public abstract void ModificarParametrosEnsayo(ParametrosEnsayo parametrosviejos, ParametrosEnsayo parametrosnuevos);
        public abstract ParametrosEnsayo LeerParametrosDeBaseDeDatosPorId(int identificacion);

        #endregion
        #region CaracteristicasTecnicas

        public CaracteristicasTecnicas ObtenerCaracteristicaTecnicaDeModelo(Modelo m)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                CaracteristicasTecnicas nuevacaracteristica = new CaracteristicasTecnicas();
                //string sql = "CALL usp_ObtenerCaracteristicaTecnicaDeModelo ('" + m.Referencia + "')";
                
                string sql = "SELECT * from caracteristicastecnicasequipos " ;
                if (m.EsIdu)
                    sql += "where caracteristicastecnicasequipos_nombre = '" + m.Referencia 
                      + "' and caracteristicastecnicasequipos_esidu = 1;";
                else
                    sql += "where caracteristicastecnicasequipos_nombre = '" + m.Referencia
                      + "' and caracteristicastecnicasequipos_esidu = 0;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    nuevacaracteristica.ID = reader.GetInt32("caracteristicastecnicasequipos_id");
                    nuevacaracteristica.Version = reader.GetInt32("caracteristicastecnicasequipos_version");
                    nuevacaracteristica.Descripcion1 = reader.GetString("caracteristicastecnicasequipos_descripcion1");
                    nuevacaracteristica.Descripcion2 = reader.GetString("caracteristicastecnicasequipos_descripcion2");
                    nuevacaracteristica.Descripcion3 = reader.GetString("caracteristicastecnicasequipos_descripcion3");
                    nuevacaracteristica.Descripcion4 = reader.GetString("caracteristicastecnicasequipos_descripcion4");
                    nuevacaracteristica.Descripcion5 = reader.GetString("caracteristicastecnicasequipos_descripcion5");
                    nuevacaracteristica.Descripcion6 = reader.GetString("caracteristicastecnicasequipos_descripcion6");
                    nuevacaracteristica.TensionNominal = reader.GetString("caracteristicastecnicasequipos_tensionnominal");
                    nuevacaracteristica.Frecuencia = reader.GetString("caracteristicastecnicasequipos_frecuencia");
                    nuevacaracteristica.PotenciaMaxima = reader.GetString("caracteristicastecnicasequipos_potenciamaxima");
                    nuevacaracteristica.CorrienteMaxima = reader.GetString("caracteristicastecnicasequipos_corrientemaxima");
                    nuevacaracteristica.Carga = reader.GetString("caracteristicastecnicasequipos_carga");
                    nuevacaracteristica.Presion = reader.GetString("caracteristicastecnicasequipos_presion");
                    nuevacaracteristica.CapacidadFrio = reader.GetString("caracteristicastecnicasequipos_capacidadfrio");
                    nuevacaracteristica.PotenciaNominalFrio = reader.GetString("caracteristicastecnicasequipos_potencianominalfrio");
                    nuevacaracteristica.CorrienteNominalFrio = reader.GetString("caracteristicastecnicasequipos_corrientenominalfrio");
                    nuevacaracteristica.Peso = reader.GetString("caracteristicastecnicasequipos_peso");
                    nuevacaracteristica.CapacidadCalor = reader.GetString("caracteristicastecnicasequipos_capacidadcalor");
                    nuevacaracteristica.PotenciaNominalCalor = reader.GetString("caracteristicastecnicasequipos_potencianominalcalor");
                    nuevacaracteristica.CorrienteNominalCalor = reader.GetString("caracteristicastecnicasequipos_corrientenominalcalor");
                    nuevacaracteristica.Err = reader.GetString("caracteristicastecnicasequipos_err");
                    nuevacaracteristica.Nombre = reader.GetString("caracteristicastecnicasequipos_nombre");
                    nuevacaracteristica.IdParametros = reader.GetInt32("caracteristicastecnicasequipos_idparametros");



                    if (reader.GetInt32("caracteristicastecnicasequipos_esidu") == 1)
                    {
                        nuevacaracteristica.Esidu = true;
                    }
                    else
                    {
                        nuevacaracteristica.Esidu = false;
                    }



                }

                reader.Close();
                return nuevacaracteristica;
            }          

        }


        protected List<CaracteristicasTecnicas> ObtenerCaracteristicasTecnicas(bool idu)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                int esidu = 1;

                if (idu == false)
                {
                    esidu = 0;
                }

                List<CaracteristicasTecnicas> nuevalista = new List<CaracteristicasTecnicas>();
                string sql = "CALL usp_ObtenerCaracteristicasTecnicas(" + esidu.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CaracteristicasTecnicas nuevacaracteristica = new CaracteristicasTecnicas();
                    nuevacaracteristica.ID = reader.GetInt32("caracteristicastecnicasequipos_id");
                    nuevacaracteristica.Version = reader.GetInt32("caracteristicastecnicasequipos_version");
                    nuevacaracteristica.Descripcion1 = reader.GetString("caracteristicastecnicasequipos_descripcion1");
                    nuevacaracteristica.Descripcion2 = reader.GetString("caracteristicastecnicasequipos_descripcion2");
                    nuevacaracteristica.Descripcion3 = reader.GetString("caracteristicastecnicasequipos_descripcion3");
                    nuevacaracteristica.Descripcion4 = reader.GetString("caracteristicastecnicasequipos_descripcion4");
                    nuevacaracteristica.Descripcion5 = reader.GetString("caracteristicastecnicasequipos_descripcion5");
                    nuevacaracteristica.Descripcion6 = reader.GetString("caracteristicastecnicasequipos_descripcion6");
                    nuevacaracteristica.TensionNominal = reader.GetString("caracteristicastecnicasequipos_tensionnominal");
                    nuevacaracteristica.Frecuencia = reader.GetString("caracteristicastecnicasequipos_frecuencia");
                    nuevacaracteristica.PotenciaMaxima = reader.GetString("caracteristicastecnicasequipos_potenciamaxima");
                    nuevacaracteristica.CorrienteMaxima = reader.GetString("caracteristicastecnicasequipos_corrientemaxima");
                    nuevacaracteristica.Carga = reader.GetString("caracteristicastecnicasequipos_carga");
                    nuevacaracteristica.Presion = reader.GetString("caracteristicastecnicasequipos_presion");
                    nuevacaracteristica.CapacidadFrio = reader.GetString("caracteristicastecnicasequipos_capacidadfrio");
                    nuevacaracteristica.PotenciaNominalFrio = reader.GetString("caracteristicastecnicasequipos_potencianominalfrio");
                    nuevacaracteristica.CorrienteNominalFrio = reader.GetString("caracteristicastecnicasequipos_corrientenominalfrio");
                    nuevacaracteristica.Peso = reader.GetString("caracteristicastecnicasequipos_peso");
                    nuevacaracteristica.CapacidadCalor = reader.GetString("caracteristicastecnicasequipos_capacidadcalor");
                    nuevacaracteristica.PotenciaNominalCalor = reader.GetString("caracteristicastecnicasequipos_potencianominalcalor");
                    nuevacaracteristica.CorrienteNominalCalor = reader.GetString("caracteristicastecnicasequipos_corrientenominalcalor");
                    nuevacaracteristica.Err = reader.GetString("caracteristicastecnicasequipos_err");
                    nuevacaracteristica.Nombre = reader.GetString("caracteristicastecnicasequipos_nombre");
                    nuevacaracteristica.IdParametros = reader.GetInt32("caracteristicastecnicasequipos_idparametros");



                    if (reader.GetInt32("caracteristicastecnicasequipos_esidu") == 1)
                    {
                        nuevacaracteristica.Esidu = true;
                    }
                    else
                    {
                        nuevacaracteristica.Esidu = false;
                    }

                    nuevalista.Add(nuevacaracteristica);
                }

                reader.Close();
                return nuevalista;
            }
        }
            

       #endregion

            public List<VersionEquipo> ObtenerVersiones()
            {
                using (MySqlConnection conn = ConectarBaseDeDatos() )
                {
                    List<VersionEquipo> ListaVersiones = new List<VersionEquipo>();
                    string sql="CALL usp_ObtenerVersiones()";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                       VersionEquipo nuevaversion = new VersionEquipo();
                       nuevaversion.ID = reader.GetInt32("versiones_id");
                       nuevaversion.Descripcion=reader.GetString("versiones_descripcion");
                       ListaVersiones.Add(nuevaversion);
                    }
                    
                    
                    reader.Close();
                    return ListaVersiones;
                }

            }

        public abstract List<Ensayos> ObtenerEnsayos();

        public void AgregarCaracteristicaTecnica(CaracteristicasTecnicas ct)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "";
                string parametros = "(";
                parametros = parametros + ct.Version.ToString() + ",'" + ct.Descripcion1 + "','" + ct.Descripcion2 + "','"
                + ct.Descripcion3 + "','" + ct.Descripcion4 + "','" + ct.Descripcion5 + "','"
                + ct.Descripcion6 + "','" + ct.TensionNominal + "','" + ct.Frecuencia + "','"
                + ct.PotenciaMaxima
                + "','" + ct.CorrienteMaxima + "','" + ct.Carga + "','" + ct.Presion +
                "','" + ct.CapacidadFrio + "','" + ct.PotenciaNominalFrio + "','" + ct.CorrienteNominalFrio
                + "','" + ct.Peso + "','" + ct.CapacidadCalor + "','" + ct.PotenciaNominalCalor + "','" +
                ct.CorrienteNominalCalor + "','" + ct.Err + "'," + (ct.Esidu ? "1" : "0") + ",'" + ct.Nombre+"'," +ct.IdParametros.ToString() + ")";

                sql = "CALL usp_AgregarCaracteristicaTecnica " + parametros;


                MySqlCommand cmd = new MySqlCommand(sql, conn);


                try { cmd.ExecuteNonQuery(); }
                catch { }
            }
        }

        public void ModificarCaracteristicaTecnica(CaracteristicasTecnicas ct)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "";
                string parametros = "(";
                parametros = parametros + ct.ID.ToString() + "," + ct.Version.ToString() + ",'" + ct.Descripcion1 + "','" + ct.Descripcion2 + "','"
                + ct.Descripcion3 + "','" + ct.Descripcion4 + "','" + ct.Descripcion5 + "','"
                + ct.Descripcion6 + "','" + ct.TensionNominal + "','" + ct.Frecuencia + "','"
                + ct.PotenciaMaxima
                + "','" + ct.CorrienteMaxima + "','" + ct.Carga + "','" + ct.Presion +
                "','" + ct.CapacidadFrio + "','" + ct.PotenciaNominalFrio + "','" + ct.CorrienteNominalFrio
                + "','" + ct.Peso + "','" + ct.CapacidadCalor + "','" + ct.PotenciaNominalCalor + "','" +
               ct.CorrienteNominalCalor + "','" + ct.Err + "'," + (ct.Esidu ? "1" : "0") + ",'" + ct.Nombre + "',"+ct.IdParametros+")";

                sql = "CALL usp_ModificarCaracteristicaTecnica " + parametros;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }


        public abstract List<CaracteristicasTecnicas> ObtenerCaracteristicasTecnicas();
      
        
        
        public void EliminarCaracteristicaTecnica(CaracteristicasTecnicas ct)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarCaracteristicaTecnica(" + ct.ID.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarEnsayoIDU(int identificacion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarEnsayoIDU(" + identificacion.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarEnsayoODU(int identificacion)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarEnsayoODU(" + identificacion.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarEtiqueta(Etiqueta e)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_EliminarEtiqueta(" + e.Id.ToString() + ")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

     



        public static string getDateTime(DateTime argDateTime)
        {
            string g = ConfigurationManager.AppSettings["DDBBDateTimeFormat"];
            return argDateTime.ToString(g);
        }
        
        public static string getDate(DateTime argDateTime)
        {
            string g = ConfigurationManager.AppSettings["DDBBDateFormat"];
            return argDateTime.ToString(g);
        }

        public bool ExisteUsuario(string usuario)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_VerificarExistenciaUsuario('" + usuario + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (cmd.ExecuteScalar() == null)
                    return false;
                else
                    return true;

              

            }

        }

        public bool ExisteUsuario(string usuario, string password)
        {
            using (MySqlConnection conn = ConectarBaseDeDatos())
            {
                string sql = "CALL usp_VerificarExistenciaUsuarioConPassword('" + usuario + "','" + password + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (cmd.ExecuteScalar() == null)
                    return false;
                else
                    return true;

            }

        }

        public List<string> ListUsers()
        {
          using (MySqlConnection conn = ConectarBaseDeDatos())
          {

            string sql = "SELECT username FROM sf_guard_user;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> users = new List<string>();
            while (reader.Read())
            {
              users.Add(reader.GetString(0));
            }
            reader.Close();
            return users;
          }
        }

        public sfUser Login(string username)
        {
          sfUser msfUser = null;
          using (MySqlConnection conn = ConectarBaseDeDatos())
          {

            string sql = "CALL usp_Login('" + username + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
              if (msfUser == null)
                msfUser = new sfUser();
              else
                break;
              msfUser.u__id = reader.GetString("u__id");
              msfUser.u__sf_guard_user_id = reader.GetString("u__sf_guard_user_id");
              msfUser.sgu__first_name = reader.GetString("sgu__first_name");
              msfUser.sgu__last_name = reader.GetString("sgu__last_name");
              msfUser.sgu__username = reader.GetString("sgu__username");
              msfUser.sgu__password = reader.GetString("sgu__password");
              msfUser.sgu__is_active = reader.GetString("sgu__is_active");
              msfUser.sgu__is_super_admin = reader.GetBoolean("sgu__is_super_admin");
              msfUser.sgu__salt = reader.GetString("sgu__salt");
              msfUser.sgg__id = reader.GetString("sgg__id");
              msfUser.sgg__name = reader.GetString("sgg__name");
              msfUser.sgg__description = reader.GetString("sgg__description");
              msfUser.sgug__user_id = reader.GetString("sgug__user_id");
              msfUser.sgug__group_id = reader.GetString("sgug__group_id");
            }

            reader.Close();
            return msfUser;

          }

        }
        
    }
}
