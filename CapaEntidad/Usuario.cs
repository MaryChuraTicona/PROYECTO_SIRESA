using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string UsuarioNombre { get; set; }
        public string ClaveHash { get; set; }
        public int RolID { get; set; }
        public bool Activo { get; set; }
    }
}
