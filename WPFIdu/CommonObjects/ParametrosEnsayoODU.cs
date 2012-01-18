using System;
using System.Collections.Generic;
using System.Text;

namespace iDU.CommonObjects
{

    [Serializable]
    
    public class ParametrosEnsayoODU : ParametrosEnsayo
    {

        private int mTiempoInicialEstabilizacion;

        public int TiempoInicialEstabilizacion
        {
            get { return mTiempoInicialEstabilizacion; }
            set { mTiempoInicialEstabilizacion = value; }

        }
        
        
        
        private int mTiempoMaximoEstabilizacion;

        public int TiempoMaximoEstabilizacion
        {
            get { return mTiempoMaximoEstabilizacion; }
            set { mTiempoMaximoEstabilizacion = value; }
        }
        
        
        private int mTiempoBajaTension;

        public int TiempoBajaTension
        {
            get { return mTiempoBajaTension; }
            set { mTiempoBajaTension = value; }

        }

        private int mTiempoMaximoBajaTension;

        public int TiempoMaximoBajaTension
        {
            get { return mTiempoMaximoBajaTension; }
            set { mTiempoMaximoBajaTension = value; }
        }
        
        private int mTiempoMedicionCalor;

        public int TiempoMedicionCalor
        {
            get { return mTiempoMedicionCalor; }
            set { mTiempoMedicionCalor = value; }

        }
        
        
        private int mTiempoMaximoMedicionCalor;

        public int TiempoMaximoMedicionCalor
        {
            get { return mTiempoMaximoMedicionCalor; }
            set { mTiempoMaximoMedicionCalor = value; }
        }
        
        
        private int mTiempoMedicionFrio;

        public int TiempoMedicionFrio
        {
            get { return mTiempoMedicionFrio; }
            set { mTiempoMedicionFrio = value; }
        }
        
        private int mTiempoRecuperacionMinima;

        public int TiempoRecuperacionMinima
        {
            get { return mTiempoRecuperacionMinima; }
            set { mTiempoRecuperacionMinima = value; }
        }
        
        private int mTiempoMaximoRecuperacionMinima;

        public int TiempoMaximoRecuperacionMinima
        {
            get { return mTiempoMaximoRecuperacionMinima; }
            set { mTiempoMaximoRecuperacionMinima = value; }
        }

        private int mDelayArranqueCompresor;

        public int DelayArranqueCompresor
        {
            get { return mDelayArranqueCompresor; }
            set { mDelayArranqueCompresor = value; }

        }
        
        
        private int mTiempoApagadoEntreCalorFrio;

        public int TiempoApagadoEntreCalorFrio
        {
            get { return mTiempoApagadoEntreCalorFrio; }
            set { mTiempoApagadoEntreCalorFrio = value; }

        }
        
        private int mTiempoCierreValvula1;

        public int TiempoCierreValvula1
        {
            get { return mTiempoCierreValvula1; }
            set { mTiempoCierreValvula1 = value; }
        }
        
        private int mTiempoCierreValvula2;

        public int TiempoCierreValvula2
        {
            get { return mTiempoCierreValvula2; }
            set { mTiempoCierreValvula2 = value; }

        }
        
        private int mTiempoFinal;

        public int TiempoFinal
        {
            get { return mTiempoFinal; }
            set { mTiempoFinal = value; }
        }
        
        private int mPresionInicialMin;

        public int PresionInicialMin
        {
            get { return mPresionInicialMin; }
            set { mPresionInicialMin = value; }
        }
        
        private int mPresionInicialMax;

        public int PresionInicialMax
        {
            get { return mPresionInicialMax; }
            set { mPresionInicialMax = value; }

        }
        
        private int mDeltaPresionEstabilizacionMin;

        public int DeltaPresionEstabilizacionMin
        {
            get { return mDeltaPresionEstabilizacionMin; }
            set { mDeltaPresionEstabilizacionMin = value; }
        }
        
        private int mDeltaPresionEstabilizacionMax;

        public int DeltaPresionEstabilizacionMax
        {
            get { return mDeltaPresionEstabilizacionMax; }
            set { mDeltaPresionEstabilizacionMax = value; }
        }
        
        private int mVelocidadBajaTensionMin;

        public int VelocidadBajaTensionMin
        {
            get { return mVelocidadBajaTensionMin; }
            set { mVelocidadBajaTensionMin = value; }
        }

        private int mVelocidadBajatensionMax;

        public int VelocidadBajatensionMax
        {

            get { return mVelocidadBajatensionMax; }
            set { mVelocidadBajatensionMax = value; }
        }
        
        private int mDeltaPresionBajaTensionMax;

        public int DeltaPresionBajaTensionMax
        {
            get { return mDeltaPresionBajaTensionMax; }
            set { mDeltaPresionBajaTensionMax = value; }
        }
        
        private int mDeltaPresionBajaTensionMin;

        public int DeltaPresionBajaTensionMin
        {
            get { return mDeltaPresionBajaTensionMin; }
            set { mDeltaPresionBajaTensionMin = value; }
        }
        
        private int mDeltaTempMaxCalor;

        public int DeltaTempMaxCalor
        {
            get { return mDeltaTempMaxCalor; }
            set { mDeltaTempMaxCalor = value; }

        }
        
        private int mDeltaTempMinCalor;

        public int DeltaTempMinCalor
        {
            get { return mDeltaTempMinCalor; }
            set { mDeltaTempMinCalor = value; }
        }
        
        private int mCorrienteMinCalor;

        public int CorrienteMinCalor
        {
            get { return mCorrienteMinCalor; }
            set { mCorrienteMinCalor = value; }
        }
        
        
        private int mCorrienteMaxCalor;

        public int CorrienteMaxCalor
        {
            get { return mCorrienteMaxCalor; }
            set { mCorrienteMaxCalor = value; }

        }
        
        private int mPotenciaMinCalor;

        public int PotenciaMinCalor
        {
            get { return mPotenciaMinCalor; }
            set { mPotenciaMinCalor = value; }
        }
        
        private int mPotenciaMaxCalor;

        public int PotenciaMaxCalor
        {
            get { return mPotenciaMaxCalor; }
            set { mPotenciaMaxCalor = value; }
        }
        
        private int mVelocidadMinVentiladorCalor;

        public int VelocidadMinVentiladorCalor
        {
            get { return mVelocidadMinVentiladorCalor; }
            set { mVelocidadMinVentiladorCalor = value; }
        }
        
        
        private int mVelocidadMaxVentiladorCalor;

        public int VelocidadMaxVentiladorCalor
        {
            get { return mVelocidadMaxVentiladorCalor; }
            set { mVelocidadMaxVentiladorCalor = value; }
        }
        
        
        private int mPresionMinApagadoCompresor;

        public int PresionMinApagadoCompresor
        {
            get { return mPresionMinApagadoCompresor; }
            set { mPresionMinApagadoCompresor = value; }
        }
        
        
        private int mDeltaTempMinFrio;

        public int DeltaTempMinFrio
        {
            get { return mDeltaTempMinFrio; }
            set { mDeltaTempMinFrio = value; }
        }
        
        
        private int mDeltaTempMaxFrio;

        public int DeltaTempMaxFrio
        {
            get { return mDeltaTempMaxFrio; }
            set { mDeltaTempMaxFrio = value; }
        }
        
        
        private int mCorrienteMaxFrio;

        public int CorrienteMaxFrio
        {
            get { return mCorrienteMaxFrio; }
            set { mCorrienteMaxFrio = value; }
        }
        
        
        private int mCorrienteMinFrio;

        public int CorrienteMinFrio
        {
            get { return mCorrienteMinFrio; }
            set { mCorrienteMinFrio = value; }
        }
        
        
        private int mPotenciaMinFrio;

        public int PotenciaMinFrio
        {
            get { return mPotenciaMinFrio; }
            set { mPotenciaMinFrio = value; }
        }
        
        private int mPotenciaMaxFrio;
        
        
        public int PotenciaMaxFrio
        {
            get { return mPotenciaMaxFrio; }
            set { mPotenciaMaxFrio = value; }
        }
        
        
        
        private int mVelocidadMinVentiladorFrio;

        public int VelocidadMinVentiladorFrio
        {
            get { return mVelocidadMinVentiladorFrio; }
            set { mVelocidadMinVentiladorFrio = value; }
        }
        
        
        
        
        private int mVelocidadMaxVentiladorFrio;

        public int VelocidadMaxVentiladorFrio
        {
            get { return mVelocidadMaxVentiladorFrio; }
            set { mVelocidadMaxVentiladorFrio = value; }
        }
        
        
        private int mPresionMinFrio;

        public int PresionMinFrio
        {
            get { return mPresionMinFrio; }
            set { mPresionMinFrio = value; }
        }
        
        
        private int mPresionMaxFrio;

        public int PresionMaxFrio
        {
            get { return mPresionMaxFrio; }
            set { mPresionMaxFrio = value; }
        }
        
        private int mPresionMaxRecuperacion;
        
        public int PresionMaxRecuperacion
        {
            get{return mPresionMaxRecuperacion;}
            set { mPresionMaxRecuperacion=value;}
        }
        
       
    }
}
