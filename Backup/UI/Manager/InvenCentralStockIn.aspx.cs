//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using BLL;
//using DTO;

//namespace UI.Manager
//{
//    public partial class InvenCentralStockIn : System.Web.UI.Page
//    {

//        InvenCentralPurRequisitionBLL PBLL = new InvenCentralPurRequisitionBLL();
//        CompanyBLL DBLL = new CompanyBLL();
//        InvenCentralPurOrderBLL PRBLL = new InvenCentralPurOrderBLL();
//        InvenCentralPurOrderDTO PRDTO = new InvenCentralPurOrderDTO();
//        CategoryBLL MTBLL = new CategoryBLL();
//        InvenCentralPurchseBLL PPBLL = new InvenCentralPurchseBLL();
//        // PharmSalesBLL PSBLL = new PharmSalesBLL();
//        ProductBLL MBLL = new ProductBLL();
//        InvenCentralPurchaeInfoDTO PurInfoDTO = new InvenCentralPurchaeInfoDTO();

//        InvenCentralPurchaseDtlDto PurDtlDTO = new InvenCentralPurchaseDtlDto();

//        // store table
//        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
//        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();

//        // payment
//        InvenCentralPurchasePaymentDTO PayDTO = new InvenCentralPurchasePaymentDTO();
//        InvenCentralPurchasePaymentDtlDto PayDtlDTO = new InvenCentralPurchasePaymentDtlDto();


//        public static int UpdateId = 0;
//        public static void Show(string message)
//        {
//            Page page = HttpContext.Current.Handler as Page;
//            if (page != null)
//            {
//                message = message.Replace("'", "\'");
//                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
//            }
//        }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!Page.IsPostBack)
//            {
//                LoadCompanySearch();
//                LoadOrderSearch();
//                LoadMediType();
//                LoadList();
//                GVINFO.Columns[9].Visible = false;
//                GvUpdate.Columns[7].Visible = false;
//            }
//        }
//        public void LoadMediType()
//        {

//            var MType = MTBLL.GetMedicationType(0);
//            ddlMedType.DataSource = MType;
//            ddlMedType.DataTextField = "MedShortFrom";
//            ddlMedType.DataValueField = "MedTypeId";
//            ddlMedType.DataBind();
//            ddlMedType.Items.Insert(0, new ListItem("Select Product Ctagory", "0"));

//        }
//        public void LoadUnit()
//        {
//            var data = MBLL.GetUnit(Convert.ToInt32(ddlPName.SelectedValue.ToString()));
//            RbtWeight.SelectedIndex = RbtWeight.Items.IndexOf(RbtWeight.Items.FindByText(data.FirstOrDefault().UnitType));
//            txtPQuality.Text = data.FirstOrDefault().ThresholdValue.ToString();
//        }
//        public void LoadCompanyName()
//        {

//            var DInfo = MBLL.GetMedicationInfo(Convert.ToInt32(ddlMedType.SelectedValue.ToString()));
//            ddlCName.DataSource = DInfo;
//            ddlCName.DataTextField = "CompanyName";
//            ddlCName.DataValueField = "CompanyId";
//            ddlCName.DataBind();
//            ddlCName.Items.Insert(0, new ListItem("Select Company Name", "0"));

//        }
//        public void LoadProduct()
//        {

//            var DInfo = PPBLL.GetMedicationName(Convert.ToInt32(ddlMedType.SelectedValue.ToString()), Convert.ToInt32(ddlCName.SelectedValue.ToString()));
//            ddlPName.DataSource = DInfo;
//            ddlPName.DataTextField = "MedicationName";
//            ddlPName.DataValueField = "MedicationId";
//            ddlPName.DataBind();
//            ddlPName.Items.Insert(0, new ListItem("Select Medication Name", "0"));

//        }
//        public void LoadCompanySearch()
//        {
//            var data = DBLL.GetCompanyName(0);
//            ddlCName_S.DataSource = data;
//            ddlCName_S.DataTextField = "CompName";
//            ddlCName_S.DataValueField = "CompId";
//            ddlCName_S.DataBind();
//            ddlCName_S.Items.Insert(0, new ListItem("Select Company Name", "0"));
//        }
//        public void LoadOrderSearch()
//        {
//            var data = PRBLL.GetPurOrderNo();
//            //data.Sort();
//            ddlMed_S.DataSource = data;
//            ddlMed_S.DataTextField = "PurOrderNO";
//            ddlMed_S.DataValueField = "PurOrderNO";
//            ddlMed_S.DataBind();


//            ddlMed_S.Items.Insert(0, new ListItem("Select Order No", "0"));
//        }
//        public void Clear()
//        {

//            LoadCompanyName();
//            LoadProduct();
//            LoadMediType();

//            txtPQuality.Text = "";
//            txtPurPrice.Text = "";
//            txtCurrent.Text = "0";
//            txtExpriyDate.Text = "";
//            txtBatchNo.Text = "";
//        }
//        public void LoadList()
//        {
//            DataTable dt = new DataTable();
//            DataRow dr;
//            ArrayList list = new ArrayList();
//            dt.Columns.Add(new System.Data.DataColumn("OrderNo", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderBy", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderDate", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));
//            var data = PRBLL.GetData(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt32(ddlCName_S.SelectedValue), Convert.ToInt32(ddlMed_S.SelectedValue));
//            for (int i = 0; i < data.Count; i++)
//            {
//                dr = dt.NewRow();

//                if (list.IndexOf(Convert.ToInt32(data[i].PurOrderNO.ToString())) == -1)
//                {
//                    int OrderNo = Convert.ToInt32(data[i].PurOrderNO.ToString());
//                    var data1 = PRBLL.GetInfo(OrderNo);
//                    int flag = 0;
//                    for (int j = 0; j < data1.Count; j++)
//                    {


//                        if (data1[j].PurOrderStatus == "N")
//                        {
//                            flag = 1;
//                            break;
//                        }
//                    }
//                    if (flag == 1)
//                    {
//                        dr[0] = data[i].PurOrderNO;
//                        dr[1] = data[i].PurOrderBy;
//                        dr[2] = data[i].PurOrderNO;
//                        dr[3] = data[i].CompanyName;
//                        list.Add(Convert.ToInt32(data[i].PurOrderNO.ToString()));
//                        dt.Rows.Add(dr);
//                    }
//                }

//            }
//            if (dt.Rows.Count > 0)
//            {

//                GVCOA.DataSource = dt;
//                GVCOA.DataBind();
//                ViewState["CurrentData"] = dt;
//                pnlOrder.Visible = true;
//            }
//            else if (dt.Rows.Count < 0 && !string.IsNullOrEmpty(Request.Form[btnSearch.UniqueID]))
//            {
//                Show("No Data Found");

//            }
//            list.Clear();

//        }
//        public void LoadInfo(int id)
//        {

//            DataTable dt = new DataTable();
//            DataRow dr;
//            dt.Columns.Add(new System.Data.DataColumn("MedicationId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedicationName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderNo", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderBy", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderDate", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("PUnit", typeof(String)));
//            var data = PRBLL.GetInfo(id);
//            for (int i = 0; i < data.Count; i++)
//            {


//                if (data[i].PurOrderStatus == "N")
//                {
//                    dr = dt.NewRow();
//                    char[] a = new char[] { '-' };
//                    string[] value = data[i].MedicationName.ToString().Split(a);
//                    dr[0] = data[i].MedicationId;
//                    dr[1] = value[0];
//                    dr[2] = data[i].CompId;
//                    dr[3] = data[i].CompanyName;
//                    dr[4] = data[i].Quantity;
//                    dr[5] = data[i].UnitPrice;
//                    dr[6] = data[i].Priority;
//                    dr[7] = data[i].PurOrderNO;
//                    dr[8] = data[i].PurOrderBy;
//                    dr[9] = data[i].PurOrderDate;
//                    dr[13] = data[i].UnitValue + " " + data[i].UnitType;
//                    var data2 = MTBLL.GetType(Convert.ToInt32(data[i].MedicationId));
//                    dr[10] = data2.FirstOrDefault().MedShortFrom;
//                    dr[11] = data2.FirstOrDefault().MedTypeId;
//                    dr[12] = data[i].ProPurId;
//                    dt.Rows.Add(dr);
//                }
//            }
//            if (dt.Rows.Count > 0)
//            {
//                GVINFO.DataSource = dt;
//                GVINFO.DataBind();
//                ViewState["CurrentInfoData"] = dt;
//                pnlInfo.Visible = true;
//            }
//            else
//                Show("No Data For RequisitionNO " + id);
//        }
//        public void GetCurrent(int id)
//        {
//            var data1 = PPBLL.GetQuantity(id);

//            int In;
//            if (data1.Count <= 0)
//                In = 0;
//            else
//                In = Convert.ToInt32(data1.FirstOrDefault().QuantityStore.ToString());
//            //var data2 = PSBLL.GetQuantity(Convert.ToInt32(ddlPName.SelectedValue.ToString()));
//            //int Out;
//            //if (data2.Count <= 0)
//            //    Out = 0;
//            //else
//            //    Out = Convert.ToInt32(data2.FirstOrDefault().Quantity.ToString());
//            txtCurrent.Text = In.ToString();
//        }
//        public void GetCurrent()
//        {
//            var storquantity = SBLL.LoadStoreStatusProduct(Convert.ToInt32(ddlPName.SelectedValue));
//            if (storquantity.Count != 0)
//            {
//                txtCurrent.Text = Convert.ToString(storquantity.First().QuantityStore);
//            }
//            else
//            {
//                txtCurrent.Text = "0";
//            }

//        }
//        private void BindGrid(int rowcount)
//        {
//            // Show("You Can't Add This Without Order");
//            DataTable dt = new DataTable();
//            DataRow dr;
//            dt.Columns.Add(new System.Data.DataColumn("MedicationId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedicationName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderNo", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("PUnit", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("ExpriyDate", typeof(string)));
//            dt.Columns.Add(new System.Data.DataColumn("BatchNo", typeof(string)));
//            if (ViewState["CurrentPurData"] != null)
//            {
//                for (int i = 0; i < rowcount + 1; i++)
//                {
//                    dt = (DataTable)ViewState["CurrentPurData"];
//                    if (dt.Rows.Count > 0)
//                    {
//                        dr = dt.NewRow();
//                        dr[0] = dt.Rows[0][0].ToString();
//                    }
//                }

//                dr = dt.NewRow();
//                char[] a = new char[] { '-' };
//                string[] value = ddlPName.SelectedItem.ToString().Split(a);
//                dr[0] = ddlPName.SelectedValue.ToString();
//                dr[1] = value[0];
//                dr[2] = ddlCName.SelectedValue.ToString();
//                dr[3] = ddlCName.SelectedItem.ToString();
//                dr[4] = RbPriority.SelectedItem.ToString();
//                dr[5] = txtPQuality.Text;
//                dr[6] = txtPurPrice.Text;
//                dr[7] = ddlMedType.SelectedItem.ToString();
//                dr[8] = ddlMedType.SelectedValue.ToString();
//                dr[9] = HFReqProOrderId.Value.ToString();
//                if (HFPurOrderNo.Value.ToString() != "")
//                    dr[10] = HFPurOrderNo.Value.ToString();
//                else
//                    dr[10] = dt.Rows[0][10].ToString();
//                dr[11] = value[1] + " " + RbtWeight.SelectedItem;

//                //if (txtExpriyDate.Text.ToString() != "")
//                dr[12] = txtExpriyDate.Text;
//                //else
//                //    dr[12] = "";
//                //if (txtBatchNo.Text.ToString() != "")
//                dr[13] = txtBatchNo.Text;
//                //else
//                //    dr[13] = "";
//                dt.Rows.Add(dr);


//            }
//            else
//            {
//                if (HFPurOrderNo.Value.ToString() != "")
//                {
//                    dr = dt.NewRow();

//                    dr[0] = ddlPName.SelectedValue.ToString();
//                    char[] a = new char[] { '-', ' ' };
//                    string[] un = ddlPName.SelectedItem.ToString().Split(a);
//                    dr[1] = un[0];
//                    dr[2] = ddlCName.SelectedValue.ToString();
//                    dr[3] = ddlCName.SelectedItem.ToString();
//                    dr[4] = RbPriority.SelectedItem.ToString();
//                    dr[5] = txtPQuality.Text;
//                    dr[6] = txtPurPrice.Text;
//                    dr[7] = ddlMedType.SelectedItem.ToString();
//                    dr[8] = ddlMedType.SelectedValue.ToString();
//                    dr[9] = HFReqProOrderId.Value.ToString();
//                    dr[10] = HFPurOrderNo.Value.ToString();
//                    dr[11] = un[1] + " " + RbtWeight.SelectedItem;

//                    //dr[12] = txtExpriyDate.Text;

//                    //dr[13] = txtBatchNo.Text;
//                    //if (txtExpriyDate.Text.ToString() != "")
//                    dr[12] = txtExpriyDate.Text;
//                    //else
//                    //    dr[12] = "";
//                    //if (txtBatchNo.Text.ToString() != "")
//                    dr[13] = txtBatchNo.Text;
//                    //else
//                    //    dr[13] = "";
//                    dt.Rows.Add(dr);
//                }
//            }
//            if (ViewState["CurrentPurData"] != null)
//            {
//                GvUpdate.DataSource = (DataTable)ViewState["CurrentPurData"];
//                GvUpdate.DataBind();

//                btnAdd.Attributes.Add("OnClick", "alert ('You Can't Add This Without OrderNo');");
//                //return;
//            }
//            else
//            {
//                if (dt.Rows.Count == 0)
//                {
//                    Show("You Can't Add This Without Order");
//                }
//                else
//                {
//                    GvUpdate.DataSource = dt;
//                    GvUpdate.DataBind();
//                }
//            }
//            if (dt.Rows.Count > 0)
//                ViewState["CurrentPurData"] = dt;

//        }
//        public void ClearControl()
//        {
//            pnlAction.Visible = false;
//            pnlInsert.Visible = false;
//            pnlInfo.Visible = false;
//            this.ViewState["CurrentPurData"] = null;
//            this.ViewState["CurrentInfoData"] = null;
//            this.ViewState["CurrentData"] = null;
//            DataTable dt = new DataTable();
//            GVCOA.DataSource = dt;
//            GVCOA.DataBind();
//            GVINFO.DataSource = dt;
//            GVINFO.DataBind();
//            GvUpdate.DataSource = dt;
//            GvUpdate.DataBind();
//            HFPurOrderNo.Value = "";
//            HFReqProOrderId.Value = "";
//            LoadList();
//        }
//        public void ClearSearch()
//        {
//            txtDateTo.Text = "";
//            txtDateFrom.Text = "";
//            LoadCompanySearch();
//            LoadOrderSearch();
//            // 
//        }
//        protected void btnSearch_Click(object sender, EventArgs e)
//        {
//            LoadList();
//        }

//        protected void btnSearchCancel_Click(object sender, EventArgs e)
//        {
//            ClearSearch();
//        }
//        protected void LinkButton1_Click(object sender, CommandEventArgs e)
//        {
//            LinkButton lb = (LinkButton)sender;
//            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
//            int rowID = gvRow.RowIndex;
//            DataTable dt = (DataTable)ViewState["CurrentData"];
//            LoadInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            //HFPurReqNo.Value = dt.Rows[rowID][0].ToString();
//        }

//        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            GVCOA.PageIndex = e.NewPageIndex;
//            LoadList();
//        }

//        protected void btnPost_Click(object sender, EventArgs e)
//        {
//            DataTable dt1 = (DataTable)ViewState["CurrentInfoData"];

//            DataTable dt = new DataTable();
//            DataRow dr;
//            dt.Columns.Add(new System.Data.DataColumn("MedicationId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedicationName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeName", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("MedTypeId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderId", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("OrderNo", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("PUnit", typeof(String)));
//            dt.Columns.Add(new System.Data.DataColumn("ExpriyDate", typeof(string)));
//            dt.Columns.Add(new System.Data.DataColumn("BatchNo", typeof(string)));
//            for (int j = 0; j < dt1.Rows.Count; j++)
//            {
//                DataTable dt2 = (DataTable)ViewState["CurrentPurData"];
//                if (ViewState["CurrentPurData"] != null)
//                {

//                    for (int i = 0; i < dt2.Rows.Count + 1; i++)
//                    {
//                        dt = (DataTable)ViewState["CurrentPurData"];
//                        if (dt.Rows.Count > 0)
//                        {
//                            dr = dt.NewRow();
//                            dr[0] = dt.Rows[0][0].ToString();
//                        }
//                    }
//                    int flag = 0;
//                    for (int k = 0; k < dt2.Rows.Count; k++)
//                    {
//                        if (Convert.ToInt32(dt2.Rows[k][0]) == Convert.ToInt32(dt1.Rows[j][0]) || Convert.ToInt32(dt2.Rows[k][2]) != Convert.ToInt32(dt1.Rows[j][2]) || Convert.ToInt32(dt2.Rows[k][10]) != Convert.ToInt32(dt1.Rows[j][7]))
//                        {
//                            flag = 1;
//                            break;
//                        }
//                    }
//                    if (flag == 0 && Convert.ToString(dt1.Rows[j][5]) != "")
//                    {
//                        dr = dt.NewRow();

//                        dr[0] = dt1.Rows[j][0];
//                        dr[1] = dt1.Rows[j][1];
//                        dr[2] = dt1.Rows[j][2];
//                        dr[3] = dt1.Rows[j][3];
//                        dr[4] = dt1.Rows[j][6];
//                        dr[5] = dt1.Rows[j][4];
//                        dr[6] = dt1.Rows[j][5];
//                        dr[7] = dt1.Rows[j][10];
//                        dr[8] = dt1.Rows[j][11];
//                        dr[9] = dt1.Rows[j][12];
//                        dr[10] = dt1.Rows[j][7];
//                        dr[11] = dt1.Rows[j][13];
//                        dt.Rows.Add(dr);

//                    }
//                }
//                else
//                {

//                    if (Convert.ToString(dt1.Rows[j][5]) != "")
//                    {
//                        dr = dt.NewRow();

//                        dr[0] = dt1.Rows[j][0];
//                        dr[1] = dt1.Rows[j][1];
//                        dr[2] = dt1.Rows[j][2];
//                        dr[3] = dt1.Rows[j][3];
//                        dr[4] = dt1.Rows[j][6];
//                        dr[5] = dt1.Rows[j][4];
//                        dr[6] = dt1.Rows[j][5];
//                        dr[7] = dt1.Rows[j][10];
//                        dr[8] = dt1.Rows[j][11];
//                        dr[9] = dt1.Rows[j][12];
//                        dr[10] = dt1.Rows[j][7];
//                        dr[11] = dt1.Rows[j][13];
//                        dt.Rows.Add(dr);
//                    }
//                }


//                if (ViewState["CurrentPurData"] != null)
//                {
//                    GvUpdate.DataSource = (DataTable)ViewState["CurrentPurData"];
//                    GvUpdate.DataBind();
//                }
//                else
//                {
//                    if (dt.Rows.Count > 0)
//                    {
//                        GvUpdate.DataSource = dt;
//                        GvUpdate.DataBind();
//                    }
//                }
//                if (dt.Rows.Count > 0)
//                {
//                    ViewState["CurrentPurData"] = dt;
//                }

//            }
//            if (GvUpdate.Rows.Count > 0)
//            {
//                pnlAction.Visible = true;
//                pnlInsert.Visible = true;


//            }
//            AddPayable();

//        }
//        protected void GvUpdateEdit_Click(object sender, CommandEventArgs e)
//        {

//            pnlUpdate.Visible = true;
//            int Index;
//            LinkButton lb = (LinkButton)sender;
//            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
//            int rowID = gvRow.RowIndex;
//            UpdateId = rowID;
//            DataTable dt = (DataTable)ViewState["CurrentPurData"];
//            var data = MTBLL.GetType(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            ddlMedType.DataSource = data;
//            ddlMedType.DataTextField = "MedShortFrom";
//            ddlMedType.DataValueField = "MedTypeId";
//            ddlMedType.DataBind();
//            var data1 = MBLL.GetMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", "", "", "");
//            ddlCName.DataSource = data1;
//            ddlCName.DataTextField = "CompanyName";
//            ddlCName.DataValueField = "CompanyId";
//            ddlCName.DataBind();

//            var data2 = PSBLL.LoadMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            ddlPName.DataSource = data2;
//            ddlPName.DataTextField = "MedicationNameUnit";
//            ddlPName.DataValueField = "MedicationId";
//            ddlPName.DataBind();

//            Index = RbtWeight.Items.IndexOf(RbtWeight.Items.FindByText(data2.FirstOrDefault().UnitType));
//            RbtWeight.SelectedIndex = Index;
//            //Show(un[1]);
//            txtPQuality.Text = dt.Rows[rowID][5].ToString();
//            txtPurPrice.Text = dt.Rows[rowID][6].ToString();
//            Index = RbPriority.Items.IndexOf(RbPriority.Items.FindByText(dt.Rows[rowID][4].ToString()));
//            RbPriority.SelectedIndex = Index;
//            GetCurrent(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            btnAdd.Text = "Update";
//            HFReqProOrderId.Value = dt.Rows[rowID][9].ToString();
//            HFPurOrderNo.Value = dt.Rows[rowID][10].ToString();
//            txtExpriyDate.Text = dt.Rows[rowID][12].ToString();
//            txtBatchNo.Text = dt.Rows[rowID][13].ToString();
//            AddPayable();
//        }
//        protected void GvUpdate_Click(object sender, CommandEventArgs e)
//        {

//            LinkButton lb = (LinkButton)sender;
//            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
//            int rowID = gvRow.RowIndex;
//            if (ViewState["CurrentPurData"] != null)
//            {
//                DataTable dt = (DataTable)ViewState["CurrentPurData"];
//                if (dt.Rows.Count > 0)
//                {
//                    dt.Rows.RemoveAt(rowID);
//                }
//                ViewState["CurrentPurData"] = dt;
//                GvUpdate.DataSource = dt;
//                GvUpdate.DataBind();
//                if (GvUpdate.Rows.Count == 0)
//                {
//                    pnlAction.Visible = false;
//                    pnlInsert.Visible = false;
//                }
//                AddPayable();
//            }


//        }
//        protected void LBINFO_Click(object sender, CommandEventArgs e)
//        {
//            pnlUpdate.Visible = true;
//            int Index;
//            LinkButton lb = (LinkButton)sender;
//            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
//            int rowID = gvRow.RowIndex;
//            DataTable dt = (DataTable)ViewState["CurrentInfoData"];
//            var data = MTBLL.GetType(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            ddlMedType.DataSource = data;
//            ddlMedType.DataTextField = "MedShortFrom";
//            ddlMedType.DataValueField = "MedTypeId";
//            ddlMedType.DataBind();
//            var data1 = MBLL.GetMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", "", "", "");
//            ddlCName.DataSource = data1;
//            ddlCName.DataTextField = "CompanyName";
//            ddlCName.DataValueField = "CompanyId";
//            ddlCName.DataBind();

//            var data2 = PSBLL.LoadMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            ddlPName.DataSource = data2;
//            ddlPName.DataTextField = "MedicationNameUnit";
//            ddlPName.DataValueField = "MedicationId";
//            ddlPName.DataBind();
//            GetCurrent(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
//            Index = RbtWeight.Items.IndexOf(RbtWeight.Items.FindByText(data2.FirstOrDefault().UnitType));
//            RbtWeight.SelectedIndex = Index;
//            //Show(un[1]);
//            txtPQuality.Text = dt.Rows[rowID][4].ToString();
//            txtPurPrice.Text = dt.Rows[rowID][5].ToString();
//            Index = RbPriority.Items.IndexOf(RbPriority.Items.FindByText(dt.Rows[rowID][6].ToString()));
//            RbPriority.SelectedIndex = Index;
//            HFReqProOrderId.Value = dt.Rows[rowID][12].ToString();
//            HFPurOrderNo.Value = dt.Rows[rowID][7].ToString();
//        }

//        protected void GVINFO_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            GVINFO.PageIndex = e.NewPageIndex;
//            if (ViewState["CurrentInfoData"] != null)
//            {
//                GVINFO.DataSource = (DataTable)ViewState["CurrentInfoData"];
//                GVINFO.DataBind();
//            }
//            GVINFO.DataBind();

//        }

//        protected void ddlMedType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlMedType.SelectedIndex != 0)
//                LoadCompanyName();
//        }

//        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlPName.SelectedIndex != 0)
//            {
//                LoadUnit();
//                GetCurrent();
//            }
//        }

//        protected void ddlCName_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (ddlCName.SelectedIndex != 0)
//            {
//                LoadProduct();
//            }
//        }

//        protected void btnAdd_Click(object sender, EventArgs e)
//        {
//            if (btnAdd.Text.ToLower() == "add")
//            {
//                if (ViewState["CurrentPurData"] != null)
//                {
//                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
//                    int count = dt.Rows.Count;

//                    for (int i = 0; i < count; i++)
//                    {
//                        if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()) || Convert.ToInt32(ddlCName.SelectedValue.ToString()) != Convert.ToInt32(dt.Rows[i][2].ToString()))
//                        {
//                            Show("Inserted Medication Already Exist!");
//                            return;
//                        }

//                    }
//                    BindGrid(count);
//                }
//                else
//                {
//                    BindGrid(1);

//                }

//            }
//            else if (btnAdd.Text.ToLower() == "update")
//            {
//                // Show(UpdateId.ToString());

//                if (ViewState["CurrentPurData"] != null)
//                {
//                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
//                    if (dt.Rows.Count > 0)
//                    {
//                        dt.Rows.RemoveAt(UpdateId);
//                    }
//                    ViewState["CurrentPurData"] = dt;
//                    GvUpdate.DataSource = dt;
//                    GvUpdate.DataBind();

//                }
//                if (ViewState["CurrentPurData"] != null)
//                {
//                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
//                    int count = dt.Rows.Count;

//                    for (int i = 0; i < count; i++)
//                    {
//                        if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
//                        {
//                            Show("Data Already Exists!");
//                            return;
//                        }

//                    }

//                    BindGrid(count);

//                }
//                else
//                {
//                    BindGrid(1);
//                }
//                btnAdd.Text = "ADD";
//            }
//            if (GvUpdate.Rows.Count > 0)
//            {
//                pnlAction.Visible = true;
//                pnlInsert.Visible = true;
//            }
//            Clear();
//            HFReqProOrderId.Value = "";
//            HFPurOrderNo.Value = "";
//            AddPayable();
//        }


//        public void AddPayable()
//        {
//            if (GvUpdate.Rows.Count > 0)
//            {


//                double sum = 0;
//                DataTable dt = (DataTable)ViewState["CurrentPurData"];
//                int Count = dt.Rows.Count;
//                for (int data = 0; data < Count; data++)
//                {
//                    sum += Convert.ToDouble(dt.Rows[data][6].ToString()) * Convert.ToDouble(dt.Rows[data][5].ToString());
//                }
//                txtTotalPayable.Text = sum.ToString();
//            }
//            else
//                txtTotalPayable.Text = "0";
//        }
//        protected void btnCancel_Click(object sender, EventArgs e)
//        {
//            Clear();
//            LoadMediType();
//            ddlCName.Items.Clear();
//            ddlPName.Items.Clear();
//            RbtWeight.SelectedIndex = 0;
//            RbPriority.SelectedIndex = 0;
//            HFReqProOrderId.Value = "";
//            HFPurOrderNo.Value = "";
//        }

//        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            GvUpdate.PageIndex = e.NewPageIndex;
//            if (ViewState["CurrentPurData"] != null)
//            {
//                GvUpdate.DataSource = (DataTable)ViewState["CurrentPurData"];
//                GvUpdate.DataBind();
//            }
//            GvUpdate.DataBind();
//        }
//        private void MessageBox(string msg)
//        {
//            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg + "')</script>"));
//        }

//        protected void btnPrint_Click(object sender, EventArgs e)
//        {
//            //int blankcount = 0;
//            //foreach (GridViewRow row in GvUpdate.Rows)
//            //{

//            //    TextBox txt = (TextBox)row.FindControl("txtGvExpiryDate");
//            //    string data = txt.Text;

//            //    if (data == "")
//            //    {
//            //        blankcount = blankcount + 1;

//            //    }

//            //}

//            //if (blankcount > 0)
//            //{
//            //    MessageBox(" te");
//            //    lblExpriyDateMissing.Visible = true;
//            //    lblExpriyDateMissing.Text = "Plz Insert Expriy Date";
//            //}

//            //else
//            //{
//            //    lblExpriyDateMissing.Visible = false;
//            //    DataTable dt = (DataTable)ViewState["CurrentPurData"];
//            //    int count = dt.Rows.Count;
//            //    PurInfoDTO.PurDes = txtNote.Text;
//            //    PurInfoDTO.CreateBy = HttpContext.Current.User.Identity.Name;
//            //    PurInfoDTO.CreateDate = System.DateTime.Now;
//            //    PurInfoDTO.SalesManName = txtSalesmanName.Text;
//            //    for (int i = 0; i < count; i++)
//            //    {
//            //        PurInfoDTO.PurOrderNo = Convert.ToInt16(dt.Rows[i][10].ToString());
//            //        PurInfoDTO.DurgCompId = Convert.ToInt16(dt.Rows[i][2].ToString());
//            //    }
//            //    PPBLL.PurchaseInfo(PurInfoDTO);

//            //    for (int i = 0; i < count; i++)
//            //    {

//            //        if (dt.Rows[i][9].ToString() != "")
//            //        {
//            //            PRDTO.ProPurId = Convert.ToInt32(dt.Rows[i][9].ToString());
//            //            PRDTO.PurOrderStatus = "Y";
//            //            PRBLL.Edit(PRDTO);
//            //        }

//            //        var Info = PPBLL.LoadPurID();
//            //        PurDtlDTO.PurId = Info.First().PurId;

//            //        PurDtlDTO.PurchasePrice = Convert.ToDouble(dt.Rows[i][6].ToString());
//            //        PurDtlDTO.Quantity = Convert.ToInt32(dt.Rows[i][5].ToString());
//            //        PurDtlDTO.BatchNo = Convert.ToString(dt.Rows[i][13].ToString());
//            //        PurDtlDTO.ExpirySalesStatus = "0";

//            //        PurDtlDTO.ExpriyDate = Convert.ToDateTime(dt.Rows[i][12].ToString());

//            //        PurDtlDTO.MedicationId = Convert.ToInt32(dt.Rows[i][0].ToString());
//            //        PPBLL.SavePurchaseDtl(PurDtlDTO);
//            //        // Show("Sucessfully Sumitted");

//            //        // data save in store table

//            //        var Quantity = SBLL.LoadStoreStatusProduct(Convert.ToInt32(dt.Rows[i][0]));
//            //        if (Quantity.Count <= 0)
//            //        {
//            //            SDTO.MedicationId = Convert.ToInt32(dt.Rows[i][0]);
//            //            SDTO.QuantityStore = Convert.ToInt32(dt.Rows[i][5]);
//            //            SBLL.AddSoteStatus(SDTO);
//            //        }
//            //        else
//            //        {
//            //            SDTO.MedicationId = Convert.ToInt32(dt.Rows[i][0]);
//            //            SDTO.PharmStoreId = Convert.ToInt32(Quantity.First().PharmStoreId);
//            //            SDTO.QuantityStore = Convert.ToInt32(dt.Rows[i][5]) + Quantity.First().QuantityStore;
//            //            SBLL.EditStoreStatus(SDTO);
//            //        }
//            //    }

//            //    // payment
//            //    var Infopur = PPBLL.LoadPurID();
//            //    PayDTO.PurId = Infopur.First().PurId;
//            //    PayDTO.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
//            //    PayDTO.FirstPaymentStatus = "N";
//            //    PPBLL.SavePaymentInfo(PayDTO);

//            //    //   PayDtlDTO.PurId = Infopur.First().PurId;
//            //    // PayDtlDTO.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
//            //    //PPBLL.SavePurchasePaymentDtl(PayDTO);// pay dto is for payment dtl dto


//            //    ClearControl();
//            //    ClearSearch();
//            //    ClearActionPanel();

//            //    var purinfoid = PPBLL.LoadPurID();
//            //    int PurId = purinfoid.First().PurId;
//            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/MedicationUI/Report/MedicationPurRptUINew.aspx?PurId=" + PurId.ToString() + "');", true);
//            //}
//        }
//        public void ClearActionPanel()
//        {
//            txtTotalPayable.Text = "";
//            txtSalesmanName.Text = "";
//            txtNote.Text = "";

//        }

//        protected void btnCancelPurchase_Click(object sender, EventArgs e)
//        {
//            Clear();
//            ClearSearch();
//            ClearControl();
//            AddPayable();
//            ClearActionPanel();
//        }


//    }
//}