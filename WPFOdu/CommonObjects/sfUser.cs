using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDU.CommonObjects
{
  public enum Role{
    None=0,
    Operador=1,
    Administrador=2, 
    SuperAdmin=4
  }
  
  public class sfUser
  {
    public string u__id = null;
    public string u__sf_guard_user_id = null;
    public string sgu__first_name = null;
    public string sgu__last_name = null;
    public string sgu__username = null;
    public string sgu__password = null;
    public string sgu__is_active = null;
    public bool sgu__is_super_admin = false;
    public string sgu__salt = null;
    public string sgg__id = null;
    public string sgg__name = null;
    public string sgg__description = null;
    public string sgug__user_id = null;
    public string sgug__group_id = null;
    
    private Role Role = Role.None;
    
    public Role getRole(){
      
      if(this.Role.Equals(Role.None))
      {    
        if(String.IsNullOrEmpty( sgg__name))
          this.Role = Role.None;

        if (sgg__name.ToLower().Equals(Convert.ToString(Role.Administrador).ToLower()))
        {
          if (this.sgu__is_super_admin)
            this.Role = Role.SuperAdmin;
          else
            this.Role = Role.Administrador;
        }
        if (sgg__name.ToLower().Equals(Convert.ToString(Role.Operador).ToLower()))
          this.Role = Role.Operador;
      }
      return this.Role;
    }
    
    public bool IsInRole(Role role){
      return Convert.ToInt32( this.getRole()) >= Convert.ToInt32( role);
    }
  }
}
