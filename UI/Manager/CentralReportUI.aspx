<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CentralReportUI.aspx.cs" Inherits="UI.Manager.CentralReportUI" %>

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
                <asp:Button ID="btnCentralStockStatus" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Central Stock Status" OnClientClick="NewWindow();" OnClick="btnCentralStockStatus_Click" />
            </td>
        </tr>
        
       <%-- 
        
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSalesDtlBreanchWise" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Branch Sales Details" OnClientClick="NewWindow();" OnClick="btnSalesDtlBreanchWise_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnSalesDtailsRptPrint" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Sales Report Print" OnClientClick="NewWindow();" OnClick="btnSalesDtailsRptPrint_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnPurchaseSatement" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="Purchase Satement" OnClientClick="NewWindow();" OnClick="btnPurchaseSatement_Click" />
            </td>
        </tr>
        --%> 
        
        
        
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnAllPurchaseView" runat="server" CssClass="AccRptUiBtn" Style="float: none;"
                    Text="All Purchase View" OnClientClick="NewWindow();" OnClick="btnAllPurchaseView_Click" />
            </td>
        </tr>
       
    </table>
</asp:Content>
