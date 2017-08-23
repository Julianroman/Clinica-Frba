using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    abstract class Repositorio
    {
        static Usuario usuarioActual;

        public static void currentUser(Usuario nuevoUsuario)     {
            usuarioActual = nuevoUsuario;
        }



        public static Usuario getUserActual()
        {
            return usuarioActual;
        }
    }
}
