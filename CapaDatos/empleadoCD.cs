using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class empleadoCD
    {
        private Conexion conexion = new Conexion();

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                SqlConnection con = conexion.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EmpleadosRegistrados", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Empleado
                        {
                            EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]),
                            DNI = dr["DNI"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Edad = Convert.ToInt32(dr["Edad"]),
                            Correo = dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Especialidad = dr["Especialidad"].ToString(),
                            RolID = Convert.ToInt32(dr["RolID"]),
                            SupervisorID = dr["SupervisorID"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["SupervisorID"]),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        });
                    }
                    dr.Close();
                }

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                
            }

            return lista;
        }

        public string InsertarEmpleado(Empleado emp)
        {
            SqlConnection conn = null;
            try
            {
                conn = conexion.AbrirConexion(); // Abre la conexión manualmente

                string verificarQuery = "SELECT COUNT(*) FROM EmpleadosRegistrados WHERE DNI = @DNI";
                SqlCommand verificarCmd = new SqlCommand(verificarQuery, conn);
                verificarCmd.Parameters.AddWithValue("@DNI", emp.DNI);
                int existe = (int)verificarCmd.ExecuteScalar();

                if (existe > 0)
                {
                    return "Ya existe un empleado registrado con este DNI.";
                }

              
                string query = @"INSERT INTO EmpleadosRegistrados 
                        (DNI, NombreCompleto, FechaNacimiento, Edad, Correo, Telefono, Direccion, Especialidad, RolID, SupervisorID, Activo, FechaRegistro)
                        VALUES 
                        (@DNI, @NombreCompleto, @FechaNacimiento, @Edad, @Correo, @Telefono, @Direccion, @Especialidad, @RolID, @SupervisorID, @Activo, @FechaRegistro)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                cmd.Parameters.AddWithValue("@NombreCompleto", emp.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", emp.Direccion);
                cmd.Parameters.AddWithValue("@Especialidad", emp.Especialidad);
                cmd.Parameters.AddWithValue("@RolID", emp.RolID);
                cmd.Parameters.AddWithValue("@SupervisorID", (object)emp.SupervisorID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", emp.Activo);
                cmd.Parameters.AddWithValue("@FechaRegistro", emp.FechaRegistro);

                cmd.ExecuteNonQuery();

                return "Empleado registrado correctamente.";
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar empleado: " + ex.Message, ex);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    conexion.CerrarConexion();
            }
        }
        public string EditarEmpleado(int id, Empleado emp)
        {
            using (SqlConnection conn = conexion.AbrirConexion())
            {
                string query = @"UPDATE EmpleadosRegistrados SET 
                         DNI = @DNI,
                         NombreCompleto = @NombreCompleto,
                         FechaNacimiento = @FechaNacimiento,
                         Edad = @Edad,
                         Correo = @Correo,
                         Telefono = @Telefono,
                         Direccion = @Direccion,
                         Especialidad = @Especialidad,
                         RolID = @RolID,
                         SupervisorID = @SupervisorID,
                         Activo = @Activo
                         WHERE EmpleadoID = @EmpleadoID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", id);
                cmd.Parameters.AddWithValue("@DNI", emp.DNI);
                cmd.Parameters.AddWithValue("@NombreCompleto", emp.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNacimiento", emp.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", emp.Edad);
                cmd.Parameters.AddWithValue("@Correo", emp.Correo);
                cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", emp.Direccion);
                cmd.Parameters.AddWithValue("@Especialidad", emp.Especialidad);
                cmd.Parameters.AddWithValue("@RolID", emp.RolID);
                cmd.Parameters.AddWithValue("@SupervisorID", (object)emp.SupervisorID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", emp.Activo);

                cmd.ExecuteNonQuery();
                return "Empleado actualizado correctamente";
            }
        }


        public string ActualizarEstadoEmpleado(int empleadoID, bool estado)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE EmpleadosRegistrados SET Activo = @Estado WHERE EmpleadoID = @EmpleadoID", con);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                cmd.Parameters.AddWithValue("@Estado", estado);
                int filas = cmd.ExecuteNonQuery();
                return filas > 0 ? "Estado actualizado correctamente" : "No se pudo actualizar el estado";
            }
        }


        public Empleado ObtenerEmpleadoPorDNI(string dni)
        {
            Empleado emp = null;

            using (SqlConnection con = new Conexion().AbrirConexion())
            {
                string query = "SELECT * FROM EmpleadosRegistrados WHERE DNI = @dni";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@dni", dni);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Empleado
                    {
                        EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]),
                        DNI = dr["DNI"].ToString(),
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Edad = CalcularEdad(Convert.ToDateTime(dr["FechaNacimiento"])),
                        Correo = dr["Correo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Especialidad = dr["Especialidad"].ToString(),
                        RolID = Convert.ToInt32(dr["RolID"]),
                        SupervisorID = dr["SupervisorID"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["SupervisorID"]),

                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                        Activo = Convert.ToBoolean(dr["Activo"])
                    };
                }
                dr.Close();
            }

            return emp;
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now < fechaNacimiento.AddYears(edad)) edad--;
            return edad;
        }

    }
}