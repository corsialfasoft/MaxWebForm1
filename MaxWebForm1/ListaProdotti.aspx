<%@ 
    Page Title="Lista Prodotti"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="ListaProdotti.aspx.cs"
    Inherits="MaxWebForm1.ListaProdotti" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
<%if (Prodotti.Count!= 0) {%>
    <div class="row">
          <div class="col-md-3">
            <label runat="server">Codice</label>
        </div>
        <div class="col-md-3">
            <asp:label runat="server">Descrizione</asp:label>
        </div>
        <div class="col-md-3">
            <asp:label runat="server">Giacenza</asp:label>
        </div>
        </div>
    <asp:Table
        ID="Table22" 
        runat="server" 
        GridLines="Both" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="45" 
        CellSpacing="0">

    </asp:Table>
    <%} %>
</asp:Content>
