<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleOparationSummary.aspx.cs" Inherits="UI.Manager.Report.SaleOparationSummary" %>
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
<center>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div style=" margin-top: 20px;">
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Form:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="118px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                Format="MM/dd/yyyy" TargetControlID="txtDateFrom">
                            </ajaxtoolkit:CalendarExtender>
                            <asp:CompareValidator ID="cvf" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                ControlToValidate="txtDateFrom" ErrorMessage="Not Valid">
                            </asp:CompareValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="To :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTodate" CssClass="input_textcss" Width="118px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                Format="MM/dd/yyyy" TargetControlID="txtTodate">
                            </ajaxtoolkit:CalendarExtender>
                            <asp:CompareValidator ID="Cvt" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                ControlToValidate="txtTodate" ErrorMessage="Not Valid">
                            </asp:CompareValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Width="65px" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Product:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Party :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCompName" runat="server" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" Width="65px" Text="Clear" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="clear: both;">
            </div>
            <div style=" margin-top: 10px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="650px" Width="690px"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt">
                    <LocalReport ReportPath="Manager\Report\SaleOperationSummaryRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="CompanyProfile"
                    TypeName="BLL.ReportSetUpFilBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SaleOperationSummary"
                    TypeName="BLL.ReportBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCompName" Name="compid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCategory" Name="catid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="FromDate" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtTodate" Name="ToDate" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </center>
</body>
</html>
