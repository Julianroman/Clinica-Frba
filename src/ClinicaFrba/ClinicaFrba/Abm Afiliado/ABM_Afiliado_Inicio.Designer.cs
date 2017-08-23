namespace ClinicaFrba.Abm_Afiliado
{
    partial class ABM_Afiliado_Inicio
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
            this.buttonAltaAfiliado = new System.Windows.Forms.Button();
            this.buttonBajaAfiliado = new System.Windows.Forms.Button();
            this.buttonModificarAfiliado = new System.Windows.Forms.Button();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAltaAfiliado
            // 
            this.buttonAltaAfiliado.Location = new System.Drawing.Point(516, 29);
            this.buttonAltaAfiliado.Name = "buttonAltaAfiliado";
            this.buttonAltaAfiliado.Size = new System.Drawing.Size(122, 30);
            this.buttonAltaAfiliado.TabIndex = 0;
            this.buttonAltaAfiliado.Text = "Alta de Afiliado";
            this.buttonAltaAfiliado.UseVisualStyleBackColor = true;
            this.buttonAltaAfiliado.Click += new System.EventHandler(this.botonAltaAfiliado_Click);
            // 
            // buttonBajaAfiliado
            // 
            this.buttonBajaAfiliado.Location = new System.Drawing.Point(516, 65);
            this.buttonBajaAfiliado.Name = "buttonBajaAfiliado";
            this.buttonBajaAfiliado.Size = new System.Drawing.Size(122, 30);
            this.buttonBajaAfiliado.TabIndex = 1;
            this.buttonBajaAfiliado.Text = "Baja de Afiliado";
            this.buttonBajaAfiliado.UseVisualStyleBackColor = true;
            this.buttonBajaAfiliado.Click += new System.EventHandler(this.botonBajaAfiliado_Click);
            // 
            // buttonModificarAfiliado
            // 
            this.buttonModificarAfiliado.Location = new System.Drawing.Point(516, 101);
            this.buttonModificarAfiliado.Name = "buttonModificarAfiliado";
            this.buttonModificarAfiliado.Size = new System.Drawing.Size(122, 30);
            this.buttonModificarAfiliado.TabIndex = 2;
            this.buttonModificarAfiliado.Text = "Modificar Afiliado";
            this.buttonModificarAfiliado.UseVisualStyleBackColor = true;
            this.buttonModificarAfiliado.Click += new System.EventHandler(this.buttonModificarAfiliado_Click);
            // 
            // grilla
            // 
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Location = new System.Drawing.Point(60, 184);
            this.grilla.Name = "grilla";
            this.grilla.Size = new System.Drawing.Size(578, 239);
            this.grilla.TabIndex = 7;
            this.grilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellClick);
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick);
            this.grilla.SelectionChanged += new System.EventHandler(this.grilla_SelectionChanged);
            this.grilla.Click += new System.EventHandler(this.grilla_Click);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.checkBox1);
            this.groupBoxFiltros.Controls.Add(this.txtDni);
            this.groupBoxFiltros.Controls.Add(this.label3);
            this.groupBoxFiltros.Location = new System.Drawing.Point(60, 10);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(387, 103);
            this.groupBoxFiltros.TabIndex = 4;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de búsqueda";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(189, 36);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 2;
            this.txtDni.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero de Documento";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(189, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Ver solo habilitados";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ABM_Afiliado_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 433);
            this.Controls.Add(this.grilla);
            this.Controls.Add(this.buttonModificarAfiliado);
            this.Controls.Add(this.buttonBajaAfiliado);
            this.Controls.Add(this.buttonAltaAfiliado);
            this.Controls.Add(this.groupBoxFiltros);
            this.Name = "ABM_Afiliado_Inicio";
            this.Text = "Afiliados";
            this.Activated += new System.EventHandler(this.ABM_Afiliado_Inicio_Activated);
            this.Load += new System.EventHandler(this.ABM_Afiliado_Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAltaAfiliado;
        private System.Windows.Forms.Button buttonBajaAfiliado;
        private System.Windows.Forms.Button buttonModificarAfiliado;
        private System.Windows.Forms.DataGridView grilla;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}