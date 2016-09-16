<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondSales.aspx.cs" Inherits="UI.Shop.SecondSales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="~/Style/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/../Scripts/jquery-1.4.1.min.js"></script>--%>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <title></title>
    <style type="text/css">
        body
        {
            background: #99B4D1;
        }
        td
        {
            border: 1px #775B9D liquid;
        }
        .radiobuttonlist
        {
            font: 12px Verdana, sans-serif;
            color: #fff; /* non selected color */
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
        .input_textcss
        {
            border: 1px solid #ccc;
            width: 210px;
            font-family: Tahoma;
            text-align: left;
        }
        /*
        .radiobuttonlist td:hover
        {
            padding-top: 10px;
            text-align: center;
            padding-bottom: 10px;
            background: #F7F5E8;
            color: #000000;
        }*/
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
            width: 230px;
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
        
        /*button*/
    </style>
    <script>
      
        $(document).ready(function () {
            $('#rbCategory td').click(function () {
               

                $("#rbCategory td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbCategory').addClass('radiobuttonlist');
            });

             $('#rbtPegSize td').click(function () {
               

                $("#rbtPegSize td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbtPegSize').addClass('radiobuttonlist');
            });
             $('#rbSubCategory td').click(function () {
               

                $("#rbSubCategory td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbSubCategory').addClass('radiobuttonlist');
            });

        });
         
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
         var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function() {
    $('#rbCategory td').click(function () {
               

                $("#rbCategory td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbCategory').addClass('radiobuttonlist');
            });

             $('#rbtPegSize td').click(function () {
               

                $("#rbtPegSize td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbtPegSize').addClass('radiobuttonlist');
            });
             $('#rbSubCategory td').click(function () {
               

                $("#rbSubCategory td").each(function () {
                    $(this).css({
                        "padding-top": "10px",
                        "text-align": "center",
                        "padding-bottom": "10px",
                        "background": "#5E9EA0",
                        "color": "#000000",
                    });
                });
                $(this).css('background-color', 'white');
                $('#rbSubCategory').addClass('radiobuttonlist');
            });
});      

            </script>
            <div>
                <center>
                    <table style="width: 1000px; border: 1px slategrey solid;">
                        <tr>
                            <td rowspan="3" style="border: 1px slategrey solid;">
                                <div style="width: 250px; height: 750px; border: 1px #fff liquid; overflow: auto;color:#fff;">
                                    <div style="padding-top: 1px;">
                                        <center>
                                            <asp:Label ID="lblCtaegoryHeader" runat="server" CssClass="category_header" Text="Category"></asp:Label>
                                            <div style="padding-top: 10px">
                                                <asp:RadioButtonList ID="rbCategory" runat="server" Font-Names="Comic Sans MS" 
                                                    RepeatLayout="Flow" RepeatColumns="1" CssClass="radiobuttonlist" OnSelectedIndexChanged="rbCategory_SelectedIndexChanged"
                                                    AutoPostBack="true" ForeColor="White">
                                                </asp:RadioButtonList>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </td>
                            <td style="border: 1px slategrey solid;">
                                <div>
                                    <div style="width: 296px; height: 160px; border: 1px slategrey solid; overflow: auto;
                                        float: left;">
                                        <div style="padding-top: 5px; padding-left: 5px; padding-right: 5px;">
                                            <center>
                                                <asp:Label ID="Label2" runat="server" CssClass="subcategory_header" Text="Peg Size"></asp:Label>
                                                <div style="padding-top: 5px;">
                                                    <asp:RadioButtonList AutoPostBack="true" RepeatDirection="Horizontal" 
                                                        ID="rbtPegSize" runat="server"
                                                        BorderWidth="2"  Font-Names="Comic Sans MS" ForeColor="Snow"
                                                        RepeatLayout="Flow" RepeatColumns="6" CssClass="radiobuttonlist" 
                                                        onselectedindexchanged="rbtPegSize_SelectedIndexChanged">
                                                    </asp:RadioButtonList>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                    <div style="border: 1px slategrey liquid; float: right; width: 220px; height: 160px;">
                                        <div>
                                            <center>
                                                <table style="height: 160px; width: 220px;">
                                                    <tr>
                                                        <td style="text-align: center; border: 1px slategrey solid;">
                                                            <asp:RadioButtonList ID="rbtSaleType" AutoPostBack="false" runat="server" RepeatDirection="Vertical"
                                                                OnSelectedIndexChanged="rbtSaleType_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True">Bar Sale</asp:ListItem>
                                                                <asp:ListItem>Off Sale</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td style="text-align: center; border: 1px slategrey solid;">
                                                            <div>
                                                                <asp:Button ID="btnAdd" runat="server" CssClass="btndone" Text="Done" OnClick="btnAdd_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center; border: 1px slategrey solid;">
                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                                                DynamicLayout="true">
                                                                <ProgressTemplate>
                                                                    <img src="../Images/loader.gif" alt="" style="height: 43px; width: 52px" />
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                        <td style="text-align: center; border: 1px slategrey solid;">
                                                            <div>
                                                                <asp:Button ID="btnClear" runat="server" ForeColor="White" CssClass="btnclose" Text="Clear"
                                                                    OnClick="btnClear_Click" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td rowspan="2" style="border: 1px slategrey solid;">
                                <div style="overflow: auto; border: 1px #F00 liquid; font-size: 15px; font-weight: bold;
                                    padding: 10px 10px 10px 10px;">
                                    <label>
                                        Raowa No :
                                    </label>
                                    <span style="color: White;">
                                        <label>
                                            <asp:Label runat="server" ID="lblMemNo"></asp:Label></label></span>
                                    <br />
                                    <span style="color: White;">
                                        <asp:Label runat="server" ID="lblMemName"></asp:Label></label>
                                        <asp:HiddenField ID="HFMemberId" runat="server" />
                                    </span>
                                </div>
                                <div style="width: 270px; height: 440px; overflow: auto; border: 1px #F00 liquid;
                                    overflow-y: scroll; padding-top: 0px;">
                                    <div style="padding-top:5px;">
                                        <asp:Panel runat="server" ID="pnlAdd">
                                            <asp:GridView ID="GVPur" runat="server" BackColor="#92B8EF" ForeColor="Snow" BorderColor="#92B8EF"
                                                Font-Size="11px" CssClass="textbox3" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                                CellSpacing="1" GridLines="None" AutoGenerateColumns="False" Height="12px" Width="100%"
                                                AllowPaging="false" PageSize="8" DataKeyNames="ProductId">
                                                <FooterStyle BackColor="#92B8EF" ForeColor="Black" />
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <PagerStyle BackColor="#92B8EF" ForeColor="PeachPuff" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#EEF5FF" Font-Bold="True" ForeColor="Black" Font-Italic="True"
                                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle BackColor="#92B8EF" Font-Italic="False" ForeColor="Snow" />
                                                <Columns>
                                                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                                                    <asp:BoundField DataField="CompName" HeaderText="Sub Category " />
                                                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                                    <%--    <asp:BoundField DataField="Priority" HeaderText="Priority" />--%>
                                                    <asp:BoundField DataField="Quantity" HeaderText="Peg Size" />
                                                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                                                    <asp:BoundField DataField="SaleType" HeaderText="Sale Type" />
                                                    <asp:BoundField DataField="TotalPrize" HeaderText="Total Prize" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnShow" runat="server" OnCommand="LBPurr_Click" CommandArgument='<%# Eval("ProductId") %>'
                                                                Text="[Delete]" CommandName="Show" CausesValidation="false" OnClientClick="javascript:return confirm('Do you really want to \ndelete the item?');" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px slategrey solid;">
                                <div style="width: 100%; height: 300px; border: 1px #fff liquid; overflow: auto;">
                                    <div style="padding-top: 10px; padding-left: 10px; padding-right: 10px; padding-bottom: 10px;">
                                        <center>
                                            <asp:Panel ID="pnlSubcategory" Visible="false" runat="server">
                                                <asp:Label ID="lblCategory" runat="server" CssClass="subcategory_header" Text="Menu Item"></asp:Label>
                                                <div style="padding-top: 10px">
                                                    <asp:RadioButtonList ID="rbSubCategory" RepeatDirection="Horizontal" runat="server"
                                                        BorderWidth="2"  Font-Names="Comic Sans MS" ForeColor="Snow"
                                                        RepeatLayout="Flow" RepeatColumns="1" CssClass="radiobuttonlist">
                                                    </asp:RadioButtonList>
                                                </div>
                                            </asp:Panel>
                                        </center>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px slategrey solid;">
                                <div style="width: 500px; height: 250px; border: 1px #F00 liquid; text-align: center;
                                    padding: 2px 10px 10px 10px;">
                                    <center>
                                        <asp:Label ID="Label3" runat="server" CssClass="subcategory_header" Text="Extra Bill"></asp:Label><br />
                                        <table style="border: 1px #F00 liquid; padding-top: 10px;">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAddGuest" CssClass="input_textcss" Text="200" Width="250px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddGuest" runat="server" Width="170px" CssClass="btnclear" Text="Add Guest Charge"
                                                        OnClick="btnAddGuest_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAddRes" CssClass="input_textcss" Width="250px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddRes" runat="server" Width="170px" CssClass="btnclear" Text="Add Restuarent Bill"
                                                        OnClick="btnAddRes_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAddCate" CssClass="input_textcss" Width="250px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddCate" runat="server" Width="170px" CssClass="btnclear" Text="Add Catering Bill"
                                                        OnClick="btnAddCate_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAddBeka" CssClass="input_textcss" Width="250px" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAddBeka" runat="server" Width="170px" CssClass="btnclear" Text="Add Bekary Bill"
                                                        OnClick="btnAddBeka_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </td>
                            <td style="border: 1px slategrey solid;">
                                <div style="height: 180px;">
                                    <table>
                                        <tr>
                                            <td colspan="2" style="text-align: center; border: 1px slategrey solid;">
                                                <center>
                                                    <asp:RadioButtonList ID="rbPayment" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="rbPayment_SelectedIndexChanged">
                                                        <asp:ListItem id="rdobtnCash" runat="server" Selected="True" Value="Cash" />
                                                        <asp:ListItem id="rdobtnBank" runat="server" Value="Credit Card" />
                                                    </asp:RadioButtonList>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; border: 1px slategrey solid;">
                                                <asp:Label runat="server" ID="lbldemo1" Text="Total Bill" />
                                                <asp:TextBox ID="txtPayable" ReadOnly="true" Width="125px" CssClass="input_textcss"
                                                    runat="server" />
                                            </td>
                                            <td style="text-align: center; border: 1px slategrey solid;">
                                                <asp:Label runat="server" ID="Label1" Text="Amount Paid" />
                                                <asp:TextBox ID="txtPaid" Width="125px" CssClass="input_textcss" Text="0" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; border: 1px slategrey solid;">
                                                <asp:Button ID="btnPreview" runat="server" ForeColor="White" CssClass="btnclear"
                                                    Text="Preview" OnClick="btnPreview_Click" />
                                            </td>
                                            <td style="text-align: center; border: 1px slategrey solid;">
                                                <asp:Button ID="btnSave" runat="server" CssClass="btndone" Text="Save" OnClick="btnSave_Click1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="border: 1px slategrey solid;">
                                                <asp:Button ID="btnNew" Width="130px" runat="server" ForeColor="White" CssClass="btnclose"
                                                    Text="New User" OnClick="btnNew_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
            <asp:HiddenField ID="HFBranceId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
