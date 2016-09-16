using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;

namespace UI
{
    public partial class MemberUI : System.Web.UI.Page
    {
        MemberDTO memDTO = new MemberDTO();
        MemberBLL memBLL = new MemberBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnSave.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSave, "").ToString());

            if (!Page.IsPostBack)
            {
                SearchPagload();
            }
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            var bb = memBLL.GetMember("", "", "", "", int.Parse(e.CommandArgument.ToString()));
            // Show(e.CommandArgument.ToString());

            HFUID.Value = bb.First().MemberId.ToString();
            txtMemberNo.Text = bb.First().MemberNo;
            txtMemType.Text = bb.First().Type;
            txtMemName.Text = bb.First().FullName;
            txtExService.Text = bb.First().Exservice;
            ddlMemType.SelectedValue = bb.First().MemType;
            // char[] a = { ' ' };
            //   string[] name = bb.First().FullName.Split(a);

            // txtDOB.Text = bb.First().DOB.Value.Date.ToShortDateString();
            txtContact.Text = bb.First().ContactNo;
            //  txtEmail.Text = bb.First().Email;
            //  ddlGender.SelectedValue = bb.First().Gender;
            // txtNationality.Text = bb.First().Nationality;
            //  txtNationalId.Text = bb.First().NationalId;
            btnSave.Text = "Update";

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
        protected void GVPur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVPur.PageIndex = e.NewPageIndex;
            SearchPagload();

        }
        //private void pagingLoal()
        //{
        //    try
        //    {
        //        RptMainHead.DataSource = null;
        //        RptMainHead.DataBind();

        //        PagedDataSource objPds = new PagedDataSource();
        //        objPds.DataSource = memBLL.GetMember("", "", "", ddlSMemType.SelectedValue, 0);
        //        objPds.AllowPaging = true;
        //        objPds.PageSize = 8;
        //        int CurPage;
        //        if (Request.QueryString["Page"] != null)
        //            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        //        else
        //            CurPage = 1;


        //        objPds.CurrentPageIndex = CurPage - 1;
        //        lblCurrentPage.Text = "Page: " + CurPage.ToString();

        //        if (!objPds.IsFirstPage)
        //            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath
        //            + "?Page=" + Convert.ToString(CurPage - 1);

        //        if (!objPds.IsLastPage)
        //            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath
        //            + "?Page=" + Convert.ToString(CurPage + 1);
        //        lnkPrev.Enabled = !objPds.IsFirstPage;
        //        lnkNext.Enabled = !objPds.IsLastPage;
        //        RptMainHead.DataSource = objPds;
        //        RptMainHead.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        Show(ex.Message);
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {


            memDTO.MemberNo = txtMemberNo.Text;
            memDTO.Type = txtMemType.Text;
            memDTO.FullName = txtMemName.Text;
            memDTO.Exservice = txtExService.Text;
            memDTO.ContactNo = txtContact.Text;
            memDTO.MemType = ddlMemType.SelectedValue;
            if (btnSave.Text == "Save")
            {
                if (ddlMemType.SelectedValue.ToLower() != "guest")
                {
                    var checkCount = memBLL.GetMember(txtMemberNo.Text, "", "", "", 0);
                    if (checkCount.Count() > 0)
                    {
                        Show("Member Already Exists!");
                        return;
                    }
                    else
                    {
                        // memDTO.CreatedBy = HttpContext.Current.User.Identity.Name;
                        // memDTO.CreatedDate = DateTime.Now;
                        memBLL.Add(memDTO);
                        Show("Sucessfully Created!");
                        //pagingLoal();
                        SearchPagload();
                        clearCntrol();
                    }
                }
                else
                {
                    memBLL.Add(memDTO);
                    Show("Sucessfully Created!");
                    //pagingLoal();
                    SearchPagload();
                    clearCntrol();
                }
            }
            else
            {
                memDTO.MemberId = Convert.ToInt32(HFUID.Value);

                //var checkUpCount = PBLL.CheckProductCodeExits(int.Parse(ddlCompany.SelectedValue), txtProductName.Text,int.Parse(HFUID.Value));

                //if (checkUpCount.Count()> 0)
                //{
                //    Show("Product Code :" + txtProductName.Text + " already Used By Another Product in this company ");
                //    return;
                //}else{

                memBLL.Edit(memDTO);
                btnSave.Text = "Save";
                Show("Sucessfully Updated!");
                /// pagingLoal();
                clearCntrol();
                SearchPagload();
            }


        }

        private void clearCntrol()
        {
            txtMemberNo.Text = "";

            txtContact.Text = "";
            txtMemType.Text = "";
            txtMemName.Text = "";
            txtExService.Text = "";
            ddlSMemType.SelectedIndex = 0;
            //txtSMemberNo.Text = "";
            //  txtMemberName.Text = "";
            // txtContactNo.Text = "";
            ddlMemType.SelectedIndex = 0;
            //pagingLoal();
            SearchPagload();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
        }
        void SearchPagload()
        {
            string memno, memname, contactno;
            if (txtSMemberNo.Text == "Member No.")
                memno = "";
            else
                memno = txtSMemberNo.Text;
            if (txtMemberName.Text == "Member Name")
                memname = "";
            else
                memname = txtMemberName.Text;
            if (txtContactNo.Text == "Contact No.")
                contactno = "";
            else
                contactno = txtContactNo.Text;


            GVPur.DataSource = memBLL.GetMember(memno, memname, contactno, ddlSMemType.SelectedValue, 0);
            GVPur.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            SearchPagload();
        }


    }
}