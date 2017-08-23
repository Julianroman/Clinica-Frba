using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroDeLlegada : Form

        
    {
        string[] elementos;
        int id_afiliado;
        Int64 total_numero_consultas;
        int id_profesional;
        bool ar;
        int especialidad;
        string date;

        int id;
        string fecha_programada;
        int consultas;
        int bono;
        int id_consulta=-1;
        string y;



        private void RegistroDeLlegada_Load(object sender, EventArgs e)
        {
            Cargar.Visible = false; 
            try
            {
                comboBox1.Items.Clear();
                SqlCommand cmd = new SqlCommand("select Descripcion from  TRIGGER_EXPLOSION.Especialidad", ManejadorConexiones.conectar());
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



        public RegistroDeLlegada()
        {
            InitializeComponent();
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {

            

            if(CheckCampos()){

                string sqlString2;

                id_afiliado= getIdAfiliado();

                ManejadorConexiones.desconectar();
                total_numero_consultas = Convert.ToInt64(ManejadorConexiones.ExecuteScalar("select top 1 Total_consultas_medicas FROM TRIGGER_EXPLOSION.Afiliado where id_afiliado = " + id_afiliado));
                ManejadorConexiones.conectar();
                if (!ar) { return; }

                
                id_profesional=getIdProfesional();

                if (!ar) { return; }
                

                date =ConfigurationManager.AppSettings["fechaSistema"];
                DateTime fechaSistema = DateTime.ParseExact(ConfigurationManager.AppSettings["fechaSistema"], "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);


                Console.Write(date);

                if (comboBox1.Text.Length != 0)
                {
                    int especialidad = getEspecialidadId();
                    sqlString2 = " select id_turno, Nombre,Apellido, Fecha_programada, Descripcion from TRIGGER_EXPLOSION.Turno, TRIGGER_EXPLOSION.Especialidad, TRIGGER_EXPLOSION.Profesional where Profesional.Id_profesional=Turno.Id_profesional and Especialidad_id=Id_especialidad and Descripcion='" + comboBox1.Text + "' and id_afiliado=" + id_afiliado + " and FORMAT(Fecha_programada,'yyyy-MM-dd') ='" + fechaSistema.ToString("yyyy-MM-dd") + "' and Cancelado=0 and Fecha_y_hora_llegada is null";                   // sqlString2 = "UPDATE TRIGGER_EXPLOSION.Turno SET Fecha_y_hora_llegada='" + date + "' where Id_afiliado=" + id_afiliado + "and Id_profesional=" + id_profesional + "and Especialidad_id=" + especialidad + " and Id_turno=(select top 1 Id_turno from TRIGGER_EXPLOSION.Turno where Id_afiliado=" + id_afiliado + " and Id_profesional=" + id_profesional + " AND Fecha_programada >= '"+date+ "' order by Fecha_programada asc )";

                }
                else {

                    sqlString2 = " select id_turno, Nombre,Apellido, Fecha_programada, Descripcion from TRIGGER_EXPLOSION.Turno, TRIGGER_EXPLOSION.Especialidad, TRIGGER_EXPLOSION.Profesional where Profesional.Id_profesional=Turno.Id_profesional and Especialidad_id=Id_especialidad and Fecha_y_hora_llegada is null and id_afiliado=" + id_afiliado + " and FORMAT(Fecha_programada,'yyyy-MM-dd') = '" + fechaSistema.ToString("yyyy-MM-dd") + "'";
                }

                Console.WriteLine(sqlString2);
                if (!ar) { return; }


                Interfaz.Interfaz.cargarGrilla(dataGridView1, sqlString2);
                     // dataGridView1.DataSource=;
                //DataGridView grilla, String querySQL
             

                
            }
            
        }




        public void InsertConsultaMedica() {

          /*  string sql = "Select  Fecha_programada,id_turno from TRIGGER_EXPLOSION.Turno where Fecha_y_hora_llegada='" + date + "' and Id_afiliado=" + id_afiliado + "and Id_profesional=" + id_profesional + "and Especialidad_id=" + especialidad;

            SqlCommand cmd = new SqlCommand(sql, ManejadorConexiones.conectar());//Agregar este Stored

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var a = reader.GetValue(0);
                    fecha_programada = Convert.ToString(reader.GetValue(0));
                    Console.WriteLine(fecha_programada);

                    id_consulta = Convert.ToInt32(reader.GetValue(1));
                    
                }

                reader.Close();

                DateTime fechaNew = DateTime.ParseExact(fecha_programada, "dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


                string y = fechaNew.ToString("yyyy-dd-MM HH:mm");

                */
            

                string checkId="select * from TRIGGER_EXPLOSION.ConsultaMedica where id_consulta="+id_consulta;

                SqlCommand cmdCheck = new SqlCommand(checkId, ManejadorConexiones.conectar());//Agregar este Stored

                 SqlDataReader reader3 = cmdCheck.ExecuteReader();

                 if (reader3.HasRows)
                 {
                     MessageBox.Show("Ya se registro una llegada previamente");
                     reader3.Close();
                 }else{
                     reader3.Close();
                    string sql2 = "insert into TRIGGER_EXPLOSION.ConsultaMedica ( Fecha_y_hora ) values ( '" + y + "' )";

                    SqlCommand cmd2 = new SqlCommand(sql2, ManejadorConexiones.conectar());//Agregar este Stored

                    cmd2.ExecuteNonQuery();

                  }

                


/*
            }
            else
            {
                Console.WriteLine("La llegada no se cargo correctamente");
                reader.Close();
                return;
            }

            */


            return;

        
        }
        public  bool CheckCampos()
        {


            if (Documento.Text.Length == 0 || Nombre.Text.Length == 0 || Profesional.Text.Length == 0  )
            {
                MessageBox.Show("Campos Vacios");
                return false;
            }
            else
            {
               

                    return true;
               
             //   return true;
            }
        }


        public int getIdProfesional()
        {



            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Id_profesional FROM TRIGGER_EXPLOSION.Profesional WHERE Nombre ='" + Regex.Replace(Nombre.Text, @"\s+", "") + "' AND Apellido='" + Regex.Replace(Profesional.Text, @"\s+", "") + "'", ManejadorConexiones.conectar()); //Agregar este Stored



                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();


                    int a = Convert.ToInt32(reader.GetValue(0));
                    id_profesional = a;


                    reader.Close();
                }

                ar = true;

            }
            catch
            {
                MessageBox.Show("No se encontro el profesional en la base de datos");
                ar = false;
            }

            
            return id_profesional;
        }

        public int getIdAfiliado()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Id_afiliado FROM TRIGGER_EXPLOSION.Afiliado WHERE Numero_documento =" + Regex.Replace(Documento.Text, @"\s+", ""), ManejadorConexiones.conectar()); //Agregar este Stored



                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();


                    int a = Convert.ToInt32(reader.GetValue(0));
                    id_afiliado = a;
                    Console.WriteLine(id_afiliado);

                    reader.Close();
                }

                ar = true;

            }
            catch
            {
                MessageBox.Show("El documento ingresado no corresponde a un afiliado");
                ar = false;
            }

            return id_afiliado;
        }

        public int getEspecialidadId()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("select Id_especialidad From TRIGGER_EXPLOSION.Especialidad where Descripcion='" + comboBox1.Text + "'", ManejadorConexiones.conectar()); //Agregar este Stored



                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();


                    int a = Convert.ToInt32(reader.GetValue(0));
                    especialidad = a;



                }

                ar = true;

            }
            catch
            {
                MessageBox.Show("La especialidad ingresada no existe");
                ar = false;
            }

            return especialidad;

         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool checkBonos()
        {
            
            string sql = "select Total_consultas_medicas from TRIGGER_EXPLOSION.Afiliado where Id_afiliado="+id_afiliado;

            SqlCommand cmd = new SqlCommand(sql, ManejadorConexiones.conectar()); //Agregar este Stored

            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                consultas = Convert.ToInt32(reader.GetValue(0));

            }


            int firstDigit = getBaseNumber();

           // firstDigit= firstDigit*100;

            int limitDigit= firstDigit +100;


            string query = "select top 1 Id_bono from TRIGGER_EXPLOSION.Bono where id_afiliado_comprador between "+firstDigit+" and "+limitDigit+" AND id_usado_por is NULL";

            SqlCommand cmd2 = new SqlCommand(query, ManejadorConexiones.conectar());

             using (SqlDataReader reader = cmd2.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bono = Convert.ToInt32(reader.GetValue(0));
                        return true;
                    }

                    reader.Close();

                    return true;
                }
                else
                {
                    MessageBox.Show("No posee bonos para realizar la consulta, por favor compre primero");
                    ManejadorConexiones.desconectar();
                    this.Close();
                    return false;
                }

            }
           

        }

        public void InsertarEnBono() {

            string query = "UPDATE TRIGGER_EXPLOSION.Bono SET Numero_consulta_medica="+total_numero_consultas+" , Id_usado_por ='" + id_afiliado + "' ,Fecha_impresion='"+date+"' where Id_bono="+bono;

            SqlCommand cmd = new SqlCommand(query, ManejadorConexiones.conectar());

            cmd.ExecuteNonQuery();

            string query2 = "UPDATE TRIGGER_EXPLOSION.Afiliado SET Total_consultas_medicas="+(consultas+1)+" where id_afiliado="+id_afiliado;

            SqlCommand cmd2 = new SqlCommand(query2, ManejadorConexiones.conectar());

            cmd2.ExecuteNonQuery();


            return;
        }



        public int getBaseNumber() {

            
            if (id_afiliado > 999)
            {
                string afiString = id_afiliado.ToString();

                string test = afiString.Substring(0, afiString.Length-2) +"00";

               // int firstDigit = Convert.ToInt32(test);
                return Convert.ToInt32(test);
            }
            else {
                return (int)(id_afiliado.ToString()[0]) - 48;
            }

        }


        private void Documento_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Profesional_TextChanged(object sender, EventArgs e)
        {

        }

        private void FechaYHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void Especialidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int FilaSeleccionada = e.RowIndex;
            id_consulta = Convert.ToInt32(dataGridView1.Rows[FilaSeleccionada].Cells["Id_turno"].Value.ToString());
            y = dataGridView1.Rows[FilaSeleccionada].Cells["Fecha_programada"].Value.ToString();

            if (id_consulta == 0)
            {
                MessageBox.Show("No existe ningun turno en para confirmar en el día de hoy");
            }
            else {
                Cargar.Visible = true;
            }
        }


      

        private void Cargar_Click(object sender, EventArgs e)
        {
            if (id_consulta == -1) {
                MessageBox.Show("Debe elegir un turno");
                return;
            }

            if (checkBonos())
            {
                string sqlString2 = "UPDATE TRIGGER_EXPLOSION.Turno SET Fecha_y_hora_llegada='" + date + "' where Id_turno="+id_consulta;


                SqlCommand command2 = new SqlCommand(sqlString2, ManejadorConexiones.conectar());//Agregar este Stored

                if (command2.ExecuteNonQuery() == 0) { MessageBox.Show("Los datos no se cargaron correctamente intente nuevamente"); return; }

                InsertConsultaMedica();
                InsertarEnBono();

                ManejadorConexiones.desconectar();
                MessageBox.Show("CARGA EXITOSA"); 
                this.Close();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      

       
    }


}
