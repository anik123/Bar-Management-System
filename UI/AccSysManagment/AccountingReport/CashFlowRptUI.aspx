﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashFlowRptUI.aspx.cs"
    Inherits="UI.AccSysManagment.AccountingReport.CashFlowRptUI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<center>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin-top: 10px;">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Cash Flow Report..."></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="From:"></asp:Label>
                    <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                        Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtfromdate">
                    </ajaxtoolkit:CalendarExtender>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="To:"></asp:Label>
                    <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                        Format="MMMM d, yyyy" TargetControlID="txtTodate">
                    </ajaxtoolkit:CalendarExtender>
                    <asp:Button ID="btnSearch" runat="server" Width="75px" Text="Search" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClear" runat="server" Width="75px" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style=" margin-top: 10px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="650px" Width="1030px"
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\CashFlowRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="CashFlowRept"
            TypeName="ABLL.ReportBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtfromdate" Name="fromdate" Type="String" />
                <asp:ControlParameter ControlID="txtTodate" Name="todate" Type="String" />
            </SelectParameters>
            <%--<SelectParameters>
                <asp:Parameter Name="fromdate" Type="DateTime" />
                <asp:Parameter Name="todate" Type="DateTime" />
            </SelectParameters>--%>
        </asp:ObjectDataSource>
    </div>
    </form>
    </center>
</body>
</html>
