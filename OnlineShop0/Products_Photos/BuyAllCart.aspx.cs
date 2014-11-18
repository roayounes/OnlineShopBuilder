using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class BuyAllCart : System.Web.UI.Page
{
    static string user, c, vid0,ct;
    protected void Page_Load(object sender, EventArgs e)
    {
        //pour avoir les info sur le client
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        if (source != null)
        {

            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            string type = result[0];
            user = result[1];
            c = result[2];
            int idV = Convert.ToInt32(user);
        }

        //Pour savoir c'est qu'elle store
        vid0 = "";
        vid0 = Request.QueryString["SId"];
        if (vid0 == null)
        {
            Response.Redirect("../Default00.aspx");
        }
        int vid = Convert.ToInt32(vid0);     
        
        ClientCartTableAdapter ccta = new ClientCartTableAdapter();

        //Pour savoir le prix total
        ct = "";
        int cid = Convert.ToInt32(c);
        double? cti = ccta.GetTotalCart(cid);
        ct = cti.ToString();
        TotPrice.Text = ct + "$";

        //pour voir les prod de la cart
        DataTable dtcc = ccta.GetDataByCartID(Convert.ToInt32(c));
        if (dtcc != null)
        {
            YourCart.Text = "<table class=\"table\">";
            foreach (DataRow pr in dtcc.Rows)
            {
                string pn = pr["ProduitNom"].ToString();
                string pdesc = pr["Desc"].ToString();
                string pp = pr["Prix"].ToString();
                string ip = pr["ImgProd"].ToString();
                string pid = pr["ProduitID"].ToString();
                string pqt = pr["quantite"].ToString();
                string PicturePath = Server.MapPath(ip);
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(PicturePath);
                int ActualWidth = image1.Width;
                int ActualHeight = image1.Height;
                string wh = "style=\"max-width:70px\"";
                string SId_PId = "SId=" + vid0 + "&PId=" + pid;
                if (ActualHeight > ActualWidth)
                {
                    wh = "style=\"max-width:70px\"";

                }
                YourCart.Text += "<tr><td style=\"width:300px\">" +
                 "<div class=\"media\">" +
                    "<a class=\"pull-left\" href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&pqt=" + pqt + "&PId=" + pid + "\">" +
                      "  <img class=\"media-object\" src=\"" + ip + "\" " + wh + " alt=\"" + pdesc + "\">" +
                    "</a>" +
                   "<div class=\"media-body\">" +
                      " <h4 class=\"media-heading\"><a href=\"../TemplateFreeViewProduct.aspx?SId=" + user + "&pqt=" + pqt + "&PId=" + pid + "\">" + pn + " </a>" + pqt + "</h4>" +
                     "Price:" + pp + "$<br />" +
                   "</div>" +
                "</div></td>" +
"</tr>";

            }
            YourCart.Text += "</table>";
        }

    }
    protected void BuyProds_Click(object sender, EventArgs e)
    {
        CommandesTableAdapter cta = new CommandesTableAdapter();
        int cid = Convert.ToInt32(c);
        DateTime dt = DateTime.Now;
        cta.Insert(dt, cid);
        DataTable dtco = cta.GetDataByCmData(dt, cid);
        string comID0 = dtco.Rows[0]["CommandeID"].ToString();
        int i = Convert.ToInt32(comID0);
        ProduitsTableAdapter pta = new ProduitsTableAdapter();
        ContientTableAdapter cota = new ContientTableAdapter();
        ContientCTableAdapter ccta = new ContientCTableAdapter();
        DataTable dtcc = ccta.GetCartProdByCID(cid);
        BleuAlert.InnerText = "Congratulation! You Just Bought:";
        RougeAlert.InnerText = "You Can Not Buy This Product Because The Amount Available Is Less Than What You Requested:";
        foreach (DataRow pr in dtcc.Rows)
        {
            string pid0 = pr["ProduitID"].ToString();
            int pid = Convert.ToInt32(pid0);
            string qtp0 = pr["quantite"].ToString();
            int qtp = Convert.ToInt32(qtp0);
            DataTable dtp = pta.GetProductByID(pid);
            string qtv0 = dtp.Rows[0]["QtValable"].ToString();
            string pn = dtp.Rows[0]["ProduitNom"].ToString();
            int qtv = Convert.ToInt32(qtv0);
            if (qtv < qtp)
            {
                RougeAlert.InnerText += " ," + pn;
                RougeAlert.Visible = true;
            }
            else
            {
                cota.Insert(i, pid, qtp);
                int qtpn = qtv - qtp;
                pta.UpdateQtProd(qtpn, pid);
                DataTable dtccp = ccta.GetDataByCidPid(cid, pid);
                if (dtcc.Rows != null)
                {
                    ccta.DeleteItemFromCart(cid, pid);
                }
                BleuAlert.InnerText += " ," + pn;
                BleuAlert.Visible = true;
 
            }

        }
    }
}