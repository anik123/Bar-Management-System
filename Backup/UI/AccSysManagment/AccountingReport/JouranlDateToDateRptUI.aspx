<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JouranlDateToDateRptUI.aspx.cs"
    Inherits="UI.AccSysManagment.AccountingReport.JouranlDateToDateRptUI" %>

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
    <div style="margin-left: 270px; margin-top: 10px;">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Journal Report..."></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="From:"></asp:Label>
                    <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                    <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                        Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtfromdate">
                    </ajaxtoolkit:CalendarExtender>
                    <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                        Operator="DataTypeCheck" ControlToValidate="txtfromdate" ErrorMessage="Not Valid">
                    </asp:CompareValidator>
                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="To:"></asp:Label>
                    <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                        Operator="DataTypeCheck" ControlToValidate="txtTodate" ErrorMessage="Not Valid">
                    </asp:CompareValidator>
                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                        Format="MM/dd/yyyy" TargetControlID="txtTodate">
                    </ajaxtoolkit:CalendarExtender>
                    <asp:Button ID="btnSearch" runat="server" Width="75px" Text="Search" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClear" runat="server" Width="75px" CausesValidation="false" Text="Clear"
                        OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 300px; margin-top: 10px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="650px" Height="650px">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\JouranlDateToDateNew.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="JournalReport_DateToDate"
            TypeName="ABLL.ReportBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtfromdate" Name="fromdate" Type="String" />
                <asp:ControlParameter ControlID="txtTodate" Name="todate" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
