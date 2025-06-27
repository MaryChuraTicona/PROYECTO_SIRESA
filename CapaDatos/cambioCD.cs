using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class cambioCD
    {
        private Conexion conexion = new Conexion();

        public void RegistrarCambio(Cambio cambio)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = "INSERT INTO HistorialCambios (UsuarioID, TablaAfectada, IDReferencia, TipoCambio, Detalle) " +
                               "VALUES (@UsuarioID, @Tabla, @Referencia, @Tipo, @Detalle)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UsuarioID", cambio.UsuarioID);
                cmd.Parameters.AddWithValue("@Tabla", cambio.TablaAfectada);
                cmd.Parameters.AddWithValue("@Referencia", cambio.IDReferencia);
                cmd.Parameters.AddWithValue("@Tipo", cambio.TipoCambio);
                cmd.Parameters.AddWithValue("@Detalle", cambio.Detalle);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Acceso> ListarAccesos(int? usuarioID, DateTime? desde, DateTime? hasta)
        {
            List<Acceso> lista = new List<Acceso>();

            using (var conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT a.AccesoID, a.UsuarioID, a.FechaHora, a.IP, a.Tipo, u.NombreCompleto 
            FROM HistorialAccesos a
            JOIN Usuarios u ON u.UsuarioID = a.UsuarioID
            WHERE (@usuarioID IS NULL OR a.UsuarioID = @usuarioID)
              AND (@desde IS NULL OR a.FechaHora >= @desde)
              AND (@hasta IS NULL OR a.FechaHora <= @hasta)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuarioID", (object)usuarioID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@desde", (object)desde ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hasta", (object)hasta ?? DBNull.Value);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Acceso
                    {
                        AccesoID = (int)dr["AccesoID"],
                        UsuarioID = (int)dr["UsuarioID"],
                        FechaHora = (DateTime)dr["FechaHora"],
                        IP = dr["IP"].ToString(),
                        Tipo = dr["Tipo"].ToString()
                    });
                }
            }

            return lista;
        }


        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (var conn = conexion.AbrirConexion())
            {
                string query = "SELECT UsuarioID, NombreCompleto FROM Usuarios WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        UsuarioID = (int)dr["UsuarioID"],
                        NombreCompleto = dr["NombreCompleto"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}

