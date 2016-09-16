<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductUI.aspx.cs" Inherits="UI.Admin.ProductUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--  for barcode  Model popup --%>
    <script type="text/javascript">
        var launch = false;
        function launchModal() {
            launch = true;
        }
        function pageLoad() {
            if (launch) {
                if (document.getElementById('<%=txtProductBarCode.ClientID%>').value != "") {

                    document.getElementById('<%= ModalPanel.ClientID %>').style.visibility = 'visible';
                    $find("mpebehaviorId").show();
                }
            }
        }
        function cancel() {
            var x;
            var r = confirm("Complete Download Barcode!");
            if (r == true) {
                var mpu = $find('mpebehaviorId');
                mpu.hide();
                document.getElementById('<%=txtProductBarCode.ClientID%>').value = "";
            }
            else {

            }
        }
    </script>
    <%--     for barcode  Model popup--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="middle">
                <div class="Singlelebel_Child">
                    <asp:Label ID="Label5" runat="server" Text="Product Entry"></asp:Label>
                </div>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Category</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" CssClass="SingleDropDownList" runat="server">
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
                            <asp:DropDownList ID="ddlCompany" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator3" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Comp Req" ControlToValidate="ddlCompany"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%-- 
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="SingleLbl">Product Code</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator2" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Product Code Req" ControlToValidate="txtProductName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    --%>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="SingleLbl">Product Purchase Price</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator5" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Price Req" ControlToValidate="txtPurchasePrice"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" CssClass="SingleLbl">Product Bar Sale Price</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalePrice" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator6" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Sale Price Req" ControlToValidate="txtSalePrice"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Product Off Sale Price</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOffSale" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Sale Price Req" ControlToValidate="txtOffSale"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%-- 
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="SingleLbl">Unit</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUnit" CssClass="SingleDropDownList" runat="server">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator1" runat="server"
                                InitialValue="0" CssClass="RequiredFieldcss" ErrorMessage="Unit Req" ControlToValidate="ddlUnit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    --%>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="SingleLbl">Centeral Reorder</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCenterReorderQuantity" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="RequiredFieldValidator4" runat="server"
                                CssClass="RequiredFieldcss" ErrorMessage="Quantity Req" ControlToValidate="txtCenterReorderQuantity"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFUID" runat="server" />
                </table>
            </div>
            <div class="clear">
            </div>
            <div class="BarcodePopupEmp">
                <asp:Panel ID="ModalPanel" Style="visibility: hidden;" runat="server">
                    <iframe id="frameeditexpanse" frameborder="0" src="/Admin/BarCodeEmpPopUp.aspx?ProductId=<%=txtProductBarCode.Text%>"
                        height="310px" width="640px"></iframe>
                    <div class="popup_Buttons">
                        <input id="btnCancelBarCodePopUp" style="background-color: #FFFEB2;" value="Cancel"
                            type="button" onclick="cancel();" />
                    </div>
                </asp:Panel>
                <ajaxtoolkit:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpebehaviorId"
                    TargetControlID="ClientButton" PopupControlID="ModalPanel" DynamicServicePath=""
                    Enabled="True">
                </ajaxtoolkit:ModalPopupExtender>
                <asp:Button ID="ClientButton" runat="server" Style="visibility: hidden;" Text="Launch Modal Popup (Client)" />
            </div>
            <div>
                <table style="width: 100%; margin-top: 30px;">
                    <tr>
                        <td style="width: 400px;">
                            <asp:Button ID="btnSave" runat="server" CssClass="SaveBtn" CausesValidation="true"
                                ValidationGroup="vg1" Text="Save" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="clearBtn" Text="Clear" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Searchbtn" Text="Search" CausesValidation="false"
                                OnClick="BtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
            <div>
                <div class="Singlelebel_Child">
                    <asp:Label ID="Label8" runat="server" Text="Product List"></asp:Label>
                </div>
                <asp:TextBox ID="txtProductBarCode" Width="0px" runat="server"></asp:TextBox>
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
                                                Category
                                            </td>
                                            <td>
                                                Sub Category
                                            </td>
                                            <td>
                                                ProductPurchasePrice
                                            </td>
                                            <td>
                                                ProductOffSalePrice
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("ProductId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("CategoryName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("CompName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ProductPurchasePrice") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductOffSalePrice") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr style="background-color: #8FADD9">
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label1" runat="server" Text=" Product Info..." ForeColor="White"></asp:Label>
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
