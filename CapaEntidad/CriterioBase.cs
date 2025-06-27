using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CriterioBase
    {
        public int CriterioID { get; set; }
        public string Nombre { get; set; }
        public string NivelRiesgo { get; set; }
        public bool Activo { get; set; }
    }
}
