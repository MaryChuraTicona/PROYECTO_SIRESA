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
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            lblUsuario.Text = $"Bienvenido: {usuarioActual.NombreCompleto} | Rol: {ObtenerNombreRol(usuarioActual.RolID)} | {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblUsuario.ForeColor = Color.FromArgb(192, 0, 0);
            lblUsuario.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            panel3.BackColor = Color.LightGray;

            panel1.BackColor = Color.FromArgb(192, 0, 0);
            foreach (var b in panel1.Controls.OfType<Button>())
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            var listaBotones = new List<Button> {
        btnEmpleado, btnUsuario, btnEstablecimiento, btnCriterios, btnFiscalizacion,
        btnMisFiscalizaciones, btnReporte, btnDenuncia, btnHistorialAccesos, btnCerrar
    };

            foreach (var b in listaBotones)
                b.Visible = false;



            switch (usuarioActual.RolID)
            {
                case 1: // Administrador
                    btnEmpleado.Visible = true;
                    btnUsuario.Visible = true;
                    btnEstablecimiento.Visible = true;
                    btnCriterios.Visible = true;
                    btnFiscalizacion.Visible = true;
                    btnReporte.Visible = true;
                    btnDenuncia.Visible = true;
                    btnHistorialAccesos.Visible = true;
                    break;

                case 2: 
                    btnMisFiscalizaciones.Visible = true;
                    
                    break;

                case 3: 
                    btnFiscalizacion.Visible = true;
                    btnReporte.Visible = true;
                    btnDenuncia.Visible = true;
                    break;

                
            }

            btnCerrar.Visible = true;


            int posY = 80;
            int separacion = 5;

            foreach (var b in listaBotones.Where(x => x.Visible))
            {
                b.Top = posY;
                posY += b.Height + separacion;
            }

            MessageBox.Show($"Bienvenido {usuarioActual.NombreCompleto} como {ObtenerNombreRol(usuarioActual.RolID)}");
        }

        private string ObtenerNombreRol(int rolID)
        {
            switch (rolID)
            {
                case 1: return "Administrador";
                case 2: return "Inspector";
                case 3: return "Supervisor";
                case 4: return "Ciudadano";
                default: return "Desconocido";
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
            MostrarFormulario(new frmCriterioBase());
        }

        private void btnHistorialAccesos_Click(object sender, EventArgs e)
        {

        }
    }
}

