<%@ 
    Page Title="Carrello"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Carrello.aspx.cs"
    Inherits="MaxWebForm1.Carrello" %>
<%@Register TagPrefix="Nauman" TagName="ProductList" Src="~/Controlli/ProductList.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
<%if (prodottos.Count>0){ %>
     <Nauman:ProductList ID="CarrelloPage" runat="server" IsQuantitaEnabled="true" IsEliminaEnabled="true" />
    <div class="row">
        <asp:Button runat="server" OnClick="Compra_Click" Text="Compra" />
        <asp:Button runat="server" OnClick="Svuota_Click" Text="Svuota il Carrello" />
        <asp:Button runat="server" Text="Indietro"/>
    </div>
    <%}%>
    <%if (Message != null){ %>
        <div class="text-warning">
            <h3><%= Message %></h3>
        </div>
    <%}%>
</asp:Content>
