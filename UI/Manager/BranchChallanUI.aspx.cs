using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using DTO;
using System.Data;
using System.Collections;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class BranchChallanUI : System.Web.UI.Page
    {
        CompanyBLL compBLL = new CompanyBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();

        InvenCentralPurOrderBLL PurOrBLL = new InvenCentralPurOrderBLL();
        InvenCentralPurOrderDTO PurOrDTO = new InvenCentralPurOrderDTO();


        InvenPerRequisitionBLL ReqBLL = new InvenPerRequisitionBLL();
        InvenPerRequisitionDto ReqDTO = new InvenPerRequisitionDto();
        // store table
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();


        InvenCentralChallenBLL ChalBLL = new InvenCentralChallenBLL();
        InvenCentralChallanInfoDTO ChalInfoDTO = new InvenCentralChallanInfoDTO();
        InvenCentralChallanDtlDTO ChalDtlDTO = new InvenCentralChallanDtlDTO();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Brach Challen";
                Branch();

                LoadListRequisitonNo();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
                Unit_productEntryPnl();
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
        private void Branch()
        {

            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));

        }

        protected void txtSearch(object sender, EventArgs e)
        {

            SearchReq();

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
        private void SearchReq()
        {
            if (txtDateTo.Text == "" && txtDateFrom.Text == "" && ddlBranch.SelectedValue == "0" && txtReqisitonNo.Text == "")
            {
                Show(" Plz Insert Data For Search");
                return;

            }
            int reqno = 0;
            if (txtReqisitonNo.Text.ToString() != "")
            {
                reqno = Convert.ToInt32(txtReqisitonNo.Text);
            }
            else reqno = 0;
            var search = ReqBLL.GetRequisition_PurOrderpage(txtDateFrom.Text, txtDateTo.Text, reqno, Convert.ToInt32(ddlBranch.SelectedValue));
            if (search.Count == 0)
            {
                Show(" No data Found !");
                return;
            }
            GVCOA.DataSource = search;
            GVCOA.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchReq();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            Search_Clear();
            LoadListRequisitonNo();
        }
        public void Search_Clear()
        {
            ddlBranch.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtReqisitonNo.Text = "";
            GVCOA.SelectedIndex = -1;

        }

        public void LoadListRequisitonNo()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                ArrayList list = new ArrayList();
                dt.Columns.Add(new System.Data.DataColumn("RequisitionNo", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("RequisitionBy", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("RequisitionDate", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("BrProName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("ReqPurOrderId", typeof(String)));
                int reqno = 0;
                if (txtReqisitonNo.Text.ToString() != "")
                {
                    reqno = Convert.ToInt32(txtReqisitonNo.Text);
                }
                else reqno = 0;
                //   var data = PBLL.GetData(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt32(ddlCName_S.SelectedValue), Convert.ToInt32(ddlMed_S.SelectedValue));
                var data = ReqBLL.GetRequisition_PurOrderpage(txtDateFrom.Text, txtDateTo.Text, reqno, Convert.ToInt32(ddlBranch.SelectedValue));
                for (int i = 0; i < data.Count; i++)
                {
                    dr = dt.NewRow();

                    if (list.IndexOf(Convert.ToInt32(data[i].RequisitionNo.ToString())) == -1)
                    {
                        int Recno = Convert.ToInt32(data[i].RequisitionNo.ToString());
                        var data1 = ReqBLL.RequsiitonWiseProdctInfoLoad(Recno);
                        int flag = 0;
                        for (int j = 0; j < data1.Count; j++)
                        {
                            if (data1[j].PurReqStatus == "0")
                            {
                                flag = 1;
                                break;
                            }
                        }

                        if (flag == 1)
                        {
                            dr[0] = data[i].RequisitionNo;
                            dr[1] = data[i].RequisitionBy;
                            dr[2] = data[i].RequisitionDate.Value.ToShortDateString();
                            dr[3] = data[i].BrProName;
                            dr[4] = data[i].ReqPurOrderId;
                            list.Add(Convert.ToInt32(data[i].RequisitionNo.ToString()));
                            dt.Rows.Add(dr);
                        }
                    }
                }
                GVCOA.DataSource = dt;
                GVCOA.DataBind();
                ViewState["CurrentData"] = dt;
                list.Clear();
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }



        protected void GVCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RequisitionNo = Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["RequisitionNo"].ToString());


            DataTable dt = (DataTable)ViewState["CurrentData"];
            LoadInfo(RequisitionNo);
            HFPurReqNo.Value = RequisitionNo.ToString();
            if (GVCOA.Rows.Count < 0)
            {
                pnlRec.Visible = false;
            }
            else pnlRec.Visible = true;

        }
        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCOA.PageIndex = e.NewPageIndex;
            LoadListRequisitonNo();
        }
        public void LoadInfo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("RequisitionNo", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("RequisitionBy", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("RequisitionDate", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CatId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("PurReqId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("ReqPurOrderId", typeof(String)));
                var data = ReqBLL.RequsiitonWiseProdctInfoLoad(id);
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].PurReqStatus == "0")
                    {
                        dr = dt.NewRow();
                        dr[0] = data[i].ProductId;
                        dr[1] = data[i].ProductName;
                        dr[2] = data[i].CompId;
                        dr[3] = data[i].CompName;
                        dr[4] = data[i].Quantity;
                        dr[5] = data[i].UnitPrice;
                        dr[6] = data[i].Priority;
                        dr[7] = data[i].RequisitionNo;
                        dr[8] = data[i].RequisitionBy;
                        dr[9] = data[i].RequisitionDate;
                        dr[10] = data[i].CategoryName;
                        dr[11] = data[i].CatId;// FirstOrDefault().MedTypeId;
                        dr[12] = data[i].PurReqId;
                        dr[13] = data[i].UnitName;
                        dr[14] = GVCOA.Rows[GVCOA.SelectedIndex].Cells[5].Text;
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    GvUpdate.DataSource = dt;
                    GvUpdate.DataBind();
                    ViewState["CurrentInfoData"] = dt;
                    PnlInfoProduct.Visible = true;
                }
                else
                    Show("No Data For RequisitionNO " + id);
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = (DataTable)ViewState["CurrentInfoData"];

                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("CatId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("PurReqId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("ReqPurOrderId", typeof(String)));


                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    int iii = Convert.ToInt32(Convert.ToInt32(dt1.Rows[j][0]));
                    var Quantity = SBLL.LoadCentralStockStatus(iii);
                    int qu = Convert.ToInt32(dt1.Rows[j][4]);
                    if (Quantity.Count != 0)
                    {
                        double? quantity = Quantity.First().QuantityStore;
                        if (quantity >= Convert.ToInt32(dt1.Rows[j][4]))
                        {
                            DataTable dt2 = (DataTable)ViewState["CurrentPurData"];
                            if (ViewState["CurrentPurData"] != null)
                            {

                                for (int i = 0; i < dt2.Rows.Count + 1; i++)
                                {
                                    dt = (DataTable)ViewState["CurrentPurData"];
                                    if (dt.Rows.Count > 0)
                                    {
                                        dr = dt.NewRow();
                                        dr[0] = dt.Rows[0][0].ToString();
                                    }
                                }
                                int flag = 0;
                                for (int k = 0; k < dt2.Rows.Count; k++)
                                {
                                    if (Convert.ToInt32(dt2.Rows[k][0]) == Convert.ToInt32(dt1.Rows[j][0]) || Convert.ToInt32(dt2.Rows[k][2]) != Convert.ToInt32(dt1.Rows[j][2]))
                                    {
                                        flag = 1;
                                        break;
                                    }
                                }
                                if (flag == 0)
                                {


                                    dr = dt.NewRow();

                                    dr[0] = dt1.Rows[j][0];
                                    dr[1] = dt1.Rows[j][1];
                                    dr[2] = dt1.Rows[j][2];
                                    dr[3] = dt1.Rows[j][3];
                                    dr[4] = dt1.Rows[j][6];
                                    dr[5] = dt1.Rows[j][4];
                                    dr[6] = dt1.Rows[j][5];
                                    dr[7] = dt1.Rows[j][10];
                                    dr[8] = dt1.Rows[j][11];
                                    dr[9] = dt1.Rows[j][12];
                                    dr[10] = dt1.Rows[j][13];
                                    dr[11] = GVCOA.Rows[GVCOA.SelectedIndex].Cells[5].Text;
                                    dt.Rows.Add(dr);


                                }
                            }
                            else
                            {
                                dr = dt.NewRow();

                                dr[0] = dt1.Rows[j][0];
                                dr[1] = dt1.Rows[j][1];
                                dr[2] = dt1.Rows[j][2];
                                dr[3] = dt1.Rows[j][3];
                                dr[4] = dt1.Rows[j][6];
                                dr[5] = dt1.Rows[j][4];
                                dr[6] = dt1.Rows[j][5];
                                dr[7] = dt1.Rows[j][10];
                                dr[8] = dt1.Rows[j][12];
                                dr[9] = dt1.Rows[j][12];
                                dr[10] = dt1.Rows[j][13];
                                dr[11] = GVCOA.Rows[GVCOA.SelectedIndex].Cells[5].Text;
                                dt.Rows.Add(dr);

                            }
                        }

                    }
                    else
                    {
                    }

                    if (ViewState["CurrentPurData"] != null)
                    {
                        GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                        GVPur.DataBind();
                    }
                    else
                    {
                        GVPur.DataSource = dt;
                        GVPur.DataBind();
                    }
                    ViewState["CurrentPurData"] = dt;
                }

                pnlAction.Visible = true;
                AddPayable();
                if (dt1.Rows.Count != dt.Rows.Count)
                {
                    Show("Some Product Not Inserted Directly Cause Greater than Store Quantity!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }

        }


        protected void LBINFO_Click(object sender, CommandEventArgs e)
        {
            try
            {
                pnlUpdate.Visible = true;
                int Index;
                LinkButton lb = (LinkButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentInfoData"];
                var data = PBLL.GetProduct(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", 0, 0, 0);
                ddlCName.DataSource = data;
                ddlCName.DataTextField = "CompName";
                ddlCName.DataValueField = "CompId";
                ddlCName.DataBind();
                var data1 = PBLL.GetProduct(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", 0, 0, 0);
                ddlCateName.DataSource = data1;
                ddlCateName.DataTextField = "CategoryName";
                ddlCateName.DataValueField = "CatId";
                ddlCateName.DataBind();

                var data2 = PBLL.GetProduct(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", 0, 0, 0);
                ddlPName.DataSource = data2;
                ddlPName.DataTextField = "ProductName";
                ddlPName.DataValueField = "ProductId";
                ddlPName.DataBind();
                var data3 = PBLL.GetProduct(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", 0, 0, 0);
                ddlUnit.DataSource = data;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "UnitId";
                ddlUnit.DataBind();

                txtPQuality.Text = dt.Rows[rowID][4].ToString();
                txtPurPrice.Text = dt.Rows[rowID][5].ToString();
                Index = RbPriority.Items.IndexOf(RbPriority.Items.FindByText(dt.Rows[rowID][6].ToString()));
                RbPriority.SelectedIndex = Index;
                HFReqId.Value = dt.Rows[rowID][12].ToString();
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentInfoData"] != null)
            {
                GvUpdate.DataSource = (DataTable)ViewState["CurrentInfoData"];
                GvUpdate.DataBind();
            }
            GvUpdate.DataBind();
        }
        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        private void LoadCategory_productEntryPnl()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        private void Product_productEntryPnl()
        {

            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), 0);
            ddlPName.DataSource = query.OrderBy(Items => Items.ProductName);
            ddlPName.DataTextField = "ProductName";
            ddlPName.DataValueField = "ProductId";
            ddlPName.DataBind();
            ddlPName.Items.Insert(0, new ListItem("Select Product", "0"));

        }
        private void Unit_productEntryPnl()
        {
            var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }
        private void CurrentStockLoad()
        {
            var stockquan = SBLL.GetProduct(Convert.ToInt16(ddlPName.SelectedValue), "", 0, 0, 0);
            if (stockquan.Count != 0)
            {
                txtCurrent.Text = stockquan.First().QuantityStore.ToString();
            }
            else
            {
                txtCurrent.Text = "0";
            }
        }

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Unit_productEntryPnl();
            CurrentStockLoad();
        }

        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_productEntryPnl();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCurrent.Text) < Convert.ToInt32(txtPQuality.Text))
                {
                    Show("Greater than Store Quantity!");
                    return;

                }
                if (btnAdd.Text.ToLower() == "add")
                {
                    if (ViewState["CurrentPurData"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["CurrentPurData"];
                        int count = dt.Rows.Count;

                        for (int i = 0; i < count; i++)
                        {
                            if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()) || Convert.ToInt32(ddlCName.SelectedValue.ToString()) != Convert.ToInt32(dt.Rows[i][2].ToString()))
                            {
                                Show("Plase Check Duplicate Entry !");
                                return;
                            }
                        }
                        BindGrid(count);
                    }
                    else
                    {
                        BindGrid(1);
                    }
                }
                pnlAction.Visible = true;
                AddPayable();
                Clear();
                HFReqId.Value = "";
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        public void Clear()
        {

            Company_productEntryPnl();
            LoadCategory_productEntryPnl();
            Product_productEntryPnl();
            Unit_productEntryPnl();

            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";
        }
        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CatId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PurReqId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("ReqPurOrderId", typeof(String)));
            if (ViewState["CurrentPurData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentPurData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                }
                dr = dt.NewRow();
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[1] = ddlPName.SelectedItem;
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[4] = RbPriority.SelectedItem.ToString();
                dr[5] = txtPQuality.Text;
                dr[6] = txtPurPrice.Text;
                dr[7] = ddlCateName.SelectedItem.ToString();
                dr[8] = ddlCateName.SelectedValue.ToString();
                dr[9] = HFReqId.Value.ToString();
                dr[10] = ddlUnit.SelectedItem.ToString();
                dr[11] = GVCOA.Rows[GVCOA.SelectedIndex].Cells[5].Text;
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();

                dr = dt.NewRow();
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[1] = ddlPName.SelectedItem;
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[4] = RbPriority.SelectedItem.ToString();
                dr[5] = txtPQuality.Text;
                dr[6] = txtPurPrice.Text;
                dr[7] = ddlCateName.SelectedItem.ToString();
                dr[8] = ddlCateName.SelectedValue.ToString();
                dr[9] = HFReqId.Value.ToString();
                dr[10] = ddlUnit.SelectedItem.ToString();
                dr[11] = GVCOA.Rows[GVCOA.SelectedIndex].Cells[5].Text;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            else
            {
                GVPur.DataSource = dt;
                GVPur.DataBind();
            }
            ViewState["CurrentPurData"] = dt;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }
                ViewState["CurrentPurData"] = dt;
                GVPur.DataSource = dt;
                GVPur.DataBind();
                if (GVPur.Rows.Count == 0)
                {
                    pnlAction.Visible = false;

                }
            }
            AddPayable();

        }
        protected void GVPur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVPur.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            GVPur.DataBind();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVPur.Rows.Count > 0)
                {
                   // lblWaiting.Visible=true;
                    int requiNo = Convert.ToInt32(GVPur.Rows[0].Cells[9].Text);
                    var data = ChalBLL.LoadBranchReqisitonNo(requiNo);
                    int? BrproId = data.First().BrProId;
                    ChalInfoDTO.ChallanBy = HttpContext.Current.User.Identity.Name;
                    ChalInfoDTO.ChallanDate = System.DateTime.Now;
                    ChalInfoDTO.PurReqNo = data.First().RequisitionNo;
                    ChalInfoDTO.BrProId = BrproId;
                    ChalInfoDTO.Note = txtNote.Text;
                    ChalBLL.CentralChallan_BranchWise(ChalInfoDTO);

                    var challanidQry = ChalBLL.LoadInvenCentralChallanID();
                    int challanIdInt = challanidQry.First().ChallanId;

                    foreach (GridViewRow row in GVPur.Rows)
                    {
                        TextBox txtquantity = (TextBox)row.FindControl("txtQuantity");
                        ChalDtlDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                        ChalDtlDTO.ChallanQuantity = Convert.ToInt32(txtquantity.Text);//Convert.ToInt32(row.Cells[7].Text);
                        if (row.Cells[8].Text != "&nbsp;")
                            ChalDtlDTO.ChallanPrice = Convert.ToDouble(row.Cells[8].Text);
                        ChalDtlDTO.ChallanId = challanIdInt;
                        ChalBLL.CentralChallanDtl_BranchWise(ChalDtlDTO);

                        // for each branch requisition status change

                        ReqDTO.PurReqId = Convert.ToInt32(row.Cells[9].Text);
                        ReqDTO.PurReqStatus = "1";
                        ReqBLL.Edit_PurRequsitionStatus(ReqDTO);

                        // for central Stock Status
                        var quantity = SBLL.LoadCentralStockStatus(Convert.ToInt32(row.Cells[3].Text));

                        SDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                        SDTO.CentralStoreId = Convert.ToInt32(quantity.First().CentralStoreId);
                        SDTO.QuantityStore = Convert.ToInt32(quantity.First().QuantityStore - Convert.ToInt32(txtquantity.Text));
                        SBLL.EditStoreQty(SDTO);

                        PurOrDTO.CentralPurOrderId = Convert.ToInt32(row.Cells[10].Text);

                        PurOrDTO.PurChallanStatus = "1";
                        PurOrBLL.Edit(PurOrDTO);

                        // for branch store status  GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)
                        var quantitybr = BrStoreBLL.GetCurrentStockStaus(0, 0, Convert.ToInt32(row.Cells[3].Text), Convert.ToInt32(BrproId), 0, 0);
                        if (quantitybr.Count <= 0)
                        {
                            BrStoreDTO.BrProId = BrproId;
                            BrStoreDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                            BrStoreDTO.QuantityStore = Convert.ToInt32(txtquantity.Text);
                            BrStoreDTO.QuantityPurchase = int.Parse(txtquantity.Text);
                            BrStoreDTO.QuantityLastPurchase = int.Parse(txtquantity.Text);
                            BrStoreDTO.DateStored = DateTime.Now.Date;
                            BrStoreDTO.DateUpdated = DateTime.Now.Date;
                            BrStoreBLL.Add(BrStoreDTO);
                        }
                        else
                        {
                            BrStoreDTO.BrProId = BrproId;
                            BrStoreDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                            BrStoreDTO.InvenStoreId = Convert.ToInt32(quantitybr.First().InvenStoreId);
                            BrStoreDTO.QuantityStore = Convert.ToInt32(Convert.ToInt16(txtquantity.Text) + quantitybr.First().QuantityStore);
                            if (quantitybr.First().QuantityPurchase == null)
                            {
                                BrStoreDTO.QuantityPurchase = int.Parse(txtquantity.Text);
                            }
                            else
                            {
                                BrStoreDTO.QuantityPurchase = quantitybr.First().QuantityPurchase + int.Parse(txtquantity.Text);

                            }
                            BrStoreDTO.QuantityLastPurchase = int.Parse(txtquantity.Text);
                            BrStoreDTO.DateUpdated = DateTime.Now.Date;
                            BrStoreBLL.Edit(BrStoreDTO);
                        }
                    }
                   // lblWaiting.Visible = false;
                    Show(" Save Sucessfully !");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/ChallanBranchRptUI.aspx?ChallanId=" + challanIdInt.ToString() + "');", true);

                    Clear();
                    PurCancel();
                    Search_Clear();

                    return;
                }
                else
                {
                    Show("Central  Store Quantity is Less than Required Quantity!");
                    return;
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void BtnCancelPurchase_Click(object sender, EventArgs e)
        {
            Clear();
            PurCancel();
            Search_Clear();
        }

        public void PurCancel()
        {
            LoadListRequisitonNo();
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            this.ViewState["CurrentInfoData"] = null;
            DataTable dt1 = new DataTable();
            GvUpdate.DataSource = dt1;
            GvUpdate.DataBind();
            LoadListRequisitonNo();
            pnlAction.Visible = false;
            pnlAction.Visible = false;
            GVCOA.SelectedIndex = -1;
            txtNote.Text = "";
            txtTotalPayable.Text = "";
            PnlInfoProduct.Visible = false;

        }
        public void AddPayable()
        {
            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {
                    TextBox txtquantity = (TextBox)row.FindControl("txtQuantity");
                    if (row.Cells[8].Text != "&nbsp;")
                        sum += Convert.ToDouble(txtquantity.Text) * Convert.ToDouble(row.Cells[8].Text);
                }
                txtTotalPayable.Text = sum.ToString();
            }
            else
                txtTotalPayable.Text = "0";
        }
        protected void btnTotalAmount_Click(object sender, EventArgs e)
        {
            AddPayable();
        }

    }
}