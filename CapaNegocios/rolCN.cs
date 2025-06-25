using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class rolCN
    {
        private rolCD rolCD = new rolCD();

        public List<Rol> Listar()
        {
            return rolCD.Listar();
        }
    }
}
