using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;


public partial class Contact : System.Web.UI.Page
{
    static string vid0,user,c,type;
    static int vid,cid;
    protected void Page_Load(object sender, EventArgs e)
    {
        vid0 = "";
        string[] stringSeparators = new string[] { "_" };
        string source = Page.User.Identity.Name;
        if (source != null)
        {

            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            type = result[0];
            user = result[1];
            c = result[2];
            int idV = Convert.ToInt32(user);
        }
        vid0 = Request.QueryString["SId"];
        if (vid0 == null)
        {
            Response.Redirect("../Default00.aspx");
        }
        vid = Convert.ToInt32(vid0);
        cid = Convert.ToInt32(c);
        VendeurTableAdapter vta = new VendeurTableAdapter();
        DataTable dtv = vta.GetDataVByVid(vid);
        string email = dtv.Rows[0]["Email"].ToString();
        string phone = dtv.Rows[0]["Telephone"].ToString();
        Email.Text = email;
        Phone.Text = phone;
    }
    protected void SendMsg_Click(object sender, EventArgs e)
    {
        MessageClientTableAdapter mcta = new MessageClientTableAdapter();
        string msgText=Msg.Text;
        if (type != "c") { error.Visible = true; }
        else
        {
            error.Visible = false;
            mcta.Insert(cid, vid, msgText);
        }
    }
}