using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace CapaUI
{
    public partial class frmUsuarios : Form
    {
        private usuario_CN usuarioCN = new usuario_CN();
        private int idUsuarioSeleccionado = 0;
        public frmUsuarios()
        {
            InitializeComponent();
            CargarRoles();
            CargarUsuarios(); 
            txtNombreCompleto.ReadOnly = true;
        }
        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add(new KeyValuePair<int, string>(1, "Administrador"));
            cmbRol.Items.Add(new KeyValuePair<int, string>(2, "Inspector"));
            cmbRol.Items.Add(new KeyValuePair<int, string>(3, "Supervisor"));
            cmbRol.Items.Add(new KeyValuePair<int, string>(4, "Ciudadano"));

            cmbRol.DisplayMember = "Value";
            cmbRol.ValueMember = "Key";
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = usuarioCN.Listar();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un rol para el usuario.");
                return;
            }
            if (!Regex.IsMatch(txtDNI.Text, "^\\d{8}$"))
            {
                MessageBox.Show("DNI inválido. Debe tener exactamente 8 dígitos.");
                return;
            }

            // Validar que el DNI no se repita
            if (usuarioCN.Listar().Exists(u => u.DNI == txtDNI.Text.Trim() && u.UsuarioID != idUsuarioSeleccionado))
            {
                MessageBox.Show("El DNI ya está registrado en otro usuario.");
                return;
            }

            if (!Regex.IsMatch(txtCorreo.Text, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Correo electrónico inválido.");
                return;
            }

            if (!Regex.IsMatch(txtTelefono.Text, "^9\\d{8}$"))
            {
                MessageBox.Show("Teléfono inválido. Debe comenzar con 9 y tener 9 dígitos.");
                return;
            }
            if (usuarioCN.Listar().Exists(u => u.UsuarioNombre == txtUsuario.Text.Trim() && u.UsuarioID != idUsuarioSeleccionado))
            {
                MessageBox.Show("El nombre de usuario ya está en uso. Elija otro.");
                return;
            }
            

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("La clave no puede estar vacía.");
                return;
            }

            Usuario nuevo = new Usuario
            {
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                UsuarioNombre = txtUsuario.Text.Trim(),
                ClaveHash = Convert.ToBase64String(GenerarHash(txtClave.Text.Trim())),
                RolID = ((KeyValuePair<int, string>)cmbRol.SelectedItem).Key,
                Activo = chkActivo.Checked
            };

            if (usuarioCN.Registrar(nuevo))
            {
                MessageBox.Show("Usuario registrado con éxito.");
                CargarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un usuario para editar.");
                return;
            }
            if (cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un rol para el usuario.");
                return;
            }

            if (usuarioCN.Listar().Exists(u => u.UsuarioNombre == txtUsuario.Text.Trim() && u.UsuarioID != idUsuarioSeleccionado))
            {
                MessageBox.Show("El nombre de usuario ya está en uso. Elija otro.");
                return;
            }
            Usuario editado = new Usuario
            {
                UsuarioID = idUsuarioSeleccionado,
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                UsuarioNombre = txtUsuario.Text.Trim(),
                ClaveHash = Convert.ToBase64String(GenerarHash(txtClave.Text.Trim())),
                RolID = ((KeyValuePair<int, string>)cmbRol.SelectedItem).Key,
                Activo = chkActivo.Checked
            };

            if (usuarioCN.Editar(editado))
            {
                MessageBox.Show("Usuario actualizado.");
                CargarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al actualizar usuario.");
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["UsuarioID"].Value);
                txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtUsuario.Text = fila.Cells["UsuarioNombre"].Value.ToString();
                txtClave.Text = fila.Cells["ClaveHash"].Value.ToString();
                chkActivo.Checked = (bool)fila.Cells["Activo"].Value;

                int rolID = Convert.ToInt32(fila.Cells["RolID"].Value);
                foreach (var item in cmbRol.Items)
                {
                    if (((KeyValuePair<int, string>)item).Key == rolID)
                    {
                        cmbRol.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void Limpiar()
        {
            txtNombreCompleto.Text = "";
            txtDNI.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            cmbRol.SelectedIndex = -1;
            chkActivo.Checked = false;
            idUsuarioSeleccionado = 0;
        }

        private async void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("Ingrese un DNI válido de 8 dígitos.");
                return;
            }

            string dni = txtDNI.Text.Trim();
            string url = $"https://api.apis.net.pe/v2/reniec/dni?numero={dni}";
            string token = "apis-token-16238.tXsu3p4oFNvcBNEw8nRKdZkVPZkq16NK";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(result);

                        string nombres = data["nombres"]?.ToString();
                        string apePat = data["apellidoPaterno"]?.ToString();
                        string apeMat = data["apellidoMaterno"]?.ToString();

                        txtNombreCompleto.Text = $"{nombres} {apePat} {apeMat}";
                    }
                    else
                    {
                        MessageBox.Show("DNI no encontrado o token inválido.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar API RENIEC: " + ex.Message);
                }
            }

        

        }

        private byte[] GenerarHash(string textoPlano)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
                return sha256.ComputeHash(bytes);
            }
        }
    }
}


