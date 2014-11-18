using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;
using System.Globalization;


public partial class FreeTemplateSignUp : System.Web.UI.Page
{
    static int vid;
    static string vid0;
    protected void Page_Load(object sender, EventArgs e)
    {
        vid0 = "";
        string[] stringSeparators = new string[] { "_" };
        vid0 = Request.QueryString["SId"];
        if (vid0 == null)
        {
            Response.Redirect("../Default00.aspx");
        }
        vid = Convert.ToInt32(vid0);
        if (!IsPostBack)
  {
    //Populate DropDownLists
    ddlMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
    {
      MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(a),
      MonthNumber = a
    });
    ddlMonth.DataBind();
    ddlYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse();
    ddlYear.DataBind();
    ddlday.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlMonth.SelectedValue)));
    ddlday.DataBind();
  }
}
protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
{
  ddlday.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlMonth.SelectedValue)));
  ddlday.DataBind();
}

protected void SignUp0_Click(object sender, EventArgs e)
{
    ClientTableAdapter cta = new ClientTableAdapter();
    DataTable dtc = cta.GetByVidEmail(EmailC.Text, vid);
    int c = dtc.Rows.Count;
    if (c != 0)
    {
        Labelerror.Text = "Email already exist";
        Labelerror.Visible = true;
    }
    else
    {
        string ddn0 = ddlMonth.Text + "/" + ddlday.Text + "/" + ddlYear.Text;
        DateTime ddn = Convert.ToDateTime(ddn0);
        cta.Insert(EmailC.Text, PassC.Text, ddlCountry.Text, Ln.Text, Fn.Text, ddn, sex.SelectedValue, DateTime.Now, vid);
        dtc = cta.GetByVidEmail(EmailC.Text, vid);
        string c0 = dtc.Rows[0]["ClientID"].ToString();
        int cID = Convert.ToInt32(c0);
        //int? vID = va.GetVdID(emailV.Text);
        string user = "c_" + vid0 + "_"+ cID;
        FormsAuthentication.SetAuthCookie(user, true);
        Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId=" + vid0 );
        //Label1.Text = Page.User.Identity.Name;
        //Label2.Text = user;
    }
}
}
