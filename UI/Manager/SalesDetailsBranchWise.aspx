<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SalesDetailsBranchWise.aspx.cs" Inherits="UI.Manager.SalesDetailsBranchWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label14" runat="server" CssClass="Singlelebel_Child" Text="Search For Payment"></asp:Label>
                <div class="PharmPur_Payment_main">
                    <div class="PharmPur_Payment_left">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Text="From Date : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        Format="MM/dd/yyyy" TargetControlID="txtDateFrom">
                                    </ajaxtoolkit:CalendarExtender>
                                    <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                        Operator="DataTypeCheck" ControlToValidate="txtDateFrom" ErrorMessage="Not Valid">
                                    </asp:CompareValidator>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server"
                                        CssClass="RequiredFieldcss" ErrorMessage="Category Re" ControlToValidate="txtDateFrom"></asp:RequiredFieldValidator>
                                    --%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        Format="MM/dd/yyyy" TargetControlID="txtDateTo">
                                    </ajaxtoolkit:CalendarExtender>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                                        Operator="DataTypeCheck" ControlToValidate="txtDateTo" ErrorMessage="Not Valid">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="PharmPur_Payment_right">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" CssClass="clabel_Location" Text="Branch Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranchName" runat="server" Width="202px" AutoPostBack="true"
                                        CssClass="input_textcss">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Sales Invoice #: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalesInvoiceNo" CssClass="input_textcss" Width="202px" runat="server"
                                        OnTextChanged="txtSearch"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                        TargetControlID="txtSalesInvoiceNo" FilterType="Custom, Numbers" ValidChars="."
                                        Enabled="True" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearchCancel" runat="server" CausesValidation="false" CssClass="Clear_Short"
                                    Text="Clear" OnClick="btnSearchCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:Panel ID="pnlRec" runat="server">
                <div class="PharmProPur">
                    <%----%>
                    <asp:Label ID="Label1" runat="server" CssClass="Singlelebel_Child" Text="List of Payment Client"></asp:Label>
                    <asp:GridView ID="GvDueInfo" runat="server" BackColor="White" BorderColor="White"
                        Width="100%" Height="35px" Font-Size="11px" BorderStyle="Ridge" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        OnRowDataBound="GvDueInfo_RowDataBound" OnPageIndexChanging="GvDueInfo_PageIndexChanging"
                        DataKeyNames="SalId" PageSize="20" ShowFooter="True">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="20" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:BoundField DataField="SalId" HeaderText="Sales Invoice #" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Sales Date" />
                            <asp:BoundField DataField="CreateBy" HeaderText="Sales By" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                            <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" />
                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                            <asp:TemplateField HeaderText=" View Sales Invoice">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnview" runat="server" OnCommand="LinkButton_Command_GvDueInfo_ViewDtl"
                                        CommandArgument='<%# Eval("SalId") %>' Text="[View Sales Invoic Report]" CommandName="View Purchase"
                                        CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblTotalCalculation" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
