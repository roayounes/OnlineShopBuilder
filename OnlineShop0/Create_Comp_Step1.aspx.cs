using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Create_Comp_Step1 : System.Web.UI.Page
{
    static string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        if (source == null)
        {
            Response.Redirect("Default00.aspx");
        }
        string[] stringSeparators = new string[] {"_"};
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        Label1.Text = user;
        
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);
        CompagnieTableAdapter ca = new CompagnieTableAdapter();
        int? cn = ca.CountStoreName(StoreName.Text);
        if(cn!=0)
        {
        }
        else{

        ca.Insert(idV, ManagerName.Text, Desc.Text, WbLink.Text, FbLlink.Text, TwitterLink.Text,1, StoreName.Text,ManagerPhone.Text);

        Response.Redirect("Create_Comp_Step2.aspx?Step=2");
        }
    }
}