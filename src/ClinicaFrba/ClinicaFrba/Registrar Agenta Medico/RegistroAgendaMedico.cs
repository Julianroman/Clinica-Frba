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
using System.Globalization;
using ClinicaFrba.Interfaz;
using System.Configuration;
using System.Text.RegularExpressions;





namespace ClinicaFrba.Registrar_Agenta_Medico
{
      

    public partial class RegistrarAgenda : Form
    {

        public int user_id =Convert.ToInt32(Interfaz.Interfaz.usuario.Id_usuario);
       
        public int retorno;

        public int id_agenda;

        List<string> virtualDays = new List<string>();

        public bool boolSabado=false;

        public int id_profesional;
     

        DateTime fechaSistema;

        //string[] diasLaborales = { };

        List<List<string>> diasLaborales = new List<List<string>>();

        public RegistrarAgenda()
        {
            InitializeComponent();
        }

        private void Aceptar_Click_1(object sender, EventArgs e)
        {
            string  prueba= Regex.Replace("melania miranda cardenas", @"\s+", "");



            

            diasLaborales.Clear();


            id_profesional = getProfesionalId();

            generarArrayDias();

          
            if (checkCampos() && CheckRangoHorario() && check48Horas() && CheckExistenciaEspecialidad())
            {

                AgregarDataEnAgenda();

                AgregarEnDiasDisponibles();

                MessageBox.Show("Carga de Agenda exitosa!!");
                this.Close();
               
                
            }
  
        }

        public void generarArrayDias()
        {

            CheckBox[] dias = { Lunes, Martes, Miercoles, Jueves, Viernes, Sabado};

            int i;


            for (i = 0; i < dias.Length; i++)
            {
                List<string> tupla = new List<string>();


                if (dias[i].Checked)
                {
                            if (dias[i].Text != "Sábado")
                            {
                                tupla.Add(dias[i].Text);
                                if(horaInit.Text.Length!=0){ tupla.Add(horaInit.Text);};
                                if (horaFin.Text.Length != 0) { tupla.Add(horaFin.Text); };
                                
                            }
                            else {
                                tupla.Add(dias[i].Text);
                                if(horaInitS.Text.Length!=0){ tupla.Add(horaInitS.Text);};
                                if(horaFinS.Text.Length!=0){ tupla.Add(horaFinS.Text);};
                            }
                            diasLaborales.Add(tupla);
                            Console.WriteLine(tupla);
                }
                
                

           }




        }

        private bool checkCampos()
        {
            if (FechaFin.Text.Length == 0 || FechaInit.Text.Length == 0 || comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Algunos campos no pueden estar vacios");

                return false;
            } 
            
            if (diasLaborales.Count != 0)
            {

                for(int i=0; i< diasLaborales.Count; i++){
                    
                    if(diasLaborales[i].Count!=3){
                        MessageBox.Show("Los rangos horarios deben estar completos");
                        return false;
                    };

                   
            
                }

                try
                {
                    string format = "yyyy-MM-dd";
                    var provider = new CultureInfo("es-AR");
                    DateTime.ParseExact(Regex.Replace(FechaInit.Text, @"\s+", ""), format, provider);
                    DateTime.ParseExact(Regex.Replace(FechaFin.Text, @"\s+", ""), format, provider);

                    DateTime fechaInicial = DateTime.ParseExact(Regex.Replace(FechaInit.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime fechaFinal = DateTime.ParseExact(Regex.Replace(FechaFin.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    //string fechaS =ConfigurationManager.AppSettings["fechaSistema"];   
                    //string fechaSis = fechaS.ToString("yyyy-MM-dd");  
                    fechaSistema = DateTime.ParseExact(ConfigurationManager.AppSettings["fechaSistema"], "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                    if (fechaInicial.Date < fechaSistema.Date || fechaFinal.Date < fechaInicial.Date)
                    {
                        MessageBox.Show("Las fechas ingresadas no son posteriores a la fecha del sistema ó la fecha incial es superior a la final");
                        return false;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Datos ingresados en un formato incorrecto");
                    return false;
                }

                return true;

            }else{
                MessageBox.Show("Debe elegir almenos un dia para la agenda");
                return false;
            }

        }
        
        public bool CheckRangoHorario()
        {

            DateTime LimiteSabInicial = DateTime.ParseExact("10:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime LimiteSabFinal= DateTime.ParseExact("15:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            DateTime limiteInicial = DateTime.ParseExact("07:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime limiteFinal = DateTime.ParseExact("20:00", "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            for (int i = 0; i < diasLaborales.Count;i++ ) {


               DateTime timeInicial = DateTime.ParseExact(diasLaborales[i][1].ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
               DateTime timeFinal = DateTime.ParseExact(diasLaborales[i][2].ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

               if (timeFinal  < timeInicial)
               {
                        MessageBox.Show("Los horarios estan ingresados de manera incorrecta, la Hora inicial debe ser inferior a la hora final");

                        return false;
                   }
            
            }

            return true;
        }


        private bool check48Horas()
        {
            double totalHoras = 0;

            for (int i = 0; i < diasLaborales.Count; i++)
            {

                DateTime timeInicial = DateTime.ParseExact(diasLaborales[i][1].ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime timeFinal = DateTime.ParseExact(diasLaborales[i][2].ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                TimeSpan difference = timeFinal - timeInicial;
                double diffInHours = difference.TotalHours;
                totalHoras = totalHoras + diffInHours;

            }

            DateTime fechaInicial = DateTime.ParseExact(Regex.Replace(FechaInit.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            DateTime fechaFinal = DateTime.ParseExact(Regex.Replace(FechaFin.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            String query = "select (SUM(DATEDIFF(MINUTE,dd.inicio_jornada,dd.fin_jornada)) / 60)  FROM TRIGGER_EXPLOSION.Dias_disponible dd JOIN TRIGGER_EXPLOSION.Agenda ag ON dd.Id_agenda = ag.Id_agenda and DATEDIFF(DAY,ag.Fecha_fin,CONVERT(DATETIME,'"
                + fechaSistema.Date + "')) <= 0 JOIN TRIGGER_EXPLOSION.Profesional p  ON ag.Id_profesional = p.Id_profesional and p.Id_profesional = "
                + id_profesional + "  and dd.Dia != 'Domingo'"
                + "and DATEDIFF(DAY,ag.Fecha_fin,CONVERT(DATETIME,'"+fechaInicial.Date
                +"')) < 0 and  (DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,'"+fechaInicial.Date+"')) >= 0  OR (DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,'"
                +fechaInicial.Date+"')) >=0 AND DATEDIFF(DAY,ag.Fecha_inicio,CONVERT(DATETIME,'"
                +fechaFinal.Date+"')) >=0))" 
                + "group by p.Id_profesional";
          
            
            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                if (reader.Read())
                { // ya tiene una agenda registrada, cuento los dias laborales que ya tiene

                    var a = reader.GetValue(0);


                    if ((Convert.ToInt32(a) + totalHoras) > 48)
                    {
                        MessageBox.Show("La sumatoria de sus agendas superan las 48 horas semanales");
                        reader.Close();
                        return false;
                    }
                    else
                    {
                        reader.Close(); 
                        return true;
                    }
                    

                }
                else
                {// no tiene ninguna agenda registrada
                    if ((totalHoras) > 48) { MessageBox.Show("Los horarios superan las 48 horas semanales"); return false; } else { return true; }
                }


            }




        }

        private void AgregarDataEnAgenda()
        {
           
                using (SqlConnection sqlConnection = ManejadorConexiones.conectar())
                {//FORMAT(Now(),'YYYY-MM-DD')

                    DateTime fechaInicial = DateTime.ParseExact(Regex.Replace(FechaInit.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime fechaFinal = DateTime.ParseExact(Regex.Replace(FechaFin.Text, @"\s+", ""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    string query = "INSERT INTO TRIGGER_EXPLOSION.Agenda (Id_profesional, Fecha_inicio,Fecha_fin, Especialidad)VALUES (" + id_profesional + ",  '" + fechaInicial + "' ,'" + fechaFinal + "', '" + comboBox1.Text + "')";
      
                    SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar()); 

                    cmd.ExecuteNonQuery();

                    
                }


               
           
        }


        private bool CheckExistenciaEspecialidad() {

            string query = "select * from TRIGGER_EXPLOSION.Agenda where id_profesional =" + id_profesional + " and Especialidad='" + comboBox1.Text + "' and year(Fecha_inicio)="+fechaSistema.Year;


            SqlCommand sqlCommand = new SqlCommand(query, ManejadorConexiones.conectar());

            SqlDataReader reader = sqlCommand.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Close();
                MessageBox.Show("Ya existe una agenda con la especialidad seleccionada");
                return false;
            }
            else {
                reader.Close();
                return true;
            }
        }
        
        
        private void AgregarEnDiasDisponibles()
        {

            if (getIdAgenda()) {

                for (int i = 0; i < diasLaborales.Count; i++) {

                    string insertSabado = "insert into TRIGGER_EXPLOSION.Dias_disponible (Id_agenda, Dia, inicio_jornada, fin_jornada) values(" + id_agenda + ",'" + diasLaborales[i][0].ToString() + "','" + diasLaborales[i][1].ToString() + "', '" + diasLaborales[i][2].ToString() + "')";


                        SqlCommand cmd = new SqlCommand(insertSabado, ManejadorConexiones.conectar()); //Agregar este Stored

                        cmd.ExecuteNonQuery();

               
                }

                return;
            };

            
            return;
        }






        public int  getProfesionalId() {


            string sqlQuery = "SELECT Id_profesional FROM TRIGGER_EXPLOSION.Profesional  WHERE Id_usuario =" + user_id;


            SqlCommand sqlCommand = new SqlCommand(sqlQuery, ManejadorConexiones.conectar());

            SqlDataReader reader = sqlCommand.ExecuteReader();
          

            if (reader.HasRows)
            {
                while (reader.Read())

                    
                {
                     var a = reader.GetValue(0);


                     reader.Close();
                     return Convert.ToInt32(a);
                    
                }
            }
            else
            {
                MessageBox.Show("No es un numero de profesional valido");
                reader.Close();
            }

           

            return 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarAgenda_Load_1(object sender, EventArgs e)
        {

            try
            {
                comboBox1.Items.Clear();
                SqlCommand cmd = new SqlCommand("select Descripcion from  TRIGGER_EXPLOSION.ProfesionalXEspecialidad,  TRIGGER_EXPLOSION.Especialidad where id_profesional="+getProfesionalId()+" and Especialidad.Id_especialidad=ProfesionalXEspecialidad.Id_especialidad", ManejadorConexiones.conectar());
                cmd.ExecuteNonQuery();
                DataTable data = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(data);

                foreach (DataRow dr in data.Rows)
                {
                    comboBox1.Items.Add(dr["Descripcion"]).ToString();
                }


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

      
        public bool getIdAgenda() {

            string sender = "select Id_agenda from TRIGGER_EXPLOSION.Agenda where Id_profesional="+id_profesional+" and Especialidad='"+comboBox1.Text+"'";
           


           
            Console.WriteLine(sender);
            SqlCommand sqlCommand = new SqlCommand(sender, ManejadorConexiones.conectar());

            SqlDataReader reader = sqlCommand.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var a = reader.GetValue(0);


                    id_agenda = Convert.ToInt32(a);
                }

                reader.Close();

                return true;
            }
            else
            {
               
         

                reader.Close();
                MessageBox.Show("Hubo un error en el cargado De los dias disponibles");
                
                return false;


            }

            

        }

        private void horaInit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void horaFin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Miercoles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Jueves_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Viernes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Sabado_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Lunes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Martes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FechaInit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FechaFin_TextChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        private void horaInitS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void horaFinS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

}
}



   
