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

public partial class Settings : System.Web.UI.Page
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
        int idV = Convert.ToInt32(user);
        if (type != "v")
        {
            Response.Redirect("/OnlineShop0/Default00.aspx");
        }
        VendeurTableAdapter vta = new VendeurTableAdapter();
        DataTable dtv = vta.GetDataVByVid(idV);
        CompagnieTableAdapter cta = new CompagnieTableAdapter();
        DataTable dtc = cta.GetDataByIDv(idV);
        sn.Text = dtc.Rows[0]["StoreName"].ToString();
        Email.Text = dtv.Rows[0]["Email"].ToString();
        sc.Text = dtv.Rows[0]["Pays"].ToString();
        sp.Text = dtv.Rows[0]["Telephone"].ToString();
        mn.Text = dtc.Rows[0]["Directeur"].ToString();
        sd.Text = dtc.Rows[0]["Description"].ToString();
        sw.Text = dtc.Rows[0]["Website"].ToString();
        fp.Text = dtc.Rows[0]["Pagefb"].ToString();
        mp.Text = dtc.Rows[0]["DirecteurPhone"].ToString();
    }
}