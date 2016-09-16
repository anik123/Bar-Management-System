using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using OnBarcode.Barcode;

namespace UI.Admin
{
    public partial class BarCodeEmpPopUp : System.Web.UI.Page
    {
        ProductBLL PBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ProductId = Request.QueryString["ProductId"];
                HFEmpId.Value = ProductId;
                if (ProductId != "")
                {
                    LoadData();
                    // ReadDataFromXmlFile();
                    BarcodeGeneration();
                }
            }
        }

        public void LoadData()
        {
            var data = PBLL.GetProduct(Convert.ToInt32(HFEmpId.Value), "", 0,0,0);

            txtProductId.Text = data.First().ProductId.ToString();
            txtProductName.Text = data.First().ProductName.ToString();
            txtCategoryName.Text = data.First().CategoryName.ToString();
            txtUnit.Text = data.First().UnitName.ToString();

        }

        ////readxml file
        //public void ReadDataFromXmlFile()
        //{
        //    XmlDocument xml = new XmlDocument();
        //    string xamalpathe = Server.MapPath("/XMLFile/BarCodeHeadTypeXml.xml");
        //    xml.Load(xamalpathe);

        //    XmlNodeList nodeList;
        //    XmlNode root = xml.DocumentElement;

        //    string node = "Employee";
        //    nodeList = root.SelectNodes(node);
        //    foreach (XmlNode book in nodeList)
        //    {
        //        lblXmlHeadId.Text = book.LastChild.InnerText;

        //    }
        //}

        // bar code generation
        public void BarcodeGeneration()
        {
            Linear barcode = new Linear();                        // Create linear barcode object  
            barcode.Type = OnBarcode.Barcode.BarcodeType.CODE39;  // Set barcode symbology type to Code-39

            string barcodesdata =  txtProductId.Text;
            barcode.Data = barcodesdata;                          // Set barcode data to encode

            barcode.Format = System.Drawing.Imaging.ImageFormat.Jpeg;

            string FileName = txtProductId.Text + ".Jpeg";
            barcode.drawBarcode(MapPath(@"~/Admin/ProductBarcode/") + FileName);// temporary file upload link
            Image1.ImageUrl = "../Admin/ProductBarcode/" + FileName;
            barcode.drawBarcode(MapPath(@"~/Admin/ProductBarcodeBackUp/") + FileName);// for back up file link
            txtImageFileName.Text = FileName;
        }


        // start  file download
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string strFolder = "../Admin/ProductBarcode/";
            string txtdata = txtImageFileName.Text;
            string filePath = Path.Combine(strFolder, txtdata);
            DownloadFile(filePath);
        }
        public void DownloadFile(string filePath)
        {
            if (File.Exists(Server.MapPath(filePath)))
            {
                string strFileName = Path.GetFileName(filePath).Replace(" ", "%20");
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
                Response.Clear();
                Response.WriteFile(Server.MapPath(filePath));
                Response.End();
            }
        } // End  file download


        public void Close()
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}