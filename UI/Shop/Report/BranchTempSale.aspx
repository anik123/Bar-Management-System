<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchTempSale.aspx.cs"
    Inherits="UI.Shop.Report.BranchTempSale" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        #ReportViewer1_ctl10
        {
            background: white;
        }
        #form1
        {
            background: gainsboro;
            margin: 0px;
            padding: 0px;
        }
        body
        {
            margin: 0px;
            padding: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="650px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="600px">
                    <LocalReport ReportPath="Shop\Report\BranchWiseTempSalesRpt.rdlc">
                        <DataSources>
                           
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="CompanyProfile"
                    TypeName="BLL.ReportSetUpFilBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="BranchTempSalesProduct" TypeName="BLL.ReportBLL">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="memid" 
                            QueryStringField="memid" Type="Int32" />
                        <asp:QueryStringParameter DefaultValue="" Name="tdate" QueryStringField="tdate" 
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
