<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LiabilitiesRptSetupUI.aspx.cs" Inherits="UI.AccSysManagment.Report_Setup_File.LiabilitiesRptSetupUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="mainheadpage">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Liabilities Report Setup" CssClass="Font_header"></asp:Label>
                </div>
                <table style="width: 85%; float: left; margin-left: 150px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="SingleLbl" Text="Main Head:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMainHeadCodeId_DR" runat="server" CssClass="SingleDDL_Journal"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="RequiredFieldCSS"
                                ValidationGroup="vg3" ControlToValidate="ddlMainHeadCodeId_DR" InitialValue="0">Select MainHead</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="SingleLbl" Text="Priority:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPriority" Width="202px" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vg3"
                                CssClass="RequiredFieldCSS" ControlToValidate="txtPriority">Priority Req </asp:RequiredFieldValidator>
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
                            <asp:Button ID="BtnSaveBalaceRpt" runat="server" Text="Save" CausesValidation="true"
                                ValidationGroup="vg3" CssClass="SaveBtn" OnClick="BtnSaveBalaceRpt_Click" />
                        </td>
                        <td>
                            <asp:Button ID="BtnCanelBalaceRpt" runat="server" Text="Cancel" CausesValidation="false"
                                CssClass="clearBtn" OnClick="BtnCanelBalaceRpt_Click" />
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
                            <asp:Label ID="Label11" runat="server" Text="Liabilities Report Setup List" CssClass="Font_header"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GVCFR" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                                Font-Size="11px" CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" AllowPaging="True"
                                Width="100%" PageSize="8" DataKeyNames="LiabRptId" OnPageIndexChanging="GVCFR_PageIndexChanging"
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
                                    <asp:CommandField HeaderText="Edit" ShowHeader="True" ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="MainHeadName_Num" HeaderText="Main Head" />
                                    <%--   <asp:BoundField DataField="SubCode1Name_Num" HeaderText="Sub Code1" />--%>
                                    <%-- <asp:BoundField DataField="SubCode2Name_Num" HeaderText="Sub Code2" />
                                    <asp:BoundField DataField="COAName_Num" HeaderText=" Account Name" />--%>
                                    <asp:BoundField DataField="Priority" HeaderText="Priority" />
                                    <%--   <asp:BoundField DataField="ActiveStatus" HeaderText="Activation Status" />--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="HFBId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
