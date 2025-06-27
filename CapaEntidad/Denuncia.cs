using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Denuncia
    {
        public string RUC { get; set; }
        public string NombreEstablecimiento { get; set; }
        public string DireccionEstablecimiento { get; set; }
        public int DenunciaID { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public int? UsuarioAtiendeID { get; set; }
        public string Respuesta { get; set; }
    }
}
