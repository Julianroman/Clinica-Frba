using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Estadisticas
{
    public partial class ProfesionalConsultado : Form
    {
        public ProfesionalConsultado()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> meses = new Dictionary<int, string>();
            if (cboSemestre.Text == "1")
            {

                meses.Add(1, "Enero");
                meses.Add(2, "Febrero");
                meses.Add(3, "Marzo");
                meses.Add(4, "Abril");
                meses.Add(5, "Mayo");
                meses.Add(6, "Junio");

            }
            else
            { 
                meses.Add(7, "Julio");
                meses.Add(8, "Agosto");
                meses.Add(9, "Septiembre");
                meses.Add(10, "Octubre");
                meses.Add(11, "Noviembre");
                meses.Add(12, "Diciembre");
            }
            meses.Add(0, "Todos");
            cboMes.DataSource = new BindingSource(meses, null);
            cboMes.DisplayMember = "Value";
            cboMes.ValueMember = "Key";
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboEspecialidad.Text != "" && cboPlan.Text != "" && cboMes.Text != "")
            {

                DataTable dt = new DataTable();

                int mes, planId, especialidadId, semestre, anio;
                try
                {
                    mes = Convert.ToInt32(cboMes.SelectedValue.ToString());
                    planId = Convert.ToInt32(cboPlan.SelectedValue.ToString());
                    especialidadId = Convert.ToInt32(cboEspecialidad.SelectedValue.ToString());
                    semestre = int.Parse(cboSemestre.Text);
                    anio = Convert.ToInt32(cboAño.Text);
                }
                catch (Exception ex)
                {
                    Interfaz.Interfaz.mostrarMensaje("Verifique que los campos insertados sean correctos");
                    return;
                }



                String query = "select * from TRIGGER_EXPLOSION.ProfesionalesConsultados(@Plan,@Especialidad,@Semestre,@Mes,@Anio)";
                SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
                cmd.Parameters.Add("@Plan", SqlDbType.Int).Value = planId;
                cmd.Parameters.Add("@Especialidad", SqlDbType.Int).Value = especialidadId;
                cmd.Parameters.Add("@Semestre", SqlDbType.Int).Value = semestre;
                cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
               
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        Interfaz.Interfaz.mostrarMensaje("No se han encontrado resultados!");
                    }
                    else
                    {
                        dataGridView1.DataSource = dt;
                    }
                    cmd.Dispose();
                    ManejadorConexiones.desconectar();


                }

            }
            else
            {
                MessageBox.Show("Complete los criterios de busqueda");

            }
        }

        private void ProfesionalConsultado_Load(object sender, EventArgs e)
        {
            SqlCommand cargar = new SqlCommand("SELECT Descripcion, Id_plan FROM TRIGGER_EXPLOSION.PlanMedico UNION SELECT 'Todos', 0", ManejadorConexiones.conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cargar);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cboPlan.DataSource = table;
            cboPlan.DisplayMember = "Descripcion";
            cboPlan.ValueMember = "Id_plan";


            cargar = new SqlCommand("SELECT Descripcion, Id_especialidad FROM TRIGGER_EXPLOSION.Especialidad UNION SELECT 'Todas', 0", ManejadorConexiones.conectar());
            adapter = new SqlDataAdapter(cargar);
            table = new DataTable();
            adapter.Fill(table);
            cboEspecialidad.DataSource = table;
            cboEspecialidad.DisplayMember = "Descripcion";
            cboEspecialidad.ValueMember = "Id_especialidad";
        }
    }
}
