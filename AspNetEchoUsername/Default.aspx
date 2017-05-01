<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetEchoUsername._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Echo User Name</h1>
        <p><asp:Label ID="lblWelcome" runat="server" Text="Label">--- name not resolved ---</asp:Label></p>
    </div>
    
</asp:Content>
