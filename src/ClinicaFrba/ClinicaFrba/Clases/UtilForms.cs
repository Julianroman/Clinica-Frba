using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    class UtilForms
    {
        public static void Limpiar(GroupBox groupBox)
          {
              foreach (Control control in groupBox.Controls)
              {
                  if (control.GetType() == typeof(TextBox)) control.ResetText();
              }
          }
  
          public static void AgregarSeleccionar(DataGridView grid)
          {
              DataGridViewButtonColumn colSeleccionar = new DataGridViewButtonColumn();
              colSeleccionar.HeaderText = "Seleccionar";
              grid.Columns.Add(colSeleccionar);
          }
  
          public static DialogResult MostrarAlerta(String mensaje)
          {
              string caption = "Atencion!";
              MessageBoxButtons buttons = MessageBoxButtons.YesNo;
              DialogResult result;
  
              result = MessageBox.Show(mensaje, caption, buttons);
              return result;
              //if (result == System.Windows.Forms.DialogResult.Yes){ handle response }
          }
 
         public static void QueryAGrid(String query, DataGridView grid)
         {
             SqlConnection db = ManejadorConexiones.conectar();
 
             SqlCommand cmd = new SqlCommand(query, db);
             cmd.CommandType = CommandType.Text;
 
             SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
 
             DataTable dtRecord = new DataTable();
             sqlDataAdap.Fill(dtRecord);
             grid.DataSource = dtRecord;
         }


         public static bool CheckCampos(string [] arrayElementos)
         {  
             int count=0;
             for (var i = 0; i < arrayElementos.Length; i++ )
             {
                 if(arrayElementos[i].Length!=0){
                     count++;
                 }
             }


             if (arrayElementos.Length == count )
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }


    }
}
