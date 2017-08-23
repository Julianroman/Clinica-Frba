using ClinicaFrba.Clases;
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

namespace ClinicaFrba.Abm_Rol
{
    public partial class ABMRol : Form
    {
        private string filtroFuncCodgio = "";

        public ABMRol()
        {
            InitializeComponent();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            UtilForms.Limpiar(groupBoxFiltros);
            filtroFuncCodgio = "";
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            DoBuscar();
        }

        public void DoBuscar() {
            grilla.SuspendLayout();
            grilla.Columns.Clear();

            UtilForms.QueryAGrid(makeQuery(), grilla);

            grilla.Columns["Id_Rol"].Visible = false;
            DataGridViewTextBoxColumn colFuncionalidades = new DataGridViewTextBoxColumn();
            colFuncionalidades.HeaderText = "Funcionalidades";
            colFuncionalidades.Name = "colFuncionalidades";
            grilla.Columns.Add(colFuncionalidades);
            for (int i = 0; i < grilla.RowCount; i++)
            {
                grilla.Rows[i].Cells["colFuncionalidades"].Value = getFuncionalidades(grilla.Rows[i].Cells["id_Rol"].Value.ToString());
            }

            UtilForms.AgregarSeleccionar(grilla);

            grilla.ResumeLayout();
        }

        private string getFuncionalidades(string Id_Rol)
        {
            string result = "";
            //TODO CRASHEA ACA, getFuncDelRol es una funcion y no un procedimiento
            SqlCommand cmd = new SqlCommand("TRIGGER_EXPLOSION.getFuncDelRol", ManejadorConexiones.conectar());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Id_Rol", Id_Rol));

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    result = result + rdr["Nombre"] + ", ";
                }
               
            }
            return (result.Length > 0) ? result.Remove(result.Length - 2, 2) : "";
        }



        private string makeQuery()
        {
            string query = "SELECT R.Id_Rol, R.Nombre FROM TRIGGER_EXPLOSION.Rol R";

            if (!filtroFuncCodgio.Equals(""))
            {
                query += " JOIN TRIGGER_EXPLOSION.RolXFuncionalidad RF " +
                         "ON (RF.Id_Rol = R.Id_Rol AND RF.Id_Funcionalidad = " + filtroFuncCodgio + ")";
            }

            if (!txtNombre.Text.Equals(""))
            {
                query += " WHERE R.Nombre LIKE \'%" + txtNombre.Text + "%\'";
            }

            return query;
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
            DoBuscar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
};