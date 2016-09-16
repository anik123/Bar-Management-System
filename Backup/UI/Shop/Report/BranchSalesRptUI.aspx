<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchSalesRptUI.aspx.cs"
    Inherits="UI.Shop.Report.BranchSalesRptUI" %>

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
    <asp:HiddenField ID="HFRptdtlId" runat="server" />
    <div style="clear: both; margin: 10px 0px 0px 330px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="650px" 
            Width="600px" Font-Names="Verdana" Font-Size="8pt" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Shop\Report\BranchWiseSalesRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="CompanyProfile" TypeName="BLL.ReportSetUpFilBLL">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="BranchSalesProduct" TypeName="BLL.ReportBLL">
           <%-- <SelectParameters>
                <asp:Parameter Name="salid" Type="Int32" />
            </SelectParameters>--%>
            <SelectParameters>
                <asp:ControlParameter ControlID="HFRptdtlId" Name="salid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
