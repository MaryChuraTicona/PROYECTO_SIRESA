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
                UsuarioRegistroID = usuarioActualID // este ID debe llegarte del frmPrincipal
            };

            bool registrado = establecimientoCN.Registrar(est);

            if (registrado)
            {
                MessageBox.Show("Establecimiento registrado correctamente.");
                LimpiarCampos();
                CargarEstablecimientos(); // Recarga el DataGridView
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
            dgvEstablecimientos.DataSource = null;
            dgvEstablecimientos.DataSource = establecimientoCN.Listar();

            // Opcional: ocultar columnas internas
            dgvEstablecimientos.Columns["EstablecimientoID"].Visible = false;
            dgvEstablecimientos.Columns["UsuarioRegistroID"].Visible = false;
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

       
        }


}

