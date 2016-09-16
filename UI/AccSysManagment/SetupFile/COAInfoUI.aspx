<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="COAInfoUI.aspx.cs" Inherits="UI.AccSysManagment.SetupFile.COAInfoUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Chart Of Accounts Entry" CssClass="Font_header"></asp:Label>
            </div>
            <div class="COA">
                <table style="width: 82%; float: left; margin-left: 190px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label36" runat="server" CssClass="SingleLbl" Text="Main Head:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainHeadCodeId" runat="server" CssClass="SingleDDL_MainHead"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlMainHeadCodeId_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="rc_Sc2" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                ControlToValidate="ddlMainHeadCodeId" InitialValue="0">Select MainHead</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblSearchMainHead" runat="server" CssClass="SearchLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" CssClass="SingleLbl" Text="Sub Code1:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubcode1" runat="server" CssClass="SingleDDL_MainHead" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlSubcode1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="Rfs1" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                ControlToValidate="ddlSubcode1" InitialValue="0">Select SubCoad1 </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblSearchSubCode1" runat="server" CssClass="SearchLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="SingleLbl" Text="Sub Code2:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubcode2" runat="server" CssClass="SingleDDL_MainHead" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlSubcode2_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="Rfs2" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                ControlToValidate="ddlSubcode2" InitialValue="0">Select SubCoad2 </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblSearchSubCode2" runat="server" CssClass="SearchLbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">AccountId: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccountId" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Account Name: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccountName" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="Rfsn" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                ControlToValidate="txtAccountName">Enter COA </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="SingleLbl">Balance: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBalance" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="SingleLbl">Description: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="HFCOAID" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="vg3"
                                CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="False"
                                OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSearch" runat="server" CssClass="clearBtn" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="Label28" runat="server" Text=" Search From Chart Of Account List " CssClass="Font_header"></asp:Label></div>
            <div class="AccHead_search_main">
                <div class="AccHead_search_Left">
                    <table style="width: 100%; float: left;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" CssClass="lbl_AccountHead_search" Text="Chart of Account No:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_COAID" CssClass="txt_Acc_Search" AutoPostBack="True" runat="server"
                                    OnTextChanged="txtSubCode2ID_S_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="lbl_AccountHead_search" Text="Chart of Acccount Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_COAName" OnTextChanged="txtSubCode2ID_S_TextChanged" AutoPostBack="True"
                                    CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code2 ID#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_SucCode2_Id" CssClass="txt_Acc_Search" AutoPostBack="True"
                                    runat="server" OnTextChanged="txtSubCode2ID_S_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label27" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code2 Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_SubCode2Name" OnTextChanged="txtSubCode2ID_S_TextChanged"
                                    AutoPostBack="True" CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="AccHead_search_right">
                    <table style="width: 100%; float: left;">
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code1 ID#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_SubCode1Id" CssClass="txt_Acc_Search" AutoPostBack="True"
                                    runat="server" OnTextChanged="txtSubCode2ID_S_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code1 Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_SubCode1Name" OnTextChanged="txtSubCode2ID_S_TextChanged"
                                    AutoPostBack="True" CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" CssClass="lbl_AccountHead_search" Text="Main Head Id#:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_MainHeadNo" OnTextChanged="txtSubCode2ID_S_TextChanged"
                                    AutoPostBack="True" CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="lbl_AccountHead_search" Text="Main Head Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_S_S2_MainHeadName" OnTextChanged="txtSubCode2ID_S_TextChanged"
                                    AutoPostBack="True" CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
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
                            <asp:Label ID="Label9" runat="server" Text="Chart Of Accounts List" CssClass="Font_header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GVCOA" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                                Font-Size="11px" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" AllowPaging="True"
                                Width="100%" PageSize="8" DataKeyNames="COAId" OnPageIndexChanging="GVCOA_PageIndexChanging"
                                OnSelectedIndexChanged="GVCOA_SelectedIndexChanged">
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
                                    <asp:BoundField DataField="COAACCId" HeaderText="Account Id" />
                                    <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                                    <asp:BoundField DataField="SubCode2_Num" HeaderText="Code2_NO#" />
                                    <asp:BoundField DataField="SubCode_2Name" HeaderText="Code2_Name" />
                                    <asp:BoundField DataField="SubCode_1Num" HeaderText="Code1_NO#" />
                                    <asp:BoundField DataField="SubCode_1Name" HeaderText="Code1_Name" />
                                    <asp:BoundField DataField="MainheadNum" HeaderText="Head_NO#" />
                                    <asp:BoundField DataField="MainHeadName" HeaderText="Head_Name" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
