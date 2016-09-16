<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AccConfigerationUI.aspx.cs" Inherits="UI.AccSysManagment.SetupFile.AccConfigerationUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" 
        ActiveTabIndex="0">
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
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
    </ajaxtoolkit:TabContainer>
</asp:Content>
