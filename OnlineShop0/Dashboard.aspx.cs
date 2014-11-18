using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Dashboard : System.Web.UI.Page
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
        CommentsStorTableAdapter csta = new CommentsStorTableAdapter();
        int? cn = csta.countCommentNS(idV);
        nc.InnerText = cn.ToString();
        ProduitsTableAdapter pta = new ProduitsTableAdapter();
        int? ctd = pta.countToDo(idV);
        tdi.InnerText = ctd.ToString();
        ClientTableAdapter cta = new ClientTableAdapter();
        string ncl = cta.countClients(idV).ToString();
        nu.InnerText = ncl;

    }
}