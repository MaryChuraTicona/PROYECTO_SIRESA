using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class usuario_CN
    {
        private usuario_CD objDatos = new usuario_CD();

        public List<Usuario> Listar()
        {
            return objDatos.ListarUsuarios();
        }

        public bool Registrar(Usuario usuario)
        {
            return objDatos.RegistrarUsuario(usuario);
        }

        public bool Editar(Usuario usuario)
        {
            return objDatos.EditarUsuario(usuario);
        }

        public bool CambiarEstado(int usuarioID, bool activo)
        {
            return objDatos.CambiarEstadoUsuario(usuarioID, activo);
        }
    }
}
