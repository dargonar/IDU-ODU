using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IVRTKERNELLib;
using System.Timers;

namespace SignalGenerator
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      rt = new RTRuntimeClass();

      oTimerOdu = new System.Timers.Timer();
      oTimerOdu.Elapsed += new ElapsedEventHandler(oTimerOdu_Elapsed);
      oTimerOdu.Interval = 1000;

      oTimerIdu = new System.Timers.Timer();
      oTimerIdu.Elapsed += new ElapsedEventHandler(oTimerIdu_Elapsed);
      oTimerIdu.Interval = 1000;
    }

    #region Members
    protected RTRuntimeClass rt = null;
    protected RTTinyRuntime trt = new RTTinyRuntime();

    private int[] tagErrors = null;
    private Random rnd = new Random((int)DateTime.Now.Ticks);

    private System.Timers.Timer oTimerIdu;
    private System.Timers.Timer oTimerOdu;

    private enum State { Running, Stopped }
    private State state = State.Stopped;
    private int times = 0;
    #endregion Members

    #region Idu Functions and Events
    void oTimerIdu_Elapsed(object sender, ElapsedEventArgs e)
    {
      this.Invoke(
      new ElapsedEventHandler(Called_TimerIdu_Elapsed), sender, e);
    }

    private void Called_TimerIdu_Elapsed(object sender, ElapsedEventArgs e)
    {
      times++;
      lblLogIdu.Text = string.Format("TIMES:{0}; {1};"
        , times.ToString()
        , state.ToString());
      if (state == State.Running)
      {
        string[] tagNames = this.getTagNamesIdu();
        object[] Values   = getValuesIdu();
        rt.writeTags(ref tagNames, ref Values, ref tagErrors);
      }
      else
      {
        state = State.Running;
      }
      

    }

    private string[] getTagNamesIdu()
    {
      List<string> names = new List<string>();

      names.Add("IDU_ST_EquipoEnsayadoOK");
      names.Add("IDU_ST_NumeroDeFalla");
      names.Add("IDU_SP_ModoSeleccionado"); //0
      names.Add("IDU_MD_CorrienteMedida");
      names.Add("IDU_MD_VelocidadCalculada");

      //Estados IDU
      //  IDU_SP_CopiaEstadoIDU 
      //    dotIDUEnergizado1
      //  ModoCalorEstadoIDU
      //    dotModoCalor1
      //  IDU_ST_CopiaEstadoODU
      //    dotDummy1
      //  IDU_Q_EntradaEstadoElectroVentilador
      //    dotElectro1
      //  IDU_Q_ReleSeleccionBajaTension
      //    dotBajaTension2

      names.Add("IDU_SP_CopiaEstadoIDU"); 
      names.Add("ModoCalorEstadoIDU");
      names.Add("IDU_ST_CopiaEstadoODU");
      names.Add("IDU_Q_EntradaEstadoElectroVentilador");
      names.Add("IDU_Q_ReleSeleccionBajaTension");
      return names.ToArray();
    }

    private object[] getValuesIdu()
    {
      List<object> tagValues = new List<object>();

      //names.Add("IDU_ST_EquipoEnsayadoOK");
      //names.Add("IDU_ST_NumeroDeFalla");
      //names.Add("IDU_SP_ModoSeleccionado"); //0
      //names.Add("IDU_MD_CorrienteMedida");
      //names.Add("IDU_MD_VelocidadCalculada");
      
      

      tagValues.Add(0);
      tagValues.Add(0);
      tagValues.Add(0);
      //GetRandomInt(0, 3);
      tagValues.Add(GetRandomInt(0, 1000));
      tagValues.Add(GetRandomInt(0, 1000));

      //names.Add("IDU_SP_CopiaEstadoIDU");
      //names.Add("ModoCalorEstadoIDU");
      //names.Add("IDU_ST_CopiaEstadoODU");
      //names.Add("IDU_Q_EntradaEstadoElectroVentilador");
      //names.Add("IDU_Q_ReleSeleccionBajaTension");

      tagValues.Add(0 & (times % 10));
      tagValues.Add(2 & (times % 10));
      tagValues.Add(4 & (times % 10));
      tagValues.Add(6 & (times % 10));
      tagValues.Add(8 & (times % 10));
      
      
      return tagValues.ToArray();
    }

    private void StartIDU()
    {
      trt.Write("IDU_ST_EnsayoEnCurso", 1);
      oTimerIdu.Start();
    }

    private void StopIDU()
    {
      oTimerIdu.Stop();
      times = 0;
      trt.Write("IDU_ST_EquipoEnsayadoOK", 1);
      trt.Write("IDU_ST_NumeroDeFalla", 0);
      trt.Write("IDU_ST_EnsayoEnCurso", 0);
      state = State.Stopped;

      lblLogIdu.Text = string.Format("STATE:{0}; "
        , state.ToString());
    }

    private void StopIDUFallado()
    {
      oTimerIdu.Stop();
      times = 0;
      
      int falla = getFallaRandomIdu();
      trt.Write("IDU_ST_NumeroDeFalla", falla);
      trt.Write("IDU_ST_EquipoEnsayadoOK", 0);
      trt.Write("IDU_ST_EnsayoEnCurso", 0);
      state = State.Stopped;
      
      lblLogIdu.Text = string.Format("STATE:{0};FALLA:{1}; "
        , state.ToString()
        , falla.ToString());
    }

    int[] fallasIdu = new int[] { 2, 3, 6, 7, 10, 12, 13, 14, 15, 18, 19 }; 

    private int getFallaRandomIdu() 
    {
      return fallasIdu[rnd.Next(0, fallasIdu.Length - 1)];
      
    }
    private void btnStartIdu_Click(object sender, EventArgs e)
    {
      StartIDU();
    }

    private void btnEndIdu_Click(object sender, EventArgs e)
    {
      StopIDU();
    }

    private void btnStopIduFallado_Click(object sender, EventArgs e)
    {
      StopIDUFallado();
    }
    #endregion Idu Functions and Events
    
    #region Common Functions 
    protected int GetRandomInt(int min, int max)
    {
      return rnd.Next(min, max);
    }
    #endregion Common Functions

    #region Odu Functions and Events


    void oTimerOdu_Elapsed(object sender, ElapsedEventArgs e)
    {
      this.Invoke(
      new ElapsedEventHandler(Called_TimerOdu_Elapsed), sender, e);
    }

    private void Called_TimerOdu_Elapsed(object sender, ElapsedEventArgs e)
    {
    
      
      times++;
      lblLogOdu.Text = string.Format("TIMES:{0}; {1};"
        , times.ToString()
        , state.ToString());
      if (state == State.Running)
      {
        string[] tagNames = this.getTagNamesOdu();
        object[] Values = getValuesOdu();

        rt.writeTags(ref tagNames, ref Values, ref tagErrors);
      }
      else
      {
        state = State.Running;
      }
      

    }

    private string[] getTagNamesOdu()
    {
      List<string> names = new List<string>();

      names.Add("ODU_MD_Potencia");
      names.Add("ODU_MD_TensionEstado");
      names.Add("ODU_MD_Humedad");
      names.Add("ODU_MD_Presion");
      names.Add("ODU_MD_TempSalida");
      names.Add("ODU_MD_TempEntrada");    // [entre valores determinados!!!]

      return names.ToArray();
    }

    private object[] getValuesOdu()
    {
      List<object> tagValues = new List<object>();

      tagValues.Add(GetRandomInt(0, 1000));
      tagValues.Add(GetRandomInt(0, 1000));
      tagValues.Add(GetRandomInt(0, 1000));
      tagValues.Add(GetRandomInt(0, 1000));
      tagValues.Add(GetRandomInt(0, 100));
      tagValues.Add(GetRandomInt(220, 280));
      return tagValues.ToArray();
    }

    private void StartODU()
    {
      trt.Write("ODU_ST_EnsayoEnCurso", 1);
      oTimerOdu.Start();
    }

    private void StopODU()
    {
      oTimerOdu.Stop();
      times = 0;
      trt.Write("ODU_ST_EnsayoAprobado", 1);
      trt.Write("ODU_ST_CodigoDeFalla", 0);
      trt.Write("ODU_ST_EnsayoEnCurso", 0);
      state = State.Stopped;

      lblLogOdu.Text = string.Format("STATE:{0}; "
        , state.ToString());
    }

    private void StopODUFallado()
    {
      oTimerOdu.Stop();
      times = 0;
      
      int falla = getFallaRandomOdu();
      trt.Write("ODU_ST_CodigoDeFalla", falla);
      trt.Write("ODU_ST_EnsayoAprobado", 0);
      trt.Write("ODU_ST_EnsayoEnCurso", 0);
      state = State.Stopped;
      
      lblLogOdu.Text = string.Format("STATE:{0};FALLA:{1}; "
        , state.ToString()
        , falla.ToString());
    }

    int[] fallasOdu = new int[] { 3, 4, 6, 7, 8, 9, 10, 11, 13, 15, 16, 17, 18, 19, 20, 21, 24 }; 

    private int getFallaRandomOdu() 
    {
      return fallasOdu[rnd.Next(0, fallasIdu.Length - 1)];
      
    }

    private void btnStartOdu_Click(object sender, EventArgs e)
    {
      StartODU();
    }

    private void btnStopOduOk_Click(object sender, EventArgs e)
    {
      StopODU();
    }

    private void btnStopOduFallado_Click(object sender, EventArgs e)
    {
      StopODUFallado();
    }

    #endregion Odu Functions and Events
  }
}
