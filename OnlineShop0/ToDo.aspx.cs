using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;
public partial class ToDo : System.Web.UI.Page
{
    static string user;
    static int vid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        vid = Convert.ToInt32(user);
        ProduitsTableAdapter pta = new ProduitsTableAdapter();
        DataTable dtp = pta.GetToDoList(vid);
        if (dtp.Rows.Count != 0)
        {
            toDo.Text = "<table class=\"table table-bordered\">" +
                "<tr><th>Product Name</th> <th>Quantity Available</th> <th>Minimum Stock</th></tr>";
            foreach (DataRow td in dtp.Rows) 
            {
                string pn=td["ProduitNom"].ToString();
                string qta=td["QtValable"].ToString();
                string mns=td["StockMin"].ToString();
                toDo.Text += "<tr><td>" + pn + "</td><td>" + qta + "</td><td>" + mns + "</td></tr>";
            }
            toDo.Text+="</table>";
        }

    }
}