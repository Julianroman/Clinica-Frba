using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet.Afiliado' Puede moverla o quitarla según sea necesario.
            
            List<SqlParameter> parametros = new List<SqlParameter>();
            ManejadorConexiones.conectar();
            DataTable tablaAfiliados = ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.getAfiliados", parametros);
            Afiliado afiliado = new Afiliado();
            afiliado.ActualizarGrid(this.dataGridView1, "select * from TRIGGER_EXPLOSION.Afiliado");

        }
    }
}
