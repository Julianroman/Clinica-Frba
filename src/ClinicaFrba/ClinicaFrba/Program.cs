using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Registro_Llegada.RegistroDeLlegada());
            //Application.Run(new Registrar_Agenta_Medico.RegistrarAgenda());
            //Application.Run(new Pedir_Turno.Gestion_turno());
            //Application.Run(new Estadisticas.Estadisticas());
            //Application.Run(new LogIn.LogIn());
            Application.Run(new LogIn.LogIn());
            //Descomentar.
        }
    }
}
