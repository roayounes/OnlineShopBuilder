using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class Create_Comp_Step3 : System.Web.UI.Page
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
       if (Request.QueryString["Step"] == "3") { Image1.Visible = true; }
   }
    protected void AddProd_Click(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);
       
        if (ProdImg.PostedFile.ContentType == "image/jpeg" || ProdImg.PostedFile.ContentType == "image/png" || ProdImg.PostedFile.ContentType == "image/bmp")
            {   double p= Convert.ToDouble(ProdPrice.Text);
                string filename1 = Page.User.Identity.Name + Guid.NewGuid() + ProdImg.FileName.ToString();
                ProdImg.SaveAs(Server.MapPath("~/Products_Photos/") + filename1);
                ProduitsTableAdapter pt = new ProduitsTableAdapter();
                DateTime dt = DateTime.Now;
                pt.Insert(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, filename1,dt);
                //Pour ajouter les categories
                DataTable dtp = pt.GetProdID(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, filename1, dt);
                string pid0 = dtp.Rows[0]["ProduitID"].ToString();
                int pid = Convert.ToInt32(pid0);
                CategoriesTableAdapter ctta = new CategoriesTableAdapter();
                CaracteriserTableAdapter csta = new CaracteriserTableAdapter();
                string source = KeyWords.Text;
                string[] stringSeparators = new string[] { "," };
                string[] result;
                result = source.Split(stringSeparators, StringSplitOptions.None);
                foreach(string kw in result)
                {
                    DataTable dtctt = ctta.GetCatID(kw);
                    if (dtctt.Rows.Count == 0)
                    {
                        ctta.Insert(kw);
                        DataTable catID00 = ctta.GetCatID(kw);
                        string catID0 = catID00.Rows[0]["CatID"].ToString();
                        int catID = Convert.ToInt32(catID0);
                        csta.Insert(pid, catID);
                    }
                    else
                    {
                        DataTable catID00 = ctta.GetCatID(kw);
                        string catID0 = catID00.Rows[0]["CatID"].ToString();
                        int catID = Convert.ToInt32(catID0);
                        csta.Insert(pid, catID);
                    }
                }
                Response.Redirect("Create_Comp_Step4.aspx");
            }

            else
            {
                //FormatError.Visible = true;
            }
    
    }

    //Add_More
    protected void Add_More(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);

        if (ProdImg.PostedFile.ContentType == "image/jpeg" || ProdImg.PostedFile.ContentType == "image/png" || ProdImg.PostedFile.ContentType == "image/bmp")
        {
            double p = Convert.ToDouble(ProdPrice.Text);
            string filename1 = Page.User.Identity.Name + Guid.NewGuid() + ProdImg.FileName.ToString();
            ProdImg.SaveAs(Server.MapPath("~/Products_Photos/") + filename1);
            ProduitsTableAdapter pt = new ProduitsTableAdapter();
            DateTime dt = DateTime.Now;
            pt.Insert(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, filename1, dt);
            //Pour ajouter les categories
            DataTable dtp = pt.GetProdID(ProdName.Text, ProdDesc.Text, p, Convert.ToInt32(QtAvailable.Text), Convert.ToInt32(MinStock.Text), Convert.ToInt32(MaxStock.Text), 0, idV, 1, filename1, dt);
            string pid0 = dtp.Rows[0]["ProduitID"].ToString();
            int pid = Convert.ToInt32(pid0);
            CategoriesTableAdapter ctta = new CategoriesTableAdapter();
            CaracteriserTableAdapter csta = new CaracteriserTableAdapter();
            string source = KeyWords.Text;
            string[] stringSeparators = new string[] { "," };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            foreach (string kw in result)
            {
                DataTable dtctt = ctta.GetCatID(kw);
                if (dtctt.Rows.Count == 0)
                {
                    ctta.Insert(kw);
                    DataTable catID00 = ctta.GetCatID(kw);
                    string catID0 = catID00.Rows[0]["CatID"].ToString();
                    int catID = Convert.ToInt32(catID0);
                    csta.Insert(pid, catID);
                }
                else
                {
                    DataTable catID00 = ctta.GetCatID(kw);
                    string catID0 = catID00.Rows[0]["CatID"].ToString();
                    int catID = Convert.ToInt32(catID0);
                    csta.Insert(pid, catID);
                }
            }
            Response.Redirect("Create_Comp_Step3.aspx");
        }

        else
        {
            //FormatError.Visible = true;
        }

    }
}