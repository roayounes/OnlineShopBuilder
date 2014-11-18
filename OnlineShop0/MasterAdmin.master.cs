using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class MasterAdmin : System.Web.UI.MasterPage
{
    static string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        int idV=Convert.ToInt32(user);
        if (type != "v") {
            Response.Redirect("/OnlineShop0/Default00.aspx");
        }
        CompagnieTableAdapter cta = new CompagnieTableAdapter();
        int? ve = cta.ExistIDV(idV);
        if (ve == 0)
        {
            StoreName.Visible = false;
        }
        else
        {
            DataTable dtv = cta.GetDataByIDv(idV);
            string sn = dtv.Rows[0]["StoreName"].ToString();
            StoreName.InnerText = sn;
        }

    }
    protected void LogOut(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.SetAuthCookie("visiteur_0_0", true);
        Response.Redirect("Default00.aspx");
    }
    protected void ViewWb(object sender, EventArgs e)
    {
        Response.Redirect("~/Products_Photos/TemplateFreeDefault.aspx?SId="+ user);
    }
}
