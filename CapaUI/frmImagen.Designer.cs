namespace CapaUI
{
    partial class frmImagen
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
            this.picVisor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVisor)).BeginInit();
            this.SuspendLayout();
            // 
            // picVisor
            // 
            this.picVisor.Location = new System.Drawing.Point(82, 39);
            this.picVisor.Name = "picVisor";
            this.picVisor.Size = new System.Drawing.Size(120, 149);
            this.picVisor.TabIndex = 0;
            this.picVisor.TabStop = false;
            // 
            // frmImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picVisor);
            this.Name = "frmImagen";
            this.Text = "frmImagen";
            this.Load += new System.EventHandler(this.frmImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picVisor;
    }
}