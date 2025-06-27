using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class cambioCN
    {
        private cambioCD data = new cambioCD();

        public void RegistrarCambio(Cambio cambio)
        {
            data.RegistrarCambio(cambio);
        }

        public List<Acceso> ObtenerAccesos(int? usuarioID, DateTime? desde, DateTime? hasta)
        {
            return data.ListarAccesos(usuarioID, desde, hasta);
        }


        public List<Usuario> ObtenerUsuarios()
        {
            return data.ObtenerUsuarios();
        }
    }

}
