using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using DTO;
using ADTO;
using PBLL.Page_ObjectBLL;
using System.Data;
using System.Threading;

namespace UI.Shop
{
    public partial class SecondSales : System.Web.UI.Page
    {
        CompanyBLL compBLL = new CompanyBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        // Sales  
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalpayDtlDTO = new InvenSalePaymentDtlDto();




        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        //Member

        MemberBLL memBLL = new MemberBLL();
        MemberDTO memDTO = new MemberDTO();

        //Unit

        UnitBLL uniBLL = new UnitBLL();

        //Invencentersotre
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        //sale xtra Info

        InvenSaleXtraInfoBLL xtraBLL = new InvenSaleXtraInfoBLL();
        InvenSaleXtraInfoDTO xtraDTO = new InvenSaleXtraInfoDTO();

        //Cocktail Info
        CocktailInfoBLL cockBLL = new CocktailInfoBLL();

        //Temp
        InvenTempSaleBLL tempBLL = new InvenTempSaleBLL();
        InvenTempSaleDTO tempDTO = new InvenTempSaleDTO();

        //Report
        InvenSalesDetailBLL DetailBLL = new InvenSalesDetailBLL();
        InvenSalesDetailDTO DetailDTO = new InvenSalesDetailDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member"] == null)
                Response.Redirect("~/Shop/FirstSale.aspx");
            if (!Page.IsPostBack)
            {
                loadMemberInfo();
                GetBranchId();
                rbCategory.RepeatLayout = RepeatLayout.Table;
                rbtPegSize.RepeatLayout = RepeatLayout.Table;
                rbSubCategory.RepeatLayout = RepeatLayout.Table;
                LoadCategory();
                LoadPeg();
                BindMember(int.Parse(HFMemberId.Value));
                //loadSubCategory();
            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
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
        private void LoadCategory()
        {
            var query = PBLL.GetProduct_Category(0, 0).Where(o => !o.CategoryName.ToLower().Contains("extra"));

            // var query = CBLL.GetCategory(0, "");
            rbCategory.DataSource = query.ToList().Distinct();
            rbCategory.DataTextField = "CategoryName";
            rbCategory.DataValueField = "CatId";
            rbCategory.DataBind();

        }
        public void AddPayable()
        {

            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {

                    sum += Convert.ToDouble(row.Cells[7].Text);
                }

                txtPayable.Text = sum.ToString();
                txtPaid.Text = sum.ToString();


            }
            else
            {
                txtPayable.Text = "0";
                txtPaid.Text = "0";

            }
            // VatCalculation();

        }
        private void BindMember(int MemId)
        {
            var data = tempBLL.GetAllInfo(MemId);
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("SaleType", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("MemberId", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("TempId", typeof(String)));
                    dt.Columns.Add(new System.Data.DataColumn("TotalPrize", typeof(String)));
                    if (ViewState["CurrentPurData"] != null)
                    {
                        DataTable dt1 = (DataTable)ViewState["CurrentPurData"];

                        for (int j = 0; j < dt1.Rows.Count + 1; j++)
                        {
                            dt = (DataTable)ViewState["CurrentPurData"];
                            if (dt.Rows.Count > 0)
                            {
                                dr = dt.NewRow();
                                dr[0] = dt.Rows[0][0].ToString();
                            }
                        }
                        dr = dt.NewRow();
                        dr[0] = data[i].ProductId;
                        //       dr[1] = ddlPName.SelectedItem.ToString();
                        dr[2] = data[i].ProductId;
                        dr[3] = data[i].SubCategory;

                        dr[4] = data[i].Category;
                        dr[5] = data[i].Category;
                        dr[6] = data[i].PegSize;
                        dr[7] = data[i].UnitPrize;
                        dr[8] = data[i].Unit;
                        dr[9] = data[i].SaleType;
                        dr[10] = data[i].MemberId;
                        dr[11] = data[i].TempId;
                        dr[12] = (data[i].PegSize * data[i].UnitPrize).ToString();
                        dt.Rows.Add(dr);

                    }
                    else
                    {

                        dr = dt.NewRow();
                        dr[0] = data[i].ProductId;
                        //       dr[1] = ddlPName.SelectedItem.ToString();
                        dr[2] = data[i].ProductId;
                        dr[3] = data[i].SubCategory;

                        dr[4] = data[i].Category;
                        dr[5] = data[i].Category;
                        dr[6] = data[i].PegSize;
                        dr[7] = data[i].UnitPrize;
                        dr[8] = data[i].Unit;
                        dr[9] = data[i].SaleType;
                        dr[10] = data[i].MemberId;
                        dr[11] = data[i].TempId;
                        dr[12] = (data[i].PegSize * data[i].UnitPrize).ToString();
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
                    GVPur.Visible = true;
                    //pnlAction.Visible = true;
                }
                AddPayable();
            }
        }

        private void loadMemberInfo()
        {
            char[] a = new char[] { '#' };
            var memdata = Session["member"].ToString().Split(a);
            //lblMemNo.Text = memdata[0];

            // lblMemName.Text = memdata[1];
            var query = memBLL.GetMember("", "", "", "", int.Parse(memdata[0]));
            lblMemName.Text = query.First().SellFullName;
            lblMemNo.Text = query.First().MemberNo;
            HFMemberId.Value = query.First().MemberId.ToString();
        }
        private void LoadPeg()
        {
            var data = uniBLL.GetUnit(0, "");
            rbtPegSize.DataSource = data;
            rbtPegSize.DataTextField = "UnitName";
            rbtPegSize.DataValueField = "UnitName";
            rbtPegSize.DataBind();
            // ddlUnit.Items.Insert(0, new ListItem("Select Peg Size", "0"));
        }
        private void loadSubCategory()
        {
            // var data = PBLL.GetProduct(0, "", int.Parse(ddlCateName.SelectedValue), 0, 0);
            var data = PBLL.GetProduct(0, "", int.Parse(rbCategory.SelectedValue), 0, 0);
            rbSubCategory.DataSource = data.ToList().Distinct();
            rbSubCategory.DataTextField = "CompName";
            rbSubCategory.DataValueField = "ProductId";
            rbSubCategory.DataBind();
            //  ddlCName.Items.Insert(0, new ListItem("Select Sub Category", "0"));

        }

        protected void rbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlSubcategory.Visible = true;
            loadSubCategory();
            lblCategory.Text = rbCategory.SelectedItem.ToString();
        }
        private double? CurrentStockLoad()
        { // for branch store status  GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)

            //   var proid = .GetProduct(0, "", int.Parse(ddlCateName.SelectedValue), 0, int.Parse(ddlCName.SelectedValue));

            var Quantitybr = SBLL.LoadCentralStockStatus(int.Parse(rbSubCategory.SelectedValue));

            // var stockquan = SBLL.GetProduct(Convert.ToInt16(ddlPName.SelectedValue), "", 0, 0, 0);

            if (Quantitybr.Count != 0)
                return Quantitybr.First().QuantityStore;
            else
                return 0;


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Show(rbCategory.SelectedItem + " " + rbSubCategory.SelectedItem + " " + rbtPegSize.SelectedItem);

        }
        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                var tempdata = tempBLL.GetAllByTempId(int.Parse(dt.Rows[rowID][11].ToString()));
                var cocktail = cockBLL.GetCocktail(int.Parse(tempdata.First().ProductId.ToString()), 0);
                if (cocktail.Count > 0)
                {

                    for (int j = 0; j < cocktail.Count; j++)
                    {
                        var Quantity = SBLL.LoadCentralStockStatus(int.Parse(tempdata.First().ProductId.ToString()));
                        SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                        SDTO.ProductId = Convert.ToInt32(cocktail[j].ItemProId.ToString());
                        SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore + (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(tempdata.First().PegSize.ToString())));
                        // DetailDTO.ProductId = Convert.ToInt32(cock[j].ItemProId.ToString()); 
                        var detail = DetailBLL.GetdtlId(Convert.ToInt32(cocktail[j].ItemProId.ToString()), DateTime.Now.ToShortDateString());
                        if (detail.Count > 0)
                        {
                            DetailDTO.DtlId = detail.First().DtlId;
                            DetailDTO.ProductId = detail.First().ProductId;
                            DetailDTO.UsedQuantity = detail.First().UsedQuantity - (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(tempdata.First().PegSize.ToString()));
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore + (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(tempdata.First().PegSize.ToString())));
                            DetailBLL.Edit(DetailDTO);
                        }

                        SBLL.EditStoreQty(SDTO);

                    }
                }
                else if (!tempdata.First().Category.ToString().ToLower().Contains("extra"))
                {
                    var Quantity = SBLL.LoadCentralStockStatus(int.Parse(tempdata.First().ProductId.ToString()));
                    SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                    SDTO.ProductId = int.Parse(tempdata.First().ProductId.ToString());
                    SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore + double.Parse(tempdata.First().PegSize.ToString()));

                    var detail = DetailBLL.GetdtlId(int.Parse(tempdata.First().ProductId.ToString()), DateTime.Now.ToShortDateString());
                    if (detail.Count > 0)
                    {
                        DetailDTO.DtlId = detail.First().DtlId;
                        DetailDTO.ProductId = detail.First().ProductId;
                        DetailDTO.UsedQuantity = detail.First().UsedQuantity - double.Parse(tempdata.First().PegSize.ToString());
                        DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore + double.Parse(tempdata.First().PegSize.ToString()));
                        DetailBLL.Edit(DetailDTO);
                    }


                    SBLL.EditStoreQty(SDTO);
                }
                tempBLL.DeleteTempId(int.Parse(dt.Rows[rowID][11].ToString()));
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }
                ViewState["CurrentPurData"] = dt;
                GVPur.DataSource = dt;
                GVPur.DataBind();
                //   tempBLL.Delete(int.Parse(HFMemberId.Value), int.Parse(e.CommandArgument.ToString()));

                if (GVPur.Rows.Count == 0)
                {
                    GVPur.Visible = false;

                }

            }
            AddPayable();

        }
        private void BindGrid(int rowcount, int proid, int compid, string compname, string catename, int cateid, double price)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SaleType", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MemberId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TempId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TotalPrize", typeof(String)));
            var data = tempBLL.LoadTempId();
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
                dr[0] = proid;
                //       dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = compid;
                dr[3] = compname;

                dr[4] = catename;
                dr[5] = cateid;
                dr[6] = 1;
                dr[7] = price;
                dr[8] = 1;
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = HFMemberId.Value;
                dr[11] = data.First().TempId;
                dr[12] = (1 * price);
                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                dr[0] = proid;
                //       dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = compid;
                dr[3] = compname;

                dr[4] = catename;
                dr[5] = cateid;
                dr[6] = 1;
                dr[7] = price;
                dr[8] = 1;
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = HFMemberId.Value;
                dr[11] = data.First().TempId;
                dr[12] = (1 * price);
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
            GVPur.Visible = true;
            AddPayable();
            // pnlAction.Visible = true;

        }
        private void BindGrid(int rowcount, double price)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SaleType", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MemberId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TempId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TotalPrize", typeof(String)));
            var data = tempBLL.LoadTempId();
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
                dr[0] = rbSubCategory.SelectedValue.ToString();
                //       dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = rbSubCategory.SelectedValue.ToString();
                dr[3] = rbSubCategory.SelectedItem.ToString();

                dr[4] = rbCategory.SelectedItem.ToString();
                dr[5] = rbCategory.SelectedValue.ToString();
                dr[6] = rbtPegSize.SelectedItem.ToString();
                dr[7] = price;
                dr[8] = rbtPegSize.SelectedItem.ToString();
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = HFMemberId.Value;
                dr[11] = data.First().TempId;
                dr[12] = (double.Parse(rbtPegSize.SelectedItem.ToString()) * price);
                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                //        dr[0] = ddlPName.SelectedValue.ToString();
                //        dr[1] = ddlPName.SelectedItem.ToString();
                dr[0] = rbSubCategory.SelectedValue.ToString();
                //       dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = rbSubCategory.SelectedValue.ToString();
                dr[3] = rbSubCategory.SelectedItem.ToString();

                dr[4] = rbCategory.SelectedItem.ToString();
                dr[5] = rbCategory.SelectedValue.ToString();
                dr[6] = rbtPegSize.SelectedItem.ToString();
                dr[7] = price;
                dr[8] = rbtPegSize.SelectedItem.ToString();
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = HFMemberId.Value;
                dr[11] = data.First().TempId;
                dr[12] = (double.Parse(rbtPegSize.SelectedItem.ToString()) * price);
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
            GVPur.Visible = true;
            AddPayable();
            // pnlAction.Visible = true;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/FirstSale.aspx");
        }

        protected void btnAddRes_Click(object sender, EventArgs e)
        {
            if (txtAddRes.Text != "")
            {
                var data = PBLL.GetProductByCategory("Restu");

                tempDTO.MemberId = int.Parse(HFMemberId.Value);
                tempDTO.Category = data.First().CategoryName.ToString();
                tempDTO.SubCategory = data.First().CompName.ToString();
                tempDTO.ProductId = int.Parse(data.First().ProductId.ToString());
                tempDTO.Unit = 1;
                tempDTO.PegSize = 1;

                tempDTO.UnitPrize = double.Parse(txtAddRes.Text);


                tempDTO.SaleType = "Bar Sale";
                tempDTO.CreateDate = DateTime.Now;
                tempBLL.Add(tempDTO);


                if (ViewState["CurrentPurData"] != null)
                {
                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count1 = dt.Rows.Count;
                    BindGrid(count1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddRes.Text));
                }
                else
                {
                    BindGrid(1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddRes.Text));
                }
                //Show(data.First().CompName + " " + data.First().CategoryName + " " + data.First().ProductId);
            }
            else
                Show("Restuarent Bill is empty!");
        }

        protected void btnAddCate_Click(object sender, EventArgs e)
        {
            if (txtAddCate.Text != "")
            {
                var data = PBLL.GetProductByCategory("Cater");
                tempDTO.MemberId = int.Parse(HFMemberId.Value);
                tempDTO.Category = data.First().CategoryName.ToString();
                tempDTO.SubCategory = data.First().CompName.ToString();
                tempDTO.ProductId = int.Parse(data.First().ProductId.ToString());
                tempDTO.Unit = 1;
                tempDTO.PegSize = 1;

                tempDTO.UnitPrize = double.Parse(txtAddCate.Text);


                tempDTO.SaleType = "Bar Sale";
                tempDTO.CreateDate = DateTime.Now;
                tempBLL.Add(tempDTO);
                //Show(data.First().CompName + " " + data.First().CategoryName + " " + data.First().ProductId);
                if (ViewState["CurrentPurData"] != null)
                {
                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count1 = dt.Rows.Count;
                    BindGrid(count1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddCate.Text));
                }
                else
                {
                    BindGrid(1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddCate.Text));
                }
            }
        }

        protected void btnAddBeka_Click(object sender, EventArgs e)
        {
            var data = PBLL.GetProductByCategory("Beka");
            if (txtAddBeka.Text != "")
            {
                tempDTO.MemberId = int.Parse(HFMemberId.Value);
                tempDTO.Category = data.First().CategoryName.ToString();
                tempDTO.SubCategory = data.First().CompName.ToString();
                tempDTO.ProductId = int.Parse(data.First().ProductId.ToString());
                tempDTO.Unit = 1;
                tempDTO.PegSize = 1;

                tempDTO.UnitPrize = double.Parse(txtAddBeka.Text);


                tempDTO.SaleType = "Bar Sale";
                tempDTO.CreateDate = DateTime.Now;
                tempBLL.Add(tempDTO);
                //Show(data.First().CompName + " " + data.First().CategoryName + " " + data.First().ProductId);
                if (ViewState["CurrentPurData"] != null)
                {
                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count1 = dt.Rows.Count;
                    BindGrid(count1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddBeka.Text));
                }
                else
                {
                    BindGrid(1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddBeka.Text));
                }
            }
        }

        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            if (txtAddGuest.Text != "")
            {
                var data = PBLL.GetProductByCategory("Guest");

                tempDTO.MemberId = int.Parse(HFMemberId.Value);
                tempDTO.Category = data.First().CategoryName.ToString();
                tempDTO.SubCategory = data.First().CompName.ToString();
                tempDTO.ProductId = int.Parse(data.First().ProductId.ToString());
                tempDTO.Unit = 1;
                tempDTO.PegSize = 1;

                tempDTO.UnitPrize = double.Parse(txtAddGuest.Text);


                tempDTO.SaleType = "Bar Sale";
                tempDTO.CreateDate = DateTime.Now;
                tempBLL.Add(tempDTO);
                //Show(data.First().CompName + " " + data.First().CategoryName + " " + data.First().ProductId);
                if (ViewState["CurrentPurData"] != null)
                {
                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count1 = dt.Rows.Count;
                    BindGrid(count1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddGuest.Text));
                }
                else
                {
                    BindGrid(1, int.Parse(data.First().ProductId.ToString()),
                        int.Parse(data.First().CompId.ToString()),
                        data.First().CompName, data.First().CategoryName,
                        int.Parse(data.First().CategoryId.ToString()),
                        double.Parse(txtAddGuest.Text));
                }
            }
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (txtPayable.Text != "" && txtPayable.Text != "")
            {
                SalInfoDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                SalInfoDTO.CreateDate = System.DateTime.Now;
                SalInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                SalInfoDTO.CustomerName = lblMemName.Text;
                SalInfoDTO.CusMobileNo = "";
                SalInfoDTO.CusContactAdd = "";
                SalInfoDTO.MemberId = int.Parse(HFMemberId.Value);
                SaleBLL.SaveSalesInfo(SalInfoDTO);
                var salid = SaleBLL.LaadSalInofId();
                int Salid = salid.First().SalId;
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    SaldtlDTO.SalePrice = Convert.ToDouble(dt.Rows[i][7]);
                    SaldtlDTO.Quantity = Convert.ToDouble(dt.Rows[i][6]);
                    SaldtlDTO.SalId = Salid;
                    SaldtlDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                    var unit = PBLL.GetProduct(Convert.ToInt32(dt.Rows[i][0]), "", 0, 0, 0);
                    SaldtlDTO.SaleType = dt.Rows[i][9].ToString();
                    SaldtlDTO.BarPrice = unit.First().ProductSalePrice;
                    SaldtlDTO.OffPrice = unit.First().ProductOffSalePrice;
                    if (dt.Rows[i][9].ToString().ToLower().Contains("bar".ToLower()))
                    {
                        SaldtlDTO.BarQuantity = Convert.ToDouble(dt.Rows[i][6]);
                        SaldtlDTO.OffQuantity = 0;


                    }
                    if (dt.Rows[i][9].ToString().ToLower().Contains("off".ToLower()))
                    {
                        SaldtlDTO.OffQuantity = Convert.ToDouble(dt.Rows[i][6]);
                        SaldtlDTO.BarQuantity = 0;
                    }
                    SaleBLL.SaveSalesDtl(SaldtlDTO);
                }
                SalPayDTO.PaidAmount = Convert.ToDouble(txtPaid.Text);
                SalPayDTO.DueAmount = Convert.ToDouble(txtPayable.Text) - Convert.ToDouble(txtPaid.Text);
                SalPayDTO.Discount = 0;
                SalPayDTO.TotalPrice = Convert.ToDouble(txtPayable.Text);
                SalPayDTO.SalId = Salid;
                if (rbPayment.SelectedItem.ToString().ToLower().Contains("credit"))
                {
                    SalPayDTO.Vat = (double.Parse(txtPayable.Text) * (1.87 / 100));
                }
                else
                    SalPayDTO.Vat = 0;
                SalPayDTO.DiscountDescription = "";
                SaleBLL.SaveSalesPaymentInfo(SalPayDTO);
                SalpayDtlDTO.SalId = Salid;
                SalpayDtlDTO.PaymentMode = rbPayment.SelectedItem.ToString();
                SalpayDtlDTO.PaidAmount = Convert.ToDouble(txtPaid.Text);
                SalpayDtlDTO.Note = "";
                SalpayDtlDTO.PaymentDate = System.DateTime.Now;
                SalpayDtlDTO.PaymentBy = HttpContext.Current.User.Identity.Name;
                SalpayDtlDTO.CardNo = "";
                SalpayDtlDTO.ApprCode = "";
                SalpayDtlDTO.BankName = "";
                SalpayDtlDTO.HolderName = "";
                SaleBLL.SaveSalesPaymentDtl(SalpayDtlDTO);
                tempBLL.Delete(int.Parse(HFMemberId.Value));
                ClearPaymentMode();
                // LoadMember();
                // Show("Sales Data Save Sucessfully");

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + Salid.ToString() + "');", true);
                Show("Sales Data Save Sucessfully");
                //Thread.Sleep(2000);
                //Response.Redirect("~/Shop/FirstSale.aspx");
                // Server.Transfer("~/Shop/FirstSale.aspx");

            }
            else
                Show("Paid Box Is Empty!");
        }

        private void ClearPaymentMode()
        {
            rbSubCategory.Items.Clear();
            txtAddBeka.Text = "";
            txtAddCate.Text = "";
            txtAddGuest.Text = "200";
            txtAddRes.Text = "";
            txtPaid.Text = "";
            txtPayable.Text = "";
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            GVPur.Visible = false;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/FirstSale.aspx");
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (txtPayable.Text != "")
                ScriptManager.RegisterStartupScript(Page, typeof(Page),
                    "OpenWindow", "window.open('/Shop/Report/BranchTempSale.aspx?memid=" + HFMemberId.Value + "&tdate=" + DateTime.Now.ToShortDateString() + "');", true);
            else
                Show("Make Transaction First!");
        }
        private void VatCalculation()
        {
            if (txtPayable.Text != "")
            {
                if (rbPayment.SelectedItem.ToString().ToLower().Contains("credit"))
                {
                    var add = (double.Parse(txtPayable.Text) * (1.87 / 100));
                    txtPayable.Text = (double.Parse(txtPayable.Text) + add).ToString();
                    txtPaid.Text = txtPayable.Text;
                }
                else
                {
                    AddPayable();
                }

            }
        }
        protected void rbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            VatCalculation();
        }
        private void Clear()
        {
            rbtPegSize.SelectedIndex = -1;
            rbSubCategory.Items.Clear();
            pnlSubcategory.Visible = false;
            rbCategory.SelectedIndex = -1;
            //rbtSaleType.SelectedIndex = -1;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void rbtSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void rbtPegSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtPegSize.SelectedIndex >= 0 && rbSubCategory.SelectedIndex >= 0)
            {
                double price = 0;
                var count = this.CurrentStockLoad();
                if (!rbCategory.SelectedItem.ToString().ToLower().Contains("Cocktail".ToLower()) &&
                    (count - double.Parse(rbtPegSize.SelectedValue.ToString())) <= 0)
                {
                    Show("Sales Quantity More than Available Quantity");
                    return;
                }
                if (rbCategory.SelectedItem.ToString().ToLower().Contains("Cockt".ToLower()))
                {
                    var cock = cockBLL.GetCocktail(Convert.ToInt32(rbSubCategory.SelectedValue.ToString()), 0);
                    if (cock.Count > 0)
                    {

                        for (int j = 0; j < cock.Count; j++)
                        {
                            var Quantity = SBLL.LoadCentralStockStatus(int.Parse(cock[j].ItemProId.ToString()));
                            if (Quantity.Count > 0)
                            {
                                if ((Quantity.First().QuantityStore - Convert.ToDouble(cock[j].Quantity)) < 0)
                                {
                                    Show(Quantity.First().CompName + " not enough in the stock!");

                                    return;
                                    //break;
                                }
                            }
                            else
                            {
                                Show("Cocktail is  not  in the stock!");

                                return;
                            }


                        }
                    }
                }
                else
                {
                    tempDTO.MemberId = int.Parse(HFMemberId.Value);
                    tempDTO.Category = rbCategory.SelectedItem.ToString();
                    tempDTO.SubCategory = rbSubCategory.SelectedItem.ToString();
                    tempDTO.ProductId = int.Parse(rbSubCategory.SelectedValue.ToString());
                    tempDTO.Unit = double.Parse(rbtPegSize.SelectedItem.ToString());
                    tempDTO.PegSize = double.Parse(rbtPegSize.SelectedItem.ToString());
                    var productinfo = PBLL.GetProduct(int.Parse(rbSubCategory.SelectedValue.ToString()), "", 0, 0, 0);
                    if (rbtSaleType.SelectedItem.ToString().ToLower().Contains("bar"))
                    {
                        tempDTO.UnitPrize = productinfo.First().ProductSalePrice;
                        price = double.Parse(productinfo.First().ProductSalePrice.ToString());
                    }
                    else
                    {
                        tempDTO.UnitPrize = productinfo.First().ProductOffSalePrice;
                        price = double.Parse(productinfo.First().ProductOffSalePrice.ToString());

                    }
                    tempDTO.SaleType = rbtSaleType.SelectedItem.ToString();
                    tempDTO.CreateDate = DateTime.Now;
                    tempBLL.Add(tempDTO);

                    /*Start quantity Deduct */




                    var cocktail = cockBLL.GetCocktail(int.Parse(rbSubCategory.SelectedValue.ToString()), 0);
                    if (cocktail.Count > 0)
                    {

                        for (int j = 0; j < cocktail.Count; j++)
                        {
                            var Quantity = SBLL.LoadCentralStockStatus(int.Parse(cocktail[j].ItemProId.ToString()));
                            SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                            SDTO.ProductId = Convert.ToInt32(cocktail[j].ItemProId.ToString());
                            SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(rbtPegSize.SelectedItem.ToString())));
                            // DetailDTO.ProductId = Convert.ToInt32(cock[j].ItemProId.ToString()); 
                            var detail = DetailBLL.GetdtlId(Convert.ToInt32(cocktail[j].ItemProId.ToString()), DateTime.Now.ToShortDateString());
                            if (detail.Count > 0)
                            {
                                DetailDTO.DtlId = detail.First().DtlId;
                                DetailDTO.ProductId = detail.First().ProductId;
                                DetailDTO.UsedQuantity = detail.First().UsedQuantity + (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(rbtPegSize.SelectedItem.ToString()));
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(rbtPegSize.SelectedItem.ToString())));
                                DetailBLL.Edit(DetailDTO);
                            }
                            else
                            {
                                DetailDTO.ProductId = Convert.ToInt32(cocktail[j].ItemProId.ToString());
                                DetailDTO.TotalQuantity = Quantity.First().QuantityStore;
                                DetailDTO.UsedQuantity = Convert.ToDouble(cocktail[j].Quantity) * double.Parse(rbtPegSize.SelectedItem.ToString());
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity)) * double.Parse(rbtPegSize.SelectedItem.ToString()));
                                DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                                DetailDTO.TodayStock = 0;
                                DetailBLL.Add(DetailDTO);
                            }
                            SBLL.EditStoreQty(SDTO);

                        }
                    }
                    else if (!rbCategory.SelectedItem.Text.ToString().ToLower().Contains("extra"))
                    {
                        var Quantity = SBLL.LoadCentralStockStatus(int.Parse(rbSubCategory.SelectedValue.ToString()));
                        if (Quantity.Count > 0)
                        {
                            SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                            SDTO.ProductId = Convert.ToInt32(int.Parse(rbSubCategory.SelectedValue.ToString()));
                            SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(rbtPegSize.SelectedItem.ToString()));

                            var detail = DetailBLL.GetdtlId(int.Parse(rbSubCategory.SelectedValue.ToString()), DateTime.Now.ToShortDateString());
                            if (detail.Count > 0)
                            {
                                DetailDTO.DtlId = detail.First().DtlId;
                                DetailDTO.ProductId = detail.First().ProductId;
                                DetailDTO.UsedQuantity = detail.First().UsedQuantity + double.Parse(rbtPegSize.SelectedItem.ToString());
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(rbtPegSize.SelectedItem.ToString()));
                                DetailBLL.Edit(DetailDTO);
                            }
                            else
                            {
                                DetailDTO.ProductId = int.Parse(rbSubCategory.SelectedValue.ToString());
                                DetailDTO.TotalQuantity = Quantity.First().QuantityStore;
                                DetailDTO.UsedQuantity = double.Parse(rbtPegSize.SelectedItem.ToString());
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(rbtPegSize.SelectedItem.ToString()));
                                DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                                DetailDTO.TodayStock = 0;
                                DetailBLL.Add(DetailDTO);
                            }

                            SBLL.EditStoreQty(SDTO);
                        }
                        else
                            Show("Not Enough in Stock!");
                    }
                }

                if (ViewState["CurrentPurData"] != null)
                {
                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count1 = dt.Rows.Count;
                    BindGrid(count1, price);
                }
                else
                {
                    BindGrid(1, price);
                }
                Clear();
            }
           
           // Clear();
        }


    }
}