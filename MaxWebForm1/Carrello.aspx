<%@ 
    Page Title="Lista Prodotti"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Carrello.aspx.cs"
    Inherits="MaxWebForm1.Carrello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
      <asp:Table
        ID="Table24" 
        runat="server" 
        GridLines="Both" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="45" 
        CellSpacing="0">

    </asp:Table>
</asp:Content>
