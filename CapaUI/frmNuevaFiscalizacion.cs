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
    public partial class frmNuevaFiscalizacion : Form
    {
        private fiscalizacionCN fiscalCN = new fiscalizacionCN();
        private equipoCN equipoCN = new equipoCN();
        private empleadoCN empCN = new empleadoCN();
        private Usuario usuarioActual;
        private int? fiscalizacionID;
        public frmNuevaFiscalizacion(Usuario u)
        {
            InitializeComponent();
            if (u == null)
            {
                MessageBox.Show("Usuario no válido.");
                return;
            }

            usuarioActual = u;
            CargarEstablecimientos();
            CargarEmpleados();
          
        }

        private void CargarEstablecimientos()
        {
            var lista = fiscalCN.ObtenerEstablecimientos();

            if (lista.Count == 0)
            {
                MessageBox.Show("No hay establecimientos registrados o están inactivos.");
            }

            cmbEstablecimiento.DataSource = lista;
            cmbEstablecimiento.DisplayMember = "RazonSocial";        
            cmbEstablecimiento.ValueMember = "EstablecimientoID";
        }

        private void CargarEmpleados()
        {
            var lista = empCN.ObtenerEmpleadosActivos();

            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("No hay empleados activos registrados.");
                return;
            }

            cmbEmpleado.DataSource = lista;
            cmbEmpleado.DisplayMember = "NombreCompleto";
            cmbEmpleado.ValueMember = "EmpleadoID";
        }
        public frmNuevaFiscalizacion(int id, Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
            fiscalizacionID = id;
            CargarEstablecimientos();
            CargarDatosFiscalizacion();
            CargarEmpleados();
        }

        

        private void CargarDatosFiscalizacion()
        {
            if (fiscalizacionID.HasValue)
            {
                if (fiscalizacionID.HasValue)
                {
                    Fiscalizacion f = fiscalCN.ObtenerFiscalizacionPorID(fiscalizacionID.Value);

                    if (f != null)
                    {
                        cmbEstablecimiento.SelectedValue = f.EstablecimientoID;
                        dtpFechaFiscalizacion.Value = f.FechaFiscalizacion;
                        cmbTipo.Text = f.TipoFiscalizacion;
                        txtObservaciones.Text = f.Observaciones;
                        chkNotificado.Checked = f.Notificado;
                        if (f.FechaNotificacion.HasValue)
                            dtpNotificacion.Value = f.FechaNotificacion.Value;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Fiscalizacion f = new Fiscalizacion
            {
                EstablecimientoID = (int)cmbEstablecimiento.SelectedValue,
                FechaFiscalizacion = dtpFechaFiscalizacion.Value.Date,
                TipoFiscalizacion = cmbTipo.Text,
                EstadoFiscalizacion = "Pendiente",
                Observaciones = txtObservaciones.Text,
                Notificado = chkNotificado.Checked,
                FechaNotificacion = dtpNotificacion.Value.Date,
                UsuarioRegistroID = usuarioActual.UsuarioID
            };

            int nuevaFiscalizacionID = fiscalCN.RegistrarFiscalizacion(f);

            // 2. Insertar inspectores asignados (incluyendo Diana)
            foreach (DataGridViewRow row in dgvEquipo.Rows)
            {
                if (row.IsNewRow) continue;

                string nombreEmpleado = row.Cells["Empleado"].Value.ToString();
                string rol = row.Cells["Rol"].Value.ToString();


                int empleadoID = empCN.ObtenerIDPorNombre(nombreEmpleado);

                equipoCN.AgregarInspectorAFiscalizacion(nuevaFiscalizacionID, empleadoID, rol);

            }

            MessageBox.Show("Fiscalización registrada correctamente.");
            this.Close();
        }

        private void frmNuevaFiscalizacion_Load(object sender, EventArgs e)
        {
            dtpFechaFiscalizacion.MinDate = DateTime.Today;
            dtpFechaFiscalizacion.Value = DateTime.Today;
            dtpNotificacion.Value = DateTime.Today;

            CargarEstablecimientos();
            CargarEmpleados();
            cmbTipo.Items.AddRange(new string[] { "Programada", "Sorpresa", "Denuncia" });
            cmbRol.Items.AddRange(new string[] { "Responsable", "Inspector" });

            dgvEquipo.Columns.Add("Empleado", "Empleado");
            dgvEquipo.Columns.Add("Rol", "Rol");
        }

        private void btnAgregarInspector_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedItem == null || cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un empleado y un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreEmpleado = cmbEmpleado.Text;
            string rol = cmbRol.Text;

            // Validar que no se repita el mismo empleado
            foreach (DataGridViewRow fila in dgvEquipo.Rows)
            {
                if (fila.IsNewRow) continue;
                if ((fila.Cells["Empleado"].Value?.ToString() ?? "") == nombreEmpleado)
                {
                    MessageBox.Show("El empleado ya fue agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Validar que solo haya un responsable
            if (rol == "Responsable")
            {
                foreach (DataGridViewRow fila in dgvEquipo.Rows)
                {
                    if (fila.IsNewRow) continue;
                    if ((fila.Cells["Rol"].Value?.ToString() ?? "") == "Responsable")
                    {
                        MessageBox.Show("Ya existe un responsable asignado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            dgvEquipo.Rows.Add(nombreEmpleado, rol);
        }

        private void btnQuitarInspector_Click(object sender, EventArgs e)
        {
            if (dgvEquipo.SelectedRows.Count > 0)
                dgvEquipo.Rows.RemoveAt(dgvEquipo.SelectedRows[0].Index);
        }
    

    private void EnviarCorreoEstablecimiento(string correoDestino, string razonSocial, DateTime fecha)
        {
            try
            {
                string asunto = "Fiscalización Sanitaria Programada";
                string cuerpo = $"Estimado(a),\n\nLe informamos que su establecimiento \"{razonSocial}\" será fiscalizado el día {fecha:dd/MM/yyyy}.\n\nSaludos,\nEquipo SIRESA.";

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("mc2019065163@virtual.upt.pe");
                mail.To.Add(correoDestino);
                mail.Subject = asunto;
                mail.Body = cuerpo;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("mc2019065163@virtual.upt.pe", "xxgvahsbpfqzypvb");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo: " + ex.Message);
            }
        }



    }

}

 
