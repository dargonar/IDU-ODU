using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using System.Configuration;

namespace IDU_ODU
{
    public class Manager : IDisposable
    {
        private Mindscape.LightSpeed.LightSpeedContext _context = null;
        private Mindscape.LightSpeed.IUnitOfWork _unitOfWork = null;

        private Mindscape.LightSpeed.LightSpeedContext getContext()
        {
            if( _context != null )
                return _context;

            _context = new LightSpeedContext();
            _context.DataProvider = DataProvider.MySql5;
            //_context.ConnectionString = "server=localhost;uid=root;pwd=root;database=iduodudiventi;pooling=false;";
            _context.ConnectionString = ConfigurationManager.AppSettings["DDBBConnString"]; 
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
            if ( _unitOfWork != null )
                return _unitOfWork;

            _unitOfWork = getContext().CreateUnitOfWork();
            return _unitOfWork;
        }

    }
}
