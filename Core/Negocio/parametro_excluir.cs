using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core;
using Dominio;

namespace Core.Negocio
{
    class Parametro_excluir : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            try
            {
                if( entidade.ID==0) return "parametro de excluxão incorreto";
                return null;
            }
            catch
            {
                return "parametro de excluxão no formato incorreto";
            }
        }
    }
}
