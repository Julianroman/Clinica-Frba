namespace ClinicaFrba.Cancelar_Turno
{
    partial class MedicoCancelarTurno
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
            this.Box_fechaACancelar = new System.Windows.Forms.DateTimePicker();
            this.labelFechaEspecifica = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextMotivo = new System.Windows.Forms.RichTextBox();
            this.buttonCancelarTurno = new System.Windows.Forms.Button();
            this.checkCancelarPorRango = new System.Windows.Forms.CheckBox();
            this.dateTimeFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFechaFin = new System.Windows.Forms.DateTimePicker();
            this.labelRango = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Box_fechaACancelar
            // 
            this.Box_fechaACancelar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Box_fechaACancelar.Location = new System.Drawing.Point(65, 78);
            this.Box_fechaACancelar.Margin = new System.Windows.Forms.Padding(2);
            this.Box_fechaACancelar.MaxDate = new System.DateTime(2110, 12, 31, 0, 0, 0, 0);
            this.Box_fechaACancelar.Name = "Box_fechaACancelar";
            this.Box_fechaACancelar.Size = new System.Drawing.Size(213, 20);
            this.Box_fechaACancelar.TabIndex = 38;
            this.Box_fechaACancelar.Value = new System.DateTime(2016, 11, 2, 0, 0, 0, 0);
            // 
            // labelFechaEspecifica
            // 
            this.labelFechaEspecifica.AutoSize = true;
            this.labelFechaEspecifica.Location = new System.Drawing.Point(62, 63);
            this.labelFechaEspecifica.Name = "labelFechaEspecifica";
            this.labelFechaEspecifica.Size = new System.Drawing.Size(118, 13);
            this.labelFechaEspecifica.TabIndex = 39;
            this.labelFechaEspecifica.Text = "Cancelar turnos del dia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Tipo de cancelacion";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(527, 165);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Motivo de la cancelacion";
            // 
            // richTextMotivo
            // 
            this.richTextMotivo.Location = new System.Drawing.Point(65, 147);
            this.richTextMotivo.Name = "richTextMotivo";
            this.richTextMotivo.Size = new System.Drawing.Size(424, 85);
            this.richTextMotivo.TabIndex = 41;
            this.richTextMotivo.Text = "";
            // 
            // buttonCancelarTurno
            // 
            this.buttonCancelarTurno.Location = new System.Drawing.Point(528, 209);
            this.buttonCancelarTurno.Name = "buttonCancelarTurno";
            this.buttonCancelarTurno.Size = new System.Drawing.Size(120, 23);
            this.buttonCancelarTurno.TabIndex = 40;
            this.buttonCancelarTurno.Text = "Cancelar Turno";
            this.buttonCancelarTurno.UseVisualStyleBackColor = true;
            this.buttonCancelarTurno.Click += new System.EventHandler(this.buttonCancelarTurno_Click);
            // 
            // checkCancelarPorRango
            // 
            this.checkCancelarPorRango.AutoSize = true;
            this.checkCancelarPorRango.Location = new System.Drawing.Point(65, 31);
            this.checkCancelarPorRango.Name = "checkCancelarPorRango";
            this.checkCancelarPorRango.Size = new System.Drawing.Size(166, 17);
            this.checkCancelarPorRango.TabIndex = 45;
            this.checkCancelarPorRango.Text = "Cancelar por rango de fechas";
            this.checkCancelarPorRango.UseVisualStyleBackColor = true;
            this.checkCancelarPorRango.CheckedChanged += new System.EventHandler(this.checkCancelarPorRango_CheckedChanged);
            // 
            // dateTimeFechaInicio
            // 
            this.dateTimeFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaInicio.Location = new System.Drawing.Point(65, 78);
            this.dateTimeFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeFechaInicio.MaxDate = new System.DateTime(2110, 12, 31, 0, 0, 0, 0);
            this.dateTimeFechaInicio.Name = "dateTimeFechaInicio";
            this.dateTimeFechaInicio.Size = new System.Drawing.Size(213, 20);
            this.dateTimeFechaInicio.TabIndex = 46;
            this.dateTimeFechaInicio.Value = new System.DateTime(2016, 11, 2, 0, 0, 0, 0);
            // 
            // dateTimeFechaFin
            // 
            this.dateTimeFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaFin.Location = new System.Drawing.Point(367, 78);
            this.dateTimeFechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeFechaFin.MaxDate = new System.DateTime(2110, 12, 31, 0, 0, 0, 0);
            this.dateTimeFechaFin.Name = "dateTimeFechaFin";
            this.dateTimeFechaFin.Size = new System.Drawing.Size(213, 20);
            this.dateTimeFechaFin.TabIndex = 47;
            this.dateTimeFechaFin.Value = new System.DateTime(2016, 11, 2, 0, 0, 0, 0);
            // 
            // labelRango
            // 
            this.labelRango.AutoSize = true;
            this.labelRango.Location = new System.Drawing.Point(62, 63);
            this.labelRango.Name = "labelRango";
            this.labelRango.Size = new System.Drawing.Size(100, 13);
            this.labelRango.TabIndex = 48;
            this.labelRango.Text = "Cancelar por rango:";
            // 
            // MedicoCancelarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 288);
            this.Controls.Add(this.labelRango);
            this.Controls.Add(this.dateTimeFechaFin);
            this.Controls.Add(this.dateTimeFechaInicio);
            this.Controls.Add(this.checkCancelarPorRango);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextMotivo);
            this.Controls.Add(this.buttonCancelarTurno);
            this.Controls.Add(this.labelFechaEspecifica);
            this.Controls.Add(this.Box_fechaACancelar);
            this.Name = "MedicoCancelarTurno";
            this.Text = "Cancelacion de Turnos";
            this.Load += new System.EventHandler(this.MedicoCancelarTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Box_fechaACancelar;
        private System.Windows.Forms.Label labelFechaEspecifica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextMotivo;
        private System.Windows.Forms.Button buttonCancelarTurno;
        private System.Windows.Forms.CheckBox checkCancelarPorRango;
        private System.Windows.Forms.DateTimePicker dateTimeFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimeFechaFin;
        private System.Windows.Forms.Label labelRango;
    }
}