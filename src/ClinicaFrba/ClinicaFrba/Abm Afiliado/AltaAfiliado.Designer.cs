namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaAfiliado
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
            this.Box_fechaNac = new System.Windows.Forms.DateTimePicker();
            this.Box_documento = new System.Windows.Forms.TextBox();
            this.Box_mail = new System.Windows.Forms.TextBox();
            this.Box_telefono = new System.Windows.Forms.TextBox();
            this.Box_apellido = new System.Windows.Forms.TextBox();
            this.Box_nombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Box_direccion = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Box_cantidadFamiliares = new System.Windows.Forms.TextBox();
            this.labelCantFamiliares = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Box_fechaNac
            // 
            this.Box_fechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Box_fechaNac.Location = new System.Drawing.Point(343, 359);
            this.Box_fechaNac.Margin = new System.Windows.Forms.Padding(2);
            this.Box_fechaNac.MaxDate = new System.DateTime(2016, 12, 25, 23, 59, 59, 0);
            this.Box_fechaNac.Name = "Box_fechaNac";
            this.Box_fechaNac.Size = new System.Drawing.Size(92, 20);
            this.Box_fechaNac.TabIndex = 37;
            this.Box_fechaNac.Value = new System.DateTime(2016, 10, 22, 0, 0, 0, 0);
            // 
            // Box_documento
            // 
            this.Box_documento.Location = new System.Drawing.Point(343, 214);
            this.Box_documento.Margin = new System.Windows.Forms.Padding(2);
            this.Box_documento.Name = "Box_documento";
            this.Box_documento.Size = new System.Drawing.Size(92, 20);
            this.Box_documento.TabIndex = 35;
            this.Box_documento.TextChanged += new System.EventHandler(this.Box_documento_TextChanged);
            this.Box_documento.Leave += new System.EventHandler(this.Box_documento_Leave);
            this.Box_documento.MouseLeave += new System.EventHandler(this.Box_documento_MouseLeave);
            // 
            // Box_mail
            // 
            this.Box_mail.Location = new System.Drawing.Point(343, 141);
            this.Box_mail.Margin = new System.Windows.Forms.Padding(2);
            this.Box_mail.Name = "Box_mail";
            this.Box_mail.Size = new System.Drawing.Size(92, 20);
            this.Box_mail.TabIndex = 33;
            // 
            // Box_telefono
            // 
            this.Box_telefono.Location = new System.Drawing.Point(343, 104);
            this.Box_telefono.Margin = new System.Windows.Forms.Padding(2);
            this.Box_telefono.Name = "Box_telefono";
            this.Box_telefono.Size = new System.Drawing.Size(92, 20);
            this.Box_telefono.TabIndex = 32;
            this.Box_telefono.Leave += new System.EventHandler(this.Box_telefono_Leave);
            // 
            // Box_apellido
            // 
            this.Box_apellido.Location = new System.Drawing.Point(343, 71);
            this.Box_apellido.Margin = new System.Windows.Forms.Padding(2);
            this.Box_apellido.Name = "Box_apellido";
            this.Box_apellido.Size = new System.Drawing.Size(92, 20);
            this.Box_apellido.TabIndex = 31;
            // 
            // Box_nombre
            // 
            this.Box_nombre.Location = new System.Drawing.Point(343, 35);
            this.Box_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.Box_nombre.Name = "Box_nombre";
            this.Box_nombre.Size = new System.Drawing.Size(92, 20);
            this.Box_nombre.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 363);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Fecha nacimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 259);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Sexo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 219);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Documento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 184);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Tipo Documento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nombre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(343, 176);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 38;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(343, 250);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(92, 21);
            this.comboBox2.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Dar de Alta Afiliado y Agregar Familiares";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 286);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Direccion";
            // 
            // Box_direccion
            // 
            this.Box_direccion.Location = new System.Drawing.Point(343, 279);
            this.Box_direccion.Margin = new System.Windows.Forms.Padding(2);
            this.Box_direccion.Name = "Box_direccion";
            this.Box_direccion.Size = new System.Drawing.Size(92, 20);
            this.Box_direccion.TabIndex = 42;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(343, 304);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(92, 21);
            this.comboBox3.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 313);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Estado Civil";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(343, 331);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(92, 21);
            this.comboBox4.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 340);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Plan Medico";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(55, 286);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "Habilitar";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(343, 11);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(92, 20);
            this.textBoxUsername.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Username";
            // 
            // Box_cantidadFamiliares
            // 
            this.Box_cantidadFamiliares.Location = new System.Drawing.Point(343, 383);
            this.Box_cantidadFamiliares.Margin = new System.Windows.Forms.Padding(2);
            this.Box_cantidadFamiliares.Name = "Box_cantidadFamiliares";
            this.Box_cantidadFamiliares.Size = new System.Drawing.Size(92, 20);
            this.Box_cantidadFamiliares.TabIndex = 51;
            this.Box_cantidadFamiliares.Leave += new System.EventHandler(this.Box_cantidadFamiliares_Leave);
            // 
            // labelCantFamiliares
            // 
            this.labelCantFamiliares.AutoSize = true;
            this.labelCantFamiliares.Location = new System.Drawing.Point(186, 390);
            this.labelCantFamiliares.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCantFamiliares.Name = "labelCantFamiliares";
            this.labelCantFamiliares.Size = new System.Drawing.Size(113, 13);
            this.labelCantFamiliares.TabIndex = 50;
            this.labelCantFamiliares.Text = "Cantidad de Familiares";
            // 
            // AltaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 547);
            this.Controls.Add(this.Box_cantidadFamiliares);
            this.Controls.Add(this.labelCantFamiliares);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Box_direccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Box_fechaNac);
            this.Controls.Add(this.Box_documento);
            this.Controls.Add(this.Box_mail);
            this.Controls.Add(this.Box_telefono);
            this.Controls.Add(this.Box_apellido);
            this.Controls.Add(this.Box_nombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "AltaAfiliado";
            this.Text = "Alta de Afiliado";
            this.Load += new System.EventHandler(this.AltaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Box_fechaNac;
        private System.Windows.Forms.TextBox Box_documento;
        private System.Windows.Forms.TextBox Box_mail;
        private System.Windows.Forms.TextBox Box_telefono;
        private System.Windows.Forms.TextBox Box_apellido;
        private System.Windows.Forms.TextBox Box_nombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Box_direccion;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Box_cantidadFamiliares;
        private System.Windows.Forms.Label labelCantFamiliares;
    }
}