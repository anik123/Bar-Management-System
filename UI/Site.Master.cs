using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using System.Web.Security;
using PBLL.Page_ObjectBLL;

namespace UI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        string rolename = "";
        string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string stradmin = "admin";
            //if (stradmin == "admin")
            //{
            //    MenuItem mnuItem = NavigationMenu.FindItem("Admin Panel"); // Find particular item
            //    NavigationMenu.Items.Remove(mnuItem);
            //    //MenuItem mnuItem1 = NavigationMenu.FindItem("Employee Type"); // Find particular item
            //    //NavigationMenu.Items.Remove(mnuItem1);
            //    //Menu1.Width = Unit.Percentage(30);
            //}

            //RoleName();
            //if (!Page.User.IsInRole("Admin"))
            //{
            //    MenuItem item = NavigationMenu.FindItem("/Manager/CentarlUnderStock.aspx");
            //    item.Parent.ChildItems.Remove(item);
            //}
            

            if (!Page.IsPostBack)
            {
                //if (Convert.ToString(Session["username"])!="")
                //{ }
                //else
                //{
                //    Response.Redirect("~LoginUI.aspx");
                //}
               // RoleName();
            }

            

        }

        public void RoleName()
        {
            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL.GetRoleName_By_User(empusername);
            rolename = role.First().RoleName.ToString();
            int roleid = role.First().RoleId;


            var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
            int count = loadPage.Count;

            // int matcheddata = 0;



            if (!Roles.IsUserInRole(rolename))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {

                    for (int i = 0; i < count; i++)
                    {
                        if (menuItem.Text == loadPage[i].PageName.ToString())
                        {
                            adminItem = menuItem;
                        }
                    }
                }
                menuItems.Remove(adminItem);
              
                /*
                foreach (MenuItem item in menuItems) 
                {
                    foreach (MenuItem parent in item.Parent)
                    {
                        foreach (MenuItem child in item.ChildItems) 
                        {

                        }
                    }
                }

                */
            }

            



        }

        protected void myMenu_DataBound(object sender, MenuEventArgs e)
        {
            //if (e.Item.Text == "Admin Panel")
            //{
            //    // disable the item
            //    //e.Item.Enabled = false;

            //    // remove the menu item
            //    NavigationMenu.Items.Remove(e.Item);

            //}
            var bb = PObjRoleBLL.Page_ObjectRole(0, 1, "", "");
            var count = bb.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (MenuItem item in e.Item.ChildItems)
                {
                    if (item.NavigateUrl == bb[i].PageName.ToString())
                        item.Enabled = false;
                }
            }
            //string empusername = HttpContext.Current.User.Identity.Name;

            //var role = LBLL.GetRoleName_By_User(empusername);
            //rolename = role.First().RoleName.ToString();
            //int roleid = role.First().RoleId;


            //var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
            //int count = loadPage.Count;



            //foreach (MenuItem mi in NavigationMenu.Items)
            //{

            //    for (int i = 0; i < count; i++)
            //    {
            //        if (mi.NavigateUrl == loadPage[i].PagePath.ToString())
            //        {
            //            mi.Enabled = true;
            //        }
            //        else
            //        {
            //            mi.Enabled = false;
            //        }
            //    }
            //}


        }

    }
}
