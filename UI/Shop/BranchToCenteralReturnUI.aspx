<%@ Page Language="C#" AutoEventWireup="true" 
    MasterPageFile="~/Site.Master"
    CodeBehind="BranchToCenteralReturnUI.aspx.cs" 
   Inherits="UI.Shop.BranchToCenteralReturnUI" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div class="clear">
            </div>
            <asp:Panel ID="pnlUpdate" runat="server">
                <asp:Label ID="Label7" runat="server" CssClass="Font_header" Text="Product Entry"></asp:Label><br>
                <div class="InvenPur_main">
                    <center>
                    <div >
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" onselectedindexchanged="ddlCName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Product:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCateName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCateName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCateName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lcomp" runat="server" CssClass="clabel_Location" Text="Product Code:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RC" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                        ControlToValidate="ddlPName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    </center>
                    
                </div>
                <div class="clear">
                </div>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="Add_Short" CausesValidation="true"
                                    ValidationGroup="vg1" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="Clear_Short" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
          <asp:Panel  ID="PnlGridView" Visible="false" runat="server">
            <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                AllowPaging="true" PageSize="8" DataKeyNames="ProductId" >
                <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                    PageButtonCount="8" />
                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                <Columns>
                
                    <asp:BoundField DataField="CompName" HeaderText="Company " />
                    <asp:BoundField DataField="CategoryName" HeaderText="Product" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Code" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                    <asp:BoundField DataField="ProductPurchasePrice" HeaderText="Purchase Price" />
                   
                    <%--    <asp:BoundField DataField="Priority" HeaderText="Priority" />--%>
                    <asp:BoundField DataField="QuantityStore" HeaderText="Current Quantity" />

                    <asp:TemplateField HeaderText="Return to Central Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReturnToCenteral" Width="100px" 
                                    runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                    
                </Columns>
            </asp:GridView>
            </asp:Panel>
            <div class="clear">
            </div>
            <asp:Panel ID="PnlAction" Visible="false" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            <asp:HiddenField ID="HFBranceId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>