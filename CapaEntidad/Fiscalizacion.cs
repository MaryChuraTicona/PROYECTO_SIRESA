using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Fiscalizacion
    {
        public int FiscalizacionID { get; set; }
        public int EstablecimientoID { get; set; }
        public string NombreEstablecimiento { get; set; } // opcional para mostrar
        public DateTime FechaFiscalizacion { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string TipoFiscalizacion { get; set; }
        public string EstadoFiscalizacion { get; set; }
        public string ResultadoFiscalizacion { get; set; }
        public string Observaciones { get; set; }
        public int? FirmaID { get; set; }
        public bool Notificado { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public int? EquipoID { get; set; }
        public int UsuarioRegistroID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string RazonSocial { get; set; } 

    }
}
