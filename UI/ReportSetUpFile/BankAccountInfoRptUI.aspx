<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankAccountInfoRptUI.aspx.cs"
    Inherits="UI.ReportSetUpFile.BankAccountInfoRptUI" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div style="margin-left: 330px; margin-top: 20px;">
                <table style="float: left;">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Company Branch:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranchName" runat="server" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Bank Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBankName" runat="server" AutoPostBack="true" Width="130px">
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
            <div style="margin-left: 330px; margin-top: 10px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="650px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="730px">
                    <LocalReport ReportPath="ReportSetUpFile\BankAccountRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="LoadAccountInfo"
                    TypeName="BLL.ReportSetUpFilBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBranchName" Name="branchid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBankName" Name="BankID" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <%--   <asp:Parameter Name="branchid" Type="Int32" />
                <asp:Parameter Name="BankID" Type="Int32" />
                        --%>
                        <asp:Parameter Name="accname" Type="String" />
                        <asp:Parameter Name="accnum" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
