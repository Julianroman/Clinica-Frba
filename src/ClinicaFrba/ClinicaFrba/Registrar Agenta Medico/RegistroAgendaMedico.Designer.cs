namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class RegistrarAgenda
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
            this.label3 = new System.Windows.Forms.Label();
            this.FechaInit = new System.Windows.Forms.TextBox();
            this.FechaFin = new System.Windows.Forms.TextBox();
            this.Aceptar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gD2C2016DataSet = new ClinicaFrba.GD2C2016DataSet();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.gD2C2016DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Lunes = new System.Windows.Forms.CheckBox();
            this.Martes = new System.Windows.Forms.CheckBox();
            this.Miercoles = new System.Windows.Forms.CheckBox();
            this.Jueves = new System.Windows.Forms.CheckBox();
            this.Viernes = new System.Windows.Forms.CheckBox();
            this.Sabado = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.especialidadTableAdapter = new ClinicaFrba.GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();
            this.tableAdapterManager = new ClinicaFrba.GD2C2016DataSetTableAdapters.TableAdapterManager();
            this.horaInit = new System.Windows.Forms.ComboBox();
            this.horaFin = new System.Windows.Forms.ComboBox();
            this.horaInitS = new System.Windows.Forms.ComboBox();
            this.horaFinS = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Especialidad";
            // 
            // FechaInit
            // 
            this.FechaInit.Location = new System.Drawing.Point(361, 31);
            this.FechaInit.Name = "FechaInit";
            this.FechaInit.Size = new System.Drawing.Size(117, 20);
            this.FechaInit.TabIndex = 9;
            this.FechaInit.TextChanged += new System.EventHandler(this.FechaInit_TextChanged);
            // 
            // FechaFin
            // 
            this.FechaFin.Location = new System.Drawing.Point(534, 31);
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Size = new System.Drawing.Size(117, 20);
            this.FechaFin.TabIndex = 10;
            this.FechaFin.TextChanged += new System.EventHandler(this.FechaFin_TextChanged);
            // 
            // Aceptar
            // 
            this.Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aceptar.Location = new System.Drawing.Point(291, 288);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(127, 47);
            this.Aceptar.TabIndex = 20;
            this.Aceptar.Text = "Agregar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha incial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(565, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fecha final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(358, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gD2C2016DataSet, "Especialidad.Descripcion", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // gD2C2016DataSet
            // 
            this.gD2C2016DataSet.DataSetName = "GD2C2016DataSet";
            this.gD2C2016DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(744, 25);
            this.fillByToolStrip.TabIndex = 18;
            this.fillByToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fillByToolStrip_ItemClicked);
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(23, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Hora inicial";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Hora final";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(358, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(341, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Ejemplo: 2016-06-20 (completar todos los meses  y diascon dos digitos)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(636, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ejemplo: 11:30";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Lunes
            // 
            this.Lunes.AutoSize = true;
            this.Lunes.Location = new System.Drawing.Point(36, 131);
            this.Lunes.Name = "Lunes";
            this.Lunes.Size = new System.Drawing.Size(55, 17);
            this.Lunes.TabIndex = 25;
            this.Lunes.Text = "Lunes";
            this.Lunes.UseVisualStyleBackColor = true;
            this.Lunes.CheckedChanged += new System.EventHandler(this.Lunes_CheckedChanged);
            // 
            // Martes
            // 
            this.Martes.AutoSize = true;
            this.Martes.Location = new System.Drawing.Point(97, 131);
            this.Martes.Name = "Martes";
            this.Martes.Size = new System.Drawing.Size(58, 17);
            this.Martes.TabIndex = 26;
            this.Martes.Text = "Martes";
            this.Martes.UseVisualStyleBackColor = true;
            this.Martes.CheckedChanged += new System.EventHandler(this.Martes_CheckedChanged);
            // 
            // Miercoles
            // 
            this.Miercoles.AutoSize = true;
            this.Miercoles.Location = new System.Drawing.Point(161, 131);
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.Size = new System.Drawing.Size(71, 17);
            this.Miercoles.TabIndex = 27;
            this.Miercoles.Text = "Miércoles";
            this.Miercoles.UseVisualStyleBackColor = true;
            this.Miercoles.CheckedChanged += new System.EventHandler(this.Miercoles_CheckedChanged);
            // 
            // Jueves
            // 
            this.Jueves.AutoSize = true;
            this.Jueves.Location = new System.Drawing.Point(242, 131);
            this.Jueves.Name = "Jueves";
            this.Jueves.Size = new System.Drawing.Size(60, 17);
            this.Jueves.TabIndex = 28;
            this.Jueves.Text = "Jueves";
            this.Jueves.UseVisualStyleBackColor = true;
            this.Jueves.CheckedChanged += new System.EventHandler(this.Jueves_CheckedChanged);
            // 
            // Viernes
            // 
            this.Viernes.AutoSize = true;
            this.Viernes.Location = new System.Drawing.Point(308, 131);
            this.Viernes.Name = "Viernes";
            this.Viernes.Size = new System.Drawing.Size(61, 17);
            this.Viernes.TabIndex = 29;
            this.Viernes.Text = "Viernes";
            this.Viernes.UseVisualStyleBackColor = true;
            this.Viernes.CheckedChanged += new System.EventHandler(this.Viernes_CheckedChanged);
            // 
            // Sabado
            // 
            this.Sabado.AutoSize = true;
            this.Sabado.Location = new System.Drawing.Point(308, 167);
            this.Sabado.Name = "Sabado";
            this.Sabado.Size = new System.Drawing.Size(63, 17);
            this.Sabado.TabIndex = 30;
            this.Sabado.Text = "Sábado";
            this.Sabado.UseVisualStyleBackColor = true;
            this.Sabado.CheckedChanged += new System.EventHandler(this.Sabado_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Seleccione los dias laborales para agendar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(33, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(251, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "La clinica atiende de 7:00 hasta las 20.00 de Lunes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(33, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(228, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "a Viernes y de 10:00 a 15:00 los días Sabados";
            // 
            // especialidadTableAdapter
            // 
            this.especialidadTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AfiliadoTableAdapter = null;
            this.tableAdapterManager.AgendaTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BonoTableAdapter = null;
            this.tableAdapterManager.CancelacionTableAdapter = null;
            this.tableAdapterManager.CompraTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.ConsultaMedicaTableAdapter = null;
            this.tableAdapterManager.Dias_disponibleTableAdapter = null;
            this.tableAdapterManager.EspecialidadTableAdapter = null;
            this.tableAdapterManager.EstadoCivilTableAdapter = null;
            this.tableAdapterManager.FuncionalidadTableAdapter = null;
            this.tableAdapterManager.MaestraTableAdapter = null;
            this.tableAdapterManager.Modificaciones_afiliadoTableAdapter = null;
            this.tableAdapterManager.PlanMedicoTableAdapter = null;
            this.tableAdapterManager.ProfesionalTableAdapter = null;
            this.tableAdapterManager.ProfesionalXEspecialidadTableAdapter = null;
            this.tableAdapterManager.RolTableAdapter = null;
            this.tableAdapterManager.RolXFuncionalidadTableAdapter = null;
            this.tableAdapterManager.TipoCancelacionTableAdapter = null;
            this.tableAdapterManager.TipoDocumentoTableAdapter = null;
            this.tableAdapterManager.TipoEspecialidadTableAdapter = null;
            this.tableAdapterManager.TurnoTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ClinicaFrba.GD2C2016DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsuarioTableAdapter = null;
            this.tableAdapterManager.UsuarioXRolTableAdapter = null;
            // 
            // horaInit
            // 
            this.horaInit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gD2C2016DataSet, "Especialidad.Descripcion", true));
            this.horaInit.FormattingEnabled = true;
            this.horaInit.Items.AddRange(new object[] {
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30"});
            this.horaInit.Location = new System.Drawing.Point(392, 127);
            this.horaInit.Name = "horaInit";
            this.horaInit.Size = new System.Drawing.Size(56, 21);
            this.horaInit.TabIndex = 36;
            this.horaInit.SelectedIndexChanged += new System.EventHandler(this.horaInit_SelectedIndexChanged);
            // 
            // horaFin
            // 
            this.horaFin.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gD2C2016DataSet, "Especialidad.Descripcion", true));
            this.horaFin.FormattingEnabled = true;
            this.horaFin.Items.AddRange(new object[] {
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00"});
            this.horaFin.Location = new System.Drawing.Point(548, 127);
            this.horaFin.Name = "horaFin";
            this.horaFin.Size = new System.Drawing.Size(56, 21);
            this.horaFin.TabIndex = 37;
            this.horaFin.SelectedIndexChanged += new System.EventHandler(this.horaFin_SelectedIndexChanged);
            // 
            // horaInitS
            // 
            this.horaInitS.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gD2C2016DataSet, "Especialidad.Descripcion", true));
            this.horaInitS.FormattingEnabled = true;
            this.horaInitS.Items.AddRange(new object[] {
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "14:30"});
            this.horaInitS.Location = new System.Drawing.Point(392, 165);
            this.horaInitS.Name = "horaInitS";
            this.horaInitS.Size = new System.Drawing.Size(56, 21);
            this.horaInitS.TabIndex = 38;
            this.horaInitS.SelectedIndexChanged += new System.EventHandler(this.horaInitS_SelectedIndexChanged);
            // 
            // horaFinS
            // 
            this.horaFinS.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.gD2C2016DataSet, "Especialidad.Descripcion", true));
            this.horaFinS.FormattingEnabled = true;
            this.horaFinS.Items.AddRange(new object[] {
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "14:30",
            "15:00"});
            this.horaFinS.Location = new System.Drawing.Point(548, 165);
            this.horaFinS.Name = "horaFinS";
            this.horaFinS.Size = new System.Drawing.Size(56, 21);
            this.horaFinS.TabIndex = 39;
            this.horaFinS.SelectedIndexChanged += new System.EventHandler(this.horaFinS_SelectedIndexChanged);
            // 
            // RegistrarAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(744, 361);
            this.Controls.Add(this.horaFinS);
            this.Controls.Add(this.horaInitS);
            this.Controls.Add(this.horaFin);
            this.Controls.Add(this.horaInit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Sabado);
            this.Controls.Add(this.Viernes);
            this.Controls.Add(this.Jueves);
            this.Controls.Add(this.Miercoles);
            this.Controls.Add(this.Martes);
            this.Controls.Add(this.Lunes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.FechaFin);
            this.Controls.Add(this.FechaInit);
            this.Controls.Add(this.label3);
            this.Name = "RegistrarAgenda";
            this.Text = "Registrar Agenda";
            this.Load += new System.EventHandler(this.RegistrarAgenda_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FechaInit;
        private System.Windows.Forms.TextBox FechaFin;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private GD2C2016DataSet gD2C2016DataSet;
        private System.Windows.Forms.BindingSource gD2C2016DataSetBindingSource;
        private GD2C2016DataSetTableAdapters.EspecialidadTableAdapter especialidadTableAdapter;
        private GD2C2016DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Lunes;
        private System.Windows.Forms.CheckBox Martes;
        private System.Windows.Forms.CheckBox Miercoles;
        private System.Windows.Forms.CheckBox Jueves;
        private System.Windows.Forms.CheckBox Viernes;
        private System.Windows.Forms.CheckBox Sabado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox horaInit;
        private System.Windows.Forms.ComboBox horaFin;
        private System.Windows.Forms.ComboBox horaInitS;
        private System.Windows.Forms.ComboBox horaFinS;
    }
}