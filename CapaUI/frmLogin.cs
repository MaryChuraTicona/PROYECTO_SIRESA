using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void PROBAR_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();
                SqlConnection conn = conexion.AbrirConexion();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show(" Conexión exitosa con Azure SQL.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

