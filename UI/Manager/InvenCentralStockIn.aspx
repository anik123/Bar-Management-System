<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InvenCentralStockIn.aspx.cs" Inherits="UI.Manager.InvenCentralStockIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label14" runat="server" CssClass="Font_header" Text="Search Purchase Order"></asp:Label>
            </div>
            <asp:Panel ID="pnlSearch" runat="server">
                <div class="PharmProPur_main">
                    <div class="InvenPur_left">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Text="From : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        Format="MMMM d, yyyy" TargetControlID="txtDateFrom">
                                    </ajaxtoolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        Format="MMMM d, yyyy" TargetControlID="txtDateTo">
                                    </ajaxtoolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="clabel_Location" Text="Company : "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCName_S" runat="server" CssClass="input_textcss" Width="200px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                        Visible="false" ControlToValidate="ddlCName_S">*Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" CssClass="clabel_Location" Text="Order No:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMed_S" runat="server" CssClass="input_textcss" Width="200px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="PharmProPur">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearchCancel" runat="server" CausesValidation="false" CssClass="Clear_Short"
                                    Text="Cancel" OnClick="btnSearchCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlOrder" Visible="false" runat="server">
                <div class="PharmProPur">
                    <asp:Label ID="Label1" runat="server" CssClass="Font_header" Text="Purchase Order List"></asp:Label>
                    <asp:GridView ID="GVCOA" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                        Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                        PageSize="6" DataKeyNames="OrderNo" OnPageIndexChanging="GVCOA_PageIndexChanging"
                        AllowPaging="true">
                        <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="6" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton1_Click" CommandArgument='<%# Eval("OrderNo") %>'
                                        Text="[Show]" CommandName="Show" CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                            <asp:BoundField DataField="OrderBy" HeaderText="Order By" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlInfo" Visible="false" runat="server">
                <div class="PharmProPur">
                    <asp:Label ID="Label2" runat="server" CssClass="Font_header" Text="Ordered Medication List"></asp:Label><span
                        style="padding-left: 20px;"><asp:Button ID="btnPost" runat="server" Width="122px"
                            Height="22px" Text="Post To Purchase" OnClick="btnPost_Click" /></span>
                    <asp:GridView ID="GVINFO" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                        Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                        PageSize="6" DataKeyNames="OrderNo" OnPageIndexChanging="GVINFO_PageIndexChanging"
                        AllowPaging="true">
                        <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="6" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBINFO_Click" CommandArgument='<%# Eval("OrderNo") %>'
                                        Text="[ADD]" CommandName="Show" CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MedTypeName" HeaderText="Medication Type" />
                            <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                            <asp:BoundField DataField="Punit" HeaderText="Medication Unit" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                            <asp:BoundField DataField="Priority" HeaderText="Priority" />
                            <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                            <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlUpdate" runat="server">
                <div>
                    <asp:Label ID="lbl7" runat="server" CssClass="Font_header" Text="Medication Entry"></asp:Label><br>
                </div>
                <div class="InvenPur_main">
                    <div class="InvenPur_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" CssClass="clabel_Location" Text="Medication Type:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMedType" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlMedType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlMedType" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lcomp" runat="server" CssClass="clabel_Location" Text="Product Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RC" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                        ControlToValidate="ddlPName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Unit:" CssClass="Medication_UnitLbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RbtWeight" RepeatDirection="Horizontal" CssClass="Medication_textcss_Unit"
                                        runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True">cc</asp:ListItem>
                                        <asp:ListItem>gm</asp:ListItem>
                                        <asp:ListItem>mg</asp:ListItem>
                                        <asp:ListItem>ml</asp:ListItem>
                                        <asp:ListItem>µmg</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Priority:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RbPriority" CssClass="RbCss" runat="server" AutoPostBack="True"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">High</asp:ListItem>
                                        <asp:ListItem>Mid</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Current Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCurrent" runat="server" CssClass="input_textcss" ReadOnly="true"
                                        Text="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelMobile1" runat="server" CssClass="clabel_Location" Text=" Purchase Quantity:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPQuality" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">* </span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                        Visible="true" ValidationGroup="vg1" ControlToValidate="txtPQuality">Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="clabel_Location" Text="Unit Price:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurPrice" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">* </span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                        Visible="true" ValidationGroup="vg1" ControlToValidate="txtPurPrice">Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" CssClass="clabel_Location" Text="Expriy Date:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExpriyDate" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <span class="Mandatory">* </span>
                                    <ajaxtoolkit:CalendarExtender ID="txtexpcal" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                        TargetControlID="txtExpriyDate">
                                    </ajaxtoolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                        Visible="true" ValidationGroup="vg1" ControlToValidate="txtExpriyDate">Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" CssClass="clabel_Location" Text="Batch No:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBatchNo" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
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
                            <td class="style1">
                                <asp:Button ID="btnAdd" runat="server" CssClass="Add_Short" CausesValidation="true"
                                    ValidationGroup="vg1" Text="ADD" OnClick="btnAdd_Click" />
                            </td>
                            <td class="style1">
                                <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="Clear_Short" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div class="clear">
            </div>
            <asp:Panel ID="pnlAction" Visible="false" runat="server">
                <div class="pham_PurReq">
                    <asp:Label ID="Label3" runat="server" CssClass="Font_header" Text="Medication Entry List"></asp:Label>
                    <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                        Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                        PageSize="6" DataKeyNames="MedicationId" OnPageIndexChanging="GvUpdate_PageIndexChanging"
                        AllowPaging="true">
                        <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="6" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" OnCommand="GvUpdateEdit_Click" CommandArgument='<%# Eval("MedicationId") %>'
                                        Text="[Edit]" CommandName="Show" CausesValidation="false" />
                                    <asp:LinkButton ID="btnShow" runat="server" OnCommand="GvUpdate_Click" CommandArgument='<%# Eval("MedicationId") %>'
                                        Text="[Delete]" CommandName="Show" CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MedTypeName" HeaderText="Medication Type" />
                            <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                            <asp:BoundField DataField="Punit" HeaderText="Medication Unit" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                            <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                            <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                            <asp:TemplateField HeaderText="Expiry Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGvExpiryDate" Width="100px" Text='<%#Eval("ExpriyDate") %>' runat="server"></asp:TextBox>
                                    <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                        Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtGvExpiryDate">
                                    </ajaxtoolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch No#">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBatchNo" Width="50px" Text='<%#Eval("BatchNo") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <%--   OnTextChanged="txtGv_TextChanged"--%>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlPayment" runat="server">
                <asp:Label ID="Label19" runat="server" CssClass="Font_header" Text="Action Panel"></asp:Label>
                <div class="InvenPur_main">
                    <div class="InvenPur_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblExpriyDateMissing" ForeColor="Red" Visible="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" Visible="false" runat="server" CssClass="clabel_Tarun" Text="SalesMan Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" Visible="false" CssClass="input_textcss" Width="200px"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" Visible="false" runat="server" CssClass="clabel_Tarun" Text="Note"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" Visible="false" CssClass="input_textcss" Width="200px"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label110" CssClass="clabel_Tarun" runat="server" Text="Total Payable (Tk)"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPayable" ReadOnly="true" ForeColor="Red" AutoPostBack="true"
                                        CssClass="input_textcss" Width="200px" runat="server" Text="0"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="clabel_Tarun" Text="Salesman Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalesmanName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                    <span class="Mandatory">* </span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                        Visible="true" ValidationGroup="vg3" ControlToValidate="txtSalesmanName">Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label210" runat="server" CssClass="clabel_Tarun" Text="Note"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNote" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <div class="PharmProPur">
                <asp:Panel ID="pnlInsert" Visible="false" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vg3"
                                    CssClass="subbtn" OnClick="btnPrint_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" CssClass="clearbtn"
                                    Text="Cancel" OnClick="btnCancelPurchase_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="HFPurOrderNo" runat="server" />
            <asp:HiddenField ID="HFReqProOrderId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
