using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LaunchStore : System.Web.UI.Page
{
    static string user;

    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        if (source == null)
        {
            Response.Redirect("/OnlineShop0/Default00.aspx");
        }
        string[] stringSeparators = new string[] { "_" };
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        //if (type != "v")
        //{
        //    Response.Redirect("/OnlineShop0/Default00.aspx");
        //}
        

    }


    protected void ViewWebsite_Click(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);
        string linkShop = "~/Products_Photos/TemplateFreeDefault.aspx?SId="+idV;
        Response.Redirect(linkShop);
    }
}