using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;


namespace UI.Admin
{
    public partial class CompanyInfoUI : System.Web.UI.Page
    {
        CompanyInfoDTO DTO = new CompanyInfoDTO();

        CompanyBLL CBLL = new CompanyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Pageload();
            }
        }


        private void Pageload()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = CBLL.SearchComInfo(0, "", "", "");
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

            RptComp.DataSource = objPds;
            RptComp.DataBind();

        }

        private void clearCntrol()
        {
            txtCompName.Text = "";
            TxtCompAddS.Text = "";
            txtCompPermanentAdd.Text = "";
            txtCompPhone.Text = "";
            txtCompMobile1.Text = "";
            txtCompMobile2.Text = "";
            txtCompDes.Text = "";
            txtCompWebsite.Text = "";
            txtCompEmail.Text = "";
            txtContactAdd.Text = "";
            txtCompMobileS.Text = "";
            txtCompNameS.Text = "";
            txtCompIdS.Text = "";
            RbtCompStatus.SelectedIndex = -1;
            btnSave.Text = "Save";
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                List<CompanyInfoDTO> bb = new List<CompanyInfoDTO>();
                bb = CBLL.SearchComInfo(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "");
                HFCompID.Value = bb.First().CompId.ToString();
                txtCompName.Text = bb.First().CompName.ToString();
                txtContactAdd.Text = bb.First().CompPresentAdd.ToString();
                txtCompPhone.Text = bb.First().CompPhone.ToString();
                txtCompMobile1.Text = bb.First().CompMobile1.ToString();
                txtCompMobile2.Text = bb.First().CompMobile2.ToString();
                txtCompEmail.Text = bb.First().CompEmail.ToString();
                txtCompDes.Text = bb.First().CompDes.ToString();
                txtCompPermanentAdd.Text = bb.First().CompPermanantAdd.ToString();
                txtCompWebsite.Text = bb.First().Website.ToString();
                RbtCompStatus.SelectedValue = bb.First().CompStatus.ToString();
                btnSave.Text = "Update";


            }
            catch { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCompName.Text == "")
            {
                txtCompName.Focus();
                return;
            }
            if (txtContactAdd.Text == "")
            {
                txtContactAdd.Focus();
                return;
            }
            if (txtCompMobile1.Text == "")
            {
                txtCompMobile1.Focus();
                return;
            }
            DTO.CompName = txtCompName.Text.ToString();
            DTO.CompPermanantAdd = txtCompPermanentAdd.Text.ToString();
            DTO.CompPresentAdd = txtContactAdd.Text.ToString();
            DTO.Website = txtCompWebsite.Text.ToString();
            DTO.CompPhone = txtCompPhone.Text.ToString();
            DTO.CompMobile1 = txtCompMobile1.Text.ToString();
            DTO.CompMobile2 = txtCompMobile2.Text.ToString();
            DTO.CompEmail = txtCompEmail.Text.ToString();
            DTO.CompDes = txtCompDes.Text.ToString();
            DTO.CompStatus = RbtCompStatus.SelectedValue.ToString();
            //DTO.CreateBy = "Tarun";
            //DTO.CreateDate = System.DateTime.Now;
            if (btnSave.Text == "Save")
            {
                DTO.CreateBy = "tarun";
                DTO.CreateDate = System.DateTime.Now;
                CBLL.Add(DTO);

            }
            else
            {
                DTO.CreateBy = "tarun";
                DTO.CreateDate = System.DateTime.Now;
                DTO.CompId = Convert.ToInt32(HFCompID.Value);
                CBLL.Edit(DTO);
                btnSave.Text = "Save";

            }
            clearCntrol();
            Pageload();

        }


        protected void txtComp_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {
            //  try
            //{
            //int compid = 0;

            //if (txtCompIdS.Text.ToString() != "")
            //{
            //    compid = Convert.ToInt32(txtCompIdS.Text);
            //}
            //else compid = 0;
            //var bb = CBLL.SearchComInfo(compid, txtCompNameS.Text.ToString(), txtCompMobileS.Text.ToString(), TxtCompAddS.Text.ToString());
            //RptComp.DataSource = bb;
            //RptComp.DataBind();

            int compid = 0;

            if (txtCompIdS.Text.ToString() != "")
            {
                compid = Convert.ToInt32(txtCompIdS.Text);
            }
            else compid = 0;

            string CompName;
            if (txtCompNameS.Text.ToString() != "")
            {
                CompName = txtCompNameS.Text.ToString();
            }
            else CompName = "";

            string mob;
            if (txtCompMobileS.Text.ToString() != "")
            {
                mob = txtCompMobileS.Text.ToString();
            }
            else mob = "";
            string add;
            if (TxtCompAddS.Text.ToString() != "")
            {
                add = TxtCompAddS.Text.ToString();

            }
            else
                add = "";
            // var bb = CBLL.SearchComInfo(compid, txtCompNameS.Text.ToString(), txtCompMobileS.Text.ToString(), TxtCompAddS.Text.ToString());

            var bb = CBLL.SearchComInfo(compid, CompName, mob, add);
            RptComp.DataSource = bb;
            RptComp.DataBind();


            // }
            // catch { }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
        }


    }


}