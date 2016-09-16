<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmpRoleAssign.aspx.cs" Inherits="UI.AccSysManagment.Employee.EmpRoleAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="middle">
<div class="Singlelebel_Child">
    <asp:Label ID="Label5" runat="server" Text="Employee Role SetUp" ></asp:Label>
    </div>
    </div>
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="EmpAssign">
                <table style="margin-left: 250px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" CssClass="Xtralebel" Text="Employee Type:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddldeptName" runat="server" CssClass="input_textcss" Width="290px"
                                OnSelectedIndexChanged="ddldeptName_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="rfvCat" runat="server" ControlToValidate="ddldeptName"
                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Type is required."></asp:RequiredFieldValidator>
                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender11"
                                TargetControlID="rfvCat" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" CssClass="Xtralebel" Text="Specialist:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                Width="290px" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ID="rfvdesig" runat="server" ControlToValidate="ddlDesignation"
                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Specility is required."></asp:RequiredFieldValidator>
                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender362"
                                TargetControlID="rfvdesig" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="Xtralebel" Text="Employee Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                Width="290px">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <%--<asp:RequiredFieldValidator ID="RfEmpName" runat="server" ControlToValidate="ddlEmpName"
                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Emp Name is required."></asp:RequiredFieldValidator>
                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender2"
                                TargetControlID="RfEmpName" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />--%>
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
                            <asp:RequiredFieldValidator ID="RFVRN" runat="server" ControlToValidate="ddlRoleName"
                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Role is required."></asp:RequiredFieldValidator>
                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1"
                                TargetControlID="RFVRN" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFUserRoleId" runat="server" />
                </table>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="subbtn" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="Singlelebel_Child">
            <asp:Label ID="Label9" runat="server" Text="Employee Role List" ></asp:Label>
            </div>
            <div class="GridView">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptDisignation" runat="server">
                                <HeaderTemplate>
                                    <table width="100%">
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
                                            <asp:Label ID="Label1" runat="server" Text="User Role Info..." ForeColor="White"></asp:Label>
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
        <Triggers>
            <%--  <asp:AsyncPostBackTrigger ControlID="ddldeptName" />
            <asp:AsyncPostBackTrigger ControlID="ddlDesignation" />
            <asp:AsyncPostBackTrigger ControlID="ddlEmpName" />
            <asp:AsyncPostBackTrigger ControlID="ddlRoleName" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
