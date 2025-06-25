using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class login_CN
    {
        private login_CD datos = new login_CD();

        public Usuario IniciarSesion(string usuario, string clavePlano)
        {
            string claveHash = GenerarHash(clavePlano); // Aquí aplicamos el hash SHA256
            return datos.ValidarLogin(usuario, claveHash);
        }

        private string GenerarHash(string textoPlano)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano.Trim());
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
