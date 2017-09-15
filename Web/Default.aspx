<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<table border="1" class="auto-style1">
        <tr>
            <td colspan="5">
                <h1>cadastro fornecedor</h1>
            </td>
        </tr>
        <tr>
            <td colspan="2"><b>Código: </b></td>
            <td colspan="3">
                       <asp:Label  ID="txtcod" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="2">Nome: </td>
            <td colspan="3">
                <asp:TextBox TextMode="SingleLine" ID="txtnome" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">CNPJ: </td>
            <td colspan="3">
                        <asp:TextBox TextMode="SingleLine" MaxLength="14" ID="txtcnpj" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button runat="server" Text="novo" id="novo_for" OnClick="Novo_for_Click"  />
            </td>
            <td class="auto-style3">
                <asp:Button runat="server" Text="alterar" id="alterar_for" OnClick="Alterar_for_Click"  />
            </td>
            <td class="auto-style4">
               <asp:Button runat="server" Text="cancelar" id="cancelar_for" OnClick="Cancelar_for_Click" />
            </td>
        </tr>
    </table>
            <br />
      <div id="divTable" runat="server" style="padding:30px; width: 998px; height: 1px;">
      <table class="auto-style19">
          <tr>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
              <td>&nbsp;</td>
          </tr>
          <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
          </tr>
      </table>
      </div>
      <asp:GridView runat="server" CssClass="display" ID="GridViewcat" EnableModelValidation="True" Width="204px" >
  <HeaderStyle Font-Bold="true" />
                    </asp:GridView >
</asp:Content>
