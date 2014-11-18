using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Create_Comp_Step2 : System.Web.UI.Page
{
    static int tempID;
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
        if (Request.QueryString["Step"] == "2") { Image2.Visible = true; }
    }
    protected void Temp2_Click(object sender, EventArgs e)
    {
        tempID =2;
        panel1.Attributes["class"] = "panel panel-primary";
        Temp1.Text = "Choose";
        Temp1.CssClass = "btn btn-primary btn-lg btn-block";
        panel2.Attributes["class"]= "panel panel-info";
        Temp2.Text = "Chosen";
        Temp2.CssClass = "btn btn-info btn-lg btn-block";
        panel3.Attributes["class"] = "panel panel-primary";
        Temp3.Text = "Choose";
        Temp3.CssClass = "btn btn-primary btn-lg btn-block";
        
    }
    protected void Temp1_Click(object sender, EventArgs e)
    {

        panel1.Attributes["class"] = "panel panel-info";
        Temp1.Text = "Chosen";
        Temp1.CssClass = "btn btn-info btn-lg btn-block";
        panel2.Attributes["class"] = "panel panel-primary";
        Temp2.Text = "Choose";
        Temp2.CssClass = "btn btn-primary btn-lg btn-block";
        panel3.Attributes["class"] = "panel panel-primary";
        Temp3.Text = "Choose";
        Temp3.CssClass = "btn btn-primary btn-lg btn-block";
        tempID = 4;
    }
    protected void Temp3_Click(object sender, EventArgs e)
    {

        panel1.Attributes["class"] = "panel panel-primary";
        Temp1.Text = "Choose";
        Temp1.CssClass = "btn btn-primary btn-lg btn-block";

        panel2.Attributes["class"] = "panel panel-primary";
        Temp2.Text = "Choose";
        Temp2.CssClass = "btn btn-primary btn-lg btn-block";
        panel3.Attributes["class"] = "panel panel-info";
        Temp3.Text = "Chosen";
        Temp3.CssClass = "btn btn-info btn-lg btn-block";
        tempID = 3;
    }

    protected void Submit0_Click(object sender, EventArgs e)
    {
        //Label1.Text = tempID.ToString();
        int idV = Convert.ToInt32(user);
        CompagnieTableAdapter ca = new CompagnieTableAdapter();
        int tpID = Convert.ToInt32(tempID);
        ca.SetTemplate(tempID,idV);
        if ((tpID == 4) || (tpID == 2))
        {
            Response.Redirect("CompleteTemplate.aspx");
        }
    }
}