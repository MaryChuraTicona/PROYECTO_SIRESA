namespace CapaUI
{
    partial class frmPrincipal
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHistorialAccesos = new System.Windows.Forms.Button();
            this.btnCriterios = new System.Windows.Forms.Button();
            this.btnMisFiscalizaciones = new System.Windows.Forms.Button();
            this.btnDenuncia = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnFiscalizacion = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnEstablecimiento = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(138, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(91, 20);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "USUARIO";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.btnHistorialAccesos);
            this.panel1.Controls.Add(this.btnUsuario);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnCriterios);
            this.panel1.Controls.Add(this.btnFiscalizacion);
            this.panel1.Controls.Add(this.btnDenuncia);
            this.panel1.Controls.Add(this.btnEmpleado);
            this.panel1.Controls.Add(this.btnMisFiscalizaciones);
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Controls.Add(this.btnEstablecimiento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 681);
            this.panel1.TabIndex = 10;
            // 
            // btnHistorialAccesos
            // 
            this.btnHistorialAccesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHistorialAccesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialAccesos.ForeColor = System.Drawing.Color.White;
            this.btnHistorialAccesos.Location = new System.Drawing.Point(-3, 435);
            this.btnHistorialAccesos.Name = "btnHistorialAccesos";
            this.btnHistorialAccesos.Size = new System.Drawing.Size(159, 36);
            this.btnHistorialAccesos.TabIndex = 11;
            this.btnHistorialAccesos.Text = "Historial Accesos";
            this.btnHistorialAccesos.UseVisualStyleBackColor = false;
            this.btnHistorialAccesos.Click += new System.EventHandler(this.btnHistorialAccesos_Click);
            // 
            // btnCriterios
            // 
            this.btnCriterios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCriterios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriterios.ForeColor = System.Drawing.Color.White;
            this.btnCriterios.Location = new System.Drawing.Point(3, 222);
            this.btnCriterios.Name = "btnCriterios";
            this.btnCriterios.Size = new System.Drawing.Size(156, 42);
            this.btnCriterios.TabIndex = 11;
            this.btnCriterios.Text = "Criterios";
            this.btnCriterios.UseVisualStyleBackColor = false;
            this.btnCriterios.Click += new System.EventHandler(this.btnCriterios_Click);
            // 
            // btnMisFiscalizaciones
            // 
            this.btnMisFiscalizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMisFiscalizaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisFiscalizaciones.ForeColor = System.Drawing.Color.White;
            this.btnMisFiscalizaciones.Location = new System.Drawing.Point(-3, 312);
            this.btnMisFiscalizaciones.Name = "btnMisFiscalizaciones";
            this.btnMisFiscalizaciones.Size = new System.Drawing.Size(159, 39);
            this.btnMisFiscalizaciones.TabIndex = 10;
            this.btnMisFiscalizaciones.Text = "Mis Fiscalizaciones";
            this.btnMisFiscalizaciones.UseVisualStyleBackColor = false;
            this.btnMisFiscalizaciones.Click += new System.EventHandler(this.btnMisFiscalizaciones_Click);
            // 
            // btnDenuncia
            // 
            this.btnDenuncia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDenuncia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDenuncia.ForeColor = System.Drawing.Color.White;
            this.btnDenuncia.Location = new System.Drawing.Point(0, 398);
            this.btnDenuncia.Name = "btnDenuncia";
            this.btnDenuncia.Size = new System.Drawing.Size(156, 34);
            this.btnDenuncia.TabIndex = 9;
            this.btnDenuncia.Text = "Denuncias";
            this.btnDenuncia.UseVisualStyleBackColor = false;
            this.btnDenuncia.Click += new System.EventHandler(this.btnDenuncia_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnEmpleado.Location = new System.Drawing.Point(0, 97);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(159, 34);
            this.btnEmpleado.TabIndex = 8;
            this.btnEmpleado.Text = "Empleados";
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(0, 477);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(156, 32);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "CerrarSesion";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Location = new System.Drawing.Point(3, 137);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(156, 37);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnFiscalizacion
            // 
            this.btnFiscalizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFiscalizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiscalizacion.ForeColor = System.Drawing.Color.White;
            this.btnFiscalizacion.Location = new System.Drawing.Point(0, 267);
            this.btnFiscalizacion.Name = "btnFiscalizacion";
            this.btnFiscalizacion.Size = new System.Drawing.Size(159, 39);
            this.btnFiscalizacion.TabIndex = 2;
            this.btnFiscalizacion.Text = "Fiscalizaciones";
            this.btnFiscalizacion.UseVisualStyleBackColor = false;
            this.btnFiscalizacion.Click += new System.EventHandler(this.btnFiscalizacion_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Location = new System.Drawing.Point(-3, 357);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(159, 35);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Reportes";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnEstablecimiento
            // 
            this.btnEstablecimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEstablecimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstablecimiento.ForeColor = System.Drawing.Color.White;
            this.btnEstablecimiento.Location = new System.Drawing.Point(0, 180);
            this.btnEstablecimiento.Name = "btnEstablecimiento";
            this.btnEstablecimiento.Size = new System.Drawing.Size(159, 36);
            this.btnEstablecimiento.TabIndex = 1;
            this.btnEstablecimiento.Text = "Establecimientos";
            this.btnEstablecimiento.UseVisualStyleBackColor = false;
            this.btnEstablecimiento.Click += new System.EventHandler(this.btnEstablecimiento_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblUsuario);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(159, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1105, 61);
            this.panel3.TabIndex = 11;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDenuncia;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnFiscalizacion;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnEstablecimiento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMisFiscalizaciones;
        private System.Windows.Forms.Button btnHistorialAccesos;
        private System.Windows.Forms.Button btnCriterios;
    }
}