using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IVRTKERNELLib;

using System.Windows.Threading;

namespace WPFiDU.Utils
{
    public class DCFConnectionChecker :IDisposable     
    {
        private iDU.PLC.PLC mPLC = null;
        public delegate void OnConnectionLost();

        private DispatcherTimer conecionCheckTimer = new DispatcherTimer();
        public event OnConnectionLost OnConnectionLostEvent = null;

        public DCFConnectionChecker() 
        { }
        public DCFConnectionChecker(string argTagToTest)
        {
            mTagToTest = argTagToTest;
        }

        string mTagToTest = string.Empty;
        public string TagToTest {
            get { return mTagToTest; }
            set { mTagToTest = value; }
        }



        public void start() 
        {
            mPLC = new iDU.PLC.PLCIDU();
            conecionCheckTimer.Interval = new TimeSpan(0, 0, 5);
            conecionCheckTimer.Tick += new EventHandler(conecionCheckTimer_Tick);
            conecionCheckTimer.Start();
        }
        
        public void stop() 
        {
            if (conecionCheckTimer == null)
                return;
            conecionCheckTimer.Stop();
        }

        private void conecionCheckTimer_Tick(object source, EventArgs e)
        {
            if(this.OnConnectionLostEvent==null)
                return;
            if (String.IsNullOrEmpty(mTagToTest))
                return;
            RtkTagValue[] values = mPLC.LeerRTKTagValue(mTagToTest);

            if (values == null)
            {
                this.OnConnectionLostEvent();
                return;
            }

            //if (values[0] == null)
            //{
            //    this.OnConnectionLostEvent();
            //    return;
            //}

            if (values[0].Quality!=192)
            {
                this.OnConnectionLostEvent();
                return;
            }
        }

        public void Dispose() 
        {
            if (this.mPLC!=null)
                this.mPLC.Dispose();
            this.mPLC = null;
        }
    }
}
