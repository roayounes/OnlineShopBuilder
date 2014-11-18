using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;


public partial class Orders : System.Web.UI.Page
{
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
        int idV = Convert.ToInt32(user);
        if (type != "v")
        {
            Response.Redirect("/OnlineShop0/Default00.aspx");
        }
        OrdersTableAdapter ota = new OrdersTableAdapter();
        ProduitCommandeTableAdapter pcta = new ProduitCommandeTableAdapter();
        DataTable dto = ota.GetOrdersByVid(idV);
        if (dto.Rows.Count != 0)
        {
            ViewOrders.Text = "<table class=\"table table-bordered\" width=\"100%\">" +
"<tr><th>Client Name</th> <th> Client Email</th> <th>Products</th> <th>Total Price</th> <th>Date</th> </tr>";
            foreach (DataRow cmd in dto.Rows)
            {
                string cm0 = cmd["CommandeID"].ToString();
                int cm = Convert.ToInt32(cm0);
                string name = cmd["Prenom"].ToString()+" "+cmd["Nom"].ToString();
                string dateCom= cmd["Date"].ToString();
                string email = cmd["Email"].ToString();
                double? priTot = pcta.GetCmdPriTot(cm);
                string priTot0 = priTot.ToString() + "$";
                DataTable pc = pcta.GetProdByCmdID(cm);
                if (pc.Rows.Count != 0)
                {
                    string prodqt = "";
                    foreach (DataRow prc in pc.Rows)
                    {
                        string prodNom = prc["ProduitNom"].ToString();
                        string qt = prc["Quantite"].ToString();
                        prodqt += qt + " " + prodNom + "<br />";
                    }
                    ViewOrders.Text += "<tr><td>" + name + "</td><td>" + email + "</td><td>" + prodqt + "</td><td>" + priTot0 + "</td><td>" + dateCom + "</td></tr>";
                }
            }
            ViewOrders.Text += "</table>";
        }

    }
}