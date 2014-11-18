using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;


public partial class Products_Photos_TemplateFreeMyCart : System.Web.UI.Page
{
    static string user,c,vid0,ct0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //pour avoir les info sur le client
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        if (source != null)
        {
            
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string type = result[0];
            user = result[1];
            c = result[2];
            int idV = Convert.ToInt32(user);
        }

        //Pour savoir c'est qu'elle store
        vid0 = "";
        vid0 = Request.QueryString["SId"];
        if (vid0==null)
        {
            Response.Redirect("../Default00.aspx");
        }
        int vid = Convert.ToInt32(vid0);

        //Pour faire display lal cart
        ClientCartTableAdapter ccta = new ClientCartTableAdapter();
        DataTable dtcc = ccta.GetDataByCartID(Convert.ToInt32(c));
        if (dtcc != null)
        {
            YourCart.Text = "<table class=\"table\">";
            foreach (DataRow pr in dtcc.Rows)
            {
                string pn = pr["ProduitNom"].ToString();
                string pdesc = pr["Desc"].ToString();
                string pp = pr["Prix"].ToString();
                string ip = pr["ImgProd"].ToString();
                string pid = pr["ProduitID"].ToString();
                string pqt = pr["quantite"].ToString();
                string PicturePath = Server.MapPath(ip);
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(PicturePath);
                int ActualWidth = image1.Width;
                int ActualHeight = image1.Height;
                string wh = "style=\"max-width:200px\"";
                string SId_PId = "SId="+vid0 + "&PId=" + pid;
                if (ActualHeight > ActualWidth)
                {
                    wh = "style=\"max-width:200px\"";

                }
                YourCart.Text += "<tr><td style=\"max-width:600px\">" +
                 "<div class=\"media\">" +
                    "<a class=\"pull-left\" href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&pqt=" + pqt + "&PId=" + pid + "\">" +
                      "  <img class=\"media-object\" src=\"" + ip + "\" " + wh + " alt=\"" + pdesc + "\">" +
                    "</a>" +
                   "<div class=\"media-body\">" +
                      " <h4 class=\"media-heading\"><a href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&pqt=" + pqt + "&PId=" + pid + "\">" + pn + " </a>" + pqt + "</h4>" +
                     "Price:" + pp + "$<br />" + pdesc +
                   "</div>" +
                "</div></td>" +
                "<td style=\"max-width:600px\">" +
   "<a href=\"../TemplateFreeViewProduct.aspx?SId="+user+"&pqt="+pqt+"&PId="+pid+"\" >Buy Product</a><br/><br/>" +
   "<a href=\"#\">Remove From Cart</a>" +
"</tr>";

            }
            YourCart.Text += "</table>";

            //Pour permettre d'acheter tous les prod de la cart
            double? ct = ccta.GetTotalCart(Convert.ToInt32(c));
            ct0 = ct.ToString();
            TotalPrice.Text = ct0+"$";
            carttotal.Visible = true;

        }
        
        
            
    }

    protected void BuyAllCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuyAllCart.aspx?SId=" + vid0);
    }
}