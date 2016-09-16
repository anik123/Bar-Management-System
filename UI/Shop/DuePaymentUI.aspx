<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DuePaymentUI.aspx.cs" Inherits="UI.Shop.DuePaymentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="SalesMedicin_Customer_main">
                <asp:Label ID="Label8" runat="server" CssClass="Singlelebel_Child" Text="Customer Info"></asp:Label><br>
                <div class="SalesMedicin_Customer_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Member No:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemno" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="Mobile No:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="ftm" runat="server" TargetControlID="txtMobileNo"
                                    FilterType="Custom, Numbers" ValidChars="+" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="SalesMedicin_Customer_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Member Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <%-- 
                                <asp:RequiredFieldValidator ID="rcn" runat="server" ValidationGroup="vg6" ForeColor="Red"
                                    ControlToValidate="txtCustomerName">Empty</asp:RequiredFieldValidator>
                                 <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rcn" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                    ControlToValidate="txtCustomerName">Empty</asp:RequiredFieldValidator>
                                --%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="clabel_Location" Text="Member Type :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSMemType" runat="server" CssClass="input_textcss" Width="202px">
                                    <asp:ListItem Selected="True">Member</asp:ListItem>
                                    <asp:ListItem>Guest</asp:ListItem>
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vg1"
                                    ForeColor="Red" ControlToValidate="ddlSMemType" InitialValue="0">Select</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="mah">
                <table style="width: 100%; margin-top: 30px;clear:both;">
                    <tr>
                        <td style="width: 400px; text-align: center;">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="SaveBtn" Text="Search" CausesValidation="false"
                                OnClick="BtnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSearchClear" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnSearchClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
               <asp:GridView ID="GVMember" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    AllowPaging="true" PageSize="8" DataKeyNames="MemberId" OnPageIndexChanging="GVMember_PageIndexChanging">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" HorizontalAlign="Center" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="8" />
                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                        HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("MemberId") %>'
                                    Text="[Show]" CommandName="Show" CausesValidation="false"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemberNo" HeaderText="Member No" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                        <asp:BoundField DataField="Exservice" HeaderText="Ex service" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Panel ID="pnlSale" Visible="false" runat="server">
                    <asp:Label ID="Label3" runat="server" CssClass="Singlelebel_Child" Text="Transaction Info"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Repeater ID="RptPayment" runat="server">
                                    <HeaderTemplate>
                                        <table id="table1" width="100%">
                                            <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                                <td>
                                                    Options
                                                </td>
                                                <td>
                                                    Due Date
                                                </td>
                                                <td>
                                                    Due Amount
                                                </td>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="text-align: center;">
                                            <td>
                                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Dueload" CommandArgument='<%# Eval("SalePaymentId") %>'
                                                    Text="[Select]" CommandName="Show" CausesValidation="false" />
                                                <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%# Eval("SalId") %>'
                                                    OnCommand="LinkButton_Inovice" Text="[View Sales Invoic Report]" CausesValidation="false" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%#  Eval("CreateDate","{0:dd/MM/yyyy}") %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("DueAmount") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr style="background-color: #8FADD9">
                                            <td colspan="6" align="center">
                                                <asp:Label ID="Label1" runat="server" Text=" Member Info..." ForeColor="White"></asp:Label>
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
                </asp:Panel>
            </div>
            <div class="clear">
            </div>
            <div>
                <asp:Label ID="Label1255" runat="server" Text="Due Entry" CssClass="Singlelebel_Child"></asp:Label>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="SingleLbl">Member</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMember" AutoPostBack="true" CssClass="SingleDropDownList"
                                runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" InitialValue="0"
                                runat="server" CssClass="RequiredFieldcss" ErrorMessage="Product Req" ControlToValidate="ddlMember"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="SingleLbl">Due Date</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDueDate" ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="txtDueDate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Due Amount</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDueAmount" ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtDueAmount"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="SingleLbl">Paid Amount</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaidAmount" ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtPaidAmount"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" CssClass="SingleLbl">Return Amount</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReturn" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtReturn"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFPaymentId" runat="server" />
                </table>
            </div>
            <div>
                <table style="width: 100%; margin-top: 30px;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="Button2" runat="server" Visible="false" CssClass="SaveBtn" Text="Search"
                                CausesValidation="false" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="Searchbtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Add" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Cancel" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                AllowPaging="true" PageSize="8" DataKeyNames="SalePaymentId" OnPageIndexChanging="GVPur_PageIndexChanging">
                <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                    PageButtonCount="8" />
                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBPurr_Click" CommandArgument='<%# Eval("SalePaymentId") %>'
                                Text="[Delete]" CommandName="Show" CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SalePaymentId" HeaderText="ID" />
                    <asp:BoundField DataField="DueAmount" HeaderText="Due Amount " />
                    <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />
                    <asp:BoundField DataField="ReturnAmount" HeaderText="Return Amount" />
                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                </Columns>
            </asp:GridView>
            <div class="clear">
            </div>
            <asp:Panel ID="pnlAction" Visible="false" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Save" CssClass="subbtn" OnClick="btnPrint_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" CssClass="clearbtn"
                                Text="Cancel" OnClick="btnCancelPurchase_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
