namespace CapaUI
{
    partial class frmRealizarInspeccion
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
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoFiscalizacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaProgramada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInspector = new System.Windows.Forms.TextBox();
            this.dgvCriterios = new System.Windows.Forms.DataGridView();
            this.ColNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCriterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRiesgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResultado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColEvidencia = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarInspeccion = new System.Windows.Forms.Button();
            this.RutaEvidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(181, 43);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(100, 20);
            this.txtRazonSocial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Razon Social";
            // 
            // b
            // 
            this.b.AutoSize = true;
            this.b.Location = new System.Drawing.Point(92, 72);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(93, 13);
            this.b.TabIndex = 3;
            this.b.Text = "Nombre Comercial";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(181, 69);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(100, 20);
            this.txtNombreComercial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "RUC";
            // 
            // txtRUC
            // 
            this.txtRUC.Location = new System.Drawing.Point(181, 95);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(100, 20);
            this.txtRUC.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(181, 121);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo";
            // 
            // txtTipoFiscalizacion
            // 
            this.txtTipoFiscalizacion.Location = new System.Drawing.Point(181, 165);
            this.txtTipoFiscalizacion.Name = "txtTipoFiscalizacion";
            this.txtTipoFiscalizacion.Size = new System.Drawing.Size(100, 20);
            this.txtTipoFiscalizacion.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Programada";
            // 
            // txtFechaProgramada
            // 
            this.txtFechaProgramada.Location = new System.Drawing.Point(181, 191);
            this.txtFechaProgramada.Name = "txtFechaProgramada";
            this.txtFechaProgramada.Size = new System.Drawing.Size(100, 20);
            this.txtFechaProgramada.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "inspector";
            // 
            // txtInspector
            // 
            this.txtInspector.Location = new System.Drawing.Point(181, 217);
            this.txtInspector.Name = "txtInspector";
            this.txtInspector.Size = new System.Drawing.Size(100, 20);
            this.txtInspector.TabIndex = 12;
            // 
            // dgvCriterios
            // 
            this.dgvCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNumero,
            this.ColCriterio,
            this.ColRiesgo,
            this.ColResultado,
            this.ColEvidencia,
            this.ColObservacion,
            this.RutaEvidencia});
            this.dgvCriterios.Location = new System.Drawing.Point(34, 269);
            this.dgvCriterios.Name = "dgvCriterios";
            this.dgvCriterios.Size = new System.Drawing.Size(643, 150);
            this.dgvCriterios.TabIndex = 14;
            this.dgvCriterios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCriterios_CellClick);
            this.dgvCriterios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCriterios_CellContentClick);
            // 
            // ColNumero
            // 
            this.ColNumero.HeaderText = "Numero";
            this.ColNumero.Name = "ColNumero";
            // 
            // ColCriterio
            // 
            this.ColCriterio.HeaderText = "Criterio";
            this.ColCriterio.Name = "ColCriterio";
            // 
            // ColRiesgo
            // 
            this.ColRiesgo.HeaderText = "Riesgo";
            this.ColRiesgo.Name = "ColRiesgo";
            // 
            // ColResultado
            // 
            this.ColResultado.FalseValue = "No";
            this.ColResultado.HeaderText = "Cumple";
            this.ColResultado.Name = "ColResultado";
            this.ColResultado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColResultado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColResultado.TrueValue = "Si";
            // 
            // ColEvidencia
            // 
            this.ColEvidencia.HeaderText = "Evidencia";
            this.ColEvidencia.Name = "ColEvidencia";
            this.ColEvidencia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEvidencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColObservacion
            // 
            this.ColObservacion.HeaderText = "Observacion";
            this.ColObservacion.Name = "ColObservacion";
            // 
            // btnGuardarInspeccion
            // 
            this.btnGuardarInspeccion.Location = new System.Drawing.Point(344, 228);
            this.btnGuardarInspeccion.Name = "btnGuardarInspeccion";
            this.btnGuardarInspeccion.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarInspeccion.TabIndex = 15;
            this.btnGuardarInspeccion.Text = "Finalizar Inspeccion";
            this.btnGuardarInspeccion.UseVisualStyleBackColor = true;
            this.btnGuardarInspeccion.Click += new System.EventHandler(this.btnGuardarInspeccion_Click);
            // 
            // RutaEvidencia
            // 
            this.RutaEvidencia.HeaderText = "Ruta Evidencia";
            this.RutaEvidencia.Name = "RutaEvidencia";
            // 
            // frmRealizarInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuardarInspeccion);
            this.Controls.Add(this.dgvCriterios);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInspector);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFechaProgramada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipoFiscalizacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRUC);
            this.Controls.Add(this.b);
            this.Controls.Add(this.txtNombreComercial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazonSocial);
            this.Name = "frmRealizarInspeccion";
            this.Text = "frmRealizarInspeccion";
            this.Load += new System.EventHandler(this.frmRealizarInspeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipoFiscalizacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaProgramada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInspector;
        private System.Windows.Forms.DataGridView dgvCriterios;
        private System.Windows.Forms.Button btnGuardarInspeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCriterio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRiesgo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColResultado;
        private System.Windows.Forms.DataGridViewButtonColumn ColEvidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaEvidencia;
    }
}