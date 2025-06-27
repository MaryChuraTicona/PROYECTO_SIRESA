using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class criterioCD
    {
        private Conexion conexion = new Conexion();


        public List<CriterioBase> ListarCriterios()
        {
            List<CriterioBase> lista = new List<CriterioBase>();

            using (var conn = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM CriteriosBase";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new CriterioBase
                    {
                        CriterioID = (int)dr["CriterioID"],
                        Nombre = dr["Nombre"].ToString(),
                        NivelRiesgo = dr["NivelRiesgo"].ToString(),
                        Activo = (bool)dr["Activo"]
                    });
                }
            }

            return lista;
        }

        public bool InsertarCriterio(CriterioBase c)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = "INSERT INTO CriteriosBase (Nombre, NivelRiesgo, Activo) VALUES (@Nombre, @NivelRiesgo, @Activo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@NivelRiesgo", c.NivelRiesgo);
                cmd.Parameters.AddWithValue("@Activo", c.Activo);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarCriterio(CriterioBase c)
        {
            using (var conn = conexion.AbrirConexion())
            {
                string query = "UPDATE CriteriosBase SET Nombre=@Nombre, NivelRiesgo=@NivelRiesgo, Activo=@Activo WHERE CriterioID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@NivelRiesgo", c.NivelRiesgo);
                cmd.Parameters.AddWithValue("@Activo", c.Activo);
                cmd.Parameters.AddWithValue("@ID", c.CriterioID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    
    public List<CriterioEvaluado> ObtenerCriteriosPrecargados()
        {
            List<CriterioEvaluado> lista = new List<CriterioEvaluado>();

            using (var conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT Numero, Criterio, NivelRiesgo FROM CriteriosEvaluados WHERE FiscalizacionID IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new CriterioEvaluado
                    {
                        Numero = dr["Numero"].ToString(),
                        Criterio = dr["Criterio"].ToString(),
                        NivelRiesgo = dr["NivelRiesgo"].ToString(),
                        Resultado = "NO", // Por defecto
                        Observacion = ""
                    });
                }
            }

            return lista;
        }
        public string RegistrarCriteriosEvaluados(List<CriterioEvaluado> lista)
        {
            using (var conn = new Conexion().AbrirConexion())
            {
                foreach (var c in lista)
                {
                    string query = @"INSERT INTO CriteriosEvaluados 
(FiscalizacionID, Criterio, Resultado, Observacion, Numero, NivelRiesgo, Evidencia)
VALUES (@FiscalizacionID, @Criterio, @Resultado, @Observacion, @Numero, @NivelRiesgo, @Evidencia)";


                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FiscalizacionID", c.FiscalizacionID);
                    cmd.Parameters.AddWithValue("@Numero", c.Numero);
                    cmd.Parameters.AddWithValue("@Criterio", c.Criterio);
                    cmd.Parameters.AddWithValue("@NivelRiesgo", c.NivelRiesgo);
                    cmd.Parameters.AddWithValue("@Resultado", c.Resultado);
                    cmd.Parameters.AddWithValue("@Observacion", c.Observacion ?? "");
                    cmd.Parameters.AddWithValue("@Evidencia", c.Evidencia ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }

            return "OK";
        }


    }
}
