namespace ClinicaFrba.Cancelar_Turno
{
    partial class AfiliadoCancelarTurno
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
            this.dataGridTurnos = new System.Windows.Forms.DataGridView();
            this.buttonCancelarTurno = new System.Windows.Forms.Button();
            this.richTextMotivo = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTurnos
            // 
            this.dataGridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTurnos.Location = new System.Drawing.Point(25, 32);
            this.dataGridTurnos.Name = "dataGridTurnos";
            this.dataGridTurnos.Size = new System.Drawing.Size(621, 164);
            this.dataGridTurnos.TabIndex = 0;
            this.dataGridTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTurnos_CellClick);
            this.dataGridTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTurnos_CellContentClick);
            // 
            // buttonCancelarTurno
            // 
            this.buttonCancelarTurno.Location = new System.Drawing.Point(491, 289);
            this.buttonCancelarTurno.Name = "buttonCancelarTurno";
            this.buttonCancelarTurno.Size = new System.Drawing.Size(120, 23);
            this.buttonCancelarTurno.TabIndex = 2;
            this.buttonCancelarTurno.Text = "Cancelar Turno";
            this.buttonCancelarTurno.UseVisualStyleBackColor = true;
            this.buttonCancelarTurno.Click += new System.EventHandler(this.buttonCancelarTurno_Click);
            // 
            // richTextMotivo
            // 
            this.richTextMotivo.Location = new System.Drawing.Point(28, 227);
            this.richTextMotivo.Name = "richTextMotivo";
            this.richTextMotivo.Size = new System.Drawing.Size(424, 85);
            this.richTextMotivo.TabIndex = 3;
            this.richTextMotivo.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Motivo de la cancelacion";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(490, 245);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de cancelacion";
            // 
            // AfiliadoCancelarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextMotivo);
            this.Controls.Add(this.buttonCancelarTurno);
            this.Controls.Add(this.dataGridTurnos);
            this.Name = "AfiliadoCancelarTurno";
            this.Text = "Cancelacion de Turnos";
            this.Load += new System.EventHandler(this.AfiliadoCancelarTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridTurnos;
        private System.Windows.Forms.Button buttonCancelarTurno;
        private System.Windows.Forms.RichTextBox richTextMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}