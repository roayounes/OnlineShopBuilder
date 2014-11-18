using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;


public partial class TemplateFreeAbout : System.Web.UI.Page
{
    static string vid0;
    static int vid;
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
        CompagnieTableAdapter ct = new CompagnieTableAdapter();
        DataTable dc = ct.GetDataByIDv(vid);
        string desc = dc.Rows[0]["Description"].ToString();
        About.Text = desc;
    }
}