using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Estadisticas
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        private void ListadoEstadisticas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            switch (ListadoEstadisticas.Text){
                case "Especialidades más canceladas":
                    EspecialidadesCanceladas especialidad = new EspecialidadesCanceladas();
                    especialidad.ShowDialog();
                    break;
                case "Profesionales más consultados":
                    ProfesionalConsultado profesional = new ProfesionalConsultado();
                    profesional.ShowDialog();
                    break;
                case "Profesionales con menos trabajo":
                    ProfesionalHoras profesionalHoras = new ProfesionalHoras();
                    profesionalHoras.ShowDialog();
                    break;
                case "Afilidado con mayor compra de bonos":
                    AfilidadoBonos afiliado = new AfilidadoBonos();
                    afiliado.ShowDialog();
                    break;
                case "Especialidades más consultadas":
                    EspecialidadBonos especialidadBonos = new EspecialidadBonos();
                    especialidadBonos.ShowDialog();
                    break;
            }
        }
    }
}
