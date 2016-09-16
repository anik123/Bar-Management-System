<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EmployeeInfo.aspx.cs" Inherits="UI.AccSysManagment.Employee.EmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function setText(newValue) {
            document.getElementById("<%=txtTitle.ClientID %>").value = newValue;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function seteximination(newValue) {
            document.getElementById("<%=txtexmination.ClientID %>").value = newValue;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function seteducationbord(newValue) {
            document.getElementById("<%=txteducationbord.ClientID %>").value = newValue;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function setdivision_cgpa(newValue) {
            document.getElementById("<%=txtDivision_cgpa.ClientID %>").value = newValue;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tab" Width="100%" 
                ActiveTabIndex="1">
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="BasicInfo">
                    <ContentTemplate>
                        <div class=" EmpBasicInfo_main">
                            <div>
                                <asp:Label ID="Label23" runat="server" Text="Employee Basic Info " CssClass="Font_header"></asp:Label></div>
                            <div class="EmpBasicInfo_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="clabel_Tarun">Employee Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmpName" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ID="Rfn" runat="server" ControlToValidate="txtEmpName"
                                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Emp Name Req."></asp:RequiredFieldValidator>
                                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender1"
                                                TargetControlID="Rfn" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" CssClass="clabel_Tarun" Text="Sur Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSurName" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Father Name:" CssClass="clabel_Tarun"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFatherName" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" CssClass="clabel_Tarun" Text="Mother Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMotherName" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" CssClass="clabel_Tarun" Text="Family Number:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFamilyContact" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" CssClass="clabel_Tarun" Text="Date of Birth:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDOB" CssClass="input_textcss" runat="server"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                                Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtDOB">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                                Operator="DataTypeCheck" ControlToValidate="txtDOB" ErrorMessage="Not Valid">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" CssClass="clabel_Tarun" Text="Age:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtage" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelGender" runat="server" CssClass="clabel_Tarun" Text="Gender:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbGenderEdit" runat="server" Width="210px" CssClass="RadioBtn_css"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" CssClass="clabel_Tarun" Text="Merital Status:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdbMeitalStatus" runat="server" Width="168px" CssClass="RadioBtn_css"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">UnMarried</asp:ListItem>
                                                <asp:ListItem>Married</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="clabel_Tarun" Text="Email:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="clabel_Tarun" Text="Phone:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" CssClass="clabel_Tarun">Mobile1:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobile1" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ID="RM1" runat="server" ControlToValidate="txtMobile1"
                                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Mobile1 Req."></asp:RequiredFieldValidator>
                                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender2"
                                                TargetControlID="RM1" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Mobile2:" CssClass="clabel_Tarun"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobile2" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" CssClass="clabel_Tarun" Text="Permanent Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPermanentAdd" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="clabel_Tarun" Text="Present Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPresentAdd" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" CssClass="clabel_Tarun" Text="Religion:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="input_textcss" /><asp:ListBox
                                                ID="lstTitles" runat="server" Style="display: none; visibility: hidden;" Height="36px"
                                                CssClass="input_textcss">
                                                <asp:ListItem Text="Hindu" Value="Hindu" />
                                                <asp:ListItem Text="Muslim" Value="Muslim" />
                                            </asp:ListBox>
                                            <ajaxtoolkit:DropDownExtender runat="server" ID="DDE1" TargetControlID="txtTitle"
                                                DropDownControlID="lstTitles" DynamicServicePath="" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" CssClass="clabel_Tarun" Text="Nationality:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNationality" CssClass="DDL_2_div" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" CssClass="clabel_Tarun" Text="National Id#:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNationalIdNumber" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label29" runat="server" CssClass="clabel_Tarun" Text="Otizm  Status:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RbOtizmStatus" runat="server" AutoPostBack="True" Width="195px"
                                                RepeatDirection="Horizontal" OnSelectedIndexChanged="RbOtizmStatus_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">No</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblOtizmType" runat="server" Visible="False" CssClass="clabel_Tarun"
                                                Text="Otizm Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOtizmType" runat="server" Visible="False" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label30" runat="server" CssClass="clabel_Tarun" Text="Reference By:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReferenceBy" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label31" runat="server" CssClass="clabel_Tarun" Text="Reference Mobile:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRefContactNum" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="EmpBasicInfo_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" CssClass="clabel_Tarun" Text="Job Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RbJobType" runat="server" Width="250px" CssClass="RadioBtn_css"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Full Time</asp:ListItem>
                                                <asp:ListItem>Part Time</asp:ListItem>
                                                <asp:ListItem>Call Up</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" CssClass="clabel_Tarun">Branch:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="DDL_2_div" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RFBr" runat="server" Font-Size="8px"
                                                ForeColor="Red" ErrorMessage="Branch Rq" InitialValue="0" ControlToValidate="ddlBranch"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" CssClass="clabel_Tarun">Employee Type:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddldeptName" runat="server" CssClass="DDL_2_div" OnSelectedIndexChanged="ddldeptName_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server"
                                                Font-Size="8px" ForeColor="Red" ErrorMessage="Emp Type" InitialValue="0" ControlToValidate="ddlDesignation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" CssClass="clabel_Tarun">Specialist:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="DDL_2_div" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <span class="Mandatory">*</span>
                                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                                Font-Size="8px" ForeColor="Red" ErrorMessage="Desig Req" InitialValue="0" ControlToValidate="ddlDesignation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" CssClass="clabel_Tarun" Text="Join Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtjoindate" CssClass="input_textcss" runat="server"></asp:TextBox><ajaxtoolkit:CalendarExtender
                                                ID="cal" runat="server" Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtjoindate">
                                            </ajaxtoolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" CssClass="clabel_Tarun" Text="Job Status:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RbJobStatus" runat="server" Width="200px" CssClass="RadioBtn_css"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Continue</asp:ListItem>
                                                <asp:ListItem> DisContinue</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" CssClass="clabel_Tarun">User Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="input_textcss"></asp:TextBox><span
                                                class="Mandatory"> *</span>
                                            <asp:RequiredFieldValidator ID="RFUN" runat="server" ControlToValidate="txtUserName"
                                                Display="None" ErrorMessage="<b>Required Field Missing</b><br />UserName Req."></asp:RequiredFieldValidator>
                                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender3"
                                                TargetControlID="RFUN" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label121" runat="server" CssClass="clabel_Tarun">Pass Word:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassWord" runat="server" MaxLength="100" CssClass="input_textcss"></asp:TextBox><span
                                                class="Mandatory"> *</span><%--<asp:CheckBox
                                                    ID="ChkBoxPassword" runat="server" AutoPostBack="true" Text="Show" Checked="True"
                                                    OnCheckedChanged="ChkBoxPassword_CheckedChanged" />--%><asp:RequiredFieldValidator
                                                        ID="RFP" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />PassWord Req."></asp:RequiredFieldValidator>
                                            <ajaxtoolkit:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender4"
                                                TargetControlID="RFP" HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label20" runat="server" CssClass="clabel_Tarun" Text="Image:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" onchange="this.form.submit();" Width="140px" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label130" runat="server" Visible="False" CssClass="clabel_Tarun" Text="View Image:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblImageMewssage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            <br />
                                            <asp:Image ID="Image1" Height="190px" Width="160px" BorderWidth="1px" runat="server"
                                                ImageUrl="~/Images/Pic002.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnlFileName" Visible="False" runat="server">
                                            <td valign="top">
                                                <asp:Label ID="lblfileuploadinfo" runat="server" CssClass="clabel_Tarun" Text="Uploaded File Info:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:GridView ID="GVFILE" runat="server" BackColor="#92B8EF" Font-Size="9px" CssClass="textbox3"
                                                    BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                                    Height="12px" Width="100%" PageSize="2" DataKeyNames="FileNo">
                                                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                        PageButtonCount="2" />
                                                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1_Image" runat="server" OnCommand="LinkButton1_Click_Image"
                                                                    CommandArgument='<%# Eval("FileNo") %>' Text="Delete" CommandName="Delete" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FileNo" HeaderText="Item No" />
                                                        <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                        <asp:BoundField DataField="FileSize" HeaderText="File Size" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="HFImageFileName" runat="server" />
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="heId" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 400px;">
                                        <asp:Button ID="btnSave" runat="server" CssClass="subbtn" CausesValidation="true"
                                            Text="Insert" OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="clearbtn"
                                            Text="Cancel" OnClick="btnCancel_Click" />
                                        <asp:Button ID="btnSearch" runat="server" CausesValidation="false" CssClass="clearbtn"
                                            Text="Search" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-top: 20px;">
                        </div>
                        <div class="EmpBasicInfo_Search_main">
                            <div>
                                <asp:Label ID="Label21" runat="server" Text=" Search Employee " CssClass="Font_header"></asp:Label></div>
                            <div class="EmpBasicInfo_Search_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lb12" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmpNames" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                OnTextChanged="txtEmpidS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" CssClass="clabel_Tarun" Text="Mobile:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileS" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                OnTextChanged="txtEmpidS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="EmpBasicInfo_Search_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label26" runat="server" CssClass="clabel_Tarun" Text="User Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUerNameS" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                OnTextChanged="txtEmpidS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" CssClass="clabel_Tarun" Text="Sur Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSurNameS" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                OnTextChanged="txtEmpidS_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div>
                            <asp:Label ID="Label122" runat="server" Text="Employee  Record List" CssClass="Font_header"></asp:Label></div>
                        <div class="GridView">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvEmpBasic" runat="server" BackColor="White" BorderColor="White"
                                            Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                            CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                            OnPageIndexChanging="GvEmpBasic_PageIndexChanging" DataKeyNames="EmpId" PageSize="5">
                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                            <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                PageButtonCount="5" />
                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                                HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_Basic"
                                                            CommandArgument='<%# Eval("EmpId") %>' Text="[Show]" CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                <asp:BoundField DataField="Mobile1" HeaderText="Mobile" />
                                                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                                <asp:BoundField DataField="BrProName" HeaderText=" Branch Name" />
                                                <asp:BoundField DataField="EmptypeName" HeaderText=" Department" />
                                                <asp:BoundField DataField="SpecilistName" HeaderText=" Desigantion" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <%-- START FORM HERE EMP EDUCATION--%>
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel4" HeaderText="Education Info">
                    <ContentTemplate>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="margin-left: 200px; text-align: right;">
                                        <asp:Label ID="Ll24" runat="server" Text="Select From Here" CssClass="Font_header"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RbtnSelectMode" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="RbtnSelectMode_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">New Entry</asp:ListItem>
                                            <asp:ListItem>Update </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="PnlEdusearch_Rpt" Width="100%" runat="server">
                            <div class="EduSearch_main">
                                <div class="EduSearch_Left">
                                    <div>
                                        <asp:Label ID="Label35" runat="server" Text=" Search Employee For New Entry " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEdu_EmpType" runat="server" CssClass="input_textcss" OnSelectedIndexChanged="ddlEdu_EmpType_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label37" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEdu_Spcilist" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlEdu_Spcilist_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label38" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEdu_EmpName" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlEdu_EmpName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="EduSearch_Right">
                                    <div>
                                        <asp:Label ID="Label39" runat="server" Text="Employee BasicInfo " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label40" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEdu_Show_EmpName" runat="server" ReadOnly="True" CssClass="input_textcss"
                                                    AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label41" runat="server" CssClass="clabel_Tarun" Text="Mobile:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEdu_Show_Mobile" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label42" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEdu_Show_EmpType" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label43" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEdu_Show_Specilist" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlSearchEmp_update" Visible="False" runat="server">
                            <div class="EduSearch_Update_main">
                                <div class="EduSearch_Update_left">
                                    <asp:Label ID="Label50" runat="server" Text=" Search Employee For Education Update "
                                        CssClass="Font_header"></asp:Label><table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label51" runat="server" CssClass="Emp_Update_serch_lbl" Text="Employee Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEduS_EmpName" runat="server" CssClass="Emp_Update_serch_input_textcss "
                                                        AutoPostBack="True" OnTextChanged="txtEduS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label52" runat="server" CssClass="Emp_Update_serch_lbl" Text="Mobile:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEduS_Mobile" runat="server" CssClass="Emp_Update_serch_input_textcss "
                                                        AutoPostBack="True" OnTextChanged="txtEduS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label53" runat="server" CssClass="Emp_Update_serch_lbl" Text="User Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEduS_UserName" runat="server" CssClass="Emp_Update_serch_input_textcss "
                                                        AutoPostBack="True" OnTextChanged="txtEduS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label54" runat="server" CssClass="Emp_Update_serch_lbl" Text="Sur Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEduS_SurName" runat="server" CssClass="Emp_Update_serch_input_textcss "
                                                        AutoPostBack="True" OnTextChanged="txtEduS_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                </div>
                                <div class="EduSearch_Update_right">
                                    <asp:Label ID="Label123" runat="server" Text="Employee List" CssClass="Font_header"></asp:Label><div>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GVEdu_EmpBasic" runat="server" BackColor="White" BorderColor="White"
                                                        Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                        OnPageIndexChanging="GVEdu_EmpBasic_PageIndexChanging" DataKeyNames="EmpId" PageSize="4">
                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                            PageButtonCount="4" />
                                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("EmpId") %>'
                                                                        Text="[Show]" CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EmpName" HeaderText="Emp Name" />
                                                            <asp:BoundField DataField="Mobile1" HeaderText="Mobile1" />
                                                            <asp:BoundField DataField="UserName" HeaderText=" UserName" />
                                                            <asp:BoundField DataField="EmptypeName" HeaderText=" Employee Department" />
                                                            <asp:BoundField DataField="SpecilistName" HeaderText="Employee Desigantion" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfEID_update" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HEdu_EmpID" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnleduInfo_rpt" Visible="False" runat="server">
                            <div>
                                <asp:Label ID="Label56" runat="server" Text="Employee Education Record" CssClass="Font_header"></asp:Label></div>
                            <div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvEduInfo" runat="server" BackColor="White" BorderColor="White"
                                                Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                OnPageIndexChanging="GvEduInfo_PageIndexChanging" DataKeyNames="EduId" PageSize="7">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                    PageButtonCount="7" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_Edu_update"
                                                                CommandArgument='<%# Eval("EduId") %>' Text="[Show]" CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                    <asp:BoundField DataField="Eximination" HeaderText="Eximination" />
                                                    <asp:BoundField DataField="InstituteName" HeaderText=" Institute Name" />
                                                    <asp:BoundField DataField="PassingYear" HeaderText="  Passing Year " />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div class=" EmpEdu_main">
                            <div>
                                <asp:Label ID="Label83" runat="server" Text="Employee Education Info " CssClass="Font_header"></asp:Label></div>
                            <div class="EmpEdu_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" CssClass="clabel_Tarun" Text="Eximination:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtexmination" runat="server" CssClass="input_textcss" /><asp:ListBox
                                                ID="lsteximination" runat="server" Style="display: none; visibility: hidden;"
                                                Height="70px" CssClass="input_textcss">
                                                <asp:ListItem Text="SSC" Value="SSC" />
                                                <asp:ListItem Text="HSC" Value="HSC" />
                                                <asp:ListItem Text="MBBS" Value="MBBS" />
                                                <asp:ListItem Text="FCPS" Value="FCPS" />
                                                <asp:ListItem Text="BBA" Value="BBA" />
                                                <asp:ListItem Text="MBA" Value="MBA" />
                                            </asp:ListBox>
                                            <ajaxtoolkit:DropDownExtender runat="server" ID="DDE2" TargetControlID="txtexmination"
                                                DropDownControlID="lsteximination" DynamicServicePath="" Enabled="True" />
                                            <asp:RequiredFieldValidator ID="rfexam" runat="server" ControlToValidate="txtexmination"
                                                Display="None" InitialValue="0" ErrorMessage="<b>Required Field Missing</b><br />Eximination is Req."></asp:RequiredFieldValidator><ajaxtoolkit:ValidatorCalloutExtender
                                                    runat="server" ID="ValidatorCalloutExtender12" TargetControlID="rfexam" HighlightCssClass="validatorCalloutHighlight"
                                                    Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label45" runat="server" CssClass="clabel_Tarun" Text=" Education Board:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txteducationbord" runat="server" CssClass="input_textcss" /><asp:ListBox
                                                ID="LstEducationBord" runat="server" Style="display: none; visibility: hidden;"
                                                Height="100px" CssClass="input_textcss">
                                                <asp:ListItem Text="Barisal" Value="Barisal" />
                                                <asp:ListItem Text="Comilla" Value="Comilla" />
                                                <asp:ListItem Text="Dhaka" Value="Dhaka" />
                                                <asp:ListItem Text="Dinajpur" Value="Dinajpur" />
                                                <asp:ListItem Text="Jessore" Value="Jessore" />
                                                <asp:ListItem Text="Rajshahi" Value="Rajshahi" />
                                                <asp:ListItem Text="Sylhat" Value="Sylhat" />
                                            </asp:ListBox>
                                            <ajaxtoolkit:DropDownExtender runat="server" ID="DDE3" TargetControlID="txteducationbord"
                                                DropDownControlID="LstEducationBord" DynamicServicePath="" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" CssClass="clabel_Tarun" Text="Institute Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInstitute" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="EmpEdu_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label47" runat="server" CssClass="clabel_Tarun" Text="Result Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlResulttype" runat="server" CssClass="DDL_2_div">
                                                <asp:ListItem>Division</asp:ListItem>
                                                <asp:ListItem>CGPA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" CssClass="clabel_Tarun" Text="Division/CGPA:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDivision_cgpa" runat="server" CssClass="DDL_2_div" /><asp:ListBox
                                                ID="LstDivision_cgpa" runat="server" Style="display: none; visibility: hidden;"
                                                CssClass="DDL_2_div">
                                                <asp:ListItem Text="1st Division" Value="1stDivision" />
                                                <asp:ListItem Text="2nd Division" Value="2ndDivision" />
                                                <asp:ListItem Text="3rd Division" Value="3rdDivision" />
                                                <asp:ListItem Text="Passed" Value="Passed" />
                                            </asp:ListBox>
                                            <ajaxtoolkit:DropDownExtender runat="server" ID="DDE5" TargetControlID="txtDivision_cgpa"
                                                DropDownControlID="LstDivision_cgpa" DynamicServicePath="" Enabled="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label49" runat="server" CssClass="clabel_Tarun" Text="Passing Year:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPasssingYear" runat="server" CssClass="DDL_2_div">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnEduAdd" runat="server" CausesValidation="False" CssClass="subbtn"
                                            Text="ADD" OnClick="btnEduAdd_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEduClear" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnEduClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="GridView">
                            <asp:Panel ID="pnlGridview" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label124" runat="server" Text="Employee Education List " CssClass="Font_header"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                                                CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                                GridLines="None" AutoGenerateColumns="False" Height="16px" AllowPaging="True"
                                                OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" OnRowDeleting="GridView1_RowDeleting">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#9471DE" ForeColor="White" />
                                                <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButtonEdu" runat="server" OnClick="LinkButtonEdu_Click" CausesValidation="false"
                                                                OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');">Remove</asp:LinkButton></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Eximination" HeaderText="Eximination Name" />
                                                    <asp:BoundField DataField="Board" HeaderText="Education Board" />
                                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                                    <asp:BoundField DataField="ResultType" HeaderText="Result Type" />
                                                    <asp:BoundField DataField="Division" HeaderText="Result" />
                                                    <asp:BoundField DataField="PassingYear" HeaderText="Passing Year" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:Panel ID="pnlEduSave" runat="server" Width="100%" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEduSave" runat="server" CausesValidation="False" CssClass="subbtn"
                                                Text="Save" OnClick="btnEduSave_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEduCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                                OnClick="btnEduCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel5" HeaderText="Trianing Info">
                    <ContentTemplate>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="margin-left: 200px; text-align: right;">
                                        <asp:Label ID="Label58" runat="server" Text="Select From Here" CssClass="Font_header"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RbtTriningInfo" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="RbtTriningInfo_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">New Entry</asp:ListItem>
                                            <asp:ListItem>Update </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="PnlTringSearch_newEntry" Width="100%" runat="server">
                            <div class="EduSearch_main">
                                <div class="EduSearch_Left">
                                    <div>
                                        <asp:Label ID="Label59" runat="server" Text=" Search Employee For New Entry " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label60" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTring_EmpType" runat="server" CssClass="input_textcss" OnSelectedIndexChanged="ddlTring_EmpType_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label61" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTring_Spcilist" runat="server" CssClass="input_textcss"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlTring_Spcilist_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label62" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTrin_EmpName" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlTrin_EmpName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="EduSearch_Right">
                                    <div>
                                        <asp:Label ID="Label63" runat="server" Text="Employee BasicInfo " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label64" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtTrianShow_EmpName" runat="server" ReadOnly="True" CssClass="input_textcss"
                                                    AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label65" runat="server" CssClass="clabel_Tarun" Text="Mobile:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtTrianShow_Mobile" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label66" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtTrianShow_EmpType" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label67" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtTrianShow_Spcilist" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlEmpSearch_trining_update" Visible="False" runat="server">
                            <div class="EduSearch_Update_main">
                                <div class="EduSearch_Update_left">
                                    <asp:Label ID="Label68" runat="server" Text=" Search Employee For Trianing Update "
                                        CssClass="Font_header"></asp:Label><table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label69" runat="server" CssClass="Emp_Update_serch_lbl" Text="Employee Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrin_EmpName" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtTraing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label70" runat="server" CssClass="Emp_Update_serch_lbl" Text="Mobile:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrin_Mobile" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtTraing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label71" runat="server" CssClass="Emp_Update_serch_lbl" Text="User Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrin_UserName" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtTraing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label72" runat="server" CssClass="Emp_Update_serch_lbl" Text="Sur Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTrin_SurName" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtTraing_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                </div>
                                <div class="EduSearch_Update_right">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GvTrain_EmpBasic" runat="server" BackColor="White" BorderColor="White"
                                                    Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    OnPageIndexChanging="GvTrain_EmpBasic_PageIndexChanging" DataKeyNames="EmpId"
                                                    PageSize="4">
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                        PageButtonCount="4" />
                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" Font-Bold="True"
                                                        HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnShow_Emp" runat="server" OnCommand="LinkButton_Command_trining"
                                                                    CommandArgument='<%# Eval("EmpId") %>' Text="[Show]" CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                        <asp:BoundField DataField="Mobile1" HeaderText="Mobile1" />
                                                        <asp:BoundField DataField="UserName" HeaderText=" UserName" />
                                                        <asp:BoundField DataField="EmptypeName" HeaderText=" Employee Department" />
                                                        <asp:BoundField DataField="SpecilistName" HeaderText="Employee Desigantion" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hftrain_update" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HTrian_EmpID" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlTriningRpt" Visible="False" runat="server">
                            <div>
                                <asp:Label ID="Label74" runat="server" Text="Employee Training Record" CssClass="Font_header"></asp:Label></div>
                            <div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvTrainInfo" runat="server" BackColor="White" BorderColor="White"
                                                Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                DataKeyNames="TrainingId" OnPageIndexChanging="GvTrainInfo_PageIndexChanging"
                                                PageSize="7">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                    PageButtonCount="7" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                                    VerticalAlign="Middle" />
                                                <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_Train_update"
                                                                CommandArgument='<%# Eval("TrainingId") %>' Text="[Show]" CommandName="Show"
                                                                CausesValidation="false" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                    <asp:BoundField DataField="TrainingName" HeaderText="Training Name" />
                                                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                                    <asp:BoundField DataField="Location" HeaderText="Location " />
                                                    <asp:BoundField DataField="TrainingYear" HeaderText="Training Year " />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <div class=" EmpEdu_main">
                            <div>
                                <asp:Label ID="Label76" runat="server" Text="Employee Training Info " CssClass="Font_header"></asp:Label></div>
                            <div class="EmpEdu_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label77" runat="server" CssClass="clabel_Tarun" Text="Training Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTrainingName" runat="server" CssClass="input_textcss" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label78" runat="server" CssClass="clabel_Tarun" Text="Topics Covered:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTopicsCovered" CssClass="input_textcss" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label82" runat="server" CssClass="clabel_Tarun" Text="Duration:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDuration" runat="server" CssClass="input_textcss" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="EmpEdu_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label79" runat="server" CssClass="clabel_Tarun" Text=" Institute Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txttrinInstituteName" runat="server" CssClass="input_textcss" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label80" runat="server" CssClass="clabel_Tarun" Text="Location:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLocation" CssClass="input_textcss" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label81" runat="server" CssClass="clabel_Tarun" Text="TrainingYear:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddltrainingYear" runat="server" CssClass="input_textcss">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnTrainAdd" runat="server" CausesValidation="False" CssClass="subbtn"
                                            Text="ADD" OnClick="btnTrainAdd_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnTrainClear" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnTrainClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="GridView">
                            <asp:Panel ID="pnlGridview_Training" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label125" runat="server" Text="Employee Training List" CssClass="Font_header"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="White"
                                                CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                                GridLines="None" AutoGenerateColumns="false" Height="12px" AllowPaging="True"
                                                Width="100%">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#9471DE" ForeColor="White" />
                                                <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButtonTraining" runat="server" OnClick="LinkButtonTraining_Click"
                                                                CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');">Remove</asp:LinkButton></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TrainingName" HeaderText="Training Name" />
                                                    <asp:BoundField DataField="TopicsCovered" HeaderText="Topics Covered" />
                                                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                    <asp:BoundField DataField="TrainingYear" HeaderText="TrainingYear" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:Panel ID="pnlTraingSave" runat="server" Width="100%" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnTrainSave" runat="server" CausesValidation="false" CssClass="subbtn"
                                                Text="Save" OnClick="btnTrainSave_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnTrainCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                                OnClick="btnTrainCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="server" ID="TabPanel6" HeaderText="Exerience Info">
                    <ContentTemplate>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="margin-left: 200px; text-align: right;">
                                        <asp:Label ID="Label90" runat="server" Text="Select From Here" CssClass="Font_header"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RbtExperience" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="RbtExperience_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">New Entry</asp:ListItem>
                                            <asp:ListItem>Update </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlExSerch_new" Width="100%" runat="server">
                            <div class="EduSearch_main">
                                <div class="EduSearch_Left">
                                    <div>
                                        <asp:Label ID="Label91" runat="server" Text=" Search Employee For New Entry " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label92" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlExEmptype" runat="server" CssClass="input_textcss" OnSelectedIndexChanged="ddlExEmptype_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label93" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlExSpcilist" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlExSpcilist_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label94" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlExEmpName" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlExEmpName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="EduSearch_Right">
                                    <div>
                                        <asp:Label ID="Label95" runat="server" Text="Employee BasicInfo " CssClass="Font_header"></asp:Label></div>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label96" runat="server" CssClass="clabel_Tarun" Text="Employee Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExShowEmpname" runat="server" ReadOnly="True" CssClass="input_textcss"
                                                    AutoPostBack="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label97" runat="server" CssClass="clabel_Tarun" Text="Mobile:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExShowMoblie" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label98" runat="server" CssClass="clabel_Tarun" Text="Employee Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExShowEmptype" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label99" runat="server" CssClass="clabel_Tarun" Text="Employee  Designation: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExShowSpecilist" runat="server" CssClass="input_textcss" AutoPostBack="True"
                                                    ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HfExEmpId" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HfExId" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HfExUpStatus" runat="server" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHfExUpStatus" runat="server" Width="10px" Visible="False" AutoPostBack="True">2</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlEx_Update" Visible="False" runat="server">
                            <div class="EduSearch_Update_main">
                                <div class="EduSearch_Update_left">
                                    <asp:Label ID="Label85" runat="server" Text=" Search Employee For Experience Update "
                                        CssClass="Font_header"></asp:Label><table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label86" runat="server" CssClass="Emp_Update_serch_lbl" Text="Employee Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExSEmpName" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtEx_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label87" runat="server" CssClass="Emp_Update_serch_lbl" Text="Mobile:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExSMobile" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtEx_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label88" runat="server" CssClass="Emp_Update_serch_lbl" Text="User Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExSUserName" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtEx_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label89" runat="server" CssClass="Emp_Update_serch_lbl" Text="Sur Name:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExSSurname" runat="server" CssClass="Emp_Update_serch_input_textcss"
                                                        AutoPostBack="True" OnTextChanged="txtEx_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                </div>
                                <div class="EduSearch_Update_right">
                                    <asp:Label ID="Label127" runat="server" Text=" Employee List " CssClass="Font_header"></asp:Label><table
                                        style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="White"
                                                    Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    OnSelectedIndexChanged="GridView4_SelectedIndexChanged" DataKeyNames="EmpId"
                                                    OnPageIndexChanging="GridView4_PageIndexChanging" PageSize="5">
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                        PageButtonCount="5" />
                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                                        VerticalAlign="Middle" />
                                                    <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command_Ex_update"
                                                                    CommandArgument='<%# Eval("EmpId") %>' Text="[Show]" CommandName="Show" CausesValidation="false" /></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                        <asp:BoundField DataField="Mobile1" HeaderText="Mobile" />
                                                        <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                                        <asp:BoundField DataField="EmptypeName" HeaderText="Employee Department" />
                                                        <asp:BoundField DataField="SpecilistName" HeaderText="Employee Desigantion " />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="PnlExperienceInfo" Visible="False" runat="server">
                            <div>
                                <asp:Label ID="Label100" runat="server" Text="Employee Experience Record" CssClass="Font_header"></asp:Label></div>
                            <div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GVExperenceinfo" runat="server" BackColor="White" BorderColor="White"
                                                Width="100%" Height="35px" Font-Size="10px" BorderStyle="Ridge" CellPadding="3"
                                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                OnSelectedIndexChanged="GVExperenceinfo_SelectedIndexChanged" DataKeyNames="ExperienceId"
                                                OnPageIndexChanging="GVExperenceinfo_PageIndexChanging" PageSize="5">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                                    PageButtonCount="5" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                                    VerticalAlign="Middle" />
                                                <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkbtnExperienceInfo" runat="server" OnCommand="LinkbtnExperienceInfo_update"
                                                                CommandArgument='<%# Eval("ExperienceId") %>' Text="[Show]" CommandName="Show"
                                                                CausesValidation="false" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                    <asp:BoundField DataField="Disignation" HeaderText="Disignation" />
                                                    <asp:BoundField DataField="Responsibility" HeaderText="Responsibility" />
                                                    <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" />
                                                    <asp:BoundField DataField="Year" HeaderText="Year of Experience" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <div class=" EmpEdu_main">
                            <div>
                                <asp:Label ID="Label101" runat="server" Text="Employee Experience Info " CssClass="Font_header"></asp:Label></div>
                            <div class="EmpEdu_left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label102" runat="server" CssClass="clabel_Tarun" Text="Designation"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="input_textcss" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label103" runat="server" CssClass="clabel_Tarun" Text="Responsibility"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResponsibility" CssClass="input_textcss" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label104" runat="server" CssClass="clabel_Tarun" Text="Organization Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOrganizationName" runat="server" CssClass="input_textcss" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="EmpEdu_right">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label105" runat="server" CssClass="clabel_Tarun" Text="From Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" CssClass="input_textcss" runat="server"></asp:TextBox><ajaxtoolkit:CalendarExtender
                                                ID="txtFromDate_CalendarExtender" runat="server" Enabled="True" Format="MMMM d, yyyy"
                                                TargetControlID="txtFromDate">
                                            </ajaxtoolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label106" runat="server" CssClass="clabel_Tarun" Text="ToDate:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtToDate" CssClass="input_textcss" runat="server"></asp:TextBox><ajaxtoolkit:CalendarExtender
                                                ID="txtToDate_cal" runat="server" Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtToDate">
                                            </ajaxtoolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label107" runat="server" CssClass="clabel_Tarun" Text="Year"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYear" runat="server" CssClass="input_textcss"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="ActionButton_div">
                            <table style="width: 100%; height: 22px;">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnExADD" runat="server" CausesValidation="False" CssClass="subbtn"
                                            Text="ADD" OnClick="btnExADD_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExClear" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                            OnClick="btnExClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="GridView">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label126" runat="server" Text="Employee Experience List " CssClass="Font_header"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="White"
                                                Font-Size="10px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="16px" AllowPaging="True"
                                                OnPageIndexChanging="GridView3_PageIndexChanging" Width="100%" OnRowDeleting="GridView3_RowDeleting">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#9471DE" ForeColor="White" />
                                                <HeaderStyle BackColor="#8FADD9" ForeColor="#E7E7FF" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButtonExp" runat="server" OnClick="LinkButtonExp_Click" CausesValidation="false"
                                                                OnClientClick="javascript:returnconfirm('Do you really want to \ndelete the item?');">Remove</asp:LinkButton></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Disignation" HeaderText="Disignation" />
                                                    <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" />
                                                    <asp:BoundField DataField="Responsibility" HeaderText="Responsibility" />
                                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" />
                                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" />
                                                    <asp:BoundField DataField="Year" HeaderText="Year" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <div class="clear">
                        </div>
                        <div>
                            <asp:Panel ID="PnlExSave" runat="server" Width="100%" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnExpSave" runat="server" CausesValidation="False" CssClass="subbtn"
                                                Text="Save" OnClick="btnExpSave_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExCancel" runat="server" CssClass="clearbtn" Text="Clear" CausesValidation="False"
                                                OnClick="btnExCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
            <%-- <triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlExEmptype" />
                        <asp:AsyncPostBackTrigger ControlID="ddlExSpcilist" />
                        <asp:AsyncPostBackTrigger ControlID="ddlExEmpName" />
                      
                        <asp:AsyncPostBackTrigger ControlID="ddlTring_EmpType" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTring_Spcilist" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTrin_EmpName" />
                        <asp:AsyncPostBackTrigger ControlID="ddltrainingYear" />
                        
                        <asp:AsyncPostBackTrigger ControlID="ddlEdu_EmpType" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEdu_Spcilist" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEdu_EmpName" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPasssingYear" />
                        <asp:AsyncPostBackTrigger ControlID="ddlResulttype" />
                    </triggers>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
