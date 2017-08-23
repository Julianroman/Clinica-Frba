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
using System.Text.RegularExpressions;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaAfiliado : Form
    {
        Interfaz.Interfaz interfaz = new Interfaz.Interfaz();
        String existeElUsuario;
        String mode;
        Int32 id_afiliado_padre;

        public AltaAfiliado()
        {
            InitializeComponent();
        }

        public AltaAfiliado(String mode, Int32 id_afiliado_padre)
        {
            this.id_afiliado_padre = id_afiliado_padre;
            this.mode = mode;
            InitializeComponent();
        }

        private void Box_tipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            if (mode == "familiar")
            {
                Box_cantidadFamiliares.Text = "0";
                Box_cantidadFamiliares.Hide();
                labelCantFamiliares.Hide();
            }
            else
            {

                interfaz.agregarElementoTextoAChequear(Box_cantidadFamiliares);

            }

            this.Box_fechaNac.MaxDate = DateTime.Now;
            String getTiposDeDocumento = "select Id_tipo_documento id, Descripcion valor from TRIGGER_EXPLOSION.TipoDocumento";
            interfaz.cargarComboIDValor(this.comboBox1, getTiposDeDocumento);
            String getEstadoCivil = "select Id_estado_civil id, Descripcion valor from TRIGGER_EXPLOSION.EstadoCivil";
            interfaz.cargarComboIDValor(this.comboBox3, getEstadoCivil);
            String getPlanesMedicos = "select Id_plan id, Descripcion valor from TRIGGER_EXPLOSION.PlanMedico";
            interfaz.cargarComboIDValor(this.comboBox4, getPlanesMedicos);
            this.comboBox2.Text = "Seleccione una opción ....";
            this.comboBox2.Items.Add("Seleccione una opción ....");
            this.comboBox2.Items.Add("masculino");
            this.comboBox2.Items.Add("femenino");

            //Agrego todos los campos que son obligatorios
            interfaz.agregarElementoTextoAChequear(textBoxUsername);
            interfaz.agregarElementoTextoAChequear(Box_apellido);
            interfaz.agregarElementoTextoAChequear(Box_direccion);
            interfaz.agregarElementoTextoAChequear(Box_documento);
            interfaz.agregarElementoTextoAChequear(Box_mail);
            interfaz.agregarElementoTextoAChequear(Box_nombre);
            interfaz.agregarElementoTextoAChequear(Box_telefono);
            interfaz.agregarElementoComboBoxAChequear(comboBox2);
            interfaz.agregarElementoComboBoxAChequear(comboBox3);
            interfaz.agregarElementoComboBoxAChequear(comboBox1);
            interfaz.agregarElementoComboBoxAChequear(comboBox4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (interfaz.elementosEstanIncompletos())
            {
                MessageBox.Show("Por favor, complete todos los campos antes de enviar");
            }
            else
            {
                if (textBoxUsername.Text == "") // El administrador desconoce el username
                {
                    existeElUsuario = "SELECT * FROM TRIGGER_EXPLOSION.Usuario WHERE Username = '" + Box_documento.Text + "'";
                    username = Box_documento.Text;
                }
                else
                {
                    existeElUsuario = "SELECT * FROM TRIGGER_EXPLOSION.Usuario WHERE Username = '" + textBoxUsername.Text + "'";
                    username = textBoxUsername.Text;
                }


                if (
                    (!Regex.IsMatch(Box_telefono.Text, @"^\d+$")
                    || !Regex.IsMatch(Box_documento.Text, @"^\d+$")
                    || !Regex.IsMatch(Box_cantidadFamiliares.Text, @"^\d+$")
                    )
                   )
                {
                    MessageBox.Show("Los campos de Telefono, Documento y Cantidad Familiares deben ser numéricos");
                    return;
                }

                try
                {
                    parametros.Add(new SqlParameter("username", username));
                    parametros.Add(new SqlParameter("nombre", Box_nombre.Text));
                    parametros.Add(new SqlParameter("apellido", Box_apellido.Text));
                    parametros.Add(new SqlParameter("descripcion_tipo_documento", comboBox1.Text));
                    parametros.Add(new SqlParameter("numero_documento", Convert.ToInt32(Box_documento.Text)));
                    parametros.Add(new SqlParameter("sexo", comboBox2.Text));
                    parametros.Add(new SqlParameter("direccion", Box_direccion.Text));
                    parametros.Add(new SqlParameter("telefono", Convert.ToInt32(Box_telefono.Text)));
                    parametros.Add(new SqlParameter("mail", Box_mail.Text));
                    parametros.Add(new SqlParameter("fecha_nacimiento", Box_fechaNac.Value.Date));
                    parametros.Add(new SqlParameter("descripcion_estado_civil", comboBox3.Text));
                    parametros.Add(new SqlParameter("descripcion_plan_medico", comboBox4.Text));
                    parametros.Add(new SqlParameter("cantidad_familiares", Convert.ToInt32(Box_cantidadFamiliares.Text)));
                    parametros.Add(new SqlParameter("id_afiliado_padre", id_afiliado_padre));
                }catch(Exception ex){
                    Interfaz.Interfaz.mostrarMensaje("Revise que todos los datos insertados tengan un formato correcto");
                    return;
                }
              




                Object usuario = ManejadorConexiones.ExecuteScalar(existeElUsuario);
                if (usuario == null) // Aun no existe el usuario
                {
                    MessageBox.Show("Por favor, cree el usuario para continuar con la alta del Afiliado");
                    AltaUsuario altaUsuario = new AltaUsuario(username);
                    altaUsuario.ShowDialog();
                }
                else
                {
                    ManejadorConexiones.ExecuteQuery("TRIGGER_EXPLOSION.alta_afiliado", parametros);
                    if (mode == "familiar")
                    {
                        MessageBox.Show("Familiar creado con éxito");
                        this.Close();
                    }
                    else
                    {
                        id_afiliado_padre = Convert.ToInt32(ManejadorConexiones.ExecuteScalar("Select * FROM TRIGGER_EXPLOSION.Afiliado where Numero_documento = " + Convert.ToInt32(Box_documento.Text)));
                        AltaFamiliar altaFamiliar = new AltaFamiliar(id_afiliado_padre);
                        //this.Hide();
                        altaFamiliar.Closed += (s, args) => this.Close();
                        altaFamiliar.BringToFront();
                        altaFamiliar.Show();

                    }
                    
                }

            }


        }

        private void Box_documento_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Box_documento_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Box_documento_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Box_documento.Text)) { MessageBox.Show("Por favor complete el numero de documento"); return; }
            if (!Regex.IsMatch(Box_documento.Text, @"^\d+$"))
            {
                MessageBox.Show("Este campo solo admite valores numericos");
                Box_documento.Text = "";
                return;
            }

            Int64 nroDoc = Convert.ToInt64(Box_documento.Text);

            Object result = ManejadorConexiones.ExecuteScalar("select TRIGGER_EXPLOSION.YaExisteAfiliadoConDocumento(" + nroDoc + ", '" + comboBox1.Text + "')");
            Boolean yaExisteNroDocumento = Convert.ToBoolean(result);

            if (yaExisteNroDocumento)
            {
                MessageBox.Show("Ya existe un afiliado con ese numero de documento, por favor, indique otro");
                Box_documento.Text = "";
                return;
            }


        }

        private void Box_telefono_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(Box_telefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Este campo solo admite valores numericos");
                Box_telefono.Text = "";
            }
        }

        private void Box_cantidadFamiliares_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(Box_cantidadFamiliares.Text, @"^\d+$"))
            {
                MessageBox.Show("Este campo solo admite valores numericos");
                Box_cantidadFamiliares.Text = "";
                return;
            }

        }


    }
}

