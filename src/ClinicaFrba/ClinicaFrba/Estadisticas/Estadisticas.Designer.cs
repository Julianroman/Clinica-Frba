namespace ClinicaFrba.Estadisticas
{
    partial class Estadisticas
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
            this.ListadoEstadisticas = new System.Windows.Forms.ComboBox();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione estadistica";
            // 
            // ListadoEstadisticas
            // 
            this.ListadoEstadisticas.FormattingEnabled = true;
            this.ListadoEstadisticas.Items.AddRange(new object[] {
            "Especialidades más canceladas",
            "Profesionales más consultados",
            "Profesionales con menos trabajo",
            "Afilidado con mayor compra de bonos",
            "Especialidades más consultadas"});
            this.ListadoEstadisticas.Location = new System.Drawing.Point(58, 107);
            this.ListadoEstadisticas.Name = "ListadoEstadisticas";
            this.ListadoEstadisticas.Size = new System.Drawing.Size(210, 21);
            this.ListadoEstadisticas.TabIndex = 1;
            this.ListadoEstadisticas.SelectedIndexChanged += new System.EventHandler(this.ListadoEstadisticas_SelectedIndexChanged);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Location = new System.Drawing.Point(110, 170);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(110, 30);
            this.btn_seleccionar.TabIndex = 2;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.UseVisualStyleBackColor = true;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 246);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.ListadoEstadisticas);
            this.Controls.Add(this.label1);
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ListadoEstadisticas;
        private System.Windows.Forms.Button btn_seleccionar;
    }
}