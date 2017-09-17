using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aplicacao;
using Dominio;
using Core.DAO;
using Core.Negocio;

namespace Core.Controle
{
    public sealed class Fachada : IFachada
    {


        /** 
         * Mapa de DAOS, será indexado pelo nome da entidade 
         * O valor é uma instância do DAO para uma dada entidade; 
         */
        private Dictionary<string, IDAO> daos;

        /**
         * Mapa para conter as regras de negócio de todas operações por entidade;
         * O valor é um mapa que de regras de negócio indexado pela operação
         */
        private Dictionary<string, Dictionary<string, List<IStrategy>>> rns;

        private Resultado resultado;
        private Fachada()
        {
            daos = new Dictionary<string, IDAO>();
            /* Intânciando o Map de Regras de Negócio */
            rns = new Dictionary<string, Dictionary<string, List<IStrategy>>>();
            
            Parametro_excluir para_ex = new Parametro_excluir();
            ValidarCNPJ val_cnpj = new ValidarCNPJ();
            Validar_Nome validar_Nome = new Validar_Nome();
            FornecedorDAO forneDAO = new FornecedorDAO();
            daos.Add(typeof(Fornecedor).Name, forneDAO);
            List<IStrategy> rnsSalvarFornecedor = new List<IStrategy>()
            {
                validar_Nome,
                val_cnpj
            };
            List<IStrategy> rnsAlterarFornecedor = new List<IStrategy>()
            {
                validar_Nome,
                val_cnpj
            };
            List<IStrategy> rnsExcluirFornecedor = new List<IStrategy>
            {
                para_ex
            };
            List<IStrategy> rnsConsultarFornecedor = new List<IStrategy>();
            Dictionary<string, List<IStrategy>> rnsFornecedor = new Dictionary<string, List<IStrategy>>
            {
                { "SALVAR", rnsSalvarFornecedor },
                { "ALTERAR", rnsAlterarFornecedor },
                { "EXCLUIR", rnsExcluirFornecedor },
                { "CONSULTAR", rnsConsultarFornecedor }
            };
            rns.Add(typeof(Fornecedor).Name, rnsFornecedor);
        }
        private static readonly Fachada Instance = new Fachada();

        public static Fachada UniqueInstance
        {
            get { return Instance; }
        }
        public Resultado Salvar(EntidadeDominio entidade)
        {
            resultado = new Resultado();
            string nmClasse = entidade.GetType().Name;

            string msg = ExecutarRegras(entidade, "SALVAR");


            if (msg == null)
            {
                IDAO dao = daos[nmClasse];

                dao.salvar(entidade);
                List<EntidadeDominio> entidades = new List<EntidadeDominio>
                {
                    entidade
                };
                resultado.Entidades=entidades;

            }
            else
            {
                resultado.Msg=msg;


            }

            return resultado;
        }

        public Resultado Alterar(EntidadeDominio entidade)
        {
            resultado = new Resultado();
            string nmClasse = entidade.GetType().Name;
            string msg = ExecutarRegras(entidade, "ALTERAR");

            if (msg == null)
            {
                IDAO dao = daos[nmClasse];
                dao.alterar(entidade);
                List<EntidadeDominio> entidades = new List<EntidadeDominio>
                {
                    entidade
                };
                resultado.Entidades=entidades;
            }
            else
            {
                resultado.Msg=msg;


            }

            return resultado;

        }


        public Resultado Excluir(EntidadeDominio entidade)
        {
            resultado = new Resultado();
            string nmClasse = entidade.GetType().Name;
            string msg = ExecutarRegras(entidade, "EXCLUIR");


            if (msg == null)
            {
                IDAO dao = daos[nmClasse];
                dao.excluir(entidade);
                List<EntidadeDominio> entidades = new List<EntidadeDominio>
                {
                    entidade
                };
                resultado.Entidades=entidades;
            }
            else
            {
                resultado.Msg=msg;
            }

            return resultado;

        }

        public Resultado Consultar(EntidadeDominio entidade)
        {
            resultado = new Resultado();
            string nmClasse = entidade.GetType().Name;
            string msg = ExecutarRegras(entidade, "CONSULTAR");


            if (msg == null)
            {
                IDAO dao = daos[nmClasse];
                try
                {

                    resultado.Entidades=dao.consultar(entidade);
                }
                catch
                {

                }
            }
            else
            {
                resultado.Msg=msg;

            }

            return resultado;

        }

        public Resultado Visualizar(EntidadeDominio entidade)
        {
            resultado = new Resultado
            {
                Entidades = new List<EntidadeDominio>(1)
            };
            resultado.Entidades.Add(entidade);
            return resultado;

        }
        
        
        private string ExecutarRegras(EntidadeDominio entidade, string operacao)
        {
            string nmClasse = entidade.GetType().Name;
            StringBuilder msg = new StringBuilder();

            Dictionary<string, List<IStrategy>> regrasOperacao = rns[nmClasse];


            if (regrasOperacao != null)
            {
                List<IStrategy> regras = regrasOperacao[operacao];

                if (regras != null)
                {
                    foreach (IStrategy s in regras)
                    {
                        string m = s.Processar(entidade);

                        if (!String.IsNullOrEmpty(m))
                        {
                            msg.Append(m);
                            msg.Append("\n");
                        }
                    }
                }

            }

            if (msg.Length > 0)
                return msg.ToString();
            else
                return null;


        }
    }
    
}

