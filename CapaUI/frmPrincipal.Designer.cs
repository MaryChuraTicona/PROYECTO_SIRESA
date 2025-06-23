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
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnEstablecimientos = new System.Windows.Forms.Button();
            this.btnFiscalizaciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnAsignarFiscalizaciones = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(67, 46);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnEstablecimientos
            // 
            this.btnEstablecimientos.Location = new System.Drawing.Point(67, 75);
            this.btnEstablecimientos.Name = "btnEstablecimientos";
            this.btnEstablecimientos.Size = new System.Drawing.Size(75, 23);
            this.btnEstablecimientos.TabIndex = 1;
            this.btnEstablecimientos.Text = "Establecimientos";
            this.btnEstablecimientos.UseVisualStyleBackColor = true;
            this.btnEstablecimientos.Click += new System.EventHandler(this.btnEstablecimientos_Click);
            // 
            // btnFiscalizaciones
            // 
            this.btnFiscalizaciones.Location = new System.Drawing.Point(67, 117);
            this.btnFiscalizaciones.Name = "btnFiscalizaciones";
            this.btnFiscalizaciones.Size = new System.Drawing.Size(75, 23);
            this.btnFiscalizaciones.TabIndex = 2;
            this.btnFiscalizaciones.Text = "Fiscalizaciones";
            this.btnFiscalizaciones.UseVisualStyleBackColor = true;
            this.btnFiscalizaciones.Click += new System.EventHandler(this.btnFiscalizaciones_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(67, 211);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(75, 23);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(67, 250);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "CerrarSesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnAsignarFiscalizaciones
            // 
            this.btnAsignarFiscalizaciones.Location = new System.Drawing.Point(67, 166);
            this.btnAsignarFiscalizaciones.Name = "btnAsignarFiscalizaciones";
            this.btnAsignarFiscalizaciones.Size = new System.Drawing.Size(228, 39);
            this.btnAsignarFiscalizaciones.TabIndex = 5;
            this.btnAsignarFiscalizaciones.Text = "ASIGNAR Fiscalizaciones";
            this.btnAsignarFiscalizaciones.UseVisualStyleBackColor = true;
            this.btnAsignarFiscalizaciones.Click += new System.EventHandler(this.btnAsignarFiscalizaciones_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(229, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(56, 13);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "USUARIO";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnAsignarFiscalizaciones);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnFiscalizaciones);
            this.Controls.Add(this.btnEstablecimientos);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEstablecimientos;
        private System.Windows.Forms.Button btnFiscalizaciones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAsignarFiscalizaciones;
        private System.Windows.Forms.Label lblUsuario;
    }
}