using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;


using CapaEntidad;
using System.IO;
using System.Reflection.Emit;

namespace CapaUI
{
    public partial class frmEstablecimientos : Form
    {
        private establecimientoCN establecimientoCN = new establecimientoCN();
        private int usuarioActualID;
        public frmEstablecimientos(int usuarioID)
        {
            InitializeComponent();
            usuarioActualID = usuarioID;
            diseno();
        }

        private async void txtRUC_Leave(object sender, EventArgs e)
        {
            string ruc = txtRUC.Text.Trim();

            if (ruc.Length != 11 || !ruc.All(char.IsDigit))
            {
                MessageBox.Show("El RUC debe tener 11 dígitos numéricos.");
                return;
            }

            string url = $"https://api.apis.net.pe/v2/sunat/ruc?numero={ruc}";
            string token = "apis-token-16368.3SUpi4VCNbmVKiuEPOcueOywc4hyIVBP";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(json);

                        txtRazonSocial.Text = data["razonSocial"]?.ToString() ?? "";
                        txtNombreComercial.Text = data["nombreComercial"]?.ToString() ?? "";
                        txtDireccion.Text = data["direccion"]?.ToString() ?? "";
                        txtEstado.Text = data["estado"]?.ToString() ?? "";
                        txtCondicion.Text = data["condicion"]?.ToString() ?? "";
                        txtUbigeo.Text = data["ubigeo"]?.ToString() ?? "";
                        txtDepartamento.Text = data["departamento"]?.ToString() ?? "";
                        txtProvincia.Text = data["provincia"]?.ToString() ?? "";
                        txtDistrito.Text = data["distrito"]?.ToString() ?? "";


                    }
                    else
                    {
                        MessageBox.Show("No se encontró información del RUC.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la API: " + ex.Message);
                }
            }
        }


        private async void frmEstablecimientos_Load(object sender, EventArgs e)
        {
            cmbEstadoSanitario.Items.AddRange(new[] { "Bueno", "Regular", "Deficiente" });
            cmbTipoNegocio.Items.AddRange(new[] { "Restaurante", "Bodega", "Farmacia", "Otro" });
            CargarEstablecimientos();
            CargarEstablecimientoss(false);

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                if (c is TextBox || c is ComboBox)
                    c.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRUC.Text) || txtRUC.Text.Length != 11)
            {
                MessageBox.Show("Debe ingresar un RUC válido (11 dígitos).");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("La Razón Social y la Dirección son obligatorias.");
                return;
            }

            if (establecimientoCN.ExisteRUC(txtRUC.Text.Trim()))
            {
                MessageBox.Show("Este RUC ya está registrado. No se puede duplicar.");
                return;
            }

            Establecimiento est = new Establecimiento
            {
                RUC = txtRUC.Text.Trim(),
                RazonSocial = txtRazonSocial.Text.Trim(),
                NombreComercial = txtNombreComercial.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EstadoContribuyente = txtEstado.Text.Trim(),
                CondicionContribuyente = txtCondicion.Text.Trim(),
                Ubigeo = txtUbigeo.Text.Trim(),
                TipoNegocio = cmbTipoNegocio.Text,
                EstadoSanitario = cmbEstadoSanitario.Text,
                FechaRegistro = DateTime.Now,
                UsuarioRegistroID = usuarioActualID 
            };

            bool registrado = establecimientoCN.Registrar(est);

            if (registrado)
            {
                MessageBox.Show("Establecimiento registrado correctamente.");
                LimpiarCampos();
                CargarEstablecimientos(); 
            }
            else
            {
                MessageBox.Show("Error al registrar el establecimiento.");
            }
        }

        private void LimpiarCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) c.Text = "";
                if (c is ComboBox) ((ComboBox)c).SelectedIndex = -1;
            }
        }
        private void CargarEstablecimientos()
        {
            try
            {
                dgvEstablecimientos.DataSource = null;
                var lista = establecimientoCN.Listar();
                dgvEstablecimientos.DataSource = lista;

                dgvEstablecimientos.Columns["EstablecimientoID"].Visible = false;
                dgvEstablecimientos.Columns["UsuarioRegistroID"].Visible = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay registros para mostrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        private void dgvEstablecimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEstablecimientos.Rows[e.RowIndex];

                txtRUC.Text = row.Cells["RUC"].Value.ToString();
                txtRazonSocial.Text = row.Cells["RazonSocial"].Value.ToString();
                txtNombreComercial.Text = row.Cells["NombreComercial"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtEstado.Text = row.Cells["EstadoContribuyente"].Value.ToString();
                txtCondicion.Text = row.Cells["CondicionContribuyente"].Value.ToString();
                txtUbigeo.Text = row.Cells["Ubigeo"].Value.ToString();
                cmbTipoNegocio.Text = row.Cells["TipoNegocio"].Value.ToString();
               
                cmbEstadoSanitario.Text = row.Cells["EstadoSanitario"].Value.ToString();
            }
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Seleccione un establecimiento para inactivar.");
                return;
            }

            if (MessageBox.Show("¿Está seguro de inactivar este establecimiento?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool inactivado = establecimientoCN.Inactivar(txtRUC.Text.Trim());
                if (inactivado)
                {
                    MessageBox.Show("Establecimiento inactivado correctamente.");
                    CargarEstablecimientos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al inactivar el establecimiento.");
                }
            }
        }

        //lista de inactivos mostrar
        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarEstablecimientoss(chkMostrarInactivos.Checked);
        }
        private void CargarEstablecimientoss(bool mostrarInactivos = false)
        {
            try
            {
                dgvEstablecimientos.DataSource = null;

                var lista = establecimientoCN.Listar(mostrarInactivos);

                dgvEstablecimientos.DataSource = lista;

                // Ocultar columnas no necesarias
                dgvEstablecimientos.Columns["EstablecimientoID"].Visible = false;
                dgvEstablecimientos.Columns["UsuarioRegistroID"].Visible = false;

                // Configurar columna Activo como CheckBox
                if (dgvEstablecimientos.Columns["Activo"] != null)
                {
                    dgvEstablecimientos.Columns["Activo"].ReadOnly = true;
                    dgvEstablecimientos.Columns["Activo"].HeaderText = "Activo";
                    dgvEstablecimientos.Columns["Activo"].CellTemplate = new DataGridViewCheckBoxCell();
                }

                // Ajustes generales
                dgvEstablecimientos.ReadOnly = true;
                dgvEstablecimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEstablecimientos.MultiSelect = false;
                dgvEstablecimientos.AllowUserToAddRows = false;
                dgvEstablecimientos.AllowUserToDeleteRows = false;

                if (lista.Count == 0)
                {
                    MessageBox.Show("No hay registros para mostrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        private void diseno()
        {

            // chkMostrarInactivos
            chkMostrarInactivos.Text = "Mostrar Todos";
            chkMostrarInactivos.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chkMostrarInactivos.ForeColor = Color.DarkRed;
            chkMostrarInactivos.Location = new Point(730, 310);
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.BackColor = Color.WhiteSmoke;


            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkRed;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 40;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Padding = new Padding(20, 0, 0, 0);


            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label1.Location = new Point(20, 50);
            txtRUC.Location = new Point(130, 48);
            txtRUC.Width = 150;

            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(20, 90);
            txtRazonSocial.Location = new Point(130, 88);
            txtRazonSocial.Width = 250;

            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Location = new Point(420, 90);
            txtNombreComercial.Location = new Point(550, 88);
            txtNombreComercial.Width = 200;

            label4.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label4.Location = new Point(20, 130);
            txtDireccion.Location = new Point(130, 128);
            txtDireccion.Width = 400;

            label13.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label13.Location = new Point(20, 170);
            txtDepartamento.Location = new Point(130, 168);
            txtDepartamento.Width = 150;

            label12.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label12.Location = new Point(300, 170);
            txtProvincia.Location = new Point(380, 168);
            txtProvincia.Width = 150;

            label11.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label11.Location = new Point(550, 170);
            txtDistrito.Location = new Point(620, 168);
            txtDistrito.Width = 150;

            label5.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label5.Location = new Point(20, 210);
            txtEstado.Location = new Point(180, 208);
            txtEstado.Width = 150;

            label6.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label6.Location = new Point(350, 210);
            txtCondicion.Location = new Point(450, 208);
            txtCondicion.Width = 150;

            label7.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label7.Location = new Point(620, 210);
            txtUbigeo.Location = new Point(700, 208);
            txtUbigeo.Width = 100;

            label8.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label8.Location = new Point(20, 250);
            cmbTipoNegocio.Location = new Point(150, 248);
            cmbTipoNegocio.Width = 200;

            label10.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label10.Location = new Point(400, 250);
            cmbEstadoSanitario.Location = new Point(530, 248);
            cmbEstadoSanitario.Width = 200;

            // botones
            btnNuevo.Text = "Nuevo";
            btnNuevo.Size = new Size(120, 40);
            btnNuevo.BackColor = Color.Gray;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(20, 300);

            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(120, 40);
            btnGuardar.BackColor = Color.DarkRed;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(160, 300);

            btnEditar.Text = "Editar";
            btnEditar.Size = new Size(120, 40);
            btnEditar.BackColor = Color.Gray;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(300, 300);

            btnInactivar.Text = "Inactivar";
            btnInactivar.Size = new Size(120, 40);
            btnInactivar.BackColor = Color.DimGray;
            btnInactivar.ForeColor = Color.White;
            btnInactivar.Location = new Point(440, 300);

            btnActivar.Text = "Activar";
            btnActivar.Size = new Size(120, 40);
            btnActivar.BackColor = Color.SeaGreen;
            btnActivar.ForeColor = Color.White;
            btnActivar.Location = new Point(580, 300);
         
            // datagrid
            dgvEstablecimientos.Location = new Point(20, 360);
            dgvEstablecimientos.Size = new Size(1100, 300);
            dgvEstablecimientos.BackgroundColor = Color.White;
            dgvEstablecimientos.GridColor = Color.DarkRed;
            dgvEstablecimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvEstablecimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstablecimientos.EnableHeadersVisualStyles = false;
            dgvEstablecimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // formulario
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;


            dgvEstablecimientos.ReadOnly = true;
           

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Seleccione un establecimiento para activar.");
                return;
            }

            if (MessageBox.Show("¿Está seguro de activar este establecimiento?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool activado = establecimientoCN.Activar(txtRUC.Text.Trim());
                if (activado)
                {
                    MessageBox.Show("Establecimiento activado correctamente.");
                    CargarEstablecimientoss(chkMostrarInactivos.Checked);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al activar el establecimiento.");
                }
            }
        }
    }
}

