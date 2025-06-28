using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using CapaNegocios;
using System.Text.RegularExpressions;
using System.IO;
using CapaEntidad;


namespace CapaUI
{
    public partial class frmDenunciaPublica : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice webcam;
        private Bitmap imagenCapturada;
        private string rutaImagenFinal = "";
        private frmDenuncia formularioPadre;
        public frmDenunciaPublica(frmDenuncia padre)
        {
            InitializeComponent();
            formularioPadre = padre;
            IniciarCamara();
        }

        public frmDenunciaPublica()
        {
            InitializeComponent();
            formularioPadre = null;
            IniciarCamara();
        }
        private void IniciarCamara()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (dispositivos.Count > 0)
            {
                webcam = new VideoCaptureDevice(dispositivos[0].MonikerString);
                webcam.NewFrame += new NewFrameEventHandler(Capturar);
                webcam.Start();
            }
            else
            {
                MessageBox.Show("No se detectó cámara conectada.");
            }
        }
        private void Capturar(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            picEvidencia.Image = frame;
        }

        private async void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                await AutocompletarDatosRENIEC(txtDNI.Text);
            }
        }

        private async Task AutocompletarDatosRENIEC(string dni)
        {
            string url = $"https://api.apis.net.pe/v2/reniec/dni?numero={dni}";
            string token = "Bearer apis-token-16356.Cza7kRgd2DHFq16BwThIrmxx8hrvOMme";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(json);

                        txtNombres.Text = $"{data["nombres"]} {data["apellidoPaterno"]} {data["apellidoMaterno"]}";
                    }
                    else
                    {
                        MessageBox.Show("DNI no encontrado en RENIEC.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar RENIEC: " + ex.Message);
                }
            }
        }

        private void frmDenunciaPublica_Load(object sender, EventArgs e)
        {

        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            if (picEvidencia.Image != null)
            {
                imagenCapturada = new Bitmap(picEvidencia.Image);

                string carpeta = Application.StartupPath + @"\evidencias\";
                Directory.CreateDirectory(carpeta);

                string nombreArchivo = $"denuncia_{DateTime.Now.Ticks}.jpg";
                rutaImagenFinal = carpeta + nombreArchivo;

                imagenCapturada.Save(rutaImagenFinal, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Foto capturada correctamente.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
          string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
          string.IsNullOrEmpty(rutaImagenFinal))
            {
                MessageBox.Show("Complete todos los campos requeridos y tome una foto.");
                return;
            }

            Denuncia denuncia = new Denuncia
            {
                DNI = txtDNI.Text,
                Nombres = txtNombres.Text,
                Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text,
                Descripcion = txtDescripcion.Text,
                RutaImagen = rutaImagenFinal,
                RUC = txtRUC.Text,
                NombreEstablecimiento = txtNombreEstablecimiento.Text,
                DireccionEstablecimiento = txtDireccionEstablecimiento.Text
            };

            var cn = new denunciaCN();
            string respuesta = cn.GuardarDenuncia(denuncia);

            if (respuesta == "ok")
            {
                MessageBox.Show("Denuncia registrada exitosamente.");
                formularioPadre?.CargarDenuncias("Pendiente");
                if (webcam != null && webcam.IsRunning)
                    webcam.SignalToStop();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la denuncia.");
            }
        }

        private void frmDenunciaPublica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam != null && webcam.IsRunning)
                webcam.SignalToStop();
        }

        private async void txtRUC_Leave(object sender, EventArgs e)
        {
            if (txtRUC.Text.Length == 11)
            {
                await AutocompletarDatosSUNAT(txtRUC.Text);
            }
        }
        private async Task AutocompletarDatosSUNAT(string ruc)
        {
            string url = $"https://api.apis.net.pe/v2/sunat/ruc?numero={ruc}";
            string token = "Bearer apis-token-16368.3SUpi4VCNbmVKiuEPOcueOywc4hyIVBP";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(json);

                        txtNombreEstablecimiento.Text = data["razonSocial"]?.ToString();
                        txtDireccionEstablecimiento.Text = data["direccion"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("RUC no encontrado en SUNAT.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar SUNAT: " + ex.Message);
                }
            }
        }


        private async void txtDNI_Leave_1(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                await AutocompletarDatosRENIEC(txtDNI.Text);
            }
        }
    }
}
