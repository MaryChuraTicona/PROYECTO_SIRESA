using CapaDatos;
using CapaEntidad;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaUI
{
    public partial class frmEmpleados : Form
    {
        private empleadoCN empleadoCN = new empleadoCN();
        private rolCN rolCN = new rolCN();
        private int? idEmpleadoSeleccionado = null;
        private bool esNuevo = true;
        public frmEmpleados()
        {
            InitializeComponent();
            CargarCargos();
            CargarSupervisores();
            ListarEmpleados();
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            txtEdad.ReadOnly = true;
            diseno();




        }

        private void CargarCargos()
        {
            cmbCargo.DataSource = rolCN.Listar();
            cmbCargo.DisplayMember = "NombreRol";
            cmbCargo.ValueMember = "RolID";
            cmbCargo.SelectedIndexChanged += cmbCargo_SelectedIndexChanged;
        }

        private void CargarSupervisores()
        {
            var supervisores = new usuario_CD().ListarUsuarios()
                                       .Where(u => u.RolID == 3 && u.Activo)
                                       .ToList();

            cmbSupervisor.DataSource = supervisores;
            cmbSupervisor.DisplayMember = "NombreCompleto";
            cmbSupervisor.ValueMember = "UsuarioID";
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCargo.SelectedValue == null) return;

            string cargo = cmbCargo.Text.ToLower();

            if (cargo.Contains("administrador") || cargo.Contains("supervisor"))
            {
                cmbSupervisor.Enabled = false;
                cmbSupervisor.SelectedIndex = -1;
            }
            else
            {
                cmbSupervisor.Enabled = true;
            }
        }

      

        private int CalcularEdad(DateTime nacimiento)
        {
            int edad = DateTime.Now.Year - nacimiento.Year;
            if (DateTime.Now < nacimiento.AddYears(edad)) edad--;
            return edad;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            var lista = empleadoCN.ObtenerEmpleados();
            bool dniDuplicado = lista.Any(empleado =>
     empleado.DNI == DNI.Text &&
     (!idEmpleadoSeleccionado.HasValue || empleado.EmpleadoID != idEmpleadoSeleccionado.Value));



            if (dniDuplicado)
            {
                MessageBox.Show("Ya existe un empleado registrado con este DNI.", "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado emp = new Empleado
            {
                DNI = DNI.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Especialidad = txtEspecialidad.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Edad = int.Parse(txtEdad.Text),
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                RolID = (int)cmbCargo.SelectedValue,
                SupervisorID = cmbSupervisor.Enabled ? (int?)cmbSupervisor.SelectedValue : null,
                Activo = chkActivo.Checked,
                FechaRegistro = DateTime.Now
            };

            try
            {
                string resultado = empleadoCN.RegistrarEmpleado(emp);
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarEmpleados(); 
                LimpiarCampos();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string mensaje;
            if (esNuevo)
                mensaje = empleadoCN.RegistrarEmpleado(emp);
            else
                mensaje = empleadoCN.EditarEmpleado(idEmpleadoSeleccionado.Value, emp);

            MessageBox.Show(mensaje);
            ListarEmpleados();
            LimpiarCampos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                esNuevo = false;
                idEmpleadoSeleccionado = (int)dgvEmpleados.CurrentRow.Cells["EmpleadoID"].Value;

                DNI.Text = dgvEmpleados.CurrentRow.Cells["DNI"].Value.ToString();
                txtNombreCompleto.Text = dgvEmpleados.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                txtEspecialidad.Text = dgvEmpleados.CurrentRow.Cells["Especialidad"].Value.ToString();
                txtCorreo.Text = dgvEmpleados.CurrentRow.Cells["Correo"].Value.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dgvEmpleados.CurrentRow.Cells["Direccion"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvEmpleados.CurrentRow.Cells["FechaNacimiento"].Value);
                txtEdad.Text = dgvEmpleados.CurrentRow.Cells["Edad"].Value.ToString();
                cmbCargo.SelectedValue = (int)dgvEmpleados.CurrentRow.Cells["RolID"].Value;
                chkActivo.Checked = Convert.ToBoolean(dgvEmpleados.CurrentRow.Cells["Activo"].Value);

                if (dgvEmpleados.CurrentRow.Cells["SupervisorID"].Value != DBNull.Value)
                    cmbSupervisor.SelectedValue = (int)dgvEmpleados.CurrentRow.Cells["SupervisorID"].Value;
            }
        }

      

        private void ListarEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = empleadoCN.ObtenerEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            DNI.Clear();
            txtNombreCompleto.Clear();
            txtEspecialidad.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            cmbCargo.SelectedIndex = -1;
            cmbSupervisor.SelectedIndex = -1;
            chkActivo.Checked = true;
            esNuevo = true;
            idEmpleadoSeleccionado = null;

        }

        private bool ValidarCampos()
        {
            if (DNI.Text.Length != 8)
            {
                MessageBox.Show("DNI inválido");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Nombre completo requerido");
                return false;
            }
            if (!int.TryParse(txtEdad.Text, out int edad) || edad < 18)
            {
                MessageBox.Show("Debe ser mayor de edad (18 años o más)");
                return false;
            }
            return true;
        }

        private async void txtDNI_Leave(object sender, EventArgs e)
        {
            if (DNI.Text.Length == 8)
            {
                var datos = await empleadoCN.ConsultarRENIECAsync(DNI.Text);
                if (datos != null)
                {
                    txtNombreCompleto.Text = datos.NombreCompleto;
                   
                }
                else
                {
                    MessageBox.Show("No se encontraron datos en RENIEC o el token expiró.");
                }
            }
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime nacimiento = dtpFechaNacimiento.Value;
            int edad = CalcularEdad(nacimiento);
            txtEdad.Text = edad.ToString();

            if (edad < 18)
            {
                
                txtEdad.Clear();
                
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;



        }

        private void diseno()
        {

            lblTitulo.Text = "Gestión de Empleados";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkRed;
            lblTitulo.Location = new Point(20, 10);

            // DNI
            lblDNI.Text = "DNI:";
            lblDNI.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DNI.Location = new Point(80, 60);
            lblDNI.Location = new Point(20, 58);
            DNI.Width = 150;

            // Nombre completo
            label1.Text = "Nombre Completo:";
            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label1.Location = new Point(250, 60);
            txtNombreCompleto.Location = new Point(400, 58);
            txtNombreCompleto.Width = 250;

            // Fecha nacimiento
            label5.Text = "Fecha de Nacimiento:";
            label5.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label5.Location = new Point(20, 100);
            dtpFechaNacimiento.Location = new Point(180, 98);
            dtpFechaNacimiento.Width = 180;

            // Edad
            label6.Text = "Edad:";
            label6.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label6.Location = new Point(380, 100);
            txtEdad.Location = new Point(430, 98);
            txtEdad.Width = 50;

            // Correo
            label7.Text = "Correo:";
            label7.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label7.Location = new Point(20, 140);
            txtCorreo.Location = new Point(90, 138);
            txtCorreo.Width = 250;

            // Teléfono
            label8.Text = "Teléfono:";
            label8.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label8.Location = new Point(360, 140);
            txtTelefono.Location = new Point(440, 138);
            txtTelefono.Width = 150;

            // Dirección
            label9.Text = "Dirección:";
            label9.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label9.Location = new Point(20, 180);
            txtDireccion.Location = new Point(100, 178);
            txtDireccion.Width = 300;

            // Especialidad
            label4.Text = "Especialidad:";
            label4.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label4.Location = new Point(420, 180);
            txtEspecialidad.Location = new Point(520, 178);
            txtEspecialidad.Width = 150;

            // Rol
            label2.Text = "Rol:";
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Location = new Point(20, 220);
            cmbCargo.Location = new Point(60, 218);
            cmbCargo.Width = 150;

            // Supervisor
            label3.Text = "Supervisor:";
            label3.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label3.Location = new Point(230, 220);
            cmbSupervisor.Location = new Point(320, 218);
            cmbSupervisor.Width = 200;

            // Activo
            chkActivo.Text = "Activo";
            chkActivo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chkActivo.Location = new Point(540, 220);





            btnGuardar.Text = "Guardar";
            btnGuardar.Size = new Size(120, 40);
            btnGuardar.BackColor = Color.DarkRed;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(20, 270);
            this.Controls.Add(btnGuardar);

            btnNuevo.Text = "Nuevo";
            btnNuevo.Size = new Size(120, 40);
            btnNuevo.BackColor = Color.Gray;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(160, 270);
            this.Controls.Add(btnNuevo);

            btnEditar.Text = "Editar";
            btnEditar.Size = new Size(120, 40);
            btnEditar.BackColor = Color.Gray;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(300, 270);
            this.Controls.Add(btnEditar);


            dgvEmpleados.Location = new Point(20, 330);
            dgvEmpleados.Size = new Size(1240,350);
            dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.GridColor = Color.DarkRed;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.Controls.Add(dgvEmpleados);

            // --- FORMULARIO MDI HIJO CONFIGURADO ---
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.WhiteSmoke;

        }
    }
}