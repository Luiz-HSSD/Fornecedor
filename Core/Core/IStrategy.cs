using Dominio;

namespace Core.Core
{
    interface IStrategy
    {
         string Processar(EntidadeDominio entidade);
    }
}
