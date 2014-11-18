using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class ViewComments : System.Web.UI.Page
{
    static string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        if (source == null)
        {
            Response.Redirect("Default00.aspx");
        }
        string[] stringSeparators = new string[] { "_" };
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        int idV = Convert.ToInt32(user);
        CommentsTableAdapter cta = new CommentsTableAdapter();
        CommentsStorTableAdapter csta = new CommentsStorTableAdapter();
        DataTable dtcs = csta.GetCommentsByStore(idV);
        if (dtcs.Rows.Count != 0)
        {
            Comments.Text = "<table class=\"table\">";
            foreach (DataRow cm in dtcs.Rows)
            {
                string cin = cm["Nom"].ToString();
                string cip = cm["Prenom"].ToString();
                string pn = cm["ProduitNom"].ToString();
                string cod = cm["Date"].ToString();
                string cot = cm["text"].ToString();
                string coid0 = cm["CommentID"].ToString();
                int coid = Convert.ToInt32(coid0);
                cta.UpdateSeenComments(coid);
                string pid0 = cm["ProduitID"].ToString();
                Comments.Text += "<tr><td> <b>" + cip + " " + cin + "</b> commented on <a href=\"TemplateFreeViewProduct.aspx?SId="+user+"&PId="+pid0+"\">" + pn + "</a> at <small>" + cod + "</small> :<i>" + cot + "</i></td></tr>";
            }
            Comments.Text +="</table>";
        }

    }
}