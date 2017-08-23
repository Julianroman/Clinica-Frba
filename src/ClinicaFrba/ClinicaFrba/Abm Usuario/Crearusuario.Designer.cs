namespace ClinicaFrba.Abm_Usuario
{
    partial class Crearusuario
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
            this.Box_user = new System.Windows.Forms.TextBox();
            this.Box_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Box_rol = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clean = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // Box_user
            // 
            this.Box_user.Location = new System.Drawing.Point(210, 41);
            this.Box_user.Margin = new System.Windows.Forms.Padding(2);
            this.Box_user.Name = "Box_user";
            this.Box_user.Size = new System.Drawing.Size(92, 20);
            this.Box_user.TabIndex = 2;
            // 
            // Box_password
            // 
            this.Box_password.Location = new System.Drawing.Point(210, 74);
            this.Box_password.Margin = new System.Windows.Forms.Padding(2);
            this.Box_password.Name = "Box_password";
            this.Box_password.Size = new System.Drawing.Size(92, 20);
            this.Box_password.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rol Asignado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Box_rol
            // 
            this.Box_rol.FormattingEnabled = true;
            this.Box_rol.Items.AddRange(new object[] {
            "Afiliado",
            "Profesional",
            "Administrador"});
            this.Box_rol.Location = new System.Drawing.Point(210, 111);
            this.Box_rol.Margin = new System.Windows.Forms.Padding(2);
            this.Box_rol.Name = "Box_rol";
            this.Box_rol.Size = new System.Drawing.Size(92, 21);
            this.Box_rol.TabIndex = 5;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(377, 583);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(56, 19);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_clean
            // 
            this.btn_clean.Location = new System.Drawing.Point(32, 583);
            this.btn_clean.Margin = new System.Windows.Forms.Padding(2);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(56, 19);
            this.btn_clean.TabIndex = 7;
            this.btn_clean.Text = "Limpiar";
            this.btn_clean.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Box_user);
            this.groupBox1.Controls.Add(this.Box_password);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Box_rol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(402, 552);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrate";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Crearusuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 622);
            this.Controls.Add(this.btn_clean);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Crearusuario";
            this.Text = "Alta de Usuario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Box_user;
        private System.Windows.Forms.TextBox Box_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Box_rol;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}