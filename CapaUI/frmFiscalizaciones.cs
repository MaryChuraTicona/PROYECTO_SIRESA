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

            MessageBox.Show("Formulario CARGADO correctamente.");
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
    }
}
