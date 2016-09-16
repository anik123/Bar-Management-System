using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DTO;
using ABLL;
using ADTO;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Shop
{
    public partial class BranchSalesRpt : System.Web.UI.Page
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


        // jopurnal
        JournalDTO JDTO = new JournalDTO();
        JournalBLL JBLL = new JournalBLL();

        // transection dtl 
        TransDetailsBLL TranBLL = new TransDetailsBLL();
        TransDetailsDTO TranDTO = new TransDetailsDTO();

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

        public int Btn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnPrint.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnPrint, "").ToString());
            //btnAdd.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAdd, "").ToString());
            try
            {

                if (!Page.IsPostBack)
                {
                    RoleName();
                    Page.Title = "Sales Product";
                    GetBranchId();
                    // Company_productEntryPnl();


                    LoadCategory_productEntryPnl();
                    loadCompany();
                    LoadmemDDL();


                    Btn = 0;
                    LoadUnit();
                    LoadMember();

                    // Unit_productEntryPnl();
                }

            }
            catch (Exception ex)
            {
                Show(ex.Message);

            }

        }
        protected void GVMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVMember.PageIndex = e.NewPageIndex;

            SearchPagload();

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
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            ClearPaymentMode();
            var data = memBLL.GetMember("", "", "", "", int.Parse(e.CommandArgument.ToString()));
            ddlMName.SelectedValue = data.First().MemberId.ToString();
            HFMemberId.Value = data.First().MemberId.ToString();
            BindMember(data.First().MemberId);

        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }
        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            var list = ddlCName.Items.Cast<ListItem>().Select(item => item.Value).ToList();
            list.Sort();
            ddlCName.DataSource = query;//.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();

            ddlCName.Items.Insert(0, new ListItem("Select Sub Category", "0"));

        }
        private void LoadUnit()
        {
            var data = uniBLL.GetUnit(0, "");
            ddlUnit.DataSource = data;
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitName";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select Peg Size", "0"));
        }
        private void LoadCategory_productEntryPnl()
        {
            var query = PBLL.GetProduct_Category(0, 0);

            // var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.ToList().Distinct();
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void loadCompany()
        {
            var data = PBLL.GetProduct(0, "", int.Parse(ddlCateName.SelectedValue), 0, 0);
            ddlCName.DataSource = data.ToList().Distinct();
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "ProductId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Sub Category", "0"));

        }
        private void LoadmemDDL()
        {

            var query = memBLL.GetMember("", "", "", "", 0);

            ddlMName.DataSource = query;
            ddlMName.DataTextField = "SellFullName";
            ddlMName.DataValueField = "MemberId";
            ddlMName.DataBind();
            ddlMName.Items.Insert(0, new ListItem("Select Member", "0"));


        }
        private void Unit_productEntryPnl()
        {
            /*
              var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
              ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
              ddlUnit.DataTextField = "UnitName";
              ddlUnit.DataValueField = "UnitId";
              ddlUnit.DataBind();
             * */
            //ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }

        private void CurrentStockLoad()
        { // for branch store status  GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)

            //   var proid = .GetProduct(0, "", int.Parse(ddlCateName.SelectedValue), 0, int.Parse(ddlCName.SelectedValue));

            var Quantitybr = SBLL.LoadCentralStockStatus(int.Parse(ddlCName.SelectedValue));

            // var stockquan = SBLL.GetProduct(Convert.ToInt16(ddlPName.SelectedValue), "", 0, 0, 0);

            if (Quantitybr.Count != 0)
            {
                if (Quantitybr.First().QuantityStore > 0)
                    txtCurrent.Text = Quantitybr.First().QuantityStore.ToString();
                else
                    txtCurrent.Text = "0";
            }
            else
            {
                txtCurrent.Text = "0";
            }
            var unit = PBLL.GetProduct(int.Parse(ddlCName.SelectedValue), "", 0, 0, 0);
            if (rbtSaleType.SelectedItem.Text.ToLower().Contains("bar"))
                txtPurPrice.Text = unit.First().ProductSalePrice.ToString();
            else
                txtPurPrice.Text = unit.First().ProductOffSalePrice.ToString();

        }

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Unit_productEntryPnl();
            CurrentStockLoad();
            //  Purchase_PriceLoad();
        }

        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Product_productEntryPnl();
            loadCompany();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAddToOrder();

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
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (!(!ddlCName.SelectedItem.ToString().ToLower().Contains("Guest".ToLower()) || !ddlCName.SelectedItem.ToString().ToLower().Contains("beka".ToLower()) || !ddlCName.SelectedItem.ToString().ToLower().Contains("Catering".ToLower()) || (!ddlCName.SelectedItem.ToString().ToLower().Contains("Restuarent".ToLower()) || !ddlCName.SelectedItem.ToString().ToLower().Contains("Cocktail".ToLower())) && Convert.ToDouble(txtCurrent.Text) < Convert.ToDouble(txtPQuality.Text)))
            {
                Show("Sales Quantity More than Available Quantity");
                return;
            }
            if (ddlCateName.SelectedItem.ToString().ToLower().Contains("Cockt".ToLower()))
            {
                var cock = cockBLL.GetCocktail(Convert.ToInt32(ddlCName.SelectedValue.ToString()), 0);
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
            else if (String.IsNullOrEmpty(txtPurPrice.Text) || txtPurPrice.Text == "0")
            {
                Show("Not Enough in Stock!");
                return;
            }
            else
            {
                tempDTO.MemberId = int.Parse(ddlMName.SelectedValue);
                tempDTO.Category = ddlCateName.SelectedItem.ToString();
                tempDTO.SubCategory = ddlCName.SelectedItem.ToString();
                tempDTO.ProductId = int.Parse(ddlCName.SelectedValue.ToString());
                tempDTO.Unit = double.Parse(ddlUnit.SelectedItem.ToString());
                tempDTO.PegSize = double.Parse(txtPQuality.Text);
                tempDTO.UnitPrize = double.Parse(txtPurPrice.Text);
                tempDTO.SaleType = rbtSaleType.SelectedItem.ToString();
                tempDTO.CreateDate = DateTime.Now;
                tempBLL.Add(tempDTO);

                /*Start quantity Deduct */




                var cocktail = cockBLL.GetCocktail(int.Parse(ddlCName.SelectedValue.ToString()), 0);
                if (cocktail.Count > 0)
                {

                    for (int j = 0; j < cocktail.Count; j++)
                    {
                        var Quantity = SBLL.LoadCentralStockStatus(int.Parse(cocktail[j].ItemProId.ToString()));
                        SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                        SDTO.ProductId = Convert.ToInt32(cocktail[j].ItemProId.ToString());
                        SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(txtPQuality.Text)));
                        // DetailDTO.ProductId = Convert.ToInt32(cock[j].ItemProId.ToString()); 
                        var detail = DetailBLL.GetdtlId(Convert.ToInt32(cocktail[j].ItemProId.ToString()), DateTime.Now.ToShortDateString());
                        if (detail.Count > 0)
                        {
                            DetailDTO.DtlId = detail.First().DtlId;
                            DetailDTO.ProductId = detail.First().ProductId;
                            DetailDTO.UsedQuantity = detail.First().UsedQuantity + (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(txtPQuality.Text));
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity) * double.Parse(txtPQuality.Text)));
                            DetailBLL.Edit(DetailDTO);
                        }
                        else
                        {
                            DetailDTO.ProductId = Convert.ToInt32(cocktail[j].ItemProId.ToString());
                            DetailDTO.TotalQuantity = Quantity.First().QuantityStore;
                            DetailDTO.UsedQuantity = Convert.ToDouble(cocktail[j].Quantity) * double.Parse(txtPQuality.Text);
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - (Convert.ToDouble(cocktail[j].Quantity)) * double.Parse(txtPQuality.Text));
                            DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                            DetailDTO.TodayStock = 0;
                            DetailBLL.Add(DetailDTO);
                        }
                        SBLL.EditStoreQty(SDTO);

                    }
                }
                else if (!ddlCateName.SelectedItem.Text.ToString().ToLower().Contains("extra"))
                {
                    var Quantity = SBLL.LoadCentralStockStatus(int.Parse(ddlCName.SelectedValue.ToString()));
                    if (Quantity.Count > 0)
                    {
                        SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                        SDTO.ProductId = Convert.ToInt32(int.Parse(ddlCName.SelectedValue.ToString()));
                        SDTO.QuantityStore = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(txtPQuality.Text));

                        var detail = DetailBLL.GetdtlId(int.Parse(ddlCName.SelectedValue.ToString()), DateTime.Now.ToShortDateString());
                        if (detail.Count > 0)
                        {
                            DetailDTO.DtlId = detail.First().DtlId;
                            DetailDTO.ProductId = detail.First().ProductId;
                            DetailDTO.UsedQuantity = detail.First().UsedQuantity + double.Parse(txtPQuality.Text);
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(txtPQuality.Text));
                            DetailBLL.Edit(DetailDTO);
                        }
                        else
                        {
                            DetailDTO.ProductId = int.Parse(ddlCName.SelectedValue.ToString());
                            DetailDTO.TotalQuantity = Quantity.First().QuantityStore;
                            DetailDTO.UsedQuantity = double.Parse(txtPQuality.Text);
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore - double.Parse(txtPQuality.Text));
                            DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                            DetailDTO.TodayStock = 0;
                            DetailBLL.Add(DetailDTO);
                        }

                        SBLL.EditStoreQty(SDTO);
                    }
                    else
                        Show("Not Enough in Stock!");
                }




                /* Finish quantity Deduct */



                if (ViewState["CurrentPurData"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    int count = dt.Rows.Count;

                    for (int i = 0; i < count; i++)
                    {
                        /*
                        if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
                        {
                            Show("Product Already Inserted  !");
                            return;
                        }
                         */
                    }
                    BindGrid(count);
                }
                else
                {
                    BindGrid(1);
                }

                pnlAction.Visible = true;
                ClearAddToOrder();
                AddPayable();
            }
        }
        public void ExtraBill()
        {
            /*
            double sum = 0;
            if (txtTotalPayable.Text == String.Empty || txtTotalPayable.Text == "0")
                sum = 0;
            else
                sum = double.Parse(txtTotalPayable.Text);
            if (txtCateBill.Text != String.Empty || txtCateBill.Text != "0")
                sum += double.Parse(txtCateBill.Text);
            if (txtRestBill.Text != String.Empty || txtRestBill.Text != "0")
                sum += double.Parse(txtRestBill.Text);
            if (txtBekary.Text != String.Empty || txtBekary.Text != "0")
                sum += double.Parse(txtBekary.Text);
            txtTotalPayable.Text = sum.ToString();
            txtPaidAmount.Text = sum.ToString();
            txtNetTotalPayable.Text = sum.ToString();
            VatCalculation();
            DiscountCalulation();
             */
        }

        public void AddPayable()
        {

            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {

                    sum += Convert.ToDouble(row.Cells[8].Text);
                }

                txtTotalPayable.Text = sum.ToString();

                txtNetTotalPayable.Text = sum.ToString();
                txtPaidAmount.Text = sum.ToString();
                ExtraBill();
            }
            else
            {
                txtTotalPayable.Text = "0";
                txtPaidAmount.Text = "0";
                txtNetTotalPayable.Text = "0";
            }
            // VatCalculation();

        }
        public void ClearAddToOrder()
        {
            Unit_productEntryPnl();
            // ddlPName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            ddlUnit.SelectedIndex = 0;
            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";


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

                    pnlAction.Visible = true;
                }
                AddPayable();
            }
        }

        private void BindGrid(int rowcount)
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
                dr[0] = ddlCName.SelectedValue.ToString();
                //       dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();

                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = txtPQuality.Text;
                dr[7] = txtPurPrice.Text;
                dr[8] = ddlUnit.SelectedItem.ToString();
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = ddlMName.SelectedValue;
                dr[11] = data.First().TempId;
                dr[12] = (double.Parse(txtPQuality.Text) * double.Parse(txtPurPrice.Text)).ToString();
                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                //        dr[0] = ddlPName.SelectedValue.ToString();
                //        dr[1] = ddlPName.SelectedItem.ToString();
                dr[0] = ddlCName.SelectedValue.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();

                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = txtPQuality.Text;
                dr[7] = txtPurPrice.Text;
                dr[8] = ddlUnit.SelectedItem.ToString();
                dr[9] = rbtSaleType.SelectedItem;
                dr[10] = ddlMName.SelectedValue;
                dr[11] = data.First().TempId;
                dr[12] = (double.Parse(txtPQuality.Text) * double.Parse(txtPurPrice.Text)).ToString();
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

            pnlAction.Visible = true;

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
        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {
            try
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
                        pnlAction.Visible = false;

                    }

                }
                AddPayable();
            }
            catch (Exception ex)
            {
                Show(ex.Message);

            }
        }




        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdoPayment.SelectedIndex == 0)
            {

                pnlBank.Visible = false;
                txtVatPercentage.Text = "";
                pnlVat.Visible = false;
                VatCalculation();
            }
            else
            {
                pnlBank.Visible = true;
                pnlVat.Visible = true;
                txtVatPercentage.Text = "0";
                VatCalculation();

            }


        }

        protected void txtVatPercentage_TextChanged(object sender, EventArgs e)
        {
            VatCalculation();

        }

        private void VatCalculation()
        {
            if (txtTotalPayable.Text == "")
                txtTotalPayable.Text = "0";
            if (txtVatPercentage.Text == "")
            {
                txtVatPercentage.Text = "0";
                txtVatAfterpercentage.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) * Convert.ToDouble(txtVatPercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text));
                txtDueAmount.Text = "0";
                // txtDicountpercentage.Text = "0";
                txtVatAfterpercentage.Text = "0";
                //txtDicountAfterpercentage.Text = "0";
            }
            else
            {
                txtVatAfterpercentage.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) * Convert.ToDouble(txtVatPercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text));
                txtDueAmount.Text = "0";

            }
        }
        protected void txtDicountpercentage_TextChanged(object sender, EventArgs e)
        {
            DiscountCalulation();
        }
        private void DiscountCalulation()
        {
            /*
            if (txtDicountpercentage.Text == "")
            {
                txtDicountpercentage.Text = "0";
                txtDicountAfterpercentage.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) * Convert.ToDouble(txtDicountpercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtDueAmount.Text = "0";
                txtDicountAfterpercentage.Text = "0";
            }
            else
            {

                txtDicountAfterpercentage.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) * Convert.ToDouble(txtDicountpercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtDueAmount.Text = "0";

            }
             * */
        }

        protected void BtnDiscountCal_Click(object sender, EventArgs e)
        {
            DiscountCalulation();
        }

        protected void BtnPaidAmount_Click(object sender, EventArgs e)
        {
            PaidAmount();
        }
        private void PaidAmount()
        {
            if (Convert.ToDouble(txtNetTotalPayable.Text) >= Convert.ToDouble(txtPaidAmount.Text))
            {
                txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text) - Convert.ToDouble(txtPaidAmount.Text));

            }
            else
            {
                txtDueAmount.Text = "0";
                txtPaidAmount.Text = txtNetTotalPayable.Text;
            }
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            PaidAmount();
        }

        protected void btnVatcalculation_Click(object sender, EventArgs e)
        {
            VatCalculation();
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SalInfoDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            SalInfoDTO.CreateDate = System.DateTime.Now;
            SalInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
            SalInfoDTO.CustomerName = txtCustomerName.Text;
            SalInfoDTO.CusMobileNo = txtMobileNo.Text;
            SalInfoDTO.CusContactAdd = txtContactAdd.Text;
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
            SalPayDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalPayDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            SalPayDTO.Discount = 0;
            SalPayDTO.TotalPrice = Convert.ToDouble(txtNetTotalPayable.Text);
            SalPayDTO.SalId = Salid;
            SalPayDTO.Vat = Convert.ToDouble(txtVatAfterpercentage.Text);
            SalPayDTO.DiscountDescription = txtDiscountDescription.Text;
            SaleBLL.SaveSalesPaymentInfo(SalPayDTO);
            SalpayDtlDTO.SalId = Salid;
            SalpayDtlDTO.PaymentMode = rdoPayment.SelectedValue.ToString();
            SalpayDtlDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalpayDtlDTO.Note = txtNote.Text;
            SalpayDtlDTO.PaymentDate = System.DateTime.Now;
            SalpayDtlDTO.PaymentBy = HttpContext.Current.User.Identity.Name;
            SalpayDtlDTO.CardNo = txtCardNo.Text;
            SalpayDtlDTO.ApprCode = txtApprCode.Text;
            SalpayDtlDTO.BankName = txtBankName.Text;
            SalpayDtlDTO.HolderName = txtHolderName.Text;
            SaleBLL.SaveSalesPaymentDtl(SalpayDtlDTO);
            tempBLL.Delete(int.Parse(HFMemberId.Value));
            ClearPaymentMode();
            LoadMember();
            Show("Sales Data Save Sucessfully");

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + Salid.ToString() + "');", true);
        }


        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearPaymentMode();
            ClearAddToOrder();
        }
        private void ClearPaymentMode()
        {
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            txtContactAdd.Text = "";
            //  txtRemarks.Text = "";
            txtApprCode.Text = "";
            txtBankName.Text = "";
            txtCardNo.Text = "";
            //  txtDicountAfterpercentage.Text = "0";
            //  txtDicountpercentage.Text = "";
            txtDueAmount.Text = "0";
            txtHolderName.Text = "";
            txtPaidAmount.Text = "";
            txtTotalPayable.Text = "0";
            txtVatAfterpercentage.Text = "0";
            txtVatPercentage.Text = "";
            txtNetTotalPayable.Text = "";
            pnlAction.Visible = false;

        }

        protected void ddlCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadCategory_productEntryPnl();
            //  loadCompany();


            if (ddlCateName.SelectedItem.Text.ToString().ToLower().Contains("extra".ToLower()))
                txtPurPrice.ReadOnly = false;
            else
                txtPurPrice.ReadOnly = false;

            CurrentStockLoad();

        }
        void LoadMember()
        {
            LoadmemDDL();
            var data = memBLL.GetOpenAccountMemeberList(txtContactAdd.Text, txtCustomerName.Text, txtMobileNo.Text, ddlSMemType.SelectedValue);

            GVMember.DataSource = data;
            GVMember.DataBind();
        }
        void SearchPagload()
        {
            if (RbtnSelectMode.SelectedItem.Value.ToString().ToLower() == "all")
            {
                var data = memBLL.GetMember(txtContactAdd.Text, txtCustomerName.Text, txtMobileNo.Text, ddlSMemType.SelectedValue, 0);
                GVMember.DataSource = data;
                GVMember.DataBind();
            }
            else
            {
                LoadMember();
            }
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Btn = 1;
            SearchPagload();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPQuality.Text = ddlUnit.SelectedItem.ToString();
        }

        protected void txtRestBill_TextChanged(object sender, EventArgs e)
        {
            /*
            if (txtTotalPayable.Text != "" || txtTotalPayable.Text.Length != 0)
            {
                txtTotalPayable.Text = (double.Parse(txtTotalPayable.Text) + double.Parse(txtRestBill.Text)).ToString();
                txtNetTotalPayable.Text = (double.Parse(txtNetTotalPayable.Text) + double.Parse(txtRestBill.Text)).ToString();
                txtPaidAmount.Text = txtNetTotalPayable.Text;
                DiscountCalulation();
                VatCalculation();
            }
            */
            ExtraBill();
        }


        protected void txtCateBill_TextChanged(object sender, EventArgs e)
        {
            /*
            if (txtTotalPayable.Text != "" || txtTotalPayable.Text.Length != 0)
            {
                txtTotalPayable.Text = (double.Parse(txtTotalPayable.Text) + double.Parse(txtCateBill.Text)).ToString();
                txtNetTotalPayable.Text = (double.Parse(txtNetTotalPayable.Text) + double.Parse(txtCateBill.Text)).ToString();
                txtPaidAmount.Text = txtNetTotalPayable.Text;
                DiscountCalulation();
                VatCalculation();
            }
             * */
            ExtraBill();
        }

        protected void txtBekary_TextChanged(object sender, EventArgs e)
        {
            ExtraBill();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Btn = 0;
            txtContactAdd.Text = "";
            txtMobileNo.Text = "";
            txtCustomerName.Text = "";
            LoadMember();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Admin/MemberUI.aspx');", true);
        }

        protected void rbtSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = PBLL.GetProduct(int.Parse(ddlCName.SelectedValue), "", 0, 0, 0);
            if (rbtSaleType.SelectedItem.Text.ToLower().Contains("bar"))
                txtPurPrice.Text = unit.First().ProductSalePrice.ToString();
            else
                txtPurPrice.Text = unit.First().ProductOffSalePrice.ToString();
        }
    }
}