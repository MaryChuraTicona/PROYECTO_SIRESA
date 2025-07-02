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
using static System.Net.WebRequestMethods;
using iTextSharp.text;
using iTextSharp.text.pdf;




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

                var cumpleCheck = row.Cells["ColResultado"].Value as bool?;
                var cumple = (cumpleCheck.HasValue && cumpleCheck.Value) ? "SÍ" : "NO";


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
                string rutaActa = GenerarActaPDF(fiscalizacionID, criterios); 
                fiscalCN.MarcarFiscalizacionComoFinalizada(fiscalizacionID, rutaActa);

                MessageBox.Show("Inspección finalizada y acta generada correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar.");
            }
        }


        private string GenerarActaPDF(int fiscalizacionID, List<CriterioEvaluado> criterios)
        {
            string carpeta = @"C:\ActasFiscalizacion";
            Directory.CreateDirectory(carpeta);

            string nombreArchivo = $"Acta_{fiscalizacionID}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            string rutaFinal = Path.Combine(carpeta, nombreArchivo);

            using (var doc = new iTextSharp.text.Document())
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(rutaFinal, FileMode.Create));
                doc.Open();
                doc.Add(new iTextSharp.text.Paragraph($"Acta de Fiscalización ID {fiscalizacionID}"));
                doc.Add(new iTextSharp.text.Paragraph($"Fecha: {DateTime.Now}"));
                doc.Add(new iTextSharp.text.Paragraph($"--------------------"));

                foreach (var c in criterios)
                {
                    doc.Add(new iTextSharp.text.Paragraph($"Nro: {c.Numero} | {c.Criterio} | {c.NivelRiesgo} | Cumple: {c.Resultado}"));
                    if (!string.IsNullOrEmpty(c.Evidencia))
                        doc.Add(new iTextSharp.text.Paragraph($"Evidencia: {c.Evidencia}"));
                    doc.Add(new iTextSharp.text.Paragraph($"Observación: {c.Observacion}"));
                    doc.Add(new iTextSharp.text.Paragraph($"--------------------"));
                }

                doc.Close();
            }

            return rutaFinal;
        }

        private void dgvCriterios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
              
            }

        

        private void dgvCriterios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCriterios.Columns[e.ColumnIndex].Name == "ColEvidencia")
            {
                var valorCelda = dgvCriterios.Rows[e.RowIndex].Cells["ColEvidencia"].Value?.ToString();

                if (valorCelda == "Ver")
                {
                    string ruta = dgvCriterios.Rows[e.RowIndex].Cells["RutaEvidencia"].Value?.ToString();
                    if (!string.IsNullOrEmpty(ruta) && System.IO.File.Exists(ruta))
                    {
                        var visor = new frmImagen(ruta);
                        visor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No hay imagen para mostrar.");
                    }
                }
                else
                {
                    
                    using (var captura = new frmCapturaFiscalizacion())
                    {
                        captura.ShowDialog();

                        if (!string.IsNullOrEmpty(captura.RutaFotoFinal))
                        {
                            dgvCriterios.Rows[e.RowIndex].Cells["RutaEvidencia"].Value = captura.RutaFotoFinal;
                            dgvCriterios.Rows[e.RowIndex].Cells["ColEvidencia"].Value = "Ver";
                            MessageBox.Show("Imagen capturada y asignada al criterio.");
                        }
                    }
                }
            }
        }
    }
}

