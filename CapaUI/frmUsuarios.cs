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
        private empleadoCN empleadoCN = new empleadoCN();
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

            // Verificar si ya hay un usuario con ese DNI
            if (usuarioCN.Listar().Exists(u => u.DNI == dni))
            {
                MessageBox.Show("Este DNI ya está registrado como usuario.");
                return;
            }

            Empleado emp = empleadoCN.BuscarEmpleadoPorDNI(dni);

            if (emp != null)
            {
                if (emp.Edad < 18)
                {
                    MessageBox.Show("No se puede registrar un usuario menor de edad.");
                    return;
                }

                txtNombreCompleto.Text = emp.NombreCompleto;
                txtCorreo.Text = emp.Correo;
                txtTelefono.Text = emp.Telefono;
                txtDireccion.Text = emp.Direccion;

                cmbRol.SelectedIndex = -1;
                foreach (var item in cmbRol.Items)
                {
                    if (((KeyValuePair<int, string>)item).Key == emp.RolID)
                    {
                        cmbRol.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("DNI no encontrado en la tabla de empleados registrados.");
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

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            Label lblTitulo = new Label
            {
                Text = "Gestión de Usuarios",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            this.Controls.Add(lblTitulo);

            // Nombre completo
            label1.Text = "Nombre Completo:";
            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label1.Location = new Point(20, 60);
            this.Controls.Add(label1);

            txtNombreCompleto.Location = new Point(160, 58);
            txtNombreCompleto.Width = 250;
            this.Controls.Add(txtNombreCompleto);

            // DNI
            DNI.Text = "DNI:";
            DNI.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DNI.Location = new Point(450, 60);
            this.Controls.Add(DNI);

            txtDNI.Location = new Point(500, 58);
            txtDNI.Width = 120;
            this.Controls.Add(txtDNI);

            // Correo
            label2.Text = "Correo:";
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(20, 100);
            this.Controls.Add(label2);

            txtCorreo.Location = new Point(160, 98);
            txtCorreo.Width = 250;
            this.Controls.Add(txtCorreo);

            // Teléfono
            label4.Text = "Teléfono:";
            label4.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label4.Location = new Point(450, 100);
            this.Controls.Add(label4);

            txtTelefono.Location = new Point(520, 98);
            txtTelefono.Width = 120;
            this.Controls.Add(txtTelefono);

            // Dirección
            label6.Text = "Dirección:";
            label6.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label6.Location = new Point(20, 140);
            this.Controls.Add(label6);

            txtDireccion.Location = new Point(160, 138);
            txtDireccion.Width = 480;
            this.Controls.Add(txtDireccion);

            // Usuario
            label3.Text = "Usuario:";
            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Location = new Point(20, 180);
            this.Controls.Add(label3);

            txtUsuario.Location = new Point(160, 178);
            txtUsuario.Width = 150;
            this.Controls.Add(txtUsuario);

            // Clave
            label5.Text = "Clave:";
            label5.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label5.Location = new Point(350, 180);
            this.Controls.Add(label5);

            txtClave.Location = new Point(400, 178);
            txtClave.Width = 150;
            this.Controls.Add(txtClave);

            Label lblRol = new Label
            {
                Text = "Rol:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 220),
                AutoSize = true
            };
            this.Controls.Add(lblRol);

            cmbRol.Location = new Point(160, 218);
            cmbRol.Width = 180;
            this.Controls.Add(cmbRol);

            // Activo
            chkActivo.Text = "Activo";
            chkActivo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chkActivo.Location = new Point(400, 220);
            this.Controls.Add(chkActivo);

            // Botones
            btnCrear.Text = "Crear";
            btnCrear.BackColor = Color.DarkRed;
            btnCrear.ForeColor = Color.White;
            btnCrear.Size = new Size(120, 40);
            btnCrear.Location = new Point(20, 270);
            this.Controls.Add(btnCrear);

            btnEditar.Text = "Editar";
            btnEditar.BackColor = Color.Gray;
            btnEditar.ForeColor = Color.White;
            btnEditar.Size = new Size(120, 40);
            btnEditar.Location = new Point(160, 270);
            this.Controls.Add(btnEditar);

            // DataGrid
            dgvUsuarios.Location = new Point(20, 330);
            dgvUsuarios.Size = new Size(900, 300);
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.GridColor = Color.DarkRed;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvUsuarios);

            // Ajustes de formulario
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }
    }
}


