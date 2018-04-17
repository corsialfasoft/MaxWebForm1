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
    <asp:Table ID="Table" runat="server" CellSpacing="30">

    </asp:Table>
    <%--<%foreach(var prodotto in Prodotti){%>
    <div class="row">
        <div class="col-md-3">
            <%=prodotto.Codice%>
        </div>
        <div class="col-md-3">
            <%=prodotto.Descrizione%>
        </div>
        <div class="col-md-3">
            <%=prodotto.Giacenza%>   
        </div>
        <div class="col-md-3">
            <asp:button runat="server" Text="Dettaglio" PostBackUrl="~/Dettaglio.aspx?id=<%{=prodotto.Codice}%>"/>
            </div>
       </div>
    <%}--%>

    } %>
</asp:Content>
