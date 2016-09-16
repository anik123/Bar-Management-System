<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExpenseHeadUI.aspx.cs" Inherits="UI.Admin.ExpenseHeadUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
        <asp:Label ID="Label5" runat="server" Text="Expense Head Creation" CssClass="Font_header"></asp:Label>
    </div>
    <div class="mainheadpage">
        <table style="width: 100%;">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">ExpenseHeadName<span class="Mandatory">*</span> </asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtExpenseHeadName" runat="server" CssClass="SingleTextbox">
                    </asp:TextBox>
                </td>
            </tr>
            <asp:HiddenField ID="HFExHID" runat="server" />
        </table>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td >
                    <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Repeater ID="RptMainHead" runat="server">
                        <HeaderTemplate>
                            <table id="table1" width="100%" border="1px">
                                <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                    <td>
                                        Expense Head Name
                                    </td>
                                    <td>
                                        Options
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="text-align: center; font-weight: bold;">
                                <td>
                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("HeadName") %>' />
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("ExHeadId") %>'
                                        Text="[Show]" CommandName="Show" CausesValidation="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-color: #8FADD9">
                                <td colspan="4" align="center">
                                    <asp:Label ID="Label1" runat="server" Text=" Expense Head Info..." ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblCurrentPage" runat="server"> </asp:Label>
                    <asp:HyperLink ID="lnkPrev" runat="server"><< Prev</asp:HyperLink>
                    <asp:HyperLink ID="lnkNext" runat="server">Next >></asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
