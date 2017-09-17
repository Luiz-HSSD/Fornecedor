using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;

namespace Core.DAO
{
    public class FornecedorDAO : AbstractDAO
    {
        public FornecedorDAO() : base("fornecedor", "forne_id")
        {
        }

        public override void salvar(EntidadeDominio entidade)
        {
            connection.Open();
            Fornecedor categoria = (Fornecedor)entidade;
            pst.CommandText = "insert into fornecedor ( cnpj , fornecedor_nome ) values ( :des , :nome )";
            parameters = new OracleParameter[]
                    {
                        new OracleParameter("des",categoria.CNPJ),
                        new OracleParameter("nome",categoria.Nome)
                    };
            pst.Parameters.Clear();
            pst.Parameters.AddRange(parameters);
            pst.Connection = connection;
            pst.CommandType = CommandType.Text;
            pst.ExecuteNonQuery();
            pst.CommandText = "commit work";
            pst.ExecuteNonQuery();
            connection.Close();
            return;
        }

        public override void alterar(EntidadeDominio entidade)
        {
            try
            {
                connection.Open();
                Fornecedor categoria = (Fornecedor)entidade;
                pst.CommandText = "UPDATE fornecedor SET cnpj=:des, fornecedor_nome=:nome WHERE forne_id=:co";
                parameters = new OracleParameter[]
                    {
                        new OracleParameter("des",categoria.CNPJ),
                        new OracleParameter("nome",categoria.Nome),
                        new OracleParameter("co",categoria.ID)

                    };
                pst.Parameters.Clear();
                pst.Parameters.AddRange(parameters);
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                vai = pst.ExecuteReader();
                vai.Read();
                pst.CommandText = "commit work";
                vai = pst.ExecuteReader();
                vai.Read();
                pst.ExecuteNonQuery();
                connection.Close();
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public override List<EntidadeDominio> consultar(EntidadeDominio entidade)
        {
            try
            {
                connection.Open();
                pst.Dispose();
                Fornecedor categoria = (Fornecedor)entidade;
                string sql = null;

                if (categoria.Nome == null)
                {
                    categoria.Nome = "";
                }

                if (categoria.CNPJ == null)
                {
                    categoria.CNPJ = "";
                }

                if (categoria.ID == 0)
                {
                    sql = "SELECT * FROM fornecedor";
                }
                else
                {
                    sql = "SELECT * FROM fornecedor WHERE forne_id= :co";
                }


                pst.CommandText = sql;
                parameters = new OracleParameter[] { new OracleParameter("co", categoria.ID.ToString()) };
                pst.Parameters.Clear();
                pst.Parameters.AddRange(parameters);
                pst.Connection = connection;
                pst.CommandType = CommandType.Text;
                //pst.ExecuteNonQuery();
                vai = pst.ExecuteReader();
                List<EntidadeDominio> entidades = new List<EntidadeDominio>();
                Fornecedor p;
                while (vai.Read())
                {
                    p = new Fornecedor()
                    {
                        ID = Convert.ToInt32(vai["forne_id"]),
                        Nome = (vai["fornecedor_nome"].ToString()),
                        CNPJ = (vai["cnpj"].ToString().Trim())
                    };
                    p.CNPJ = p.CNPJ.Substring(0, 2) + "." + p.CNPJ.Substring(2, 3) + "." + p.CNPJ.Substring(5, 3) + "/" + p.CNPJ.Substring(8, 4) + "-" + p.CNPJ.Substring(12, 2);
                    entidades.Add(p);
                }
                connection.Close();
                return entidades;
            }
            catch (OracleException ora)
            {
                throw ora;
            }


        }
    }
}
