<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailySalesReportRpt.aspx.cs" Inherits="UI.Shop.Report.DailySalesReportRpt" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        #ReportViewer1_ctl10{
    background:white;
}
#form1
{
    background:gainsboro;
    margin:0px;
    
          padding:0px;
}
body{margin:0px;
          padding:0px;
          }
</style>

</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   

    <asp:HiddenField ID="HFRptdtlId" runat="server" />
    <div style="clear: both; margin: 10px 0px 0px 0px;">
    <center>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" Height="655px" 
            Width="473px"  WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Shop\Report\Copy of InvenDailySale.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
            SelectMethod="LoadDailySale" TypeName="BLL.ReportBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="date" QueryStringField="date" Type="String" />
                <asp:QueryStringParameter Name="TotalSale" QueryStringField="TotalSale" 
                    Type="String" />
                <asp:QueryStringParameter Name="GuestCharge" QueryStringField="GuestCharge" 
                    Type="String" />
                <asp:QueryStringParameter Name="card" QueryStringField="card" Type="String" />
                <asp:QueryStringParameter Name="ExtraBill" QueryStringField="ExtraBill" 
                    Type="String" />
                <asp:QueryStringParameter Name="GouestChargePlus" 
                    QueryStringField="GouestChargePlus" Type="String" />
                <asp:QueryStringParameter Name="TotalAmount" QueryStringField="TotalAmount" 
                    Type="String" />
                <asp:QueryStringParameter Name="BarSale" QueryStringField="BarSale" 
                    Type="String" />
                <asp:QueryStringParameter Name="CateringSale" QueryStringField="CateringSale" 
                    Type="String" />
                <asp:QueryStringParameter Name="BekarySale" QueryStringField="BekarySale" 
                    Type="String" />
                <asp:QueryStringParameter Name="RestuarentSale" 
                    QueryStringField="RestuarentSale" Type="String" />
                <asp:QueryStringParameter Name="GuestSale" QueryStringField="GuestSale" 
                    Type="String" />
                    <asp:QueryStringParameter Name="quan" QueryStringField="quan" 
                    Type="String" />

            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="LoadDailySale" TypeName="BLL.ReportBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="date" QueryStringField="date" Type="String" />
                <asp:QueryStringParameter Name="TotalSale" QueryStringField="TotalSale" 
                    Type="String" />
                <asp:QueryStringParameter Name="GuestCharge" QueryStringField="GuestCharge" 
                    Type="String" />
                <asp:QueryStringParameter Name="card" QueryStringField="card" Type="String" />
                <asp:QueryStringParameter Name="ExtraBill" QueryStringField="ExtraBill" 
                    Type="String" />
                <asp:QueryStringParameter Name="GouestChargePlus" 
                    QueryStringField="GouestChargePlus" Type="String" />
                <asp:QueryStringParameter Name="TotalAmount" QueryStringField="TotalAmount" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </center>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="LoadDailySale" TypeName="BLL.ReportBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="date" QueryStringField="Date" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
    
</body>
</html>
