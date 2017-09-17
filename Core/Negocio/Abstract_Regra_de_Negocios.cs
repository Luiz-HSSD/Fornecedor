using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core;
using Dominio;

namespace Core.Negocio
{
    abstract class Abstract_Regra_de_Negocios : IStrategy
    {
        protected StringBuilder sb = new StringBuilder();
        public abstract string Processar(EntidadeDominio entidade);
    }
}
