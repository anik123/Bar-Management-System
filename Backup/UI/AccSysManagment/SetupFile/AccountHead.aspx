<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AccountHead.aspx.cs" Inherits="UI.AccSysManagment.SetupFile.AccountHead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" 
        ActiveTabIndex="1">
        <ajaxtoolkit:TabPanel runat="server" ID="Panel1" HeaderText="Main Head">
            <ContentTemplate>
                <asp:UpdatePanel ID="tab1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label5" runat="server" Text="Main Head Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="mainheadpage">
                            <table style="width: 82%; float: left; margin-left: 150px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Main Hade NO#: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMainHeadNo" runat="server" CssClass="SingleTextbox">
                                        </asp:TextBox><span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RFMH" runat="server" ForeColor="Red"
                                            ErrorMessage="Main Hade No Req" ControlToValidate="txtMainHeadNo"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Main Hade Name: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMainHeadName" runat="server" CssClass="SingleTextbox">
                                        </asp:TextBox><span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RFMN" runat="server" ForeColor="Red"
                                            ErrorMessage="Main Hade Name Req" ControlToValidate="txtMainHeadName"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Description: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="SingleTextbox">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HFMHID" runat="server" />
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="vg1"
                                            CssClass="SaveBtn" Text="Save" OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Main Head List" CssClass="Font_header"></asp:Label>
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVMainHead" runat="server" BackColor="#92B8EF" ForeColor="Snow"
                                            Font-Size="11px" BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge"
                                            BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                            Height="15px" AllowPaging="True" Width="100%" PageSize="5" DataKeyNames="MainHeadId"
                                            OnPageIndexChanging="GVMainHead_PageIndexChanging" OnSelectedIndexChanged="GVMainHead_SelectedIndexChanged">
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
                                                <asp:BoundField DataField="MainHadeNum" HeaderText="Main Hade NO# " />
                                                <asp:BoundField DataField="MainHeadName" HeaderText="Main Head Name" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel runat="server" ID="Panel2" HeaderText="Sub Code 1">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Sub Code1 Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="mainheadpage">
                            <table style="width: 82%; float: left; margin-left: 150px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" CssClass="SingleLbl" Text="Main Head:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMainHeadCodeId" runat="server" CssClass="SingleDDL_MainHead"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlMainHeadCodeId_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Sub Code ID#: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubCode1No" runat="server" ReadOnly="True" CssClass="SingleTextbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="SingleLbl">Sub Code Name: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubCode1Name" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg2" ID="RFSC1" runat="server" ForeColor="Red"
                                            ErrorMessage="Sub Code Name" ControlToValidate="txtSubCode1Name"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="SingleLbl">Description: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubCode1Description" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HFSC1" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 400px;">
                                        <asp:Button ID="btnSaveSubCode1" runat="server" CausesValidation="true" ValidationGroup="vg2"
                                            CssClass="SaveBtn" Text="Save" OnClick="btnSaveSubCode1_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancelSubCode1" runat="server" CssClass="clearBtn" Text="Clear"
                                            CausesValidation="False" OnClick="btnCancelSubCode1_Click" />
                                        <asp:Button ID="btnSearch" runat="server" CssClass="clearBtn" Text="Search" CausesValidation="False"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Label ID="Label29" runat="server" Text=" Search From Sub Code1 List " CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="subcode1_search_main">
                            <div class="subcode1_search_Left">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code1 ID#:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubCode1ID_S" CssClass="txt_Acc_Search" AutoPostBack="True" runat="server"
                                                OnTextChanged="txtSubCode1ID_S_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code1 Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubCode1Name_S" OnTextChanged="txtSubCode1ID_S_TextChanged" AutoPostBack="True"
                                                CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="subcode1_search_right">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" CssClass="lbl_AccountHead_search" Text="Main Head Id#:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainHeadId_S" OnTextChanged="txtSubCode1ID_S_TextChanged" AutoPostBack="True"
                                                CssClass="txt_Acc_Search" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" CssClass="lbl_AccountHead_search" Text="Main Head Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMainHeadName_S" OnTextChanged="txtSubCode1ID_S_TextChanged" AutoPostBack="True"
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
                                        <asp:Label ID="Label9" runat="server" Text="Sub Code1 List" CssClass="Font_header"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVSubCode1" runat="server" BackColor="#92B8EF" ForeColor="Snow"
                                            BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px"
                                            Font-Size="11px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                            Height="15px" AllowPaging="True" Width="100%" PageSize="8" DataKeyNames="SubCode_1Id"
                                            OnPageIndexChanging="GVSubCode1_PageIndexChanging" OnSelectedIndexChanged="GVSubCode1_SelectedIndexChanged">
                                            <FooterStyle BackColor="#92B8EF" ForeColor="Black" Height="12px" />
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
                                                <asp:BoundField DataField="SubCode_1Num" HeaderText="SubCode_1 NO#" />
                                                <asp:BoundField DataField="SubCode_1Name" HeaderText="SubCode_1 Name" />
                                                <asp:BoundField DataField="MainheadNum" HeaderText="Main Head NO#" />
                                                <asp:BoundField DataField="MainHeadName" HeaderText="Main Head Name" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel runat="server" ID="Panel3" HeaderText="Sub Code 2">
            <ContentTemplate>
                <asp:UpdatePanel ID="tab3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="Label11" runat="server" Text="Sub Code2 Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="mainheadpage">
                            <table style="width: 82%; float: left; margin-left: 150px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="SingleLbl" Text="Main Head:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="SC2_ddlMainHead" runat="server" CssClass="SingleDDL_MainHead"
                                            AutoPostBack="True" OnSelectedIndexChanged="SC2_ddlMainHead_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ID="rc_Sc2" runat="server" ValidationGroup="vg3" ForeColor="Red"
                                            ControlToValidate="SC2_ddlMainHead" InitialValue="0">Select Main Head</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" CssClass="SingleLbl" Text="Sub Code1:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="SC2_ddlSubcode1" runat="server" CssClass="SingleDDL_MainHead"
                                            AutoPostBack="True" OnSelectedIndexChanged="SC2_ddlSubcode1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg3" ID="Rfs1_s2" runat="server" ForeColor="Red"
                                            InitialValue="0" ErrorMessage="Select Sub Head" ControlToValidate="SC2_ddlSubcode1"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="SingleLbl">Sub Code2 Id#: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSC2_No2" runat="server" ReadOnly="True" AutoPostBack="True" CssClass="SingleTextbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" CssClass="SingleLbl">Sub Code2 Name: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSC2_Name" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg3" ID="RFSC2" runat="server" ForeColor="Red"
                                            ErrorMessage="Sub Code2 Name" ControlToValidate="txtSC2_Name"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" CssClass="SingleLbl">Description: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSC2_Description" runat="server" CssClass="SingleTextbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFSC2_Id2" runat="server" />
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
                                        <asp:Button ID="btnSC2_Save" runat="server" ValidationGroup="vg3" CssClass="SaveBtn"
                                            CausesValidation="true" Text="Save" OnClick="btnSC2_Save_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSC2_Clear" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnSC2_Clear_Click" />
                                        <asp:Button ID="BtnSearchSubCode2" runat="server" CssClass="clearBtn" Text="Search"
                                            CausesValidation="False" OnClick="BtnSearchSubCode2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <asp:Label ID="Label28" runat="server" Text=" Search From Sub Code2 List " CssClass="Font_header"></asp:Label></div>
                        <div class="AccHead_search_main">
                            <div class="AccHead_search_Left">
                                <table style="width: 100%; float: left;">
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
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" CssClass="lbl_AccountHead_search" Text="Sub Code1 ID#:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_S_S2_SubCode1Id" CssClass="txt_Acc_Search" AutoPostBack="True"
                                                runat="server" OnTextChanged="txtSubCode2ID_S_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="AccHead_search_right">
                                <table style="width: 100%; float: left;">
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
                                        <asp:Label ID="Label16" runat="server" Text="Sub Code2 List" CssClass="Font_header"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="SC2_Gv" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                                            CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                            Font-Size="11px" GridLines="None" AutoGenerateColumns="False" Height="15px" AllowPaging="True"
                                            Width="100%" PageSize="8" DataKeyNames="SubCode_2Id" OnPageIndexChanging="SC2_Gv_PageIndexChanging"
                                            OnSelectedIndexChanged="SC2_Gv_SelectedIndexChanged">
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
                                                    <ItemStyle Width="35px" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="SubCode2_Num" HeaderText="Code_2 NO#">
                                                    <ItemStyle Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubCode_2Name" HeaderText="Code_2 Name">
                                                    <ItemStyle Width="219px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubCode_1Num" HeaderText="Code_1 NO#">
                                                    <ItemStyle Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubCode_1Name" HeaderText="Code_1 Name">
                                                    <ItemStyle Width="135px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MainheadNum" HeaderText="Head NO#">
                                                    <ItemStyle Width="65px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MainHeadName" HeaderText="Head Name">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Description" HeaderText="Description">
                                                    <ItemStyle Width="85px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
    </ajaxtoolkit:TabContainer>
</asp:Content>
