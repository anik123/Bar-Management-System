<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarCodeEmpPopUp.aspx.cs"
    Inherits="UI.Admin.BarCodeEmpPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function cancel() {
            window.parent.document.getElementById('btnCancelBarCodePopUp').click();
        }
    </script>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Employee BarCode Generation....
            </div>
            <div class="TitlebarRight" onclick="cancel();">
            </div>
        </div>
        <div class="popup_Body">
            <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </ajaxtoolkit:ToolkitScriptManager>
            <asp:Panel ID="panel_PopupInpatient" runat="server" CssClass="ModalPopup" Width="580px">
                <asp:Label ID="Label8" runat="server" CssClass="Font_header" Text="Employee Information Panel"></asp:Label>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="clabel_EmpPopup" Text="Product Id#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProductId" runat="server" CssClass="input_textcss_empPopupBarcode"
                                    AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" CssClass="clabel_EmpPopup" Text="Product Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="input_textcss_empPopupBarcode"
                                    AutoPostBack="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lb12" runat="server" CssClass="clabel_EmpPopup" Text="Category Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="input_textcss_empPopupBarcode"
                                    AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="clabel_EmpPopup" Text="Unit:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUnit" runat="server" CssClass="input_textcss_empPopupBarcode" AutoPostBack="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-top: 20px;">
                    <asp:Label ID="Label7" runat="server" CssClass="Font_header" Text="Bar Code Panel"></asp:Label>
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label5" runat="server" CssClass="clabel_EmpPopup" Text="BarCode:"></asp:Label>
                            </td>
                            <td>
                                <asp:Image ID="Image1" runat="server" />
                            </td>
                            <td valign="middle">
                                <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_EmpPopup" Text="File Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtImageFileName" CssClass="input_textcss_empPopupBarcode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="HFEmpId" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
