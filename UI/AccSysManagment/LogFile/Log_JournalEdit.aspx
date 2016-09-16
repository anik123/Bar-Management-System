<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_JournalEdit.aspx.cs"
    Inherits="UI.AccSysManagment.LogFile.Log_JournalEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        //        function okay() {

        //            window.parent.document.getElementById('MainContent_txtBed').value = document.getElementById('txtBedId').value;
        //            // window.parent.document.getElementById('MainContent_txtBedFee').value = document.getElementById('txtBedRate').value;
        //            //   window.parent.document.getElementById('btnOkay').click();
        //            cancel();



        //        }
        function cancel() {
            window.parent.document.getElementById('btnCancel').click();

        }

      
    </script>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Bed Info....
            </div>
            <div class="TitlebarRight" onclick="cancel();">
            </div>
        </div>
        <div class="popup_Body">
            <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </ajaxtoolkit:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="panel_PopupInpatient" runat="server" CssClass="ModalPopup" Width="500">
                        <div class="LogFilePopUpUpperMain">
                            <div class="LogFilePopUpUpperMain_Left">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="From Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server" Width="149px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="txtPatientDOB_CalendarExtender" runat="server"
                                                Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtFromDate">
                                            </ajaxtoolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="LogFilePopUpUpperMain_Right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="To Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTodate" runat="server" Width="149px"></asp:TextBox>
                                             <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                                Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtTodate">
                                            </ajaxtoolkit:CalendarExtender>
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
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                        onclick="btnSearch_Click"  />
                                </td>
                                <td>
                                    <asp:Button ID="BtncanCel" runat="server" Text="Cancel" 
                                        onclick="BtncanCel_Click"  />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                                        CssClass="textbox" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                        GridLines="None" AutoGenerateColumns="false" Height="15px" AllowPaging="True"
                                        Width="480px" DataKeyNames="LogJournalId" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        PageSize="4">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="true" Font-Bold="true"
                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#8FADD9" Font-Bold="True" ForeColor="#E7E7FF" />
                                        <Columns>
                                            <asp:BoundField DataField="LogField" HeaderText="Change Entity" />
                                            <asp:BoundField DataField="LogDate" HeaderText="Edit Date" />
                                            <asp:BoundField DataField="LogBy" HeaderText="Edit By" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="popup_Buttons">
            <%--<input id="btnOkay" value="Done" type="button" runat="server" onclick="okay();" />--%>
            <input id="btnCancel" value="Cancel" type="button" onclick="cancel();" />
        </div>
    </div>
    </form>
</body>
</html>
