using Core.Aplicacao;
using Dominio;

namespace Web.Command
{
    public class ExcluirCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.excluir(entidade);
        }
    }
}