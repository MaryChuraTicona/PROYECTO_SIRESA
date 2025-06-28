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
            try
            {
                // Validar campos obligatorios
                if (cmbEstablecimiento.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un establecimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbTipo.Text))
                {
                    MessageBox.Show("Seleccione el tipo de fiscalización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que tenga al menos un inspector asignado
                if (dgvEquipo.Rows.Count <= 1)
                {
                    MessageBox.Show("Debe asignar al menos un inspector a la fiscalización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int establecimientoID = (int)cmbEstablecimiento.SelectedValue;
                DateTime fechaFiscalizacion = dtpFechaFiscalizacion.Value.Date;

                // Validar que no exista ya programada
                if (fiscalCN.ExisteFiscalizacionEnFecha(establecimientoID, fechaFiscalizacion))
                {
                    MessageBox.Show("Ya existe una fiscalización programada para este establecimiento en la misma fecha.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construir la entidad
                Fiscalizacion f = new Fiscalizacion
                {
                    EstablecimientoID = establecimientoID,
                    FechaFiscalizacion = fechaFiscalizacion,
                    TipoFiscalizacion = cmbTipo.Text,
                    EstadoFiscalizacion = "Pendiente",
                    Observaciones = txtObservaciones.Text,
                    Notificado = chkNotificado.Checked,
                    FechaNotificacion = dtpNotificacion.Value.Date,
                    UsuarioRegistroID = usuarioActual.UsuarioID
                };

                // Registrar
                int nuevaFiscalizacionID = fiscalCN.RegistrarFiscalizacion(f);

                // Registrar inspectores
                foreach (DataGridViewRow row in dgvEquipo.Rows)
                {
                    if (row.IsNewRow) continue;

                    string nombreEmpleado = row.Cells["Empleado"].Value?.ToString();
                    string rol = row.Cells["Rol"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(nombreEmpleado) || string.IsNullOrWhiteSpace(rol))
                        continue;

                    int empleadoID = empCN.ObtenerIDPorNombre(nombreEmpleado);

                    equipoCN.AgregarInspectorAFiscalizacion(nuevaFiscalizacionID, empleadoID, rol);
                }

                MessageBox.Show("Fiscalización registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la fiscalización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaFiscalizacion_Load(object sender, EventArgs e)
        {
            dtpFechaFiscalizacion.MinDate = DateTime.Today;
            dtpFechaFiscalizacion.Value = DateTime.Today;
            dtpNotificacion.Value = DateTime.Today;

            CargarEstablecimientos();
            CargarEmpleados();
            disenoNuevaFiscalizacion();
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

        private void disenoNuevaFiscalizacion()
        {

            this.Text = "Nueva Fiscalización";

            // Título centrado opcional
            Label lblTitulo = new Label();
            lblTitulo.Text = "NUEVA FISCALIZACIÓN";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point((this.Width / 2) - 120, 10);
            this.Controls.Add(lblTitulo);

            // Estilo DataGridView
            dgvEquipo.EnableHeadersVisualStyles = false;
            dgvEquipo.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon;
            dgvEquipo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEquipo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dgvEquipo.DefaultCellStyle.BackColor = Color.White;
            dgvEquipo.DefaultCellStyle.ForeColor = Color.Black;
            dgvEquipo.DefaultCellStyle.SelectionBackColor = Color.LightSalmon;
            dgvEquipo.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvEquipo.GridColor = Color.Maroon;
            dgvEquipo.BorderStyle = BorderStyle.Fixed3D;

            // Estilo botones
            btnGuardar.BackColor = Color.Maroon;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;

            btnAgregarInspector.BackColor = Color.Maroon;
            btnAgregarInspector.ForeColor = Color.White;
            btnAgregarInspector.FlatStyle = FlatStyle.Flat;

            btnQuitarInspector.BackColor = Color.Gray;
            btnQuitarInspector.ForeColor = Color.White;
            btnQuitarInspector.FlatStyle = FlatStyle.Flat;
            lblEstablecimiento.Text = "Establecimiento:";
            lblEstablecimiento.Location = new Point(20, 30);
            lblEstablecimiento.AutoSize = true;


            cmbEstablecimiento.Location = new Point(150, 27);
            cmbEstablecimiento.Width = 220;


            lblTipo.Text = "Tipo:";
            lblTipo.Location = new Point(20, 70);
            lblTipo.AutoSize = true;


            cmbTipo.Location = new Point(150, 67);
            cmbTipo.Width = 220;

            lblFecha.Text = "Fecha de fiscalización:";
            lblFecha.Location = new Point(20, 110);
            lblFecha.AutoSize = true;


            dtpFechaFiscalizacion.Location = new Point(150, 107);
            dtpFechaFiscalizacion.Width = 220;


            lblObservaciones.Text = "Observaciones:";
            lblObservaciones.Location = new Point(20, 150);
            lblObservaciones.AutoSize = true;


            txtObservaciones.Location = new Point(150, 147);
            txtObservaciones.Size = new Size(220, 60);
            txtObservaciones.Multiline = true;


            chkNotificado.Text = "Notificado";
            chkNotificado.Location = new Point(20, 220);
            chkNotificado.AutoSize = true;


            lblFechaNotif.Text = "Fecha notificación:";
            lblFechaNotif.Location = new Point(20, 250);
            lblFechaNotif.AutoSize = true;


            dtpNotificacion.Location = new Point(150, 247);
            dtpNotificacion.Width = 220;


            btnGuardar.Text = "Guardar";
            btnGuardar.BackColor = Color.Maroon;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(150, 290);
            btnGuardar.Size = new Size(100, 35);


            lblEmpleado.Text = "Empleado:";
            lblEmpleado.Location = new Point(420, 30);
            lblEmpleado.AutoSize = true;


            cmbEmpleado.Location = new Point(500, 27);
            cmbEmpleado.Width = 200;


            lblRol.Text = "Rol:";
            lblRol.Location = new Point(420, 70);
            lblRol.AutoSize = true;


            cmbRol.Location = new Point(500, 67);
            cmbRol.Width = 200;


            btnAgregarInspector.Text = "Agregar";
            btnAgregarInspector.BackColor = Color.Maroon;
            btnAgregarInspector.ForeColor = Color.White;
            btnAgregarInspector.Location = new Point(500, 110);
            btnAgregarInspector.Size = new Size(90, 30);


            btnQuitarInspector.Text = "Quitar";
            btnQuitarInspector.BackColor = Color.Gray;
            btnQuitarInspector.ForeColor = Color.White;
            btnQuitarInspector.Location = new Point(610, 110);
            btnQuitarInspector.Size = new Size(90, 30);


            dgvEquipo.Location = new Point(420, 160);
            dgvEquipo.Size = new Size(380, 180);
     

            // Agregar todos al formulario
            this.Controls.AddRange(new Control[] {
    lblEstablecimiento, cmbEstablecimiento,
    lblTipo, cmbTipo,
    lblFecha, dtpFechaFiscalizacion,
    lblObservaciones, txtObservaciones,
    chkNotificado,
    lblFechaNotif, dtpNotificacion,
    btnGuardar,

    lblEmpleado, cmbEmpleado,
    lblRol, cmbRol,
    btnAgregarInspector, btnQuitarInspector,
    dgvEquipo
});
        }
    }
}




