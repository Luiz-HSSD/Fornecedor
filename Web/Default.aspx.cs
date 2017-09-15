using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Oracle.DataAccess.Client;
using System.Text;

namespace Web
{
    public partial class _Default : Viewgenerico
    {
        private Fornecedor forne = new Fornecedor();

        private void Pesquisar()
        {
            int evade = 0;
            string GRID = "<TABLE class='display' id='GridViewcat'><THEAD>{0}</THEAD><TBODY>{1}</TBODY></TABLE>";
            string tituloColunas = "<tr><th></th><th>Código</th><th>Nome</th><th>CNPJ</th></tr>";
            string linha = "<tr><td> <a href='Default.aspx?cod={0}'>editar</a> ";
            linha += "<a href='Default.aspx?del={0}'>apagar</a></td><td>{0}</td><td>{1}</td><td>{2}</td></tr>";

            forne.ID = 0;
            Res = Commands["CONSULTAR"].Execute(forne);
            try
            {
                evade = Res.Entidades.Count;
            }
            catch
            {
                evade = 0;
            }
            StringBuilder conteudo = new StringBuilder();
            for (int i = 0; i < evade; i++)
            {
                forne = (Fornecedor)Res.Entidades.ElementAt(i);
                conteudo.AppendFormat(linha,
                    forne.ID.ToString(),
                    forne.Nome.ToString(),
                    forne.CNPJ.ToString());


            }
            string tabelafinal = string.Format(GRID, tituloColunas, conteudo.ToString());
            divTable.InnerHtml = tabelafinal;
            forne.ID = 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    Pesquisar();
                    if (!string.IsNullOrEmpty(Request.QueryString["cod"]))
                    {
                        forne.ID = Convert.ToInt32(Request.QueryString["cod"]);
                        Res = Commands["CONSULTAR"].Execute(forne);
                        forne = (Fornecedor)Res.Entidades.ElementAt(0);
                        txtcod.Text = Convert.ToString(forne.ID);
                        txtnome.Text = forne.Nome;
                        txtcnpj.Text = forne.CNPJ;

                    }
                    else
                    {
                        //verificr edição
                        if (!string.IsNullOrEmpty(Request.QueryString["del"]))
                        {

                            forne.ID = Convert.ToInt32(Request.QueryString["del"]);
                            Commands["EXCLUIR"].Execute(forne);
                            Response.Redirect("Default.aspx");
                        }

                    }

                    //carregando caixa listagem

                }
            }
            catch (OracleException E)
            {
                // Response.Redirect("~/Default.aspx", false);
                throw E;
            }
        }

        protected void Novo_for_Click(object sender, EventArgs e)
        {
            forne.Nome = txtnome.Text;
            forne.CNPJ = txtcnpj.Text;
            Commands["SALVAR"].Execute(forne);
            txtcod.Text = "";
            txtnome.Text = "";
            txtcnpj.Text = "";
            Pesquisar();
        }

        protected void Alterar_for_Click(object sender, EventArgs e)
        {
            forne.ID = Convert.ToInt32(txtcod.Text);
            forne.Nome = txtnome.Text;
            forne.CNPJ = txtcnpj.Text;
            Commands["ALTERAR"].Execute(forne);
            txtcod.Text = "";
            txtnome.Text = "";
            txtcnpj.Text = "";
            Pesquisar();
        }

        protected void Cancelar_for_Click(object sender, EventArgs e)
        {
            txtcod.Text = "";
            txtnome.Text = "";
            txtcnpj.Text = "";
        }
    }
}