using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class rolCD
    {
        private Conexion conexion = new Conexion();

        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT RolID, NombreRol FROM Roles", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Rol
                        {
                            RolID = Convert.ToInt32(dr["RolID"]),
                            NombreRol = dr["NombreRol"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar roles: " + ex.Message);
            }

            return lista;
        }
    }
}
