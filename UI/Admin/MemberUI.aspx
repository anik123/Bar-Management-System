<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MemberUI.aspx.cs" Inherits="UI.MemberUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="middle">
                <div class="Singlelebel_Child">
                    <asp:Label ID="Label5" runat="server" Text="Member Entry"></asp:Label>
                </div>
            </div>
            <div class="mainheadpage">
                <table style="margin-left: 235px; margin-top: 20px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="SingleLbl">Member No. : </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMemberNo" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="SingleLbl">Member Type : </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMemType" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" CssClass="SingleLbl">Member Name : </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMemName" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" CssClass="SingleLbl">Ex-Service : </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtExService" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" CssClass="SingleLbl">Contact No. : </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContact" runat="server" CssClass="SingleTextbox">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="SingleLbl">Transaction Type:</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMemType" CssClass="SingleDropDownList" runat="server">
                                <asp:ListItem Selected="True">Member</asp:ListItem>
                                <asp:ListItem>Guest</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFUID" runat="server" />
                </table>
            </div>
            <div class="clear">
            </div>
            <div class="mah">
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
                    <asp:Label ID="Label8" runat="server" Text="Member List"></asp:Label>
                </div>
                <asp:TextBox ID="txtSMemberNo" Width="120px" onclick="this.value='';" onblur="if(this.value=='') this.value='Member No.';"
                    Text="Member No." runat="server"></asp:TextBox>
                <asp:TextBox ID="txtMemberName" Width="120px" onclick="this.value='';" onblur="if(this.value=='') this.value='Member Name';"
                    Text="Member Name" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtContactNo" Width="120px" onclick="this.value='';" onblur="if(this.value=='') this.value='Contact No.';"
                    Text="Contact No." runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddlSMemType" Width="120px" runat="server">
                    <asp:ListItem Selected="True">Member</asp:ListItem>
                    <asp:ListItem>Guest</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%-- 
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
                                                Member No.
                                            </td>
                                            <td>
                                                Type
                                            </td>
                                            <td>
                                                Member Name
                                            </td>
                                            <td>
                                                Ex-Service
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="text-align: center;">
                                        <td>
                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("MemberId") %>'
                                                Text="[Show]" CommandName="Show" CausesValidation="false" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("MemberNo") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Type") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("FullName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Exservice") %>' />
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
            --%>
            <div>
                <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                    Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                    CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                    AllowPaging="true" PageSize="8" DataKeyNames="MemberId" OnPageIndexChanging="GVPur_PageIndexChanging">
                    <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" HorizontalAlign="Center" ForeColor="Black" />
                    <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                    <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                        PageButtonCount="8" />
                    <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                        HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnShow" runat="server" OnCommand="LinkButton_Command" CommandArgument='<%# Eval("MemberId") %>'
                                    Text="[show]" CommandName="Show" CausesValidation="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemberNo" HeaderText="Member No" />
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                        <asp:BoundField DataField="Exservice" HeaderText="Ex service" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
