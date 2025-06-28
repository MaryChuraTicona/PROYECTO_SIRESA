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
            diseno();
            cmbNivelRiesgo.Items.AddRange(new string[] { "Bajo", "Medio", "Alto" });
            chkActivo.Checked = true;
            CargarCriterios();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill; 
           
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

            dgvCriterios.Columns["ID"].Width = 50;         
            dgvCriterios.Columns["Nombre"].Width = 350;
            dgvCriterios.Columns["NivelRiesgo"].Width = 100;
            dgvCriterios.Columns["Activo"].Width = 70;
           

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

        private void diseno()
        {
       
            Label lblTitulo = new Label();
            lblTitulo.Text = "Gestión de Criterios de Fiscalización";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkRed;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 40;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Padding = new Padding(20, 0, 0, 0);
            this.Controls.Add(lblTitulo);

            this.BackColor = Color.WhiteSmoke;

            

            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label1.Location = new Point(30, 60);
            txtNombre.Location = new Point(200, 58);
            txtNombre.Width = 400;

            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(30, 100);
            cmbNivelRiesgo.Location = new Point(200, 98);
            cmbNivelRiesgo.Width = 200;

            chkActivo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chkActivo.ForeColor = Color.DarkRed;
            chkActivo.Location = new Point(30, 140);


            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(120, 40);
            btnGuardar.BackColor = Color.DarkRed;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(200, 180);

            btnNuevo.Text = "Nuevo";
            btnNuevo.Size = new Size(120, 40);
            btnNuevo.BackColor = Color.Gray;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Location = new Point(340, 180);

            dgvCriterios.Dock = DockStyle.Bottom;
            dgvCriterios.Location = new Point(30, 240);
            dgvCriterios.Width = 1100;
            dgvCriterios.Height = 400;
            dgvCriterios.BackgroundColor = Color.White;
            dgvCriterios.GridColor = Color.DarkRed;
            dgvCriterios.EnableHeadersVisualStyles = false;
            dgvCriterios.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvCriterios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCriterios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(dgvCriterios);
            // Formulario general
            //this.BackColor = Color.WhiteSmoke;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.TopLevel = false;
            //this.Dock = DockStyle.Fill;
        }

    }
}
