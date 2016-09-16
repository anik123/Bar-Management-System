﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientCompanyListRptUI.aspx.cs"
    Inherits="UI.ReportSetUpFile.ClientCompanyListRptUI" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left: 330px; visibility: hidden; margin-top: 20px;">
                <table style="float: left;">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Company Type:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCompanyType" runat="server" Width="130px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Importer</asp:ListItem>
                                <asp:ListItem>Exporter</asp:ListItem>
                                <asp:ListItem>Both</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Companay Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyName" Width="130px" runat="server"></asp:TextBox>
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
            <div style="margin-left: 180px; margin-top: 10px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="650px" Width="990px"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt">
                    <LocalReport ReportPath="ReportSetUpFile\CompClientListRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    SelectMethod="CompanyProfile" TypeName="BLL.ReportSetUpFilBLL">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ClientCompanyList"
                    TypeName="BLL.ReportSetUpFilBLL">
                    <SelectParameters>
                        <asp:Parameter Name="CompId" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtCompanyName" Name="CompName" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompMobile" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCompanyType" Name="CompStatus" Type="String" />
                    </SelectParameters>
                    <%-- <SelectParameters>
                        <asp:Parameter Name="CompId" Type="Int32" />
                        <asp:Parameter Name="CompName" Type="String" />
                        <asp:Parameter Name="CompMobile" Type="String" />
                        <asp:Parameter Name="CompStatus" Type="String" />
                    </SelectParameters>--%>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>