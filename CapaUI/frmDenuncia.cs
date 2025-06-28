using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaUI
{
    public partial class frmDenuncia : Form
    {
        private denunciaCN denunciaCN = new denunciaCN();
        private List<Denuncia> listaDenuncias = new List<Denuncia>();
        private Denuncia denunciaSeleccionada;
        private Usuario usuarioActual;
        public frmDenuncia(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmDenuncia_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;


            cmbEstadoFiltro.Items.AddRange(new string[] { "Todos", "Pendiente", "Atendida", "Rechazada" });
            cmbEstadoFiltro.SelectedIndex = 0;
            
            CargarDenuncias("Pendiente");
            disenoDenuncia();

           
        }
        public void CargarDenuncias(string estado)
        {
            dgvDenuncias.Rows.Clear();
            listaDenuncias = denunciaCN.ObtenerDenuncias(estado);

            foreach (var d in listaDenuncias)
            {
                dgvDenuncias.Rows.Add(
            d.DenunciaID,
            d.DNI,
            d.Nombres,
            d.Correo,
            d.FechaRegistro,
            d.Estado,
            d.RUC,                         
            d.NombreEstablecimiento,       
            d.DireccionEstablecimiento       
        );
            }
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDenuncias(cmbEstadoFiltro.SelectedItem.ToString());
            
        }

        private void dgvDenuncias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDenuncias.Rows[e.RowIndex].Cells[0].Value);
                denunciaSeleccionada = listaDenuncias.FirstOrDefault(d => d.DenunciaID == id);

                if (denunciaSeleccionada != null)
                {
                    var detalle = new frmDetalleDenuncia(denunciaSeleccionada, usuarioActual);
                    detalle.ShowDialog();
                    CargarDenuncias(cmbEstadoFiltro.SelectedItem.ToString());
                }
            }
        }

        private void btnGuardarRespuesta_Click(object sender, EventArgs e)
        {
           
        }

       
        private void disenoDenuncia()
        {
            
            this.Text = "Gestión de Denuncias";

            Label lblTitulo = new Label();
            lblTitulo.Text = "GESTIÓN DE DENUNCIAS";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Maroon;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 20);
            this.Controls.Add(lblTitulo);

            
            dgvDenuncias.EnableHeadersVisualStyles = false;
            dgvDenuncias.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgvDenuncias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDenuncias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvDenuncias.DefaultCellStyle.SelectionBackColor = Color.LightSalmon;
            dgvDenuncias.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDenuncias.GridColor = Color.Maroon;
            dgvDenuncias.BorderStyle = BorderStyle.Fixed3D;
            dgvDenuncias.Size = new Size(1000, 400);
            dgvDenuncias.BorderStyle = BorderStyle.Fixed3D;

            cmbEstadoFiltro.Location = new Point(20, 80);
            cmbEstadoFiltro.Width = 120;

            
            lblFiltro.Text = "Filtro:";
            lblFiltro.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblFiltro.Location = new Point(850, 30);

            lblFiltro.AutoSize = true;
            this.Controls.Add(lblFiltro);

          
          

           
        }

        private void dgvDenuncias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDenuncias.Rows[e.RowIndex].Cells[0].Value);
                denunciaSeleccionada = listaDenuncias.FirstOrDefault(d => d.DenunciaID == id);

                if (denunciaSeleccionada != null)
                {
                    var detalle = new frmDetalleDenuncia(denunciaSeleccionada, usuarioActual);
                    detalle.ShowDialog();
                    CargarDenuncias(cmbEstadoFiltro.SelectedItem.ToString());




                }
            }
    }
    }
}
