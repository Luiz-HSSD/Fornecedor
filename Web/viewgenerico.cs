using Core.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Command;

namespace Web
{
    public class Viewgenerico : System.Web.UI.Page
    {
        protected  Resultado Res { get; set; } = new Resultado();
        protected  Dictionary<string, ICommand.ICommand> Commands { get; set; } = new Dictionary<string, ICommand.ICommand>();

        public static string Erro(string msg)
        {
            string[] vai = msg.Split('\n');
            string res = "";
            if (vai.Length == 0)
                return null;
            foreach (string fire in vai)
            {
                res += fire + "<br />";
            }
            return res;
        }
        public Viewgenerico()
        {
            Commands.Add("SALVAR", new SalvarCommand());
            Commands.Add("ALTERAR", new AlterarCommand());
            Commands.Add("EXCLUIR", new ExcluirCommand());
            Commands.Add("CONSULTAR", new ConsultarCommand());
            Commands.Add("VISUALIZAR", new VisualizarCommand());
        }
               
    }
}