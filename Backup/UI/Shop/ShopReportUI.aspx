<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ShopReportUI.aspx.cs" Inherits="UI.Shop.ShopReportUI" %>

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
            <td style="width: 380px;">
            </td>
            <td align="left">
                <asp:Button ID="btnCurrentStockStatus_Branch" runat="server" CssClass="AccRptUiBtn"
                    Style="float: none;" Text="Branch Stock" OnClientClick="NewWindow();" OnClick="btnCurrentStockStatus_Branch_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSalesAmountView" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Branch Sales Details" OnClientClick="NewWindow();" OnClick="btnSalesAmountView_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnShopSalesPrintUI" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Shop Sales Report" OnClientClick="NewWindow();" OnClick="btnShopSalesPrintUI_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnShopReturnRptView" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Shop Return View " OnClientClick="NewWindow();" 
                    onclick="btnShopReturnRptView_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnRatingofGoods_BranchWise" runat="server" CssClass="AccRptUiBtn"
                    Style="float: none;" Text="Rating Of Goods " OnClientClick="NewWindow();" OnClick="btnRatingofGoods_BranchWise_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFBranceId" runat="server" />
</asp:Content>
