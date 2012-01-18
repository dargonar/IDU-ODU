using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using WPFiDU;

namespace IDU_ODU
{
    public partial class InfoEnsayosResetManager : Manager
    {
        public InfoEnsayosReset getOne(int id)
        {
            return getUnitOfWork().FindOne<InfoEnsayosReset>(id);
        }

        public IList<InfoEnsayosReset> getAll()
        {
            return getUnitOfWork().Find<InfoEnsayosReset>();
        }

        public bool delete(int id)
        {
            InfoEnsayosReset InfoEnsayosResetToDel = null;
            InfoEnsayosResetToDel = getUnitOfWork().FindOne<InfoEnsayosReset>( id) ;

            if (InfoEnsayosResetToDel == null)
                return false;

             getUnitOfWork().Remove(InfoEnsayosResetToDel);
             getUnitOfWork().SaveChanges();

            return true;
        }

        public bool modify(InfoEnsayosReset argInfoEnsayosReset)
        {
            getUnitOfWork().Attach (argInfoEnsayosReset);
            getUnitOfWork().SaveChanges();
            return true;
        }

        public bool addInfoEnsayosReset(InfoEnsayosReset argInfoEnsayosReset)
        {
            getUnitOfWork().Add(argInfoEnsayosReset);
            getUnitOfWork().SaveChanges();
            return true;
        }
    }
 }