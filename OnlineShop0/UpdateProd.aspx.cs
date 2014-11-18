using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class UpdateProd : System.Web.UI.Page
{
    static string user,pid0,dateP;
    static int pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string source = Page.User.Identity.Name;
        string[] stringSeparators = new string[] { "_" };
        string[] result;
        result = source.Split(stringSeparators, StringSplitOptions.None);
        string type = result[0];
        user = result[1];
        string c = result[2];
        //if (Request.QueryString["Step"] == "3") { Image1.Visible = true; }
        pid0 = "";
        pid0 = Request.QueryString["PId"];
        pid = Convert.ToInt32(pid0);
        ProduitsTableAdapter pta = new ProduitsTableAdapter();
        DataTable pdt = pta.GetProductByID(pid);
        ProdName.Text = pdt.Rows[0]["ProduitNom"].ToString();
        ProdPrice.Text = pdt.Rows[0]["Prix"].ToString();
        QtAvailable.Text = pdt.Rows[0]["QtValable"].ToString();
        MinStock.Text = pdt.Rows[0]["StockMin"].ToString();
        MaxStock.Text = pdt.Rows[0]["StockMax"].ToString();
        ProdDesc.Text = pdt.Rows[0]["Desc"].ToString();
        dateP=pdt.Rows[0]["ProdDate"].ToString();
        //ProdImg.FileName = pdt.Rows[1]["ProduitNom"].ToString();
    }
    protected void UpdateProd_Click(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);
        ProduitsTableAdapter pt = new ProduitsTableAdapter();
        DateTime dt = Convert.ToDateTime(dateP);
        double p = Convert.ToDouble(ProdPrice.Text);
        if (ProdImg.HasFile)
        {
            if (ProdImg.PostedFile.ContentType == "image/jpeg" || ProdImg.PostedFile.ContentType == "image/png" || ProdImg.PostedFile.ContentType == "image/bmp")
            {
                string filename1 = Page.User.Identity.Name + Guid.NewGuid() + ProdImg.FileName.ToString();
                ProdImg.SaveAs(Server.MapPath("~/Products_Photos/") + filename1);
                pt.UpdateProd(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, filename1, dt, pid);
                Response.Redirect("/OnlineShop0/Products_Photos/ProductsAdmin.aspx");
            }


            else
            {
                //FormatError.Visible = true;
            }
        }
        else 
        {
            pt.UpdateSansImg(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, dt, pid);
            Response.Redirect("/OnlineShop0/Products_Photos/ProductsAdmin.aspx");
        }
    }
}