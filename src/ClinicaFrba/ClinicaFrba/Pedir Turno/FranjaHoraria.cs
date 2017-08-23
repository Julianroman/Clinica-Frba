using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class FranjaHoraria
    {
        private DateTime horaInicio;
        private DateTime horaFinalizacion;
        // Dia perteneciente hay que analizar si tiene consistencia o hay que volarlo
        private Dia diaPerteneciente;
        private Turno turnoAsignado = null;


        public Boolean estaDisponible()
        {
            return this.turnoAsignado == null;
        }




    }
}
