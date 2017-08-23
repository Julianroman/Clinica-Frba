using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;



namespace ClinicaFrba
{
    class Usuario
    {

        public int Id_usuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public Documento documento { get; set; }
        public String sexo { get; set; }
        public Auth autentificacion { get; set; }
        public HashSet<Rol> roles { get; set; }
        public Boolean primerLogin {get;set;}
        public String rolActual { get; set; }

        public void setRolActual(String rol) {
            this.rolActual = rol;
        }

        public Usuario(string username)
        {
            this.Username = username;
            getId();
            getPrimerLogin();
            Interfaz.Interfaz.login(this);
        }

        public Usuario(string nombreX,
                       string apellidoX,
                       string direccionX,
                       string telefonoX,
                       string mailX,
                       int diaNacimiento,
                       int mesNacimiento,
                       int anioNacimiento,
                       string nroDocumento,
                       string tipoDocumento,
                       string sexoX,
                       string username,
                       string password)
        {
            apellido = apellidoX;
            direccion = direccionX;
            telefono = telefonoX;
            mail = mailX;
            fechaDeNacimiento = new DateTime(anioNacimiento, mesNacimiento, diaNacimiento);
            documento = new Documento(nroDocumento, tipoDocumento);
            sexo = sexoX;
            autentificacion = new Auth(username, password);
        }

      /*  public void agregarRol(Afiliado afiliado) 
        {
            //calling a hash set's Add(item) method returns a Boolean value: true if the item was added, 
            //and false otherwise (because it was already found in the set).

            if(!this.roles.Add(afiliado)) throw new OverflowException("Ya existe el rol especificado en este usuario");
            
            // Necesitamos los planes sepan quienes son sus afiliados asi que los notificaremos
            afiliado.notificarPlan(this);
        }*/


        public Boolean existeUsuario()
        {
            SqlCommand sqlCommand = getSqlCommandQueryByUsername();

            try
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();

               
                if(reader.HasRows){
                    reader.Close();
                    return true;
                } else{
                    reader.Close();
                    return false;

                }

         
        
            }
            catch (SqlException e)
            {
                Interfaz.Interfaz.mostrarMensaje("Error al hacer consulta existeUsuario()" + e.Message);
            }

            ManejadorConexiones.desconectar();
            return false;
          

        }


    

        public Boolean estaHabilitado()
        {
        

            try
            {
                string sqlQuery = "SELECT Habilitado FROM TRIGGER_EXPLOSION.Usuario WHERE Username = @user";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
                sqlCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = this.Username;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Int32 habilitado = Convert.ToInt32(reader["Habilitado"]);
                        ManejadorConexiones.desconectar();
                        return habilitado == 1;
                    }
                    else
                    {
                        ManejadorConexiones.desconectar();
                        return false;
                    }

                }

              

            }
            catch (SqlException e)
            {
                Interfaz.Interfaz.mostrarMensaje("Se produjo un error al consultar usuario habilitado: " + e.Message);

            }

            ManejadorConexiones.desconectar();
            return false;
        }

        //devuelve un SqlCommand con la consulta del usuario por Username, recordar desconectar
        private SqlCommand getSqlCommandQueryByUsername()
        {
            string sqlQuery = "SELECT Username FROM TRIGGER_EXPLOSION.Usuario WHERE Username = @user";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
            sqlCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = this.Username;
            return sqlCommand;
        }



        public int getId()
        {
            string sqlQuery = "SELECT Id_usuario FROM TRIGGER_EXPLOSION.Usuario WHERE Username = @user";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
            sqlCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = this.Username;

            using (var reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    Int32 id = Convert.ToInt32(reader["Id_usuario"]);
                    sqlCommand.Dispose();
                    ManejadorConexiones.desconectar();
                    this.Id_usuario = id;
                    return id;
                }
                else
                {
                    sqlCommand.Dispose();
                    ManejadorConexiones.desconectar();
                    return 0;
                }
            }
         

        }


        public Boolean getPrimerLogin()
        {
                using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                string sqlQuery = "SELECT Primer_login FROM TRIGGER_EXPLOSION.Usuario WHERE Id_usuario = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id_usuario;

                using (var reader = sqlCommand.ExecuteReader())
                {
                    reader.Read();
                    this.primerLogin = Convert.ToInt32(reader["Primer_login"]) == 1;
                    return this.primerLogin;
                }

            }
        }


        public Boolean checkPassword()
        {
            if (this.Id_usuario == 0) getId();

          

          using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                string sqlQuery = "SELECT 1 FROM TRIGGER_EXPLOSION.Usuario WHERE Id_usuario = @ID AND Contrasenia = @Pass";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id_usuario;
                sqlCommand.Parameters.Add("@Pass", SqlDbType.VarChar).Value = this.Password;

                using (var reader = sqlCommand.ExecuteReader())
                {
                    reader.Read();
                    return reader.HasRows;
                }

            }

           
          
        }


        public void resetearIntentos()
        {
            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                using(SqlCommand cmd = new SqlCommand("TRIGGER_EXPLOSION.SP_ResetIntentos",sqlConnection)){

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_usuario", SqlDbType.VarChar).Value = this.Id_usuario;

                    cmd.ExecuteNonQuery();
                }

                

            }

        }



        public void cambiarPassword(string newPassword)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            SHA256Managed managed = new SHA256Managed();
            byte[] bytes = managed.ComputeHash(encoding.GetBytes(newPassword));

            string password = Interfaz.Interfaz.bytesDeHasheoToString(bytes);
            using (SqlConnection conn = ManejadorConexiones.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("TRIGGER_EXPLOSION.SP_CambiarPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id_usuario", SqlDbType.VarChar).Value = this.Id_usuario;
                    cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = password;

                    cmd.ExecuteNonQuery();

                }

            }

        }



        public void setPrimeraVez(Boolean value)
        {
            using (SqlConnection conn = ManejadorConexiones.conectar())
            {
                using (SqlCommand command = new SqlCommand("TRIGGER_EXPLOSION.SP_PrimeraVez", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = this.Id_usuario;
                    int primeraVez;
                    if (value) primeraVez = 1;
                    else primeraVez = 0;
                    command.Parameters.Add("@Value", SqlDbType.Int).Value = primeraVez;

                    command.ExecuteNonQuery();

                }

            }

        }


        public void sumarIntentoFallido()
        {
            using (SqlConnection conn = ManejadorConexiones.conectar())
            {
                using (SqlCommand command = new SqlCommand("TRIGGER_EXPLOSION.SP_SumarIntentoFallido", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id_usuario", SqlDbType.VarChar).Value = this.Id_usuario;
                    command.ExecuteNonQuery();

                }

            }
        }


        public int getIntentosFallidos()
        {

            using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
            {
                string sqlQuery = "SELECT Intentos_fallidos FROM TRIGGER_EXPLOSION.Usuario WHERE Id_usuario = @ID";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id_usuario;
  

                using (var reader = sqlCommand.ExecuteReader())
                {
                    reader.Read();
                    if (reader.HasRows)
                    {
                        return Convert.ToInt32(reader["Intentos_fallidos"]);
                    }
                    else throw new System.ArgumentException("Parece ser que el Usuario " + this.Id_usuario + " no tiene intentos fallidos");
                       
                }

            }
        }



        public int getAfiliadoId()
        {
            String query = "select Id_afiliado from TRIGGER_EXPLOSION.Afiliado where Id_usuario = @id";

            SqlCommand cmd = new SqlCommand(query,ManejadorConexiones.conectar());
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = this.Id_usuario;

            using(var reader = cmd.ExecuteReader()){

                if (reader.Read())
                {
                    return Convert.ToInt32(reader["Id_afiliado"]);
                }
                else return -1;
            }
        }


        public void deshabilitar()
        {
            using (SqlConnection conn = ManejadorConexiones.conectar())
            {
                using (SqlCommand command = new SqlCommand("TRIGGER_EXPLOSION.SP_DesHabilitarUsuario", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id_usuario", SqlDbType.VarChar).Value = this.Id_usuario;
                    command.ExecuteNonQuery();

                }

            }

        }



        public void habilitar()
        {
            using (SqlConnection conn = ManejadorConexiones.conectar())
            {
                using (SqlCommand command = new SqlCommand("TRIGGER_EXPLOSION.SP_HabilitarUsuario", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id_usuario", SqlDbType.VarChar).Value = this.Id_usuario;
                    command.ExecuteNonQuery();

                }

            }

        }




        public Boolean esProfesional() { return this.roles.Any(r => r.esProfesional()); }
        public Boolean esAfiliado() { return this.roles.Any(r => r.esAfiliado()); }

        //////////////////////
        // Setters & Getters//
        //////////////////////

        public String getUserId() {
            return this.Username;
        }
    }
}
