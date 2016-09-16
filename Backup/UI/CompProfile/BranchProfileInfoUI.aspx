<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchProfileInfoUI.aspx.cs" Inherits="UI.CompProfile.BranchProfileInfoUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="CompMain">
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Brany Info Entry" CssClass="Font_header"></asp:Label>
                </div>
                <div class="CompMain_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" CssClass="Lebel" runat="server"> Company Profile Name:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCompProfileName" Width="232px" CssClass="DDL_2_div" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelPName" CssClass="Lebel" runat="server"> Branch Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrName" runat="server" CssClass="Textbox"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Brany Req" ControlToValidate="txtBrName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Lebel"> Contact Address:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactAdd" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Lebel" Text="Web Site:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrWebsite" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" CssClass="Lebel" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrEmail" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <asp:HiddenField ID="HFBrID" runat="server" />
                    </table>
                </div>
                <div class="CompMain_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelPhone" CssClass="Lebel" runat="server" Text="Phone:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrPhone" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMobile1" CssClass="Lebel" runat="server"> Mobile1:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrMobile1" runat="server" CssClass="Textbox"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                    CssClass="RequiredFieldcss" ErrorMessage="Mobile Req" ControlToValidate="txtBrMobile1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" CssClass="Lebel" runat="server" Text="Mobile2:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrMobile2" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" CssClass="Lebel" Text="Description:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrDes" runat="server" CssClass="Textbox" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSearch" runat="server" CssClass="Searchbtn" Text="Search" CausesValidation="false"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="Label21" runat="server" Text="Search Brany" CssClass="Font_header"></asp:Label>
            </div>
            <div class="SearchMain">
                <div class="Search_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="Lebel" Text="Brany Id:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrIdS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtBr_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Brany Req" ControlToValidate="txtBrName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" CssClass="Lebel" Text="Contact Address:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBrAddS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtBr_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Search_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" CssClass="Lebel" Text="Branch Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrNameS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtBr_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Brany Req" ControlToValidate="txtBrName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="Lebel" Text="Mobile:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBrMobileS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtBr_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <table style="width: 100%; float: left">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptBr" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1px">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                            <td>
                                                Options
                                            </td>
                                            <td>
                                                Branch Name
                                            </td>
                                            <td>
                                                Contact Address
                                            </td>
                                            <td>
                                                Mobile
                                            </td>
                                            <td>
                                                Email
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="background-color: #EEF5FF; text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("BrProId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BrProName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BrAddress") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("BrMobile1") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("BrEmail") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="5" align="center">
                                            <asp:Label ID="Label1" runat="server" Text="Brany Info..." ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCurrentPage" runat="server">
                            </asp:Label>
                            <asp:HyperLink ID="lnkPrev" runat="server"><< Prev</asp:HyperLink>
                            <asp:HyperLink ID="lnkNext" runat="server">Next >></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
