using Dominio;
using Core.Aplicacao;

namespace Web.Command
{
    public class ConsultarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.consultar(entidade);
        }
    }
}