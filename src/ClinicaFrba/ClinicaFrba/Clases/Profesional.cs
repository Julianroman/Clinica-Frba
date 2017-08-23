using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Profesional 
    {
        private String matricula;
        private List<Especialidad> especialidades;
        private Agenda agenda;
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string id { get; set; }


        public Profesional(string id)
        {
            this.id = id;
        }

        public Profesional(string id, string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;

        }


        public DateTime getFechaFin(String especialidad, int idAgenda)
        {

            DateTime date = new DateTime();
            String query = "SELECT Fecha_fin FROM TRIGGER_EXPLOSION.Agenda where Id_profesional = @id and Especialidad = @especialidad and Id_agenda = @agenda";
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@especialidad", especialidad);
            cmd.Parameters.Add("@agenda", SqlDbType.Int).Value = idAgenda;

            using (SqlDataReader reader = cmd.ExecuteReader()){
                if (reader.Read())
                {
                    date = Convert.ToDateTime(reader["Fecha_fin"]);
                }
               
               cmd.Dispose();
               ManejadorConexiones.desconectar();
            }
            return date;
        }


        public DateTime getFechaInicio(String especialidad, int idAgenda)
        {

            DateTime date = new DateTime();
            String query = "SELECT Fecha_inicio FROM TRIGGER_EXPLOSION.Agenda where Id_profesional = @id and Especialidad = @especialidad and Id_agenda = @agenda";
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@especialidad", especialidad);
            cmd.Parameters.Add("@agenda", SqlDbType.Int).Value = idAgenda;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    date = Convert.ToDateTime(reader["Fecha_inicio"]);
                }
                cmd.Dispose();
                ManejadorConexiones.desconectar();
            }
            return date;
        }





        //La idea es obtener una lista de todas las fechas en las que el profesional tiene un turno asignado 
        //No deberia importarme de que especialidad es ese turno ya que sea de cual sea esa fecha no estara disponible
        //no me interesan las fechas que ya vencieron, paso por parametro la fecha del sistema
        public List<DateTime> getFechasOcupado()
        {
            List<DateTime> lista = new List<DateTime>();

            String query = "select Fecha from TRIGGER_EXPLOSION.getFechasDeTurnos(@afiliado,  @fecha)";
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());
            cmd.Parameters.Add("@afiliado", SqlDbType.Int).Value = this.id;
            String fechaSistema = ConfigurationManager.AppSettings["fechaSistema"];
            cmd.Parameters.Add("@fecha",fechaSistema);

            using (SqlDataReader reader = cmd.ExecuteReader()){

                while (reader.Read())
                {
                  
                    lista.Add(Convert.ToDateTime(reader["Fecha"]));
                }

                cmd.Dispose();
                ManejadorConexiones.desconectar();

            }

            return lista;
        }


        //Devuelve todos los ID de agenda para los cuales el profesional tiene una agenda registrada en esa especialidad
        public List<Int64> getIdDeAgendasDelProfesional(String especialidad)
        {
            List<Int64> lista = new List<Int64>();
            String query = "select Id FROM TRIGGER_EXPLOSION.getIdDeAgendasPorEspecialidad(@profesional,@especialidad,@fecha)";
            SqlCommand cmd = new SqlCommand(query,ManejadorConexiones.conectar());
            cmd.Parameters.Add("@profesional",SqlDbType.Int).Value = this.id;
            cmd.Parameters.Add("@especialidad",SqlDbType.VarChar).Value = especialidad;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = ConfigurationManager.AppSettings["fechaSistema"];

            using (SqlDataReader reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    lista.Add(Convert.ToInt64(reader["Id"]));

                }
                cmd.Dispose();
                ManejadorConexiones.desconectar();
            }
            return lista;
        }


        public  int diferenciaDeMeses(DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }

        //retorna una lista con todas las fechas posibles de asignacion de un turno
        //requiere la especialidad
        public List<DateTime> getHorariosLibre(String especialidad)
        {
            List<DateTime> lista = new List<DateTime>();
            List<DateTime> listaOcupados = getFechasOcupado();

           List<Int64> listaIDsdDeAgendas =  getIdDeAgendasDelProfesional(especialidad);


            foreach(int id in listaIDsdDeAgendas){
                
           DateTime fechaInicio = getFechaInicio(especialidad,id);
            DateTime fechaFin =  getFechaFin(especialidad,id);

            DateTime fechaSistema = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            DateTime fecha = fechaSistema; //fecha sobre la que voy a iterar

           //evito que se procesen todas las fechas mas alla de X cantidad de meses para evitar demasiado procesamiento
            int diff = diferenciaDeMeses(fechaFin, fechaSistema);
            if (diff >= 4)
            {
                fechaFin = fechaSistema.AddMonths(4);
            }

            // Seteamos a la hora que abre la clínica para optimizar el algoritmo
            TimeSpan ts = new TimeSpan(7, 0, 0);
            fecha = fecha.Date + ts;
            if (fecha.Date.CompareTo(fechaInicio.Date) < 0) fecha = fechaInicio; //segun fecha del sistema todavia el profesional no arranco a atender

            while(fecha.Date.CompareTo(fechaFin.Date) <= 0){ // si devuelve menor a cero el primer date es mas viejo que el segundo
                             
                    if (fecha.DayOfWeek != DayOfWeek.Sunday) // domingos no cuentan!
                    {
                        if (fecha.DayOfWeek == DayOfWeek.Saturday) // si es sabado tiene distintos horarios
                        {
                            if (fecha.Hour >= 10 && fecha.Hour < 15)
                            {
                                if (!listaOcupados.Contains(fecha))
                                {
                                    if (horarioEstaDentroDeLosLaborablesDelProfesional(fecha.DayOfWeek, fecha, especialidad, id))
                                    {
                                        lista.Add(fecha);
                                    }
                                }                               
                            }
                        }
                        else // es dia de semana
                        {
                            if (fecha.Hour >= 7 && fecha.Hour < 20)
                            {
                                if (!listaOcupados.Contains(fecha))
                                {
                                    if (horarioEstaDentroDeLosLaborablesDelProfesional(fecha.DayOfWeek, fecha, especialidad, id))
                                    {
                                           lista.Add(fecha);
                                      }
                                  
                                   
                                }                              
                            }
                        }
                    }

                    fecha = fecha.AddMinutes(30);                
            }

            }

            return lista;
        }


        //le paso un dia de la semana  y una hora y minuto  determinada y me dice si esta entre las 
        //que trabaja el profesional en la especialidad indicada

        public Boolean horarioEstaDentroDeLosLaborablesDelProfesional(DayOfWeek dia, int hora, int minuto, String especialidad)
        {
            if (dia == DayOfWeek.Sunday) return false;

            String nombreDia = "";
            switch (dia)
            {
                case DayOfWeek.Friday: { nombreDia = "Viernes"; break;    }
                case DayOfWeek.Monday:{ nombreDia = "Lunes"; break;    }
                case DayOfWeek.Saturday:{nombreDia = "Sábado"; break;}
                case DayOfWeek.Thursday: {nombreDia = "Jueves"; break;}
                case DayOfWeek.Tuesday: {nombreDia = "Martes"; break;}
                case DayOfWeek.Wednesday: {nombreDia = "Miércoles"; break;}
               

            }

            String query = "select hora_inicio, hora_fin from TRIGGER_EXPLOSION.getHorarioDisponibleDelDia(@NombreEspecialidad,@NombreDia,@IdProfesional)";
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());


            cmd.Parameters.Add("@NombreEspecialidad", SqlDbType.VarChar).Value = especialidad;
             cmd.Parameters.Add("@NombreDia", SqlDbType.VarChar).Value = nombreDia;
             cmd.Parameters.Add("@IdProfesional", SqlDbType.Int).Value = this.id;


             using (SqlDataReader reader = cmd.ExecuteReader())
             {

                 if (reader.Read())
                 {                
                     TimeSpan horaInicio = (TimeSpan)(reader["hora_inicio"]);
                     TimeSpan horaFin = (TimeSpan)(reader["hora_fin"]);
                     cmd.Dispose();
                     ManejadorConexiones.desconectar();

                    
                     if (hora >= horaInicio.Hours )
                     {
                         if (hora < horaFin.Hours)
                         {
                             

                             return true;
                         }
                         else if (hora == horaFin.Hours && minuto < horaFin.Minutes)
                         {
                             return true;
                         }
                         else return false;
                     }
                     /*else if (hora == horaInicio.Hours && minuto >= horaInicio.Minutes)
                     {
                         if (hora < horaFin.Hours)
                         {
                             return true;
                         }
                         else if (hora == horaFin.Hours && minuto < horaFin.Minutes)
                         {
                             return true;
                         }
                         else return false;
                     }*/
                     else
                     {
                         return false;
                     }
                    

                 }
                 else
                 {
                     cmd.Dispose();
                     ManejadorConexiones.desconectar();
                     return false;
                 }

            

             }
        }


        public Boolean horarioEstaDentroDeLosLaborablesDelProfesional(DayOfWeek dia, DateTime fecha, String especialidad, int idAgenda)
        {
             if (dia == DayOfWeek.Sunday) return false;

            String nombreDia = "";
            switch (dia)
            {
                case DayOfWeek.Friday: { nombreDia = "Viernes"; break;    }
                case DayOfWeek.Monday:{ nombreDia = "Lunes"; break;    }
                case DayOfWeek.Saturday:{nombreDia = "Sábado"; break;}
                case DayOfWeek.Thursday: {nombreDia = "Jueves"; break;}
                case DayOfWeek.Tuesday: {nombreDia = "Martes"; break;}
                case DayOfWeek.Wednesday: {nombreDia = "Miércoles"; break;}
               

            }

            String query = "select hora_inicio, hora_fin from TRIGGER_EXPLOSION.getHorarioDisponibleDelDia(@NombreEspecialidad,@NombreDia,@IdProfesional, @IdAgenda)";
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());


            cmd.Parameters.Add("@NombreEspecialidad", SqlDbType.VarChar).Value = especialidad;
             cmd.Parameters.Add("@NombreDia", SqlDbType.VarChar).Value = nombreDia;
             cmd.Parameters.Add("@IdProfesional", SqlDbType.Int).Value = this.id;
             cmd.Parameters.Add("@IdAgenda", SqlDbType.Int).Value = idAgenda;


             using (SqlDataReader reader = cmd.ExecuteReader())
             {

                 if (reader.Read())
                 {
                     TimeSpan horaInicio = (TimeSpan)(reader["hora_inicio"]);
                     TimeSpan horaFin = (TimeSpan)(reader["hora_fin"]);
                     cmd.Dispose();
                     ManejadorConexiones.desconectar();

                     if (fecha.Hour == horaFin.Hours && fecha.Minute == horaFin.Minutes)
                     {
                         return false;

                     }
                     else
                     {
                         return (TimeBetween(fecha, horaInicio, horaFin));
                     }

                     


                 }
                 else
                 {
                     cmd.Dispose();
                     ManejadorConexiones.desconectar();
                     return false;
                 }

            

             }
        }


        bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
        {


            // convert datetime to a TimeSpan
            TimeSpan now = datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }

        public List<String> getFechasEnString(String especialidad)
        {
            List<DateTime> fechas = getHorariosLibre(especialidad);
        List<String> lista = new List<String>();

            foreach(DateTime fecha in fechas){
                lista.Add(Convert.ToString(fecha));

            }


            return lista;

        }
   

    }


}
