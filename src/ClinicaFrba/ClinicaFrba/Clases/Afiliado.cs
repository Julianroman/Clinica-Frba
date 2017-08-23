using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class Afiliado : Rol
    {

        SqlConnection miConector;

        private Plan plan;
        private Double total_consultas;
        private List<Usuario> familiares;
        private Usuario conyugue;
        private String estado_civil;
        private String nroAfiliado;
        private List<Bono> bonos;
        private List<Turno> turnos;

        public Afiliado(){}

        public Afiliado(Plan plan,
            Double total_consultas,
            String estado_civil,
            String nroAfiliado)
        {
            //El resto de las variables son opcionales por lo que se inicializaran aparte
            this.plan = plan;
            this.total_consultas = total_consultas;
            this.estado_civil = estado_civil;
            this.nroAfiliado = nroAfiliado;
        }

        public void agregarFamiliar(Usuario familiar)
        {
            this.familiares.Add(familiar);
        }

        public void setConyugue(Usuario conyugue)
        {
            this.conyugue = conyugue;
        }

       /* public void compraBono(int cantidad) {
       
            this.bonos = plan.venderBonos(cantidad);

            // Lo siguiente se hace ya que segun el enunciado cada bono debe tener cierta info del
            // afiliado que lo utilizo, como el total_consultas

            this.bonos.ForEach(b => b.setAfiliado(this));
        }

        public void notificarPlan(Usuario usuarioNuevo) 
        {
            this.plan.agregarAfiliado(usuarioNuevo);
        }

        public Boolean esAfiliado()
        {
            return true;
        }*/

        public void ActualizarGrid(DataGridView dg, String Query)
        {

            //conectarnos a la base de datos...

            this.miConector = ManejadorConexiones.conectar();

            //crear DataSet

            System.Data.DataSet MiDataSet = new System.Data.DataSet();

            //Crear Adaptador de datos
            SqlDataAdapter MiDataAdapter = new SqlDataAdapter(Query, miConector);


            //LLenar el DataSet
            MiDataAdapter.Fill(MiDataSet, "afiliado");

            //Asignarle el valor adecuado a las propiedades del DataGrid

            dg.DataSource = MiDataSet;
            dg.DataMember = "afiliado";

            //nos desconectamos de la base de datos...

            ManejadorConexiones.desconectar();

        }
    }
}
