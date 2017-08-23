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
    public partial class CrearRol : Form
    {
        SqlCommand cargarFuncionalidades, existeRol, crearRolNuevo, RolId, FuncId, asignarFunc;
        SqlDataReader data;
        decimal rol = 0;
        List<String> funcion = new List<String>();

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public CrearRol()
        {
            InitializeComponent();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                crearNuevoRol();
                cleanForm();
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);

            if (funcion.Contains(text))
            {

                String mensaje = "Esta funcionalidad ya ha sido ingresada";
                String caption = "Funcionalidad duplicada";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            }
            else
            {

                listBox2.DisplayMember = "Nombre";
                listBox2.Items.Add((DataRowView)listBox1.SelectedItem);

                funcion.Add(text);

            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            string text = listBox2.GetItemText(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);

            funcion.Remove(text);
        }

        private void CrearRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = ManejadorConexiones.conectar();
            cargarFuncionalidades = new SqlCommand("TRIGGER_EXPLOSION.getFuncionalidades", conexion);
            cargarFuncionalidades.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cargarFuncionalidades);
            DataTable table = new DataTable();
            adapter.Fill(table);
            SqlDataReader reader = cargarFuncionalidades.ExecuteReader();
            listBox1.DataSource = table;
            listBox1.DisplayMember = "Nombre";
            ManejadorConexiones.desconectar();
        }

        private Boolean validarCampos()
        {
            if (string.IsNullOrEmpty(txtBoxNombre.Text) || (int)listBox2.Items.Count == 0)
            {
                String mensaje = "Los campos nombre y funcionalidades son obligatorios";
                String caption = "Error al crear el rol";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                SqlConnection conexion = ManejadorConexiones.conectar();
                existeRol = new SqlCommand("TRIGGER_EXPLOSION.ExisteRol", conexion);
                existeRol.CommandType = CommandType.StoredProcedure;
                existeRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
                var resultado = existeRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = existeRol.ExecuteReader();
                var existeR = resultado.Value;
                data.Close();
                ManejadorConexiones.desconectar();

                if ((int)existeR == 1)
                {
                    String mensaje = "El rol ya existe, ingrese otro nombre";
                    String caption = "Error al crear el rol";
                    MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                    return false;
                }
                else
                    return true;
            }
        }

        private void crearNuevoRol()
        {
            SqlConnection conexion = ManejadorConexiones.conectar();
            crearRolNuevo = new SqlCommand("TRIGGER_EXPLOSION.SP_altaRol", conexion);
            crearRolNuevo.CommandType = CommandType.StoredProcedure;
            crearRolNuevo.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
            crearRolNuevo.ExecuteNonQuery();


            RolId = new SqlCommand("TRIGGER_EXPLOSION.obtenerRolId", conexion);
            RolId.CommandType = CommandType.StoredProcedure;
            RolId.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
            var resultado = RolId.Parameters.Add("@Valor", SqlDbType.Decimal);
            resultado.Direction = ParameterDirection.ReturnValue;
            data = RolId.ExecuteReader();
            ManejadorConexiones.desconectar();

            var idRol = resultado.Value;
            rol = decimal.Parse(idRol.ToString());
            data.Close();

            crearFuncionalidades();

        }

        private void crearFuncionalidades()
        {

            List<decimal> ids = new List<decimal>();


            for (int i = 0; i < funcion.Count(); i++)
            {
                SqlConnection conexion = ManejadorConexiones.conectar();
                FuncId = new SqlCommand("TRIGGER_EXPLOSION.obtenerFuncionalidadId", conexion);
                FuncId.CommandType = CommandType.StoredProcedure;
                FuncId.Parameters.Add("@nombre", SqlDbType.VarChar).Value = funcion.ElementAt(i).ToString();
                var resultado = FuncId.Parameters.Add("@Valor", SqlDbType.Decimal);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = FuncId.ExecuteReader();
                var id = resultado.Value;
                decimal aniadir = decimal.Parse(id.ToString());
                ids.Add(aniadir);
                data.Close();
                ManejadorConexiones.desconectar();
            }

            for (int i = 0; i < ids.Count(); i++)
            {

                SqlConnection conexion = ManejadorConexiones.conectar();
                asignarFunc = new SqlCommand("TRIGGER_EXPLOSION.asignarFuncionalidad", conexion);
                asignarFunc.CommandType = CommandType.StoredProcedure;
                asignarFunc.Parameters.Add("@idRol", SqlDbType.Decimal).Value = rol;
                asignarFunc.Parameters.Add("@idFunc", SqlDbType.Decimal).Value = ids.ElementAt(i);
                asignarFunc.ExecuteNonQuery();
                ManejadorConexiones.desconectar();

            }

            rol = 0;
            String mensaje = "El rol se ha creado exitosamente";
            String caption = "Rol creado";
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
            this.Close();

        }

        private void cleanForm()
        {
            txtBoxNombre.Clear();
            listBox2.Items.Clear();
        }


    }
}
