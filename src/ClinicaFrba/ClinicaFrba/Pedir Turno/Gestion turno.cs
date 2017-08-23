using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Gestion_turno : Form
    {

        List<Especialidad> especialidades = new List<Especialidad>();
        Especialidad especialidadSeleccionada;
        Profesional profesionalSeleccionado;
        DateTime fechaSeleccionada;
        DateTime horaSeleccionada;


        public Gestion_turno()
        {
            InitializeComponent();
            comboBox__profesional.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_especialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Fechas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Horarios.DropDownStyle = ComboBoxStyle.DropDownList;
            
            cargarEspecialidades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                Interfaz.Interfaz.mostrarMensaje("Por favor seleccione todos los campos");
                return;
            }

            try
            {
                String seleccion = (String)comboBox_Horarios.SelectedItem;
                horaSeleccionada = Convert.ToDateTime(seleccion);
            }
            catch (Exception ex)
            {
               
            }

            if (horaSeleccionada == null || !(horaSeleccionada.Hour >= 7 && horaSeleccionada.Hour < 20))
            {
                Interfaz.Interfaz.mostrarMensaje("Seleccione un horario");
                return;
            }
            DateTime fechaCompleta = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, fechaSeleccionada.Day,
                                                    horaSeleccionada.Hour, horaSeleccionada.Minute, horaSeleccionada.Second);

        
         bool disponible =  Interfaz.Interfaz.turno_disponible(fechaCompleta, 
         Convert.ToInt32(profesionalSeleccionado.id), Convert.ToInt32(especialidadSeleccionada.id));

           if (disponible)
           {  
               int idAfiliado = Interfaz.Interfaz.usuario.getAfiliadoId();
               Interfaz.Interfaz.agregarTurno(idAfiliado,Convert.ToInt32(profesionalSeleccionado.id),
                                fechaCompleta,Convert.ToInt32(especialidadSeleccionada.id));
               

           }
           else Interfaz.Interfaz.mostrarMensaje("Horario no disponible!");

          
           this.Close();
        }


        private bool validarCampos()
        {
            if (comboBox__profesional.SelectedItem != null && comboBox_especialidad.SelectedItem != null
                    && comboBox_Fechas.SelectedItem != null && comboBox_Horarios.SelectedItem != null)
            {

                return true;
            }
            else
            {
                return false;
            }
                    
        }



        private void cargarEspecialidades()

        {
            especialidades =  Interfaz.Interfaz.getEspecialidades();

            //foreach (Especialidad especialidad in especialidades)
            //{
              //  comboBox_especialidad.Items.Add(especialidad.nombre);
           //}


            comboBox_especialidad.DisplayMember = "nombre";
            comboBox_especialidad.ValueMember = "id";
            comboBox_especialidad.DataSource = especialidades;
            comboBox_especialidad.SelectedIndex = -1;

            comboBox_especialidad.SelectionChangeCommitted += new System.EventHandler(EspecialidadesSelectedIndexChanged);
           // comboBox_especialidad.SelectedIndexChanged += new System.EventHandler(EspecialidadesSelectedIndexChanged);
            //comboBox_especialidad.SelectedIndex = 1;

         /*   try
            {
                especialidadSeleccionada = (Especialidad)comboBox_especialidad.SelectedItem;

                cargarProfesionalesPorEspecialidad(especialidadSeleccionada.id);
            }
            catch (Exception ex)
            {
                
            }*/
        



        }


        //Funcion llamada cada vez que se selecciona una especialidad
        private void EspecialidadesSelectedIndexChanged(object sender, System.EventArgs e)
        {
            especialidadSeleccionada = (Especialidad)comboBox_especialidad.SelectedItem;
            
            cargarProfesionalesPorEspecialidad(especialidadSeleccionada.id);

        }

        private void cargarProfesionalesPorEspecialidad(string especialidad_id)
        {
            List<Profesional> list = Interfaz.Interfaz.getProfesionalesPorEspecialidad(especialidad_id);
            comboBox__profesional.DisplayMember = "apellido";
            comboBox__profesional.ValueMember = "id";
            comboBox__profesional.DataSource = list;
            

            comboBox__profesional.SelectionChangeCommitted += new System.EventHandler(ProfesionalSelectedIndexChanged);

           
             comboBox_Fechas.SelectionChangeCommitted += new System.EventHandler(FechaSelectedIndexChanged);
             cargarFechasDisponiblesDelProfesional();   
        }


        private void FechaSelectedIndexChanged(object sender, System.EventArgs e)
        {
            fechaSeleccionada = (DateTime)comboBox_Fechas.SelectedItem;
            cargarHorariosDelProfesional();
        }

        private void ProfesionalSelectedIndexChanged(object sender, System.EventArgs e)
        {
            profesionalSeleccionado = (Profesional)comboBox__profesional.SelectedItem;
            cargarFechasDisponiblesDelProfesional();
        }

        //carga solo las fechas sin los horarios
        private void cargarFechasDisponiblesDelProfesional()
        {
            profesionalSeleccionado = (Profesional)comboBox__profesional.SelectedItem;
            if (profesionalSeleccionado == null)
            {
                return;
            }
           List<DateTime> fechasLibre = profesionalSeleccionado.getHorariosLibre(especialidadSeleccionada.nombre);
            List<DateTime> fechasSinHorarios = new List<DateTime>();

            foreach (DateTime fecha in fechasLibre){
                if(!fechasSinHorarios.Contains(fecha.Date))
                fechasSinHorarios.Add(fecha.Date);
            }
            comboBox_Fechas.DataSource = fechasSinHorarios;
            cargarHorariosDelProfesional();
        }



        private void cargarHorariosDelProfesional()
        {
            try
            {
                fechaSeleccionada = (DateTime)comboBox_Fechas.SelectedItem;
            }
            catch (Exception e)
            {
                return;
            }
           
            if (fechaSeleccionada == null) return;
            List<DateTime> fechasLibre = profesionalSeleccionado.getHorariosLibre(especialidadSeleccionada.nombre);
            List<String> horarios = new List<String>();

            DateTime fecha = fechaSeleccionada;
            fecha =  fecha.AddHours(7);
            while (fecha.Date == fechaSeleccionada.Date)
            {
                DateTime otraFecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour,fecha.Minute,fecha.Second);
                if (fechasLibre.Contains(otraFecha))
                {
                    if (fecha.Minute < 10)
                    {
                        horarios.Add(fecha.Hour + ":" + "0" + fecha.Minute);
                    }
                    else
                    {
                        horarios.Add(fecha.Hour + ":" + fecha.Minute);
                    }
                                      
                }
                fecha = fecha.AddMinutes(30);

            }

            comboBox_Horarios.DataSource = horarios;
            comboBox_Horarios.SelectionChangeCommitted += new System.EventHandler(HorarioSelectedIndexChanged);

          
         
           
        }


        private void HorarioSelectedIndexChanged(object sender, System.EventArgs e)
        {
            String seleccion =  (String) comboBox_Horarios.SelectedItem;
           horaSeleccionada =  Convert.ToDateTime(seleccion);
           Console.WriteLine("hora seleccionada");
        }

        private void comboBox_especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Gestion_turno_Load(object sender, EventArgs e)
        {

        }


    }
}
