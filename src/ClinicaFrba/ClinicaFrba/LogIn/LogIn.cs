using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Interfaz;
using ClinicaFrba.Abm_Rol;
using ClinicaFrba.Clases;
using System.Security.Cryptography;


namespace ClinicaFrba.LogIn
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            textBox_password.PasswordChar = '*';
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
    

            if (!ValidarCampos())
                return;


            Usuario usuario = new Usuario(textBox_user.Text);

          

            if (!usuario.existeUsuario())
            {
                Interfaz.Interfaz.mostrarMensaje("El usuario no existe!!");
                return;
            }

            if (!usuario.estaHabilitado())
            {
                Interfaz.Interfaz.mostrarMensaje("El usuario no esta habilitado!! contactese con un administrador");
                return;
            }


            //Si es el primer login tomo como password lo que inserta el usuario ya que nunca se guardo la pass encriptada, si no lo paso al SHA256
            if (usuario.primerLogin)
            {
                usuario.Password = textBox_password.Text;
            }
            else
            {
                UTF8Encoding encoderHash = new UTF8Encoding();
                SHA256Managed hasher = new SHA256Managed();
                byte[] bytesDeHasheo = hasher.ComputeHash(encoderHash.GetBytes(textBox_password.Text));
                string password = Interfaz.Interfaz.bytesDeHasheoToString(bytesDeHasheo);
                usuario.Password = password;
            }


            if (usuario.checkPassword())
            {
                Interfaz.Interfaz.mostrarMensaje("Usuario logueado exitosamente!");
                usuario.resetearIntentos();
                if (usuario.primerLogin)
                {
                   
                    Interfaz.Interfaz.mostrarMensaje("Debido a que es la primera vez que se loguea luego de la migracion, es necesario que modifique su contrasena");
                    InputDialog formDialog  = new InputDialog();
                    formDialog.ShowDialog();
                    usuario.cambiarPassword(formDialog.newPass);
                    Interfaz.Interfaz.mostrarMensaje("La contraseña ha sido modificada");
                    usuario.setPrimeraVez(false);
                }



                Interfaz.Interfaz.usuario = usuario;
                //hace falta este?
                Repositorio.currentUser(usuario);
                SelectRolFuncionalidad rolDialog = new SelectRolFuncionalidad();
                rolDialog.ShowDialog();

            }
            else // LA PASSWORD ES INVALIDA
            {
                Interfaz.Interfaz.mostrarMensaje("La password es invalida");
                usuario.sumarIntentoFallido();
                if (usuario.getIntentosFallidos() == 3)
                {
                    usuario.deshabilitar();
                    Interfaz.Interfaz.mostrarMensaje("Su usuario ha sido deshabilitado por reiterados ingresos invalidos");


                }

            }

            

        }

        private bool ValidarCampos()
        {
            bool passoword_validation = true;
            bool user_validation = true;

            if (textBox_password.Text.Equals(""))
            {
                Interfaz.Interfaz.mostrarMensaje("El campo password esta vacio!");
                passoword_validation = false;
            }

            if (textBox_user.Text.Equals(""))
            {
                Interfaz.Interfaz.mostrarMensaje("El campo usuario esta vacio!");
                user_validation = false;
            }
            return user_validation && passoword_validation;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

