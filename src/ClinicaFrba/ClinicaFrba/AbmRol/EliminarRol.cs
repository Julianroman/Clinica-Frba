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

namespace ClinicaFrba.AbmRol
{
    public partial class EliminarRol : Form

    {
        SqlCommand cargarRoles, idRol, inhabilitar, inhabilitarPorUsuario;

        private void EliminarRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = ManejadorConexiones.conectar();
            cargarRoles = new SqlCommand("TRIGGER_EXPLOSION.getRolesHabilitados", conexion);
            cargarRoles.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cargarRoles);
            DataTable table = new DataTable();
            ManejadorConexiones.desconectar();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Nombre";
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar el rol seleccionado?", "Eliminar Rol", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string nombre = comboBox1.Text.ToString();
                SqlConnection conexion = ManejadorConexiones.conectar();
                idRol = new SqlCommand("TRIGGER_EXPLOSION.ObtenerRolId", conexion);
                idRol.CommandType = CommandType.StoredProcedure;
                idRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                var resultado = idRol.Parameters.Add("@Valor", SqlDbType.Decimal);
                resultado.Direction = ParameterDirection.ReturnValue;
                SqlDataReader dataReader = idRol.ExecuteReader();

                var id = resultado.Value;
                decimal rol = decimal.Parse(id.ToString());
                dataReader.Close();
                //inhabilitar rol

                inhabilitar = new SqlCommand("TRIGGER_EXPLOSION.SP_deshabilitarRol", conexion);
                inhabilitar.CommandType = CommandType.StoredProcedure;
                inhabilitar.Parameters.Add("@id_rol", SqlDbType.Decimal).Value = rol;
                inhabilitar.ExecuteNonQuery();

                inhabilitarPorUsuario = new SqlCommand("TRIGGER_EXPLOSION.inhabilitarRolXUsuario", conexion);
                inhabilitarPorUsuario.CommandType = CommandType.StoredProcedure;
                inhabilitarPorUsuario.Parameters.Add("@id", SqlDbType.Decimal).Value = rol;
                inhabilitarPorUsuario.ExecuteNonQuery();
                conexion.Close();

                String mensaje = "El rol se ha eliminado exitosamente";
                String caption = "Rol eliminado";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

                this.Close();
            }
        }

        public EliminarRol()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
