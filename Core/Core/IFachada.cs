using Dominio;
using  Core.Aplicacao;

namespace Core.Core
{
    public interface IFachada
    {
         Resultado Salvar(EntidadeDominio entidade);
         Resultado Alterar(EntidadeDominio entidade);
         Resultado Excluir(EntidadeDominio entidade);
         Resultado Consultar(EntidadeDominio entidade);
         Resultado Visualizar(EntidadeDominio entidade);


    }
}
