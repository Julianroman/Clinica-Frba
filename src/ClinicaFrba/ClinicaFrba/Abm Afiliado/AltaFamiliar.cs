using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaFamiliar : Form
    {
        Int32 id_familiar_padre;

        public AltaFamiliar(Int32 id_familiar_padre)
        {
            this.id_familiar_padre = id_familiar_padre;
            InitializeComponent();
            //paraCerrar.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaAfiliado altaAfiliado = new AltaAfiliado("familiar", id_familiar_padre);
            altaAfiliado.Show();

        }
    }
}
