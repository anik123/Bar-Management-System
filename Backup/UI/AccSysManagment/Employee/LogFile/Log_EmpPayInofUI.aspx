<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Log_EmpPayInofUI.aspx.cs" Inherits="UI.AccSysManagment.Employee.LogFile.Log_EmpPayInofUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <ajaxtoolkit:TabContainer runat="server" ID="Tabs" Width="100%" ActiveTabIndex="1">
                <ajaxtoolkit:TabPanel runat="server" ID="Panel1" HeaderText="Emp BasicInfo">
                    <ContentTemplate>
                        <div class="LogFilePopUpUpperMain">
                            <div class="LogFilePopUpUpperMain_Left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" CssClass="clabel_Tarun" runat="server" Text="From Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server" Width="180px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                                Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtFromDate">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" ForeColor="Red"
                                                Operator="DataTypeCheck" ControlToValidate="txtFromDate" ErrorMessage="Not Valid">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="LogFilePopUpUpperMain_Right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" CssClass="clabel_Tarun" runat="server" Text="To Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTodate" runat="server" Width="180px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                Format="MM/dd/yyyy" TargetControlID="txtTodate">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:CompareValidator ID="Cv" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                                ControlToValidate="txtTodate" ErrorMessage="Not Valid">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="BtncanCel" runat="server" Text="Cancel" OnClick="BtncanCel_Click" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                                        CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                        GridLines="None" Width="100%" AutoGenerateColumns="false" Height="15px" AllowPaging="True"
                                        DataKeyNames="LogPayEmpInfoId" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        PageSize="15">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="true" Font-Bold="true"
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <Columns>
                                            <asp:BoundField DataField="LogField" HeaderText="Change Entity" />
                                            <asp:BoundField DataField="LogDate" ItemStyle-Width="145px" HeaderText="Edit Date" />
                                            <asp:BoundField DataField="LogBy" ItemStyle-Width="70px" HeaderText="Edit By" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
                <ajaxtoolkit:TabPanel runat="server" ID="Panel2" HeaderText="User Role">
                    <ContentTemplate>
                        <div class="LogFilePopUpUpperMain">
                            <div class="LogFilePopUpUpperMain_Left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" CssClass="clabel_Tarun" runat="server" Text="From Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate_Roll" runat="server" Width="180px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="cal1" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                                TargetControlID="txtFromDate_Roll">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:CompareValidator ID="cv1" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                                ControlToValidate="txtFromDate_Roll" ErrorMessage="Not Valid">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="LogFilePopUpUpperMain_Right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" CssClass="clabel_Tarun" runat="server" Text="To Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTodate_Roll" runat="server" Width="180px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="ca2" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                                TargetControlID="txtTodate_Roll">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:CompareValidator ID="cv2" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                                ControlToValidate="txtTodate_Roll" ErrorMessage="Not Valid">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Button ID="BtnSearchRoll" runat="server" Text="Search" OnClick="BtnSearchRoll_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="BtnSearchRoll_Cancel" runat="server" Text="Cancel" OnClick="BtnSearchRoll_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="White"
                                        CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                        GridLines="None" Width="100%" AutoGenerateColumns="false" Height="15px" AllowPaging="True"
                                        DataKeyNames="LogFilePayUserRoleId" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        PageSize="15">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="true" Font-Bold="true"
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <Columns>
                                            <asp:BoundField DataField="LogField" HeaderText="Change Entity" />
                                            <asp:BoundField DataField="LogDate" ItemStyle-Width="145px" HeaderText="Edit Date" />
                                            <asp:BoundField DataField="LogBy" ItemStyle-Width="70px" HeaderText="Edit By" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxtoolkit:TabPanel>
            </ajaxtoolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
