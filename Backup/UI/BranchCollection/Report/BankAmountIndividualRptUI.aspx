<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankAmountIndividualRptUI.aspx.cs"
    Inherits="UI.BranchCollection.Report.BankAmountIndividualRptUI" %>

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
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="clear: both; margin: 10px 0px 0px 360px;">
                <asp:Label ID="Label1" runat="server" Text="Bank:"></asp:Label>
                <asp:DropDownList ID="ddlBankName" runat="server" Width="120px">
                </asp:DropDownList>
                <asp:Label ID="Label9" runat="server">Account Type: </asp:Label>
                <asp:DropDownList ID="ddlAccountType" runat="server" Width="120px">
                </asp:DropDownList>
                <asp:Button ID="btnChearch" runat="server" Width="60px" CausesValidation="false"
                    Text="Search" OnClick="btnChearch_Click" />
                <asp:Button ID="btnClear" runat="server" Width="60px" CausesValidation="false" Text="Clear"
                    OnClick="btnClear_Click" />
            </div>
            <div style="clear: both; margin: 10px 0px 0px 320px;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="650px"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt">
                    <LocalReport ReportPath="BranchCollection\Report\BankAmountIndividualRpt.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="BankAmountIndividual"
                    TypeName="BLL.CompProfile.PayRollReprotBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBankName" Name="bankid" Type="Int16" />
                    </SelectParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlAccountType" Name="accounttypeid" Type="int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
