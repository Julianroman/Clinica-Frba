using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Cancelar_Turno
{
    public partial class MedicoCancelarTurno : Form
    {
        Interfaz.Interfaz interfaz = new Interfaz.Interfaz();

        public MedicoCancelarTurno()
        {
            InitializeComponent();
        }

        private void buttonCancelarTurno_Click(object sender, EventArgs e)
        {
            if (!Box_fechaACancelar.Checked)
            {
                MessageBox.Show("Por favor, seleccione una fecha para cancelar el turno");
            }
            else
            {
                if (interfaz.elementosEstanIncompletos())
                {
                    MessageBox.Show("Por favor, informe los elementos que le pide el formulario");
                    return;
                } 
                


                if (!checkCancelarPorRango.Checked)
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    parametros.Add(new SqlParameter("fecha", Box_fechaACancelar.Value));
                    parametros.Add(new SqlParameter("motivo_cancelacion", richTextMotivo.Text));
                    parametros.Add(new SqlParameter("id_tipo_cancelacion", comboBox1.SelectedIndex));
                    ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.cancelar_turno_fechaEspecifica", parametros);
                }
                else
                {
                    if (dateTimeFechaInicio.Value > dateTimeFechaFin.Value)
                    {
                        MessageBox.Show("La fecha de inicio debe ser menor a la de fin");
                        return;
                    }

                    List<SqlParameter> parametros = new List<SqlParameter>();
                    parametros.Add(new SqlParameter("fechaInicio", dateTimeFechaInicio.Value));
                    parametros.Add(new SqlParameter("fechaFin", dateTimeFechaFin.Value));
                    parametros.Add(new SqlParameter("motivo_cancelacion", richTextMotivo.Text));
                    parametros.Add(new SqlParameter("id_tipo_cancelacion", comboBox1.SelectedIndex));
                    ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.cancelar_turno_rangoDeFechas", parametros);
                }
                MessageBox.Show("Turnos cancelados satisfactoriamente");
                this.Close();
            }
        }

        private void MedicoCancelarTurno_Load(object sender, EventArgs e)
        {
            dateTimeFechaInicio.Visible = false;
            dateTimeFechaFin.Visible = false;
            labelFechaEspecifica.Visible = true;
            Box_fechaACancelar.Visible = true;
            dateTimeFechaInicio.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            dateTimeFechaInicio.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            Box_fechaACancelar.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            Box_fechaACancelar.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            dateTimeFechaFin.Value = dateTimeFechaInicio.Value.AddDays(30);
            interfaz.cargarComboIDValor(comboBox1, "select t.Id_tipo_cancelacion id, t.Descripcion valor from TRIGGER_EXPLOSION.TipoCancelacion t");
            interfaz.agregarElementoTextoAChequear(richTextMotivo);
            interfaz.agregarElementoComboBoxAChequear(comboBox1);
        
        }

        private void checkCancelarPorRango_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCancelarPorRango.Checked)
            {
                labelFechaEspecifica.Visible = false;
                Box_fechaACancelar.Visible = false;
                dateTimeFechaInicio.Visible = true;
                dateTimeFechaFin.Visible = true;
                labelRango.Visible = true;
                labelFechaEspecifica.Visible = false;
            }
            else
            {
                dateTimeFechaInicio.Visible = false;
                dateTimeFechaFin.Visible = false;
                labelFechaEspecifica.Visible = true;
                Box_fechaACancelar.Visible = true;
                labelRango.Visible = false;
                labelFechaEspecifica.Visible = true;
            }
        }
    }
}
