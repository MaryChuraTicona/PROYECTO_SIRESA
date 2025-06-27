using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocios
{
    public class fiscalizacionCN
    {
        private fiscalizacionCD fiscalCD = new fiscalizacionCD();

        

        public int RegistrarFiscalizacion(Fiscalizacion f)
        {
            return fiscalCD.RegistrarFiscalizacion(f);
        }

        public List<Fiscalizacion> ObtenerFiscalizaciones()
        {
            return fiscalCD.ObtenerFiscalizaciones();
        }

        public List<Fiscalizacion> ObtenerFiscalizacionesPendientes()
        {
            return fiscalCD.ObtenerFiscalizacionesPendientes();
        }

        public List<Establecimiento> ObtenerEstablecimientos()
        {
            return fiscalCD.ObtenerEstablecimientos();
        }

        public bool EditarFiscalizacion(Fiscalizacion f)
        {
            return fiscalCD.ActualizarFiscalizacion(f);
        }

        public Fiscalizacion ObtenerFiscalizacionPorID(int id)
        {
            return fiscalCD.ObtenerFiscalizacionPorID(id);
        }

        public List<Fiscalizacion> ObtenerFiscalizacionesPorEmpleado(int empleadoID)
        {
            return fiscalCD.ObtenerFiscalizacionesPorEmpleado(empleadoID);
        }

        public bool MarcarFiscalizacionComoFinalizada(int id)
        {
            return fiscalCD.MarcarFiscalizacionComoFinalizada(id);
        }

    }
}
