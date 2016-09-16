<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PharmPurcahseDueUI.aspx.cs" Inherits="HMS.UI.MedicationUI.PharmPurcahseDueUI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function NewWindow() {
        document.forms[0].target = "_blank";
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label26" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCompanyName" runat="server" Width="217px" AutoPostBack="true"
                        CssClass="input_textcss" OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Sales Man Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSalesManName" runat="server" OnTextChanged="txtCompIdS_TextChanged"
                        AutoPostBack="true" CssClass="input_textcss" Width="217px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:GridView ID="GvDueInfo" runat="server" BackColor="White" BorderColor="White"
                        Width="100%" Height="35px" Font-Size="12px" BorderStyle="Ridge" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="GvDueInfo_PageIndexChanging" DataKeyNames="PharmPurPaymentId"
                        PageSize="7">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="7" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                            HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_GvDueInfo"
                                        CommandArgument='<%# Eval("PharmPurPaymentId") %>' Text="[Show]" CommandName="Show"
                                        CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PurId" HeaderText="PurId" />
                            <asp:BoundField DataField="PaymentDate" HeaderText="Last Pay Date" />
                            <asp:BoundField DataField="CompName" HeaderText="Comp Name" />
                            <asp:BoundField DataField="SalesManName" HeaderText="SalesManName" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                            <asp:BoundField DataField="PaidAmount" HeaderText="PaidAmount" />
                            <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnview" runat="server" OnCommand="LinkButton_Command_GvDueInfo_ViewDtl"
                                        CommandArgument='<%# Eval("PharmPurPaymentId") %>' Text="[ViewDetails]" CommandName="ViewDetails"
                                        CausesValidation="false" OnClientClick="NewWindow();" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div class="Salpayment_main">
        <div>
            <asp:Label ID="Label2" runat="server" Text=" Emp Salary Payment" Font-Bold="True"
                Font-Size="10pt" ForeColor="#006699"></asp:Label>
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
                            <asp:TextBox ID="txtPaidAmoun" OnTextChanged="txtPaidAmoun_TextChanged" AutoPostBack="true"
                                CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtSalesManNameS" CssClass="input_textcss" Width="200px" ReadOnly="true"
                                AutoPostBack="true" runat="server"></asp:TextBox>
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
                    <asp:HiddenField ID="HFPurID" runat="server" />
                    <asp:HiddenField ID="HFPaymentID" runat="server" />
                    <asp:Label ID="lblSalPay" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblPurPay" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblCurrBankAmount" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblCashPurchase" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblCashSalPay" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblCashTotal" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblPreviousPayAmount" Visible="false" runat="server"></asp:Label>
                     <asp:Label ID="lblTotalPrice" Visible="false" runat="server"></asp:Label>
                </table>
            </asp:Panel>
        </div>
    </div>
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
                            CssClass="button3" Text="Cancel" OnClick="btnCancelPurchase_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
