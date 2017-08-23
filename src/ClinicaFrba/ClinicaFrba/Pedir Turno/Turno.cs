using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class Turno
    {
        private Usuario afiliado;
        private Usuario profesional;
        private Dia fecha;
        private DateTime fechaLlegada;
        private FranjaHoraria hora;
        // TODO, no hace falta guardar hora y fecha llegada, con un Date alcanza
        // Hay que actualizar el DER y volarlo de aca
        private DateTime horaLlegada;
        ///////

       

        private Turno() { }
        public Turno(Usuario afiliado, Usuario profesional)
        {
            if (afiliado.esAfiliado() && profesional.esProfesional())
            {
                this.afiliado = afiliado;
                this.profesional = profesional;
            }
            else
            {
                throw new FormatException("El turno se debe inicializar con un Afiliado y un Profesional");
            }
        }



    }
}
