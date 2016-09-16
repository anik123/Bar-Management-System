<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportSetUpFileUI.aspx.cs" Inherits="UI.ReportSetUpFile.ReportSetUpFileUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function NewWindow() {
            document.forms[0].target = "_blank";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
        <asp:Label ID="Label1" runat="server" Text="Click To View Report" CssClass="Singlelebel_Child"></asp:Label>
    </div>
    <table id="tableMain" class="ReportViewHR">
        <tr>
            <td style="width: 380px;">
            </td>
            <td align="left">
                <asp:Button ID="btnBankAccount" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Bank Account " OnClientClick="NewWindow();" OnClick="btnBankAccount_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnBranchList" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Company Branch List" OnClientClick="NewWindow();" OnClick="btnBranchList_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnClientCompanyList" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Exporter List" OnClientClick="NewWindow();" OnClick="btnClientCompanyList_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnProductList" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Goods List" OnClientClick="NewWindow();" OnClick="btnProductList_Click" />
            </td>
        </tr>
       
    </table>
</asp:Content>
