using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

public partial class SearchResult : System.Web.UI.Page
{
    static string user = "", c;
    static int vid, searchID;
    static string vid0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;

        int idV = 0;
        string type = "x";
        string[] stringSeparators = new string[] { "_" };
        if (source != null)
        {
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            type = result[0];
            user = result[1];
            c = result[2];
            idV = Convert.ToInt32(user);
        }


        vid0 = "";
        vid0 = Request.QueryString["SId"];
        if (vid0 == null)
        {
            Response.Redirect("../Default00.aspx");
        }

        vid = Convert.ToInt32(vid0);

        string searchID0 = "";
        searchID0 =Request.QueryString["SearchID"];
        if(searchID0==null)
        {
            Response.Redirect("TemplateFreeDefault.aspx?SId=" + vid0);
        }
        searchID = Convert.ToInt32(searchID0);
        NEWSearchTableAdapter nsta = new NEWSearchTableAdapter();
        DataTable dtns = nsta.GetSearchWords(searchID);
        string sw0=dtns.Rows[0]["SearchWord"].ToString();
        SearchWords.Text = sw0;
        SearchResultTableAdapter srta = new SearchResultTableAdapter();
        DataTable dtsr = srta.GetProdsBySearchID(searchID);
        SearchResults.Text = "<div class=\"row\">";
        foreach (DataRow pr in dtsr.Rows)
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
            SearchResults.Text += " <div class=\"col-sm-4 col-lg-4 col-md-4\">" +
                       " <div class=\"thumbnail\"  >" +
                       "<div style=\"height:200px\" align=\"middle\"><img src=\"" + ip + "\" alt=\"\" "+wh+"  /> </div>" +
                           " <div class=\"caption\"> ";
            SearchResults.Text += "<h4 class=\"pull-right\">" + pp + "$</h4>";
            SearchResults.Text += "<h4><a id=\"Prod\" title=\"" + pid + "\"href=\"../TemplateFreeViewProduct.aspx?" + SId_PId + "\"  onclick=\"Click_Link\">" + pn + "</a></h4>";
            SearchResults.Text += "<p>" + pdesc + "</p></div>";
            SearchResults.Text += "<div class=\"ratings\">" +
                             "   <p class=\"pull-right\">15 reviews</p>" +
                                "<p>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" +
                                    "<span class=\"glyphicon glyphicon-star\"></span>" + " </p> </div> </div></div>";


        }

    
    }
}