<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PharmPurchaseDueDtl.aspx.cs" Inherits="HMS.UI.MedicationUI.PharmPurchaseDueDtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:GridView ID="GvDueInfo" runat="server" BackColor="White" BorderColor="White"
                        Width="100%" Height="35px" Font-Size="12px" BorderStyle="Ridge" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="GvDueInfo_PageIndexChanging" DataKeyNames="PharmPurPayDtlId"
                        PageSize="15">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="7" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField>
                               <%-- <ItemTemplate>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_GvDueInfo"
                                        CommandArgument='<%# Eval("PharmPurPaymentId") %>' Text="[Show]" CommandName="Show"
                                        CausesValidation="false" />
                                </ItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PurId" HeaderText="PurId" />
                             <asp:BoundField DataField="PharmPurPayDtlId" HeaderText="PharmPurPayDtlId" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="Last Pay Date" />
                            <asp:BoundField DataField="CompName" HeaderText="Comp Name" />
                            <asp:BoundField DataField="SalesManName" HeaderText="SalesManName" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                            <asp:BoundField DataField="PaidAmount" HeaderText="PaidAmount" />
                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
