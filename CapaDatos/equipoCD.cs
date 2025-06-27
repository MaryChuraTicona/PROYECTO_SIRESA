using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class equipoCD
    {
        public string RegistrarEquipoInspeccion(List<EquipoInspeccion> equipo)
        {
            using (var conn = new Conexion().AbrirConexion())
            {
                foreach (var e in equipo)
                {
                    string query = @"INSERT INTO EquiposInspeccion (FiscalizacionID, EmpleadoID, RolEnEquipo,)
VALUES (@FiscalizacionID, @EmpleadoID, @RolEnEquipo, )";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FiscalizacionID", e.FiscalizacionID);
                    cmd.Parameters.AddWithValue("@EmpleadoID", e.EmpleadoID);
                    cmd.Parameters.AddWithValue("@RolEnEquipo", e.RolEnEquipo);
                   
                    cmd.ExecuteNonQuery();
                }
            }

            return "OK";
        }


        public void InsertarInspectorAFiscalizacion(int fiscalizacionID, int empleadoID, string rol)
        {
            using (SqlConnection con = new  Conexion().AbrirConexion())
            {
                string query = @"INSERT INTO EquiposInspeccion (FiscalizacionID, EmpleadoID, RolEnEquipo)
                             VALUES (@FiscalizacionID, @EmpleadoID, @RolEnEquipo)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FiscalizacionID", fiscalizacionID);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                cmd.Parameters.AddWithValue("@RolEnEquipo", rol);

                cmd.ExecuteNonQuery();
            }
        }

        public int ContarInspeccionesPorDia(int empleadoID, DateTime fecha)
        {
            int cantidad = 0;
            using (var conn = new  Conexion().AbrirConexion())
            {
                string query = @"
                SELECT COUNT(*) FROM EquiposInspeccion ei
                INNER JOIN Fiscalizaciones f ON ei.FiscalizacionID = f.FiscalizacionID
                WHERE ei.EmpleadoID = @empleadoID AND CAST(f.FechaFiscalizacion AS DATE) = @fecha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@empleadoID", empleadoID);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return cantidad;
        }
    }
}