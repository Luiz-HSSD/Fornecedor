using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class EntidadeDominio:IEntidade
    {
        public EntidadeDominio()
        {
            id = 0;

        }

        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
