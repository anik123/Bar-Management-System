<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LogSuccessPage.aspx.cs" Inherits="UI.LogSuccessPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        .<asp:Label ID="Label25" runat="server" Text="Welcome ,"></asp:Label>
        <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Italic="True" 
            Text="Label"></asp:Label>
        <asp:Label ID="Label26" runat="server" 
            Text=" ,You Have Successfully Logged In Your System"></asp:Label>
        <asp:HiddenField ID="HFBranceId" runat="server" />
    </h1>
</asp:Content>
