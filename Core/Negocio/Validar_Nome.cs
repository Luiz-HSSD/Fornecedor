using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core;
using Dominio;
using System.Text.RegularExpressions;

namespace Core.Negocio
{
    class Validar_Nome : Abstract_Regra_de_Negocios
    {
        public override string Processar(EntidadeDominio entidade)
        {
            Pessoa pe = (Pessoa)entidade;
            sb = new  StringBuilder( null);
            if(pe.Nome.Length<3)
                sb.Append("nome pequeno demais");
            if(pe.Nome.Length>40)
                sb.Append("nome excede o limite de caracteres");
            foreach (char s in pe.Nome)
            {
                if (char.IsDigit(s))
                {
                    if (String.IsNullOrEmpty(sb.ToString()))
                        sb.Append("há numeros neste nome");
                    else
                        sb.Append("\nhá numeros neste nome");
                }


            }
            if (Regex.IsMatch(pe.Nome, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                if (String.IsNullOrEmpty(sb.ToString()))
                    sb.Append("há caractere especial no nome");
                else
                    sb.Append("\nhá caractere especial no nome");
            }
            return sb.ToString(); 
        }
    }
}
