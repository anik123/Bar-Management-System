using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using OnBarcode.Barcode;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;

namespace UI.Admin
{
    public partial class BarCodeEmpPopUp : System.Web.UI.Page
    {
        ProductBLL PBLL = new ProductBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              //  RoleName();
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
        public void LoadData()
        {
            var data = PBLL.GetProduct(Convert.ToInt32(HFEmpId.Value), "", 0,0,0);

            txtProductId.Text = data.First().ProductId.ToString();
            txtProductName.Text = data.First().ProductName.ToString();
            txtCategoryName.Text = data.First().CategoryName.ToString();
            txtUnit.Text = data.First().UnitName.ToString();
            txtProductCode.Text = data.First().ProductName.ToString();
            txtPrice.Text = data.First().ProductSalePrice.ToString();

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
            try
            {
                Linear barcode = new Linear();                        // Create linear barcode object  
                barcode.Type = OnBarcode.Barcode.BarcodeType.CODE39;  // Set barcode symbology type to Code-39

                string barcodesdata = txtProductId.Text;
                barcode.Data = barcodesdata;                          // Set barcode data to encode
                barcode.TopMargin = 30;
                barcode.BottomMargin = 30;
                barcode.X = 1;
                barcode.Y = 75;
                barcode.ShowText = false;
                barcode.Format = System.Drawing.Imaging.ImageFormat.Jpeg;
                string FileName = txtProductId.Text + ".jpeg";
                barcode.drawBarcode(MapPath(@"~/Admin/ProductBarcode/") + FileName);// temporary file upload link

                // barcode.drawBarcode(MapPath(@"~/Admin/ProductBarcodeBackUp/") + FileName);// for back up file link
                //start

                System.Byte[] imgTitle = generateDynamicTitle();
                MemoryStream memStream = new MemoryStream(imgTitle);
                Bitmap title = new Bitmap(memStream);
                title.Save(Server.MapPath(@"~/Admin/ProductBarcode/title.jpg"), ImageFormat.Jpeg);

                System.Byte[] imgFooter = generateDynamicFooter();
                MemoryStream memStream2 = new MemoryStream(imgFooter);
                Bitmap footer = new Bitmap(memStream2);
                footer.Save(Server.MapPath(@"~/Admin/ProductBarcode/footer.jpg"), ImageFormat.Jpeg);

                string strImagePath1 = Server.MapPath(@"~/Admin/ProductBarcode/" + FileName);
                string strImagePath2 = Server.MapPath(@"~/Admin/ProductBarcode/title.jpg");
                string strImagePath3 = Server.MapPath(@"~/Admin/ProductBarcode/footer.jpg");

                System.Drawing.Image img = System.Drawing.Image.FromFile(strImagePath1);
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(System.Drawing.Image.FromFile(strImagePath2), new Point(10, 5));
                g.DrawImage(System.Drawing.Image.FromFile(strImagePath3), new Point(5, 122));
                g.Dispose();
                img.Save(Server.MapPath(@"~/Admin/ProductBarcode/" + txtProductId.Text + ".jpg"), ImageFormat.Jpeg);
                img.Save(MapPath(@"~/Admin/ProductBarcodeBackUp/" + txtProductId.Text + ".jpg"), ImageFormat.Jpeg);

                img.Dispose();
                //end
                Image1.ImageUrl = "../Admin/ProductBarcode/" + txtProductId.Text + ".jpg";
                txtImageFileName.Text = txtProductId.Text + ".jpg";
                File.Delete(Server.MapPath(@"~/Admin/ProductBarcode/" + FileName));
            }
            catch (Exception ex)
            {
            }

        }
        private void margeimages(string filename)
        {
            try
            {
                System.Byte[] imgTitle = generateDynamicTitle();
                MemoryStream memStream = new MemoryStream(imgTitle);
                Bitmap title = new Bitmap(memStream);
                title.Save(Server.MapPath(@"~/Admin/ProductBarcode/title.jpg"), ImageFormat.Jpeg);
                System.Byte[] imgFooter = generateDynamicFooter();
                MemoryStream memStream2 = new MemoryStream(imgFooter);
                Bitmap footer = new Bitmap(memStream2);
                footer.Save(Server.MapPath(@"~/Admin/ProductBarcode/footer.jpg"), ImageFormat.Jpeg);
                string strImagePath1 = Server.MapPath(@"~/Admin/ProductBarcode/" + filename);
                string strImagePath2 = Server.MapPath(@"~/Admin/ProductBarcode/title.jpg");
                string strImagePath3 = Server.MapPath(@"~/Admin/ProductBarcode/footer.jpg");
                 System.Drawing.Image img = System.Drawing.Image.FromFile(strImagePath1);
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(System.Drawing.Image.FromFile(strImagePath2), new Point(70, 15));
                g.DrawImage(System.Drawing.Image.FromFile(strImagePath3), new Point(70, 195));
                g.Dispose();
               img.Save(Server.MapPath(@"~/Admin/ProductBarcode/" + filename), ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

            }
        }
        

    private byte[] generateDynamicFooter()
    {
        MemoryStream ms = new MemoryStream();
        Bitmap oBmp1 = new Bitmap(130, 25);
        Graphics oGrp1 = Graphics.FromImage(oBmp1);
        System.Drawing.Color ocolor = new Color();
        string sFooterText = "Price: Tk-"+txtPrice.Text;
        ocolor = Color.White;
        SolidBrush oBrush = new SolidBrush(ocolor);
        SolidBrush oBrushWrite = new SolidBrush(Color.Black);
        oGrp1.FillRectangle(oBrush, 0, 0, 130, 25);
        Font oFont = new Font("Ariel", 10);
        PointF oPoint = new PointF(15F, 1F);
        oGrp1.DrawString(sFooterText, oFont, oBrushWrite, oPoint);
        oBmp1.Save(ms, ImageFormat.Jpeg);
        oBmp1.Dispose();
        return ms.GetBuffer(); 
    }

    private byte[] generateDynamicTitle()
    {
        MemoryStream ms = new MemoryStream();
        Bitmap oBmp1 = new Bitmap(130, 25);
        Graphics oGrp1 = Graphics.FromImage(oBmp1);
        System.Drawing.Color ocolor = new Color();
        string sTitleText = txtProductCode.Text;
        ocolor = Color.White;
        SolidBrush oBrush = new SolidBrush(ocolor);
        SolidBrush oBrushWrite = new SolidBrush(Color.Black);
        oGrp1.FillRectangle(oBrush, 0, 0, 130, 25);
        Font oFont = new Font("Ariel", 10);
        PointF oPoint = new PointF(15F, 1F);
        oGrp1.DrawString(sTitleText, oFont, oBrushWrite, oPoint);
        oBmp1.Save(ms, ImageFormat.Jpeg);
        oBmp1.Dispose();
        return ms.GetBuffer();
    }   
        
    
        // start  file download
        protected  void btnDownload_Click(object sender, EventArgs e)
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