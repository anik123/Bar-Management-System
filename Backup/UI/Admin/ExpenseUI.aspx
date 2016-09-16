<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExpenseUI.aspx.cs" Inherits="UI.Admin.ExpenseUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script language='javascript'>
        document.getElementById('MainContent_ddlExHeadName').focus();
    </script>--%>
    <%-- ScriptManager.RegisterStartupScript(this, this.GetType(), "foc", "document.getElementById('"
    + ddlExHeadName.ClientID + "').focus();", true);--%>
    <%--  <script language='javascript'>
        Page.ClientScript.RegisterStartupScript(this.GetType(), "foc", "document.getElementById('MainContent_ddlExHeadName').focus();", true);
    </script>--%>
    <%--<script language='javascript'>
        document.getElementById('MainContent_ddlExHeadName').focus();
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
        <asp:Label ID="Label5" runat="server" Text="Expense Entry" CssClass="Font_header"></asp:Label>
    </div>
    <div class="mainheadpage">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">ExpenseHeadName<span class="Mandatory">*</span></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlExHeadName" CssClass="SingleDropDownList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEname" runat="server" ControlToValidate="ddlExHeadName"
                        Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Expense Head Req."></asp:RequiredFieldValidator>
                    <ajaxtoolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="rfvEname" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="SingleLbl">Date<span class="Mandatory">*</span></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="11" CssClass="SingleDropDownList"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator runat="server" ID="rfvAccountNumber" ControlToValidate="txtDate"
                        Display="None" ErrorMessage="<b>Required Field Missing</b><br />Date is required." />
                    <ajaxtoolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        TargetControlID="rfvAccountNumber" HighlightCssClass="validatorCalloutHighlight" />--%>
                    <ajaxtoolkit:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server"
                        Enabled="True" TargetControlID="txtDate" />
                    <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                        Operator="DataTypeCheck" ControlToValidate="txtDate" ErrorMessage="Not Valid">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Amount<span class="Mandatory">*</span> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="SingleTextbox">
                    </asp:TextBox>
                    <ajaxtoolkit:FilteredTextBoxExtender ID="Filteredtextboxextender2" runat="server"
                        TargetControlID="txtAmount" FilterType="Custom, Numbers" ValidChars="." />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Remarks</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="SingleTextbox">
                    </asp:TextBox>
                </td>
            </tr>
            <asp:HiddenField ID="HFExId" runat="server" />
        </table>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Cancel" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Repeater ID="RptMainHead" runat="server">
                        <HeaderTemplate>
                            <table id="table1" width="100%" border="1px">
                                <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                    <td>
                                        Options
                                    </td>
                                    <td>
                                        Expense Head Name
                                    </td>
                                    <td>
                                        Date
                                    </td>
                                    <td>
                                        Amount
                                    </td>
                                    <td>
                                        Remarks
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("ExpanseId") %>'
                                        Text="[Show]" CommandName="Show" CausesValidation="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("HeadName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Date","{0:dd/MM/yyyy}") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Amount") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Remarks") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-color: #8FADD9">
                                <td colspan="6" align="center">
                                    <asp:Label ID="Label1" runat="server" Text=" Expense Info..." ForeColor="White"></asp:Label>
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
</asp:Content>
