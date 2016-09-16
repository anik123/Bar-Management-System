<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RatingOfGoods_BranchWiseRptUI.aspx.cs"
    Inherits="UI.Shop.Report.RatingOfGoods_BranchWiseRptUI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #ReportViewer1_ctl10{
    background:white;
}
#form1
{
    background:gainsboro;
    margin:0px;
    
          padding:0px;
}
body{margin:0px;
          padding:0px;
          }
</style>

</head>
<body>
<center>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div style=" margin-top: 20px;">
                <table >
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Form:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateFrom" CssClass="input_textcss" Width="118px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="cal1" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                TargetControlID="txtDateFrom">
                            </ajaxtoolkit:CalendarExtender>
                            <asp:CompareValidator ID="cvf" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                ControlToValidate="txtDateFrom" ErrorMessage="Not Valid">
                            </asp:CompareValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="To :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTodate" CssClass="input_textcss" Width="118px" runat="server"></asp:TextBox>
                            <ajaxtoolkit:CalendarExtender ID="cal2" runat="server" Enabled="True" Format="MM/dd/yyyy"
                                TargetControlID="txtTodate">
                            </ajaxtoolkit:CalendarExtender>
                            <asp:CompareValidator ID="Cvt" runat="server" Type="Date" ForeColor="Red" Operator="DataTypeCheck"
                                ControlToValidate="txtTodate" ErrorMessage="Not Valid">
                            </asp:CompareValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text=" Product:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Width="65px" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" Width="65px" Text="Clear" OnClick="btnClear_Click" />
                     <%--  <input id="Button1" type="button" value="Print Report" onclick="PrintReport();"/>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="HFBranceId" runat="server" />
            <div style="clear: both;">
            </div>
            <div style=" margin-top: 10px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="650px" Width="600px"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt">
                    <LocalReport ReportPath="Manager\Report\RatingOfGoodsRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="CompanyProfile"
                    TypeName="BLL.ReportSetUpFilBLL"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SalesRating_BranchWise"
                    TypeName="BLL.ReportBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCategory" Name="catid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HFBranceId" Name="brid" Type="Int32" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="FromDate" Type="String" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtTodate" Name="ToDate" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" language="javascript">
        function PrintReport() {
            
            var viewerReference = $find("ReportViewer1");

            var stillonLoadState = viewerReference.get_isLoading();

            if (!stillonLoadState) {
                var reportArea = viewerReference.get_reportAreaContentType();
                if (reportArea == Microsoft.Reporting.WebFormsClient.ReportAreaContent.ReportPage) {
                    $find("ReportViewer1").invokePrintDialog();
                }
            }
        } 
     </script>
     </center>
</body>
</html>
