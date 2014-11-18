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

public partial class Temp2_Temp2Master : System.Web.UI.MasterPage
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
        if ((type == "c") && (vid == idV))
        {
           // SignOut.Visible = true;
        }
        TempInfo0TableAdapter ti = new TempInfo0TableAdapter();
        DataTable tf = ti.GetDataByStoreID(vid);
        string img1 = "~/Cover Photos/" + tf.Rows[0]["Param1"].ToString();
        string img2 = "~/Cover Photos/" + tf.Rows[0]["Param2"].ToString();
        string img3 = "~/Cover Photos/" + tf.Rows[0]["Param3"].ToString();
        //Cover1.ImageUrl = img1;
        //Cover2.ImageUrl = img2;
        //Cover3.ImageUrl = img3;
        //StoreName.InnerText = "abc";
        CompagnieTableAdapter ct = new CompagnieTableAdapter();
        DataTable cd = ct.GetDataByIDv(vid);
        string sn = cd.Rows[0]["StoreName"].ToString();
        //StoreName.InnerText = sn;

    }
    protected void signUpPage(object sender, EventArgs e)
    {
        string sulk = "/OnlineShop0/FreeTemplateSignUp.aspx?SId=" + vid;
        Response.Redirect(sulk);
    }
    protected void LogOut(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.SetAuthCookie("visiteur_0_0", true);
        Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId=" + vid0);

    }
    protected void goToCart(object sender, EventArgs e)
    {
        Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeMyCart.aspx?SId=" + vid0);
    }
    protected void goToHome(object sender, EventArgs e)
    {
        Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId=" + vid0);
    }
}
