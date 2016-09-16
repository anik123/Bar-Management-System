<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PageObjectCreation.aspx.cs" Inherits="UI.PageObject.PageObjectCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <asp:Label ID="Ll2224" runat="server" Text="Page Object Creation" CssClass="Font_header"></asp:Label>
            </div>
            <div class="PageObject">
                <table style="margin-left: 140px; width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Ll24" runat="server" CssClass="SingleLbl" Text="Page Type:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPageType" runat="server" CssClass="SingleTextbox"> </asp:TextBox><span
                                class="Mandatory"> *</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                CssClass="RequiredField_CSS" ErrorMessage="Page Type Req" ControlToValidate="txtPageType"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Page Name:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPageName" runat="server" CssClass="SingleTextbox"> </asp:TextBox><span
                                class="Mandatory"> *</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="rf" runat="server" CssClass="RequiredField_CSS"
                                ErrorMessage="Page Name Req" ControlToValidate="txtPageName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Page Path:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPagePath" runat="server" CssClass="SingleTextbox"> </asp:TextBox><span
                                class="Mandatory"> *</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="Rferec" runat="server" CssClass="RequiredField_CSS"
                                ErrorMessage="Page Path Req" ControlToValidate="txtPagePath"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="SingleLbl">Page Methode:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPageMathode" runat="server" CssClass="SingleTextbox"> </asp:TextBox><span
                                class="Mandatory"> *</span>
                            <%-- <asp:RequiredFieldValidator ValidationGroup="vg1" ID="rfv2" runat="server" CssClass="RequiredField_CSS"
                                ErrorMessage="Page Methode Req" ControlToValidate="txtPageMathode"></asp:RequiredFieldValidator>
                            --%>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFObjId" runat="server" />
                </table>
            </div>
            <div class="ActionButton_div">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnWSSave" runat="server" CssClass="subbtn" ValidationGroup="vg1"
                                CausesValidation="true" Text="Save" OnClick="btnWSSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnWSCancel" runat="server" CssClass="clearbtn" Text="Cancel" CausesValidation="False"
                                OnClick="btnWSCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="PnlGridView" class="GridView" runat="server">
                <table class="tblwithbdr">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Page Object Record List" CssClass="Font_header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvPageObject" runat="server" Width="100%" Height="35px" Font-Size="11px"
                                BorderStyle="None" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                AllowPaging="True" DataKeyNames="PageObjectId" OnPageIndexChanging="GvPageObject_PageIndexChanging"
                                PageSize="6" OnSelectedIndexChanged="GvPageObject_SelectedIndexChanged">
                                <FooterStyle CssClass="tblfooter" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                    PageButtonCount="6" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                    VerticalAlign="Middle" />
                                <HeaderStyle CssClass="tblheader" />
                                <Columns>
                                    <asp:CommandField HeaderText="Select" ShowHeader="True" ItemStyle-CssClass="tblrowbgodd"
                                        ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:CommandField>
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgodd" DataField="PageTypeName" HeaderText="Page Type" />
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgevn" DataField="PageName" HeaderText="Page Name" />
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgodd" DataField="PagePath" HeaderText="Page Path" />
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgevn" DataField="PageMethodeName" HeaderText="Page Methode Name" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
