<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeStatementRptUI.aspx.cs"
    Inherits="UI.AccSysManagment.AccountingReport.IncomeStatementRptUI" %>

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
    <div >
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Income Satement..."></asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Tax Amount(%):"></asp:Label>
                    <asp:TextBox ID="txtTaxAmount" runat="server">0.0</asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Width="75px" Text="Search" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClear" runat="server" Width="75px" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div >
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="650px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt" Width="909px">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\IncomeStatementRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="IncomeStatement"
            TypeName="ABLL.ReportBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtTaxAmount" Name="tax" Type="Double" />
            </SelectParameters>
            <%-- <SelectParameters>
              <asp:Parameter Name="tax" Type="Double" />
            </SelectParameters>--%>
        </asp:ObjectDataSource>
    </div>
    </form>
    </center>
</body>
</html>
