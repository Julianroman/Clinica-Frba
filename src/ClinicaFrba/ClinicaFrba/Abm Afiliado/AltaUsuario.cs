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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaUsuario : Form
    {

        Interfaz.Interfaz interfaz = new Interfaz.Interfaz();


        String username;
        public AltaUsuario(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (interfaz.elementosEstanIncompletos())
            {
                MessageBox.Show("Por favor, complete los campos antes de enviar");
            }
            else
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("username", txtUsername.Text));
                parametros.Add(new SqlParameter("contrasenia", txtContrasenia.Text));
                ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.alta_usuario", parametros);
                MessageBox.Show("Usuario creado");
                this.Close();
            }
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            txtUsername.ReadOnly = true;

            interfaz.agregarElementoTextoAChequear(txtUsername);
            interfaz.agregarElementoTextoAChequear(txtContrasenia);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
