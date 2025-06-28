namespace CapaUI
{
    partial class frmDetalleDenuncia
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
            this.lblDireccionEstablecimiento = new System.Windows.Forms.Label();
            this.lblEstablecimiento = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picEvidencia = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.btnGuardarRespuesta = new System.Windows.Forms.Button();
            this.btnEnviarCorreo = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDireccionEstablecimiento
            // 
            this.lblDireccionEstablecimiento.AutoSize = true;
            this.lblDireccionEstablecimiento.Location = new System.Drawing.Point(76, 140);
            this.lblDireccionEstablecimiento.Name = "lblDireccionEstablecimiento";
            this.lblDireccionEstablecimiento.Size = new System.Drawing.Size(52, 13);
            this.lblDireccionEstablecimiento.TabIndex = 44;
            this.lblDireccionEstablecimiento.Text = "Direccion";
            // 
            // lblEstablecimiento
            // 
            this.lblEstablecimiento.AutoSize = true;
            this.lblEstablecimiento.Location = new System.Drawing.Point(76, 104);
            this.lblEstablecimiento.Name = "lblEstablecimiento";
            this.lblEstablecimiento.Size = new System.Drawing.Size(81, 13);
            this.lblEstablecimiento.TabIndex = 43;
            this.lblEstablecimiento.Text = "Establecimiento";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Location = new System.Drawing.Point(92, 63);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(30, 13);
            this.lblRUC.TabIndex = 42;
            this.lblRUC.Text = "RUC";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(153, 284);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(100, 43);
            this.txtRespuesta.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Respuesta";
            // 
            // picEvidencia
            // 
            this.picEvidencia.Location = new System.Drawing.Point(293, 228);
            this.picEvidencia.Name = "picEvidencia";
            this.picEvidencia.Size = new System.Drawing.Size(161, 132);
            this.picEvidencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEvidencia.TabIndex = 36;
            this.picEvidencia.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(153, 202);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 43);
            this.txtDescripcion.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Descripcion";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(316, 140);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(38, 13);
            this.lblCorreo.TabIndex = 33;
            this.lblCorreo.Text = "Correo";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(262, 104);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(101, 13);
            this.lblNombres.TabIndex = 32;
            this.lblNombres.Text = "Nombres Completos";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(318, 63);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 31;
            this.lblDNI.Text = "DNI";
            // 
            // btnGuardarRespuesta
            // 
            this.btnGuardarRespuesta.Location = new System.Drawing.Point(169, 359);
            this.btnGuardarRespuesta.Name = "btnGuardarRespuesta";
            this.btnGuardarRespuesta.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRespuesta.TabIndex = 30;
            this.btnGuardarRespuesta.Text = "Guardar Respuesta";
            this.btnGuardarRespuesta.UseVisualStyleBackColor = true;
            this.btnGuardarRespuesta.Click += new System.EventHandler(this.btnGuardarRespuesta_Click);
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.Location = new System.Drawing.Point(319, 366);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarCorreo.TabIndex = 45;
            this.btnEnviarCorreo.Text = "Enviar Correo";
            this.btnEnviarCorreo.UseVisualStyleBackColor = true;
            this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(122, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 46;
            this.lblTitulo.Text = "label1";
            // 
            // frmDetalleDenuncia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEnviarCorreo);
            this.Controls.Add(this.lblDireccionEstablecimiento);
            this.Controls.Add(this.lblEstablecimiento);
            this.Controls.Add(this.lblRUC);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picEvidencia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.btnGuardarRespuesta);
            this.Name = "frmDetalleDenuncia";
            this.Text = "frmDetalleDenuncia";
            this.Load += new System.EventHandler(this.frmDetalleDenuncia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDireccionEstablecimiento;
        private System.Windows.Forms.Label lblEstablecimiento;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picEvidencia;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Button btnGuardarRespuesta;
        private System.Windows.Forms.Button btnEnviarCorreo;
        private System.Windows.Forms.Label lblTitulo;
    }
}