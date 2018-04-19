<%@ 
    Page Title="Ricerca"
    Language="C#"
    MasterPageFile="~/Site.Master
    " AutoEventWireup="true"
    CodeBehind="Ricerca.aspx.cs"
    Inherits="MaxWebForm1.Ricerca" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
     <asp:CustomValidator id="CustomValidator1"
           Display="Static"
           ErrorMessage="Inserire almeno uno dei campi!"
           ForeColor="green"
           Font-Names="verdana" 
           Font-Size="10pt"
           OnServerValidate="Controllo"
           runat="server"/>

      <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Label runat="server">Prodotto</asp:Label>
        </div>
            <div class="col-md-2">
            <asp:TextBox TextMode="Number" ID="Codice" runat="server" placeholder="Codice"></asp:TextBox>
        </div>
    </div>
    <div class="row">
       <div class="col-md-2">
        <asp:Label runat="server">Descrizione</asp:Label>
        </div>
        <div class="col-md-2">
        <asp:TextBox ID="Descrizione" runat="server" placeholder="Inserisci un codice"></asp:TextBox>
        </div>
   </div>
    <asp:Button OnClick="Unnamed_Click" runat="server" Text="Cerca" />
        <%if(Messagge != null) {%>
    <div class="text-warning">
        <h4><%= Messagge %></h4>
    </div>
    <%} %>
</asp:Content>
