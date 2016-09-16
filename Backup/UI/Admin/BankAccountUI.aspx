<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BankAccountUI.aspx.cs" Inherits="UI.Admin.BankAccountUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel UpdateMode="Conditional" ID="up" runat="server">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" ActiveTabIndex="2"
                AutoPostBack="true">
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel1" HeaderText="BankNameSetUp">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label5" runat="server" Text="Bank Name Entry" CssClass="Font_header"></asp:Label>
                            <table style="margin-left: 235px; margin-top: 20px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Bank Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="Textbox"></asp:TextBox>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                                            ErrorMessage="Bank Name Req" ControlToValidate="txtBankName"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" Text="Save" ValidationGroup="vg1"
                                            OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVBank" runat="server" BackColor="White" BorderColor="White" Width="100%"
                                            Height="35px" Font-Size="11px" BorderStyle="Ridge" CellPadding="3" CellSpacing="1"
                                            PageSize="8" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                            DataKeyNames="BankId" OnPageIndexChanging="GVBank_PageIndexChanging" OnSelectedIndexChanged="GVBank_SelectedIndexChanged">
                                            <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                            <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                PageButtonCount="8" />
                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                                HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="BankName" HeaderText="Bank Name " />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:HiddenField ID="hfbankid" runat="server" />
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel2" HeaderText="Account Type Setup">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Account Type Entry" CssClass="Font_header"></asp:Label>
                            <table style="margin-left: 235px; margin-top: 20px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Account Type:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtAccountType" runat="server" CssClass="Textbox"></asp:TextBox>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg2" ID="Rfacc" runat="server" CssClass="RequiredFieldcss"
                                            ErrorMessage="Account Type Req" ControlToValidate="TxtAccountType"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HfAccountType" runat="server" />
                            </table>
                        </div>
                        <div>
                            <table style="width: 100%; margin-top: 20px;">
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnAccountTypeSave" runat="server" CssClass="SaveBtn" Text="Save"
                                            ValidationGroup="vg2" OnClick="BtnAccountTypeSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnAccountTypeSaveCLear" runat="server" CssClass="clearBtn" Text="Clear"
                                            CausesValidation="False" OnClick="BtnAccountTypeSaveCLear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVAccountType" runat="server" BackColor="White" BorderColor="White"
                                            Width="100%" Height="35px" Font-Size="11px" BorderStyle="Ridge" CellPadding="3"
                                            CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                            OnPageIndexChanging="GVAccountType_PageIndexChanging" DataKeyNames="AccountTypeId"
                                            PageSize="8" OnSelectedIndexChanged="GVAccountType_SelectedIndexChanged">
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                            <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                PageButtonCount="8" />
                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="AccountTypeName" HeaderText="Account Type Name" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel3" HeaderText="Account Info Setup">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label21" runat="server" Text="Account Info Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="AccountUi_main">
                            <div class="AccountUi_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lb12" runat="server" CssClass="lblBankAccount"> Bank Name: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBankName" runat="server" CssClass="ddlBankAccount">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vg3"
                                                ForeColor="Red" ControlToValidate="ddlBankName" InitialValue="0">Bank Req</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="lblBankAccount"> Branch Name: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBranch" runat="server" CssClass="txtboxBankAccount"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg3" ID="RequiredFieldValidator4" runat="server"
                                                ForeColor="Red" ErrorMessage="Branch Req" ControlToValidate="txtBranch"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="lblBankAccount" Text="Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="txtboxBankAccount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" CssClass="lblBankAccount"> Mobile: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txtboxBankAccount"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg3" ID="RequiredFieldValidator5" runat="server"
                                                ForeColor="Red" ErrorMessage="Mobile Req" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" CssClass="lblBankAccount" Text="Phone:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="txtboxBankAccount"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="AccountUi_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label9" runat="server" CssClass="lblBankAccount"> Account Type:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="ddlBankAccount">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="rc" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                                ControlToValidate="ddlAccountType" InitialValue="0">Type Req</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" CssClass="lblBankAccount"> Account Name: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtboxBankAccount"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg3" ID="RequiredFieldValidator7" runat="server"
                                                ForeColor="Red" ErrorMessage="Acc Req" ControlToValidate="txtAccountName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" CssClass="lblBankAccount">Account Number: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountNum" runat="server" CssClass="txtboxBankAccount"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg3" ID="RequiredFieldValidator8" runat="server"
                                                ForeColor="Red" ErrorMessage="Num Req" ControlToValidate="txtAccountNum"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="lblBankAccount" Text="Acctivatio Status:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RbActivationStatus" runat="server" Width="220px" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Active</asp:ListItem>
                                                <asp:ListItem>Deactive</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" CssClass="lblBankAccount" Text="Branch Holder:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCompBranchName" Width="222px" CssClass="txtboxBankAccount"
                                                runat="server">
                                            </asp:DropDownList>
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
                                        <asp:Button ID="BtnSaveAccountIndfo" runat="server" ValidationGroup="vg3" CssClass="SaveBtn"
                                            Text="Save" OnClick="BtnSaveAccountIndfo_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnCancelAccountInfo" runat="server" CssClass="clearBtn" Text="Cancel"
                                            CausesValidation="False" OnClick="BtnCancelAccountInfo_Click" />
                                        <asp:Button ID="BtnSearch" runat="server" CssClass="Searchbtn" Text="Search" CausesValidation="False"
                                            OnClick="BtnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:Label ID="Label14" runat="server" Text=" Search Account Info" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="BankAccount_Search_main">
                            <div class="BankAccount_Search_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" CssClass="lblBankAccount" Text="Bank Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBankNameS" runat="server" CssClass="txtboxBankAccount" AutoPostBack="True"
                                                OnTextChanged="txtAccountInfoIdS_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                                ErrorMessage="Mobile Req" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" CssClass="lblBankAccount" Text="Branch Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBranchNameS" runat="server" CssClass="txtboxBankAccount" AutoPostBack="True"
                                                OnTextChanged="txtAccountInfoIdS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="BankAccount_Search_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" CssClass="lblBankAccount" Text="Account Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountNameS" runat="server" CssClass="txtboxBankAccount" AutoPostBack="True"
                                                OnTextChanged="txtAccountInfoIdS_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                                ErrorMessage="Mobile Req" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" CssClass="lblBankAccount" Text="Account Number:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountNumberS" runat="server" CssClass="txtboxBankAccount" AutoPostBack="True"
                                                OnTextChanged="txtAccountInfoIdS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:Label ID="Label22" runat="server" Text="Account Info Records" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="GridView">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVAccountInfo" runat="server" BackColor="White" BorderColor="White"
                                            Width="100%" Height="35px" Font-Size="11px" BorderStyle="Ridge" CellPadding="3"
                                            CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                            OnPageIndexChanging="GVAccountInfo_PageIndexChanging" DataKeyNames="AccountInfoId"
                                            PageSize="4" OnSelectedIndexChanged="GVAccountInfo_SelectedIndexChanged">
                                            <FooterStyle CssClass="tblfooter" />
                                            <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                PageButtonCount="4" />
                                            <PagerStyle CssClass="tblfooter" />
                                            <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <HeaderStyle CssClass="tblheader" />
                                            <Columns>
                                                <asp:CommandField ItemStyle-CssClass="tblrowbgevn" HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:CommandField>
                                                <asp:BoundField ItemStyle-CssClass="tblrowbgodd" DataField="BankName" HeaderText="Bank Name" />
                                                <asp:BoundField DataField="BranchName" ItemStyle-CssClass="tblrowbgevn" HeaderText="Branch Name" />
                                                <asp:BoundField DataField="AccountName" HeaderText="Account Name" ItemStyle-CssClass="tblrowbgodd" />
                                                <asp:BoundField DataField="AccountNum" HeaderText="Account Num #" ItemStyle-CssClass="tblrowbgevn" />
                                                <asp:BoundField DataField="ActivationSatus" HeaderText="Activation Satus "  ItemStyle-CssClass="tblrowbgodd"/>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfAID" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
