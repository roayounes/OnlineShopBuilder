using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Products_Photos_AllProd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProduitsTableAdapter pd0 = new ProduitsTableAdapter();
        DataTable pd = pd0.GetProducts();
        //Products.Text = "<div class=\"row\">";
        Products.Text = "<table>";
        Products.Text += "<tr><th>Product Name</th><th>Product Description</th></tr>";
        foreach (DataRow pr in pd.Rows)
        {
            string pn = pr["ProduitNom"].ToString();
            string pdesc = pr["Desc"].ToString();
            string pp = pr["Prix"].ToString();
            string ip = pr["ImgProd"].ToString();
            string pid = pr["ProduitID"].ToString();
            string vid0 = pr["VendeurID"].ToString();
            string PicturePath = Server.MapPath(ip);
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(PicturePath);
            int ActualWidth = image1.Width;
            int ActualHeight = image1.Height;
            string wh = "style=\"height:100px\" ";
            string SId_PId = "SId=" + vid0 + "&PId=" + pid;
            if (ActualHeight > ActualWidth)
            {
                wh = "style=\"max-width:100px\"";

            }
            Products.Text += "<tr><td><img src=\"" + ip + "\" alt=\"\" " + wh + "  /></td><td>Name :" + "<a id=\"Prod\" title=\"" + pid + "\"href=\"../TemplateFreeViewProduct.aspx?" + SId_PId + "\"  onclick=\"Click_Link\">" + pn + "</a></h4>" + "<br /> Price :" + pp + "<br />Desc :" + pdesc + "<br /></td></tr>";

        }
        Products.Text+="</table>";

    }
}