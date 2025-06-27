using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaUI
{
    public partial class frmDenuncia : Form
    {
        private denunciaCN denunciaCN = new denunciaCN();
        private List<Denuncia> listaDenuncias = new List<Denuncia>();
        private Denuncia denunciaSeleccionada;
        private Usuario usuarioActual;
        public frmDenuncia(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmDenuncia_Load(object sender, EventArgs e)
        {
            cmbEstadoFiltro.Items.AddRange(new string[] { "Todos", "Pendiente", "Atendida", "Rechazada" });
            cmbEstadoFiltro.SelectedIndex = 0;
            CargarDenuncias("Todos");

            LimpiarDetalle();
        }
        private void CargarDenuncias(string estado)
        {
            dgvDenuncias.Rows.Clear();
            listaDenuncias = denunciaCN.ObtenerDenuncias(estado);

            foreach (var d in listaDenuncias)
            {
                dgvDenuncias.Rows.Add(d.DenunciaID, d.DNI, d.Nombres, d.Correo, d.FechaRegistro, d.Estado);
            }
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDenuncias(cmbEstadoFiltro.SelectedItem.ToString());
            LimpiarDetalle();
        }

        private void dgvDenuncias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDenuncias.Rows[e.RowIndex].Cells[0].Value);
                denunciaSeleccionada = listaDenuncias.FirstOrDefault(d => d.DenunciaID == id);

                if (denunciaSeleccionada != null)
                {
                    lblDNI.Text = "DNI: " + denunciaSeleccionada.DNI;
                    lblNombres.Text = "Nombres: " + denunciaSeleccionada.Nombres;
                    lblCorreo.Text = "Correo: " + denunciaSeleccionada.Correo;
                    lblRUC.Text = "RUC: " + denunciaSeleccionada.RUC;
                    lblEstablecimiento.Text = "Establecimiento: " + denunciaSeleccionada.NombreEstablecimiento;
                    lblDireccionEstablecimiento.Text = "Dirección: " + denunciaSeleccionada.DireccionEstablecimiento;

                    txtDescripcion.Text = denunciaSeleccionada.Descripcion;
                    txtRespuesta.Text = denunciaSeleccionada.Respuesta ?? "";

                    if (File.Exists(denunciaSeleccionada.RutaImagen))
                        picEvidencia.Image = Image.FromFile(denunciaSeleccionada.RutaImagen);
                    else
                        picEvidencia.Image = null;

                    txtRespuesta.Enabled = denunciaSeleccionada.Estado == "Pendiente";
                    btnGuardarRespuesta.Enabled = denunciaSeleccionada.Estado == "Pendiente";
                }
            }
        }

        private void btnGuardarRespuesta_Click(object sender, EventArgs e)
        {
            if (denunciaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una denuncia.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("Ingrese una respuesta.");
                return;
            }

            denunciaSeleccionada.Respuesta = txtRespuesta.Text;

            string resultado = denunciaCN.ResponderDenuncia(
            denunciaSeleccionada.DenunciaID,
            usuarioActual.UsuarioID,
            denunciaSeleccionada.Respuesta,
            "Atendida"
                     );


            if (resultado == "ok")
            {
                MessageBox.Show("Respuesta guardada correctamente.");
                CargarDenuncias(cmbEstadoFiltro.SelectedItem.ToString());
                LimpiarDetalle();
            }
            else
            {
                MessageBox.Show("Error: " + resultado);
            }
        }

        private void LimpiarDetalle()
        {
            lblDNI.Text = "DNI:";
            lblNombres.Text = "Nombres:";
            lblCorreo.Text = "Correo:";
            lblRUC.Text = "RUC:";
            lblEstablecimiento.Text = "Establecimiento:";
            lblDireccionEstablecimiento.Text = "Dirección:";
            txtDescripcion.Clear();
            txtRespuesta.Clear();
            picEvidencia.Image = null;
            btnGuardarRespuesta.Enabled = false;
        }
    }
}
