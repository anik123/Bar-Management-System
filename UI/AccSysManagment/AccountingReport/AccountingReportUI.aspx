<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AccountingReportUI.aspx.cs" Inherits="UI.AccSysManagment.AccountingReport.AccountingReportUI" %>

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
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnChartofAccount" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Chart of Account" OnClientClick="NewWindow();" OnClick="btnChartofAccount_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnLastJournal" CssClass="AccRptUiBtn" Style="float: none;" Text="Last Journal"
                    runat="server" OnClientClick="NewWindow();" OnClick="btnLastJournal_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 380px;">
            </td>
            <td align="left">
                <asp:Button ID="btnDateToDateJournal" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Date Wise Journal" OnClientClick="NewWindow();" OnClick="btnDateToDateJournal_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnLedger" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Ledger Report" OnClientClick="NewWindow();" OnClick="btnLedger_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnTraialBalance" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Trial Balance" OnClientClick="NewWindow();" OnClick="btnTraialBalance_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="BtnTraialBalanceRptNew" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Trial Balance Expand" OnClientClick="NewWindow();" OnClick="BtnTraialBalanceRptNew_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnBalanceSheet" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Balance Sheet" OnClientClick="NewWindow();" OnClick="btnBalanceSheet_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnIncomeStatement" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Income Statement" OnClientClick="NewWindow();" OnClick="btnIncomeStatement_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnIncomeHardCode" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Income Statement" OnClientClick="NewWindow();" OnClick="btnIncomeHardCode_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSalesIncomeReport" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Income Sales Report" OnClientClick="NewWindow();" 
                    onclick="btnSalesIncomeReport_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnCashFlow" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Cash Flow" OnClientClick="NewWindow();" OnClick="btnCashFlow_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnliabilities" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Liabilities Report" OnClientClick="NewWindow();" OnClick="btnliabilities_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="BtnPartyWiseLiabilities" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Liabilities Part Wise" OnClientClick="NewWindow();" OnClick="BtnPartyWiseLiabilities_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnExpense" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Expense Report" OnClientClick="NewWindow();" OnClick="btnExpense_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnLogJournalEdit" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Journal Edit Log" OnClientClick="NewWindow();" OnClick="btnLogJournalEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
