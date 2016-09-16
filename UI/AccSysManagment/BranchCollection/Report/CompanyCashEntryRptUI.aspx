<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyCashEntryRptUI.aspx.cs"
    Inherits="UI.BranchCollection.Report.CompanyCashEntryRptUI" %>

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
    <div style="clear: both; margin: 10px 0px 0px 0px;">
        <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label>
        <asp:DropDownList ID="ddltrainingYear" runat="server" Height="22px" Width="100px"
            CssClass="input_textcss">
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Month"></asp:Label>
        <asp:DropDownList ID="ddlMonthName" runat="server" Width="202px" CssClass="input_textcss"
            Height="22px">
        </asp:DropDownList>
        <asp:Button ID="btnChearch" runat="server" CausesValidation="false" Width="80px"
           Text="Search" CssClass="input_text" OnClick="btnChearch_Click" />
        <asp:Button ID="btnClear" runat="server" CausesValidation="false"  Width="80px"
            CssClass="subbtn" Text="Clear" OnClick="btnClear_Click" />
    </div>
    <div style="clear: both; margin: 10px 0px 0px 0px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="10pt"
            Height="650px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
            WaitMessageFont-Size="12pt" Width="720px">
            <LocalReport ReportPath="AccSysManagment\BranchCollection\Report\CompanyCashRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="CashEntryOfCompany"
            TypeName="BLL.CompProfile.PayRollReprotBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlMonthName" Name="month" Type="String" />
            </SelectParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddltrainingYear" Name="year" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
    </form>
    </center>
</body>
</html>
