using CapaDatos;
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
     empleado.DNI == txtDNI.Text &&
     (!idEmpleadoSeleccionado.HasValue || empleado.EmpleadoID != idEmpleadoSeleccionado.Value));



            if (dniDuplicado)
            {
                MessageBox.Show("Ya existe un empleado registrado con este DNI.", "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado emp = new Empleado
            {
                DNI = txtDNI.Text,
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
                ListarEmpleados(); // actualiza grilla o lista
                LimpiarCampos();   // limpia los textbox, datepickers, etc.
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

                txtDNI.Text = dgvEmpleados.CurrentRow.Cells["DNI"].Value.ToString();
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
            txtDNI.Clear();
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
            if (txtDNI.Text.Length != 8)
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
            if (txtDNI.Text.Length == 8)
            {
                var datos = await empleadoCN.ConsultarRENIECAsync(txtDNI.Text);
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
                MessageBox.Show("Solo se permite registrar empleados mayores de 18 años.", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEdad.Clear();
                
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

        }
    }
}