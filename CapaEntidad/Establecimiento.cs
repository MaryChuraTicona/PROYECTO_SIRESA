using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Establecimiento
    {
        public int EstablecimientoID { get; set; }
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string EstadoContribuyente { get; set; }
        public string CondicionContribuyente { get; set; }
        public string Ubigeo { get; set; }
        public string TipoNegocio { get; set; }
        public string EstadoSanitario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioRegistroID { get; set; }
    }
}
