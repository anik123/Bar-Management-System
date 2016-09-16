<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CashFlowEntityUI.aspx.cs" Inherits="UI.AccSysManagment.Report_Setup_File.CashFlowEntityUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" ActiveTabIndex="1">
        <ajaxtoolkit:TabPanel runat="server" ID="Panel1" HeaderText="Cash Flow Entity">
            <ContentTemplate>
                <div class="HeaderPartition">
                    <asp:Label ID="Label5" runat="server" Text="Cash Flow Entity Entry" CssClass="HeaderPartition_Font"></asp:Label>
                </div>
                <div class="CashFlowEntity">
                    <table style="width: 83%; float: left; margin-left: 150px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Cash Flow Entity: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCashFlowEntity" runat="server" CssClass="SingleTextbox"></asp:TextBox><span
                                    class="Mandatory">*</span>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="Rfmvn" runat="server" CssClass="RequiredFieldCSS"
                                    ErrorMessage="Cash Flow Name Req" ControlToValidate="txtCashFlowEntity"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="SingleLbl">Priority: </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPriority" runat="server" Width="186px" CssClass="SingleTextbox"></asp:TextBox><span
                                    class="Mandatory">*</span>
                                <asp:Label ID="Label3" Width="100px" runat="server"> Integer Only </asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="vg1" CssClass="RequiredFieldCSS" ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="Priority Req" ControlToValidate="txtPriority"></asp:RequiredFieldValidator>
                                <ajaxtoolkit:FilteredTextBoxExtender ID="ftam" runat="server" TargetControlID="txtPriority"
                                    FilterType="Custom, Numbers" ValidChars="." />
                            </td>
                        </tr>
                        <asp:HiddenField ID="HFCFID" runat="server" />
                    </table>
                </div>
                <div class="clear">
                </div>
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSaveCashFlow" runat="server" CssClass="SaveBtn" ValidationGroup="vg1"
                                    Text="Save" OnClick="btnSaveCashFlow_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelCashFlow" runat="server" CssClass="clearBtn" Text="Clear"
                                    CausesValidation="False" OnClick="btnCancelCashFlow_Click" />
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
                                <asp:Label ID="Label8" runat="server" Text="Cash Flow Entity List" CssClass="HeaderPartition_Font"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GvCFE" runat="server" BackColor="#92B8EF" ForeColor="Snow" Font-Size="11px"
                                    BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px"
                                    CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                    Height="15px" AllowPaging="True" Width="100%" PageSize="8" DataKeyNames="CFEId"
                                    OnPageIndexChanging="GvCFE_PageIndexChanging" OnSelectedIndexChanged="GvCFE_SelectedIndexChanged">
                                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                        PageButtonCount="8" />
                                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="CFEName" HeaderText="Cash Flow Entity Name" />
                                        <asp:BoundField DataField="Priority" HeaderText="Priority" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Cash Flow Report Setup">
            <ContentTemplate>
                <div>
                    <asp:Label ID="Label12" runat="server" Text=" Cash Flow Report Setup  " CssClass="Font_header"></asp:Label>
                </div>
                <div class="CashFlowRpt_main">
                    <div class="CashFlowRpt_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Ll24" runat="server" Text="Cash Flow Entity:" CssClass="SingleLbl_journal"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCashFlowEntity" runat="server" CssClass="SingleDDL_Journal">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="rfvcf" runat="server" CssClass="RequiredFieldCSS"
                                        ValidationGroup="vg3" ControlToValidate="ddlCashFlowEntity" InitialValue="0">Select Cash Flow</asp:RequiredFieldValidator>
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
                                        ControlToValidate="ddlSubcode1_DR" InitialValue="0">Select SubCoad1</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="CashFlowRpt_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="SingleLbl_journal" Text="Sub Code2:"></asp:Label>
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
                                    <asp:Label ID="Label7" runat="server" CssClass="SingleLbl_journal" Text="Chart of Account:"></asp:Label>
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
                                    <asp:Label ID="Label4" runat="server" CssClass="SingleLbl_journal" Text="Activation Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RBTActivationStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">Active</asp:ListItem>
                                        <asp:ListItem>Deactive</asp:ListItem>
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
                            <td style="width: 400px;">
                                <asp:Button ID="BtnSaveCashFlowRpt" runat="server" Text="Save" CausesValidation="true"
                                    ValidationGroup="vg3" CssClass="SaveBtn" OnClick="BtnSaveCashFlowRpt_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnCancelCashFlowRpt" runat="server" Text="Cancel" CausesValidation="false"
                                    CssClass="clearBtn" OnClick="BtnCancelCashFlowRpt_Click" />
                                <asp:Button ID="btnSearch" runat="server" CausesValidation="false" CssClass="clearBtn"
                                    Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:Label ID="Label28" runat="server" Text=" Search From Cash Flow Report List "
                        CssClass="Font_header"></asp:Label>
                </div>
                <div class="CashFlowRpt_search_main">
                    <div class="CashFlowRpt_search_Left">
                        <table style="width: 100%; float: left;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="SingleLbl_journal" Text="Cash Flow Entity:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCashFlowEntitySearch" CssClass="txt_Acc_Search" AutoPostBack="True"
                                        runat="server" OnTextChanged="txtCashFlow_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="RequiredFieldCSS"
                                        ControlToValidate="ddlSubcode1_DR" InitialValue="0">*Select SubCoad1</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="SingleLbl_journal" Text="Chart of Acccount:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCOAName" OnTextChanged="txtCashFlow_TextChanged" AutoPostBack="True"
                                        CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="CashFlowRpt_search_right">
                        <table style="width: 100%; float: left;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" CssClass="SingleLbl_journal" Text="Sub Code1 Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSubCode1Name" OnTextChanged="txtCashFlow_TextChanged" AutoPostBack="True"
                                        CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="RequiredFieldCSS"
                                        ControlToValidate="ddlSubcode2_DR" InitialValue="0">Select SubCoad2 </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label25" runat="server" CssClass="SingleLbl_journal" Text="Main Head Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMainHeadName" OnTextChanged="txtCashFlow_TextChanged" AutoPostBack="True"
                                        CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
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
                                <asp:Label ID="Label11" runat="server" Text="Cash Flow Report Setup List" CssClass="Font_header"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GVCFR" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                                    Font-Size="11px" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" AllowPaging="True"
                                    Width="100%" PageSize="8" DataKeyNames="CFRId" OnPageIndexChanging="GVCFR_PageIndexChanging"
                                    OnSelectedIndexChanged="GVCFR_SelectedIndexChanged">
                                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                        PageButtonCount="8" />
                                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="CFEName" HeaderText="Cash Flow Entity" />
                                        <asp:BoundField DataField="Priority" HeaderText="Priority" />
                                        <asp:BoundField DataField="MainHeadName_Num" HeaderText="Main Head" />
                                        <asp:BoundField DataField="SubCode1Name_Num" HeaderText="Sub Code1" />
                                        <asp:BoundField DataField="SubCode2Name_Num" HeaderText="Sub Code2" />
                                        <%--    <asp:BoundField DataField="SubCode_1Num" HeaderText="Code1_NO#" />--%>
                                        <asp:BoundField DataField="COAName_Num" HeaderText=" Account Name" />
                                        <%--  <asp:BoundField DataField="ActiveStatus" HeaderText="Activation Status" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
    </ajaxtoolkit:TabContainer>
    <div>
        <asp:HiddenField ID="HFCFRId" runat="server" />
    </div>
</asp:Content>
