<%@ 
    Page Title="Dettaglio"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Dettaglio.aspx.cs"
    Inherits="MaxWebForm1.Dettaglio" %>
<%@Register TagPrefix="Nauman" TagName="Prodotto" Src="~/Controlli/DettaglioProdotto.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <%if(Message != null){ %>
    <h3><%=Message %></h3>
    <%} %>
    <%if (prodotto.Codice != 0){ %>
   <Nauman:Prodotto ID="Prodotto" runat="server" />
       <div class="col-md-4">
        <asp:Label runat="server">Quantità desiderata</asp:Label>
        </div>
    <div class="col-md-4">
        <asp:TextBox runat="server" ID="Quantita" TextMode="Number"></asp:TextBox>
    </div><br />
        <asp:Button runat="server" Text="Aggiungi" OnClick="Aggiungi"/>
   
    <%} %>
        <asp:Button runat="server" Text="Indietro" OnClick="Indietro"/>
</asp:Content>
