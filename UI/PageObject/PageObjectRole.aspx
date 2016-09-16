<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PageObjectRole.aspx.cs" Inherits="UI.PageObject.PageObjectRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
                {
                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                    {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }

        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;

            if (parentNodeTable) {
                var checkUncheckSwitch;

                if (check) //checkbox checked
                {
                    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    if (isAllSiblingsChecked)
                        checkUncheckSwitch = true;
                    else
                        return; //do not need to check parent if any(one or more) child not checked
                }
                else //checkbox unchecked
                {
                    checkUncheckSwitch = false;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (!prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }

        function postBackByObject() {
            var o = window.event.srcElement;
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                __doPostBack("", "");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="middle">
                <div class="Singlelebel_Child">
                    <asp:Label ID="Ll2224" runat="server" Text="Page Object Role Assign"></asp:Label>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="PageObject">
                <table style="width: 100%; padding-top: 10px;">
                    <tr>
                        <td style="width: 212px">
                        </td>
                        <td valign="top">
                            <asp:Label ID="Label2" runat="server" CssClass="SingleLbl">Role Name:</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRoleName" runat="server" CssClass="SingleTextbox">
                            </asp:DropDownList>
                            <span class="Mandatory">*</span>
                            <asp:RequiredFieldValidator ValidationGroup="vg1" ID="rfv2" runat="server" CssClass="RequiredField_CSS"
                                ErrorMessage="Role Is Req" InitialValue="0" ControlToValidate="ddlRoleName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 212px">
                        </td>
                        <td valign="top">
                            <asp:Label ID="Label4" runat="server" CssClass="SingleLbl">Page Access:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Panel ID="Panel1" ScrollBars="Both" Height="240px" Width="288px" runat="server">
                                <asp:TreeView ID="treeviewPageObject" runat="server" ShowCheckBoxes="All" ExpandDepth="0"
                                    AfterClientCheck="CheckChildNodes();" PopulateNodesFromClient="true" ShowLines="true"
                                    ShowExpandCollapse="true" onclick="OnTreeClick(event)">
                                </asp:TreeView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HFObjId" runat="server" />
                </table>
            </div>
            <div class=" ActionButton_div">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnWSSave" runat="server" CssClass="subbtn" ValidationGroup="vg1"
                                CausesValidation="true" Text="Save" OnClick="btnWSSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnWSCancel" runat="server" CssClass="clearbtn" Text="Cancel" CausesValidation="False"
                                OnClick="btnWSCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 20px;">
            </div>
            <asp:Panel ID="PnlGridView" class="GridView" runat="server">
                <table class="tblwithbdr">
                    <tr>
                        <td>
                            <div class="Singlelebel_Child">
                                <asp:Label ID="Label1" runat="server" Text="Page Object Role Assign Record List"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvPageObjectRole" runat="server" Width="100%" Height="35px" Font-Size="11px"
                                BorderStyle="None" CellPadding="3" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                AllowPaging="True" DataKeyNames="RoleId" OnPageIndexChanging="GvPageObjectRole_PageIndexChanging"
                                PageSize="10" OnSelectedIndexChanged="GvPageObjectRole_SelectedIndexChanged">
                                <FooterStyle CssClass="tblfooter" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerSettings FirstPageText="Pre" Mode="NextPreviousFirstLast" NextPageText="Next"
                                    PageButtonCount="10" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#EEF5FF" ForeColor="Black" Font-Italic="True" HorizontalAlign="Center"
                                    VerticalAlign="Middle" />
                                <HeaderStyle CssClass="tblheader" />
                                <Columns>
                                    <asp:CommandField HeaderText="Select" ShowHeader="True" ItemStyle-CssClass="tblrowbgodd"
                                        ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:CommandField>
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgevn" DataField="RoleName" HeaderText=" Role Name" />
                                    <%-- <asp:BoundField ItemStyle-CssClass="tblrowbgodd" DataField="PageTypeName" HeaderText="Page Type" />
                                    <asp:BoundField ItemStyle-CssClass="tblrowbgevn" DataField="PageName" HeaderText="Page Name" />
                                    --%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
