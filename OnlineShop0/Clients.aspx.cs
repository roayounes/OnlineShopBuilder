using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;


public partial class Clients : System.Web.UI.Page
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
        ClientTableAdapter cta = new ClientTableAdapter();
        DataTable dtc = cta.GetClientsByVid(vid);
        if (dtc.Rows.Count == 0)
        {
            ClientTable.Text = "You Don't Have Clients Yet";
        }
        else
        {
            ClientTable.Text = "<table border=\"1\" width=\"100%\">" +
"<tr><th>Id</th> <th>Email</th> <th>country</th> <th>Last Name</th> <th>First Name</th> <th>Birthday</th> <th>Sex</th> <th>Regestration Day</th> </tr>";
            foreach (DataRow row in dtc.Rows)
            {
                string idc = row["ClientID"].ToString();
                string email = row["Email"].ToString();
                string country = row["Pays"].ToString();
                string ln = row["Nom"].ToString();
                string fn = row["Prenom"].ToString();
                string birthday = row["DateNaissance"].ToString();
                string sex = row["Sexe"].ToString();
                string regdate = row["DateInscription"].ToString();
                ClientTable.Text += "<tr> <td>" + idc + "</td> <td>" + email + "</td> <td>" + country + "</td> <td>" + ln + "</td> <td>" + fn + "</td><td>" + birthday + "</td><td>" + sex + "</td><td>" + regdate + "</td>";
                ClientTable.Text += "</tr>";
            }
            ClientTable.Text += "</table>";
        }
    }
}
