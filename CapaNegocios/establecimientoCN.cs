using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class establecimientoCN
    {
        private establecimientoCD datos = new establecimientoCD();

        public bool Registrar(Establecimiento est)
        {
            return datos.Registrar(est);
        }

        public List<Establecimiento> Listar()
        {
            return datos.Listar();
        }

        public bool ExisteRUC(string ruc)
        {
            return datos.ExisteRUC(ruc);
        }

        public bool Inactivar(string ruc)
        {
            return datos.Inactivar(ruc);  
        }
        public List<Establecimiento> Listar(bool mostrarTodos)
        {
            return datos.Listar(mostrarTodos);
        }

        public bool Activar(string ruc)
        {
            return datos.Activar(ruc);
        }

        public Establecimiento ObtenerEstablecimientoPorID(int id)
        {
            return datos.ObtenerEstablecimientoPorID(id);
        }


    }

}
