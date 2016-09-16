<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeType.aspx.cs" Inherits="UI.AccSysManagment.Employee.EmployeeType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tab" ActiveTabIndex="1" Width="100%">
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Department Setup">
                    <contenttemplate>
                      
                                <div class="Header_Page">
                                    <asp:Label ID="Label5" runat="server" Text=" Department Entry" CssClass="Font_header"></asp:Label></div>
                                <div class="Emptype">
                                    <table style="margin-left: 240px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" CssClass="Xtralebel">Department Name: </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdeptName" runat="server" CssClass="input_textcss">
                                                </asp:TextBox><span class="Mandatory">*</span>
                                                <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                                    ForeColor="Red" ErrorMessage="Department Req" ControlToValidate="txtdeptName"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="hDepttId" runat="server" />
                                    </table>
                                </div>
                                <div class="ActionButton_div">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" CssClass="subbtn" ValidationGroup="vg1" CausesValidation="true"
                                                    Text="Save" OnClick="btnSave_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="false"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div>
                                    <asp:Label ID="Label3" runat="server" Text="Department List" CssClass="Font_header"></asp:Label><asp:GridView
                                        ID="GridRole" runat="server" BackColor="White" BorderColor="White" Width="100%"
                                        Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridRole_PageIndexChanging"
                                        DataKeyNames="EmpTypeId" PageSize="10">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                            PageButtonCount="10" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <Columns>
                                            <asp:BoundField DataField="TypeName" HeaderText="Department Name" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_GridRole"
                                                        SelectedRowStyle="True" CommandArgument='<%# Eval("EmpTypeId") %>' Text="[Show]"
                                                        CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                      
                    </contenttemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="Server" ID="Panel2" HeaderText="Designation Info">
                    <contenttemplate>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <div>
                                    <asp:Label ID="Label4" runat="server" Text="Designation Name Entry" CssClass="Font_header"></asp:Label></div>
                                <div class="testinfo">
                                    <table style="margin-left: 240px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" CssClass="EmpDesigantionLebel" Text="Department Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddldeptName" runat="server" Width="252px" CssClass="input_textcss">
                                                </asp:DropDownList>
                                                <span class="Mandatory">*</span>
                                                <asp:RequiredFieldValidator ID="rc" runat="server" ValidationGroup="vg2" ForeColor="Red"
                                                    ControlToValidate="ddldeptName" InitialValue="0">Role Req</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" CssClass="EmpDesigantionLebel"> Designation: </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdisignation" runat="server" Width="250px" CssClass="input_textcss"> </asp:TextBox><span
                                                    class="Mandatory">*</span>
                                                <asp:RequiredFieldValidator ValidationGroup="vg2" ID="RfD" runat="server" ForeColor="Red"
                                                    ErrorMessage="Designation Req" ControlToValidate="txtdisignation"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="HFDesigantion" runat="server" />
                                    </table>
                                </div>
                                <div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnSaveDesigantion" runat="server" OnClick="BtnSaveDesigantion_Click"
                                                    CssClass="subbtn" Text="Save" CausesValidation="true" ValidationGroup="vg2" />
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnCanelDesigantion" runat="server" CssClass="clearbtn" Text="Clear"
                                                    CausesValidation="false" OnClick="BtnCanelDesigantion_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div>
                                    <asp:Label ID="Label8" runat="server" Text="Designation Name List" CssClass="Font_header"></asp:Label></div>
                                <div>
                                    <asp:GridView ID="GvEmpBasic" runat="server" BackColor="White" BorderColor="White"
                                        Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                        OnPageIndexChanging="GvEmpBasic_PageIndexChanging" DataKeyNames="EmpSpecilistId"
                                        PageSize="8">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                            PageButtonCount="8" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <Columns>
                                            <asp:BoundField DataField="Specialist" HeaderText="Designation" />
                                            <asp:BoundField DataField="TypeName" HeaderText="Department " />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_Basic"
                                                        SelectedRowStyle="True" CommandArgument='<%# Eval("EmpSpecilistId") %>' Text="[Show]"
                                                        CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </contenttemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="Server" ID="TabPanel1" HeaderText="Role Info">
                    <contenttemplate>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Employee Role Entry" CssClass="Font_header"></asp:Label><div
                                    class="EmpRoleSetup">
                                    <table style="margin-left: 250px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" CssClass="Xtralebel">Role Name: </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRolename" runat="server" Width="230px" CssClass="input_textcss">
                                                </asp:TextBox><span class="Mandatory">*</span>
                                                <asp:RequiredFieldValidator ValidationGroup="vg4" ID="RequiredFieldValidator2" runat="server"
                                                    ForeColor="Red" ErrorMessage="Role Name is Req" ControlToValidate="txtRolename"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="HFRoleId" runat="server" />
                                    </table>
                                </div>
                                <div class="Diagnosis_AcctionBtn">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnSaveRole" runat="server" CssClass="subbtn" ValidationGroup="vg4"
                                                    CausesValidation="true" Text="Save" OnClick="BtnSaveRole_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="BtnCancelRole" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="false"
                                                    OnClick="BtnCancelRole_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Label ID="Label10" runat="server" Text="Employee Role List" CssClass="Font_header"></asp:Label><div
                                    class="GridView">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Repeater ID="RptDisignation" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" border="1px">
                                                            <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                                                <td>
                                                                    Options
                                                                </td>
                                                                <td>
                                                                    Role Name
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr style="background-color: #EEF5FF; text-align: center;">
                                                            <td>
                                                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("RoleId") %>'
                                                                    Text="[Show]" CommandName="Show" CausesValidation="false" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("RoleName") %>' />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr style="background-color: #8FADD9">
                                                            <td colspan="4" align="center">
                                                                <asp:Label ID="Label1" runat="server" Text="Role Info..." ForeColor="White"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        </table></FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblCurrentPage" runat="server"> </asp:Label><asp:HyperLink ID="lnkPrev"
                                                    runat="server"><< Prev</asp:HyperLink><asp:HyperLink ID="lnkNext" runat="server">Next >></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="clear">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </contenttemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
