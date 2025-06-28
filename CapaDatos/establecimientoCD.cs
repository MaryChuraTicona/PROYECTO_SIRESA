using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class establecimientoCD
    {
        private Conexion conexion = new Conexion();

        public bool Registrar(Establecimiento est)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"INSERT INTO Establecimientos 
        (RUC, RazonSocial, NombreComercial, Direccion, EstadoContribuyente, CondicionContribuyente, Ubigeo, 
         TipoNegocio, EstadoSanitario, FechaRegistro, UsuarioRegistroID)
        VALUES
        (@RUC, @RazonSocial, @NombreComercial, @Direccion, @EstadoContribuyente, @CondicionContribuyente, @Ubigeo,
         @TipoNegocio,  @EstadoSanitario, @FechaRegistro, @UsuarioRegistroID)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RUC", est.RUC);
                cmd.Parameters.AddWithValue("@RazonSocial", est.RazonSocial);
                cmd.Parameters.AddWithValue("@NombreComercial", est.NombreComercial);
                cmd.Parameters.AddWithValue("@Direccion", est.Direccion);
                cmd.Parameters.AddWithValue("@EstadoContribuyente", est.EstadoContribuyente);
                cmd.Parameters.AddWithValue("@CondicionContribuyente", est.CondicionContribuyente);
                cmd.Parameters.AddWithValue("@Ubigeo", est.Ubigeo);
                cmd.Parameters.AddWithValue("@TipoNegocio", est.TipoNegocio);
                cmd.Parameters.AddWithValue("@EstadoSanitario", est.EstadoSanitario);
                cmd.Parameters.AddWithValue("@FechaRegistro", est.FechaRegistro);
                cmd.Parameters.AddWithValue("@UsuarioRegistroID", est.UsuarioRegistroID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool ExisteRUC(string ruc)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT COUNT(*) FROM Establecimientos WHERE RUC = @ruc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ruc", ruc);

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // true si ya existe
            }
        }


        public List<Establecimiento> Listar()
        {
            List<Establecimiento> lista = new List<Establecimiento>();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Establecimientos WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Establecimiento
                    {
                        EstablecimientoID = (int)dr["EstablecimientoID"],
                        RUC = dr["RUC"].ToString(),
                        RazonSocial = dr["RazonSocial"].ToString(),
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        EstadoContribuyente = dr["EstadoContribuyente"].ToString(),
                        CondicionContribuyente = dr["CondicionContribuyente"].ToString(),
                        Ubigeo = dr["Ubigeo"].ToString(),
                        TipoNegocio = dr["TipoNegocio"].ToString(),
                        EstadoSanitario = dr["EstadoSanitario"].ToString(),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                        UsuarioRegistroID = (int)dr["UsuarioRegistroID"],
                        Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : "",
                        Activo = dr["Activo"] != DBNull.Value ? (bool)dr["Activo"] : true

                    });
                }
            }

            return lista;
        }


        public List<Establecimiento> Listar(bool mostrarTodos)
        {
            List<Establecimiento> lista = new List<Establecimiento>();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Establecimientos";
                if (!mostrarTodos)
                    query += " WHERE Activo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Establecimiento
                    {
                        EstablecimientoID = (int)dr["EstablecimientoID"],
                        RUC = dr["RUC"].ToString(),
                        RazonSocial = dr["RazonSocial"].ToString(),
                        NombreComercial = dr["NombreComercial"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        EstadoContribuyente = dr["EstadoContribuyente"].ToString(),
                        CondicionContribuyente = dr["CondicionContribuyente"].ToString(),
                        Ubigeo = dr["Ubigeo"].ToString(),
                        TipoNegocio = dr["TipoNegocio"].ToString(),
                        EstadoSanitario = dr["EstadoSanitario"].ToString(),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                        UsuarioRegistroID = (int)dr["UsuarioRegistroID"],
                        Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : "",
                        Activo = dr["Activo"] != DBNull.Value ? (bool)dr["Activo"] : true
                    });
                }
            }
            return lista;
        }

        public bool Inactivar(string ruc)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "UPDATE Establecimientos SET Activo = 0 WHERE RUC = @ruc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Activar(string ruc)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = "UPDATE Establecimientos SET Activo = 1 WHERE RUC = @ruc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Establecimiento ObtenerEstablecimientoPorID(int id)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = @"SELECT EstablecimientoID, RazonSocial, NombreComercial, RUC, Direccion
                         FROM Establecimientos
                         WHERE EstablecimientoID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Establecimiento
                    {
                        EstablecimientoID = (int)dr["EstablecimientoID"],
                        RazonSocial = dr["RazonSocial"].ToString(),
                        NombreComercial = dr["NombreComercial"].ToString(),
                        RUC = dr["RUC"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    };
                }
            }
            return null;
        }


    }

}
