using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace WPFiDU
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class InfoEnsayosReset : Entity<int>
  {
    #region Fields
  
    private System.DateTime _fecha;
    private int _numeroEnsayosOK;
    private string _usuario;
    private string _pC;
    private bool _esIDU;

    #endregion
    
    #region Field attribute names
    
    public const string FechaField = "Fecha";
    public const string NumeroEnsayosOKField = "NumeroEnsayosOK";
    public const string UsuarioField = "Usuario";
    public const string PCField = "PC";
    public const string EsIDUField = "EsIDU";

    #endregion
    
    #region Properties


    public System.DateTime Fecha
    {
      get { return Get(ref _fecha); }
      set { Set(ref _fecha, value, "Fecha"); }
    }

    public int NumeroEnsayosOK
    {
      get { return Get(ref _numeroEnsayosOK); }
      set { Set(ref _numeroEnsayosOK, value, "NumeroEnsayosOK"); }
    }

    public string Usuario
    {
      get { return Get(ref _usuario); }
      set { Set(ref _usuario, value, "Usuario"); }
    }

    public string PC
    {
      get { return Get(ref _pC); }
      set { Set(ref _pC, value, "PC"); }
    }

    public bool EsIDU
    {
      get { return Get(ref _esIDU); }
      set { Set(ref _esIDU, value, "EsIDU"); }
    }

    #endregion
  }


  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LightSpeedModel1UnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public LightSpeedModel1UnitOfWork()
    {
    }
	
    public System.Linq.IQueryable<InfoEnsayosReset> InfoEnsayosResets
    {
      get { return this.Query<InfoEnsayosReset>(); }
    }
  }
}
