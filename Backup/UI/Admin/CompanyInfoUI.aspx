<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CompanyInfoUI.aspx.cs" Inherits="UI.Admin.CompanyInfoUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="CompMain">
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Company Info Entry" CssClass="Font_header"></asp:Label>
                </div>
                <div class="CompMain_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelPName" CssClass="Lebel" runat="server">Company Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompName" runat="server" CssClass="Textbox"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Name Req" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
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
                                <asp:Label ID="Label8" runat="server" CssClass="Lebel" Text="Permanent Address:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompPermanentAdd" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Lebel" Text="Web Site:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompWebsite" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" CssClass="Lebel" runat="server" Text="Email:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompEmail" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label6" CssClass="Lebel" runat="server" Text="Company Type:"></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:RadioButtonList ID="RbtCompStatus" runat="server" CssClass="Company_Rbt_Expeoter" RepeatDirection="Horizontal">
                                    <asp:ListItem>Importer</asp:ListItem>
                                    <asp:ListItem>Exporter</asp:ListItem>
                                    <asp:ListItem>Both</asp:ListItem>
                                </asp:RadioButtonList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="rfrbt" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Select one" ControlToValidate="RbtCompStatus"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <asp:HiddenField ID="HFCompID" runat="server" />
                    </table>
                </div>
                <div class="CompMain_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelPhone" CssClass="Lebel" runat="server" Text="Phone:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompPhone" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelMobile1" CssClass="Lebel" runat="server"> Mobile1:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompMobile1" runat="server" CssClass="Textbox"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                    CssClass="RequiredFieldcss" ErrorMessage="Mobile Req" ControlToValidate="txtCompMobile1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" CssClass="Lebel" runat="server" Text="Mobile2:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompMobile2" runat="server" CssClass="Textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label3" runat="server" CssClass="Lebel" Text="Description:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompDes" runat="server" CssClass="Textbox" TextMode="MultiLine"></asp:TextBox>
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
                <asp:Label ID="Label21" runat="server" Text="Search Company" CssClass="Font_header"></asp:Label>
            </div>
            <div class="SearchMain">
                <div class="Search_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="Lebel" Text="Company Id:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompIdS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtComp_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Company Req" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" CssClass="Lebel" Text="Contact Address:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtCompAddS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtComp_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Search_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" CssClass="Lebel" Text="Company Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompNameS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtComp_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Company Req" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="Lebel" Text="Mobile:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompMobileS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                    OnTextChanged="txtComp_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <table style="width: 100%; float: left">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptComp" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" border="1px">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                            <td>
                                                Options
                                            </td>
                                            <td>
                                                Company Name
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
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("CompID") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("CompName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("CompPresentAdd") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("CompMobile1") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("CompEmail") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="5" align="center">
                                            <asp:Label ID="Label1" runat="server" Text="Company Info..." ForeColor="White"></asp:Label>
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
