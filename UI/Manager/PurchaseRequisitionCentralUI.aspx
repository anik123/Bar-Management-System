<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchaseRequisitionCentralUI.aspx.cs" Inherits="UI.Manager.PurchaseRequisitionCentralUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label8" runat="server" CssClass="Font_header">Search by</asp:Label>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Product Name:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" CssClass="DDL_2_div" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RfEmpName" runat="server" CssClass="RequiredFieldcss"
                            ErrorMessage="Category Req" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="clabel_Tarun">Product Company:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="DDL_2_div">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFBr" runat="server" CssClass="RequiredFieldcss"
                            ErrorMessage="Branch Rq" ControlToValidate="ddlCompany"></asp:RequiredFieldValidator>
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
            <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                PageSize="8" DataKeyNames="ProductId" OnSelectedIndexChanged="GvUpdate_SelectedIndexChanged"
                OnPageIndexChanging="GvUpdate_PageIndexChanging" AllowPaging="true">
                <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                    PageButtonCount="8" />
                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                    VerticalAlign="Middle" />
                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                <Columns>
                    <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:CommandField>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="CompName" HeaderText="Company Name" />
                    <asp:BoundField DataField="CenterReorderValue" HeaderText="Central Reorder Quantity #" />
                    <asp:BoundField DataField="QuantityStore" HeaderText="Central Current Stock #" />
                    <asp:BoundField DataField="ReqiredPurQuantity" HeaderText="Central Reqired Quantity #" />
                    <asp:BoundField DataField="RequistionDate" DataFormatString="{0:dd/MM/yy}" HeaderText="Branch Requisition Date #" />
                   
                    
                   <asp:BoundField DataField="BranchReqNo" HeaderText="Branch Requisition No #" />
                   <asp:BoundField DataField="BranchRequistion" HeaderText="Branch Requisition Quantity #" />
                   

                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlUpdate" runat="server">
                <div>
                    <asp:Label ID="Label7" runat="server" CssClass="Font_header" Text="Product Entry"></asp:Label><br>
                </div>
                <div class="InvenPur_main">
                    <div class="InvenPur_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Product:"></asp:Label>
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
                                    <asp:Label ID="Label3" runat="server" Text="Unit:" CssClass="clabel_Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlUnit" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="clabel_Location" Text="Current Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCurrent" runat="server" CssClass="input_textcss" ReadOnly="true"
                                        Text="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelMobile1" runat="server" CssClass="clabel_Location" Text=" Purchase Quantity:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPQuality" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="txtPQuality">Empty</asp:RequiredFieldValidator>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                        TargetControlID="txtPQuality" FilterType="Custom, Numbers" ValidChars="" Enabled="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Unit Price:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurPrice" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="txtPurPrice" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Priority:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RbPriority" CssClass="RbCss" runat="server" AutoPostBack="True"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">High</asp:ListItem>
                                        <asp:ListItem>Mid</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                    </asp:RadioButtonList>
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
                                <asp:Button ID="btnAdd" runat="server" CssClass="Add_Short" CausesValidation="true"
                                    ValidationGroup="vg1" Text="ADD" OnClick="btnAdd_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="Clear_Short" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                AllowPaging="true" PageSize="8" DataKeyNames="ProductId" OnPageIndexChanging="GVPur_PageIndexChanging">
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
                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBPurr_Click" CommandArgument='<%# Eval("ProductId") %>'
                                Text="[Delete]" CommandName="Show" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                    <asp:BoundField DataField="CompName" HeaderText="Company Name" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                    <asp:BoundField DataField="ProductId" HeaderText="Product Id" />
                    <asp:BoundField DataField="BranchReqNo" HeaderText="Branch ReqNo" />
                   
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlAction" Visible="false" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Save" CausesValidation="false" CssClass="subbtn"
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
            <asp:HiddenField ID="HFReOrderId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
