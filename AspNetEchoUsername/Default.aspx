<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetEchoUsername._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Echo User Name</h1>
        <p><asp:Label ID="lblWelcome" runat="server">--- name not resolved ---</asp:Label></p>
        <p><asp:Label ID="lblGroups" runat="server">--- groups not resolved ---</asp:Label></p>
        <!--<p><asp:ListBox ID="lbGroups" runat="server" Height="500"></asp:ListBox></p>-->
    </div>
    
</asp:Content>
