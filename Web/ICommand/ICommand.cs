using Core.Aplicacao;
using Dominio;
namespace Web.ICommand
{
    public interface ICommand
    {
         Resultado Execute(EntidadeDominio entidade) ;
    }
}
