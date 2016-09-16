<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PasswordChangeUI.aspx.cs" Inherits="UI.AccSysManagment.Employee.PasswordChangeUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="middle">
            <div class="Singlelebel_Child">
                <asp:Label ID="Label5" runat="server" Text="Change Password" ></asp:Label>
                </div>
            </div>
            <div class="testinfo">
                <table style="margin-left: 300px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="Xtralebel">Old Password: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOldPasswordBox" TextMode="Password" Text="" runat="server" Width="160px"
                                CssClass="input_textcss"> </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="ROldP" ValidationGroup="vg1" runat="server" CssClass="RequiredFieldCSS"
                                ErrorMessage="Old Password Reqired" ControlToValidate="txtOldPasswordBox"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RGEX" runat="server" Display="dynamic" ControlToValidate="txtOldPasswordBox"
                                CssClass="RequiredFieldCSS" ErrorMessage="Password must be 4-12 nonblank characters."
                                ValidationExpression="[^\s]{4,12}" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="Xtralebel">New Password: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewpassword" TextMode="Password" runat="server" Width="160px"
                                CssClass="input_textcss"> </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                CssClass="RequiredFieldCSS" ErrorMessage="New Password Required" ControlToValidate="txtNewpassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="dynamic"
                                ControlToValidate="txtNewpassword" CssClass="RequiredFieldCSS" ErrorMessage="Password must be 4-12 nonblank characters."
                                ValidationExpression="[^\s]{4,12}" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Xtralebel">Confirm New Password: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmNewPassword" TextMode="Password" runat="server" Width="160px"
                                CssClass="input_textcss"> </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RSN" runat="server" CssClass="RequiredFieldCSS"
                                ErrorMessage="Confirm Password Required" ControlToValidate="txtConfirmNewPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="txtNewpassword"
                                ControlToValidate="txtConfirmNewPassword" CssClass="RequiredFieldCSS" Display="Dynamic"
                                ErrorMessage="The Confirm New Password must match the New Password entry."></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 100%; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="subbtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
