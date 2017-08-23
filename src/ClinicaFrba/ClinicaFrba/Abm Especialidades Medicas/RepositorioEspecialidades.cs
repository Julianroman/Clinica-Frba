using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class RepositorioEspecialidades
    {
        private List<Especialidad> especialidadesDisponibles = new List<Especialidad>();

        public void agregarEspecialidadAlRepo(Especialidad especialidad)
        {
            this.especialidadesDisponibles.Add(especialidad);
        }

        public void quitarEspecialidadAlRepo(Especialidad especialidad)
        {
            this.especialidadesDisponibles.Remove(especialidad);
        }

        public List<Especialidad> getEspecialidades()
        {
            return this.especialidadesDisponibles;
        }

        public Especialidad buscarEspecialidad(String busqueda)
        {
            // Esta es un plus, podriamos permitir que se busquen las especialidades disponibles
            // a traves de un string en vez de tener que usar un menu desplegable
            return especialidadesDisponibles.Find(e => e.matches(busqueda));
        }
    }
}
