using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;

namespace CapaUI
{
    public partial class frmLogin : Form
    {
        private string captchaText;
        private Random random = new Random();
        public frmLogin()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            // Generar texto aleatorio para el CAPTCHA
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            captchaText = "";
            for (int i = 0; i < 6; i++)
            {
                captchaText += chars[random.Next(chars.Length)];
            }

            // Crear imagen del CAPTCHA - Usa picCaptcha en lugar de captchaPictureBox
            Bitmap bmp = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Fondo blanco
                g.Clear(Color.White);

                // Dibujar texto con distorsión
                for (int i = 0; i < captchaText.Length; i++)
                {
                    Font font = new Font("Arial", 14 + random.Next(-2, 3), FontStyle.Bold);
                    g.DrawString(captchaText[i].ToString(), font,
                                Brushes.Black, 10 + i * 20, 5 + random.Next(-5, 5));
                }

                // Agregar líneas de ruido
                for (int i = 0; i < 10; i++)
                {
                    g.DrawLine(Pens.Gray,
                               random.Next(bmp.Width), random.Next(bmp.Height),
                               random.Next(bmp.Width), random.Next(bmp.Height));
                }
            }

            picCaptcha.Image = bmp; 
        }
        
        private void PROBAR_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            if (txtCaptcha.Text != captchaText)
            {
                MessageBox.Show("CAPTCHA incorrecto. Intente nuevamente.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenerateCaptcha();
                txtCaptcha.Clear();
                return;
            }
            var logica = new login_CN();
            var usuario = logica.IniciarSesion(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());

            if (usuario != null)
            {
                MessageBox.Show("Login exitoso!", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmPrincipal principal = new frmPrincipal(usuario);  
                principal.Show();

                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenerateCaptcha();
                txtCaptcha.Clear();
            }
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            

            this.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            this.ClientSize = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblSiresa.Text = "SIRESA";
            lblSiresa.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblSiresa.ForeColor = Color.FromArgb(192, 0, 0);
            lblSiresa.AutoSize = false;
            lblSiresa.TextAlign = ContentAlignment.MiddleCenter;
            lblSiresa.Size = new Size(600, 40);
            lblSiresa.Location = new Point(0, panelLogo.Bottom + 10);

            label2.Text = "Usuario:";
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(150, 200);

            txtUsuario.Size = new Size(300, 25);
            txtUsuario.Location = new Point(150, 225);

            label3.Text = "Contraseña:";
            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Location = new Point(150, 260);


            txtContraseña.Size = new Size(300, 25);
            txtContraseña.Location = new Point(150, 285);

            picCaptcha.Size = new Size(150, 40);
            picCaptcha.Location = new Point(150, 320);
            picCaptcha.BackColor = Color.LightGray;

            txtCaptcha.Size = new Size(120, 25);
            txtCaptcha.Location = new Point(280, 330);

            btnRefresh.Size = new Size(30, 30);
            btnRefresh.Location = new Point(410, 330);


            btnLogin.Text = "Ingresar al Sistema";
            btnLogin.BackColor = Color.FromArgb(192, 0, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.Size = new Size(300, 40);
            btnLogin.Location = new Point(150, 380);


            try
            {
                Conexion conexion = new Conexion();
                SqlConnection conn = conexion.AbrirConexion();

                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("✅ Conectado a la base: " + conn.Database, "Conexión Exitosa");
                }

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al conectar: " + ex.Message, "Error");
            }
        }

        private void txtCaptcha_TextChanged(object sender, EventArgs e)
        {

        }

        private void picCaptcha_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCiudadano_Click(object sender, EventArgs e)
        {
            frmDenunciaPublica frm = new frmDenunciaPublica();
            frm.ShowDialog();
        }
    }
}

