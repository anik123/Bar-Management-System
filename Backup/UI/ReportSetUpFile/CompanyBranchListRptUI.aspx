<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyBranchListRptUI.aspx.cs"
    Inherits="UI.ReportSetUpFile.CompanyBranchListRptUI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="id" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="margin-left: 330px; margin-top: 10px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
                    Width="750px" Font-Names="Verdana" Font-Size="8pt" 
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
                    WaitMessageFont-Size="14pt">
                    <LocalReport ReportPath="ReportSetUpFile\BranchList_CompanyRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="LoadCompanyBrachList" TypeName="BLL.ReportSetUpFilBLL">
                    <SelectParameters>
                        <asp:Parameter Name="proid" Type="Int32" />
                        <asp:Parameter Name="CompName" Type="String" />
                        <asp:Parameter Name="CompMobile" Type="String" />
                        <asp:Parameter Name="CompAdd" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
