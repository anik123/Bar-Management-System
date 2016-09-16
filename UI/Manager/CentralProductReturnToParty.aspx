<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CentralProductReturnToParty.aspx.cs" Inherits="UI.Manager.CentralProductReturnToParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="SalesMedicin_Customer_main">
                <asp:Label ID="Label8" runat="server" CssClass="Font_header" Text=" Search Customer Info"></asp:Label><br>
                <div class="SalesMedicin_Customer_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Product Company:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCompanyName" CssClass="input_textcss" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Product:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" CssClass="input_textcss" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="SalesMedicin_Customer_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Product:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProduct" CssClass="input_textcss" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="clabel_Location" Text="Branch:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" CssClass="input_textcss" runat="server">
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
                        <asp:BoundField DataField="BrProName" HeaderText="Return Branch" />
                        <asp:BoundField DataField="ReturnDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Return Date" />
                        <asp:BoundField DataField="CompName" HeaderText="Company" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Product" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Code" />
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
