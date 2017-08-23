using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Funcionalidad
    {
        private String nombre;

        public Funcionalidad(String nombre) { this.nombre = nombre; }

        public Boolean matches(String busqueda) {
            return this.nombre.ToLower().Contains(busqueda);
        }



        //////////////////////
        // Setters & Getters//
        //////////////////////
        public String getNombre() { return nombre; }
    }
}
