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
        public static List<Especialidad> especialidades { get; set; }
        public static List<Profesional> profesionales { get; set; }
        private List<Control> elementosTextoQueNoDebenEstarIncompletos = new List<Control>();
        private List<ComboBox> elementosComboBoxQueNoDebenEstarIncompletos = new List<ComboBox>();

        public Interfaz(){}

        public static void login(Usuario usuario)
        {
            Interfaz.usuario = usuario;
        }

        public bool elementosEstanIncompletos()
        {
            // Nota, it works
            if (elementosComboBoxQueNoDebenEstarIncompletos.Count() == 0)
            {
                return elementosTextoQueNoDebenEstarIncompletos.TrueForAll(elem => String.IsNullOrEmpty(elem.Text));
            }
            else
            {
                if (
                    elementosTextoQueNoDebenEstarIncompletos.TrueForAll(elem => !String.IsNullOrEmpty(elem.Text))
                    && elementosComboBoxQueNoDebenEstarIncompletos.TrueForAll(elem => elem.SelectedIndex > 0)
                    ) return false;

                return true;
            }
        }

        public void agregarElementoTextoAChequear(Control elem)
        {
            this.elementosTextoQueNoDebenEstarIncompletos.Add(elem);
        }

        public void agregarElementoComboBoxAChequear(ComboBox elem)
        {
            this.elementosComboBoxQueNoDebenEstarIncompletos.Add(elem);
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

        public static void cargarGrilla(DataGridView grilla, String querySQL)
        {
            SqlDataReader valores = ManejadorConexiones.ExecuteReader(querySQL, null, ManejadorConexiones.conectar());

            DataTable dt = new DataTable();

            dt.Load(valores);

            ManejadorConexiones.desconectar();

            grilla.DataSource = null;
            grilla.DataSource = dt;
        }

        public static void cargarGrillaSP(DataGridView grilla, String storeProcedure, List<SqlParameter> parametros)
        {
            DataTable dt = ManejadorConexiones.ExecuteQuery(storeProcedure, parametros);

            grilla.DataSource = null;
            grilla.DataSource = dt;
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

        public static  List<Especialidad> getEspecialidades()
        {
            if (especialidades != null) return especialidades;

         especialidades = new List<Especialidad>();
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                String query = "SELECT Id_especialidad, Descripcion FROM TRIGGER_EXPLOSION.Especialidad";
                using (var cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            especialidades.Add(new Especialidad(row.Field<string>("Descripcion"),
                                   Convert.ToString(row.Field<decimal>("Id_especialidad")) ));
                        }
                    }

                }
            }

            return especialidades;

        }


        public static List<Profesional> getProfesionales()
        {
            profesionales = new List<Profesional>();
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                String query = "SELECT * FROM TRIGGER_EXPLOSION.Profesional";
                using (var cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            profesionales.Add(new Profesional(
                                   Convert.ToString(row.Field<decimal>("Id_profesional")),
                                   row.Field<string>("Nombre"),
                                   row.Field<string>("Apellido")
                                   ));
                        }
                    }

                }
            }

            return profesionales;
        }



        public static void agregarTurno(int id_afiliado, int id_profesional, DateTime fecha, int especialidad  )
        {
            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                String query = "INSERT INTO  TRIGGER_EXPLOSION.Turno (Id_afiliado, Id_profesional, Fecha_programada, Especialidad_id) VALUES (@afiliado, @profesional, @fecha, @especialidad)";
                using (var cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                    cmd.Parameters.Add("@afiliado", SqlDbType.Int).Value = id_afiliado;
                    cmd.Parameters.Add("@profesional", SqlDbType.Int).Value = id_profesional;
                    cmd.Parameters.Add("@especialidad", SqlDbType.Int).Value = especialidad;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        mostrarMensaje("El turno ha sido guardado!");

                    }
                    catch (Exception e)
                    {
                        mostrarMensaje("No se pudo guardar el turno, seleccione otra fecha");
                    }
                   

                }
            }
        }

        public static bool turno_disponible(DateTime date, int id_medico, int id_especialidad)
        {
            
                String query = "SELECT  TRIGGER_EXPLOSION.FX_get_Disponibilidad(@fecha, @id, @especialidad)";
                SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_medico;
                cmd.Parameters.Add("@especialidad", SqlDbType.Int).Value = id_especialidad;

                   int disponible = (int) cmd.ExecuteScalar();

                   cmd.Dispose();
                   ManejadorConexiones.desconectar();
                   if (disponible == 1) return true;
                   else return false;

                
            

        }

        public static List<Profesional> getProfesionalesPorEspecialidad(string id_especialidad)
        {
            if (profesionales == null) getProfesionales();

            List<Profesional> filtrado = new List<Profesional>();
            
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                String query = "SELECT Id_especialidad, Id_profesional FROM TRIGGER_EXPLOSION.ProfesionalXEspecialidad";
                using (var cmd = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            string especialidad = Convert.ToString(row.Field<decimal>("Id_especialidad"));
                            string id_profesional = Convert.ToString(row.Field<decimal>("Id_profesional"));

                            if (especialidad == id_especialidad)
                            {
                                
                                foreach (Profesional profesional in profesionales)
                                {
                                    if (profesional.id == id_profesional) filtrado.Add(profesional);
                                }
                            }
                           
                        }
                    }

                }
            }

            return filtrado;
        }
      
    }
}
