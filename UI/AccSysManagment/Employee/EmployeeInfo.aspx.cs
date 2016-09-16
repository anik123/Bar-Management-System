using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using ABLL;
using System.Data;
using System.Globalization;
using System.IO;
using BLL.CompProfile;
using BLL.PBLL;
using DTO.PDTO;
using PBLL.Page_ObjectBLL;
using System.Web.Security;


namespace UI.AccSysManagment.Employee
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        // for log file
        LogPayRollBLL LogBLL = new LogPayRollBLL();
        Log_PayEmpInfoDTO LogDTO = new Log_PayEmpInfoDTO();
        // emp info
        EmpBasicInfoDTO DTO = new EmpBasicInfoDTO();
        EmpBasinInfoBLL EBLL = new EmpBasinInfoBLL();
        EmpSpecialistBLL SBLL = new EmpSpecialistBLL();
        EmpTypeBLL TBLL = new EmpTypeBLL();
        // EmpBasis Info Setup

        // Emp Education Info SetUp
        EmpEducationBLL EduBLL = new EmpEducationBLL();
        EmpEducationDTO EduDTO = new EmpEducationDTO();
        // Emp Education Info SetUp


        // Emp Trining Info Setup
        EmpTrainingBLL TrainBLL = new EmpTrainingBLL();
        EmpTrainingDTO TDTO = new EmpTrainingDTO();
        // Emp Trining Info Setup

        // emp experence info
        ExperienceBLL ExBLL = new ExperienceBLL();
        ExperienceDTO ExDTO = new ExperienceDTO();
        // emp experence info
        // branch load
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();


        public static int Count; //  for image upload
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Employee Profile";

                Tab.ActiveTabIndex = 0;

                // EmpBasis Info Setup
                //  pagingLoal();
                loadDataGVEmpBasic(0, "", "", "", "");
                loadDeptName();
                LoadCountry();
                LoadDesignation();
                lstTitles.Attributes.Add("onclick", "setText(this.options[this.selectedIndex].value);");
                CompanyBranch();

                // pagingLoal_Basic_EDU();
                LaodEmpType_Edu();
                LoadYear_Edu();
                LaodSepecilist_Edu();
                LoadEmpName_Edu();
                loadGVEduInfo(0, 0, "", "", "", "");
                lsteximination.Attributes.Add("onclick", "seteximination(this.options[this.selectedIndex].value);");
                LstEducationBord.Attributes.Add("onclick", "seteducationbord(this.options[this.selectedIndex].value);");
                LstDivision_cgpa.Attributes.Add("onclick", "setdivision_cgpa(this.options[this.selectedIndex].value);");
                // Emp Education Info SetUp



                // Emp Trining Info Setup

                LaodEmpType_Train();
                LaodSepecilist_Train();
                LoadEmpName_Train();
                LoadYear();
                loadGvTrain_EmpBasicInfo(0, "", "", "", "");
                // Emp Trining Info Setup

                // Emp Experience info 
                loadData(0, "", "", "", "");
                // loadDataGvEx(0);
                loadDataGvEx(0, 0, "", "", "", "");
                LaodEmpType_EXp();
                LaodSepecilist_EXp();
                LoadEmpName_EXp();

                // Emp Experience info 
                // Image upload
                GVFILE.Columns[1].Visible = false;
                Count = 0;
            }
            else
            {
                try
                {
                    if (FileUpload1.FileName != "")
                    {
                        if (ViewState["CurrentFileName"] != null)
                        {

                            DataTable dt = (DataTable)ViewState["CurrentFileName"];
                            if (dt.Rows.Count > 0)
                            {
                                string Path_To_Check = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + dt.Rows[0][1]);
                                File.Delete(Path_To_Check);
                                dt.Rows.RemoveAt(0);
                            }

                        }
                        if (GVFILE.Rows.Count != 0)
                        {
                            string imagename = HFImageFileName.Value;
                            string Path_To_Check = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + imagename);
                            File.Delete(Path_To_Check);
                            //  GVFILE.RowDeleted();
                        }

                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        if ((ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".gif") || ext.Equals(".png") || ext.Equals(".bmp")) && FileUpload1.PostedFile.ContentLength <= (1024 * 1000))
                        {
                            string Path_To_Check = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + FileUpload1.FileName);
                            if (!System.IO.File.Exists(Path_To_Check))
                            {
                                FileUpload1.SaveAs(MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/") + FileUpload1.FileName);
                                string filename = FileUpload1.FileName;
                                HFImageFileName.Value = filename;
                                Image1.ImageUrl = "/AccSysManagment/Employee/UploadEmpImage/" + filename;
                                if (ViewState["CurrentFileName"] != null)
                                {

                                    DataTable dt = (DataTable)ViewState["CurrentFileName"];
                                    int count = dt.Rows.Count;
                                    BindGridImage(count);
                                    lblImageMewssage.Visible = false;

                                }
                                else
                                {
                                    lblImageMewssage.Visible = false;
                                    BindGridImage(1);
                                }

                            }
                            else
                            {
                                lblImageMewssage.Visible = true;
                                lblImageMewssage.Text = "File already Exist";

                            }
                        }
                        else
                        {
                            lblImageMewssage.Visible = true;
                            lblImageMewssage.Font.Size = 8;
                            lblImageMewssage.Text = "Ivalid Formate Or File Size Is More Than 100 kb";

                        }
                    }

                }
                catch (Exception ex)
                {
                    //Show(ex.Message);
                }
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
        // load branch
        private void CompanyBranch()
        {

            var query = BrPrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query;
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Bank Name", "0"));

        }

        public void LinkButton1_Click_Image(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentFileName"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentFileName"];
                if (dt.Rows.Count > 0)
                {
                    string Path_To_Check = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + dt.Rows[rowID][1]);
                    File.Delete(Path_To_Check);
                    dt.Rows.RemoveAt(rowID);
                }

                ViewState["CurrentFileName"] = dt;
                GVFILE.DataSource = dt;
                GVFILE.DataBind();
            }

            else
            {
                //this.GVFILE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //  this.dataGridView1.DataSource = bs;
                //  GVFILE..RemoveAt(GVFILE.SelectedRowStyle[0].Index);
                //foreach (GridViewRow row in GVFILE.Rows)
                //{
                //    string Path_To_Check = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + row.Cells[1].Text;
                //    File.Delete(Path_To_Check);

                //}
                //GVFILE.Rows.
            }


            if (GVFILE.Rows.Count <= 0)
            {
                pnlFileName.Visible = false;
                Image1.ImageUrl = "~/Images/Pic002.jpg";
            }
            else
                pnlFileName.Visible = true;

        }
        private void BindGridImage(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("FileNo", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("FilePath", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("FileSize", typeof(String)));

            if (ViewState["CurrentFileName"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentFileName"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                }
                dr = dt.NewRow();
                dr[0] = ++Count;
                dr[1] = FileUpload1.FileName;
                dr[2] = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + FileUpload1.FileName);
                dr[3] = (int)(FileUpload1.PostedFile.ContentLength / 1024) + " Kb";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = ++Count;
                dr[1] = FileUpload1.FileName;
                dr[2] = Server.MapPath(@"~/AccSysManagment/Employee/UploadEmpImage/" + FileUpload1.FileName);
                dr[3] = (int)(FileUpload1.PostedFile.ContentLength / 1024) + " Kb";
                dt.Rows.Add(dr);

            }
            if (ViewState["CurrentFileName"] != null)
            {
                GVFILE.DataSource = (DataTable)ViewState["CurrentFileName"];
                GVFILE.DataBind();

            }
            else
            {
                GVFILE.DataSource = dt;
                GVFILE.DataBind();
            }
            if (GVFILE.Rows.Count > 0)
                pnlFileName.Visible = true;
            ViewState["CurrentFileName"] = dt;

        }




        // end of image upload



        // Emp Trining Info Setup

        protected void RbtTriningInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RbtTriningInfo.SelectedItem.ToString() == "New Entry")
            {
                PnlTringSearch_newEntry.Visible = true;
                PnlEmpSearch_trining_update.Visible = false;
                loadGvTrain_EmpBasicInfo(0, "", "", "", "");
                btnTrainAdd.Text = "ADD";
                PnlTriningRpt.Visible = false;

            }

            else
            {
                PnlTringSearch_newEntry.Visible = false;
                PnlEmpSearch_trining_update.Visible = true;
                loadGvTrain_EmpBasicInfo(0, "", "", "", "");
            }

        }

        private void LaodEmpType_Train()
        {
            var query = TBLL.GetEmpType(0);
            ddlTring_EmpType.DataSource = query;
            ddlTring_EmpType.DataTextField = "TypeName";
            ddlTring_EmpType.DataValueField = "EmpTypeId";
            ddlTring_EmpType.DataBind();
            ddlTring_EmpType.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }

        private void LaodSepecilist_Train()
        {
            var query = EBLL.GetSpcialistSearchAllpage(Convert.ToInt32(ddlTring_EmpType.SelectedValue));
            ddlTring_Spcilist.DataSource = query;
            ddlTring_Spcilist.DataTextField = "Specialist";
            ddlTring_Spcilist.DataValueField = "EmpSpecilistId";
            ddlTring_Spcilist.DataBind();
            ddlTring_Spcilist.Items.Insert(0, new ListItem("Select Specialist", "0"));
        }
        private void LoadEmpName_Train()
        {
            var query = EduBLL.LoadEmpName_Train(Convert.ToInt32(ddlTring_Spcilist.SelectedValue));
            ddlTrin_EmpName.DataSource = query;
            ddlTrin_EmpName.DataTextField = "EmpName";
            ddlTrin_EmpName.DataValueField = "EmpId";
            ddlTrin_EmpName.DataBind();
            ddlTrin_EmpName.Items.Insert(0, new ListItem("Select Emp Name", "0"));
        }

        private void loadAllOtherEmpInfo_Train()
        {

            var query = EduBLL.GetALLOtherInfo(Convert.ToInt32(ddlTring_EmpType.Text.ToString()), Convert.ToInt32(ddlTring_Spcilist.Text.ToString()), Convert.ToInt32(ddlTrin_EmpName.Text.ToString()));
            TxtTrianShow_EmpType.Text = query.FirstOrDefault().EmptypeName.ToString();
            TxtTrianShow_Spcilist.Text = query.FirstOrDefault().SpecilistName.ToString();
            TxtTrianShow_EmpName.Text = query.FirstOrDefault().EmpName.ToString();
            TxtTrianShow_Mobile.Text = query.FirstOrDefault().Mobile1.ToString();

        }

        private void LoadYear()
        {
            ddltrainingYear.DataSource = GetYearInfo();
            ddltrainingYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }

        public List<string> GetYearInfo()
        {
            List<string> list = new List<string>();
            int year = DateTime.Today.Year;

            int index = 0;

            while (index < 154)
            {
                this.ddltrainingYear.Items.Add(year.ToString());
                ddltrainingYear.DataBind();

                year--;


                if (year <= 0)
                {

                    year++;
                }
                index++;

            }
            return list;
        }



        protected void ddlTring_EmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaodSepecilist_Train();
        }

        protected void ddlTring_Spcilist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpName_Train();
        }

        protected void ddlTrin_EmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAllOtherEmpInfo_Train();
        }


        //protected void ChkBoxPassword_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ChkBoxPassword.Checked != true)
        //    {
        //        txtPassWord.TextMode = TextBoxMode.SingleLine;
        //    }
        //    else
        //    {
        //        txtPassWord.TextMode = TextBoxMode.Password;
        //    }
        //}

        private void loadGvTrain_EmpBasicInfo(int empid, string empname, string moblie, string username, string SurName)
        {
            EBLL.LoadEmpBasic_Tarining(0, "", "", "", "");
            var data = EBLL.LoadEmpBasic_Tarining(empid, empname, moblie, username, SurName);
            GvTrain_EmpBasic.DataSource = data;
            GvTrain_EmpBasic.DataBind();
        }

        protected void GvTrain_EmpBasic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTrain_EmpBasic.PageIndex = e.NewPageIndex;
            loadGvTrain_EmpBasicInfo(0, "", "", "", "");
        }


        private void LoadGvTrainInfo(int empid, int trinId, string Deptname, string pname, string designation, string mobile)
        {
            //   TrainBLL.LoadEmpTrainingInfo_modified(0, 0, "", "", "", "");
            var data = TrainBLL.LoadEmpTrainingInfo_modified(empid, trinId, Deptname, pname, designation, mobile);
            GvTrainInfo.DataSource = data;
            GvTrainInfo.DataBind();
        }

        protected void GvTrainInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTrainInfo.PageIndex = e.NewPageIndex;
            LoadGvTrainInfo(0, 0, "", "", "", "");
        }
        protected void btnTrainAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (txtTrainingName.Text.ToString() == dt.Rows[i][0].ToString())
                    {
                        return;
                    }

                }
                BindGrid_train(count);

            }
            else
            {
                BindGrid_train(1);
                pnlTraingSave.Visible = true;
            }
        }

        protected void LinkButtonTraining_Click(object sender, EventArgs e)
        {

            LinkButton lb_tairn = (LinkButton)sender;

            GridViewRow gvRow = (GridViewRow)lb_tairn.NamingContainer;

            int rowID_tarin = gvRow.RowIndex;

            if (ViewState["CurrentData"] != null)
            {

                DataTable dt1 = (DataTable)ViewState["CurrentData"];

                if (dt1.Rows.Count > 0)
                {
                    dt1.Rows.RemoveAt(rowID_tarin);
                }
                ViewState["CurrentData"] = dt1;
                int count = dt1.Rows.Count;

                for (int i = 0; i < count; i++)
                {

                }
                if (count == 0)
                {
                    pnlEduSave.Visible = false;
                }
                GridView2.DataSource = dt1;
                GridView2.DataBind();

            }
        }

        private void BindGrid_train(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("TrainingName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TopicsCovered", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Duration", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("InstituteName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Location", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TrainingYear", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TrainId", typeof(String)));
            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();

                    }
                }
                dr = dt.NewRow();
                dr[0] = txtTrainingName.Text;
                dr[1] = txtTopicsCovered.Text;
                dr[2] = txtDuration.Text;
                dr[3] = txttrinInstituteName.Text;
                dr[4] = txtLocation.Text;
                dr[5] = ddltrainingYear.SelectedItem.ToString();
                dr[6] = hftrain_update.Value;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txtTrainingName.Text;
                dr[1] = txtTopicsCovered.Text;
                dr[2] = txtDuration.Text;
                dr[3] = txttrinInstituteName.Text;
                dr[4] = txtLocation.Text;
                dr[5] = ddltrainingYear.SelectedItem.ToString();
                dr[6] = hftrain_update.Value;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentData"] != null)
            {
                GridView2.DataSource = (DataTable)ViewState["CurrentData"];
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            ViewState["CurrentData"] = dt;
            clearCntrol_Traing_basicInfo();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentData"] != null)
            {
                GridView2.DataSource = (DataTable)ViewState["CurrentData"];
                GridView2.DataBind();
            }
            GridView2.DataBind();
        }




        protected void btnTrainSave_Click(object sender, EventArgs e)
        {

            if (btnTrainSave.Text == "Save")
            {
                TDTO.CreateDate = System.DateTime.Now;
                TDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                if (btnTrainAdd.Text == "ADD")
                {
                    //load  status flag
                    List<EmpBasicInfoDTO> PP = new List<EmpBasicInfoDTO>();
                    PP = EBLL.GetEmp_trining_Status_Flag(Convert.ToInt32(ddlTring_EmpType.Text.ToString()), Convert.ToInt32(ddlTring_Spcilist.Text.ToString()), Convert.ToInt32(ddlTrin_EmpName.Text.ToString()));
                    DTO.EmpId = Convert.ToInt32(PP.First().EmpId.ToString());
                    DTO.TariningStatus = "2";
                    EBLL.Edit_Status_flag_training(DTO);
                    // change   status flag
                    TDTO.EmpId = Convert.ToInt32(ddlTrin_EmpName.SelectedValue.ToString());
                }
                else
                {
                    TDTO.EmpId = Convert.ToInt32(HTrian_EmpID.Value);
                }

                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;


                for (int i = 0; i < count; i++)
                {
                    TDTO.TrainingName = Convert.ToString(dt.Rows[i][0]);
                    TDTO.TopicsCovered = Convert.ToString(dt.Rows[i][1]);
                    TDTO.Duration = Convert.ToString(dt.Rows[i][2]);
                    TDTO.InstituteName = Convert.ToString(dt.Rows[i][3]);
                    TDTO.Location = Convert.ToString(dt.Rows[i][4]);
                    TDTO.TrainingYear = Convert.ToString(dt.Rows[i][5]);

                    TrainBLL.Add(TDTO);
                    PnlTriningRpt.Visible = false;
                    pnlTraingSave.Visible = false;
                    btnTrainAdd.Text = "ADD";
                }
            }


            else
            {
                TDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                TDTO.UpdateDate = System.DateTime.Now;
                TDTO.EmpId = Convert.ToInt32(HTrian_EmpID.Value);  //problem
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count1 = dt.Rows.Count;


                for (int i = 0; i < count1; i++)
                {

                    TDTO.TrainingId = Convert.ToInt32(dt.Rows[i][6]);
                    TDTO.TrainingName = Convert.ToString(dt.Rows[i][0]);
                    TDTO.TopicsCovered = Convert.ToString(dt.Rows[i][1]);
                    TDTO.Duration = Convert.ToString(dt.Rows[i][2]);
                    TDTO.InstituteName = Convert.ToString(dt.Rows[i][3]);
                    TDTO.Location = Convert.ToString(dt.Rows[i][4]);
                    TDTO.TrainingYear = Convert.ToString(dt.Rows[i][5]);

                    TrainBLL.Edit(TDTO);
                    btnTrainAdd.Text = "ADD";
                    PnlTriningRpt.Visible = false;

                    //  pagingLoal_EduInfo();
                }
                //pnlEduSave.Visible = false;
            }


            clearCntrol_Training();
        }


        protected void txtTraing_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // (int empid, string empname, string moblie, string username, string SurName)
                var bb = EBLL.LoadEmpBasic_Tarining(0, txtTrin_EmpName.Text.ToString(), txtTrin_Mobile.Text.ToString(), txtTrin_UserName.Text.ToString(), txtTrin_SurName.Text.ToString());
                GvTrain_EmpBasic.DataSource = bb;
                GvTrain_EmpBasic.DataBind();
            }
            catch { }
        }

        protected void LinkButton_Command_trining(object sender, CommandEventArgs e)
        {
            List<EmpBasicInfoDTO> bb = new List<EmpBasicInfoDTO>();

            bb = EBLL.LoadEmpBasic_Tarining(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "", "");
            HTrian_EmpID.Value = bb.First().EmpId.ToString();
            txtTrin_Mobile.Text = bb.First().Mobile1.ToString();
            txtTrin_EmpName.Text = bb.First().EmpName.ToString();
            txtTrin_SurName.Text = bb.First().SurName.ToString();
            txtTrin_UserName.Text = bb.First().UserName.ToString();
            PnlTriningRpt.Visible = true;
            //  PnlSearch_NewEntry.Visible = false;

            List<EmpTrainingDTO> pp = new List<EmpTrainingDTO>();
            pp = TrainBLL.LoadEmpTrainingInfo_modified(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "", "", "");
            GvTrainInfo.DataSource = pp;
            GvTrainInfo.DataBind();
            btnTrainAdd.Text = "Update";
        }


        protected void LinkButton_Command_Train_update(object sender, CommandEventArgs e)
        {
            List<EmpTrainingDTO> bb_update_tarin = new List<EmpTrainingDTO>();
            bb_update_tarin = TrainBLL.ShowtrianingInfo_ForUpdate(Convert.ToInt32(e.CommandArgument.ToString()));
            hftrain_update.Value = bb_update_tarin.Single().TrainingId.ToString();
            HTrian_EmpID.Value = bb_update_tarin.First().EmpId.ToString();
            txttrinInstituteName.Text = bb_update_tarin.First().InstituteName.ToString();
            txtTrainingName.Text = bb_update_tarin.First().TrainingName.ToString();
            txtTopicsCovered.Text = bb_update_tarin.First().TopicsCovered.ToString();
            txtDuration.Text = bb_update_tarin.First().Duration.ToString();
            txtLocation.Text = bb_update_tarin.First().Location.ToString();
            ddltrainingYear.SelectedValue = bb_update_tarin.First().TrainingYear.ToString();
            btnTrainAdd.Text = "Update";
            btnTrainSave.Text = "Update";
        }
        private void clearCntrol_Training()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GridView2.DataSource = dt;
            GridView2.DataBind();
            txtTopicsCovered.Text = "";
            txtTrainingName.Text = "";
            TxtTrianShow_EmpName.Text = "";
            TxtTrianShow_EmpType.Text = "";
            TxtTrianShow_Mobile.Text = "";
            TxtTrianShow_Spcilist.Text = "";
            txtTrin_EmpName.Text = "";
            txtTrin_Mobile.Text = "";
            txtTrin_SurName.Text = "";
            txtTrin_UserName.Text = "";
            txttrinInstituteName.Text = "";
            txtDuration.Text = "";
            txtLocation.Text = "";
            LoadYear();
            LaodSepecilist_Train();
            LaodEmpType_Train();
            LoadEmpName_Train();
            pnlTraingSave.Visible = false;

            btnTrainSave.Text = "Save";
        }


        private void clearCntrol_Traing_basicInfo()
        {
            txttrinInstituteName.Text = "";
            txtDuration.Text = "";
            txtLocation.Text = "";
            txtTopicsCovered.Text = "";
            txtTrainingName.Text = "";
            ddltrainingYear.SelectedValue = "0";

        }

        protected void btnTrainClear_Click(object sender, EventArgs e)
        {
            clearCntrol_Training();
            loadGvTrain_EmpBasicInfo(0, "", "", "", "");
            PnlTriningRpt.Visible = false;
            btnTrainAdd.Text = "ADD";

        }



        protected void btnTrainCancel_Click(object sender, EventArgs e)
        {
            clearCntrol_Training();
            PnlTriningRpt.Visible = false;
        }
        // Emp Trining Info Setup


        // Emp Education Info SetUp
        protected void RbtnSelectMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RbtnSelectMode.SelectedItem.ToString() == "New Entry")
            {
                PnlEdusearch_Rpt.Visible = true;
                PnlSearchEmp_update.Visible = false;
                loadGVEdu_EmpBasic(0, "", "", "", "");
                btnEduAdd.Text = "ADD";
                PnleduInfo_rpt.Visible = false;

            }

            else
            {
                PnlEdusearch_Rpt.Visible = false;
                PnlSearchEmp_update.Visible = true;
                loadGVEdu_EmpBasic(0, "", "", "", "");
            }

        }

        private void LaodEmpType_Edu()
        {
            var query = TBLL.GetEmpType(0);
            ddlEdu_EmpType.DataSource = query;
            ddlEdu_EmpType.DataTextField = "TypeName";
            ddlEdu_EmpType.DataValueField = "EmpTypeId";
            ddlEdu_EmpType.DataBind();
            ddlEdu_EmpType.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }

        private void LaodSepecilist_Edu()
        {
            var query = EBLL.GetSpcialistSearchAllpage(Convert.ToInt32(ddlEdu_EmpType.SelectedValue));
            ddlEdu_Spcilist.DataSource = query;
            ddlEdu_Spcilist.DataTextField = "Specialist";
            ddlEdu_Spcilist.DataValueField = "EmpSpecilistId";
            ddlEdu_Spcilist.DataBind();
            ddlEdu_Spcilist.Items.Insert(0, new ListItem("Select Specialist", "0"));
        }
        private void LoadEmpName_Edu()
        {
            var query = EduBLL.LoadEmpName_Edu(Convert.ToInt32(ddlEdu_Spcilist.SelectedValue));
            ddlEdu_EmpName.DataSource = query;
            ddlEdu_EmpName.DataTextField = "EmpName";
            ddlEdu_EmpName.DataValueField = "EmpId";
            ddlEdu_EmpName.DataBind();
            ddlEdu_EmpName.Items.Insert(0, new ListItem("Select Emp Name", "0"));
        }

        private void loadAllOtherEmpInfo()
        {

            var query = EduBLL.GetALLOtherInfo(Convert.ToInt32(ddlEdu_EmpType.Text.ToString()), Convert.ToInt32(ddlEdu_Spcilist.Text.ToString()), Convert.ToInt32(ddlEdu_EmpName.Text.ToString()));
            txtEdu_Show_EmpType.Text = query.FirstOrDefault().EmptypeName.ToString();
            txtEdu_Show_Specilist.Text = query.FirstOrDefault().SpecilistName.ToString();
            txtEdu_Show_EmpName.Text = query.FirstOrDefault().EmpName.ToString();
            txtEdu_Show_Mobile.Text = query.FirstOrDefault().Mobile1.ToString();

        }
        protected void ddlEdu_EmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaodSepecilist_Edu();

        }

        protected void ddlEdu_Spcilist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpName_Edu();
        }

        protected void ddlEdu_EmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAllOtherEmpInfo();
        }


        private void LoadYear_Edu()
        {
            ddlPasssingYear.DataSource = GetYearInfo_Edu();
            ddlPasssingYear.Items.Insert(0, new ListItem("Select year", "0"));
        }

        public List<string> GetYearInfo_Edu()
        {
            List<string> list = new List<string>();
            int year = DateTime.Today.Year;

            int index = 0;

            while (index < 154)
            {
                this.ddlPasssingYear.Items.Add(year.ToString());
                ddlPasssingYear.DataBind();

                year--;


                if (year <= 0)
                {

                    year++;
                }
                index++;

            }
            return list;
        }


        protected void txtEduS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  (int empid, string empname, string moblie, string username, string otizmstatus)

                var bb = EBLL.LoadEmpBasic_EduPage(0, txtEduS_EmpName.Text.ToString(), txtEduS_Mobile.Text.ToString(), txtEduS_SurName.Text.ToString(), txtEduS_SurName.Text.ToString());
                GVEdu_EmpBasic.DataSource = bb;
                GVEdu_EmpBasic.DataBind();
            }
            catch { }
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<EmpBasicInfoDTO> bb = new List<EmpBasicInfoDTO>();

            bb = EBLL.LoadEmpBasic_EduPage(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "", "");
            HEdu_EmpID.Value = bb.First().EmpId.ToString();
            txtEduS_Mobile.Text = bb.First().Mobile1.ToString();
            txtEduS_EmpName.Text = bb.First().EmpName.ToString();
            txtEduS_SurName.Text = bb.First().SurName.ToString();
            txtEduS_UserName.Text = bb.First().UserName.ToString();
            PnleduInfo_rpt.Visible = true;

            List<EmpEducationDTO> pp = new List<EmpEducationDTO>();
            pp = EduBLL.LoadEmpEducationInfo_modified(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "", "", "");
            GvEduInfo.DataSource = pp;
            GvEduInfo.DataBind();
            btnEduAdd.Text = "Update";
        }


        private void loadGVEdu_EmpBasic(int empid, string empname, string moblie, string username, string SurName)
        {
            //  EBLL.LoadEmpBasic_EduPage(0, "", "", "", "");
            var data = EBLL.LoadEmpBasic_EduPage(empid, empname, moblie, username, SurName);
            GVEdu_EmpBasic.DataSource = data;
            GVEdu_EmpBasic.DataBind();
        }

        protected void GVEdu_EmpBasic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVEdu_EmpBasic.PageIndex = e.NewPageIndex;
            loadGVEdu_EmpBasic(0, "", "", "", "");
        }



        private void loadGVEduInfo(int empid, int eduid, string Deptname, string pname, string designation, string mobile)
        {
            // EduBLL.LoadEmpEducationInfo_modified(empid, eduid, Deptname, pname, designation, mobile);
            var data = EduBLL.LoadEmpEducationInfo_modified(empid, eduid, Deptname, pname, designation, mobile);
            GvEduInfo.DataSource = data;
            GvEduInfo.DataBind();
        }

        protected void GvEduInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEduInfo.PageIndex = e.NewPageIndex;
            loadGVEduInfo(0, 0, "", "", "", "");
        }

        protected void btnEduAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    //  if (ddlEximination.SelectedItem.ToString() == dt.Rows[i][0].ToString())
                    if (txtexmination.Text.ToString() == dt.Rows[i][0].ToString())
                    {
                        return;
                    }

                }
                BindGrid(count);
                //pnlEduSave.Visible = true;
            }
            else
            {
                BindGrid(1);
                pnlEduSave.Visible = true;

            }

        }

        protected void LinkButtonEdu_Click(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;

            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            int rowID = gvRow.RowIndex;

            if (ViewState["CurrentData"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentData"];

                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }
                ViewState["CurrentData"] = dt;
                //double sum = 0;
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {

                }
                if (count == 0)
                {
                    pnlEduSave.Visible = false;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Eximination", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Board", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("InstituteName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ResultType", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Division", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PassingYear", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("EduId", typeof(String)));
            // dt.Columns.Add(new System.Data.DataColumn("EmpId", typeof(String)));
            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();

                    }
                }

                dr = dt.NewRow();
                dr[0] = txtexmination.Text;
                dr[1] = txteducationbord.Text;
                dr[2] = txtInstitute.Text;
                dr[3] = ddlResulttype.SelectedItem.ToString();
                dr[4] = txtDivision_cgpa.Text;
                dr[5] = ddlPasssingYear.SelectedItem.ToString();
                dr[6] = hfEID_update.Value;
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txtexmination.Text;
                dr[1] = txteducationbord.Text;
                dr[2] = txtInstitute.Text;
                dr[3] = ddlResulttype.SelectedItem.ToString();
                dr[4] = txtDivision_cgpa.Text;
                dr[5] = ddlPasssingYear.SelectedItem.ToString();
                dr[6] = hfEID_update.Value;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentData"] != null)
            {
                GridView1.DataSource = (DataTable)ViewState["CurrentData"];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            ViewState["CurrentData"] = dt;
            clearCntrol_Education_basicInfo();
        }

        private void clearCntrol_Education_basicInfo()
        {
            txteducationbord.Text = "";
            txtexmination.Text = "";
            txtInstitute.Text = "";
            txtDivision_cgpa.Text = "";
            //ddlResulttype.SelectedItem.Text = "Division";
            ddlPasssingYear.SelectedValue = "0";

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentData"] != null)
            {
                GridView1.DataSource = (DataTable)ViewState["CurrentData"];
                GridView1.DataBind();
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnEduSave_Click(object sender, EventArgs e)
        {

            if (btnEduSave.Text == "Save")
            {

                EduDTO.CreateDate = System.DateTime.Now;
                EduDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                if (btnEduAdd.Text == "ADD")
                {
                    //load  status flag
                    List<EmpBasicInfoDTO> PP = new List<EmpBasicInfoDTO>();
                    // PP = EBLL.GetEmp_All_Status_Flag(Convert.ToInt32(ddlEdu_EmpName.Text.ToString()));
                    PP = EBLL.GetEmp_All_Status_Flag(Convert.ToInt32(ddlEdu_EmpType.Text.ToString()), Convert.ToInt32(ddlEdu_Spcilist.Text.ToString()), Convert.ToInt32(ddlEdu_EmpName.Text.ToString()));
                    DTO.EmpId = Convert.ToInt32(PP.First().EmpId.ToString());
                    DTO.EduStatus = "2";
                    EBLL.Edit_Status_flag(DTO);
                    // change   status flag
                    EduDTO.EmpId = Convert.ToInt32(ddlEdu_EmpName.SelectedValue.ToString());
                }
                else
                {
                    EduDTO.EmpId = Convert.ToInt32(HEdu_EmpID.Value);
                }

                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;


                for (int i = 0; i < count; i++)
                {


                    EduDTO.Eximination = Convert.ToString(dt.Rows[i][0]);
                    EduDTO.Board = Convert.ToString(dt.Rows[i][1]);
                    EduDTO.InstituteName = Convert.ToString(dt.Rows[i][2]);
                    EduDTO.ResultType = Convert.ToString(dt.Rows[i][3]);
                    EduDTO.Division = Convert.ToString(dt.Rows[i][4]);
                    EduDTO.PassingYear = Convert.ToString(dt.Rows[i][5]);

                    EduBLL.Add(EduDTO);
                    PnleduInfo_rpt.Visible = false;
                    pnlEduSave.Visible = false;
                    // pagingLoal_Basic_EDU();
                    btnEduAdd.Text = "ADD";
                }
            }


            else
            {
                if (hfEID_update.Value == "")
                {
                    txtEduS_EmpName.Focus();
                }
                EduDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                EduDTO.Updatedate = System.DateTime.Now;
                EduDTO.EmpId = Convert.ToInt32(heId.Value);
                DataTable dt1 = (DataTable)ViewState["CurrentData"];
                int count1 = dt1.Rows.Count;


                for (int i = 0; i < count1; i++)
                {

                    EduDTO.EduId = Convert.ToInt32(dt1.Rows[i][6]);
                    EduDTO.Eximination = Convert.ToString(dt1.Rows[i][0]);
                    EduDTO.Board = Convert.ToString(dt1.Rows[i][1]);
                    EduDTO.InstituteName = Convert.ToString(dt1.Rows[i][2]);
                    EduDTO.ResultType = Convert.ToString(dt1.Rows[i][3]);

                    EduDTO.Division = Convert.ToString(dt1.Rows[i][4]);
                    EduDTO.PassingYear = Convert.ToString(dt1.Rows[i][5]);

                    EduBLL.Edit(EduDTO);
                    btnEduAdd.Text = "ADD";
                    PnleduInfo_rpt.Visible = false;

                    loadGVEduInfo(0, 0, "", "", "", "");
                }
                pnlEduSave.Visible = false;
            }


            clearCntrol_edu();
        }



        protected void LinkButton_Command_Edu_update(object sender, CommandEventArgs e)
        {
            List<EmpEducationDTO> bb_update = new List<EmpEducationDTO>();

            bb_update = EduBLL.ShowEducationInfo_ForUpdate(Convert.ToInt32(e.CommandArgument.ToString()));
            hfEID_update.Value = bb_update.Single().EduId.ToString();
            heId.Value = bb_update.First().EmpId.ToString();
            txtInstitute.Text = bb_update.First().InstituteName.ToString();
            txtDivision_cgpa.Text = bb_update.First().Division.ToString();
            txtexmination.Text = bb_update.First().Eximination.ToString();
            txteducationbord.Text = bb_update.First().Board.ToString();
            ddlResulttype.SelectedValue = bb_update.First().ResultType.ToString();
            ddlPasssingYear.SelectedValue = bb_update.First().PassingYear.ToString();
            btnEduAdd.Text = "Update";
            btnEduSave.Text = "Update";
        }


        private void clearCntrol_edu()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            txtEdu_Show_EmpName.Text = "";
            txtEdu_Show_EmpType.Text = "";
            txtEdu_Show_Mobile.Text = "";
            txtEdu_Show_Specilist.Text = "";
            txtDivision_cgpa.Text = "";
            txtInstitute.Text = "";
            txtEmpName.Text = "";
            txtMobile1.Text = "";
            txtInstitute.Text = "";
            txtEduS_EmpName.Text = "";
            txtEduS_Mobile.Text = "";
            txtEduS_SurName.Text = "";
            txtEduS_UserName.Text = "";
            txtEmpNames.Text = "";
            txtMobileS.Text = "";
            LoadYear_Edu();
            LaodSepecilist_Edu();
            LaodEmpType_Edu();
            LoadEmpName_Edu();
            txtexmination.Text = "";
            txteducationbord.Text = "";
            pnlEduSave.Visible = false;

            btnSave.Text = "Save";
        }
        protected void btnEduCancel_Click(object sender, EventArgs e)
        {
            clearCntrol_edu();
            PnleduInfo_rpt.Visible = false;
            btnEduAdd.Text = "ADD";

        }



        protected void btnEduClear_Click(object sender, EventArgs e)
        {
            clearCntrol_edu();
            loadDataGVEmpBasic(0, "", "", "", "");
            PnleduInfo_rpt.Visible = false;
            loadGVEdu_EmpBasic(0, "", "", "", "");

        }

        //// Emp Education Info SetUp

        // EmpBasis Info Setup
        private void LoadCountry()
        {
            ddlNationality.DataSource = GetCountryInfo();
            ddlNationality.DataBind();
            ddlNationality.Items.Insert(0, new ListItem("Select Country Name", "0"));
        }
        public List<string> GetCountryInfo()
        {
            List<string> list = new List<string>();
            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo inforeg = new RegionInfo(info.LCID);
                if (!list.Contains(inforeg.EnglishName))
                {
                    list.Add(inforeg.EnglishName);
                    list.Sort();
                }
            }
            return list;
        }
        private void loadDeptName()
        {
            var query = TBLL.GetEmpType(0);
            ddldeptName.DataSource = query;
            ddldeptName.DataTextField = "TypeName";
            ddldeptName.DataValueField = "EmpTypeId";
            ddldeptName.DataBind();
            ddldeptName.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }
        private void LoadDesignation()
        {
            var query = EBLL.GetSpcialistSearch(Convert.ToInt32(ddldeptName.SelectedValue));
            ddlDesignation.DataSource = query;
            ddlDesignation.DataTextField = "SpecilistName";
            ddlDesignation.DataValueField = "EmpSpecilistId";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Specialist", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text.ToString() == "")
            {
                txtEmpName.Focus();
                return;
            }

            if (txtMobile1.Text.ToString() == "")
            {
                txtMobile1.Focus();
                return;
            }
            if (ddldeptName.SelectedValue == "0")
            {
                ddldeptName.Focus();
                return;
            }
            if (ddlDesignation.SelectedValue == "0")
            {
                ddlDesignation.Focus();
                return;
            }
            if (txtUserName.Text.ToString() == "")
            {
                txtUserName.Focus();
                return;
            }
            if (txtPassWord.Text.ToString() == "")
            {
                txtPassWord.Focus();
                return;
            }
            DTO.BrProId = Convert.ToInt16(ddlBranch.SelectedValue);
            DTO.EmpTypeId = Convert.ToInt32(ddldeptName.SelectedValue.ToString());
            DTO.EmpSpecilistId = Convert.ToInt32(ddlDesignation.SelectedValue.ToString());
            if (txtDOB.Text.ToString() != "")
                DTO.DOB = Convert.ToDateTime(txtDOB.Text);
            DTO.Email = txtEmail.Text.ToString();
            DTO.FatherName = txtFatherName.Text.ToString();
            DTO.Address = txtPresentAdd.Text.ToString();
            //   DTO.EduStatus = "1";
            //  DTO.Image = txtimage.Text.ToString();
            DTO.Email = txtEmail.Text.ToString();
            DTO.JobStatus = RbJobStatus.SelectedItem.ToString();
            DTO.JobType = RbJobType.Text.ToString();
            if (txtjoindate.Text.ToString() != "")
                DTO.JoinDate = Convert.ToDateTime(txtjoindate.Text);
            DTO.Age = txtage.Text.ToString();
            DTO.Merital = rdbMeitalStatus.SelectedItem.ToString();
            DTO.EmpName = txtEmpName.Text.ToString();
            DTO.Mobile1 = txtMobile1.Text.ToString();
            DTO.Mobile2 = txtMobile2.Text.ToString();
            DTO.NationalID = txtNationalIdNumber.Text.ToString();
            DTO.Religion = txtTitle.Text.ToString();
            DTO.Password = txtPassWord.Text.ToString();
            DTO.Nationality = ddlNationality.SelectedValue.ToString();
            DTO.PermanentAdd = txtPermanentAdd.Text.ToString();
            DTO.Phone = txtPhone.Text.ToString();
            DTO.MotherName = txtMotherName.Text.ToString();
            DTO.Gender = rbGenderEdit.SelectedItem.ToString();
            DTO.FamilyContactNum = txtFamilyContact.Text.ToString();
            DTO.OtizmStatus = RbOtizmStatus.SelectedValue.ToString();
            if (RbOtizmStatus.SelectedValue == "Yes")
            {
                lblOtizmType.Visible = true;
                DTO.OtizmType = txtOtizmType.Text.ToString();
            }
            else
            {
            }
            DTO.ImageName = HFImageFileName.Value;
            DTO.UserName = txtUserName.Text.ToString();
            DTO.RefContactNum = txtRefContactNum.Text.ToString();
            DTO.ReferenceBy = txtReferenceBy.Text.ToString();
            DTO.SurName = txtSurName.Text.ToString();
            DTO.CreateDate = System.DateTime.Now;
            DTO.CreateBy = HttpContext.Current.User.Identity.Name;
            DTO.EduStatus = "1";
            DTO.TariningStatus = "1";
            DTO.ExperienceStatus = "1";
            DTO.LocationStatus = "1";
            DTO.SalaryStatus = "1";
            DTO.DiscountStatus = "1";
            if (btnSave.Text == "Insert")
            {
                EBLL.Add(DTO);
                loadDataGVEmpBasic(0, "", "", "", "");
            }
            else
            {
                // start log insert
                string Logfield = "";
                var bb = EBLL.LoadEmpBasic(Convert.ToInt32(heId.Value), "", "", "", "");
                Logfield = "EmpId-" + heId.Value + ";" + " EmpName-" + bb.First().EmpName.ToString() + "#" + txtEmpName.Text + ";" + "Mobile-" + bb.First().Mobile1.ToString() + "#" + txtMobile1.Text + ";" + "UserName-" + bb.First().UserName.ToString() + "#" + txtUserName.Text + ";" + " EmpType-" + bb.First().EmptypeName.ToString() + "#" + ddldeptName.SelectedItem + ";" + "Specilist-" + bb.First().SpecilistName.ToString() + "#" + ddlDesignation.SelectedItem + ";" + "Brach-" + bb.First().BrProName.ToString() + "#" + ddlBranch.SelectedItem + ";";
                LogDTO.LogField = Logfield;
                LogDTO.LogBy = HttpContext.Current.User.Identity.Name;
                LogDTO.LogDate = System.DateTime.Now;
                LogBLL.AddPayEmpBasicInfo_Log(LogDTO);
                // end log insert
                DTO.EmpId = Convert.ToInt32(heId.Value);
                DTO.UpdateDate = System.DateTime.Now;
                DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                EBLL.Edit(DTO);
                btnSave.Text = "Insert";
                loadDataGVEmpBasic(0, "", "", "", "");
            }

            clearCntrol();
        }
        private void clearCntrol()
        {
            pnlFileName.Visible = false;
            Image1.ImageUrl = "~/Images/Pic002.jpg";

            ddlBranch.SelectedValue = "0";
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtFatherName.Text = "";
            txtEmpName.Text = "";
            loadDeptName();
            txtjoindate.Text = "";
            txtSurName.Text = "";
            txtage.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtNationalIdNumber.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtFamilyContact.Text = "";
            txtOtizmType.Text = "";
            txtRefContactNum.Text = "";
            txtReferenceBy.Text = "";
            txtSurName.Text = "";
            txtTitle.Text = "";
            txtUserName.Text = "";
            txtPermanentAdd.Text = "";
            txtPhone.Text = "";
            txtPresentAdd.Text = "";
            txtEmpNames.Text = "";
            txtMobileS.Text = "";
            txtOtizmType.Text = "";
            txtUerNameS.Text = "";
            txtMotherName.Text = "";
            txtOtizmType.Visible = false;
            lblOtizmType.Visible = false;
            ddldeptName.SelectedValue = "0";
            ddlDesignation.SelectedValue = "0";
            rbGenderEdit.SelectedValue = "Male";
            RbOtizmStatus.SelectedValue = "No";
            rdbMeitalStatus.SelectedValue = "UnMarried";
            ddlNationality.SelectedValue = "0";
            btnSave.Text = "Insert";
            txtPassWord.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
            loadDataGVEmpBasic(0, "", "", "", "");
        }

        private void loadDataGVEmpBasic(int empid, string empname, string moblie, string username, string SurName)
        {
            var data = EBLL.LoadEmpBasic(empid, empname, moblie, username, SurName);
            GvEmpBasic.DataSource = data;
            GvEmpBasic.DataBind();
        }

        protected void GvEmpBasic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmpBasic.PageIndex = e.NewPageIndex;
            loadDataGVEmpBasic(0, "", "", "", "");
        }
        protected void LinkButton_Command_Basic(object sender, CommandEventArgs e)
        {
            List<EmpBasicInfoDTO> bb = new List<EmpBasicInfoDTO>();
            bb = EBLL.LoadEmpBasic(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "", "");

            heId.Value = bb.First().EmpId.ToString();

            if (bb.First().DOB.ToString() != "")
                txtDOB.Text = bb.First().DOB.Value.ToShortDateString();//.ToString();
            txtEmail.Text = bb.First().Email.ToString();
            txtFatherName.Text = bb.First().FatherName.ToString();
            txtMotherName.Text = bb.First().MotherName.ToString();
            if (bb.First().JoinDate.ToString() != "")
                txtjoindate.Text = bb.First().JoinDate.Value.ToShortDateString();//.ToString();
            txtEmpName.Text = bb.First().EmpName.ToString();
            txtSurName.Text = bb.First().SurName.ToString();
            txtMobile1.Text = bb.First().Mobile1.ToString();
            txtMobile2.Text = bb.First().Mobile2.ToString();
            txtNationalIdNumber.Text = bb.First().NationalID.ToString();
            txtPermanentAdd.Text = bb.First().PermanentAdd.ToString();
            txtage.Text = bb.First().Age.ToString();
            txtFamilyContact.Text = bb.First().FamilyContactNum.ToString();
            txtRefContactNum.Text = bb.First().RefContactNum.ToString();
            txtReferenceBy.Text = bb.First().ReferenceBy.ToString();
            txtUserName.Text = bb.First().UserName.ToString();
            txtPhone.Text = bb.First().Phone.ToString();
            txtPresentAdd.Text = bb.First().Address.ToString();
            ddlNationality.SelectedValue = bb.First().Nationality.ToString();
            txtPassWord.Text = bb.First().Password.ToString();
            txtTitle.Text = bb.First().Religion.ToString();
            ddldeptName.SelectedValue = bb.First().EmpTypeId.ToString();
            RbJobStatus.SelectedValue = bb.First().JobStatus.ToString();
            RbJobType.SelectedValue = bb.First().JobType.ToString();
            rdbMeitalStatus.SelectedValue = bb.First().Merital.ToString();
            RbOtizmStatus.SelectedValue = bb.First().OtizmStatus.ToString();

            ddlBranch.SelectedValue = bb.First().BrProId.ToString();
            if (RbOtizmStatus.SelectedItem.ToString() == "Yes")
            {
                txtOtizmType.Visible = true;
                lblOtizmType.Visible = true;
                txtOtizmType.Text = bb.First().OtizmType.ToString();
            }
            else
            {
                lblOtizmType.Visible = false;
                txtOtizmType.Visible = false;
            }
            rbGenderEdit.SelectedValue = bb.First().Gender.ToString();
            ddlDesignation.SelectedValue = bb.First().EmpSpecilistId.ToString();

            if (bb.First().FileName.ToString() == "")
            {
                Image1.ImageUrl = "~/Images/Pic002.jpg";
                pnlFileName.Visible = false;
            }
            else
            {
                string filename = bb.First().FileName.ToString();
                Image1.ImageUrl = "/AccSysManagment/Employee/UploadEmpImage/" + filename;

                HFImageFileName.Value = filename;
                pnlFileName.Visible = true;
                var pp1 = EBLL.LoadEmpBasic(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "", "");
                GVFILE.DataSource = pp1;
                GVFILE.DataBind();
            }
            btnSave.Text = "Update";
            //BindGridImage(1);
        }
        protected void ddldeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDesignation();
        }

        protected void txtEmpidS_TextChanged(object sender, EventArgs e)
        {
            EmpSearch();
        }
        public void EmpSearch()
        {
            try
            {
                var bb = EBLL.LoadEmpBasic(0, txtEmpNames.Text.ToString(), txtMobileS.Text.ToString(), txtUerNameS.Text.ToString(), txtSurNameS.Text.ToString());
                GvEmpBasic.DataSource = bb;
                GvEmpBasic.DataBind();
            }
            catch { }
        }
        protected void RbOtizmStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbOtizmStatus.SelectedItem.ToString() == "Yes")
            {
                lblOtizmType.Visible = true;
                txtOtizmType.Visible = true;

            }
            else
            {
                txtOtizmType.Visible = false;
                lblOtizmType.Visible = false;
            }
        }

        // EmpBasis END Info Setup


        // Emp Experience Info Setup

        protected void RbtExperience_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtExperience.SelectedItem.ToString() == "New Entry")
            {
                PnlExSerch_new.Visible = true;
                PnlEx_Update.Visible = false;
                btnExADD.Text = "ADD";
                PnlExperienceInfo.Visible = false;
            }

            else
            {
                PnlExSerch_new.Visible = false;
                PnlEx_Update.Visible = true;
                GridView4.Visible = true;
            }

        }
        private void LaodEmpType_EXp()
        {
            var query = TBLL.GetEmpType(0);
            ddlExEmptype.DataSource = query;
            ddlExEmptype.DataTextField = "TypeName";
            ddlExEmptype.DataValueField = "EmpTypeId";
            ddlExEmptype.DataBind();
            ddlExEmptype.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }

        private void LaodSepecilist_EXp()
        {
            var query = EBLL.GetSpcialistSearchAllpage(Convert.ToInt32(ddlExEmptype.SelectedValue));
            ddlExSpcilist.DataSource = query;
            ddlExSpcilist.DataTextField = "Specialist";
            ddlExSpcilist.DataValueField = "EmpSpecilistId";
            ddlExSpcilist.DataBind();
            ddlExSpcilist.Items.Insert(0, new ListItem("Select Specialist", "0"));
        }
        private void LoadEmpName_EXp()
        {
            var query = ExBLL.LoadEmpName_Experience(Convert.ToInt32(ddlExSpcilist.SelectedValue));
            ddlExEmpName.DataSource = query;
            ddlExEmpName.DataTextField = "EmpName";
            ddlExEmpName.DataValueField = "EmpId";
            ddlExEmpName.DataBind();
            ddlExEmpName.Items.Insert(0, new ListItem("Select Emp Name", "0"));
        }

        private void loadAllOtherEmpInfo_EXp()
        {

            var query = EduBLL.GetALLOtherInfo(Convert.ToInt32(ddlExEmptype.Text.ToString()), Convert.ToInt32(ddlExSpcilist.Text.ToString()), Convert.ToInt32(ddlExEmpName.Text.ToString()));
            txtExShowEmptype.Text = query.FirstOrDefault().EmptypeName.ToString();
            txtExShowSpecilist.Text = query.FirstOrDefault().SpecilistName.ToString();
            txtExShowEmpname.Text = query.FirstOrDefault().EmpName.ToString();
            txtExShowMoblie.Text = query.FirstOrDefault().Mobile1.ToString();

        }


        protected void ddlExEmptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaodSepecilist_EXp();
        }

        protected void ddlExSpcilist_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpName_EXp();
        }

        protected void ddlExEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAllOtherEmpInfo_EXp();
        }

        protected void btnExADD_Click(object sender, EventArgs e)
        {

            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (txtResponsibility.Text.ToString() == dt.Rows[i][4].ToString())
                    {
                        return;

                    }

                }
                BindGrid_Ex(count);
                PnlExSave.Visible = true;
            }
            else
            {
                BindGrid_Ex(1);
                PnlExSave.Visible = true;
            }
        }

        protected void LinkButtonExp_Click(object sender, EventArgs e)
        {

            LinkButton lb_ex = (LinkButton)sender;

            GridViewRow gvRow = (GridViewRow)lb_ex.NamingContainer;

            int rowID_ex = gvRow.RowIndex;

            if (ViewState["CurrentData"] != null)
            {

                DataTable dt1 = (DataTable)ViewState["CurrentData"];

                if (dt1.Rows.Count > 0)
                {
                    dt1.Rows.RemoveAt(rowID_ex);
                }
                ViewState["CurrentData"] = dt1;
                int count = dt1.Rows.Count;

                for (int i = 0; i < count; i++)
                {

                }
                if (count == 0)
                {
                    PnlExSave.Visible = false;
                }
                GridView3.DataSource = dt1;
                GridView3.DataBind();

            }
        }

        private void BindGrid_Ex(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Disignation", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("FromDate", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ToDate", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("OrganizationName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Responsibility", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Year", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("HfExpId", typeof(String)));
            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();

                    }
                }
                dr = dt.NewRow();
                dr[0] = txtDesignation.Text;
                dr[1] = txtFromDate.Text;
                dr[2] = txtToDate.Text;
                dr[3] = txtOrganizationName.Text;
                dr[4] = txtResponsibility.Text;
                dr[5] = txtYear.Text;
                dr[6] = HfExId.Value;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = txtDesignation.Text;
                dr[1] = txtFromDate.Text;
                dr[2] = txtToDate.Text;
                dr[3] = txtOrganizationName.Text;
                dr[4] = txtResponsibility.Text;
                dr[5] = txtYear.Text;
                dr[6] = HfExId.Value;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentData"] != null)
            {
                GridView3.DataSource = (DataTable)ViewState["CurrentData"];
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            ViewState["CurrentData"] = dt;
            clearCntrol_Experance_basicInfo();
        }


        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView3.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentData"] != null)
            {
                GridView3.DataSource = (DataTable)ViewState["CurrentData"];
                GridView3.DataBind();
            }
            GridView3.DataBind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void btnExpSave_Click(object sender, EventArgs e)
        {

            if (btnExpSave.Text == "Save")
            {

                ExDTO.CreateDate = System.DateTime.Now;
                ExDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                if (btnExADD.Text == "ADD")
                {
                    //load  status flag
                    List<EmpBasicInfoDTO> PP = new List<EmpBasicInfoDTO>();
                    // PP = EBLL.GetEmp_All_Status_Flag(Convert.ToInt32(ddlEdu_EmpName.Text.ToString()));
                    PP = EBLL.GetEmp_EXperience_Status_Flag(Convert.ToInt32(ddlExEmptype.Text.ToString()), Convert.ToInt32(ddlExSpcilist.Text.ToString()), Convert.ToInt32(ddlExEmpName.Text.ToString()));
                    DTO.EmpId = Convert.ToInt32(PP.First().EmpId.ToString());
                    DTO.ExperienceStatus = "2";
                    EBLL.Edit_Status_flag_Experience(DTO);
                    // change   status flag
                    ExDTO.EmpId = Convert.ToInt32(ddlExEmpName.SelectedValue.ToString());
                }
                else
                {
                    ExDTO.EmpId = Convert.ToInt32(HfExEmpId.Value);
                }

                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;


                for (int i = 0; i < count; i++)
                {

                    ExDTO.Disignation = Convert.ToString(dt.Rows[i][0]);

                    if (dt.Rows[i][1].ToString() != string.Empty)
                    {
                        ExDTO.FromDate = Convert.ToDateTime(dt.Rows[i][1]);
                    }

                    ExDTO.ToDate = Convert.ToDateTime(dt.Rows[i][2]);
                    ExDTO.OrganizationName = Convert.ToString(dt.Rows[i][3]);
                    ExDTO.Responsibility = Convert.ToString(dt.Rows[i][4]);
                    ExDTO.Year = Convert.ToString(dt.Rows[i][5]);
                    ExBLL.Add(ExDTO);
                    PnlExperienceInfo.Visible = false;
                    PnlExSave.Visible = false;
                    btnExADD.Text = "ADD";
                }
            }


            else
            {

                ExDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                ExDTO.UpdateDate = System.DateTime.Now;
                ExDTO.EmpId = Convert.ToInt32(HfExEmpId.Value);  //problem
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count1 = dt.Rows.Count;


                for (int i = 0; i < count1; i++)
                {


                    ExDTO.ExperienceId = Convert.ToInt32(dt.Rows[i][6]);
                    ExDTO.Disignation = Convert.ToString(dt.Rows[i][0]);
                    ExDTO.FromDate = Convert.ToDateTime(dt.Rows[i][1]);
                    ExDTO.ToDate = Convert.ToDateTime(dt.Rows[i][2]);
                    ExDTO.OrganizationName = Convert.ToString(dt.Rows[i][3]);
                    ExDTO.Responsibility = Convert.ToString(dt.Rows[i][4]);
                    ExDTO.Year = Convert.ToString(dt.Rows[i][5]);

                    ExBLL.Edit(ExDTO);
                    btnExADD.Text = "ADD";
                    PnlExperienceInfo.Visible = false;

                }
            }


            clearCntrol_Experience();
            loadData(0, "", "", "", "");
        }


        private void clearCntrol_Experience()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GridView3.DataSource = dt;
            GridView3.DataBind();
            txtDesignation.Text = "";
            txtFromDate.Text = "";
            txtExSEmpName.Text = "";
            txtExShowEmpname.Text = "";
            txtExShowEmptype.Text = "";
            txtExShowMoblie.Text = "";
            txtExShowSpecilist.Text = "";
            txtExSMobile.Text = "";
            txtExSSurname.Text = "";
            txtToDate.Text = "";
            txtOrganizationName.Text = "";
            txtResponsibility.Text = "";
            txtYear.Text = "";
            LaodSepecilist_EXp();
            LaodEmpType_EXp();
            LoadEmpName_EXp();
            PnlExSave.Visible = false;
            btnExpSave.Text = "Save";
        }



        private void clearCntrol_Experance_basicInfo()
        {
            txtDesignation.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtOrganizationName.Text = "";
            txtResponsibility.Text = "";
            txtYear.Text = "";

        }

        protected void btnExClear_Click(object sender, EventArgs e)
        {
            clearCntrol_Experience();
            //  pagingLoal_Basic_Exp();
            PnlExperienceInfo.Visible = false;
            btnExADD.Text = "ADD";

        }


        protected void btnExCancel_Click(object sender, EventArgs e)
        {
            clearCntrol_Experience();
            PnlExperienceInfo.Visible = false;

        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void LinkButton_Command_Ex_update(object sender, CommandEventArgs e)
        {

            List<EmpBasicInfoDTO> bb = new List<EmpBasicInfoDTO>();
            bb = EBLL.LoadEmpBasic_Experienceinfo(Convert.ToInt32(e.CommandArgument.ToString()), "", "", "", "");
            HfExEmpId.Value = bb.First().EmpId.ToString();
            txtExSEmpName.Text = bb.First().EmpName.ToString();
            txtExSMobile.Text = bb.First().Mobile1.ToString();
            txtExSSurname.Text = bb.First().SurName.ToString();
            txtExSUserName.Text = bb.First().UserName.ToString();
            PnlExperienceInfo.Visible = true;
            List<ExperienceDTO> pp1 = new List<ExperienceDTO>();

            pp1 = ExBLL.LoadEmpExperienceInfo_modified(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "", "", "");
            GVExperenceinfo.DataSource = pp1;
            GVExperenceinfo.DataBind();
            btnExADD.Text = "Update";
        }

        private void loadData(int empid, string empname, string moblie, string username, string SurName)
        {
            var data = EBLL.LoadEmpBasic_Experienceinfo(empid, empname, moblie, username, SurName);
            GridView4.DataSource = data;
            GridView4.DataBind();

        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            loadData(0, "", "", "", "");
        }

        protected void txtEx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // (int empid, string empname, string moblie, string username, string SurName)
                var bb = EBLL.LoadEmpBasic_Experienceinfo(0, txtExSEmpName.Text.ToString(), txtExSMobile.Text.ToString(), txtExSSurname.Text.ToString(), txtExSUserName.Text.ToString());
                GridView4.DataSource = bb;
                GridView4.DataBind();
            }
            catch { }
        }


        protected void GVExperenceinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void LinkbtnExperienceInfo_update(object sender, CommandEventArgs e)
        {
            List<ExperienceDTO> bb_update_Ex = new List<ExperienceDTO>();

            bb_update_Ex = ExBLL.LoadEmpExperienceInfo_new_update(Convert.ToInt32(e.CommandArgument.ToString()));
            HfExId.Value = bb_update_Ex.First().ExperienceId.ToString();
            HfExEmpId.Value = bb_update_Ex.First().EmpId.ToString();
            txtDesignation.Text = bb_update_Ex.First().Disignation.ToString();
            txtFromDate.Text = bb_update_Ex.First().FromDate.ToString();
            txtToDate.Text = bb_update_Ex.First().ToDate.ToString();
            txtOrganizationName.Text = bb_update_Ex.First().OrganizationName.ToString();
            txtResponsibility.Text = bb_update_Ex.First().Responsibility.ToString();
            txtYear.Text = bb_update_Ex.First().Year.ToString();
            btnExADD.Text = "Update";
            btnExpSave.Text = "Update";

        }
        private void loadDataGvEx(int empid, int expid, string Deptname, string pname, string designation, string mobile)
        {
            //(int empid, int expid, string Deptname, string pname, string designation, string mobile)
            var data = ExBLL.LoadEmpExperienceInfo_modified(empid, expid, Deptname, pname, designation, mobile);
            GVExperenceinfo.DataSource = data;
            GVExperenceinfo.DataBind();

        }
        protected void GVExperenceinfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVExperenceinfo.PageIndex = e.NewPageIndex;
            loadDataGvEx(0, 0, "", "", "", "");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            EmpSearch();
        }


    }
}