<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DailySalesUI.aspx.cs" Inherits="UI.Shop.DailySalesUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="PharmPur_Payment_main">
            <asp:Label ID="Label1255" runat="server" Text="Search Inovice" CssClass="Singlelebel_Child"></asp:Label>
                <div class="clear"></div>
                <div class="PharmPur_Payment_left">
                
                <div>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" CssClass="clabel_Location" Text="From Date : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                    Format="MM/dd/yyyy" TargetControlID="txtDateFrom">
                                </ajaxtoolkit:CalendarExtender>
                                
                            </td>
                        </tr>
                    </table>
                    </div>
                </div>
                <div class="PharmPur_Payment_right">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" CssClass="clabel_Location" Text="To Date :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateTo" CssClass="input_textcss" Width="202px" runat="server"></asp:TextBox>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                    Format="MM/dd/yyyy" TargetControlID="txtDateTo">
                                </ajaxtoolkit:CalendarExtender>
                               
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Add_Short" 
                                onclick="btnSearch_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="btnSearchCancel" runat="server" CausesValidation="false" CssClass="Clear_Short"
                                Text="Clear" onclick="btnSearchCancel_Click"  />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Repeater ID="RptMainHead" runat="server">
                                <HeaderTemplate>
                                    <table id="table1" width="100%">
                                        <tr style="background-color: #8FADD9; text-align: center; font-weight: bold;">
                                          
                                            <td>
                                                Options
                                            </td>
                                             <td>
                                                Sales Date
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                       <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("CreateDate") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton_Sale" CommandArgument='<%# Eval("CreateDate") %>'
                                                Text="[View Inovice]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("CreateDate","{0:dd/MM/yyyy}") %>' />
                                        </td>
                                       
                                       
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label1" runat="server" Text=" Member Info..." ForeColor="White"></asp:Label>
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
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="SingleLbl">Sale Date</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSaleDate" ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="txtSaleDate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="SingleLbl">Total Bar Bill</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBarBill" ReadOnly="true" Text="0" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator8" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtTotalSale"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Total Resturent Bill</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRestuarentBill" Text="0"  ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator9" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtRestuarentBill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="SingleLbl">Total Catering Bill</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCateringBill" Text="0"  ReadOnly="true" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator10" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtCateringBill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" CssClass="SingleLbl">Total Bekary Bill</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBekaryBill" Text="0"  ReadOnly="true"  CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator11" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtBekaryBill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" CssClass="SingleLbl">Total Guest Charge</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuestChargeBill" Text="0"  ReadOnly="true"  CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator12" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtGuestChargeBill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Total Sale</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalSale" ReadOnly="true"  CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtTotalSale"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="SingleLbl">(-) Guest Charge</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuestCharge"  CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtGuestCharge"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" CssClass="SingleLbl">(-) Card</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCard" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtCard"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">(-) Restaurent & Catering Bill</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtExtraBill" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtExtraBill"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="SingleLbl">(+) Guest Charge</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGuestChargeplus" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator6" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtGuestChargeplus"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Total Amount</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalAmount" CssClass="SingleDropDownList" runat="server"></asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator7" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="txtTotalAmount"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFPaymentId" runat="server" />
                    <asp:HiddenField ID="HFQuantity" runat="server" />
                </table>
            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="Add_Short" onclick="btnView_Click" 
                                  />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" CausesValidation="false" CssClass="Clear_Short"
                                Text="Clear" onclick="btnSearchCancel_Click"  />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
