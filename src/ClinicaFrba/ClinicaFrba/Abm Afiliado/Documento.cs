using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClinicaFrba
{
    class Documento
    {
        private String nroDocumento;
        private String tipoDocumento;

        public Documento(String nroDocumento, String tipoDocumento) {
            this.nroDocumento = nroDocumento;
            this.tipoDocumento = tipoDocumento;
        }


        
        //////////////////////
        // Setters & Getters//
        //////////////////////

        public String getNroDocumento() { return nroDocumento; }
        public String getTipoDocumento() { return tipoDocumento; }
    }
}
