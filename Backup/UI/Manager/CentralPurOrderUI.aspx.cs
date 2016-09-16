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

namespace UI.Manager
{
    public partial class CentralPurOrderUI : System.Web.UI.Page
    {
        InvenCentralPurRequisitionBLL ReqBLL = new InvenCentralPurRequisitionBLL();
        InvenCentralPurRequisitonDTO ReqDTO = new InvenCentralPurRequisitonDTO();
        CompanyBLL compBLL = new CompanyBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        InvenCentralStoreStatusBLL StockBLL = new InvenCentralStoreStatusBLL();
        InvenCentralPurOrderBLL PurOrBLL = new InvenCentralPurOrderBLL();
        InvenCentralPurOrderDTO PurOrDTO = new InvenCentralPurOrderDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadList();
                LoadRequisitionNo();
                Company();
            }
        }
        private void LoadRequisitionNo()
        {

            var query = ReqBLL.GetReqList_Dropdownlist();
            ddlRequisionNo.DataSource = query;//OrderBy(Items => Items.BrProId);
            ddlRequisionNo.DataTextField = "RequisitionNo";
            ddlRequisionNo.DataValueField = "RequisitionNo";
            ddlRequisionNo.DataBind();
            ddlRequisionNo.Items.Insert(0, new ListItem("Select Branch", "0"));

        }
        private void Company()
        {
            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName_S.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName_S.DataTextField = "CompName";
            ddlCName_S.DataValueField = "CompId";
            ddlCName_S.DataBind();
            ddlCName_S.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        public void LoadList()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            ArrayList list = new ArrayList();
            dt.Columns.Add(new System.Data.DataColumn("RequisitionNo", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("RequisitionBy", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("RequisitionDate", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));

            var data = ReqBLL.GetRequisition_CentralPurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt32(ddlCName_S.SelectedValue), Convert.ToInt32(ddlRequisionNo.SelectedValue));

            for (int i = 0; i < data.Count; i++)
            {
                dr = dt.NewRow();

                if (list.IndexOf(Convert.ToInt32(data[i].RequisitionNo.ToString())) == -1)
                {
                    int Recno = Convert.ToInt32(data[i].RequisitionNo.ToString());
                    var data1 = ReqBLL.GetInfo(Recno);
                    int flag = 0;
                    for (int j = 0; j < data1.Count; j++)
                    {
                        if (data1[j].PurReqStatus == "N")
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        dr[0] = data[i].RequisitionNo;
                        dr[1] = data[i].RequisitionBy;
                        dr[2] = data[i].RequisitionDate;
                        dr[3] = data[i].CompName;
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
        protected void btnSearch_Click(object sender, EventArgs e)
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
            if (txtDateTo.Text == "" && txtDateFrom.Text == "" && ddlRequisionNo.SelectedValue == "0" && ddlCName_S.SelectedValue == "0")
            {
                Show(" Plz Insert Data For Search");
                return;

            }
            var search = ReqBLL.GetRequisition_CentralPurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt32(ddlRequisionNo.SelectedValue));
            if (search.Count == 0)
            {
                Show(" No data Found !");
                return;
            }
            GVCOA.DataSource = search;
            GVCOA.DataBind();

        }

        protected void txtSearch(object sender, EventArgs e)
        {
            SearchReq();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, CommandEventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            DataTable dt = (DataTable)ViewState["CurrentData"];
            LoadInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
            HFPurReqNo.Value = dt.Rows[rowID][0].ToString();
            if (GVCOA.Rows.Count < 0)
            {
                pnlRec.Visible = false;
            }
            else pnlRec.Visible = true;
        }
        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCOA.PageIndex = e.NewPageIndex;
            LoadList();
        }
        public void LoadInfo(int id)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CenPurReqId", typeof(String)));
            var data = ReqBLL.GetInfo(id);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].PurReqStatus == "N")
                {
                    dr = dt.NewRow();
                    dr[0] = data[i].ProductId;
                   // char[] split = new char[] { '-', ' ' };
                   // String[] Value = data[i].MedicationName.ToString().Split(split);
                    dr[1] = data[i].ProductName;
                    dr[2] = data[i].CompId;
                    dr[3] = data[i].CompName;
                    dr[4] = data[i].Quantity;
                    dr[5] = data[i].UnitPrice;
                    dr[6] = data[i].Priority;
                    dr[7] = data[i].RequisitionNo;
                    dr[8] = data[i].RequisitionBy;
                    dr[9] = data[i].RequisitionDate;
                    dr[13] = data[i].UnitName;//+ " " + data[i].UnitType;
                    
                    dr[12] = data[i].CenPurReqId;
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                GVINFO.DataSource = dt;
                GVINFO.DataBind();
                ViewState["CurrentInfoData"] = dt;
                //pnlInfo.Visible = true;
            }
            else
                Show("No Data For RequisitionNO " + id);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
        protected void LBINFO_Click(object sender, CommandEventArgs e)
        {
            //pnlUpdate.Visible = true;
            //int Index;
            //LinkButton lb = (LinkButton)sender;
            //GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            //int rowID = gvRow.RowIndex;
            //DataTable dt = (DataTable)ViewState["CurrentInfoData"];
            //var data = MTBLL.GetType(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
            //ddlMedType.DataSource = data;
            //ddlMedType.DataTextField = "MedShortFrom";
            //ddlMedType.DataValueField = "MedTypeId";
            //ddlMedType.DataBind();
            //var data1 = MBLL.GetMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()), "", "", "", "");
            //ddlCName.DataSource = data1;
            //ddlCName.DataTextField = "CompanyName";
            //ddlCName.DataValueField = "CompanyId";
            //ddlCName.DataBind();

            //var data2 = PSBLL.LoadMedicationInfo(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
            //ddlPName.DataSource = data2;
            //ddlPName.DataTextField = "MedicationNameUnit";
            //ddlPName.DataValueField = "MedicationId";
            //ddlPName.DataBind();
            //GetCurrent(Convert.ToInt32(dt.Rows[rowID][0].ToString()));
            //Index = RbtWeight.Items.IndexOf(RbtWeight.Items.FindByText(data2.FirstOrDefault().UnitType));
            //RbtWeight.SelectedIndex = Index;
            ////Show(un[1]);
            //txtPQuality.Text = dt.Rows[rowID][4].ToString();
            //txtPurPrice.Text = dt.Rows[rowID][5].ToString();
            //Index = RbPriority.Items.IndexOf(RbPriority.Items.FindByText(dt.Rows[rowID][6].ToString()));
            //RbPriority.SelectedIndex = Index;
            //HFReqId.Value = dt.Rows[rowID][12].ToString();
        }
    }
}