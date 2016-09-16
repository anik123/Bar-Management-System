using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDTO;
using PBLL.Page_ObjectBLL;
using PBLL;
using ABLL;
using System.Web.Security;


namespace UI.PageObject
{
    public partial class PageObjectRole : System.Web.UI.Page
    {
        PageObjectRoleDTO PObjRoleDTO = new PageObjectRoleDTO();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        PageObjectBLL PObjBLL = new PageObjectBLL();

        RoleBLL RBLL = new RoleBLL();
        LoginBLL LBLL = new LoginBLL();
      

        protected void Page_Load(object sender, EventArgs e)

        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnWSSave.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnWSSave, "").ToString());
            
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Page Role";
                LoadRole();
                BindData();
                LoadPageObjectRole_Gridview();
            }

        }
        public void RoleName()
        {

            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL.GetRoleName_By_User(empusername);
            int roleid = role.First().RoleId;

            var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
            int count = loadPage.Count;

            int matcheddata = 0;
            for (int i = 0; i < count; i++)
            {
                if (HttpContext.Current.Request.Url.AbsolutePath == loadPage[i].PagePath.ToString())
                {
                    matcheddata = matcheddata + 1;
                }
            }
            if (matcheddata == 1)
            {
            }
            else
            {
                FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket("", true, 0);
                string hash1 = FormsAuthentication.Encrypt(ticket1);
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash1);
                cookie1.Expires = DateTime.Now.AddMinutes(0);

                if (ticket1.IsPersistent)
                    cookie1.Expires = ticket1.Expiration;

                Response.Cookies.Add(cookie1);
                Response.Redirect(" LoginUI.aspx");
            }
        }


        private void LoadRole()
        {
            var query = RBLL.LoadRole(0);
            ddlRoleName.DataSource = query;
            ddlRoleName.DataTextField = "RoleName";
            ddlRoleName.DataValueField = "RoleId";
            ddlRoleName.DataBind();
            ddlRoleName.Items.Insert(0, new ListItem("Select Role", "0"));
        }


        protected void btnWSSave_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (TreeNode node in treeviewPageObject.CheckedNodes)
            {

                str = node.Value.ToString();
                //str = node.Selected.ToString();
                // str = node.Text; //+= node.Text + ",";
                PObjRoleDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                PObjRoleDTO.CreateDate = System.DateTime.Now;
                PObjRoleDTO.PageObjectId = Convert.ToInt16(str);
                PObjRoleDTO.RoleId = Convert.ToInt16(ddlRoleName.SelectedValue);

                try
                {
                    PObjRoleBLL.Add(PObjRoleDTO);
                    
                }
                catch
                {

                }

            }
            foreach (TreeNode node in treeviewPageObject.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    if (childnode.Checked != true)
                    {
                        var unchekdata = childnode.Value.ToString();
                        try
                        {
                            PObjRoleBLL.Delete_Data(Convert.ToInt16(unchekdata), Convert.ToInt16(ddlRoleName.SelectedValue));
                        }
                        catch { }
                    }
                }
            }
            Show("Succesfully Created!");
                Clear();
            ConditinalClear();
        }
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        public void ConditinalClear()
        {
            LoadPageObjectRole_Gridview();
            GvPageObjectRole.SelectedIndex = -1;
            btnWSSave.Text = "Save";
        }
             
        public void Clear()
        {
           
            ddlRoleName.SelectedValue = "0";

            foreach (TreeNode node in treeviewPageObject.Nodes)
            {
                foreach (TreeNode childnode in node.ChildNodes)
                {
                    node.Checked = false;
                    childnode.Checked = false;
                }

            }
           
            treeviewPageObject.CollapseAll();//=false;
        }
        protected void btnWSCancel_Click(object sender, EventArgs e)
        {
            ConditinalClear();
            Clear();
           // PObjRoleBLL.Delete_Data(1, 4);
                   
            
        }

        private void BindData()
        {
            List<PageObjectDTO> pagetype = new List<PageObjectDTO>();
            pagetype = PObjBLL.LoadPageObject_PageTypeName();
            PopulateTreeViewControl(pagetype);
        }

        // This method is used to populate the TreeView Control 
        private void PopulateTreeViewControl(List<PageObjectDTO> pagetypeList)
        {
            TreeNode parentNode = null;

            foreach (PageObjectDTO category in pagetypeList)
            {
                parentNode = new TreeNode(category.PageTypeName, category.PageObjectId.ToString());

                List<PageObjectDTO> PageNameList = new List<PageObjectDTO>();
                PageNameList = PObjBLL.LoadPageObject_PageTypeName_PageName(category.PageTypeName);
                foreach (PageObjectDTO PageNamedto in PageNameList)
                {
                    TreeNode childNode = new TreeNode(PageNamedto.PageName, PageNamedto.PageObjectId.ToString());

                    parentNode.ChildNodes.Add(childNode);
                }

                parentNode.Collapse();
                treeviewPageObject.ShowCheckBoxes = TreeNodeTypes.All;
                treeviewPageObject.Nodes.Add(parentNode);
            }
        }

        private void LoadPageObjectRole_Gridview()
        {
            var data = PObjRoleBLL.Page_ObjectRole_Name(0, 0, "", "");
            GvPageObjectRole.DataSource = data;
            GvPageObjectRole.DataBind();
        }

        protected void GvPageObjectRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPageObjectRole.PageIndex = e.NewPageIndex;
            LoadPageObjectRole_Gridview();
        }


        protected void GvPageObjectRole_SelectedIndexChanged(object sender, EventArgs e)
        {

            Clear();
            var bb = PObjRoleBLL.Page_ObjectRole(0, Convert.ToInt32(GvPageObjectRole.DataKeys[GvPageObjectRole.SelectedIndex].Values["RoleId"].ToString()), "", "");


            ddlRoleName.SelectedValue = bb.First().RoleId.ToString();
            int count = bb.Count;

            for (int i = 0; i < count; i++)
            {
                foreach (TreeNode node in treeviewPageObject.Nodes)
                {
                    foreach (TreeNode childnode in node.ChildNodes)
                    {
                        if (childnode.Value.ToString() == bb[i].PageObjectId.ToString())
                        {
                            node.Expand();// = true;
                            childnode.Checked = true;
                        }
                    }
                }
            }
            btnWSSave.Text = "Update";


        }


    }
}