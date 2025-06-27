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
            this.picEvidencia = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.btnGuardarRespuesta = new System.Windows.Forms.Button();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDenuncias = new System.Windows.Forms.DataGridView();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDireccionEstablecimiento = new System.Windows.Forms.Label();
            this.lblEstablecimiento = new System.Windows.Forms.Label();
            this.lblRUC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenuncias)).BeginInit();
            this.SuspendLayout();
            // 
            // picEvidencia
            // 
            this.picEvidencia.Location = new System.Drawing.Point(486, 277);
            this.picEvidencia.Name = "picEvidencia";
            this.picEvidencia.Size = new System.Drawing.Size(161, 132);
            this.picEvidencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEvidencia.TabIndex = 21;
            this.picEvidencia.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(329, 194);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 43);
            this.txtDescripcion.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Descripcion";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(351, 142);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(38, 13);
            this.lblCorreo.TabIndex = 17;
            this.lblCorreo.Text = "Correo";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(298, 106);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(101, 13);
            this.lblNombres.TabIndex = 15;
            this.lblNombres.Text = "Nombres Completos";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(351, 65);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(26, 13);
            this.lblDNI.TabIndex = 13;
            this.lblDNI.Text = "DNI";
            // 
            // btnGuardarRespuesta
            // 
            this.btnGuardarRespuesta.Location = new System.Drawing.Point(364, 386);
            this.btnGuardarRespuesta.Name = "btnGuardarRespuesta";
            this.btnGuardarRespuesta.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRespuesta.TabIndex = 12;
            this.btnGuardarRespuesta.Text = "Guardar Respuesta";
            this.btnGuardarRespuesta.UseVisualStyleBackColor = true;
            this.btnGuardarRespuesta.Click += new System.EventHandler(this.btnGuardarRespuesta_Click);
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(458, 22);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(121, 21);
            this.cmbEstadoFiltro.TabIndex = 22;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Filtro";
            // 
            // dgvDenuncias
            // 
            this.dgvDenuncias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDenuncias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDenuncias.Location = new System.Drawing.Point(444, 85);
            this.dgvDenuncias.Name = "dgvDenuncias";
            this.dgvDenuncias.ReadOnly = true;
            this.dgvDenuncias.Size = new System.Drawing.Size(261, 186);
            this.dgvDenuncias.TabIndex = 24;
            this.dgvDenuncias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDenuncias_CellClick);
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(364, 310);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(100, 43);
            this.txtRespuesta.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Respuesta";
            // 
            // lblDireccionEstablecimiento
            // 
            this.lblDireccionEstablecimiento.AutoSize = true;
            this.lblDireccionEstablecimiento.Location = new System.Drawing.Point(215, 142);
            this.lblDireccionEstablecimiento.Name = "lblDireccionEstablecimiento";
            this.lblDireccionEstablecimiento.Size = new System.Drawing.Size(52, 13);
            this.lblDireccionEstablecimiento.TabIndex = 29;
            this.lblDireccionEstablecimiento.Text = "Direccion";
            // 
            // lblEstablecimiento
            // 
            this.lblEstablecimiento.AutoSize = true;
            this.lblEstablecimiento.Location = new System.Drawing.Point(162, 106);
            this.lblEstablecimiento.Name = "lblEstablecimiento";
            this.lblEstablecimiento.Size = new System.Drawing.Size(81, 13);
            this.lblEstablecimiento.TabIndex = 28;
            this.lblEstablecimiento.Text = "Establecimiento";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Location = new System.Drawing.Point(215, 65);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(30, 13);
            this.lblRUC.TabIndex = 27;
            this.lblRUC.Text = "RUC";
            // 
            // frmDenuncia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDireccionEstablecimiento);
            this.Controls.Add(this.lblEstablecimiento);
            this.Controls.Add(this.lblRUC);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvDenuncias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEstadoFiltro);
            this.Controls.Add(this.picEvidencia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.btnGuardarRespuesta);
            this.Name = "frmDenuncia";
            this.Text = "frmDenuncia";
            this.Load += new System.EventHandler(this.frmDenuncia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDenuncias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picEvidencia;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Button btnGuardarRespuesta;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDenuncias;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDireccionEstablecimiento;
        private System.Windows.Forms.Label lblEstablecimiento;
        private System.Windows.Forms.Label lblRUC;
    }
}