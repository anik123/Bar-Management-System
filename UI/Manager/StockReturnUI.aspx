<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StockReturnUI.aspx.cs" Inherits="UI.Manager.StockReturnUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <div class="middle">
         <div class="Singlelebel_Child">
                <asp:Label ID="Label5" runat="server" Text="Product Return"></asp:Label>
            </div>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" AutoPostBack="true" 
                                CssClass="SingleDropDownList" runat="server" 
                                onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RfEmpName" InitialValue="0"
                                runat="server" CssClass="RequiredFieldcss" ErrorMessage="Product Req" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="SingleLbl">Sub Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubCategory" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="ddlSubCategory"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                   
                    
                  
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Unit</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSize" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="ddlSize"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
               
                   
                    <asp:HiddenField ID="HFUID" runat="server" />
                </table>
            </div>
             <div>
                <table style="width: 100%;margin-top:30px;">
                    <tr>
                        <td style="width: 400px;">
                         <asp:Button ID="BtnSearch" runat="server" Visible="false" CssClass="SaveBtn" Text="Search" CausesValidation="false"
                                />
                            
                        </td>
                        <td>
                        <asp:Button ID="btnSave" runat="server"  CssClass="Searchbtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Return" onclick="btnSave_Click"  />
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" 
                                CausesValidation="false" onclick="btnCancel_Click"
                                 />
                           
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="HFBranceId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
