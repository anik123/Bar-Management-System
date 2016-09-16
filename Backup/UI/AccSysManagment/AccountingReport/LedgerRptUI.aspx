<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LedgerRptUI.aspx.cs" Inherits="UI.AccSysManagment.AccountingReport.LedgerRptUI" %>

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
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div style="margin-left: 100px; margin-top: 20px;">
                <table style="float: left;">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Ledger Report..."></asp:Label>
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="From:"></asp:Label>
                            <asp:TextBox ID="txtfromdate" Width="137px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtfromdate">
                            </ajaxtoolkit:CalendarExtender>
                         <%--   <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                Operator="DataTypeCheck" ControlToValidate="txtfromdate" ErrorMessage="Not Valid">
                            </asp:CompareValidator>--%>
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="To:"></asp:Label>
                            <asp:TextBox ID="txtTodate" Width="137px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                Format="MM/dd/yyyy" TargetControlID="txtTodate">
                            </ajaxtoolkit:CalendarExtender>
                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                                Operator="DataTypeCheck" ControlToValidate="txtTodate" ErrorMessage="Not Valid">
                            </asp:CompareValidator>--%>
                            <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Account No#:"></asp:Label>
                            <asp:TextBox ID="txtAccountCodeNO" Width="137px" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Width="70px" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server" Width="70px" CausesValidation="false" Text="Clear"
                                OnClick="btnClear_Click" />
                            <asp:Label ID="Label9" runat="server" Visible="false" Font-Bold="true" Text="not valid:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Main Head:"></asp:Label>
                            <asp:DropDownList ID="ddlMainHead" runat="server" AutoPostBack="true" Width="140px"
                                OnSelectedIndexChanged="ddlMainHead_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label4" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Sub Code1:"></asp:Label>
                            <asp:DropDownList ID="ddlSubCode1" runat="server" AutoPostBack="true" Width="140px"
                                OnSelectedIndexChanged="ddlSubCode1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label5" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Sub Code2:"></asp:Label>
                            <asp:DropDownList ID="ddlSubCode2" runat="server" AutoPostBack="true" Width="140px"
                                OnSelectedIndexChanged="ddlSubCode2_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="COA:"></asp:Label>
                            <asp:DropDownList ID="ddlCOA" runat="server" AutoPostBack="true" Width="140px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="clear: both;">
            </div>
            <div style="margin-left: 300px; margin-top: 20px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="630px" Height="650px">
                    <LocalReport ReportPath="AccSysManagment\AccountingReport\LedgerRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="LedgerRpt"
                    TypeName="ABLL.ReportBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtfromdate" Name="fromdate" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtTodate" Name="todate" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAccountCodeNO" Name="coanum" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMainHead" Name="mainheadid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlSubCode1" Name="subcode1id" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlSubCode2" Name="subcode2id" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCOA" Name="coaid" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
