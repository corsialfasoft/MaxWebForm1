<%@ 
    Page Title="Carrello"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Carrello.aspx.cs"
    Inherits="MaxWebForm1.Carrello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
<%if (prodottos.Count>0){ %>
      <asp:Table
        ID="Table24" 
        runat="server" 
        GridLines="Both" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="25" 
        CellSpacing="0">

    </asp:Table>
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
