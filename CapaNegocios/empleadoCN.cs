using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CapaNegocios
{
    public class empleadoCN
    {
        private empleadoCD empleadoData = new empleadoCD();

        public string RegistrarEmpleado(Empleado emp)
        {
            return empleadoData.InsertarEmpleado(emp);
        }

        public string EditarEmpleado(int id, Empleado emp)
        {
            return empleadoData.EditarEmpleado(id, emp);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return empleadoData.ListarEmpleados();
        }
        public Empleado BuscarEmpleadoPorDNI(string dni)
        {
            return empleadoData.ObtenerEmpleadoPorDNI(dni);
        }
        public string CambiarEstadoEmpleado(int id, bool activo)
        {
            return empleadoData.ActualizarEstadoEmpleado(id, activo);
        }
        public async Task<Empleado> ConsultarRENIECAsync(string dni)
        {
            string url = $"https://api.apis.net.pe/v2/reniec/dni?numero={dni}";
            string token = "apis-token-16356.Cza7kRgd2DHFq16BwThIrmxx8hrvOMme";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(result);

                        return new Empleado
                        {
                            NombreCompleto = $"{data["nombres"]} {data["apellidoPaterno"]} {data["apellidoMaterno"]}",
                            FechaNacimiento = data["fechaNacimiento"] != null
                                ? DateTime.Parse(data["fechaNacimiento"].ToString())
                                : DateTime.Now
                        };
                    }
                }
                catch
                {
                    
                }
            }

            return null;
        }
    }
}
