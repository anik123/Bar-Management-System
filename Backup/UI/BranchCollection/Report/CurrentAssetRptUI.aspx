<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentAssetRptUI.aspx.cs"
    Inherits="UI.BranchCollection.Report.CurrentAssetRptUI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="clear: both; margin: 10px 0px 0px 350px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="450px" 
            Width="600px" Font-Names="Verdana" Font-Size="8pt" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="BranchCollection\Report\CurrentAssetRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="CurrentAssetStatus" TypeName="BLL.CompProfile.PayRollReprotBLL">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
