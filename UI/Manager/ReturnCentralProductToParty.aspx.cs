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

namespace UI.Manager
{
    public partial class ReturnCentralProductToParty : System.Web.UI.Page
    {
        CompanyBLL compBLL = new CompanyBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        InvenCentralToPartyReturnDtlBLL CenPartyBLL = new InvenCentralToPartyReturnDtlBLL();
        InvenCentralToPartyReturnDtlDto CenPartyDto = new InvenCentralToPartyReturnDtlDto();


        // Sales  
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalpayDtlDTO = new InvenSalePaymentDtlDto();
        //strore central
        InvenCentralStoreStatusBLL CNStoreBLL = new InvenCentralStoreStatusBLL();
        InvenCentralStoreStatusDTO CNStoreDTO = new InvenCentralStoreStatusDTO();

        // jopurnal
        JournalDTO JDTO = new JournalDTO();
        JournalBLL JBLL = new JournalBLL();

        // transection dtl 
        TransDetailsBLL TranBLL = new TransDetailsBLL();
        TransDetailsDTO TranDTO = new TransDetailsDTO();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Page.Title = "Return To Central";
                GetBranchId();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
                // Unit_productEntryPnl();
            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            LoadProductGridView();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                TextBox txtreturn = (TextBox)row.FindControl("txtReturnToCenteral");
                txtreturn.Text = "";
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

        public void LoadProductGridView()
        {


            var pp = PBLL.GetProductForCentralReturn(Convert.ToInt16(ddlCName.SelectedValue), Convert.ToInt16(ddlCateName.SelectedValue), Convert.ToInt16(ddlPName.SelectedValue));
            if (pp.Count != 0)
            {
                PnlGridView.Visible = true;
                PnlAction.Visible = true;
            }
            else
            {
                PnlAction.Visible = false;

                PnlGridView.Visible = false;
                Show(" No Data Found !");
            }
            GvUpdate.DataSource = pp;
            GvUpdate.DataBind();

        }

        protected void ddlCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategory_productEntryPnl();
        }

        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_productEntryPnl();
        }

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SearchClearControl();
        }

        private void SearchClearControl()
        {


            GvUpdate.DataSource = null;
            GvUpdate.DataBind();


            GvUpdate.SelectedIndex = -1;
            PnlGridView.Visible = false;
            PnlAction.Visible = false;
            ddlCateName.SelectedIndex = -1;
            ddlCName.SelectedIndex = -1;
            ddlPName.SelectedIndex = -1;

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

            ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        private void LoadCategory_productEntryPnl()
        {
            var query = PBLL.GetProduct_Category(0, Convert.ToInt16(ddlCName.SelectedValue));

            // var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.ToList().Distinct();
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Product", "0"));
        }

        private void Product_productEntryPnl()
        {
            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), Convert.ToInt16(ddlCName.SelectedValue));
            ddlPName.DataSource = query.OrderBy(Items => Items.ProductName);
            ddlPName.DataTextField = "ProductName";
            ddlPName.DataValueField = "ProductId";
            ddlPName.DataBind();
            ddlPName.Items.Insert(0, new ListItem("Select Product Code", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlCName.SelectedIndex == 0 || ddlCName.SelectedIndex == -1)
            {
                Show("Please Select Company");
                return;
            }
            else
            {

                try
                {
                    string empusername = HttpContext.Current.User.Identity.Name;
                    var brid = empBLL.GetCurrentUserBranchName(empusername);


                    foreach (GridViewRow row in GvUpdate.Rows)
                    {
                        TextBox txtreturn = (TextBox)row.FindControl("txtReturnToCenteral");
                        //TextBox txtRate = (TextBox)row.FindControl("txtRateOfInterest");
                        // TextBox txtSalePrice = (TextBox)row.FindControl("txtSalePrice");

                        if (txtreturn.Text != "" && row.Cells[5].Text != "")
                        {
                            if (int.Parse(txtreturn.Text) > int.Parse(row.Cells[5].Text))
                            {
                                Show(" You Can't Return More than Current Quantity");
                            }
                            else
                            {
                                var incenStore = CNStoreBLL.LoadCentralStockStatus(int.Parse(row.Cells[3].Text));

                                //  var inStoreSts = BrStoreBLL.GetStoreStatusByProId(int.Parse(row.Cells[3].Text), int.Parse(HFBranceId.Value));

                                if (incenStore.Count() > 0)
                                {
                                    int cnQnty = int.Parse(incenStore.First().QuantityStore.ToString());

                                    // int bnQnty = int.Parse(inStoreSts.First().QuantityStore.ToString());


                                    //BrStoreDTO.QuantityStore = bnQnty - int.Parse(txtreturn.Text);
                                    //BrStoreDTO.ProductId = int.Parse(row.Cells[3].Text);
                                    //BrStoreDTO.InvenStoreId = inStoreSts.First().InvenStoreId;
                                    CNStoreDTO.QuantityStore = cnQnty - int.Parse(txtreturn.Text);
                                    CNStoreDTO.ProductId = int.Parse(row.Cells[3].Text);
                                    CNStoreDTO.CentralStoreId = incenStore.First().CentralStoreId;

                                    CNStoreBLL.EditCenQty(CNStoreDTO);

                                    CenPartyDto.reBy = HttpContext.Current.User.Identity.Name;
                                    CenPartyDto.reCompId =int.Parse(ddlCName.SelectedValue);
                                    CenPartyDto.reDate = DateTime.Now.Date;
                                    CenPartyDto.reProAmount = int.Parse(txtreturn.Text) * int.Parse(row.Cells[4].Text);
                                    CenPartyDto.reProBranchId = int.Parse(brid.First().BrProId.ToString());
                                    CenPartyDto.reProId = int.Parse(row.Cells[3].Text);
                                    CenPartyDto.reQty = int.Parse(txtreturn.Text);
                                    CenPartyBLL.Add(CenPartyDto);

                                    SearchClearControl();
                                    Show("Return Successfull");
                                }
                                else
                                {
                                    Show("Selected Product not from your barnch");
                                }
                            }

                        }


                    }
                }
                catch (Exception ex)
                {

                    Show(ex.Message);
                }

            }

        }
      



    }
}