using CapaEntidad;
using CapaNegocios;
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
    public partial class frmCriteriosFiscalizacion : Form
    {
        private int fiscalizacionID;
        private criterioCN criterioCN = new criterioCN();
        private List<CriterioEvaluado> criterios;
        public frmCriteriosFiscalizacion(int fiscalizacionID)
        {
            InitializeComponent();
            this.fiscalizacionID = fiscalizacionID;
        }

        private void frmCriteriosFiscalizacion_Load(object sender, EventArgs e)
        {
            criterios = criterioCN.ObtenerCriteriosPrecargados();

            dgvCriterios.Rows.Clear();
            foreach (var c in criterios)
            {
                int index = dgvCriterios.Rows.Add();
                dgvCriterios.Rows[index].Cells["Numero"].Value = c.Numero;
                dgvCriterios.Rows[index].Cells["Criterio"].Value = c.Criterio;
                dgvCriterios.Rows[index].Cells["NivelRiesgo"].Value = c.NivelRiesgo;
                dgvCriterios.Rows[index].Cells["Resultado"].Value = "NO"; // default
                dgvCriterios.Rows[index].Cells["Observacion"].Value = "";
            }
        }

        private void btnGuardarCriterios_Click(object sender, EventArgs e)
        {
            List<CriterioEvaluado> evaluados = new List<CriterioEvaluado>();

            foreach (DataGridViewRow row in dgvCriterios.Rows)
            {
                if (row.IsNewRow) continue;

                var evaluado = new CriterioEvaluado
                {
                    FiscalizacionID = this.fiscalizacionID,
                    Numero = row.Cells["Numero"].Value?.ToString(),
                    Criterio = row.Cells["Criterio"].Value?.ToString(),
                    NivelRiesgo = row.Cells["NivelRiesgo"].Value?.ToString(),
                    Resultado = row.Cells["Resultado"].Value?.ToString(),
                    Observacion = row.Cells["Observacion"].Value?.ToString()
                };

                evaluados.Add(evaluado);
            }

            string resultado = criterioCN.RegistrarCriteriosEvaluados(evaluados);

            if (resultado == "OK")
                MessageBox.Show("Criterios evaluados registrados.");
            else
                MessageBox.Show("Error: " + resultado);
        }
    }
}

