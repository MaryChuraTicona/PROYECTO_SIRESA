namespace CapaUI
{
    partial class frmNuevaFiscalizacion
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbEstablecimiento = new System.Windows.Forms.ComboBox();
            this.lblEstablecimiento = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.chkNotificado = new System.Windows.Forms.CheckBox();
            this.lblFechaNotif = new System.Windows.Forms.Label();
            this.dtpFechaFiscalizacion = new System.Windows.Forms.DateTimePicker();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dtpNotificacion = new System.Windows.Forms.DateTimePicker();
            this.dgvEquipo = new System.Windows.Forms.DataGridView();
            this.btnAgregarInspector = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnQuitarInspector = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(179, 257);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbEstablecimiento
            // 
            this.cmbEstablecimiento.FormattingEnabled = true;
            this.cmbEstablecimiento.Location = new System.Drawing.Point(155, 33);
            this.cmbEstablecimiento.Name = "cmbEstablecimiento";
            this.cmbEstablecimiento.Size = new System.Drawing.Size(121, 21);
            this.cmbEstablecimiento.TabIndex = 1;
            // 
            // lblEstablecimiento
            // 
            this.lblEstablecimiento.AutoSize = true;
            this.lblEstablecimiento.Location = new System.Drawing.Point(43, 36);
            this.lblEstablecimiento.Name = "lblEstablecimiento";
            this.lblEstablecimiento.Size = new System.Drawing.Size(81, 13);
            this.lblEstablecimiento.TabIndex = 2;
            this.lblEstablecimiento.Text = "Establecimeinto";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(43, 63);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(155, 60);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(43, 95);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(112, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha de fiscalizacion";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(43, 131);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 6;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // chkNotificado
            // 
            this.chkNotificado.AutoSize = true;
            this.chkNotificado.Location = new System.Drawing.Point(150, 166);
            this.chkNotificado.Name = "chkNotificado";
            this.chkNotificado.Size = new System.Drawing.Size(74, 17);
            this.chkNotificado.TabIndex = 7;
            this.chkNotificado.Text = "Notificado";
            this.chkNotificado.UseVisualStyleBackColor = true;
            // 
            // lblFechaNotif
            // 
            this.lblFechaNotif.AutoSize = true;
            this.lblFechaNotif.Location = new System.Drawing.Point(74, 206);
            this.lblFechaNotif.Name = "lblFechaNotif";
            this.lblFechaNotif.Size = new System.Drawing.Size(63, 13);
            this.lblFechaNotif.TabIndex = 8;
            this.lblFechaNotif.Text = "Notificacion";
            // 
            // dtpFechaFiscalizacion
            // 
            this.dtpFechaFiscalizacion.Location = new System.Drawing.Point(161, 89);
            this.dtpFechaFiscalizacion.Name = "dtpFechaFiscalizacion";
            this.dtpFechaFiscalizacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFiscalizacion.TabIndex = 9;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(161, 124);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(100, 20);
            this.txtObservaciones.TabIndex = 10;
            // 
            // dtpNotificacion
            // 
            this.dtpNotificacion.Location = new System.Drawing.Point(155, 199);
            this.dtpNotificacion.Name = "dtpNotificacion";
            this.dtpNotificacion.Size = new System.Drawing.Size(200, 20);
            this.dtpNotificacion.TabIndex = 11;
            // 
            // dgvEquipo
            // 
            this.dgvEquipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipo.Location = new System.Drawing.Point(383, 257);
            this.dgvEquipo.Name = "dgvEquipo";
            this.dgvEquipo.Size = new System.Drawing.Size(240, 150);
            this.dgvEquipo.TabIndex = 21;
            // 
            // btnAgregarInspector
            // 
            this.btnAgregarInspector.Location = new System.Drawing.Point(399, 208);
            this.btnAgregarInspector.Name = "btnAgregarInspector";
            this.btnAgregarInspector.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarInspector.TabIndex = 20;
            this.btnAgregarInspector.Text = "Agregar";
            this.btnAgregarInspector.UseVisualStyleBackColor = true;
            this.btnAgregarInspector.Click += new System.EventHandler(this.btnAgregarInspector_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(466, 161);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(121, 21);
            this.cmbRol.TabIndex = 18;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(380, 161);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 17;
            this.lblRol.Text = "Rol";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(385, 99);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(59, 13);
            this.lblEmpleado.TabIndex = 15;
            this.lblEmpleado.Text = "Empleados";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(466, 91);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(121, 21);
            this.cmbEmpleado.TabIndex = 13;
            // 
            // btnQuitarInspector
            // 
            this.btnQuitarInspector.Location = new System.Drawing.Point(512, 208);
            this.btnQuitarInspector.Name = "btnQuitarInspector";
            this.btnQuitarInspector.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarInspector.TabIndex = 22;
            this.btnQuitarInspector.Text = "Quitar";
            this.btnQuitarInspector.UseVisualStyleBackColor = true;
            this.btnQuitarInspector.Click += new System.EventHandler(this.btnQuitarInspector_Click);
            // 
            // frmNuevaFiscalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuitarInspector);
            this.Controls.Add(this.dgvEquipo);
            this.Controls.Add(this.btnAgregarInspector);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.dtpNotificacion);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.dtpFechaFiscalizacion);
            this.Controls.Add(this.lblFechaNotif);
            this.Controls.Add(this.chkNotificado);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblEstablecimiento);
            this.Controls.Add(this.cmbEstablecimiento);
            this.Controls.Add(this.btnGuardar);
            this.Name = "frmNuevaFiscalizacion";
            this.Text = "frmNuevaFiscalizacion";
            this.Load += new System.EventHandler(this.frmNuevaFiscalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbEstablecimiento;
        private System.Windows.Forms.Label lblEstablecimiento;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.CheckBox chkNotificado;
        private System.Windows.Forms.Label lblFechaNotif;
        private System.Windows.Forms.DateTimePicker dtpFechaFiscalizacion;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DateTimePicker dtpNotificacion;
        private System.Windows.Forms.DataGridView dgvEquipo;
        private System.Windows.Forms.Button btnAgregarInspector;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Button btnQuitarInspector;
    }
}