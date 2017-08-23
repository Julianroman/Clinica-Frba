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
    public partial class ModificarRol : Form
    {
        SqlConnection conexion;
        SqlCommand cargarRoles, habilitado, funcPorRol, existeRol, cambiarNombre, idRol, idFunc, eliminarFunc, asignarFunc, cargarFunc, habilitar;
        SqlDataReader data;
        List<String> funcion = new List<String>();
        List<String> funcionesViejas = new List<String>();

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

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            string text = listBox2.GetItemText(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);

            funcion.Remove(text);
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            conexion = ManejadorConexiones.conectar();
            habilitar = new SqlCommand("TRIGGER_EXPLOSION.SP_habilitarRol", conexion);
            habilitar.CommandType = CommandType.StoredProcedure;
            habilitar.Parameters.Add("@nombre", SqlDbType.VarChar).Value = comboBox1.Text.ToString();
            habilitar.ExecuteNonQuery();
            ManejadorConexiones.desconectar();

            String mensaje = "El rol ha sido habilitado";
            String caption = "Rol modificado";
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
            btn_habilitar.Visible = false;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                modificarRol();
                cleanForm();
            }
        }

        string rol;

        private void button1_Click(object sender, EventArgs e)
        {
            rol = comboBox1.Text.ToString();
            int habilitado = estaHabilitado(rol);
            if (habilitado == 0)
                btn_habilitar.Visible = true;
            else
                btn_habilitar.Visible = false;
            label4.Visible = true;
            label3.Visible = true;
            txtBoxNombre.Visible = true;
            listBox1.Visible = true;
            listBox2.Visible = true;
            btn_quitar.Visible = true;
            btn_agregar.Visible = true;
            txtBoxNombre.Text = rol;
            btn_modificar.Visible = true;

            cargarFuncionalidadesPorRol(rol);
        }



        private void ModificarRol_Load(object sender, EventArgs e)
        {
            conexion = ManejadorConexiones.conectar();
            cargarRoles = new SqlCommand("TRIGGER_EXPLOSION.getRoles", conexion);
            cargarRoles.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cargarRoles);
            DataTable table = new DataTable();
            conexion.Close();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            cargarFuncionalidades();
        }




        public ModificarRol()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int estaHabilitado(String rol)
        {
            conexion.Open();
            habilitado = new SqlCommand("TRIGGER_EXPLOSION.RolHabilitado", conexion);
            habilitado.CommandType = CommandType.StoredProcedure;
            habilitado.Parameters.Add("@nombre", SqlDbType.VarChar).Value = rol;
            var resultado = habilitado.Parameters.Add("@Valor", SqlDbType.Bit);
            resultado.Direction = ParameterDirection.ReturnValue;
            data = habilitado.ExecuteReader();
            var habi = resultado.Value;
            int respuesta = (int)habi;
            conexion.Close();
            data.Close();
            return respuesta;
        }


        private void cargarFuncionalidadesPorRol(String rol)
        {

            List<String> funcionalidades = new List<string>();
            listBox2.Items.Clear();
            funcionesViejas.Clear();
            funcionalidades.Clear();
            funcion.Clear();
            conexion = ManejadorConexiones.conectar();
            funcPorRol = new SqlCommand("TRIGGER_EXPLOSION.FuncionalidadesPorRol", conexion);

            funcPorRol.CommandType = CommandType.StoredProcedure;
            funcPorRol.Parameters.Add("@Rol", SqlDbType.VarChar).Value = rol;

            SqlDataAdapter adapter = new SqlDataAdapter(funcPorRol);
            SqlDataReader reader = funcPorRol.ExecuteReader();

            while (reader.Read())
            {
                funcionalidades.Add(reader.GetString(0)); //Specify column index 
            }



            listBox2.Items.AddRange(funcionalidades.ToArray());
            reader.Close();

            listBox2.DisplayMember = "Nombre";
            ManejadorConexiones.desconectar();

            for (int i = 0; i < listBox2.Items.Count; i++)
            {

                string text = listBox2.GetItemText(listBox2.Items[i]);

                funcion.Add(text);
                funcionesViejas.Add(text);
            }

        }

        private Boolean validarCampos()
        {

            if (string.IsNullOrEmpty(txtBoxNombre.Text) || (int)listBox2.Items.Count == 0)
            {
                String mensaje = "Los campos nombre y funcionalidades son obligatorios";
                String caption = "Error al modificar el rol";
                MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                return false;
            }

            else
            {
                conexion = ManejadorConexiones.conectar();
                existeRol = new SqlCommand("TRIGGER_EXPLOSION.ExisteRol", conexion);
                existeRol.CommandType = CommandType.StoredProcedure;
                existeRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
                var resultado = existeRol.Parameters.Add("@Valor", SqlDbType.Int);
                resultado.Direction = ParameterDirection.ReturnValue;
                data = existeRol.ExecuteReader();
                var existeR = resultado.Value;
                data.Close();
                ManejadorConexiones.desconectar();

                if ((int)existeR == 1 && !(rol.Equals(txtBoxNombre.Text)))
                {
                    String mensaje = "El rol ya existe, ingrese otro nombre";
                    String caption = "Error al modificar el rol";
                    MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);
                    return false;
                }
                else
                    return true;
            }

        }

        private void modificarRol()
        {

            conexion = ManejadorConexiones.conectar();
            cambiarNombre = new SqlCommand("TRIGGER_EXPLOSION.ModificarNombreRol", conexion);
            cambiarNombre.CommandType = CommandType.StoredProcedure;
            cambiarNombre.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
            rol = comboBox1.Text.ToString();
            cambiarNombre.Parameters.Add("@anterior", SqlDbType.VarChar).Value = rol;
            cambiarNombre.ExecuteNonQuery();


            idRol = new SqlCommand("TRIGGER_EXPLOSION.ObtenerRolId", conexion);
            idRol.CommandType = CommandType.StoredProcedure;
            idRol.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBoxNombre.Text;
            var resultado = idRol.Parameters.Add("@Valor", SqlDbType.Decimal);
            resultado.Direction = ParameterDirection.ReturnValue;
            data = idRol.ExecuteReader();


            var idResult = resultado.Value;
            decimal id = (decimal.Parse(idResult.ToString()));
            data.Close();

            eliminarFunc = new SqlCommand("TRIGGER_EXPLOSION.EliminarFuncionalidades", conexion);
            eliminarFunc.CommandType = CommandType.StoredProcedure;
            eliminarFunc.Parameters.Add("@rol", SqlDbType.Decimal).Value = id;
            eliminarFunc.ExecuteNonQuery();
            conexion.Close();

            List<decimal> ids = new List<decimal>();


            for (int i = 0; i < funcion.Count(); i++)
            {
                conexion.Open();
                idFunc = new SqlCommand("TRIGGER_EXPLOSION.ObtenerFuncionalidadId", conexion);
                idFunc.CommandType = CommandType.StoredProcedure;
                idFunc.Parameters.Add("@nombre", SqlDbType.VarChar).Value = funcion.ElementAt(i).ToString();
                var resultado2 = idFunc.Parameters.Add("@Valor", SqlDbType.Decimal);
                resultado2.Direction = ParameterDirection.ReturnValue;
                data = idFunc.ExecuteReader();
                var id2 = resultado2.Value;
                decimal aniadir = decimal.Parse(id2.ToString());
                ids.Add(aniadir);
                data.Close();
                conexion.Close();
            }


            for (int i = 0; i < ids.Count(); i++)
            {

                conexion.Open();
                asignarFunc = new SqlCommand("TRIGGER_EXPLOSION.AsignarFuncionalidad", conexion);
                asignarFunc.CommandType = CommandType.StoredProcedure;
                asignarFunc.Parameters.Add("@idRol", SqlDbType.Decimal).Value = id;
                asignarFunc.Parameters.Add("@idFunc", SqlDbType.Decimal).Value = ids.ElementAt(i);
                asignarFunc.ExecuteNonQuery();
                conexion.Close();

            }

            String mensaje = "El rol se ha modificado correctamente";
            String caption = "Rol modificado";
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK);

            this.Close();

        }

        private void cargarFuncionalidades()
        {
            conexion = ManejadorConexiones.conectar();
            cargarFunc = new SqlCommand("TRIGGER_EXPLOSION.getFuncionalidades", conexion);
            cargarFunc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cargarFunc);
            DataTable table = new DataTable();
            adapter.Fill(table);
            SqlDataReader reader = cargarFunc.ExecuteReader();
            listBox1.DataSource = table;
            listBox1.DisplayMember = "Nombre";
            ManejadorConexiones.desconectar ();
        }

        private void cleanForm()
        {
            comboBox1.SelectedIndex = -1;
            btn_habilitar.Visible = false;
            btn_habilitar.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            txtBoxNombre.Clear();
            txtBoxNombre.Visible = false;
            listBox1.Visible = false;
            listBox2.Items.Clear();
            listBox2.Visible = false;
            btn_agregar.Visible = false;
            btn_quitar.Visible = false;
            btn_modificar.Visible = false;

        }
    }
}
