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
    public partial class frmAsignarFiscalizaciones : Form
    {
        public frmAsignarFiscalizaciones()
        {
            InitializeComponent();
        }

        private void frmAsignarFiscalizaciones_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }
    }
}
