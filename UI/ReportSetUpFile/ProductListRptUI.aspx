<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductListRptUI.aspx.cs"
    Inherits="UI.ReportSetUpFile.ProductListRptUI" %>

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
            <div style="margin-left: 330px; margin-top: 0px;">
                <table style="float: left;">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Product:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Font-Bold="True"
                                Text="Company:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCompany" runat="server" Width="130px">
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
            <div style="margin-left: 330px; margin-top: 0px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="650px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="600px">
                    <LocalReport ReportPath="ReportSetUpFile\ProductListRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="CompanyProfile"
                    TypeName="BLL.ReportSetUpFilBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ProductList"
                    TypeName="BLL.ReportSetUpFilBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCategory" Name="cateid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCompany" Name="compid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:Parameter Name="producname" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCompany" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
