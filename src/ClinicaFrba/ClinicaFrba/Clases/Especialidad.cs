using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Especialidad
    {
        public String nombre { get; set; }
        public String id {get;set;}

        public Especialidad(string nombreEspecialidad)
        {
            this.nombre = nombreEspecialidad;

        }


        public Especialidad(string nombre, string id)
        {
            this.nombre = nombre;
            this.id = id;

        }

        public Boolean matches(string busqueda)
        {
            return this.nombre.ToLower().Contains(busqueda);
        }
    }
}
