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
    public partial class frmFiscalizaciones : Form
    {
     
        private Usuario usuarioActual;
        private fiscalizacionCN fiscalCN = new fiscalizacionCN();
        private List<Fiscalizacion> listaFiscalizaciones;



        public frmFiscalizaciones(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
            CargarFiscalizaciones();
        }

     

        private void CargarFiscalizaciones()
        {
          
            listaFiscalizaciones = fiscalCN.ObtenerFiscalizaciones();

            dgvFiscalizaciones.Rows.Clear();

            foreach (var f in listaFiscalizaciones)
            {
                dgvFiscalizaciones.Rows.Add(new object[]
                {
                    f.FiscalizacionID,
                    f.NombreEstablecimiento,
                    f.FechaFiscalizacion.ToShortDateString(),
                    f.TipoFiscalizacion,
                    f.EstadoFiscalizacion,
                    f.ResultadoFiscalizacion,
                    "Editar",
                    "PDF"
                });
            }
        }

        private void frmFiscalizaciones_Load(object sender, EventArgs e)
        {
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            cmbEstadoFiltro.Items.AddRange(new string[] { "Todos", "Pendiente", "Programada", "Finalizada" });
            cmbEstadoFiltro.SelectedIndex = 0;
            cmbEstadoFiltro.SelectedIndexChanged += cmbEstadoFiltro_SelectedIndexChanged;

            DisenoFiscalizaciones();
        }

        private void btnNuevaFiscalizacion_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("El usuario no está inicializado. Cierre y vuelva a ingresar.");
                return;
            }
            frmNuevaFiscalizacion frm = new frmNuevaFiscalizacion(usuarioActual);
            
            frm.ShowDialog();
            CargarFiscalizaciones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();
            var resultados = listaFiscalizaciones
                .Where(f => f.NombreEstablecimiento.ToLower().Contains(filtro)
                         || f.TipoFiscalizacion.ToLower().Contains(filtro))
                .ToList();

            dgvFiscalizaciones.Rows.Clear();

            foreach (var f in resultados)
            {
                dgvFiscalizaciones.Rows.Add(new object[]
                {
                    f.FiscalizacionID,
                    f.NombreEstablecimiento,
                    f.FechaFiscalizacion.ToShortDateString(),
                    f.TipoFiscalizacion,
                    f.EstadoFiscalizacion,
                    f.ResultadoFiscalizacion,
                    "Editar",
                    "PDF"
                });
            }
        }

        private void dgvFiscalizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int fiscalizacionID = Convert.ToInt32(dgvFiscalizaciones.Rows[e.RowIndex].Cells[0].Value);

                string accion = dgvFiscalizaciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                string estado = dgvFiscalizaciones.Rows[e.RowIndex].Cells[4].Value?.ToString();


                if (accion == "Editar")
                {
                    if (estado != "Pendiente")
                    {
                        MessageBox.Show("Solo se pueden editar fiscalizaciones pendientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    frmNuevaFiscalizacion frm = new frmNuevaFiscalizacion(fiscalizacionID, usuarioActual);
                    frm.ShowDialog();
                    CargarFiscalizaciones();
                }
                else if (accion == "Ver")
                {
                    frmDetalleFiscalizacion frm = new frmDetalleFiscalizacion(fiscalizacionID);
                    frm.ShowDialog();
                }
                else if (accion == "PDF")
                {
                    if (estado == "Pendiente")
                    {
                        MessageBox.Show("Solo puede generar PDF si la fiscalización ya fue ejecutada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    GenerarPDF(fiscalizacionID);
                }
            }
        }
        private void GenerarPDF(int fiscalizacionID)
        {
            MessageBox.Show($"(Aquí se generará el PDF para Fiscalización #{fiscalizacionID})");
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = cmbEstadoFiltro.SelectedItem.ToString();

            var resultados = estado == "Todos"
                ? listaFiscalizaciones
                : listaFiscalizaciones.Where(f => f.EstadoFiscalizacion.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();

            dgvFiscalizaciones.Rows.Clear();

            foreach (var f in resultados)
            {
                dgvFiscalizaciones.Rows.Add(new object[]
                {
            f.FiscalizacionID,
            f.NombreEstablecimiento,
            f.FechaFiscalizacion.ToShortDateString(),
            f.TipoFiscalizacion,
            f.EstadoFiscalizacion,
            f.ResultadoFiscalizacion,
            "Editar",
            "PDF"
                });
            }
        }

        private void DisenoFiscalizaciones()
        {
            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Gestión de Fiscalizaciones";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkRed;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 40;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Padding = new Padding(20, 0, 0, 0);
            this.Controls.Add(lblTitulo);

            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Buscar
            label2.Text = "Buscar:";
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(30, 60);

            txtBuscar.Location = new Point(100, 58);
            txtBuscar.Width = 250;

            // Filtro estado
            cmbEstadoFiltro.Location = new Point(370, 58);
            cmbEstadoFiltro.Width = 150;

            // Botón Nueva
            btnNuevaFiscalizacion.Text = "Nueva";
            btnNuevaFiscalizacion.Size = new Size(120, 40);
            btnNuevaFiscalizacion.BackColor = Color.DarkRed;
            btnNuevaFiscalizacion.ForeColor = Color.White;
            btnNuevaFiscalizacion.FlatStyle = FlatStyle.Flat;
            btnNuevaFiscalizacion.Location = new Point(550, 55);

            // DataGrid
            dgvFiscalizaciones.Location = new Point(30, 120);
            dgvFiscalizaciones.Width = this.ClientSize.Width - 60;
            dgvFiscalizaciones.Height = this.ClientSize.Height - 180;
            dgvFiscalizaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvFiscalizaciones.BackgroundColor = Color.White;
            dgvFiscalizaciones.GridColor = Color.DarkRed;
            dgvFiscalizaciones.EnableHeadersVisualStyles = false;
            dgvFiscalizaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvFiscalizaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFiscalizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajustes de columnas manuales
            if (dgvFiscalizaciones.Columns["FiscalizacionID"] != null)
                dgvFiscalizaciones.Columns["FiscalizacionID"].Width = 50;

            if (dgvFiscalizaciones.Columns["NombreEstablecimiento"] != null)
                dgvFiscalizaciones.Columns["NombreEstablecimiento"].Width = 300;

        }

    }
}
