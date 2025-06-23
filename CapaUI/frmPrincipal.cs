using CapaEntidad;
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

namespace CapaUI
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuarioActual;
        public frmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Bienvenido: " + usuarioActual.NombreCompleto;

            // CONTROL DE ACCESOS SEGÚN ROL
            switch (usuarioActual.RolID)
            {
                case 1: // Administrador
                        // Acceso total
                    break;

                case 2: // Inspector
                    btnUsuarios.Enabled = false;
                    btnReportes.Enabled = false;
                    btnAsignarFiscalizaciones.Enabled = false;
                    break;

                case 3: // Supervisor
                    btnUsuarios.Enabled = false;
                    break;

                case 4: // Ciudadano
                    btnUsuarios.Enabled = false;
                    btnFiscalizaciones.Enabled = false;
                    btnReportes.Enabled = false;
                    btnAsignarFiscalizaciones.Enabled = false;
                    break;
            }
        }

        private void AbrirFormulario(Form formHijo)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == formHijo.GetType())
                {
                    form.Activate();
                    return;
                }
            }

            formHijo.MdiParent = this;
            formHijo.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }

        private void btnFiscalizaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmFiscalizaciones());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void btnAsignarFiscalizaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAsignarFiscalizaciones());
        }

        private void btnEstablecimientos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEstablecimientos());
        }
    }
}

