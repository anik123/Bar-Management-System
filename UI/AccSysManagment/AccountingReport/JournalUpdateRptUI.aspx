<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalUpdateRptUI.aspx.cs" Inherits="UI.AccountingReport.JournalUpdateRptUI" %>

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
    <asp:HiddenField ID="HFID" runat="server" />
    <div style=" margin-top: 10px;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="637px" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="928px">
            <LocalReport ReportPath="AccSysManagment\AccountingReport\JouranalUpdateRpt.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="JournalReport_UpdateJournalPage" TypeName="ABLL.ReportBLL">
             <SelectParameters>
                <asp:ControlParameter ControlID="HFID" Name="TransectionNo" Type="Int32" />
            </SelectParameters>
           <%-- <SelectParameters>
                <asp:Parameter Name="jounalid" Type="Int32" />
            </SelectParameters>--%>
        </asp:ObjectDataSource>
    </div>
    </form>
    </center>
</body>
</html>
