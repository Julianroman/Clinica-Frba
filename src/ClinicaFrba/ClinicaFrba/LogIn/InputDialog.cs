using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.LogIn
{
    public partial class InputDialog : Form
    {
        private Usuario usuario;

        public String newPass { get; set; }
        

        public InputDialog()
        {

            InitializeComponent();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_password.Text.Equals(""))
            {
                Interfaz.Interfaz.mostrarMensaje("La password no puede estar vacia!!!");
                return;
            }
            newPass = text_password.Text;
            this.Hide();
           
        }
    }
}
