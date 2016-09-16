<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchWiseReorder_Purchase_PriceUI.aspx.cs" Inherits="UI.Admin.BranchWiseReorder_Purchase_PriceUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td style="margin-left: 200px; text-align: right;">
                            <asp:Label ID="Label58" runat="server" Text="Select From Here" CssClass="Font_header"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RbtTriningInfo" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="RbtTriningInfo_SelectedIndexChanged">
                                <asp:ListItem Selected="True">New Entry</asp:ListItem>
                                <asp:ListItem>Update </asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="clabel_Tarun">Reordered Branch:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" CssClass="DDL_2_div" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Category Name:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="DDL_2_div">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
            <div style="margin-top: 20px;">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSearchCancel" runat="server" CssClass="Clear_Short" Text="Cancel"
                                OnClick="btnSearchCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="PnlGridView" Visible="false" runat="server">
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
                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                        HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product" />
                        <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="CompName" HeaderText="Company Name" />
                        <asp:TemplateField HeaderText="Reorder Quantity #">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReorderValue" Width="100px" Text='<%#Eval("ReorderValue") %>'
                                    runat="server"></asp:TextBox>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="txtfr" runat="server" TargetControlID="txtReorderValue"
                                    FilterType="Custom, Numbers" ValidChars="." />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate Of Interest (%)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRateOfInterest" Width="100px" Text='<%#Eval("RateOfInterest") %>'
                                    runat="server"></asp:TextBox>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="ftxtrate" runat="server" TargetControlID="txtRateOfInterest"
                                    FilterType="Custom, Numbers" ValidChars="." />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReorderId" HeaderText="Reorder Id" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="PnlAction" Visible="false" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
