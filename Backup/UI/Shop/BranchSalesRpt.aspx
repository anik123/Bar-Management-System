<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchSalesRpt.aspx.cs" Inherits="UI.Shop.BranchSalesRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="SalesMedicin_Customer_main">
                <asp:Label ID="Label8" runat="server" CssClass="Font_header" Text="Customer Info"></asp:Label><br>
                <div class="SalesMedicin_Customer_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Customer Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCustomerName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rcn" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                    ControlToValidate="txtCustomerName">Empty</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="Mobile No:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="ftm" runat="server" TargetControlID="txtMobileNo"
                                    FilterType="Custom, Numbers" ValidChars="+" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="SalesMedicin_Customer_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Contact Address:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactAdd" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvcon" runat="server" ForeColor="Red" ControlToValidate="txtCustomerName">Name Req</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Remarks:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
            <asp:Panel ID="pnlUpdate" runat="server">
                <asp:Label ID="Label7" runat="server" CssClass="Font_header" Text="Product Entry"></asp:Label><br>
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
                                    <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Category:"></asp:Label>
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
                                    <asp:Label ID="lcomp" runat="server" CssClass="clabel_Location" Text="Product Name:"></asp:Label>
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
                                    <asp:Label ID="Label4" runat="server" Text="Unit:" CssClass="clabel_Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="rfvu" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                        ControlToValidate="ddlUnit" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="clabel_Location" Text="Current Quantity:"></asp:Label>
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
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="txtPQuality" FilterType="Custom, Numbers" ValidChars="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Unit Price:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurPrice" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="txtPurPrice">Empty</asp:RequiredFieldValidator>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        TargetControlID="txtPurPrice" FilterType="Custom, Numbers" ValidChars="." />
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
                                Text="[Delete]" CommandName="Show" CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                    <asp:BoundField DataField="CompName" HeaderText="Company " />
                    <%--    <asp:BoundField DataField="Priority" HeaderText="Priority" />--%>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                </Columns>
            </asp:GridView>
            <div class="IndorpatientPayment_main">
                <div>
                    <asp:Label ID="Label37" runat="server" Text="Payment Panel" CssClass="Font_header"></asp:Label>
                </div>
                <asp:Panel ID="PnlExSerch_new" CssClass="IndorpatientPayment_main" runat="server">
                    <asp:Panel ID="pnlCash" runat="server" CssClass="IndorpatientPayment_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label42" CssClass="clabel" runat="server" Text="Payment Mode"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdoPayment" Width="263px" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="rdoPayment_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem id="rdobtnCash" runat="server" Selected="True" Value="Cash" />
                                        <asp:ListItem id="rdobtnBank" runat="server" Value="Credit Card" />
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text=" Total Payable:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPayable" runat="server" Width="196px" AutoPostBack="true"
                                        ReadOnly="true" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label43" runat="server" Text="Vat/Tax:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVatPercentage" runat="server" Width="30px" CssClass="input_textcss"
                                        AutoPostBack="true" OnTextChanged="txtVatPercentage_TextChanged"></asp:TextBox><span
                                            style="vertical-align: top;">%</span>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="filtervatparcen" runat="server" TargetControlID="txtVatPercentage"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:TextBox ID="txtVatAfterpercentage" runat="server" Width="60px" CssClass="input_textcss">0</asp:TextBox><span
                                        style="vertical-align: top;">tk</span>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="fav" runat="server" TargetControlID="txtVatAfterpercentage"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:Button ID="btnVatcalculation" runat="server" Text="Vat" Height="22px" Width="78"
                                        OnClick="btnVatcalculation_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Text="Discount:" CssClass="clabel"></asp:Label>
                                </td>
                                <td valign="top">
                                    <%--   <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Discount">
                                <ContentTemplate>--%>
                                    <asp:TextBox ID="txtDicountpercentage" runat="server" Width="30px" CssClass="input_textcss"
                                        OnTextChanged="txtDicountpercentage_TextChanged"></asp:TextBox><span style="vertical-align: top;">%</span>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="fd" runat="server" TargetControlID="txtDicountpercentage"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:TextBox ID="txtDicountAfterpercentage" runat="server" Width="60px" CssClass="input_textcss">0</asp:TextBox><span
                                        style="vertical-align: top;">tk</span>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="fda" runat="server" TargetControlID="txtDicountAfterpercentage"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:Button ID="BtnDiscountCal" runat="server" Text="Discount" Height="22px" Width="78"
                                        OnClick="BtnDiscountCal_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Discount Discription:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscountDescription" runat="server" Width="196px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label45" runat="server" Text="Net Total Payable:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNetTotalPayable" runat="server" Width="196px" ReadOnly="true"
                                        CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Text="Paid Amount:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaidAmount" runat="server" Width="141px" CssClass="input_textcss"
                                        AutoPostBack="true" OnTextChanged="txtPaidAmount_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="Fvp" runat="server" TargetControlID="txtPaidAmount"
                                        FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:Button ID="BtnPaidAmount" runat="server" Text="Paid" Height="22px" Width="50px"
                                        OnClick="BtnPaidAmount_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Text="Due Amount:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDueAmount" runat="server" ReadOnly="true" Width="196px" CssClass="input_textcss">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Note:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNote" runat="server" Width="196px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlBank" runat="server" CssClass="IndorpatientPayment_Right" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label41" runat="server" Text="  Holder Name:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHolderName" runat="server" Width="263px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label38" runat="server" Text=" Bank Name:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server" Width="263px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="Appr Code:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApprCode" runat="server" Width="150px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Text="Card No:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="150px" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </div>
            <div class="clear">
            </div>
            <asp:Panel ID="pnlAction" Visible="false" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Save" CssClass="subbtn" OnClick="btnPrint_Click" />
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
