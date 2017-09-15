using Core.Aplicacao;
using Dominio;

namespace Web.Command
{
    public class SalvarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.salvar(entidade);
        }
    }
}