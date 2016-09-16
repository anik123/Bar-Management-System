<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CollectionReportUI.aspx.cs" Inherits="UI.BranchCollection.Report.CollectionReportUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function NewWindow() {
            document.forms[0].target = "_blank";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
        <asp:Label ID="Label1" runat="server" Text="Click To View Report" CssClass="Font_header"></asp:Label>
    </div>
    <table id="tableMain" class="ReportViewHR">
        <tr>
            <td style="width: 400px;">
            </td>
            <td align="left">
                <asp:Button ID="BtnCurrentAsset" runat="server" CssClass="button3" Style="float: none;"
                    Text="Current Asset" OnClientClick="NewWindow();" OnClick="BtnCurrentAsset_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnCompanyCash" runat="server" CssClass="button3" Style="float: none;"
                    Text="Company Cash" OnClientClick="NewWindow();" OnClick="btnCompanyCash_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="BtnBankAmountIndividual" runat="server" CssClass="button3" Style="float: none;"
                    Text="Individual Bank Amount" OnClientClick="NewWindow();" OnClick="BtnBankAmountIndividual_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnBankTransection" runat="server" CssClass="button3" Style="float: none;"
                    Text="Bank All Transection" OnClientClick="NewWindow();" OnClick="btnBankTransection_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
