namespace ClinicaFrba.Registro_Resultado
{
    partial class RegistrarResultado
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
            this.Documento = new System.Windows.Forms.TextBox();
            this.Fecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Hora = new System.Windows.Forms.TextBox();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Diagnostico = new System.Windows.Forms.RichTextBox();
            this.Comentarios = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Diagnosticar = new System.Windows.Forms.Button();
            this.Sintomas = new System.Windows.Forms.RichTextBox();
            this.ll = new System.Windows.Forms.Label();
            this.Asistencia = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Documento
            // 
            this.Documento.Location = new System.Drawing.Point(158, 57);
            this.Documento.Name = "Documento";
            this.Documento.Size = new System.Drawing.Size(100, 20);
            this.Documento.TabIndex = 0;
            this.Documento.TextChanged += new System.EventHandler(this.Documento_TextChanged_1);
            // 
            // Fecha
            // 
            this.Fecha.Location = new System.Drawing.Point(158, 101);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(100, 20);
            this.Fecha.TabIndex = 2;
            this.Fecha.TextChanged += new System.EventHandler(this.Fecha_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Documento paciente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha cita";
            // 
            // Hora
            // 
            this.Hora.Location = new System.Drawing.Point(158, 137);
            this.Hora.Name = "Hora";
            this.Hora.Size = new System.Drawing.Size(100, 20);
            this.Hora.TabIndex = 7;
            this.Hora.TextChanged += new System.EventHandler(this.Hora_TextChanged);
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(115, 287);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 8;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Diagnostico
            // 
            this.Diagnostico.Location = new System.Drawing.Point(374, 57);
            this.Diagnostico.Name = "Diagnostico";
            this.Diagnostico.Size = new System.Drawing.Size(297, 64);
            this.Diagnostico.TabIndex = 9;
            this.Diagnostico.Text = "";
            this.Diagnostico.TextChanged += new System.EventHandler(this.Diagnostico_TextChanged);
            // 
            // Comentarios
            // 
            this.Comentarios.AutoSize = true;
            this.Comentarios.Location = new System.Drawing.Point(371, 30);
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.Size = new System.Drawing.Size(63, 13);
            this.Comentarios.TabIndex = 10;
            this.Comentarios.Text = "Diagnostico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora cita";
            // 
            // Diagnosticar
            // 
            this.Diagnosticar.Location = new System.Drawing.Point(596, 287);
            this.Diagnosticar.Name = "Diagnosticar";
            this.Diagnosticar.Size = new System.Drawing.Size(75, 23);
            this.Diagnosticar.TabIndex = 11;
            this.Diagnosticar.Text = "Enviar";
            this.Diagnosticar.UseVisualStyleBackColor = true;
            this.Diagnosticar.Click += new System.EventHandler(this.Diagnosticar_Click);
            // 
            // Sintomas
            // 
            this.Sintomas.Location = new System.Drawing.Point(374, 152);
            this.Sintomas.Name = "Sintomas";
            this.Sintomas.Size = new System.Drawing.Size(297, 64);
            this.Sintomas.TabIndex = 12;
            this.Sintomas.Text = "";
            this.Sintomas.TextChanged += new System.EventHandler(this.Sintomas_TextChanged);
            // 
            // ll
            // 
            this.ll.AutoSize = true;
            this.ll.Location = new System.Drawing.Point(371, 136);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(50, 13);
            this.ll.TabIndex = 13;
            this.ll.Text = "Sintomas";
            // 
            // Asistencia
            // 
            this.Asistencia.AutoSize = true;
            this.Asistencia.Location = new System.Drawing.Point(49, 176);
            this.Asistencia.Name = "Asistencia";
            this.Asistencia.Size = new System.Drawing.Size(74, 17);
            this.Asistencia.TabIndex = 14;
            this.Asistencia.Text = "Asistencia";
            this.Asistencia.UseVisualStyleBackColor = true;
            this.Asistencia.CheckedChanged += new System.EventHandler(this.Asistencia_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(46, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Debe ingresar los datos del paciente, luego ACEPTAR ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(46, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "para poder completar el diagnostico";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(167, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "AAAA-MM-DD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(177, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "HH:MM";
            // 
            // RegistrarResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 414);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Asistencia);
            this.Controls.Add(this.ll);
            this.Controls.Add(this.Sintomas);
            this.Controls.Add(this.Diagnosticar);
            this.Controls.Add(this.Comentarios);
            this.Controls.Add(this.Diagnostico);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Hora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.Documento);
            this.Name = "RegistrarResultado";
            this.Text = "Registro de Diagnostico Paciente";
            this.Load += new System.EventHandler(this.RegistrarResultado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Documento;
        private System.Windows.Forms.TextBox Fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Hora;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.RichTextBox Diagnostico;
        private System.Windows.Forms.Label Comentarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Diagnosticar;
        private System.Windows.Forms.RichTextBox Sintomas;
        private System.Windows.Forms.Label ll;
        private System.Windows.Forms.CheckBox Asistencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}