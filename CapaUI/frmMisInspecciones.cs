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
    public partial class frmMisInspecciones : Form
    {
        private Usuario usuarioActual;
        private fiscalizacionCN fiscalCN = new fiscalizacionCN();
        private empleadoCN empCN = new empleadoCN();
        private List<Fiscalizacion> misFiscalizaciones = new List<Fiscalizacion>();
        private int empleadoID;
        public frmMisInspecciones(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmMisInspecciones_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;

            disenoMisInspeciones();
          

            lblTitulo.Text = "Mis inspecciones asignadas";

            cmbFiltro.Items.AddRange(new string[] { "Todos", "Pendiente", "Programado", "Finalizado" });
            cmbFiltro.SelectedIndex = 0;

            Empleado emp = empCN.BuscarEmpleadoPorDNI(usuarioActual.DNI);
           


            if (emp != null)
            {
                empleadoID = emp.EmpleadoID;
                CargarMisFiscalizaciones();
            }
            else
            {
                MessageBox.Show("No se encontró un empleado vinculado al usuario actual.");
                this.BeginInvoke((MethodInvoker)delegate {
                    this.Close();
                });
            }
        }
        private void CargarMisFiscalizaciones()
        {
            dgvMisInspecciones.Rows.Clear();
            misFiscalizaciones = fiscalCN.ObtenerFiscalizacionesPorEmpleado(empleadoID);

            var filtroEstado = cmbFiltro.SelectedItem.ToString();

            var filtradas = misFiscalizaciones
                .Where(f => filtroEstado == "Todos" || f.EstadoFiscalizacion == filtroEstado)
                .ToList();

            foreach (var f in filtradas)
            {
                dgvMisInspecciones.Rows.Add(
                    f.FiscalizacionID,
                    f.NombreEstablecimiento,
                    f.FechaFiscalizacion.ToShortDateString(),
                    f.TipoFiscalizacion,
                    f.EstadoFiscalizacion,
                    "Ver"
                );
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarMisFiscalizaciones();
        }

        private void dgvMisInspecciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               
                if (dgvMisInspecciones.Columns[e.ColumnIndex].Name == "ColVer")
                {
                    int fiscalizacionID = Convert.ToInt32(dgvMisInspecciones.Rows[e.RowIndex].Cells["ColID"].Value);

                    string estado = dgvMisInspecciones.Rows[e.RowIndex].Cells["ColEstado"].Value.ToString();

                    if (estado == "Programado")
                    {
                        frmRealizarInspeccion frm = new frmRealizarInspeccion(fiscalizacionID, empleadoID);
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                    }
                    else
                    {
                        frmDetalleFiscalizacion frm = new frmDetalleFiscalizacion(fiscalizacionID);
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                    }
                }
          
                else if (dgvMisInspecciones.Columns[e.ColumnIndex].Name == "ColAccion")
                {
                    int fiscalizacionID = Convert.ToInt32(dgvMisInspecciones.Rows[e.RowIndex].Cells["ColID"].Value);
                    string estado = dgvMisInspecciones.Rows[e.RowIndex].Cells["ColEstado"].Value.ToString();

                    
                    if (estado == "Pendiente" || estado == "Programado")
                    {
                        frmRealizarInspeccion frm = new frmRealizarInspeccion(fiscalizacionID, empleadoID);
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Esta fiscalización ya está finalizada.", "Aviso");
                    }
                }
            }
        }

        private void disenoMisInspeciones() { 

                lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblTitulo.ForeColor = Color.Maroon;
                this.BackColor = Color.WhiteSmoke;  

                dgvMisInspecciones.EnableHeadersVisualStyles = false;
                dgvMisInspecciones.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
                dgvMisInspecciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvMisInspecciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvMisInspecciones.DefaultCellStyle.SelectionBackColor = Color.LightSalmon;
                dgvMisInspecciones.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvMisInspecciones.GridColor = Color.Maroon;
                dgvMisInspecciones.BorderStyle = BorderStyle.Fixed3D;
                dgvMisInspecciones.RowHeadersVisible = false;
                dgvMisInspecciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

       
    }