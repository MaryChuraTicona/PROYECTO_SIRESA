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
                Conexion conexion = new Conexion();
                SqlConnection conn = conexion.AbrirConexion();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show(" Conexión exitosa con Azure SQL.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Aquí iría tu lógica de validación de usuario y contraseña
            if (IsValidUser(txtUsuario.Text, txtContraseña.Text))
            {
                MessageBox.Show("Login exitoso!", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Abrir formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenerateCaptcha();
                txtCaptcha.Clear();
            }
        }
        private bool IsValidUser(string username, string password)
        {
            // Aquí implementarías la validación real contra tu base de datos
            // Esto es solo un ejemplo
            return username == "admin" && password == "12345";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
    }
}

