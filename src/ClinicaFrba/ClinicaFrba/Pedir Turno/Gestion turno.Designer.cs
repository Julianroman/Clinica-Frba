namespace ClinicaFrba.Pedir_Turno
{
    partial class Gestion_turno
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_especialidad = new System.Windows.Forms.ComboBox();
            this.comboBox__profesional = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Fechas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Horarios = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profesional";
            // 
            // comboBox_especialidad
            // 
            this.comboBox_especialidad.FormattingEnabled = true;
            this.comboBox_especialidad.Location = new System.Drawing.Point(159, 41);
            this.comboBox_especialidad.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_especialidad.Name = "comboBox_especialidad";
            this.comboBox_especialidad.Size = new System.Drawing.Size(270, 21);
            this.comboBox_especialidad.TabIndex = 2;
            this.comboBox_especialidad.SelectedIndexChanged += new System.EventHandler(this.comboBox_especialidad_SelectedIndexChanged);
            // 
            // comboBox__profesional
            // 
            this.comboBox__profesional.FormattingEnabled = true;
            this.comboBox__profesional.Location = new System.Drawing.Point(159, 80);
            this.comboBox__profesional.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox__profesional.Name = "comboBox__profesional";
            this.comboBox__profesional.Size = new System.Drawing.Size(270, 21);
            this.comboBox__profesional.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 337);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Confirmar turno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // comboBox_Fechas
            // 
            this.comboBox_Fechas.FormattingEnabled = true;
            this.comboBox_Fechas.Location = new System.Drawing.Point(159, 139);
            this.comboBox_Fechas.Name = "comboBox_Fechas";
            this.comboBox_Fechas.Size = new System.Drawing.Size(270, 21);
            this.comboBox_Fechas.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Horario";
            // 
            // comboBox_Horarios
            // 
            this.comboBox_Horarios.FormattingEnabled = true;
            this.comboBox_Horarios.Location = new System.Drawing.Point(159, 197);
            this.comboBox_Horarios.Name = "comboBox_Horarios";
            this.comboBox_Horarios.Size = new System.Drawing.Size(270, 21);
            this.comboBox_Horarios.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(29, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(400, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Si no le aparece ninguna opcion para la fecha y horario  no hay turnos disponible" +
    "s para esta especialidad y profesional";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "La carga de todas las fechas y horarios puede demorarse";
            // 
            // Gestion_turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 385);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_Horarios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Fechas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox__profesional);
            this.Controls.Add(this.comboBox_especialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gestion_turno";
            this.Text = "Pedir turno";
            this.Load += new System.EventHandler(this.Gestion_turno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_especialidad;
        private System.Windows.Forms.ComboBox comboBox__profesional;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Fechas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Horarios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}