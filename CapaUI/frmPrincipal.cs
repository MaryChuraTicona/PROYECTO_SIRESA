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
            MessageBox.Show("RolID actual: " + usuarioActual.RolID);


            btnEmpleados.Visible = false;
            btnUsuarios.Visible = false;
            btnEstablecimientos.Visible = false;
            btnFiscalizaciones.Visible = false;
            btnReportes.Visible = false;
            btnDenuncias.Visible = false;

            btnEmpleado.Visible = false;
            btnUsuario.Visible = false;
            btnEstablecimiento.Visible = false;
            btnFiscalizacion.Visible = false;
            btnReporte.Visible = false;
            btnDenuncia.Visible = false;
            btnCerrar.Visible = true; // Siempre debe estar visible
            btnMisFiscalizaciones.Visible = false;

            // Activar según Rol
            switch (usuarioActual.RolID)
            {
                case 1: // Administrador
                    btnEmpleados.Visible = true;
                    btnUsuarios.Visible = true;
                    btnEstablecimientos.Visible = true;
                    btnFiscalizaciones.Visible = true;
                    btnReportes.Visible = true;
                    btnDenuncias.Visible = true;

                    btnEmpleado.Visible = true;
                    btnUsuario.Visible = true;
                    btnEstablecimiento.Visible = true;
                    btnFiscalizacion.Visible = true;
                    btnReporte.Visible = true;
                    btnDenuncia.Visible = true;
                    break;

                case 2: // Inspector
                    btnMisFiscalizaciones.Visible = true;
                    btnDenuncia.Visible = true;
                    break;

                case 3: // Supervisor
                    btnEstablecimientos.Visible = true;
                    btnFiscalizaciones.Visible = true;
                    btnReportes.Visible = true;
                    btnDenuncias.Visible = true;

                    btnEstablecimiento.Visible = true;
                    btnFiscalizacion.Visible = true;
                    btnReporte.Visible = true;
                    btnDenuncia.Visible = true;
                    break;

                case 4: // Ciudadano
                    btnDenuncia.Visible = true;
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
            
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            formularioHijo.MdiParent = this;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.Show();
            formularioHijo.BringToFront();
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

       

        private void btnFiscalizacion_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new frmFiscalizaciones(usuarioActual));
        }

       
    

    private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void btnDenuncia_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmDenuncia(usuarioActual));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void btnMisFiscalizaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMisInspecciones(usuarioActual));
        }

        private void btnCriterios_Click(object sender, EventArgs e)
        {
            frmCriterioBase frm = new frmCriterioBase();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

