using Core.Aplicacao;
using Dominio;
namespace Web.Command
{
    public class AlterarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.Alterar(entidade);
        }
    }
}