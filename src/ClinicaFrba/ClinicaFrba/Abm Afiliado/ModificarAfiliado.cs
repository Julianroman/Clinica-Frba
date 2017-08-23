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
using System.Text.RegularExpressions;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        Interfaz.Interfaz interfaz = new Interfaz.Interfaz();
        Int64 afiliadoAModificar;

        public ModificarAfiliado(Int64 id_afiliado)
        {
            InitializeComponent();
            this.afiliadoAModificar = id_afiliado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("sexo", comboBoxSexo.Text));
            parametros.Add(new SqlParameter("direccion", Box_direccion.Text));
            parametros.Add(new SqlParameter("telefono", Box_telefono.Text));
            parametros.Add(new SqlParameter("mail", Box_mail.Text));
            parametros.Add(new SqlParameter("descripcion_estado_civil", comboBoxEstadoCivil.Text));
            parametros.Add(new SqlParameter("descripcion_plan_medico", comboBoxPlanMedico.Text));
            parametros.Add(new SqlParameter("motivo_modificacion", txtMotivoModificacion.Text));
            parametros.Add(new SqlParameter("id_afiliado", afiliadoAModificar));
            parametros.Add(new SqlParameter("fecha_modif", ConfigurationManager.AppSettings["FechaSistema"]));


            parametros.RemoveAll( param => String.IsNullOrWhiteSpace(param.Value.ToString()));
            parametros.RemoveAll(param => param.Value.ToString() == "Seleccione una opción ....");
            ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.modificar_afiliado", parametros);
            MessageBox.Show("Afiliado modificado con exito");
            this.Close();
        }

        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
            String getEstadoCivil = "select Id_estado_civil id, Descripcion valor from TRIGGER_EXPLOSION.EstadoCivil";
            interfaz.cargarComboIDValor(this.comboBoxEstadoCivil, getEstadoCivil);
            String getPlanesMedicos = "select Id_plan id, Descripcion valor from TRIGGER_EXPLOSION.PlanMedico";
            interfaz.cargarComboIDValor(this.comboBoxPlanMedico, getPlanesMedicos);
            this.comboBoxSexo.Text = "Seleccione una opción ....";
            this.comboBoxSexo.Items.Add("masculino");
            this.comboBoxSexo.Items.Add("femenino");
           
        }

        private void Box_telefono_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(Box_telefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Este campo solo admite valores numericos");
                Box_telefono.Text = "";
                return;
            }
        }
    }
}
