namespace CapaUI
{
    partial class frmCriteriosFiscalizacion
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
            this.dgvCriterios = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NivelRiesgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarCriterios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCriterios
            // 
            this.dgvCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Criterio,
            this.NivelRiesgo,
            this.Resultado,
            this.Observacion});
            this.dgvCriterios.Location = new System.Drawing.Point(81, 101);
            this.dgvCriterios.Name = "dgvCriterios";
            this.dgvCriterios.Size = new System.Drawing.Size(496, 145);
            this.dgvCriterios.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "N°";
            this.Numero.Name = "Numero";
            this.Numero.Width = 30;
            // 
            // Criterio
            // 
            this.Criterio.HeaderText = "Criterio";
            this.Criterio.Name = "Criterio";
            // 
            // NivelRiesgo
            // 
            this.NivelRiesgo.HeaderText = "Nivel de Riesgo";
            this.NivelRiesgo.Name = "NivelRiesgo";
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.Resultado.Name = "Resultado";
            // 
            // Observacion
            // 
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.Name = "Observacion";
            // 
            // btnGuardarCriterios
            // 
            this.btnGuardarCriterios.Location = new System.Drawing.Point(285, 287);
            this.btnGuardarCriterios.Name = "btnGuardarCriterios";
            this.btnGuardarCriterios.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCriterios.TabIndex = 1;
            this.btnGuardarCriterios.Text = "Guardar ";
            this.btnGuardarCriterios.UseVisualStyleBackColor = true;
            this.btnGuardarCriterios.Click += new System.EventHandler(this.btnGuardarCriterios_Click);
            // 
            // frmCriteriosFiscalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuardarCriterios);
            this.Controls.Add(this.dgvCriterios);
            this.Name = "frmCriteriosFiscalizacion";
            this.Text = "frmCriteriosFiscalizacion";
            this.Load += new System.EventHandler(this.frmCriteriosFiscalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCriterios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criterio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NivelRiesgo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
        private System.Windows.Forms.Button btnGuardarCriterios;
    }
}