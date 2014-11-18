using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class MasterPage00 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SignIn_Click(object sender, EventArgs e)
    {
        VendeurTableAdapter vta=new VendeurTableAdapter();
        DataTable dtv = vta.GetVid(Email.Text, Pass.Text);
        if (dtv.Rows.Count == 0)
        {
            Error.Visible = true;
        }
        else
        {
            String user = dtv.Rows[0]["VendeurID"].ToString();
            int idv = Convert.ToInt32(user);
            user = "v_" + user + "_0";
            FormsAuthentication.SetAuthCookie(user, true);
            Response.Redirect("Dashboard.aspx");

        }

    }
}
