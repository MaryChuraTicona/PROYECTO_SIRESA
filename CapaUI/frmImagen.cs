using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUI
{
    public partial class frmImagen : Form
    {
        public frmImagen(string ruta)
        {
            InitializeComponent();
            picVisor.SizeMode = PictureBoxSizeMode.Zoom;
            picVisor.Image = Image.FromFile(ruta);
        }

        private void frmImagen_Load(object sender, EventArgs e)
        {

        }
    }
}
