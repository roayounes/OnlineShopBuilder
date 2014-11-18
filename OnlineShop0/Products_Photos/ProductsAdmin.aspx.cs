using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Products_Photos_ProductsAdmin : System.Web.UI.Page
{
    static string user;

    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        if (source != null)
        {

            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string type = result[0];
            user = result[1];
            string c = result[2];
            int idV = Convert.ToInt32(user);
        }

        int vid = Convert.ToInt32(user);
        ProduitsTableAdapter pt = new ProduitsTableAdapter();
        DataTable pd = pt.GetProdByStore(vid);
        Products.Text = "<table class=\"table\">";
        foreach (DataRow pr in pd.Rows)
        {
            string pn = pr["ProduitNom"].ToString();
            string pdesc = pr["Desc"].ToString();
            string pp = pr["Prix"].ToString();
            string ip = pr["ImgProd"].ToString();
            string pid = pr["ProduitID"].ToString();
            string PicturePath = Server.MapPath(ip);
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(PicturePath);
            int ActualWidth = image1.Width;
            int ActualHeight = image1.Height;
            string wh = "style=\"height:170px\" ";
            string SId_PId = "SId=" + user + "&PId=" + pid;
            if (ActualHeight > ActualWidth)
            {
                wh = "style=\"max-width:170px\"";

            }
            Products.Text += "<tr><td style=\"max-width:600px\">" +
 "<div class=\"media\">" +
    "<a class=\"pull-left\" href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&PId=" + pid + "\">" +
      "  <img class=\"media-object\" src=\"" + ip + "\" " + wh + " alt=\"" + pdesc + "\">" +
    "</a>" +
   "<div class=\"media-body\">" +
      " <h4 class=\"media-heading\"><a href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&pqt=" + "&PId=" + pid + "\">" + pn + " </a></h4>" +
     "Price:" + pp + "$<br />" + pdesc +
     "<br />"+
     "<a href=\"/OnlineShop0/UpdateProd.aspx?PId=" + pid + "\">Update</a>" +
   "</div>" +
"</div></td>" +
"</tr>";



        }

        string img1 = pd.Rows[0]["ImgProd"].ToString();
        //Image1.ImageUrl = "~/Products_Photos/" + img1;
        //logoImg.Src = "~/Products_Photos/" + img1;
    }
    protected void Click_Link(object sender, EventArgs e)
    {

    }
    protected void AddMore_Click(object sender, EventArgs e)
    {
        Response.Redirect("/OnlineShop0/Create_Comp_Step3.aspx");
    }
}