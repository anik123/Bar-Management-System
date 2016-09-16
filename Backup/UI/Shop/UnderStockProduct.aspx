<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UnderStockProduct.aspx.cs" Inherits="UI.Shop.UnderStockProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Category Name:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" CssClass="DDL_2_div" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="clabel_Tarun">Product Company:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="DDL_2_div">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 20px;">
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
            <asp:Panel ID="pnlAction" runat="server">
                <asp:Label ID="Label8" runat="server" CssClass="Font_header" Text=" Branch Under Stock Product List"></asp:Label><br>
                <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    PageSize="20" DataKeyNames="ProductId" OnPageIndexChanging="GvUpdate_PageIndexChanging"
                    AllowPaging="true">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="20" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product" />
                        <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="CompName" HeaderText="Company Name" />
                        <asp:BoundField DataField="ReorderValue" HeaderText="Reorder Quantity #" />
                        <asp:BoundField DataField="QuantityStore" HeaderText="Current Stock #" />
                        <asp:BoundField DataField="ReqiredPurQuantity" HeaderText="Reqired Quantity #" />
                    </Columns>
                </asp:GridView>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="btnRefresh" runat="server" CssClass="SaveBtn" Text="Refresh" OnClick="btnRefresh_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCreateReqisisiton" runat="server" CssClass="btnCreateReqisition"
                                Text="Create Purchases Requisition" OnClick="btnCreateReqisisiton_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
