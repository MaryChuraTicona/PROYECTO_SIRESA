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
            this.IsMdiContainer = true;
           


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

        private void MostrarFormulario(Form formularioHijo)
        {
            // Cierra formularios anteriores
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            formularioHijo.MdiParent = this;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEmpleados());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }

        private void btnEstablecimiento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEstablecimientos(usuarioActual.UsuarioID));
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAsignarFiscalizaciones());
        }

        private void btnFiscalizacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAsignarFiscalizaciones());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void btnDenuncia_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}

