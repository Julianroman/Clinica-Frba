using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class Bono
    {
        private Boolean usado;
        
        private Plan planDeOrigen;
        private Rol usadoPor;
        private DateTime fechaDeImpresion;
        private Double nroConsulta;

        private Bono() { }
        public Bono(Plan planQueLoVendio) 
        {
            this.planDeOrigen = planQueLoVendio;
        }
        
        public Bono setAfiliado(Afiliado afiliado) {
            this.usadoPor = afiliado;
            return this;
        }
    }
}
