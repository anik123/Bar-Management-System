<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Transaction.aspx.cs" Inherits="UI.AccSysManagment.Report_Setup_File.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tab" ActiveTabIndex="1" Width="100%">
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Department Setup">
                    <ContentTemplate>
                        <table style="margin-left: 240px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" CssClass="translbl2" Text="Transaction Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tranName" runat="server" CssClass="trandopdownlist"></asp:TextBox>
                                    <span>
                                        <asp:Label ID="RStar" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </span>
                                    <asp:RequiredFieldValidator ID="NameRequiredField" runat="server" ControlToValidate="tranName"
                                        ErrorMessage="Please Enter Name" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="HiddenTransId" runat="server" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div class="clear">
                        </div>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Button ID="SaveBtn" runat="server" CssClass="SaveBtn" Text="Save" ValidationGroup="save"
                                        OnClick="SaveBtn_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="BtnCancle" runat="server" CssClass="clearBtn" Text="Cancle" CausesValidation="False"
                                        OnClick="BtnCancle_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="PnlTransection" runat="server">
                            <asp:Label ID="Label8" runat="server" Text="Transaction ItemList" CssClass="Font_header"></asp:Label>
                            <asp:GridView ID="TranList" runat="server" BackColor="#92B8EF" ForeColor="Snow" Font-Size="11px"
                                BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px"
                                CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                Height="15px" AllowPaging="True" Width="100%" DataKeyNames="TranId" OnPageIndexChanging="TranList_PageIndexChanging"
                                OnSelectedIndexChanged="TranList_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="TranName" HeaderText="Transaction Name " />
                                    <asp:BoundField DataField="CreateBy" HeaderText="Create By" />
                                    <asp:BoundField DataField="CreateDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Create Date" />
                                    <asp:BoundField DataField="UpdateBy" HeaderText="Update By" />
                                    <asp:BoundField DataField="UpdateDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Update Date" />
                                </Columns>
                                <FooterStyle BackColor="#92B8EF" ForeColor="Black" Height="10px" />
                                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next" />
                                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Transaction Details">
                    <ContentTemplate>
                        <div class="journal_main">
                            <table style="margin-left: 240px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="translbl2" Text="Select Transaction:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="tranlistdropp" runat="server" CssClass="trandopdownlist" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tranlistdropp"
                                            ErrorMessage="Select Transaction" ForeColor="Red" InitialValue="0" ValidationGroup="vg3">Select Transaction</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <div class="journal_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label37" runat="server" Text="Debit(DR)" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" CssClass="translbl2" Text="Main Head:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainHeadCodeId_DR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlMainHeadCodeId_DR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="rc_Sc2" runat="server" ControlToValidate="ddlMainHeadCodeId_DR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select MainHead</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" CssClass="translbl2" Text="Sub Code1:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubcode1_DR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlSubcode1_DR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="Rfs1" runat="server" ControlToValidate="ddlSubcode1_DR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select SubCoad1 </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" CssClass="translbl2" Text="Sub Code2:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubcode2_DR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlSubcode2_DR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="Rfs2" runat="server" ControlToValidate="ddlSubcode2_DR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select SubCoad2 </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" CssClass="translbl2" Text="Chart Of Account:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCOA_DR" runat="server" AutoPostBack="True" CssClass="trandopdownlist">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="rcoadr" runat="server" ControlToValidate="ddlCOA_DR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select COA </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label38" runat="server" Text="Voucher(DR)" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" CssClass="translbl2" Text="Main Voucher:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainVoucher_DR" runat="server" CssClass="trandopdownlist"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlMainVoucher_DR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="vg3"
                                                CssClass="RequiredFieldCSS" ControlToValidate="ddlMainVoucher_DR" InitialValue="0">MainVoucher </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" CssClass="translbl2" Text="Sub Voucher:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubVoucher_DR" runat="server" CssClass="trandopdownlist"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="vg3"
                                                CssClass="RequiredFieldCSS" ControlToValidate="ddlSubVoucher_DR" InitialValue="0">SubVoucher </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="journal_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label2" runat="server" Text="Credit(CR)" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="translbl2" Text="Main Head:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMainHeadCodeId_CR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlMainHeadCodeId_CR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMainHeadCodeId_CR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select MainHead</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" CssClass="translbl2" Text="Sub Code1:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubcode1_CR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlSubcode1_CR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSubcode1_CR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select SubCoad1 </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="translbl2" Text="Sub Code2:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubcode2_CR" runat="server" AutoPostBack="True" CssClass="trandopdownlist"
                                                OnSelectedIndexChanged="ddlSubcode2_CR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSubcode2_CR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select SubCoad2 </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="translbl2" Text="Chart Of Account:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCOA_CR" runat="server" AutoPostBack="True" CssClass="trandopdownlist">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCOA_CR"
                                                CssClass="RequiredFieldCSS" InitialValue="0" ValidationGroup="vg3">Select COA </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label16" runat="server" Text="Voucher(CR)" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="translbl2" Text="Voucher:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMaintVoucher_CR" runat="server" CssClass="trandopdownlist"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlMaintVoucher_CR_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="Rfvmv" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                                ControlToValidate="ddlMaintVoucher_CR" InitialValue="0">MainVoucher </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" CssClass="translbl2" Text="Sub Voucher:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubVoucher_CR" runat="server" CssClass="trandopdownlist"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RfVSV" runat="server" ValidationGroup="vg3" CssClass="RequiredFieldCSS"
                                                ControlToValidate="ddlSubVoucher_CR" InitialValue="0">SubVoucher </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <table style="width: 100%; margin-top: 15px;">
                            <tr>
                                <td>
                                    <asp:Button ID="AddBtn" runat="server" CssClass="AddBtn" ValidationGroup="vg3" Text="Save"
                                        OnClick="AddBtn_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="clearbtn_Short" CausesValidation="False"
                                        OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="PnlgvTransectDtl" runat="server">
                            <asp:Label ID="Label9" runat="server" Text="Transaction Details List" CssClass="Font_header"></asp:Label>
                            <asp:GridView ID="TransDetailsGrid" runat="server" BackColor="#92B8EF" ForeColor="Snow"
                                Font-Size="11px" BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge"
                                BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                Height="15px" AllowPaging="True" Width="100%" PageSize="5" DataKeyNames="AccTransDtlId"
                                OnSelectedIndexChanged="TransDetailsGrid_SelectedIndexChanged" OnPageIndexChanging="TransDetailsGrid_PageIndexChanging">
                                <FooterStyle BackColor="#92B8EF" ForeColor="Black" Height="15px" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                    PageButtonCount="5" />
                                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                <Columns>
                                    <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="TransName" HeaderText="Transaction Name " />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:HiddenField ID="HFCOAID" runat="server" />
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
