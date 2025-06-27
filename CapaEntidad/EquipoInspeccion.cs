using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class EquipoInspeccion
    {
        public int EquipoID { get; set; }
        public int FiscalizacionID { get; set; }
        public int EmpleadoID { get; set; }
        public string RolEnEquipo { get; set; }
      
    }
}
