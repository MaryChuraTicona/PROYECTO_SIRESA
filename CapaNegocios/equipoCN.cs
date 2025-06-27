using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class equipoCN
    {
        private equipoCD data = new equipoCD();

        public string RegistrarEquipoInspeccion(List<EquipoInspeccion> equipo)
        {
            return data.RegistrarEquipoInspeccion(equipo);
        }

        public int ContarInspeccionesPorDia(int empleadoID, DateTime fecha)
        {
            return data.ContarInspeccionesPorDia(empleadoID, fecha);
        }

        public void AgregarInspectorAFiscalizacion(int fiscalizacionID, int empleadoID, string rol)
        {
       
        data.InsertarInspectorAFiscalizacion(fiscalizacionID, empleadoID, rol);
        }
    }
}
