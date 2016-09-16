<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchReturnProductReciveUI.aspx.cs" Inherits="UI.Manager.BranchReturnProductReciveUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="SalesMedicin_Customer_main">
                <asp:Label ID="Label8" runat="server" CssClass="Font_header" Text="Search"></asp:Label><br>
                <div class="SalesMedicin_Customer_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" CssClass="clabel_Location" Text="Form Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="MM/dd/yyyy" TargetControlID="txtFromDate">
                                </ajaxtoolkit:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                                    Operator="DataTypeCheck" ControlToValidate="txtFromDate" ErrorMessage="Not Valid">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="clabel_Location" Text="To Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="MM/dd/yyyy" TargetControlID="txtToDate">
                                </ajaxtoolkit:CalendarExtender>
                                <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                    Operator="DataTypeCheck" ControlToValidate="txtToDate" ErrorMessage="Not Valid">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="SalesMedicin_Customer_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="clabel_Location" Text="Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" CssClass="input_textcss" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Product Category:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" CssClass="input_textcss" runat="server">
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
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="Add_Short" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" CausesValidation="true" Text="Clear" CssClass="Clear_Short"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    PageSize="20" OnPageIndexChanging="GvUpdate_PageIndexChanging" AllowPaging="true">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="20" />
                    <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                        VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:BoundField DataField="BranchReturnId" HeaderText="Return Id #" />
                        <asp:BoundField DataField="BrProName" HeaderText="Branch Name" />
                        <asp:BoundField DataField="ReturnDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Return Date" />
                        <asp:BoundField DataField="CompName" HeaderText="Company" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity #" />
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="myCheckBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Panel ID="pnlAcction" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Save" CssClass="subbtn" OnClientClick="javascript:return confirm('Do you really want to \n Return items?');"
                                OnClick="btnPrint_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" CssClass="clearbtn"
                                Text="Cancel" OnClick="btnCancelPurchase_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="HFBranceId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
