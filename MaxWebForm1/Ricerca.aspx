<%@ 
    Page Title="Ricerca"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Ricerca.aspx.cs"
    Inherits="MaxWebForm1.Ricerca" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="column id">
        <asp:Label runat="server">Prodotto</asp:Label>
        <asp:TextBox ID="Codice" runat="server"></asp:TextBox>
    </div>
    <div>
    <asp:Label runat="server">Descrizione</asp:Label>
    <asp:TextBox ID="Descrizione" runat="server"></asp:TextBox>
        </div>
    <asp:Button OnClick="Unnamed_Click" runat="server" Text="Cerca" />
</asp:Content>
