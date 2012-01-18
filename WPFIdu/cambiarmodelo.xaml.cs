using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using iDU.CommonObjects;
using iDU.BL;
using WPFiDU.BL;
using iDU.PLC;
using iDU;
using System.Windows.Threading;
using WPFiDU;
using log4net;

namespace dcf001
{
	public partial class cambiomodelo
	{
        private static readonly ILog logger = LogManager.GetLogger(typeof(cambiomodelo));
        
        private bool mConectado=/*false*/true;



        public bool Conectado
        {
            get {return mConectado;}
            set { mConectado =value;}

        }
     
      
		public cambiomodelo(Modelo m)
		{
			this.InitializeComponent();
            
            VerInformacion(m);
            
		}

        private void CargarParametrosEnsayo(Modelo m)
        {
            ModelosManager manag_modelos = new ModelosManager();
            ParametrosManager manag_parametros = new ParametrosManager();
            CaracteristicasTecnicasManager c = new CaracteristicasTecnicasManager();

            CaracteristicasTecnicas ct = c.ObtenerCaracteristicaTecnicaDeModelo(m);

            ParametrosEnsayo parametros = manag_parametros.LeerParametrosDeBaseDeDatosPorId(ct.IdParametros);
            manag_parametros.EscribirParametrosEnPLC(parametros, true);

            manag_parametros.Dispose();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




        private void VerInformacion(Modelo m)
        {

            
            try
            {

                ltbCambiando.Items.Add("Se selecciono el modelo :");
                ltbCambiando.Items.Add(m.Nombremodelo);
                
                PLC plc = null;

                if (m.EsIdu)
                {
                    plc = new PLCIDU();
                }
                else
                {
                     plc = new PLCODU();
                }

             
                if (plc.ProbarConexion() ==/* false*/ true)
                {
                    ltbCambiando.Items.Add("Error en la conexion");
                    mConectado = false;
                }
                else
                {
                    ltbCambiando.Items.Add("se conecto al plc ");
                    CargarParametrosEnsayo(m);
                    mConectado = true;
                }
                plc.Dispose();
            }
            catch (Exception ex)
            {
                excepcion formexepciones = new excepcion(ex);
                formexepciones.ShowDialog();
            }
            
        }
       
	}
}