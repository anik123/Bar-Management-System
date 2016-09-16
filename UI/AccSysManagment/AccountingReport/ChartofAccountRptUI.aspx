<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartofAccountRptUI.aspx.cs"
    Inherits="UI.AccSysManagment.AccountingReport.ChartofAccountRptUI" %>

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
    <div style=" margin-top: 20px;">
        <table >
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Chart of Accounts Report..."></asp:Label>
                </td>
            </tr>
        </table>
        <table >
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Main Head:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMainHead" runat="server" AutoPostBack="true" Width="173px"
                        OnSelectedIndexChanged="ddlMainHead_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Sub Code1:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubCode1" runat="server" AutoPostBack="true" Width="173px"
                        OnSelectedIndexChanged="ddlSubCode1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Sub Code2:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubCode2" runat="server" AutoPostBack="true" Width="173px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Width="75px" Text="Search" OnClick="btnSearch_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Width="75px" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both;">
    </div>
    <div style=" margin-top: 20px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="550px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="14pt" Width="1180px">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\ChartOfAccountingRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ChartOfAccountReport"
            TypeName="ABLL.ReportBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlMainHead" Name="mainheadid" Type="Int32" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSubCode1" Name="subcode1id" Type="Int32" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSubCode2" Name="subcode2id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
    </center>
</body>
</html>
