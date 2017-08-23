using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Rol
    {
        private int id_rol;
        private String nombreRol;
        private Boolean habilitado;
        private String tipo;
        private List<Funcionalidad> funcionalidades;



        public Boolean esProfesional() { return false; }
        public Boolean esAfiliado() { return false; }




        //////////////////////
        // Setters & Getters//
        //////////////////////
    }
}
