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
    public partial class frmDetalleFiscalizacion : Form
    {
        private int fiscalizacionID;
        private fiscalizacionCN fiscalCN = new fiscalizacionCN();
        public frmDetalleFiscalizacion(int id)
        {
            InitializeComponent();
            fiscalizacionID = id;
        }

        private void frmDetalleFiscalizacion_Load(object sender, EventArgs e)
        {
            CargarDetalle();

            txtEstablecimiento.ReadOnly = true;
            txtTipo.ReadOnly = true;
            txtEstado.ReadOnly = true;
            txtResultado.ReadOnly = true;
            txtObservaciones.ReadOnly = true;

            chkNotificado.Enabled = false;
            dtpFecha.Enabled = false;
            dtpNotificacion.Enabled = false;
        }

        private void CargarDetalle()
        {
            Fiscalizacion f = fiscalCN.ObtenerFiscalizacionPorID(fiscalizacionID);

            if (f != null)
            {
                txtEstablecimiento.Text = f.RazonSocial;
                dtpFecha.Value = f.FechaFiscalizacion;
                txtTipo.Text = f.TipoFiscalizacion;
                txtEstado.Text = f.EstadoFiscalizacion;
                txtResultado.Text = f.ResultadoFiscalizacion;
                txtObservaciones.Text = f.Observaciones;
                chkNotificado.Checked = f.Notificado;
                dtpNotificacion.Visible = f.Notificado;

                if (f.FechaNotificacion.HasValue)
                    dtpNotificacion.Value = f.FechaNotificacion.Value;
            }
            else
            {
                MessageBox.Show("No se pudo cargar la información.");
                this.Close();
            }
        }
    }
}

