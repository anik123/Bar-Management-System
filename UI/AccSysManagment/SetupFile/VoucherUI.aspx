<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VoucherUI.aspx.cs" Inherits="UI.AccSysManagment.SetupFile.VoucherUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxtoolkit:tabcontainer runat="server" id="Tabs" width="100%" 
        activetabindex="0">
        <ajaxtoolkit:TabPanel runat="server" ID="Panel1" HeaderText="Main Voucher Entry">
            <ContentTemplate>
                <asp:UpdatePanel ID="tab1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="HeaderPartition">
                            <asp:Label ID="Label5" runat="server" Text="Main Voucher Entry" CssClass="HeaderPartition_Font"></asp:Label>
                        </div>
                        <div class="mainheadpage">
                            <table style="width: 85%; float: left; margin-left: 150px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Main Voucher  NO#: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMainVoucherNo" runat="server" CssClass="SingleTextbox"></asp:TextBox><span
                                            class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg1" ID="Rfmvn" runat="server" ErrorMessage="Main Voucher No Req"
                                            ControlToValidate="txtMainVoucherNo"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="SingleLbl"> Voucher Name: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMainVoucherName" runat="server" CssClass="SingleTextbox"></asp:TextBox><span
                                            class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg1" ID="Rfmvna" runat="server" ErrorMessage="Main Voucher Name Req"
                                            ControlToValidate="txtMainVoucherName"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HFMVID" runat="server" />
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" CausesValidation="true"
                                            ValidationGroup="vg1" Text="Save" OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="False"
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
                                        <asp:Label ID="Label8" runat="server" Text="Main Voucher List" CssClass="HeaderPartition_Font"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVMainVoucher" runat="server" BackColor="#92B8EF" ForeColor="Snow" Font-Size="11px"
                                            BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px"
                                            CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                            Height="15px" AllowPaging="True" Width="100%" PageSize="8" DataKeyNames="MainVoucherId"
                                            OnPageIndexChanging="GVMainVoucher_PageIndexChanging" OnSelectedIndexChanged="GVMainVoucher_SelectedIndexChanged">
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
                                                <asp:BoundField DataField="MainVoucherCode" HeaderText="Main Voucher Code#" />
                                                <asp:BoundField DataField="MainVoucherName" HeaderText="Main Voucher Name" />
                                            </Columns>
                                            <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                                HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel runat="server" ID="Panel2" HeaderText="Sub Voucher Entry">
            <HeaderTemplate>
                Sub Voucher Entry
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="tab2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="HeaderPartition">
                            <asp:Label ID="Label1" runat="server" Text="Sub Voucher Entry" CssClass="HeaderPartition_Font"></asp:Label>
                        </div>
                        <div class="mainheadpage">
                            <table style="width: 80%; float: left; margin-left: 150px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" CssClass="SingleLbl" Text="Main Voucher:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMainVoucher" runat="server" CssClass="SIngelDDl_subcode"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlMainVoucher_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="SingleLbl">Sub Voucher NO#: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubVNO" runat="server" ReadOnly="True" CssClass="SingleTextbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Sub Voucher Name: </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtSubVNAME" runat="server" CssClass="SingleTextbox"></asp:TextBox><span
                                            class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ValidationGroup="vg2" ID="Rfsn" runat="server" ErrorMessage="Sub Voucher Name Req"
                                            ControlToValidate="txtSubVNAME"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HFSVID" runat="server" />
                                    </td>
                                    <td>
                                        <%--     <asp:Button ID="BtnPopUp" runat="server"  Text="pop"  OnClientClick=" ModalPopupsAlert3()" />--%>
                                        <%--<ajaxtoolkit:ModalPopupExtender ID="MPE" runat="server" TargetControlID="BtnPopUp"
                                    PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true"
                                    OkControlID="OkButton" OnOkScript="onOk()" CancelControlID="CancelButton" PopupDragHandleControlID="Panel3">
                                </ajaxtoolkit:ModalPopupExtender>--%>
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
                                        <asp:Button ID="BtnSubVoucheerSave" runat="server" CausesValidation="true" ValidationGroup="vg2"
                                            CssClass="SaveBtn" Text="Save" OnClick="BtnSubVoucheerSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnSubVoucheerClear" runat="server" CssClass="clearBtn" Text="Clear"
                                            CausesValidation="False" OnClick="BtnSubVoucheerClear_Click" />
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
                                        <asp:Label ID="Label7" runat="server" Text="Sub Voucher List" CssClass="HeaderPartition_Font"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GVSubVoucher" runat="server" BackColor="#92B8EF" ForeColor="Snow"
                                            BorderColor="#92B8EF" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" Font-Size="11px"
                                            CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                            Height="15px" AllowPaging="True" Width="100%" PageSize="6" DataKeyNames="SubVoucherId"
                                            OnPageIndexChanging="GVSubVoucher_PageIndexChanging" OnSelectedIndexChanged="GVSubVoucher_SelectedIndexChanged">
                                            <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                            <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                PageButtonCount="6" />
                                            <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                                HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="MainVoucherCode" HeaderText="Main Voucher Code#" />
                                                <asp:BoundField DataField="MainVoucherName" HeaderText="Main Voucher Name" />
                                                <asp:BoundField DataField="SubVoucherCode" HeaderText="Sub Voucher Code#" />
                                                <asp:BoundField DataField="SubVoucherName" HeaderText="Sub Voucher Name" />
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
    </ajaxtoolkit:tabcontainer>
</asp:Content>
