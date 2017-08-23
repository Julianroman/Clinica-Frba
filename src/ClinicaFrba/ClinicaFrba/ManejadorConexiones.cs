using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;



namespace ClinicaFrba
{
    class ManejadorConexiones
    {
        public static string stringConexion;
        public static SqlConnection sqlConnection = new SqlConnection();


        public static SqlConnection conectar()
        {

            
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                return sqlConnection;
            }

            try
            {

                stringConexion = ConfigurationManager.AppSettings["ConnectionString"];
                sqlConnection.ConnectionString = stringConexion;
                sqlConnection.Open();

            }
            catch (SqlException e)
            {
                Interfaz.Interfaz.mostrarMensaje("Error al  abrir conexion con la base de datos: " + e.Message);
            }
            return sqlConnection;
        }


        public static void desconectar()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (SqlException)
            {

            }

        }

        public static DataTable ExecuteQuery(string procedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = null;
            try
            {
             
                adapter = new SqlDataAdapter(procedureName, conectar());
                adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();
                adapter.Fill(data);
                return (data.Rows.Count > 0) ? data : null;
            }
            catch (Exception e)
            {
                throw new SystemException("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                if (adapter != null) adapter.SelectCommand.Connection.Close();
                desconectar();
            }

        }

        public static Object ExecuteScalar(string query)
        {
            SqlDataAdapter adapter = null;
            try
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query, sqlConnection);
                Object result = adapter.SelectCommand.ExecuteScalar();
                return result;
            }
            catch (Exception e)
            {
                throw new SystemException("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                if (adapter != null) adapter.SelectCommand.Connection.Close();
            }

        }

        public static SqlDataReader ExecuteReader(string stringQuery, List<SqlParameter> parameters, SqlConnection conexion) 
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = stringQuery;
                if (parameters != null)
                    foreach (SqlParameter parametro in parameters)
                    {
                        if (parametro.Value == null)
                            parametro.Value = DBNull.Value;
                        command.Parameters.Add(parametro);
                    }
                return command.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new SystemException("Ha ocurrido un error en la base de datos", e);
            }
        }
    }
}
