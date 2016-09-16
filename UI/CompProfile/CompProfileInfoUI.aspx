<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CompProfileInfoUI.aspx.cs" Inherits="UI.CompProfile.CompProfileInfoUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="CompMain">
                
                <div class="Singlelebel_Child">
                 <asp:Label ID="Label5" runat="server" Text="Company Info Entry"></asp:Label>
             
                   
                </div>
                <div class="clear"></div>
                <div class="CompMain_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="LabelPName" CssClass="Lebel" runat="server"> Company Name</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompName" runat="server" CssClass="Textbox"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                                    ErrorMessage="Profile Name" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="Lebel"> Contact Address</asp:Label>
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
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="Singlelebel_Child">

                <asp:Label ID="Label21" runat="server" Text="Search Company"></asp:Label>
            </div>
            <div>
                <table style="width: 100%; float: left">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptComp" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" >
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
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("CompProId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("CompProName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("CompAddress") %>' />
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
