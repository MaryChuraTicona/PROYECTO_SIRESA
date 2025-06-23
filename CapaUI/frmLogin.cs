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

            picCaptcha.Image = bmp; // Usa picCaptcha en lugar de captchaPictureBox
        }
        
        private void PROBAR_Click(object sender, EventArgs e)
        {
            try
            {
               // Conexion conexion = new Conexion();
                //SqlConnection conn = conexion.AbrirConexion();

                //if (conn.State == System.Data.ConnectionState.Open)
               // {
                 //   MessageBox.Show(" Conexión exitosa con Azure SQL.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validar CAPTCHA primero - Usa txtCaptcha en lugar de captchaTextBox
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

                frmPrincipal principal = new frmPrincipal(usuario);  // Se abre el MDI con el usuario logueado
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
    }
}

