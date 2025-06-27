using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class criterioCN
    {
        private criterioCD criterioData = new criterioCD();

        public List<CriterioEvaluado> ObtenerCriteriosPrecargados()
        {
            return criterioData.ObtenerCriteriosPrecargados();
        }
        public string RegistrarCriteriosEvaluados(List<CriterioEvaluado> lista)
        {
            return criterioData.RegistrarCriteriosEvaluados(lista);
        }

        public List<CriterioBase> ObtenerCriterios()
        {
            return criterioData.ListarCriterios();
        }

        public bool RegistrarCriterio(CriterioBase c)
        {
            return criterioData.InsertarCriterio(c);
        }

        public bool EditarCriterio(CriterioBase c)
        {
            return criterioData.ActualizarCriterio(c);
        }
    }
}

