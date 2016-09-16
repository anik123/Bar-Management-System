<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiabilitiesRptUI.aspx.cs"
    Inherits="UI.AccSysManagment.AccountingReport.LiabilitiesRptUI" %>

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
    <div style=" margin-top: 20px; width: 100%;">
        <table >
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Liabilities Report..."></asp:Label>
                </td>
            </tr>
        </table>
        <table >
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="From:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfromdate" Width="170px" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                        Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtfromdate">
                    </ajaxtoolkit:CalendarExtender>
                </td>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="To:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTodate" Width="170px" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                        Format="MMMM d, yyyy" TargetControlID="txtTodate">
                    </ajaxtoolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Account Head:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubCode1" runat="server" AutoPostBack="true" Width="173px"
                        OnSelectedIndexChanged="ddlSubCode1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="Label5" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Account Sub Head:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubCode2" runat="server" Width="173px" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table >
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Width="75px" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
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
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="812px">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\LiabilitiesRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="LiabilitiesReport"
            TypeName="ABLL.ReportBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtfromdate" Name="fromdate" Type="String" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtTodate" Name="todate" Type="String" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSubCode1" Name="subccode1id" Type="Int32" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSubCode2" Name="subcode2id" Type="Int32" />
            </SelectParameters>
            <%--  <SelectParameters>
                <asp:Parameter Name="fromdate" Type="DateTime" />
                <asp:Parameter Name="todate" Type="DateTime" />
                <asp:Parameter Name="subccode1id" Type="Int32" />
                <asp:Parameter Name="Subcode2id" Type="Int32" />
              
            </SelectParameters>--%>
        </asp:ObjectDataSource>
    </div>
    </form>
    </center>
</body>
</html>
