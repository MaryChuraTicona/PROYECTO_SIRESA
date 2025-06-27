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
    public partial class frmCriterioBase : Form
    {
        private criterioCN criterioCN = new criterioCN();
        private int? criterioSeleccionadoID = null;
        public frmCriterioBase()
        {
            InitializeComponent();
            cmbNivelRiesgo.Items.AddRange(new string[] { "Bajo", "Medio", "Alto" });
            chkActivo.Checked = true;
            CargarCriterios();
        }

        private void frmCriterioBase_Load(object sender, EventArgs e)
        {

        }

        private void CargarCriterios()
        {
            dgvCriterios.Columns.Clear();
            dgvCriterios.Rows.Clear();

            dgvCriterios.Columns.Add("ID", "ID");
            dgvCriterios.Columns.Add("Nombre", "Nombre");
            dgvCriterios.Columns.Add("NivelRiesgo", "Nivel de Riesgo");
            dgvCriterios.Columns.Add("Activo", "Activo");

            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "Editar";
            btnEditar.HeaderText = "Acción";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvCriterios.Columns.Add(btnEditar);

            var lista = criterioCN.ObtenerCriterios();
            foreach (var c in lista)
            {
                dgvCriterios.Rows.Add(c.CriterioID, c.Nombre, c.NivelRiesgo, c.Activo ? "Sí" : "No");
            }
        }

        private void dgvCriterios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCriterios.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                criterioSeleccionadoID = Convert.ToInt32(dgvCriterios.Rows[e.RowIndex].Cells["ID"].Value);
                txtNombre.Text = dgvCriterios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                cmbNivelRiesgo.Text = dgvCriterios.Rows[e.RowIndex].Cells["NivelRiesgo"].Value.ToString();
                chkActivo.Checked = dgvCriterios.Rows[e.RowIndex].Cells["Activo"].Value.ToString() == "Sí";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbNivelRiesgo.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            CriterioBase c = new CriterioBase
            {
                Nombre = txtNombre.Text.Trim(),
                NivelRiesgo = cmbNivelRiesgo.SelectedItem.ToString(),
                Activo = chkActivo.Checked
            };

            if (criterioSeleccionadoID.HasValue)
            {
                c.CriterioID = criterioSeleccionadoID.Value;
                if (criterioCN.EditarCriterio(c))
                    MessageBox.Show("Criterio actualizado.");
                else
                    MessageBox.Show("No se pudo actualizar.");
            }
            else
            {
                if (criterioCN.RegistrarCriterio(c))
                    MessageBox.Show("Criterio registrado.");
                else
                    MessageBox.Show("Error al registrar.");
            }

            criterioSeleccionadoID = null;
            LimpiarCampos();
            CargarCriterios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            criterioSeleccionadoID = null;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            cmbNivelRiesgo.SelectedIndex = -1;
            chkActivo.Checked = true;
        }
    }
}
