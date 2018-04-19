<%@ Control Language="C#" 
    AutoEventWireup="true"
    CodeBehind="DettaglioProdotto.ascx.cs"
    Inherits="MaxWebForm1.Controlli.Dettaglio" %>

    <div class="col-md-4">
        <asp:Label runat="server">Codice</asp:Label>
    </div>
    <div class="col-md-4">
        <asp:Label ID="codice" runat="server"><%=product.Codice %></asp:Label>
    </div> <br />
    <div class="col-md-4">
    <asp:Label runat="server">Prodotto</asp:Label>
        </div>
    <div class="col-md-4">
    <asp:Label ID="descrizione" runat="server"><%=product.Descrizione %></asp:Label>
        </div>
    <br />
    <div class="col-md-4">
         <asp:Label runat="server">Giacenza</asp:Label>
        </div>
    <div class="col-md-4">
    <asp:Label ID="Giacenza" runat="server"><%=product.Giacenza %></asp:Label>
    </div><br />
