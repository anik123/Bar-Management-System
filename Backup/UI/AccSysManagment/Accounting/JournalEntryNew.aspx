<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="JournalEntryNew.aspx.cs" Inherits="UI.AccSysManagment.Accounting.JournalEntryNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <table style="width: 100%;">
                </table>
            </div>
            <div class="journal_main">
                <div>
                    <asp:Label ID="Label11" runat="server" CssClass="Font_header" Text="Insert Entity Of Journal"></asp:Label>
                </div>
                <div class="journal_left">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Ll24" runat="server" Text="Select From Here" CssClass="SingleLbl_journal"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RbtJournalType" runat="server" Width="120px" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">DR</asp:ListItem>
                                    <asp:ListItem>CR</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label36" runat="server" CssClass="SingleLbl_journal" Text="Main Head:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMainHeadCodeId_DR" runat="server" CssClass="SingleDDL_Journal"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlMainHeadCodeId_DR_SelectedIndexChanged">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rc_Sc2" runat="server" CssClass="RequiredFieldCSS"
                                    ValidationGroup="vg3" ControlToValidate="ddlMainHeadCodeId_DR" InitialValue="0">Select MainHead</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" CssClass="SingleLbl_journal" Text="Sub Code1:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubcode1_DR" runat="server" CssClass="SingleDDL_Journal"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSubcode1_DR_SelectedIndexChanged">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="Rfs1" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="ddlSubcode1_DR" InitialValue="0">Select SubCoad1 </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="SingleLbl_journal" Text="Sub Code2:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubcode2_DR" runat="server" CssClass="SingleDDL_Journal"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSubcode2_DR_SelectedIndexChanged">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="Rfs2" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="ddlSubcode2_DR" InitialValue="0">Select SubCoad2 </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="SingleLbl_journal" Text="Chart Of Account:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCOA_DR" runat="server" CssClass="SingleDDL_Journal" AutoPostBack="True">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rcoadr" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="ddlCOA_DR" InitialValue="0">Select COA </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="SingleLbl_journal" Text="Amount:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDRAmount" CssClass="textbox_Journal" runat="server"></asp:TextBox>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="rfAm" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="txtDRAmount">Insert DRAmount</asp:RequiredFieldValidator>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="ftam" runat="server" TargetControlID="txtDRAmount"
                                    FilterType="Custom, Numbers" ValidChars="." />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="journal_right">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" CssClass="SingleLbl_journal" Text="Voucher:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMaintVoucher" runat="server" CssClass="SingleDDL_Journal"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlMaintVoucher_SelectedIndexChanged">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="Rfvmv" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="ddlMaintVoucher" InitialValue="0">MainVoucher </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="SingleLbl_journal" Text="Sub Voucher:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubVoucher" runat="server" CssClass="SingleDDL_Journal"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <span class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ID="RfVSV" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                    ControlToValidate="ddlSubVoucher" InitialValue="0">SubVoucher </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="SingleLbl_journal" Text="Voucher NO#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVoucherNo" CssClass="textbox_Journal" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" CssClass="SingleLbl_journal" Text="MR NO#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMRNO" CssClass="textbox_Journal" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" CssClass="SingleLbl_journal" Text="Transection Date:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransectionDate" CssClass="textbox_Journal" runat="server"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                    Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtTransectionDate">
                                </ajaxtoolkit:CalendarExtender>
                                <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                    Operator="DataTypeCheck" ControlToValidate="txtTransectionDate" ErrorMessage="Not Valid">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" CssClass="SingleLbl_journal" Text="Remarks:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarksDR" CssClass="textbox_Journal" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="HFTransectionNo" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HFJournalID" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <table style="width: 100%; margin-top: 15px;">
            <tr>
                <td>
                    <asp:Button ID="btnAddDR" runat="server" CssClass="AddBtn" CausesValidation="true"
                        ValidationGroup="vg3" Text="Add" OnClick="btnAddDR_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnClearDR" runat="server" Text="Clear" CssClass="clearbtn_Short"
                        OnClick="BtnClearDR_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="lblCheckDRC_R" Visible="false" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GvJrEntry" runat="server" BackColor="White" BorderColor="White"
            Font-Size="11px" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
            GridLines="None" AutoGenerateColumns="False" Height="16px" AllowPaging="True"
            OnPageIndexChanging="GvJrEntry_PageIndexChanging" Width="100%">
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#9471DE" ForeColor="White" />
            <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton" runat="server" OnClick="LinkButton_Click" CausesValidation="false"
                            OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');">Remove</asp:LinkButton></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="JournalType" HeaderText="Journal Type" />
                <asp:BoundField DataField="COAName_Num" HeaderText="Chart of Accounts" />
                <asp:BoundField DataField="SubCode2Name_Num" HeaderText="Account Head Name" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                <asp:BoundField DataField="VONO" HeaderText="VONO#" />
                <asp:BoundField DataField="MRNO" HeaderText="MRNO#" />
                <asp:BoundField DataField="SubVoucherCodeName" HeaderText="Voucher" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Panel ID="PnlAction" Visible="false" runat="server">
        <table style="width: 100%; margin-top: 15px;">
            <tr>
                <td>
                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="SaveBtn" OnClick="BtnSave_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="clearBtn" OnClick="BtnCancel_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div>
        <asp:Label ID="Label19" runat="server" CssClass="Font_header" Text="List Of Journal Entry"></asp:Label>
    </div>
    <%--<div>
        <asp:GridView ID="GvJrShow" runat="server" BackColor="White" BorderColor="White"
            Font-Size="11px" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
            GridLines="None" AutoGenerateColumns="False" Height="16px" AllowPaging="True"
            Width="100%">
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#9471DE" ForeColor="White" />
            <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
            <Columns>
                <asp:BoundField DataField="COAName_Num" HeaderText="Chart of Accounts" />
                <asp:BoundField DataField="SubCode2Name_Num" HeaderText="Chart of Accounts" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                <asp:BoundField DataField="VONO" HeaderText="VONO#" />
                <asp:BoundField DataField="MRNO" HeaderText="MRNO#" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                <asp:BoundField DataField="TransectionNo" HeaderText="Transection No#" />
                <asp:BoundField DataField="JournalId" HeaderText="Journal Id" />
            </Columns>
        </asp:GridView>
    </div>--%>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Repeater ID="RptJournalShow" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="1px">
                                <tr style="background-color: #8FADD9; text-align: center; font-size: 11px;">
                                    <td>
                                        Journal Id
                                    </td>
                                    <td>
                                        No#
                                    </td>
                                    <td>
                                        Chart of Accounts
                                    </td>
                                    <td>
                                        Accounts
                                    </td>
                                    <td>
                                        DR.Amount
                                    </td>
                                    <td>
                                        CR.Amount
                                    </td>
                                    <td>
                                        VONO#
                                    </td>
                                    <td>
                                        MRNO#
                                    </td>
                                    <td>
                                        Voucher
                                    </td>
                                    <td>
                                        Remarks
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #EEF5FF; text-align: center; font-size: 11px;">
                                <td>
                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("JournalId") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TransectionNo") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("COAName_Num") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("SubCode2Name_Num") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("DRAmount") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("CRAmount") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("VONO") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("MRNO") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("SubVoucherCodeName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Remarks") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-color: #8FADD9">
                                <td colspan="10" align="center">
                                    <asp:Label ID="Label1" runat="server" Text="Journal Info..." ForeColor="White"></asp:Label>
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
