using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class TemplateFreeDefault : System.Web.UI.Page
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
        string vid0 = "";
        vid0 = Request.QueryString["SId"];
        if (vid0==null)
        {
            Response.Redirect("../Default00.aspx");
        }

        int vid = Convert.ToInt32(vid0);
        ProduitsTableAdapter pt = new ProduitsTableAdapter();
        DataTable pd = pt.GetProdByStore(vid);
        Products.Text="<div class=\"row\">";
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
            string wh = "style=\"height:200px\" ";
            string SId_PId = "SId="+vid0 + "&PId=" + pid;
            if(ActualHeight>ActualWidth)
            {
                wh="style=\"max-width:200px\"" ;

            }
            Products.Text += " <div class=\"col-sm-4 col-lg-4 col-md-4\">" +
                       " <div class=\"thumbnail\"  >" +
                       "<div style=\"height:200px\" align=\"middle\"><img src=\"" + ip + "\" alt=\"\" "+wh+"  /> </div>" +
                           " <div class=\"caption\"> ";
            Products.Text += "<h4 class=\"pull-right\">" + pp + "$</h4>";
            Products.Text += "<h4><a id=\"Prod\" title=\"" + pid + "\"href=\"../TemplateFreeViewProduct.aspx?" + SId_PId + "\"  onclick=\"Click_Link\">" + pn + "</a></h4>";
            Products.Text += "<p>" + pdesc + "</p></div>";
            Products.Text += "<div class=\"ratings\">" +
                             "   <p class=\"pull-right\">15 reviews</p>" +
                                "<p>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" + " </p> </div> </div></div>";


        }

        string img1 = pd.Rows[0]["ImgProd"].ToString();
        //Image1.ImageUrl = "~/Products_Photos/" + img1;
        //logoImg.Src = "~/Products_Photos/" + img1;
    }
    protected void Click_Link(object sender, EventArgs e)
    {
        
    }
}