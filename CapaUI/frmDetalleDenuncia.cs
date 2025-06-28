using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using System.IO;


namespace CapaUI
{
    public partial class frmDetalleDenuncia : Form
    {
        private Denuncia denunciaSeleccionada;
        private Usuario usuarioActual;
        private denunciaCN denunciaCN = new denunciaCN();
        public frmDetalleDenuncia(Denuncia denuncia, Usuario usuario)
        {
            InitializeComponent();
            denunciaSeleccionada = denuncia;
            usuarioActual = usuario;
            
       
        }

       

        private void frmDetalleDenuncia_Load(object sender, EventArgs e)
        {
            this.Text = "Detalle de Denuncia";
            lblTitulo.Text = denunciaSeleccionada.Estado == "Pendiente"
                ? "RESPUESTA A DENUNCIA PENDIENTE"
                : "DETALLE DE DENUNCIA ATENDIDA";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Maroon;

            MostrarDatos();
        }
        private void MostrarDatos()
        {
            lblDNI.Text = "DNI: " + denunciaSeleccionada.DNI;
            lblNombres.Text = "Nombres: " + denunciaSeleccionada.Nombres;
            lblCorreo.Text = "Correo: " + denunciaSeleccionada.Correo;
            lblRUC.Text = "RUC: " + denunciaSeleccionada.RUC;
            lblEstablecimiento.Text = "Establecimiento: " + denunciaSeleccionada.NombreEstablecimiento;
            lblDireccionEstablecimiento.Text = "Dirección: " + denunciaSeleccionada.DireccionEstablecimiento;
            txtDescripcion.Text = denunciaSeleccionada.Descripcion;
            txtRespuesta.Text = denunciaSeleccionada.Respuesta ?? "";

            if (File.Exists(denunciaSeleccionada.RutaImagen))
            {
                picEvidencia.Image = Image.FromFile(denunciaSeleccionada.RutaImagen);
                picEvidencia.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picEvidencia.Image = null;
            }

           
            bool pendiente = denunciaSeleccionada.Estado == "Pendiente";
            btnGuardarRespuesta.Enabled = pendiente;
            btnEnviarCorreo.Enabled = pendiente && !string.IsNullOrWhiteSpace(denunciaSeleccionada.Correo);
            txtRespuesta.Enabled = pendiente;
        }
        private void btnGuardarRespuesta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("Debe ingresar la respuesta antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de guardar la respuesta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string resultado = denunciaCN.ResponderDenuncia(
                denunciaSeleccionada.DenunciaID,
                usuarioActual.UsuarioID,
                txtRespuesta.Text,
                "Atendida"
            );

            if (resultado == "ok")
            {
                MessageBox.Show("Respuesta guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("Debe ingresar la respuesta antes de enviar correo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(denunciaSeleccionada.Correo))
            {
                MessageBox.Show("No hay correo disponible para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var mail = new MailMessage();
                mail.To.Add(denunciaSeleccionada.Correo);
                mail.Subject = "Respuesta a su denuncia - SIRESA";
                mail.Body = $@"
                Estimado/a {denunciaSeleccionada.Nombres},

                Su denuncia ha sido atendida:

                Respuesta: {txtRespuesta.Text}

                Gracias por colaborar con la vigilancia sanitaria.

                Atentamente,
                SIRESA
                ";
                mail.IsBodyHtml = false;
                mail.From = new MailAddress("mc2019065163@virtual.upt.pe", "SIRESA");

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("mc2019065163@virtual.upt.pe", "xxgvahsbpfqzypvb\r\n")
                };

                smtp.Send(mail);
                MessageBox.Show("Correo enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                string resultado = denunciaCN.ResponderDenuncia(
                    denunciaSeleccionada.DenunciaID,
                    usuarioActual.UsuarioID,
                    txtRespuesta.Text,
                    "Atendida"
                );

                if (resultado != "ok")
                {
                    MessageBox.Show("Error al actualizar la denuncia: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

