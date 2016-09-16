using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.CompProfile;
using DTO.BrProfile;

namespace UI.CompProfile
{
    public partial class BranchProfileInfoUI : System.Web.UI.Page
    {

        BranchProfileDTO DTO = new BranchProfileDTO();
        BranchProfileBLL BBLL = new BranchProfileBLL();
        CompProfileInfoBLL CBLL = new CompProfileInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pageload();
                GetCompProfileName();
            }
        }

        private void GetCompProfileName()
        {

            var query = CBLL.LoadCompProfileInfo(0);
            ddlCompProfileName.DataSource = query;
            ddlCompProfileName.DataTextField = "CompProName";
            ddlCompProfileName.DataValueField = "CompProId";
            ddlCompProfileName.DataBind();
            //ddlCompProfileName.Items.Insert(0, new ListItem("Select Bank Name", "0"));

        }
        private void Pageload()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = BBLL.LoadBrProfileInfo(0, "", "", "");
            objPds.AllowPaging = true;
            objPds.PageSize = 4;
            int CurPage;
            if (Request.QueryString["Page"] != null)
                CurPage = Convert.ToInt32(Request.QueryString["Page"]);
            else
                CurPage = 1;

            objPds.CurrentPageIndex = CurPage - 1;
            lblCurrentPage.Text = "Page: " + CurPage.ToString();

            if (!objPds.IsFirstPage)
                lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath
                + "?Page=" + Convert.ToString(CurPage - 1);

            if (!objPds.IsLastPage)
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath
                + "?Page=" + Convert.ToString(CurPage + 1);

            RptBr.DataSource = objPds;
            RptBr.DataBind();
        }

        private void clearCntrol()
        {
            TxtBrAddS.Text = "";
            txtBrDes.Text = "";
            txtBrEmail.Text = "";
            txtBrIdS.Text = "";
            txtBrMobile1.Text = "";
            txtBrMobile1.Text = "";
            txtBrMobile2.Text = "";
            txtBrMobileS.Text = "";
            txtBrName.Text = "";
            txtBrNameS.Text = "";
            txtBrPhone.Text = "";
            txtBrWebsite.Text = "";
            txtContactAdd.Text = "";
            btnSave.Text = "Save";
            Pageload();
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {

            try
            {

                var bb = BBLL.LoadBrProfileInfo(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "");
                HFBrID.Value = bb.First().BrProId.ToString();
                txtBrDes.Text = bb.First().BrDescription.ToString();
                txtBrEmail.Text = bb.First().BrEmail.ToString();
                txtBrMobile1.Text = bb.First().BrMobile1.ToString();
                txtBrMobile2.Text = bb.First().BrMobile2.ToString();
                txtBrName.Text = bb.First().BrProName.ToString();
                txtContactAdd.Text = bb.First().BrAddress.ToString();
                txtBrPhone.Text = bb.First().BrPhone.ToString();
                txtBrWebsite.Text = bb.First().BrWebsite.ToString();
                ddlCompProfileName.SelectedValue = bb.First().CompProId.ToString();
                btnSave.Text = "Update";
            }
            catch { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DTO.BrAddress = txtContactAdd.Text.ToString();
            DTO.BrDescription = txtBrDes.Text.ToString();
            DTO.BrEmail = txtBrEmail.Text.ToString();
            DTO.BrMobile1 = txtBrMobile1.Text.ToString();
            DTO.BrMobile2 = txtBrMobile2.Text.ToString();
            DTO.BrPhone = txtBrPhone.Text.ToString();
            DTO.BrProName = txtBrName.Text.ToString();
            DTO.BrWebsite = txtBrWebsite.Text.ToString();
            DTO.CompProId = Convert.ToInt16(ddlCompProfileName.SelectedValue);

            if (btnSave.Text == "Save")
            {
                DTO.CreateBy = "tarun";
                DTO.CreateDate = System.DateTime.Now;
                BBLL.Add(DTO);
            }
            else
            {
                DTO.UpdateBy = "tarun";
                DTO.UpdateDate = System.DateTime.Now;
                DTO.BrProId = Convert.ToInt16(HFBrID.Value);
                BBLL.Edit(DTO);
                btnSave.Text = "Save";
            }
            clearCntrol();
            Pageload();

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

        protected void txtBr_TextChanged(object sender, EventArgs e)
        {

            Search();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {
            if (txtBrMobileS.Text == "" && txtBrIdS.Text == "" && TxtBrAddS.Text == "" && txtBrNameS.Text == "")
            {
                Show(" Plz Search By valid Data");
            }
            try
            {

                int compid = 0;

                if (txtBrIdS.Text.ToString() != "")
                {
                    compid = Convert.ToInt32(txtBrIdS.Text);
                }
                else compid = 0;

                string CompName;
                if (txtBrName.Text.ToString() != "")
                {
                    CompName = txtBrName.Text.ToString();
                }
                else CompName = "";

                string mob;
                if (txtBrMobileS.Text.ToString() != "")
                {
                    mob = txtBrMobileS.Text.ToString();
                }
                else mob = "";
                string add;
                if (TxtBrAddS.Text.ToString() != "")
                {
                    add = TxtBrAddS.Text.ToString();

                }
                else
                    add = "";

                var bb = BBLL.LoadBrProfileInfo(compid, CompName, mob, add);
                RptBr.DataSource = bb;
                RptBr.DataBind();


            }
            catch { }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
        }

    }
}