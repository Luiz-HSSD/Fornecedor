using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pessoa_Juridica:Pessoa
    {
        private string cnpj;

        public string CNPJ
        {
            get { return cnpj; }
            set { cnpj = value; }
        }
        public Pessoa_Juridica():base()
        {
            cnpj = "";
        }
    }
}
