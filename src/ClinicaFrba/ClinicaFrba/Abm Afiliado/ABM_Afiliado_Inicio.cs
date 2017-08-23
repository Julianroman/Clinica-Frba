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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_Afiliado_Inicio : Form
    {
        public int FilaSeleccionada { get; set; }
        Int64 id_afiliado;


        public ABM_Afiliado_Inicio()
        {
            InitializeComponent();
        }

        private void cargarGrilla(String query) 
        {
            Interfaz.Interfaz.cargarGrilla(this.grilla, query);
        }

        private void botonAltaAfiliado_Click(object sender, EventArgs e)
        {

            AltaAfiliado altaUsuario = new AltaAfiliado();
            altaUsuario.ShowDialog();
        }

        private void botonBajaAfiliado_Click(object sender, EventArgs e)
        {
            if (FilaSeleccionada == -1)
            {
                MessageBox.Show("Por favor, seleccione primero un elemento de la grilla");
                return;
            }
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("id_afiliado", id_afiliado));
            String bajaAfiliado = "TRIGGER_EXPLOSION.baja_afiliado";
            ManejadorConexiones.ExecuteQuery(bajaAfiliado, parametros);
            MessageBox.Show("Afiliado Nº " + id_afiliado + " dado de baja");
            this.getAfiliados();
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ABM_Afiliado_Inicio_Load(object sender, EventArgs e)
        {
            FilaSeleccionada = -1;
            this.getAfiliados();
        }

        private void getAfiliados() 
        {
            Int64 habilitado = checkBox1.Checked ? 1 : 0;
            String afiliados = "select * from TRIGGER_EXPLOSION.Afiliado WHERE Habilitado = " + habilitado;
            this.cargarGrilla(afiliados);
        }

        private void allAfiliadosToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            String afiliadoByName = "select * from TRIGGER_EXPLOSION.Afiliado WHERE Numero_documento LIKE '" + txtDni.Text + "%'";
            this.cargarGrilla(afiliadoByName);
        }

        private void grilla_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void grilla_Click(object sender, EventArgs e)
        {
            
        }

        private void grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.FilaSeleccionada = e.RowIndex;
            id_afiliado = Convert.ToInt64(grilla.Rows[FilaSeleccionada].Cells["Id_afiliado"].Value.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.getAfiliados();
        }

        private void buttonModificarAfiliado_Click(object sender, EventArgs e)
        {
            if (FilaSeleccionada == -1)
            {
                MessageBox.Show("Por favor, seleccione primero un elemento de la grilla");
                return;
            }
            ModificarAfiliado modificarAfiliado = new ModificarAfiliado(this.id_afiliado);
            modificarAfiliado.Show();
        }

        private void ABM_Afiliado_Inicio_Activated(object sender, EventArgs e)
        {
            this.getAfiliados();
        }


    }
}
