namespace CapaUI
{
    partial class frmFiscalizaciones
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevaFiscalizacion = new System.Windows.Forms.Button();
            this.dgvFiscalizaciones = new System.Windows.Forms.DataGridView();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.FiscalizacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFiscalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFiscalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoFiscalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PDF = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalizaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Fiscalizaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(224, 75);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnNuevaFiscalizacion
            // 
            this.btnNuevaFiscalizacion.Location = new System.Drawing.Point(179, 112);
            this.btnNuevaFiscalizacion.Name = "btnNuevaFiscalizacion";
            this.btnNuevaFiscalizacion.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaFiscalizacion.TabIndex = 4;
            this.btnNuevaFiscalizacion.Text = "Nueva";
            this.btnNuevaFiscalizacion.UseVisualStyleBackColor = true;
            this.btnNuevaFiscalizacion.Click += new System.EventHandler(this.btnNuevaFiscalizacion_Click);
            // 
            // dgvFiscalizaciones
            // 
            this.dgvFiscalizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiscalizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FiscalizacionID,
            this.NombreEstablecimiento,
            this.FechaFiscalizacion,
            this.TipoFiscalizacion,
            this.EstadoFiscalizacion,
            this.Ver,
            this.Editar,
            this.PDF});
            this.dgvFiscalizaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFiscalizaciones.Location = new System.Drawing.Point(0, 264);
            this.dgvFiscalizaciones.Name = "dgvFiscalizaciones";
            this.dgvFiscalizaciones.Size = new System.Drawing.Size(800, 186);
            this.dgvFiscalizaciones.TabIndex = 5;
            this.dgvFiscalizaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiscalizaciones_CellContentClick);
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(352, 74);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(121, 21);
            this.cmbEstadoFiltro.TabIndex = 6;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // FiscalizacionID
            // 
            this.FiscalizacionID.HeaderText = "ID";
            this.FiscalizacionID.Name = "FiscalizacionID";
            this.FiscalizacionID.Width = 30;
            // 
            // NombreEstablecimiento
            // 
            this.NombreEstablecimiento.HeaderText = "Nombre Establecimiento";
            this.NombreEstablecimiento.Name = "NombreEstablecimiento";
            // 
            // FechaFiscalizacion
            // 
            this.FechaFiscalizacion.HeaderText = "Fecha Fiscalizacion";
            this.FechaFiscalizacion.Name = "FechaFiscalizacion";
            // 
            // TipoFiscalizacion
            // 
            this.TipoFiscalizacion.HeaderText = "Tipo ";
            this.TipoFiscalizacion.Name = "TipoFiscalizacion";
            // 
            // EstadoFiscalizacion
            // 
            this.EstadoFiscalizacion.HeaderText = "Estado";
            this.EstadoFiscalizacion.Name = "EstadoFiscalizacion";
            // 
            // Ver
            // 
            this.Ver.HeaderText = "Ver";
            this.Ver.Name = "Ver";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            // 
            // PDF
            // 
            this.PDF.HeaderText = "PDF";
            this.PDF.Name = "PDF";
            // 
            // frmFiscalizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbEstadoFiltro);
            this.Controls.Add(this.dgvFiscalizaciones);
            this.Controls.Add(this.btnNuevaFiscalizacion);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFiscalizaciones";
            this.Text = "frmFiscalizaciones";
            this.Load += new System.EventHandler(this.frmFiscalizaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiscalizaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevaFiscalizacion;
        private System.Windows.Forms.DataGridView dgvFiscalizaciones;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FiscalizacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFiscalizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFiscalizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoFiscalizacion;
        private System.Windows.Forms.DataGridViewButtonColumn Ver;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn PDF;
    }
}