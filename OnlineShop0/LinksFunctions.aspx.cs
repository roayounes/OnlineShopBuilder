using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class LinksFunctions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SId_PId="+user+"&cid="+c+"&pqt="+pqt+"&pid="+pid+"
        string[] stringSeparators = new string[] { "_" };
        string vid0 = "";
        string s = Request.QueryString["SId_PId"];
        if (s == null)
        {
            Response.Redirect("../Default00.aspx");
        }
        else
        {
            string[] result1;
            result1 = s.Split(stringSeparators, StringSplitOptions.None);
            vid0 = result1[0];
        }
        int vid = Convert.ToInt32(vid0);
        string cid0 = Request.QueryString["cid"];
        int cid = Convert.ToInt32(cid0);
        string pqt0 = Request.QueryString["pqt"];
        int pqt = Convert.ToInt32(pqt0); 
        string pid0 = Request.QueryString["pid"];
        int pid = Convert.ToInt32(pid0);


    }
}