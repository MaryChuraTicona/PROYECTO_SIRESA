using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaDatos
{
    public  class Conexion
    {
        private SqlConnection conexion;

        private string cadenaConexion = "Server=tcp:chura-mary.database.windows.net,1433;" +
                                        "Initial Catalog=SIRESA;" +
                                        "Persist Security Info=False;" +
                                        "User ID=mary-2019;" +
                                        "Password=2014120005Luz;" +
                                        "MultipleActiveResultSets=False;" +
                                        "Encrypt=True;" +
                                        "TrustServerCertificate=False;" +
                                        "Connection Timeout=30;";

        public SqlConnection AbrirConexion()
        {
            if (conexion == null)
                Console.WriteLine("Cadena: " + cadenaConexion);
            conexion = new SqlConnection(cadenaConexion);

            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;

        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
