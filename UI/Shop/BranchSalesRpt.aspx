<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchSalesRpt.aspx.cs" Inherits="UI.Shop.BranchSalesRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="SalesMedicin_Customer_main">
                <asp:Label ID="Label8" runat="server" CssClass="Singlelebel_Child" Text="Customer Info"></asp:Label><br>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td style="margin-left: 200px; text-align: right;">
                                <asp:Label ID="Ll24" runat="server" Text="Search From : " CssClass="Font_header"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RbtnSelectMode" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Open </asp:ListItem>
                                    <asp:ListItem>All</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="SalesMedicin_Customer_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Member No:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactAdd" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
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
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Member Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCustomerName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <%-- 
                                <asp:RequiredFieldValidator ID="rcn" runat="server" ValidationGroup="vg6" ForeColor="Red"
                                    ControlToValidate="txtCustomerName">Empty</asp:RequiredFieldValidator>
                                 <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rcn" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                    ControlToValidate="txtCustomerName">Empty</asp:RequiredFieldValidator>
                                --%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Member Type:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSMemType" runat="server" CssClass="input_textcss" Width="202px">
                                    <asp:ListItem Selected="True">Member</asp:ListItem>
                                    <asp:ListItem>Guest</asp:ListItem>
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vg1"
                                    ForeColor="Red" ControlToValidate="ddlSMemType" InitialValue="0">Select</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="mah">
                <table style="width: 100%; margin-top: 30px; clear: both;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="SaveBtn" Text="Search" CausesValidation="false"
                                OnClick="BtnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="Button1_Click" />
                            <asp:Button ID="btnCreate" runat="server" CssClass="Searchbtn" Text="Add Member"
                                CausesValidation="false" OnClick="btnCreate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="GVMember" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    AllowPaging="true" PageSize="50" DataKeyNames="MemberId" OnPageIndexChanging="GVMember_PageIndexChanging">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" HorizontalAlign="Center" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="8" />
                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                        HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("MemberId") %>'
                                    Text="[Show]" CommandName="Show" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemberNo" HeaderText="Member No" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                        <asp:BoundField DataField="Exservice" HeaderText="Ex service" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="clear">
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                            DynamicLayout="true">
                            <ProgressTemplate>
                                <img src="../Images/loader.gif" alt="" style="height: 43px; width: 52px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <asp:Panel ID="pnlUpdate" runat="server">
                        <asp:Label ID="Label7" runat="server" CssClass="Singlelebel_Child" Text="Product Entry"></asp:Label><br>
                        <div class="InvenPur_main">
                            <div class="InvenPur_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lcomp" runat="server" CssClass="clabel_Location" Text="Member :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMName" runat="server" CssClass="input_textcss" Width="202px">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RC" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                                ControlToValidate="ddlMName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Category :"></asp:Label>
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
                                            <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Text="Sub Category:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCName" runat="server" CssClass="input_textcss" Width="202px"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlCName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                                ForeColor="Red" ControlToValidate="ddlCName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Peg Size:" CssClass="clabel_Location"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input_textcss" Width="202px"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
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
                                            <asp:Label ID="LabelMobile1" runat="server" CssClass="clabel_Location" Text="Sales Quantity (Peg):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPQuality" ReadOnly="true" runat="server" CssClass="input_textcss"
                                                Width="200px"></asp:TextBox>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vg1"
                                                ForeColor="Red" ControlToValidate="txtPQuality">Empty</asp:RequiredFieldValidator>
                                            <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                TargetControlID="txtPQuality" ValidChars="012345679." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Unit Price:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPurPrice" runat="server" ReadOnly="true" AutoPostBack="true"
                                                Width="200px"></asp:TextBox>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="vg1"
                                                ForeColor="Red" ControlToValidate="txtPurPrice">Empty</asp:RequiredFieldValidator>
                                            <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                TargetControlID="txtPurPrice" FilterType="Custom, Numbers" ValidChars="." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label58" runat="server" Text="Select From Here" CssClass="clabel_Location"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList AutoPostBack="true" ID="rbtSaleType" runat="server" CssClass="input_textcss"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtSaleType_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">Bar Sale</asp:ListItem>
                                                <asp:ListItem>Off Sale</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                AllowPaging="false" PageSize="8" DataKeyNames="ProductId" OnPageIndexChanging="GVPur_PageIndexChanging">
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
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="CompName" HeaderText="Sub Category " />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                    <%--    <asp:BoundField DataField="Priority" HeaderText="Priority" />--%>
                    <asp:BoundField DataField="Quantity" HeaderText="Peg Size" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                    <asp:BoundField DataField="SaleType" HeaderText="Sale Type" />
                    <asp:BoundField DataField="TotalPrize" HeaderText="Total Prize" />
                </Columns>
            </asp:GridView>
            <div class="IndorpatientPayment_main">
                <div>
                    <asp:Label ID="Label37" runat="server" Text="Payment Panel" CssClass="Singlelebel_Child"></asp:Label>
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
                            <%-- 
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Restuarent Bill :" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRestBill" runat="server" Width="196px" AutoPostBack="true" CssClass="input_textcss"
                                        Text="0" OnTextChanged="txtRestBill_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        TargetControlID="txtRestBill" FilterType="Custom, Numbers" ValidChars="." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Catering Bll:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCateBill" Text="0" runat="server" Width="196px" AutoPostBack="true"
                                        CssClass="input_textcss" OnTextChanged="txtCateBill_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        TargetControlID="txtCateBill" FilterType="Custom, Numbers" ValidChars="." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Bekary Bll:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBekary" Text="0" runat="server" Width="196px" AutoPostBack="true"
                                        CssClass="input_textcss" OnTextChanged="txtBekary_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                        TargetControlID="txtBekary" FilterType="Custom, Numbers" ValidChars="." />
                                </td>
                            </tr>
                            --%>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text=" Total Payable:" CssClass="clabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPayable" runat="server" Width="196px" AutoPostBack="true"
                                        ReadOnly="true" CssClass="input_textcss"></asp:TextBox>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlVat" Visible="false" runat="server">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label43" runat="server" Text="Credit Card Charge:" CssClass="clabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVatPercentage" runat="server" Width="30px" CssClass="input_textcss"
                                            AutoPostBack="true" Text="" OnTextChanged="txtVatPercentage_TextChanged"></asp:TextBox><span
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
                            </asp:Panel>
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
            <asp:HiddenField ID="HFMemberId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
