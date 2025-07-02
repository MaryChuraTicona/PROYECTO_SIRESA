namespace CapaUI
{
    partial class frmCapturaFiscalizacion
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.picCaptura = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptura)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(107, 292);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Location = new System.Drawing.Point(107, 263);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(75, 23);
            this.btnTomarFoto.TabIndex = 4;
            this.btnTomarFoto.Text = "Capturar";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // picCaptura
            // 
            this.picCaptura.Location = new System.Drawing.Point(53, 32);
            this.picCaptura.Name = "picCaptura";
            this.picCaptura.Size = new System.Drawing.Size(165, 209);
            this.picCaptura.TabIndex = 3;
            this.picCaptura.TabStop = false;
            // 
            // frmCapturaFiscalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.picCaptura);
            this.Name = "frmCapturaFiscalizacion";
            this.Text = "frmCapturaFiscalizacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCapturaFiscalizacion_FormClosing);
            this.Load += new System.EventHandler(this.frmCapturaFiscalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.PictureBox picCaptura;
    }
}