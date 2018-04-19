<%@ 
    Page Title="Lista Prodotti"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="ListaProdotti.aspx.cs"
    Inherits="MaxWebForm1.ListaProdotti" %>
   <%@Register TagPrefix="Nauman" TagName="ProductList" Src="~/Controlli/ProductList.ascx"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
<%if (Messaggio!= null) { %>
    <div class="text-warning">
        <h4><%=Messaggio %></h4>
    </div>
    <%} %>
<%if (Prodotti.Count!= 0) {%>
    <Nauman:ProductList ID="Lista" runat="server" IsDetailEnabled="true" IsGiacenzaEnabled="true" />
    <%} %>
</asp:Content>
