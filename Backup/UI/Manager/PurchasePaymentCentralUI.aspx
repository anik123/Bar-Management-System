<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchasePaymentCentralUI.aspx.cs" Inherits="UI.Manager.PurchasePaymentCentralUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label14" runat="server" CssClass="Font_header" Text="Search For Payment"></asp:Label>
                <div class="PharmPur_Payment_main">
                    <div class="PharmPur_Payment_left">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Text="From Date : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" OnTextChanged="txtOrderNO_TextChanged"
                                        Width="202px" runat="server"></asp:TextBox>
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
                                    <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" CssClass="input_textcss" Width="202px" AutoPostBack="true"
                                        OnTextChanged="txtOrderNO_TextChanged" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        Format="MM/dd/yyyy" TargetControlID="txtDateTo">
                                    </ajaxtoolkit:CalendarExtender>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                                        Operator="DataTypeCheck" ControlToValidate="txtDateTo" ErrorMessage="Not Valid">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Purchase Invoice NO #: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurchaseInvoiceNO" CssClass="input_textcss" Width="202px" runat="server"
                                        AutoPostBack="true" OnTextChanged="txtOrderNO_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                        TargetControlID="txtPurchaseInvoiceNO" FilterType="Custom, Numbers" ValidChars=""
                                        Enabled="True" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="PharmPur_Payment_right">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Purchase Order NO #: "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrderNO" CssClass="input_textcss" Width="202px" runat="server"
                                        AutoPostBack="true" OnTextChanged="txtOrderNO_TextChanged"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="txtOrderNO" FilterType="Custom, Numbers" ValidChars="" Enabled="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCompanyName" runat="server" Width="202px" CssClass="input_textcss">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="clabel_Location" Text="Sales Man:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalesManName" runat="server" OnTextChanged="txtOrderNO_TextChanged"
                                        AutoPostBack="true" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearchCancel" runat="server" CssClass="Clear_Short" Text="Clear"
                                    OnClick="btnSearchCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:Panel ID="pnlRec" runat="server">
                <div class="PharmProPur">
                    <asp:Label ID="Label1" runat="server" CssClass="Font_header" Text="List of Payment Client"></asp:Label>
                    <asp:GridView ID="GvDueInfo" runat="server" BackColor="White" BorderColor="White"
                        Width="100%" Height="35px" Font-Size="12px" BorderStyle="Ridge" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="GvDueInfo_PageIndexChanging" DataKeyNames="PurId" PageSize="5"
                        OnSelectedIndexChanged="GvDueInfo_SelectedIndexChanged">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="5" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:CommandField HeaderText="Payment " ShowHeader="True" ControlStyle-ForeColor="Red"
                                SelectText="Click Pay" ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                            <asp:BoundField DataField="PurId" HeaderText="Purchase NO#" />
                            <asp:BoundField DataField="CreateDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Purchase Date" />
                            <asp:BoundField DataField="SalesManName" HeaderText="Sales Man" />
                            <asp:BoundField DataField="PurOrderNo" HeaderText="Order NO#" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                            <asp:TemplateField HeaderText="Product Invoice">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnview" runat="server" OnCommand="LinkButton_Command_GvDueInfo_ViewDtl"
                                        CommandArgument='<%# Eval("PurId") %>' Text="[View Purchase Report]" CommandName="View Purchase"
                                        CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <div class="Salpayment_main">
                <asp:Label ID="Label4" runat="server" Text=" Purchase Payment" CssClass="Font_header"></asp:Label>
                <div class="Salpayment_left">
                    <asp:Panel ID="pnlBank" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" CssClass="clabel_Tarun" runat="server" Text="Total Bank Amount(TK)"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalBankAmount" ForeColor="Red" runat="server" Width="200px" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Labdel10" runat="server" CssClass="clabel_Tarun" Text="Account"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBank" runat="server" Width="202px" CssClass="input_textcss"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RFdb" runat="server" ValidationGroup="vg2" ForeColor="Red"
                                        ControlToValidate="ddlBank" InitialValue="0">Select One</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label28" CssClass="clabel_Tarun" runat="server" Text=" Current Bank(Tk)"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBankAmount" ForeColor="Red" runat="server" Width="200px" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Labedl11" CssClass="clabel_Tarun" runat="server" Text="LC Number"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLCNumber" CssClass="input_textcss" runat="server" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" CssClass="clabel_Tarun" runat="server" Text="Cheque No"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChequeNo" Width="200px" CssClass="input_textcss" runat="server"></asp:TextBox>
                                    <span class="Mandatory">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" CssClass="clabel_Tarun" runat="server" Text="Cheque Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChequeDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server"
                                        Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtChequeDate">
                                    </ajaxtoolkit:CalendarExtender>
                                    <span class="Mandatory">*</span>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" Type="Date" ForeColor="Red"
                                        Operator="DataTypeCheck" ControlToValidate="txtChequeDate" ErrorMessage="Not Valid">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" CssClass="clabel_Tarun" runat="server" Text="Issue Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIssueDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Enabled="True"
                                        Format="MM/dd/yyyy" TargetControlID="txtIssueDate">
                                    </ajaxtoolkit:CalendarExtender>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" Type="Date" ForeColor="Red"
                                        Operator="DataTypeCheck" ControlToValidate="txtIssueDate" ErrorMessage="Not Valid">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div class="Salpayment_Right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label9" CssClass="clabel_Tarun" runat="server" Text="Payment Mode"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoPayment" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    OnSelectedIndexChanged="rdoPayment_SelectedIndexChanged">
                                    <asp:ListItem id="rdobtnBank" CssClass="input_textcss" Selected="True" runat="server"
                                        Value="Bank" />
                                    <asp:ListItem id="rdobtnCash" CssClass="input_textcss" runat="server" Value="Cash" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCashLbl" runat="server" Visible="false" CssClass="clabel_Tarun"
                                    Text="Current Cash"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCashAount" runat="server" Visible="false" ForeColor="#E93535" Width="200px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label110" CssClass="clabel_Tarun" runat="server" Text="Total Payable (Tk)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalPayable" ForeColor="Red" ReadOnly="true" CssClass="input_textcss"
                                    Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="clabel_Tarun" Text="Paid Amount"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaidAmoun" OnTextChanged="txtPaidAmoun_TextChanged" Width="130px"
                                    CssClass="input_textcss" runat="server"></asp:TextBox><span class="Mandatory"> *</span>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    TargetControlID="txtPaidAmoun" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                <asp:Button ID="BtnPaid" runat="server" CssClass="PaidButton" CausesValidation="true"
                                    Text="Paid" OnClick="BtnPaid_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="clabel_Tarun" Text="Due Amount 	"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDueAmount" CssClass="input_textcss_PharmPurchase_cash" runat="server"
                                    Width="200px" ReadOnly="True">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" CssClass="clabel_Tarun" Text="Sales Man"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSalesManNamePayment" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                <span class="Mandatory">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label210" runat="server" CssClass="clabel_Tarun" Text="Note"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNote" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                <asp:Panel ID="pnlAction" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Save&Print" CssClass="subbtn" OnClick="btnPrint_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" CssClass="clearbtn"
                                    Text="Cancel" OnClick="btnCancelPurchase_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:HiddenField ID="HFPurId" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HFPhamrPaymentID" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HFTotalPrice" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HFTransectionNo" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
