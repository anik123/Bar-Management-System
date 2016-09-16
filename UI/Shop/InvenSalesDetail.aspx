<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InvenSalesDetail.aspx.cs" Inherits="UI.Shop.InvenSalesDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="middle">
                <div class="Singlelebel_Child">
                    <asp:Label ID="Label5" runat="server" Text="Daily Sales Report"></asp:Label>
                </div>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Sales Date :</asp:Label>
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
                </table>
            </div>
            <div>
                <table style="width: 100%; margin-top: 30px;">
                    <tr>
                        <td style="width: 40%;">
                            <asp:Button ID="BtnSearch" runat="server" Visible="false" CssClass="SaveBtn" Text="Search"
                                CausesValidation="false" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="Searchbtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Show" onclick="btnSave_Click"  />
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" 
                                CausesValidation="false" onclick="btnCancel_Click"
                                 />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
