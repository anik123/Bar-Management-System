<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchChallanUI.aspx.cs" Inherits="UI.Manager.BranchChallanUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label14" runat="server" CssClass="Font_header" Text="Search Requisition"></asp:Label>
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
                                            Format="MM/dd/yyyy" TargetControlID="txtDateFrom">
                                        </ajaxtoolkit:CalendarExtender>
                                        <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                            Operator="DataTypeCheck" ControlToValidate="txtDateFrom" ErrorMessage="Not Valid">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateTo" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                            Format="MM/dd/yyyy" TargetControlID="txtDateTo">
                                        </ajaxtoolkit:CalendarExtender>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ForeColor="Red"
                                            Operator="DataTypeCheck" ControlToValidate="txtDateTo" ErrorMessage="Not Valid">
                                        </asp:CompareValidator>
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
                                        <asp:TextBox ID="txtReqisitonNo" CssClass="input_textcss" Width="202px" OnTextChanged="txtSearch"
                                            runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="clabel_Location" Text="Branch :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="input_textcss" Width="200px">
                                        </asp:DropDownList>
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
            </div>
            <asp:Panel ID="pnlRec" runat="server">
                <div class="PharmProPur">
                    <asp:Label ID="Label1" runat="server" CssClass="Font_header" Text="Branch Requisition List"></asp:Label>
                    <asp:GridView ID="GVCOA" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                        Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                        CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                        PageSize="6" DataKeyNames="RequisitionNo" OnPageIndexChanging="GVCOA_PageIndexChanging"
                        AllowPaging="true" OnSelectedIndexChanged="GVCOA_SelectedIndexChanged">
                        <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                            PageButtonCount="6" />
                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                            VerticalAlign="Middle" />
                        <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                        <Columns>
                            <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:CommandField>
                            <asp:BoundField DataField="RequisitionNo" HeaderText="Requisition No" />
                            <asp:BoundField DataField="BrProName" HeaderText="Branch" />
                            <%--  <asp:BoundField DataField="CompName" HeaderText=" Product Company" />--%>
                            <asp:BoundField DataField="RequisitionBy" HeaderText="Requisition By" />
                            <asp:BoundField DataField="RequisitionDate" DataFormatString="{0:dd/MM/yy}" HeaderText="Requisition Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
            <asp:Panel ID="PnlInfoProduct" Visible="false" runat="server">
                <asp:Label ID="Label2" runat="server" CssClass="Font_header" Text="Requisition Product List"></asp:Label>
                <span style="padding-left: 20px;">
                    <asp:Button ID="btnPost" runat="server" Width="122px" CausesValidation="false" Height="22px"
                        Text="Post To Order" OnClick="btnPost_Click" />
                </span>
                <asp:GridView ID="GvUpdate" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    PageSize="10" DataKeyNames="RequisitionNo" OnPageIndexChanging="GvUpdate_PageIndexChanging"
                    AllowPaging="true">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="10" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBINFO_Click" CommandArgument='<%# Eval("RequisitionNo") %>'
                                    Text="[ADD]" CommandName="Show" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product" />
                        <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="CompName" HeaderText="Company " />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity #" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Price" />
                        <asp:BoundField DataField="Priority" HeaderText=" Priority" />
                        <asp:BoundField DataField="PurReqId" HeaderText=" Reqisiton Id" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnlUpdate" runat="server">
                <div>
                    <asp:Label ID="Label7" runat="server" CssClass="Font_header" Text="Product Entry"></asp:Label><br>
                </div>
                <div class="InvenPur_main">
                    <div class="InvenPur_left">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="clabel_Location" Text="Company Name:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCName" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Category:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCateName" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCateName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vg1"
                                        ForeColor="Red" ControlToValidate="ddlCateName" InitialValue="0">Select</asp:RequiredFieldValidator>
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
                                    <asp:Label ID="Label4" runat="server" Text="Unit:" CssClass="clabel_Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input_textcss" Width="202px"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <span class="Mandatory">*</span>
                                    <asp:RequiredFieldValidator ID="rfvu" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                        ControlToValidate="ddlUnit" InitialValue="0">Select</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="InvenPur_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="clabel_Location" Text="Current Status:"></asp:Label>
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
                                    <span class="Mandatory">*</span>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="fte" runat="server" TargetControlID="txtPQuality"
                                        FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                                    <asp:RequiredFieldValidator ID="rv" runat="server" ValidationGroup="vg1" ForeColor="Red"
                                        ControlToValidate="txtPQuality">Empty</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="clabel_Location" Text="Unit Price:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurPrice" runat="server" CssClass="input_textcss" Width="200px"></asp:TextBox>
                                    <ajaxtoolkit:FilteredTextBoxExtender ID="ftse" runat="server" TargetControlID="txtPurPrice"
                                        FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
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
                </div>
            </asp:Panel>
            <div class="clear">
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" CssClass="Add_Short" CausesValidation="true"
                                ValidationGroup="vg1" Text="ADD" OnClick="btnAdd_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Clear" CssClass="Clear_Short" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                AllowPaging="true" PageSize="8" DataKeyNames="ProductId" OnPageIndexChanging="GVPur_PageIndexChanging">
                <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                    PageButtonCount="8" />
                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBPurr_Click" CommandArgument='<%# Eval("ProductId") %>'
                                Text="[Delete]" CommandName="Show" CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                    <asp:BoundField DataField="CompName" HeaderText="Company " />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" />
                    <%--   <asp:BoundField DataField="Quantity" HeaderText="Quantity" />--%>
                    <asp:TemplateField HeaderText="Quantity #">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" Width="80px" Text='<%#Eval("Quantity") %>' runat="server"></asp:TextBox>
                            <ajaxtoolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                TargetControlID="txtQuantity" FilterType="Custom, Numbers" ValidChars="." Enabled="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                    <asp:BoundField DataField="PurReqId" HeaderText="Reqisition Id" />
                    <%--       <asp:BoundField DataField="BrProId" HeaderText="Branch Id" />--%>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlAction" Visible="false" runat="server">
                <asp:Label ID="Label19" runat="server" CssClass="Font_header" Text="Action Panel"></asp:Label>
                <div class="Challan_Pay_main">
                    <div class="Challan_Pay_left">
                        <table style="width: 100%;">
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
                    <div class="Challan_Pay_right">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label110" CssClass="clabel_Tarun" runat="server" Text="Total Payable (Tk)"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPayable" ReadOnly="true" ForeColor="Red" AutoPostBack="true"
                                        CssClass="input_textcss" runat="server" Width="140px" Text="0"></asp:TextBox>
                                    <asp:Button ID="btnTotalAmount" runat="server" Text="Button" OnClick="btnTotalAmount_Click" />
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
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" Text="Save" CausesValidation="false" CssClass="subbtn"
                                OnClick="btnPrint_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelPurchase" runat="server" CausesValidation="false" CssClass="clearbtn"
                                Text="Cancel" OnClick="btnCancelPurchase_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="HFPurReqNo" runat="server" />
            <asp:HiddenField ID="HFReqId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
