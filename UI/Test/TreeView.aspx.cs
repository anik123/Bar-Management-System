using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;

namespace UI.Test
{
    public partial class TreeView : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CategoryDTO CDTO = new CategoryDTO();


        ProductDTO PDTO = new ProductDTO();
        ProductBLL PBLL = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //  Category category = new Category();
            List<CategoryDTO> categoryList = new List<CategoryDTO>();
            // categoryList = category.GetCategories();
            categoryList = CBLL.GetCategory(0, "");
            // Now it is time to populate the Tree View control 
            PopulateTreeViewControl(categoryList);
        }

        // This method is used to populate the TreeView Control 
        private void PopulateTreeViewControl(List<CategoryDTO> categoryList)
        {
            TreeNode parentNode = null;

            foreach (CategoryDTO category in categoryList)
            {
                parentNode = new TreeNode(category.CategoryName, category.CatId.ToString());

                List<ProductDTO> ProductList = new List<ProductDTO>();
                ProductList = PBLL.GetProduct_Categorywise(category.CatId,0);
                foreach (ProductDTO product in ProductList)
                {
                    TreeNode childNode = new TreeNode(product.ProductName, product.ProductId.ToString());

                    parentNode.ChildNodes.Add(childNode);
                }


                parentNode.Collapse();
                // Show all checkboxes 
                tvwRegionCountry.ShowCheckBoxes = TreeNodeTypes.All;
                tvwRegionCountry.Nodes.Add(parentNode);
            }
        }


        protected void tvwRegionCountry_TreeNodeCheckChanged(object sender, EventArgs e)
        {
        }








    }
}