using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Text.RegularExpressions;

namespace CapaUI
{
    public partial class frmCapturaFiscalizacion : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice webcam;
        private Bitmap imagenCapturada;
        public string RutaFotoFinal { get; private set; }

        public frmCapturaFiscalizacion()
        {
            InitializeComponent();
        }

        private void frmCapturaFiscalizacion_Load(object sender, EventArgs e)
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
            picCaptura.Image = frame;
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            if (picCaptura.Image != null)
            {
                imagenCapturada = new Bitmap(picCaptura.Image);

                string carpeta = Application.StartupPath + @"\EvidenciasFiscalizacion\";
                Directory.CreateDirectory(carpeta);

                string nombreArchivo = $"fiscal_{DateTime.Now.Ticks}.jpg";
                RutaFotoFinal = Path.Combine(carpeta, nombreArchivo);

                imagenCapturada.Save(RutaFotoFinal, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Foto capturada correctamente.");
                this.Close();
            }
        }

        private void frmCapturaFiscalizacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webcam != null && webcam.IsRunning)
                webcam.SignalToStop();
        }
    }
}
