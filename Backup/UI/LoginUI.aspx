<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="AUI.LoginUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main_wrapper">
        <div id="wrapper">
        </div>
        <div class="clear">
        </div>
        <div class="body_bg_mid">
            <div class="main_body_content">
                <div class="admin_cont">
                    <div class="admin_bg_top">
                    </div>
                    <div class="admin_bg_mid">
                        <div class="admin_fild">
                            <div class="user_icon">
                            </div>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="ffil"></asp:TextBox>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="admin_fild">
                            <div class="pass_icon">
                            </div>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="ffil" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="clear">
                        </div>
                        <a href="#" class="reset_text">Reset password ?</a>
                        <asp:Button ID="btnlogin" runat="server" Text="" CssClass="log_in_but" OnClick="btnlogin_Click" />
                    </div>
                    <div class="admin_bg_bot">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
