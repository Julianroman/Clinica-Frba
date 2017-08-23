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
    public partial class AfilidadoBonos : Form
    {
        public AfilidadoBonos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {

                try
                {
                    int anio, mes, semestre;
                    anio = Convert.ToInt32(cboAño.SelectedItem.ToString());
                    String mesString = cboMes.SelectedValue.ToString();
                    mes = Convert.ToInt32(mesString);
                    semestre = Convert.ToInt32(cboSemestre.SelectedItem.ToString());


                    DataTable dt = new DataTable();

                    String query = "SELECT * from TRIGGER_EXPLOSION.AfiliadosBonos(@Semestre,@Mes,@Anio) ";

                    SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
                    cmd.Parameters.Add("@Semestre", SqlDbType.Int).Value = semestre;
                    cmd.Parameters.Add("@Mes", SqlDbType.Int).Value = mes;
                    cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        adapter.Fill(dt);
                        cmd.Dispose();
                        ManejadorConexiones.desconectar();
                        if (dt.Rows.Count == 0)
                        {
                            Interfaz.Interfaz.mostrarMensaje("No hay ningun afiliado para los parametros seleccionados!");
                        }
                        else
                        {
                            dataGridView1.DataSource = dt;
                        }

                        
                    }


                }
                catch (Exception ex)
                {
                    Interfaz.Interfaz.mostrarMensaje("Consulta cancelada, revise los parametros seleccionados ");
                    ManejadorConexiones.desconectar();
                }


            }
            else
            {
                MessageBox.Show("Complete los criterios de busqueda");
            }
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
    }
}
