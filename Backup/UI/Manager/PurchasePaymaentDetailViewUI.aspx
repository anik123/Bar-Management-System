<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchasePaymaentDetailViewUI.aspx.cs" Inherits="UI.Manager.PurchasePaymaentDetailViewUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Text="Show Details About the Purchase Transection"
            CssClass="Font_header"></asp:Label>
    </div>
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:GridView ID="GvDueInfo" runat="server" BackColor="White" BorderColor="White"
                        Width="100%" Height="35px" Font-Size="12px" BorderStyle="Ridge" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="GvDueInfo_PageIndexChanging" DataKeyNames="PurPayDtlId"
                        PageSize="15">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="7" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField></asp:TemplateField>
                            <asp:BoundField DataField="PurId" HeaderText="Purchase No#" />
                            <asp:BoundField DataField="PurPayDtlId" HeaderText="Payment Id" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="Last Pay Date" />
                           <%-- <asp:BoundField DataField="CompName" HeaderText="Company" />--%>
                            <asp:BoundField DataField="SalesManName" HeaderText="Sales Man" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                            <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />
                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                            <asp:TemplateField HeaderText="Product Invoice">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnProduct" runat="server" OnCommand="LinkButton_Command_GvDueInfo_ProductInfo"
                                        CommandArgument='<%# Eval("PurId") %>' Text="[Product]" CommandName="ViewDetailsProduct"
                                        CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment Invoice">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnview" runat="server" OnCommand="LinkButton_Command_GvDueInfo_ViewDtl"
                                        CommandArgument='<%# Eval("PurPayDtlId") + ";" + Eval("PurId") %>' Text="[Invoice]"
                                        CommandName="ViewDetails" CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
