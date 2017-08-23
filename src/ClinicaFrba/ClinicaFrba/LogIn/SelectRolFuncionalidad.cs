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
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Abm_Rol;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Registro_Resultado;
using ClinicaFrba.Cancelar_Turno;
using ClinicaFrba.Estadisticas;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.AbmRol;

namespace ClinicaFrba.LogIn
{
    public partial class SelectRolFuncionalidad : Form
    {
        private Interfaz.Interfaz interfaz = new Interfaz.Interfaz();
        private Interfaz.Interfaz interfaz2 = new Interfaz.Interfaz();

        public SelectRolFuncionalidad()
        {
            InitializeComponent();
        }

        public class itemComboBox
        {
            public string Nombre_Rol { get; set; }
            public int ID_Rol { get; set; }

            public itemComboBox(string nombre, int id)
            {
                Nombre_Rol = nombre;
                ID_Rol = id;
            }
            public override string ToString()
            {
                return Nombre_Rol;
            }
        }



        private void getFunc() {
            String query2 = "select * from TRIGGER_EXPLOSION.getFuncDelRol('" + comboBox1.Text + "')";
                interfaz2.cargarComboIDValor(this.comboBox2, query2);
        }

        

        private void button1_Click(object sender, EventArgs e){}

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0) { this.getFunc(); };
            Repositorio.getUserActual().setRolActual(this.comboBox1.Text) ;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e){}

        private void SelectRolFuncionalidad_Load(object sender, EventArgs e)
        {


              String query = "select * from TRIGGER_EXPLOSION.getRolesDelUsuario('" + Repositorio.getUserActual().getUserId() + "')";
              interfaz.cargarComboIDValor(this.comboBox1, query);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Cargar Agenda":

                    RegistrarAgenda registroAgenda = new RegistrarAgenda();
                    registroAgenda.ShowDialog();
                    break;
                case "Sacar Turno":
                    Gestion_turno gestionTurno = new Gestion_turno();
                    gestionTurno.ShowDialog();
                    break;
                case "Comprar Bonos":
                    CompraBono compraBono = new CompraBono();
                    compraBono.ShowDialog();
                    break;
                case "ABM Afiliado":
                    ABM_Afiliado_Inicio abmAfiliado = new ABM_Afiliado_Inicio();
                    abmAfiliado.ShowDialog();
                    break;
                case "ABM Rol":
                    GestionarRoles abmRol = new GestionarRoles();
                    abmRol.ShowDialog();
                    break;
                case "Estadisticas":
                    Estadisticas.Estadisticas estadistica = new Estadisticas.Estadisticas();
                    estadistica.ShowDialog();
                    break;
                case "Cancelar Turno":
                    if (comboBox1.Text == "Afiliado")
                    {
                        AfiliadoCancelarTurno afiliadoCancelaTurno = new AfiliadoCancelarTurno();
                        afiliadoCancelaTurno.ShowDialog();
                    }
                    else
                    {
                        MedicoCancelarTurno medicoCancelaTurno = new MedicoCancelarTurno();
                        medicoCancelaTurno.ShowDialog();
                    }
                    break;
                case "Registrar Diagnostico":
                    RegistrarResultado diagnostico = new RegistrarResultado();
                    diagnostico.ShowDialog();
                    break;
                case "Registrar Llegada Paciente":
                    RegistroDeLlegada llegada = new RegistroDeLlegada();
                    llegada.ShowDialog();
                    break;
            }
        }
    }
}
