using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class Dia
    {
        private List<FranjaHoraria> horariosDisponibles;

        private Boolean tieneDisponibilidad()
        {
            // Si encuentra al menos un horario que este disponible => devuelve true
            return this.horariosDisponibles.Find(h => h.estaDisponible()) != null;
        }
    }
}
