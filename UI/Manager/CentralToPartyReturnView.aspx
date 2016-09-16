<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CentralToPartyReturnView.aspx.cs" Inherits="UI.Manager.CentralToPartyReturnView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label14" runat="server" CssClass="Font_header" Text="Search Requisition"></asp:Label>
                <asp:Panel ID="pnlSearch" runat="server">
                    <div class="PharmProPur_main">
                        <div class="InvenPur_left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Text="From Date: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="MM/dd/yyyy" TargetControlID="txtDateFrom">
                                        </ajaxtoolkit:CalendarExtender>
                                        <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                            Operator="DataTypeCheck" ControlToValidate="txtDateFrom" ErrorMessage="Not Valid">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To Date:"></asp:Label>
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
                        <div class="InvenPur_right">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Company : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCName_S" runat="server" CssClass="input_textcss" Width="204px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="clabel_Location" Text="Reteun No#:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReturnNo" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                        <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            TargetControlID="txtReturnNo" FilterType="Custom, Numbers" ValidChars="" Enabled="True" />
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
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSearchCancel" runat="server" CausesValidation="false" CssClass="Clear_Short"
                                        Text="Cancel" OnClick="btnSearchCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>
            <asp:Panel ID="pnlRec" runat="server">
                <div class="PharmProPur">
                    <%--<asp:Label ID="Label1" runat="server" CssClass="Font_header" Text="Requisition List"></asp:Label>--%>
                    <asp:GridView ID="GVCOA" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                        Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                        PageSize="20" DataKeyNames="ReturnNo" OnPageIndexChanging="GVCOA_PageIndexChanging"
                        AllowPaging="true" OnSelectedIndexChanged="GVCOA_SelectedIndexChanged">
                        <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="20" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                        <Columns>
                            <asp:BoundField DataField="ReturnNo" HeaderText="Return No" />
                            <asp:BoundField DataField="CompName" HeaderText=" Product Company" />
                            <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" />
                            <asp:CommandField HeaderText="View Report" SelectText="Click View" ShowHeader="True"
                                ShowSelectButton="True"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
