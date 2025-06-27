using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class usuario_CD
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"SELECT u.UsuarioID, u.NombreCompleto, u.DNI, u.Correo, u.Telefono,
                                u.Usuario, u.ClaveHash, u.RolID, r.NombreRol, u.Activo
                                FROM Usuarios u
                                JOIN Roles r ON u.RolID = r.RolID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        UsuarioID = (int)dr["UsuarioID"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        DNI = dr["DNI"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        UsuarioNombre = dr["Usuario"].ToString(),   // ⬅ aquí el cambio
                        ClaveHash = dr["ClaveHash"].ToString(),
                        RolID = (int)dr["RolID"],
                        Activo = (bool)dr["Activo"]
                    });
                }
                dr.Close();
            }
            return lista;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"INSERT INTO Usuarios (NombreCompleto, DNI, Correo, Telefono, Usuario, ClaveHash, RolID, Activo)
                                 VALUES (@NombreCompleto, @DNI, @Correo, @Telefono, @Usuario, @ClaveHash, @RolID, @Activo)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                cmd.Parameters.AddWithValue("@ClaveHash", usuario.ClaveHash);
                cmd.Parameters.AddWithValue("@RolID", usuario.RolID);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EditarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"UPDATE Usuarios SET 
                                 NombreCompleto = @NombreCompleto,
                                 DNI = @DNI,
                                 Correo = @Correo,
                                 Telefono = @Telefono,
                                 Usuario = @Usuario,
                                 ClaveHash = @ClaveHash,
                                 RolID = @RolID,
                                 Activo = @Activo
                                 WHERE UsuarioID = @UsuarioID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                cmd.Parameters.AddWithValue("@ClaveHash", usuario.ClaveHash);
                cmd.Parameters.AddWithValue("@RolID", usuario.RolID);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CambiarEstadoUsuario(int usuarioID, bool activo)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "UPDATE Usuarios SET Activo = @Activo WHERE UsuarioID = @UsuarioID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

