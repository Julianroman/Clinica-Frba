namespace ClinicaFrba.Abm_Afiliado
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gD2C2016DataSet = new ClinicaFrba.GD2C2016DataSet();
            this.afiliadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.afiliadoTableAdapter = new ClinicaFrba.GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            this.idafiliadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalconsultasmedicasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familiaresacargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conyugeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idestadocivilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerodocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechanacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipodocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afiliadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idafiliadoDataGridViewTextBoxColumn,
            this.idusuarioDataGridViewTextBoxColumn,
            this.planidDataGridViewTextBoxColumn,
            this.totalconsultasmedicasDataGridViewTextBoxColumn,
            this.familiaresacargoDataGridViewTextBoxColumn,
            this.conyugeDataGridViewTextBoxColumn,
            this.idestadocivilDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.numerodocumentoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.fechanacimientoDataGridViewTextBoxColumn,
            this.idtipodocumentoDataGridViewTextBoxColumn,
            this.sexoDataGridViewTextBoxColumn,
            this.habilitadoDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.afiliadoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 219);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(723, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // gD2C2016DataSet
            // 
            this.gD2C2016DataSet.DataSetName = "GD2C2016DataSet";
            this.gD2C2016DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // afiliadoBindingSource
            // 
            this.afiliadoBindingSource.DataMember = "Afiliado";
            this.afiliadoBindingSource.DataSource = this.gD2C2016DataSet;
            // 
            // afiliadoTableAdapter
            // 
            this.afiliadoTableAdapter.ClearBeforeFill = true;
            // 
            // idafiliadoDataGridViewTextBoxColumn
            // 
            this.idafiliadoDataGridViewTextBoxColumn.DataPropertyName = "Id_afiliado";
            this.idafiliadoDataGridViewTextBoxColumn.HeaderText = "Id_afiliado";
            this.idafiliadoDataGridViewTextBoxColumn.Name = "idafiliadoDataGridViewTextBoxColumn";
            this.idafiliadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idusuarioDataGridViewTextBoxColumn
            // 
            this.idusuarioDataGridViewTextBoxColumn.DataPropertyName = "Id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.HeaderText = "Id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.Name = "idusuarioDataGridViewTextBoxColumn";
            // 
            // planidDataGridViewTextBoxColumn
            // 
            this.planidDataGridViewTextBoxColumn.DataPropertyName = "Plan_id";
            this.planidDataGridViewTextBoxColumn.HeaderText = "Plan_id";
            this.planidDataGridViewTextBoxColumn.Name = "planidDataGridViewTextBoxColumn";
            // 
            // totalconsultasmedicasDataGridViewTextBoxColumn
            // 
            this.totalconsultasmedicasDataGridViewTextBoxColumn.DataPropertyName = "Total_consultas_medicas";
            this.totalconsultasmedicasDataGridViewTextBoxColumn.HeaderText = "Total_consultas_medicas";
            this.totalconsultasmedicasDataGridViewTextBoxColumn.Name = "totalconsultasmedicasDataGridViewTextBoxColumn";
            // 
            // familiaresacargoDataGridViewTextBoxColumn
            // 
            this.familiaresacargoDataGridViewTextBoxColumn.DataPropertyName = "Familiares_a_cargo";
            this.familiaresacargoDataGridViewTextBoxColumn.HeaderText = "Familiares_a_cargo";
            this.familiaresacargoDataGridViewTextBoxColumn.Name = "familiaresacargoDataGridViewTextBoxColumn";
            // 
            // conyugeDataGridViewTextBoxColumn
            // 
            this.conyugeDataGridViewTextBoxColumn.DataPropertyName = "Conyuge";
            this.conyugeDataGridViewTextBoxColumn.HeaderText = "Conyuge";
            this.conyugeDataGridViewTextBoxColumn.Name = "conyugeDataGridViewTextBoxColumn";
            // 
            // idestadocivilDataGridViewTextBoxColumn
            // 
            this.idestadocivilDataGridViewTextBoxColumn.DataPropertyName = "Id_estado_civil";
            this.idestadocivilDataGridViewTextBoxColumn.HeaderText = "Id_estado_civil";
            this.idestadocivilDataGridViewTextBoxColumn.Name = "idestadocivilDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // numerodocumentoDataGridViewTextBoxColumn
            // 
            this.numerodocumentoDataGridViewTextBoxColumn.DataPropertyName = "Numero_documento";
            this.numerodocumentoDataGridViewTextBoxColumn.HeaderText = "Numero_documento";
            this.numerodocumentoDataGridViewTextBoxColumn.Name = "numerodocumentoDataGridViewTextBoxColumn";
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "Mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "Mail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            // 
            // fechanacimientoDataGridViewTextBoxColumn
            // 
            this.fechanacimientoDataGridViewTextBoxColumn.DataPropertyName = "Fecha_nacimiento";
            this.fechanacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha_nacimiento";
            this.fechanacimientoDataGridViewTextBoxColumn.Name = "fechanacimientoDataGridViewTextBoxColumn";
            // 
            // idtipodocumentoDataGridViewTextBoxColumn
            // 
            this.idtipodocumentoDataGridViewTextBoxColumn.DataPropertyName = "Id_tipo_documento";
            this.idtipodocumentoDataGridViewTextBoxColumn.HeaderText = "Id_tipo_documento";
            this.idtipodocumentoDataGridViewTextBoxColumn.Name = "idtipodocumentoDataGridViewTextBoxColumn";
            // 
            // sexoDataGridViewTextBoxColumn
            // 
            this.sexoDataGridViewTextBoxColumn.DataPropertyName = "Sexo";
            this.sexoDataGridViewTextBoxColumn.HeaderText = "Sexo";
            this.sexoDataGridViewTextBoxColumn.Name = "sexoDataGridViewTextBoxColumn";
            // 
            // habilitadoDataGridViewCheckBoxColumn
            // 
            this.habilitadoDataGridViewCheckBoxColumn.DataPropertyName = "Habilitado";
            this.habilitadoDataGridViewCheckBoxColumn.HeaderText = "Habilitado";
            this.habilitadoDataGridViewCheckBoxColumn.Name = "habilitadoDataGridViewCheckBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alta Afiliado";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(519, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificar Afiliado";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Baja Afiliado";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 425);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afiliadoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GD2C2016DataSet gD2C2016DataSet;
        private System.Windows.Forms.BindingSource afiliadoBindingSource;
        private GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiliadoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idafiliadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalconsultasmedicasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familiaresacargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conyugeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestadocivilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerodocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechanacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipodocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}