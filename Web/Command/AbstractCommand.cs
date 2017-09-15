using Core.Aplicacao;
using Dominio;
using Core.Core;
using Core.Controle;

namespace Web.Command
{
    public abstract class AbstractCommand : ICommand.ICommand
    {
        protected IFachada fachada = Fachada.UniqueInstance;

        public abstract Resultado Execute(EntidadeDominio entidade);
       
    }
}