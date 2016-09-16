<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CompanyInfoUI.aspx.cs" Inherits="UI.Admin.CompanyInfoUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div style="margin-bottom: 20px;">
                <div class="middle">
                    <div class="Singlelebel_Child">
                        <asp:Label ID="Label5" runat="server" Text="Sub Category" ></asp:Label>
                    </div>
                </div>
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="LabelPName" CssClass="Lebel" runat="server">Sub Category :</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompName" runat="server" CssClass="Textbox"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                                ErrorMessage="Name Req" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFCompID" runat="server" />
                </table>
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
            <div class="Singlelebel_Child">
                <asp:Label ID="Label21" runat="server" Text="Search Category" ></asp:Label>
                </div>
            </div>
            <div class="SearchMain">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label23" runat="server" CssClass="Lebel" Text="Sub Category Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompNameS" runat="server" CssClass="Textbox" AutoPostBack="true"
                                OnTextChanged="txtComp_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="RequiredFieldcss"
                                ErrorMessage="Company Req" ControlToValidate="txtCompName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 100%; float: left">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptComp" runat="server">
                                <HeaderTemplate>
                                    <table width="100%">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                            <td>
                                                Options
                                            </td>
                                            <td>
                                                Sub Category
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
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
