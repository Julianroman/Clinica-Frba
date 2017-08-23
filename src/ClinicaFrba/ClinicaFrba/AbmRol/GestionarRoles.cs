using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class GestionarRoles : Form
    {
        public GestionarRoles()
        {
            InitializeComponent();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            CrearRol rol = new CrearRol();
            rol.ShowDialog();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            EliminarRol rol = new EliminarRol();
            rol.ShowDialog();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ModificarRol rol = new ModificarRol();
            rol.ShowDialog();
        }
    }
}
