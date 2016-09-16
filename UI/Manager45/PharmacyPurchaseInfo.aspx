<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PharmacyPurchaseInfo.aspx.cs" Inherits="HMS.UI.MedicationUI.PharmacyPurchaseInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label13" runat="server" Text=" Purchase Medication" Font-Bold="True"
            Font-Size="10pt" ForeColor="#006699"></asp:Label>
    </div>
    <div class="AccountUi_main">
        <div class="AccountUi_left">
            <table style="width: 100%;">
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Medication Type:"></asp:Label>
                    </td>
                    <td class="style9">
                        <asp:DropDownList ID="ddlPType" runat="server" CssClass="input_textcss" Width="171px"
                            Height="22px" OnSelectedIndexChanged="ddlPType_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lcomp" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Company Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCompName" runat="server" CssClass="input_textcss" Width="171px"
                            Height="22px" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Medication Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTName" runat="server" Width="172px" CssClass="input_textcss"
                            Height="22px" OnSelectedIndexChanged="ddlTreadName_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Unit:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnit" runat="server" CssClass="input_textcss" Width="170px" AutoPostBack="true"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Organic Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrganicName" runat="server" Width="170px" AutoPostBack="true"
                            CssClass="input_textcss" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="AccountUi_right">
            <table style="width: 100%;">
                <%-- <tr>
                    <td align="right">
                        <asp:Label ID="LabelDOB" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Purchase Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurDate" runat="server" CssClass="input_textcss" Width="170px"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        <asp:Label ID="LabelMobile1" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text=" Purchase Quantity:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurQuan" runat="server" CssClass="input_textcss" Width="170px"></asp:TextBox>
                        <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                            TargetControlID="txtPurQuan" FilterType="Custom, Numbers" ValidChars="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="PurUnit Price:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurPrice" runat="server" CssClass="input_textcss" Width="170px"></asp:TextBox>
                        <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                            TargetControlID="txtPurPrice" FilterType="Custom, Numbers" ValidChars="." />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Font-Bold="True"
                            Text="Remarks:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="input_textcss" Width="170px"></asp:TextBox>
                    </td>
                </tr>
                <asp:HiddenField ID="HFPurID" runat="server" />
                <asp:Label ID="lblSalPay" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblPurPay" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblCurrBankAmount" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblCashPurchase" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblCashSalPay" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblCashTotal" Visible="false" runat="server"></asp:Label>
            </table>
        </div>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%; height: 33px;">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSave" runat="server" CssClass="" Width="80px" Text="ADD" OnClick="btnSave_Click" />
                </td>
                <td align="left">
                    <asp:Button ID="btnCancel" runat="server" Text="Clear" Width="80px" CssClass="" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="left" valign="top" colspan="8">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                        CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                        GridLines="None" AutoGenerateColumns="False" Height="16px" AllowPaging="True"
                        OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" OnRowDeleting="GridView1_RowDeleting">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false"
                                        OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Type" HeaderText="Medication Type" />
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                            <asp:BoundField DataField="PurchaseQuantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="PurUnitprice" HeaderText="PurUnitprice" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div class="Salpayment_main">
        <div>
            <asp:Label ID="Label1" runat="server" Text=" Purchase Payment" Font-Bold="True" Font-Size="10pt"
                ForeColor="#006699"></asp:Label>
        </div>
        <div class="Salpayment_left">
            <asp:Panel ID="pnlBank" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Labdel10" runat="server" CssClass="clabel_Tarun" Text="Account"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBank" runat="server" Width="202px" CssClass="input_textcss"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvbank" ControlToValidate="ddlBank"
                                Display="None" ErrorMessage="<b>Required Field Missing</b><br />Bank Name is required." />
                            <ajaxtoolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
                                TargetControlID="rfvbank" HighlightCssClass="validatorCalloutHighlight" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label28" CssClass="clabel_Tarun" runat="server" Text=" Current Bank(Tk)"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBankAmount" ForeColor="Red" CssClass="input_textcss" runat="server"
                                Width="200px" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Labedl11" CssClass="clabel_Tarun" runat="server" Text="LC Number"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLCNumber" CssClass="input_textcss" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" CssClass="clabel_Tarun" runat="server" Text="Cheque No"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtChequeNo" Width="200px" CssClass="input_textcss" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="Label18" CssClass="clabel_Tarun" runat="server" Text="Cheque Date"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtChequeDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server"
                                Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtChequeDate">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="Label19" CssClass="clabel_Tarun" runat="server" Text="Issue Date"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIssueDate" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Enabled="True"
                                Format="MMMM d, yyyy" TargetControlID="txtIssueDate">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="PnlCash" runat="server" Visible="false">
                <table style="width: 100%;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" CssClass="clabel_Tarun" Text="Current Cash"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCashAount" runat="server" ForeColor="#E93535" Width="200px" CssClass="input_textcss"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" CssClass="clabel_Tarun" Text="Paid Amount"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaidAmoun" OnTextChanged="txtPaidAmoun_TextChanged" CssClass="input_textcss"
                                Width="200px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="Label5" runat="server" CssClass="clabel_Tarun" Text="Due Amount 	"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDueAmount" CssClass="input_textcss" runat="server" Width="200px"
                                ReadOnly="True">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="Salpayment_Right">
            <asp:Panel ID="Panel3" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td class="style3" align="right">
                            <asp:Label ID="Label6" CssClass="clabel_Tarun" runat="server" Text="Payment Mode"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rdoPayment" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="rdoPayment_SelectedIndexChanged">
                                <asp:ListItem id="rdobtnBank" CssClass="input_textcss" Selected="True" runat="server"
                                    Value="Bank" />
                                <asp:ListItem id="rdobtnCash" CssClass="input_textcss" runat="server" Value="Cash" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:Label ID="Label110" CssClass="clabel_Tarun" runat="server" Text="Total Payable (Tk)"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotalPayable" ForeColor="Red" AutoPostBack="true" CssClass="input_textcss"
                                Width="200px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="clabel_Tarun" Text="SalesMan Name"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSalesmanName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label210" runat="server" CssClass="clabel_Tarun" Text="Note"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNote" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <asp:HiddenField ID="hfaccountid" runat="server" />
                    <%--  <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label8" runat="server" CssClass="clabel_Tarun" Text="Due Amount 	"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDueAmount" CssClass="input_textcss" runat="server" Width="200px"
                                        ReadOnly="True">0</asp:TextBox>
                                    <asp:HiddenField ID="hfaccountid" runat="server" />
                                </td>
                            </tr> --%>
                </table>
            </asp:Panel>
        </div>
        <%--</ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="txtPaidAmoun" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </div>
    <%--<div class="Purechase_main">
        <table style="width: 100%;">
            <tr>
                <td align="right">
                    <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Total Price:"></asp:Label>
                </td>
                <td align="left" class="style13">
                    <asp:TextBox ID="txtTotalPrice" CssClass="input_textcss" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label15" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Paid Amount:"></asp:Label>
                </td>
                <td align="left" class="style13">
                    <asp:TextBox ID="txtPaidAmoun" CssClass="input_textcss" runat="server" AutoPostBack="true"
                        OnTextChanged="txtPaidAmoun_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label16" runat="server" CssClass="clabel_Location" Font-Bold="True"
                        Text="Due Amount:"></asp:Label>
                </td>
                <td align="left" class="style13">
                    <asp:TextBox ID="txtDueAmount" CssClass="input_textcss" runat="server">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="Label17" runat="server" Text="Note:" CssClass="clabel_Location" Font-Bold="True"></asp:Label>
                </td>
                <td align="left" class="style13">
                    <asp:TextBox ID="txtNote" CssClass="input_textcss" runat="server" Height="44px" TextMode="MultiLine"
                        Width="177px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>--%>
    <div class="clear">
    </div>
    <div>
        <asp:Panel ID="pnlAction" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="right">
                        <asp:Button ID="btnPrint" runat="server" Text="Save&Print" Width="80px" OnClick="btnPrint_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" Width="80px"
                            Text="Cancel" OnClick="btnCancelPurchase_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
