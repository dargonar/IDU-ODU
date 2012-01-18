using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iDU.BL;
using iDU.CommonObjects;

namespace WPFiDU.BL
{
    public class ManagerUsuarios : Manager
    {

        public void SetearPasswordUsuario(string nuevopassword,string descripcion)
        {
            AccesoDatos.SetearPasswordUsuario(nuevopassword,descripcion);

        }

        public string ObtenerPasswordUsuario(string descripcion)
        {

            return AccesoDatos.ObtenerPasswordUsuario(descripcion);
        }

        public string ObtenerUsuario(string password)
        {
            return AccesoDatos.ObtenerUsuario(password);

        }

        public bool ExisteUsuario(string usuario)
        {
            return AccesoDatos.ExisteUsuario(usuario);

        }

        public bool ExisteUsuario(string usuario, string password)
        {
            return AccesoDatos.ExisteUsuario(usuario, password);
        
        }
        
        
        public static sfUser sfUser = null;
        public sfUser Login(string username, string password)
        {
          if(String.IsNullOrEmpty(username) | String.IsNullOrEmpty(password))
            return null;
            
          sfUser msfUser = AccesoDatos.Login(username);
          if(msfUser==null)
            return null;
            
          //string textToHash = msfUser.sgu__salt + password.Trim();

          //byte[] byteRepresentation = System.Text.UnicodeEncoding.UTF8.GetBytes(textToHash);
          //byte[] hashedTextInBytes = null;
          //System.Security.Cryptography.SHA1CryptoServiceProvider cripto = new System.Security.Cryptography.SHA1CryptoServiceProvider();
          //hashedTextInBytes = cripto.ComputeHash(byteRepresentation);
          //string hashedText = BitConverter.ToString(hashedTextInBytes).Replace("-", "").ToLower();

          //if (hashedText==msfUser.sgu__password)
          //  return msfUser;

          if (password.Trim()== msfUser.sgu__password)
          {
            ManagerUsuarios.sfUser=msfUser;
            return msfUser;
          }
          
          return null;
        }

        public List<string> ListUsers()
        {
          return AccesoDatos.ListUsers();
          
        }        
    
    }
}
