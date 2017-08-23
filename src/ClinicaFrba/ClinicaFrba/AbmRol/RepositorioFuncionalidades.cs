using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    abstract class RepositorioFuncionalidades
    {
        private List<Funcionalidad> funcionalidades;

        public List<Funcionalidad> getFuncionalidades() { return funcionalidades; }

        public List<Funcionalidad> buscarFuncionalidades(String busqueda)
        {
            // Esta es un plus, podriamos permitir que se busquen las funcionalidades disponibles
            // a traves de un string en vez de tener que usar un menu desplegable
            return funcionalidades.FindAll(f => f.matches(busqueda));
        }

    }
}