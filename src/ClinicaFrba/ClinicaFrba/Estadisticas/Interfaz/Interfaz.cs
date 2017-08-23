using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace ClinicaFrba.Interfaz
{
    class Interfaz
    {

        public static  Usuario usuario { get; set; }

        public Interfaz(){}

        public static void login(Usuario usuario)
        {
            Interfaz.usuario = usuario;
        }


        public static void mostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }



        public static string bytesDeHasheoToString(byte[] array)
        {
            StringBuilder salida = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                salida.Append(array[i].ToString("X2"));
            }
            return salida.ToString();
        }

        public void cargarComboIDValor(ComboBox combo, String querySQL)
        {
            SqlDataReader valores = ManejadorConexiones.ExecuteReader(querySQL, null, ManejadorConexiones.conectar());

            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("valor");
            dt.Rows.Add("-1", "Seleccione una opción ....");
            dt.Load(valores);

            ManejadorConexiones.desconectar();

            combo.DataSource = null;
            combo.ValueMember = "id";
            combo.DisplayMember = "valor";
            combo.DataSource = dt;
        }


        public static List<Especialidad> getEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();


                return especialidades;

        }
    }
}
