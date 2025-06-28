using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class fiscalizacionCD
    {
        private Conexion conexion = new Conexion();
        public int RegistrarFiscalizacion(Fiscalizacion f)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = @"INSERT INTO Fiscalizaciones
                        (
                            EstablecimientoID, FechaFiscalizacion, TipoFiscalizacion, EstadoFiscalizacion,
                            Observaciones, FirmaID, Notificado, FechaNotificacion,
                            FechaEjecucion, ResultadoFiscalizacion, EquipoID, UsuarioRegistroID
                        )
                        VALUES
                        (
                            @EstablecimientoID, @FechaFiscalizacion, @TipoFiscalizacion, @EstadoFiscalizacion,
                            @Observaciones, @FirmaID, @Notificado, @FechaNotificacion,
                            @FechaEjecucion, @ResultadoFiscalizacion, @EquipoID, @UsuarioRegistroID
                        );
                        SELECT SCOPE_IDENTITY();
                        ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EstablecimientoID", f.EstablecimientoID);
                cmd.Parameters.AddWithValue("@FechaFiscalizacion", f.FechaFiscalizacion);
                cmd.Parameters.AddWithValue("@TipoFiscalizacion", f.TipoFiscalizacion);
                cmd.Parameters.AddWithValue("@EstadoFiscalizacion", f.EstadoFiscalizacion);
                cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrEmpty(f.Observaciones) ? (object)DBNull.Value : f.Observaciones);
                cmd.Parameters.AddWithValue("@FirmaID", f.FirmaID.HasValue ? (object)f.FirmaID.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Notificado", f.Notificado);
                cmd.Parameters.AddWithValue("@FechaNotificacion", f.FechaNotificacion.HasValue ? (object)f.FechaNotificacion.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaEjecucion", f.FechaEjecucion.HasValue ? (object)f.FechaEjecucion.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@ResultadoFiscalizacion", string.IsNullOrEmpty(f.ResultadoFiscalizacion) ? (object)DBNull.Value : f.ResultadoFiscalizacion);
                cmd.Parameters.AddWithValue("@EquipoID", f.EquipoID.HasValue ? (object)f.EquipoID.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@UsuarioRegistroID", f.UsuarioRegistroID);

                return Convert.ToInt32(cmd.ExecuteScalar());

            }
        }

        public List<Fiscalizacion> ObtenerFiscalizaciones()
        {
            List<Fiscalizacion> lista = new List<Fiscalizacion>();

            using (var conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT f.FiscalizacionID, f.FechaFiscalizacion, f.TipoFiscalizacion, 
                   f.EstadoFiscalizacion, f.ResultadoFiscalizacion,
                   f.Observaciones, e.RazonSocial AS RazonSocial
            FROM Fiscalizaciones f
            INNER JOIN Establecimientos e ON f.EstablecimientoID = e.EstablecimientoID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Fiscalizacion
                    {
                        FiscalizacionID = Convert.ToInt32(dr["FiscalizacionID"]),
                        FechaFiscalizacion = Convert.ToDateTime(dr["FechaFiscalizacion"]),
                        TipoFiscalizacion = dr["TipoFiscalizacion"].ToString(),
                        EstadoFiscalizacion = dr["EstadoFiscalizacion"].ToString(),
                        ResultadoFiscalizacion = dr["ResultadoFiscalizacion"].ToString(),
                        Observaciones = dr["Observaciones"].ToString(),
                        NombreEstablecimiento = dr["RazonSocial"].ToString()
                    });
                }
            }

            return lista;
        }
        public List<Fiscalizacion> ObtenerFiscalizacionesPendientes()
        {
            List<Fiscalizacion> lista = new List<Fiscalizacion>();

            using (var conn = new Conexion().AbrirConexion())
            {
                string query = @"SELECT F.FiscalizacionID, E.NombreComercial AS NombreEstablecimiento
                         FROM Fiscalizaciones F
                         INNER JOIN Establecimientos E ON F.EstablecimientoID = E.EstablecimientoID
                         WHERE F.EstadoFiscalizacion = 'Pendiente'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Fiscalizacion
                    {
                        FiscalizacionID = Convert.ToInt32(dr["FiscalizacionID"]),
                        NombreEstablecimiento = dr["NombreEstablecimiento"].ToString()
                    });
                }
            }

            return lista;
        }

        public Fiscalizacion ObtenerFiscalizacionPorID(int id)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Fiscalizaciones WHERE FiscalizacionID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new Fiscalizacion
                    {
                        FiscalizacionID = (int)dr["FiscalizacionID"],
                        EstablecimientoID = (int)dr["EstablecimientoID"],
                        FechaFiscalizacion = (DateTime)dr["FechaFiscalizacion"],
                        TipoFiscalizacion = dr["TipoFiscalizacion"].ToString(),
                        EstadoFiscalizacion = dr["EstadoFiscalizacion"].ToString(),
                        Observaciones = dr["Observaciones"].ToString(),
                        Notificado = (bool)dr["Notificado"],
                        FechaNotificacion = dr["FechaNotificacion"] == DBNull.Value ? null : (DateTime?)dr["FechaNotificacion"]
                    };
                }
            }
            return null;
        }

        public bool ActualizarFiscalizacion(Fiscalizacion f)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = @"
                    UPDATE Fiscalizaciones
                    SET EstablecimientoID = @EstablecimientoID,
                        FechaFiscalizacion = @FechaFiscalizacion,
                        TipoFiscalizacion = @TipoFiscalizacion,
                        EstadoFiscalizacion = @EstadoFiscalizacion,
                        Observaciones = @Observaciones,
                        Notificado = @Notificado,
                        FechaNotificacion = @FechaNotificacion
                    WHERE FiscalizacionID = @FiscalizacionID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FiscalizacionID", f.FiscalizacionID);
                cmd.Parameters.AddWithValue("@EstablecimientoID", f.EstablecimientoID);
                cmd.Parameters.AddWithValue("@FechaFiscalizacion", f.FechaFiscalizacion);
                cmd.Parameters.AddWithValue("@TipoFiscalizacion", f.TipoFiscalizacion);
                cmd.Parameters.AddWithValue("@EstadoFiscalizacion", f.EstadoFiscalizacion);
                cmd.Parameters.AddWithValue("@Observaciones", f.Observaciones);
                cmd.Parameters.AddWithValue("@Notificado", f.Notificado);
                cmd.Parameters.AddWithValue("@FechaNotificacion", f.FechaNotificacion.HasValue ? (object)f.FechaNotificacion.Value : DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Establecimiento> ObtenerEstablecimientos()
        {
            List<Establecimiento> lista = new List<Establecimiento>();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT EstablecimientoID, RazonSocial FROM Establecimientos WHERE Estado = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Establecimiento
                    {
                        EstablecimientoID = Convert.ToInt32(dr["EstablecimientoID"]),
                        RazonSocial = dr["RazonSocial"].ToString()
                    });
                }
            }

            return lista;
        }

        public List<Fiscalizacion> ObtenerFiscalizacionesPorEmpleado(int empleadoID)
        {
            List<Fiscalizacion> lista = new List<Fiscalizacion>();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT f.FiscalizacionID, f.FechaFiscalizacion, f.TipoFiscalizacion, 
                   f.EstadoFiscalizacion, e.RazonSocial AS NombreEstablecimiento
            FROM Fiscalizaciones f
            INNER JOIN Establecimientos e ON f.EstablecimientoID = e.EstablecimientoID
            INNER JOIN EquiposInspeccion eq ON eq.FiscalizacionID = f.FiscalizacionID
            WHERE eq.EmpleadoID = @EmpleadoID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Fiscalizacion
                    {
                        FiscalizacionID = Convert.ToInt32(dr["FiscalizacionID"]),
                        FechaFiscalizacion = Convert.ToDateTime(dr["FechaFiscalizacion"]),
                        TipoFiscalizacion = dr["TipoFiscalizacion"].ToString(),
                        EstadoFiscalizacion = dr["EstadoFiscalizacion"].ToString(),
                        NombreEstablecimiento = dr["NombreEstablecimiento"].ToString()
                    });
                }
            }

            return lista;
        }

        public bool MarcarFiscalizacionComoFinalizada(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "UPDATE Fiscalizaciones SET EstadoFiscalizacion = 'Finalizada' WHERE FiscalizacionID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ExisteFiscalizacionEnFecha(int establecimientoID, DateTime fecha)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = @"SELECT COUNT(*) 
                         FROM Fiscalizaciones
                         WHERE EstablecimientoID = @establecimientoID
                           AND CAST(FechaFiscalizacion AS DATE) = @fecha
                           AND EstadoFiscalizacion <> 'Cancelada'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@establecimientoID", establecimientoID);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }




    }
}

