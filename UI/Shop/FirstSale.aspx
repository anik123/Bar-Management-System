<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstSale.aspx.cs" Inherits="UI.Shop.FirstSale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            background: #99B4D1;
            color: White;
            font-weight: bold;
            font-family: @MS UI Gothic;
        }
        td
        {
            border: 1px slategrey liquid;
        }
        .input_textcss
        {
            border: 1px solid #ccc;
            width: 210px;
            font-family: Tahoma;
            text-align: left;
        }
        .btndone
        {
            height: 45px;
            width: 110px; /*  border: 1px solid #ccc;*/ /* Old browsers */
            cursor: pointer;
            background: #b0d4e3;
            font-weight: bold;
            font-size: medium;
            color: White;
            background: #6bba70; /* Old browsers */
            background: -moz-linear-gradient(top, #6bba70 0%, #6bba70 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#6bba70), color-stop(100%,#6bba70)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #6bba70 0%,#6bba70 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #6bba70 0%,#6bba70 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #6bba70 0%,#6bba70 100%); /* IE10+ */
            background: #6bba70; /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#6bba70', endColorstr='#6bba70',GradientType=0 );
            text-align: center;
        }
        .btnclear
        {
            /*font-weight: bold;     background: #666;     color: #FFF;     line-height: 50px;     border: 1px solid #ccc;         cursor: pointer;*/
            height: 45px;
            width: 110px; /*  border: 1px solid #ccc;*/
            cursor: pointer;
            font-weight: bold;
            font-size: medium;
            color: Black; /* Old browsers */
            background: -moz-linear-gradient(top, #b0d4e3 0%, #88bacf 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#b0d4e3), color-stop(100%,#88bacf)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #b0d4e3 0%,#88bacf 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #b0d4e3 0%,#88bacf 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #b0d4e3 0%,#88bacf 100%); /* IE10+ */
            background: linear-gradient(to bottom, #b0d4e3 0%,#88bacf 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#b0d4e3', endColorstr='#88bacf',GradientType=0 ); /* IE6-9 */
            text-align: center;
        }
        .btnclose
        {
            /*font-weight: bold;     background: #666;     color: #FFF;     line-height: 50px;     border: 1px solid #ccc;         cursor: pointer;*/
            height: 45px;
            width: 110px; /*  border: 1px solid #ccc;*/
            cursor: pointer;
            font-weight: bold;
            font-size: medium;
            color: Black; /* Old browsers */
            background: -moz-linear-gradient(top, #C7142D 0%, #C7142D 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#b0d4e3), color-stop(100%,#C7142D)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #C7142D 0%,#C7142D 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #C7142D 0%,#C7142D 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #C7142D 0%,#C7142D 100%); /* IE10+ */
            background: linear-gradient(to bottom, #C7142D 0%,#C7142D 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#C7142D', endColorstr='#C7142D',GradientType=0 ); /* IE6-9 */
            text-align: center;
        }
        .radiobuttonlist
        {
            font: 12px Verdana, sans-serif;
            color: #000; /* non selected color */
        }
        
        .radiobuttonlist input
        {
            width: 0px;
            height: 0px;
        }
        .radiobuttonlist td
        {
            padding-top: 10px;
            text-align: center;
            padding-bottom: 10px;
            background: #5E9EA0;
            cursor: pointer;
        }
        
        .radiobuttonlist td:hover
        {
            padding-top: 10px;
            text-align: center;
            padding-bottom: 10px;
            background: #F7F5E8;
            color: #000000;
        }
        .radiobuttonlist label
        {
            cursor: pointer;
            width: 60px;
            color: #3E3928;
            font-weight: bold;
            font-size: 16px; /* background-color: #5E9EA0; */
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 2px; /*border: 1px solid #AAAAAA;*/
            margin: 0px 5px 0px 0px;
            text-align: center;
            clear: both;
        }
        .Singlelebel_Parent
        {
            width: 100%;
            text-align: center;
        }
        .category_header
        {
            -webkit-box-shadow: #4E707C 0 0 5px;
            background-image: url(/Images/title.png);
            background-position: initial initial;
            background-repeat: initial initial;
            box-shadow: #4E707C 0 0 5px;
            color: #FFFFFF;
            font-family: Tahoma;
            font-size: 14px;
            font-weight: bold;
            height: 40px;
            line-height: 40px;
            margin-bottom: 1px;
            margin-top: 2px;
            padding-left: 20px;
            width: 150px;
            display: inline-block; /*          -webkit-box-shadow:#4E707C 0 0 5px;   background-image:url(http://cs.aiub.edu/public/img/title.png);   background-position:initial initial;   background-repeat:initial initial;   box-shadow:#4E707C 0 0 5px;   color:#FFFFFF;   font-family:Calibri;   height:50px;   line-height:50px;   margin-bottom:10px;   padding-left:20px;   width:230px; */
        }
        .subcategory_header
        {
            -webkit-box-shadow: #4E707C 0 0 5px;
            background-image: url(/Images/title.png);
            background-position: initial initial;
            background-repeat: initial initial;
            box-shadow: #4E707C 0 0 5px;
            color: #FFFFFF;
            font-family: Tahoma;
            font-size: 14px;
            font-weight: bold;
            height: 40px;
            line-height: 40px;
            margin-bottom: 1px;
            margin-top: 2px;
            padding-left: 20px;
            width: 230px;
            display: inline-block; /*          -webkit-box-shadow:#4E707C 0 0 5px;   background-image:url(http://cs.aiub.edu/public/img/title.png);   background-position:initial initial;   background-repeat:initial initial;   box-shadow:#4E707C 0 0 5px;   color:#FFFFFF;   font-family:Calibri;   height:50px;   line-height:50px;   margin-bottom:10px;   padding-left:20px;   width:230px; */
        }
        /*Hover*/
        
        
        /* button */
        
        
        .btndone
        {
            height: 45px;
            width: 110px; /*  border: 1px solid #ccc;*/ /* Old browsers */
            cursor: pointer;
            background: #b0d4e3;
            font-weight: bold;
            font-size: medium;
            color: White;
            background: #6bba70; /* Old browsers */
            background: -moz-linear-gradient(top, #2b7742 0%, #2b7742 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#2b7742), color-stop(100%,#2b7742)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #2b7742 0%,#2b7742 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #2b7742 0%,#2b7742 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #2b7742 0%,#2b7742 100%); /* IE10+ */
            background: #2b7742; /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#2b7742', endColorstr='#2b7742',GradientType=0 );
            text-align: center;
        }
        .btnclear
        {
            /*font-weight: bold;     background: #666;     color: #FFF;     line-height: 50px;     border: 1px solid #ccc;         cursor: pointer;*/
            height: 45px;
            width: 110px; /*  border: 1px solid #ccc;*/
            cursor: pointer;
            font-weight: bold;
            font-size: medium;
            color: White; /* Old browsers */
            background: -moz-linear-gradient(top,#27b1e7 0%, #27b1e7 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#27b1e7), color-stop(100%,#27b1e7)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #27b1e7 0%,#27b1e7 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #27b1e7 0%,#27b1e7 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #27b1e7 0%,#27b1e7 100%); /* IE10+ */
            background: linear-gradient(to bottom, #27b1e7 0%,#27b1e7 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#27b1e7', endColorstr='#27b1e7',GradientType=0 ); /* IE6-9 */
            text-align: center;
        }
        
        /*button*/
        .style1
        {
            width: 134px;
            height: 559px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <table style="width: 990px; height: 600px; border: 1px Black liquid;">
                        <tr>
                            <td style="height: 60px;">
                                <table style="height: 100%; width: 100%; border: 1px slategrey solid;">
                                    <tr>
                                        <td style="text-align: center;border:1px slategrey solid;">
                                            <asp:Label ID="Label11" runat="server" CssClass="clabel_Location" Text="Member No:"></asp:Label>
                                        </td>
                                        <td style="text-align: center;border:1px slategrey solid;">
                                            <asp:Label ID="Label1" runat="server" CssClass="clabel_Location" Text="Member Name:"></asp:Label>
                                        </td>
                                        <td style="border:1px slategrey solid;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;border:1px slategrey solid;">
                                            <asp:TextBox ID="txtActiveMemNo" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="text-align: center;border:1px slategrey solid;">
                                            <asp:TextBox ID="txtActiveMemName" CssClass="input_textcss" Width="200px" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="border:1px slategrey solid;">
                                            <center>
                                                <asp:Button ID="BtnActiveSearch" runat="server" CssClass="btndone" Text="Search"
                                                    CausesValidation="false" OnClick="BtnActiveSearch_Click" />
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="border:1px slategrey solid;">
                                <asp:Button ID="btnViewAll" runat="server" Width="100%" Height="79px" CssClass="btnclear"
                                    Text="View All" CausesValidation="false" OnClick="btnViewAll_Click" />
                            </td>
                            <td rowspan="2" style="border:1px slategrey solid;">
                                <div style="padding-top: 0%; height: 150px;border:1px slategrey solid;">
                                    <table style="border: 1px #000 liquid; width: 100%;">
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label2" runat="server" CssClass="clabel_Location" Text="Member No:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAllMemNo" CssClass="input_textcss" Width="100%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:Label ID="Label3" runat="server" CssClass="clabel_Location" Text="Member Name:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAllMemName" CssClass="input_textcss" Width="100%" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnAllSearch" runat="server" CssClass="btndone" Width="100%" Height="25px"
                                                    Text="Search" CausesValidation="false" OnClick="btnAllSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 100%; height: 150px;">
                                    <asp:Panel ID="Panel1" Visible="true" runat="server">
                                        <div style="padding-top: 30px;border:1px slategrey solid;">
                                            <table style="border: 1px #000 liquid; width: 100%;">
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:Label ID="Label4" runat="server" CssClass="clabel_Location" Text="Guest Name:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtAddGuestName" CssClass="input_textcss" Width="100%" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnAddGuest" runat="server" CssClass="btndone" Width="100%" Height="25px"
                                                            Text="Add" CausesValidation="false" OnClick="btnAddGuest_Click" /><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div style="border: 1px #000 liquid; height: 385px;">
                                    <asp:Button ID="btnExit" runat="server" CssClass="btnclose" Width="100%" Height="25px"
                                        Text="Close" ForeColor="White" CausesValidation="false" 
                                        onclick="btnExit_Click" /><br />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="border:1px slategrey solid;">
                                <div style=" height: 600px; width: 680px; overflow: auto;">
                                    <div style="padding-top: 5px; padding-left: 5px; padding-right: 5px; padding-bottom: 5px;">
                                        <center>
                                            <div style="padding-top: 5px;">
                                                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rbtMember" runat="server" BorderWidth="2"
                                                     Font-Names="Comic Sans MS" ForeColor="Snow" RepeatLayout="Flow"
                                                    RepeatColumns="3" CssClass="radiobuttonlist" OnSelectedIndexChanged="rbtMember_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:RadioButtonList>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </td>
                            <td style="width: 125px;border:1px slategrey solid;">
                                <div>
                                    <div>
                                        <table style="border: 1px black liquid; text-align: center;" class="style1">
                                            <tr>
                                                <td>
                                                    <div style="text-align: center; color: White; font-weight: bold; font-size: 17px;
                                                        padding-bottom: 10px;">
                                                        <label>
                                                            Add :
                                                        </label>
                                                    </div>
                                                    <div>
                                                        <asp:Button ID="btnAddMember" runat="server" CssClass="btndone" Text="Member" CausesValidation="false"
                                                            OnClick="btnAddMember_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 315px;">
                                                    <div style="padding-top: 150px;">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                                            DynamicLayout="true">
                                                            <ProgressTemplate>
                                                                <img src="../Images/loader.gif" alt="" style="height: 43px; width: 52px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="text-align: center; color: White; font-weight: bold; font-size: 17px;
                                                        padding-top: 30px; padding-bottom: 10px;">
                                                        <div>
                                                            Developed By:<br />
                                                        </div>
                                                        <div style="padding-top: 10px;">
                                                            <a href="http://www.carbon51.com">
                                                                <img src="../Images/logo.jpg" style="width: 120px; height: 120px;" /></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
