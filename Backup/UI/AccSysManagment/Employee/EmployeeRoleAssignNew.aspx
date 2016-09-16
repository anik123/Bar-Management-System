<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeRoleAssignNew.aspx.cs" Inherits="UI.AccSysManagment.Employee.EmployeeRoleAssignNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label5" runat="server" Text="Employee Role SetUp" CssClass="Font_header"></asp:Label>
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="EmpAssign">
                <table style="margin-left: 250px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="Xtralebel" Text="Employee Name:"></asp:Label>
                        </td>
                        <td>
                            <ajaxtoolkit:ComboBox ID="CEmpName" runat="server" Width="260px" AutoPostBack="true"
                                DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False"
                                CssClass="ComboBoxCss" ItemInsertLocation="Append" />
                            <span class="Mandatory">*</span>
                            <asp:Label ID="lblEmpvalidation" runat="server" Visible="false" ForeColor="Red">Emp Name Req</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Xtralebel">Role Name: </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRoleName" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                Width="290px">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                ForeColor="Red" ControlToValidate="ddlRoleName" InitialValue="0">Role Name Req</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFUserRoleId" runat="server" />
                </table>
            </div>
            <div>
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
            <asp:Label ID="Label9" runat="server" Text="Employee Role List" CssClass="Font_header"></asp:Label>
            <div class="GridView">
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
                                                Employee Type
                                            </td>
                                            <td>
                                                Spcility
                                            </td>
                                            <td>
                                                Employee Name
                                            </td>
                                            <td>
                                                Role Name
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="background-color: #EEF5FF; text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("UserRoleId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("EmpType") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("EmpSpcility") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("EmpName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("RoleName") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label1" runat="server" Text="User Role Assign Info..." ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCurrentPage" runat="server"> </asp:Label>
                            <asp:HyperLink ID="lnkPrev" runat="server"><< Prev</asp:HyperLink>
                            <asp:HyperLink ID="lnkNext" runat="server">Next >></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
