using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Default00 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Cr_Ven_Click(object sender, EventArgs e)
    {
        VendeurTableAdapter va = new VendeurTableAdapter();
        DataTable dtv = va.GetDataByEmail(emailV.Text);
        int ce = dtv.Rows.Count;
        if (ce != 0)
        {
            Label1.Text = "Email already exist";
            Label1.Visible = true;
        }
        else
        {

            va.Insert(emailV.Text, passV.Text, ddlCountry.SelectedValue, phoneV.Text, DateTime.Now, Convert.ToInt32(typeV.SelectedValue),DateTime.Now);
            dtv = va.GetDataByEmail(emailV.Text);
            string s = dtv.Rows[0]["VendeurID"].ToString();
            int vID = Convert.ToInt32(s);
            //int? vID = va.GetVdID(emailV.Text);
            string user = "v_" + vID.ToString() + "_0";
            FormsAuthentication.SetAuthCookie(user, true);
            if (typeV.Text == "1")
            {
                Response.Redirect("Create_Comp_Step1.aspx");
            }
        }
    }
}