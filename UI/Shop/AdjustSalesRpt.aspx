<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdjustSalesRpt.aspx.cs" Inherits="UI.Shop.AdjustSalesRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
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
                                <asp:TextBox ID="txtContactAdd" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtCustomerName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
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
                                <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Member Type:"></asp:Label>
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
                <table style="width: 100%; margin-top: 30px; clear: both;">
                    <tr>
                        <td style="width: 50%;">
                            <asp:Button ID="btnSearch" runat="server" CssClass="SaveBtn" Text="Search" CausesValidation="false"
                                OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    AllowPaging="true" PageSize="8" DataKeyNames="MemberId" 
                    OnPageIndexChanging="GVPur_PageIndexChanging" 
                    >
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
            <asp:HiddenField ID="HFMemberId" runat="server" />
            <asp:Panel ID="pnlSale" Visible="false" runat="server">
                <asp:Label ID="Label7" runat="server" CssClass="Singlelebel_Child" Text="Transaction Info"></asp:Label><br>
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
                                                Transaction Date
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Activity" CommandArgument='<%# Eval("CreateDate") %>'
                                                Text="[Select]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%#  Eval("CreateDate","{0:dd/MM/yyyy}") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label1" runat="server" Text=" Transaction Info..." ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCurrentPagePayment" runat="server"> </asp:Label>
                            <asp:HyperLink ID="lnkPrevPayment" runat="server"><< Prev</asp:HyperLink>
                            <asp:HyperLink ID="lnkNextPayment" runat="server">Next >></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlDetails" Visible="false" runat="server">
                <asp:Label ID="Label9" runat="server" CssClass="Singlelebel_Child" Text="Transaction Details"></asp:Label><br>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptDetails" runat="server">
                                <HeaderTemplate>
                                    <table id="table1" width="100%">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                            <td>
                                                Options
                                            </td>
                                            <td>
                                                Sal No
                                            </td>
                                            <td>
                                                Paid Amount
                                            </td>
                                            <td>
                                                Due Amount
                                            </td>
                                            <td>
                                                Total Payable
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%# Eval("SalId") %>'
                                                OnCommand="LinkButton_Inovice" Text="[View]" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%#  Eval("SalId") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%#  Eval("PaidAmount") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("DueAmount") %>' />
                                        </td>
                                         <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("TotalAmount") %>' />
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
                            <asp:Label ID="lblCurrentDetails" runat="server"> </asp:Label>
                            <asp:HyperLink ID="lnkPrevDetails" runat="server"><< Prev</asp:HyperLink>
                            <asp:HyperLink ID="lnkNextDetails" runat="server">Next >></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>


            <asp:Panel ID="pnlProduct" Visible="false" runat="server">
                <asp:Label ID="Label2" runat="server" CssClass="Singlelebel_Child" Text="Transaction Details"></asp:Label><br>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptProduct" runat="server">
                                <HeaderTemplate>
                                    <table id="table1" width="100%">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                            <td>
                                                Options
                                            </td>
                                            <td>
                                                Category
                                            </td>
                                            <td>
                                                Sub Category
                                            </td>
                                            <td>
                                                Quantity
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%# Eval("SaleDtlId") %>'
                                                OnCommand="LinkButton_Product" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" Text="[Delete]" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%#  Eval("CategoryName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%#  Eval("CompName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("Quantity") %>' />
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
                            <asp:Label ID="lblCurrentProduct" runat="server"> </asp:Label>
                            <asp:HyperLink ID="lnkPrevProduct" runat="server"><< Prev</asp:HyperLink>
                            <asp:HyperLink ID="lnkNextProduct" runat="server">Next >></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="HFDate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
