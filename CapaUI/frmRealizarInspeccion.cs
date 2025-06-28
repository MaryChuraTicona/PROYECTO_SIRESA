using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaUI
{
    public partial class frmRealizarInspeccion : Form
    {
        private int fiscalizacionID;
        private int empleadoID;
        private fiscalizacionCN fiscalCN = new fiscalizacionCN();
        private establecimientoCN estCN = new establecimientoCN();
        private criterioCN criterioCN = new criterioCN();
        private empleadoCN empleadoCN = new empleadoCN();
        private Fiscalizacion fiscal;
        public frmRealizarInspeccion(int fiscalizacionID, int empleadoID)
        {
            InitializeComponent();

            this.fiscalizacionID = fiscalizacionID;
            this.empleadoID = empleadoID;
        }

        private void frmRealizarInspeccion_Load(object sender, EventArgs e)
        {
            fiscal = fiscalCN.ObtenerFiscalizacionPorID(fiscalizacionID);
            if (fiscal == null)
            {
                MessageBox.Show("No se encontró la fiscalización.");
                this.Close();
                return;
            }

            Establecimiento  est = estCN.ObtenerEstablecimientoPorID(fiscal.EstablecimientoID);


            Empleado inspector = empleadoCN.ObtenerEmpleados().FirstOrDefault(emp => emp.EmpleadoID == empleadoID);

            txtRazonSocial.Text = est?.RazonSocial ?? "";
            txtNombreComercial.Text = est?.NombreComercial ?? "";
            txtRUC.Text = est?.RUC ?? "";
            txtDireccion.Text = est?.Direccion ?? "";

            txtTipoFiscalizacion.Text = fiscal.TipoFiscalizacion;
            txtFechaProgramada.Text = fiscal.FechaFiscalizacion.ToShortDateString();
            txtInspector.Text = inspector?.NombreCompleto ?? "";

            CargarCriterios();
        }

        private void CargarCriterios()
        {
            var criterios = criterioCN.ObtenerCriteriosPrecargados();
            dgvCriterios.Rows.Clear();

          
            if (!dgvCriterios.Columns.Contains("RutaEvidencia"))
            {
                DataGridViewTextBoxColumn rutaCol = new DataGridViewTextBoxColumn();
                rutaCol.Name = "RutaEvidencia";
                rutaCol.HeaderText = "Ruta Evidencia";
                rutaCol.Visible = false;
                dgvCriterios.Columns.Add(rutaCol);
            }

            foreach (var c in criterios)
            {
                dgvCriterios.Rows.Add(c.CriterioID.ToString(), c.Nombre, c.NivelRiesgo, false, "📸", "");

            }
        }

        private void btnGuardarInspeccion_Click(object sender, EventArgs e)
        {
            List<CriterioEvaluado> criterios = new List<CriterioEvaluado>();

            foreach (DataGridViewRow row in dgvCriterios.Rows)
            {
                if (row.IsNewRow) continue;

                var cumple = Convert.ToBoolean(row.Cells["ColCumple"].Value) ? "SÍ" : "NO";
                var rutaEvidencia = row.Cells["RutaEvidencia"]?.Value?.ToString() ?? "";

                criterios.Add(new CriterioEvaluado
                {
                    FiscalizacionID = fiscalizacionID,
                    Numero = row.Cells["ColNumero"].Value.ToString(),
                    Criterio = row.Cells["ColCriterio"].Value.ToString(),
                    NivelRiesgo = row.Cells["ColRiesgo"].Value.ToString(),
                    Resultado = cumple,
                    Observacion = row.Cells["ColObservacion"].Value?.ToString(),
                    Evidencia = rutaEvidencia
                });
            }

            var resultado = criterioCN.RegistrarCriteriosEvaluados(criterios);

            if (resultado == "OK")
            {
                fiscalCN.MarcarFiscalizacionComoFinalizada(fiscalizacionID);
                MessageBox.Show("Inspección registrada correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar.");
            }
        }

        private void dgvCriterios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCriterios.Columns[e.ColumnIndex].Name == "ColEvidencia")
            {
                CapturarImagenDesdeCelular(e.RowIndex);
            }
        }

        private void CapturarImagenDesdeCelular(int fila)
        {
            try
            {
                string ipCamUrl = "http://192.168.1.23:4747/shot.jpg";

                using (WebClient client = new WebClient())
                {
                    byte[] data = client.DownloadData(ipCamUrl);

                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        Image img = Image.FromStream(ms);

                        string numero = dgvCriterios.Rows[fila].Cells["ColNumero"].Value?.ToString() ?? "Criterio";
                        string carpeta = @"C:\\Evidencias";
                        if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                        string ruta = Path.Combine(carpeta, $"Evidencia_{numero}_{DateTime.Now.Ticks}.jpg");
                        img.Save(ruta);

                        MessageBox.Show("Imagen capturada y guardada correctamente.", "Captura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCriterios.Rows[fila].Cells["RutaEvidencia"].Value = ruta;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}

