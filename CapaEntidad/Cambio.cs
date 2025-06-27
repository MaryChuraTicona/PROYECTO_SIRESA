using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cambio
    {
        public int CambioID { get; set; }
        public int UsuarioID { get; set; }
        public string TablaAfectada { get; set; }
        public int IDReferencia { get; set; }
        public string TipoCambio { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCambio { get; set; }
    }

    public class Acceso
    {
        public int AccesoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
        public string IP { get; set; }
        public string Tipo { get; set; }
        public string NombreCompleto { get; set; } 
    }

}
