using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using ADTO;

namespace UI.AccSysManagment.Employee
{
    public partial class PasswordChangeUI : System.Web.UI.Page
    {
        EmpBasinInfoBLL EmpBLL = new EmpBasinInfoBLL();
        EmpBasicInfoDTO EmpDTO = new EmpBasicInfoDTO();

        string UserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Password Change";
            }

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserName = HttpContext.Current.User.Identity.Name;
            var data = EmpBLL.LoadEmpBasic(0, "", "", UserName, "");
            if (data.First().Password != txtOldPasswordBox.Text)
            {

                Show(" Your Old Password Not Correct! Insert Again");

                Clear();
                return;
            }

            EmpDTO.EmpId = data.First().EmpId;
            EmpDTO.Password = txtConfirmNewPassword.Text;

            EmpBLL.Edit_Password(EmpDTO);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtConfirmNewPassword.Text = "";
            txtNewpassword.Text = "";
            txtOldPasswordBox.Text = "";
        }
    }

}