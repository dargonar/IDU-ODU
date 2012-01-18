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
        public bool AgregarEnsayoOK()
        {
          /*  string PC ="";
            IList<InfoEnsayosReset> v = getUnitOfWork().Find<InfoEnsayosReset>().Where(t => t.PC == PC);
            v.NumeroEnsayosOK++;


            getUnitOfWork().Attach(v);
            getUnitOfWork().SaveChanges();*/
            return true;

        }


        public bool ResetearEnsayos(DateTime fecha, string usuario)
        {
            /*IList<InfoEnsayosReset> ens = getUnitOfWork().Find<InfoEnsayosReset>().Where(t => t.PC == "");

            ens.Fecha = fecha;
            ens.NumeroEnsayosOK = 0;
            ens.Usuario = usuario;

            getUnitOfWork().Attach(ens);
            getUnitOfWork().SaveChanges();*/
            return true;

        }

    }
}