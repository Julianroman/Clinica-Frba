namespace ClinicaFrba.Abm_Afiliado
{
    partial class ModificarAfiliado
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
            this.comboBoxPlanMedico = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Box_direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.Box_mail = new System.Windows.Forms.TextBox();
            this.Box_telefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMotivoModificacion = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // comboBoxPlanMedico
            // 
            this.comboBoxPlanMedico.FormattingEnabled = true;
            this.comboBoxPlanMedico.Location = new System.Drawing.Point(365, 207);
            this.comboBoxPlanMedico.Name = "comboBoxPlanMedico";
            this.comboBoxPlanMedico.Size = new System.Drawing.Size(92, 21);
            this.comboBoxPlanMedico.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Plan Medico";
            // 
            // comboBoxEstadoCivil
            // 
            this.comboBoxEstadoCivil.FormattingEnabled = true;
            this.comboBoxEstadoCivil.Location = new System.Drawing.Point(365, 180);
            this.comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            this.comboBoxEstadoCivil.Size = new System.Drawing.Size(92, 21);
            this.comboBoxEstadoCivil.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Estado Civil";
            // 
            // Box_direccion
            // 
            this.Box_direccion.Location = new System.Drawing.Point(365, 155);
            this.Box_direccion.Margin = new System.Windows.Forms.Padding(2);
            this.Box_direccion.Name = "Box_direccion";
            this.Box_direccion.Size = new System.Drawing.Size(92, 20);
            this.Box_direccion.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Direccion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "Modificar Afiliado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Location = new System.Drawing.Point(365, 126);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(92, 21);
            this.comboBoxSexo.TabIndex = 65;
            // 
            // Box_mail
            // 
            this.Box_mail.Location = new System.Drawing.Point(365, 97);
            this.Box_mail.Margin = new System.Windows.Forms.Padding(2);
            this.Box_mail.Name = "Box_mail";
            this.Box_mail.Size = new System.Drawing.Size(92, 20);
            this.Box_mail.TabIndex = 61;
            // 
            // Box_telefono
            // 
            this.Box_telefono.Location = new System.Drawing.Point(365, 67);
            this.Box_telefono.Margin = new System.Windows.Forms.Padding(2);
            this.Box_telefono.Name = "Box_telefono";
            this.Box_telefono.Size = new System.Drawing.Size(92, 20);
            this.Box_telefono.TabIndex = 60;
            this.Box_telefono.Leave += new System.EventHandler(this.Box_telefono_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 135);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Sexo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Teléfono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 244);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Motivo Modificacion (Solo necesario si se modifica el plan del afiliado))";
            // 
            // txtMotivoModificacion
            // 
            this.txtMotivoModificacion.Location = new System.Drawing.Point(199, 260);
            this.txtMotivoModificacion.Name = "txtMotivoModificacion";
            this.txtMotivoModificacion.Size = new System.Drawing.Size(331, 96);
            this.txtMotivoModificacion.TabIndex = 75;
            this.txtMotivoModificacion.Text = "";
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 449);
            this.Controls.Add(this.txtMotivoModificacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxPlanMedico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxEstadoCivil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Box_direccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxSexo);
            this.Controls.Add(this.Box_mail);
            this.Controls.Add(this.Box_telefono);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "ModificarAfiliado";
            this.Text = "Modificar Afiliado";
            this.Load += new System.EventHandler(this.ModificarAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPlanMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEstadoCivil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Box_direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.TextBox Box_mail;
        private System.Windows.Forms.TextBox Box_telefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtMotivoModificacion;
    }
}