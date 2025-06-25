using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class login_CD
    {
        private Conexion conexion = new Conexion();

        public Usuario ValidarLogin(string usuario, string clave)
        {
            Usuario u = null;

            using (var conn = conexion.AbrirConexion())
            {
                string query = @"
            SELECT UsuarioID, NombreCompleto, Usuario, RolID, Activo 
            FROM Usuarios 
            WHERE Usuario = @usuario 
              AND ClaveHash = @claveHash 
              AND Activo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@claveHash", clave); // AQUÍ se genera el hash en C#

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    u = new Usuario
                    {
                        UsuarioID = (int)dr["UsuarioID"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        UsuarioNombre = dr["Usuario"].ToString(),
                        RolID = (int)dr["RolID"],
                        Activo = (bool)dr["Activo"]
                    };
                }
            }

            return u;
        }

       

    }
}
