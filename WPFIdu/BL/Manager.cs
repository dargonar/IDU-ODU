using System;
using System.Collections.Generic;
using System.Text;
using iDU.DAO;
using iDU.CommonObjects;
using System.Configuration;
using Mindscape.LightSpeed;
using WPFiDU.CommonObjects;



namespace iDU.BL
{
    public class Manager:IDisposable
    {
        private Mindscape.LightSpeed.LightSpeedContext _context = null;
        private Mindscape.LightSpeed.IUnitOfWork _unitOfWork = null;
        private Mindscape.LightSpeed.LightSpeedContext getContext()
        {
            if (_context != null)
                return _context;

            _context = new LightSpeedContext();
            _context.DataProvider = DataProvider.MySql5;
            _context.ConnectionString = "server=localhost; user id=root; password=248; database=linea_armado2; pooling=false;";
            _context.IdentityMethod = IdentityMethod.IdentityColumn;
            //_context.Logger = new Mindscape.LightSpeed.Logging.TraceLogger();
            return _context;
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
                _unitOfWork = null;
            }

            _context = null;
        }

        protected IUnitOfWork getUnitOfWork()
        {
            if (_unitOfWork != null)
                return _unitOfWork;

            _unitOfWork = getContext().CreateUnitOfWork();
            return _unitOfWork;
        }
        
        
        private bool mEsIdu;
        protected BaseDAO AccesoDatos = null;
     //   protected ParametrosEnsayo ParametrosDeEnsayos = null;



        public bool EsIdu
        {
            get { return mEsIdu; }
            set { mEsIdu = value; }
        }

        

        public Manager()
        {
            string type = ConfigurationManager.AppSettings["TIPO"];
            if (type.Trim().ToUpper().Equals("IDU"))
                 mEsIdu = true;
                
            else
                mEsIdu = false;
               

                if (mEsIdu)
                {
                    AccesoDatos = new IDUDb();
                  //  ParametrosDeEnsayos = new ParametrosEnsayoIDU();
                   
                    
                }
                else
                {
                    AccesoDatos = new ODUDb();
                   // ParametrosDeEnsayos = new ParametrosEnsayoODU();
                    
                    
                }
          
        }


    }
 }
