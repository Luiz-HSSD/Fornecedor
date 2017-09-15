using Core.Aplicacao;
using Dominio;

namespace Web.Command
{
    public class VisualizarCommand : AbstractCommand
    {
        public override Resultado Execute(EntidadeDominio entidade)
        {
            return fachada.visualizar(entidade);
        }
    }
}