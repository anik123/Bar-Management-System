<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CocktailUI.aspx.cs" Inherits="UI.Shop.CocktailUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="middle">
            <div class="Singlelebel_Child">
                <asp:Label ID="Label5" runat="server" Text="Cocktail Entry" ></asp:Label>
                </div>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" AutoPostBack="true" CssClass="SingleDropDownList"
                                runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" InitialValue="0"
                                runat="server" CssClass="RequiredFieldcss" ErrorMessage="Product Req" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="SingleLbl">Sub Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubCategory" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="ddlSubCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Item Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlItemCategory" AutoPostBack="true" CssClass="SingleDropDownList"
                                runat="server" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" InitialValue="0"
                                runat="server" CssClass="RequiredFieldcss" ErrorMessage="Product Req" ControlToValidate="ddlItemCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Item Sub Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlItemSubCategory" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="ddlItemSubCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="SingleLbl">Item Quantity</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlQuantity" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="ddlQuantity"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFUID" runat="server" />
                </table>
            </div>
            <div class="clear">
            </div>
            <div class="clear">
            </div>
            <div>
                <table style="width: 100%;clear:both;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" CssClass="Add_Short" CausesValidation="true"
                                ValidationGroup="vg1" Text="ADD" OnClick="btnAdd_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="Clear_Short" 
                                CausesValidation="false" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="GVPur" Visible="false" runat="server" BackColor="#92B8EF" ForeColor="Snow"
                    BorderColor="#92B8EF" Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge"
                    BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                    Height="12px" Width="100%" AllowPaging="true" PageSize="8" OnPageIndexChanging="GVPur_PageIndexChanging">
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
                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBPurr_Click" Text="[Delete]"
                                    CommandName="Show" CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductId" HeaderText="Product Serial #" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                        <asp:BoundField DataField="CompName" HeaderText="Sub Category" />
                        <asp:BoundField DataField="ItemProductId" HeaderText="Item Product Serial" />
                        <asp:BoundField DataField="ItemCategoryName" HeaderText="Item Category Name" />
                        <asp:BoundField DataField="ItemSubCategoryName" HeaderText="Item Sub Category Name" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Panel Visible="false" ID="pnlSave" CssClass="IndorpatientPayment_main" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Save" CssClass="subbtn" OnClick="btnPrint_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelCocktail" runat="server" CausesValidation="false" CssClass="clearbtn"
                                    Text="Cancel" OnClick="btnCancelCocktail_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="clear">
            </div>
            <div>
                <div class="SalesMedicin_Customer_main">
                <div class="Singlelebel_Child">
                    <asp:Label ID="Label7" runat="server" Text=" Search Cocktail Info"></asp:Label>
                    </div>
                    <br>
                    <div class="SalesMedicin_Customer_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="Category : "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlViewCategory" AutoPostBack="true" CssClass="SingleDropDownList"
                                        runat="server" OnSelectedIndexChanged="ddlViewCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="SalesMedicin_Customer_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" CssClass="clabel_Location" Text="Sub Category :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlViewSubCategory" CssClass="SingleDropDownList" runat="server"
                                        OnSelectedIndexChanged="ddlViewSubCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div>
                <div>
                    <table style="width: 100%;clear:both;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="Add_Short" Text="View" 
                                    onclick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnViewClear" runat="server" CausesValidation="true" Text="Clear"
                                    CssClass="Clear_Short" onclick="btnViewClear_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptMainHead" runat="server">
                                <HeaderTemplate>
                                    <table id="table1" width="100%">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                          <!--
                                            <td>
                                                Options
                                            </td>
                                             -->
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
                                    <!-- 
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("CocktaiInfoId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                       --> <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("CategoryName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("CompName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Quantity") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label1" runat="server" Text=" Product Info..." ForeColor="White"></asp:Label>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
