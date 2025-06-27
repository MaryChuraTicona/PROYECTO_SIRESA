using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CriterioEvaluado
    {
        public int CriterioID { get; set; }
        public int FiscalizacionID { get; set; }
        public string Numero { get; set; }
        public string Criterio { get; set; }
        public string NivelRiesgo { get; set; } 
        public string Resultado { get; set; } 
        public string Observacion { get; set; }
        public string Evidencia { get; set; }

    }
}
