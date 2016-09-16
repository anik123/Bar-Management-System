<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CompanyTakaTransectionUI.aspx.cs" Inherits="UI.BranchCollection.CompanyTakaTransectionUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%-- <script type="text/javascript" language="javascript">
        $(function () {
            $("#MainContent_Tabs_Panel1_btnSave").click(function (e) {
                var t2date = $("#MainContent_Tabs_Panel1_txtamount").val();
                if (t2date == "") {
                    $('#MainContent_Tabs_Panel1_txtamount').focus();
                    alert('Plz Insert Amount');
                    return false;
                }



            }
        );


            $("#MainContent_Tabs_Panel2_BtnSaveCash").click(function () {
                var cashdata = $("#MainContent_Tabs_Panel2_txtamountCash").val();
                if (cashdata == "") {
                    $('#MainContent_Tabs_Panel2_txtamountCash').focus();
                    alert('Plz Insert Amount');
                    return false;
                }
            });
        });

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" ActiveTabIndex="1"
                AutoPostBack="true">
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel1" HeaderText="Bank Transection">
                    <ContentTemplate>
                        <div class="middle">
                            <asp:Label ID="Label5" runat="server" Text="Bank Amount Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div class="testinfo">
                            <table style="margin-left: 240px; margin-top: 20px;">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label10" runat="server" CssClass="Font_header" Text=" Current Bank Amount (Total): "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblBankAmountTotal" runat="server" AutoPostBack="true" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="Xtralebel">Bank Account </asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBankName" runat="server" CssClass="input_textcss" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vg2"
                                            ForeColor="Red" ControlToValidate="ddlBankName" InitialValue="0">Account Req</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCurrentPage" Visible="False" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotalCurrentAmount" runat="server" BackColor="#FFDAFF" Font-Size="15px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="Xtralebel">Collection Income Item:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBank_CollectionItem" runat="server" CssClass="input_textcss">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg2"
                                            ForeColor="Red" ControlToValidate="ddlBank_CollectionItem" InitialValue="0">Collection Item Req</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="Xtralebel">Payment(Tk) </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtamount" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        <span class="Mandatory">*</span>
                                        <ajaxtoolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtamount"
                                            FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vg2"
                                            ForeColor="Red" ControlToValidate="txtamount">Amount Req</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" CssClass="Xtralebel">Collection Date:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCollectionDate_Bank" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                            class="Mandatory"> *</span>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                            Format="dd/MM/yyyy" TargetControlID="txtCollectionDate_Bank">
                                        </ajaxtoolkit:CalendarExtender>
                                        <asp:CompareValidator ID="cp" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                            ControlToValidate="txtCollectionDate_Bank" ErrorMessage="Not Valid">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="Xtralebel">Remarks: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="input_textcss"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfBTran" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfaccountid" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" ValidationGroup="vg2" CssClass="subbtn" Text="Save"
                                            OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel2" HeaderText="Cash Transection">
                    <ContentTemplate>
                        <div class="middle">
                            <asp:Label ID="Label7" runat="server" Text="Cash Amount Entry" CssClass="Font_header"></asp:Label>
                        </div>
                        <div>
                            <table style="margin-left: 240px; margin-top: 20px;">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label20" runat="server" CssClass="Font_header" Text=" Current Cash Amount: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCash" runat="server" AutoPostBack="true" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" CssClass="Xtralebel">Collection Income Item:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCollectionItem_Cash" runat="server" CssClass="input_textcss">
                                        </asp:DropDownList>
                                        <span class="Mandatory">*</span>
                                        <asp:RequiredFieldValidator ID="Rf" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                            ControlToValidate="ddlCollectionItem_Cash" InitialValue="0">Collection Item Req</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="Xtralebel">Amount Paid(Tk):</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtamountCash" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                            class="Mandatory"> *</span>
                                        <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="txtamountCash" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RfAmount" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                            ControlToValidate="txtamountCash">Amount Req</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="Xtralebel">Collection Date:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCollectionDate_Cash" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                            class="Mandatory"> *</span>
                                        <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtCollectionDate_Cash">
                                        </ajaxtoolkit:CalendarExtender>
                                        <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                            Operator="DataTypeCheck" ControlToValidate="txtCollectionDate_Cash" ErrorMessage="Not Valid">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="Xtralebel">Remarks: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarksCash" runat="server" CssClass="input_textcss"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnSaveCash" runat="server" ValidationGroup="vg1" CssClass="subbtn"
                                            Text="Save" OnClick="BtnSaveCash_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnCancelCash" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                            OnClick="BtnCancelCash_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
