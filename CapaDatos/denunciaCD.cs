using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class denunciaCD
    {
        private Conexion conexion = new Conexion();

        public string RegistrarDenuncia(Denuncia d)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"
INSERT INTO Denuncias 
(DNI, Nombres, Correo, Descripcion, RutaImagen, Estado, RUC, NombreEstablecimiento, DireccionEstablecimiento)
VALUES 
(@dni, @nombres, @correo, @descripcion, @ruta, @estado, @ruc, @nombreEst, @direccionEst)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", d.DNI);
                cmd.Parameters.AddWithValue("@nombres", d.Nombres);
                cmd.Parameters.AddWithValue("@correo", (object)d.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descripcion", d.Descripcion);
                cmd.Parameters.AddWithValue("@ruta", d.RutaImagen);
                cmd.Parameters.AddWithValue("@estado", "Pendiente");
                cmd.Parameters.AddWithValue("@ruc", d.RUC);
                cmd.Parameters.AddWithValue("@nombreEst", d.NombreEstablecimiento);
                cmd.Parameters.AddWithValue("@direccionEst", d.DireccionEstablecimiento);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "ok" : "error";
            }
        }

        public List<Denuncia> ListarDenuncias(string estadoFiltro)
        {
            List<Denuncia> lista = new List<Denuncia>();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"
                    SELECT * FROM Denuncias
                    WHERE (@estado = 'Todos' OR Estado = @estado)
                    ORDER BY FechaRegistro DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@estado", estadoFiltro);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Denuncia
                    {
                        DenunciaID = Convert.ToInt32(dr["DenunciaID"]),
                        DNI = dr["DNI"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        RutaImagen = dr["RutaImagen"].ToString(),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                        Estado = dr["Estado"].ToString(),
                        Respuesta = dr["Respuesta"]?.ToString()
                    });
                }
            }

            return lista;
        }

        public string ActualizarRespuesta(int id, int usuarioID, string respuesta, string nuevoEstado)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"
                    UPDATE Denuncias
                    SET Respuesta = @respuesta,
                        Estado = @estado,
                        UsuarioAtiendeID = @usuarioID
                    WHERE DenunciaID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@respuesta", respuesta);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);
                cmd.Parameters.AddWithValue("@id", id);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "ok" : "error";
            }
        }

        public Denuncia ObtenerPorID(int id)
        {
            Denuncia d = null;

            using (var conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Denuncias WHERE DenunciaID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        d = new Denuncia()
                        {
                            DenunciaID = Convert.ToInt32(dr["DenunciaID"]),
                            Nombres = dr["Nombres"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            // Agrega los demás campos que uses
                        };
                    }
                }
            }

            return d;
        }

    }
}
