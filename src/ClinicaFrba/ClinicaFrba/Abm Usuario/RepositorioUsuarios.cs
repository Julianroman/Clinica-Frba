using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    abstract class RepositorioUsuarios
    {
        private List<Usuario> usuarios;

      /*  public Usuario iniciarSesion(string username, string password) { 
            Usuario elUserQueIniciaSesion;
            elUserQueIniciaSesion = usuarios.Find(u => u.iniciaSesion(username, password));
            if (elUserQueIniciaSesion == null) throw new InvalidOperationException("Usuario o contrasenas invalidos");
            return elUserQueIniciaSesion;
        }*/




        //////////////////////
        // Setters & Getters//
        //////////////////////
        public List<Usuario> getUsuarios() { return usuarios; }
        
    }
}
