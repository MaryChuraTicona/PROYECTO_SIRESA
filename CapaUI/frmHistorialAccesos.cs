using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaUI
{
    public partial class frmHistorialAccesos : Form
    {
        private cambioCN cambioNegocio = new cambioCN();
        public frmHistorialAccesos()
        {
            InitializeComponent();
        }

        private void frmHistorialAccesos_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarAccesos();
        }
        private void CargarUsuarios()
        {
           
            List<Usuario> usuarios = new usuario_CN().ObtenerUsuariosActivos();
            cmbUsuarios.DisplayMember = "NombreCompleto";
            cmbUsuarios.ValueMember = "UsuarioID";
            cmbUsuarios.DataSource = usuarios;
        }

        private void CargarAccesos()
        {
            int? usuarioID = cmbUsuarios.SelectedValue != null ? (int?)cmbUsuarios.SelectedValue : null;

            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : (DateTime?)null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date.AddDays(1).AddSeconds(-1) : (DateTime?)null;

            dgvAccesos.DataSource = cambioNegocio.ObtenerAccesos(usuarioID, desde, hasta);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAccesos();
        }
    }
}
