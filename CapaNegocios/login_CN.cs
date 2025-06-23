using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class login_CN
    {
        private login_CD datos = new login_CD();

        public Usuario IniciarSesion(string usuario, string clave)
        {
            return datos.ValidarLogin(usuario, clave);
        }
    }
}
