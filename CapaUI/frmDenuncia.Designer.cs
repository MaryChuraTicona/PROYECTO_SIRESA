namespace CapaUI
{
    partial class frmDenuncia
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
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.dgvDenuncias = new System.Windows.Forms.DataGridView();
            this.DenunciaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenuncias)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(233, 73);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(121, 21);
            this.cmbEstadoFiltro.TabIndex = 22;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(137, 81);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(29, 13);
            this.lblFiltro.TabIndex = 23;
            this.lblFiltro.Text = "Filtro";
            // 
            // dgvDenuncias
            // 
            this.dgvDenuncias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDenuncias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDenuncias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DenunciaID,
            this.DNI,
            this.Nombres,
            this.Correo,
            this.FechaRegistro,
            this.Estado});
            this.dgvDenuncias.Location = new System.Drawing.Point(82, 142);
            this.dgvDenuncias.Name = "dgvDenuncias";
            this.dgvDenuncias.ReadOnly = true;
            this.dgvDenuncias.Size = new System.Drawing.Size(261, 186);
            this.dgvDenuncias.TabIndex = 24;
            this.dgvDenuncias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDenuncias_CellClick);
            this.dgvDenuncias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDenuncias_CellContentClick);
            // 
            // DenunciaID
            // 
            this.DenunciaID.HeaderText = "DenunciaID";
            this.DenunciaID.Name = "DenunciaID";
            this.DenunciaID.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Nombres completos";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "Fecha de Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // frmDenuncia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDenuncias);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbEstadoFiltro);
            this.Name = "frmDenuncia";
            this.Text = "frmDenuncia";
            this.Load += new System.EventHandler(this.frmDenuncia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenuncias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridView dgvDenuncias;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenunciaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}