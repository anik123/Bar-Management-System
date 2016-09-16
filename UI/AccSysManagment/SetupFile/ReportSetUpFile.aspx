<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportSetUpFile.aspx.cs" Inherits="UI.AccSysManagment.SetupFile.ReportSetUpFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function NewWindow() {
            document.forms[0].target = "_blank";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
        <asp:Label ID="Label1" runat="server" Text="Click For Report Setup File" CssClass="Font_header"></asp:Label>
    </div>
    <table id="tableMain" class="ReportViewHR">
        <tr>
            <td style="width: 380px;">
            </td>
            <td align="left">
                <asp:Button ID="btnCashFlowSetup" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Cash Flow Setup" OnClientClick="NewWindow();" OnClick="btnCashFlowSetup_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnBalanceSheetRpt" CssClass="AccRptUiBtn" Style="float: none;" Text="Balance Sheet Setup"
                    runat="server" OnClientClick="NewWindow();" OnClick="btnBalanceSheetRpt_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 380px;">
            </td>
            <td align="left">
                <asp:Button ID="btnIncomeStatementRpt" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Profit Loass Setup" OnClientClick="NewWindow();" OnClick="btnIncomeStatementRpt_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnLiabilities" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Liabilities Report" OnClientClick="NewWindow();" OnClick="btnLiabilities_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnTransectionItemSetup" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Transection Item" OnClientClick="NewWindow();" 
                    onclick="btnTransectionItemSetup_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
