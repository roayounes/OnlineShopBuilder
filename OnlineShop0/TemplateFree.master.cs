using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

public partial class TemplateFree : System.Web.UI.MasterPage
{
    static string user="",c;
    static int vid,searchID;
    static string vid0;
    
   protected void Page_Load(object sender, EventArgs e)
   {   
       string source = Page.User.Identity.Name;

       int idV=0;
       string type="x";
       string[] stringSeparators = new string[] { "_" };
       if(source!=null){
                  string[] result;
                  result = source.Split(stringSeparators, StringSplitOptions.None);
                  type = result[0];
                  user = result[1];
                  c = result[2];
                  idV=Convert.ToInt32(user);}

       
       vid0 = "";
       vid0 = Request.QueryString["SId"];
       if (vid0 == null)
       {
           Response.Redirect("../Default00.aspx");
       }

       vid = Convert.ToInt32(vid0);
       if((type=="c")&&(vid==idV))
       {
           SignInBox.Visible=false;
           ClientInfo.Visible = true;
           SignUpBox.Visible = true;
       }
       TempInfo0TableAdapter ti = new TempInfo0TableAdapter();
       DataTable tf = ti.GetDataByStoreID(vid);
       string img1 = "~/Cover Photos/"+ tf.Rows[0]["Param1"].ToString();
       string img2 = "~/Cover Photos/" + tf.Rows[0]["Param2"].ToString();
       string img3 = "~/Cover Photos/" + tf.Rows[0]["Param3"].ToString();
       Cover1.ImageUrl = img1;
       Cover2.ImageUrl = img2;
       Cover3.ImageUrl = img3;
       StoreName.InnerText = "abc";
       CompagnieTableAdapter ct = new CompagnieTableAdapter();
       DataTable cd = ct.GetDataByIDv(vid);
       string sn = cd.Rows[0]["StoreName"].ToString();
       StoreName.InnerText = sn;

   }


   protected void aboutPage(object sender, EventArgs e)
   {
       string ablk = "/OnlineShop0/TemplateFreeAbout.aspx?SId=" + vid;
       Response.Redirect(ablk);
   }
   protected void signUpPage(object sender, EventArgs e)
   {
       string sulk = "/OnlineShop0/FreeTemplateSignUp.aspx?SId=" + vid;
       Response.Redirect(sulk);
   }

   protected void SignIn_Click(object sender, EventArgs e)
   {

       
           ClientTableAdapter cta =new ClientTableAdapter();
           DataTable dtc = cta.GetClientID(EmailC.Text,PassC.Text,vid);
           if (dtc.Rows.Count == 0)
           {
               Error.Visible = true;
           }
           else
           {
               String user0 = dtc.Rows[0]["ClientID"].ToString();
               string cP = dtc.Rows[0]["Prenom"].ToString();
               int idc = Convert.ToInt32(user0);
               user = "c_" + vid0 + "_"+idc;
               FormsAuthentication.SetAuthCookie(user, true);
               //Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId"+vid0);

           

       }
   }
   protected void LogOut(object sender, EventArgs e)
   {
       FormsAuthentication.SignOut();
       FormsAuthentication.SetAuthCookie("visiteur_0_0", true);
       Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId=" + vid0);
       
   }
     protected void goAbout(object sender, EventArgs e)
   {
       Response.Redirect("/OnlineShop0/TemplateFreeAbout.aspx?SId="+vid0);
     }
     protected void goToCart(object sender, EventArgs e)
     {
         Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeMyCart.aspx?SId=" + vid0);
     }
     protected void goToHome(object sender, EventArgs e)
     {
         Response.Redirect("/OnlineShop0/Products_Photos/TemplateFreeDefault.aspx?SId=" + vid0);
     }
     protected void goContact(object sender, EventArgs e)
     {
         Response.Redirect("/OnlineShop0/Contact.aspx?SId=" + vid0);
     }
     protected void Search(object sender, EventArgs e)
     {
         ProdCategoriesTableAdapter pcta = new ProdCategoriesTableAdapter();
         SearchTableAdapter sta = new SearchTableAdapter();
         NEWSearchTableAdapter nsta = new NEWSearchTableAdapter();
         ProduitsTableAdapter pta = new ProduitsTableAdapter();
         DateTime dt = DateTime.Now;
         string words0 = SearchWords.Text;//pour prendre la phrase a chercher
         nsta.Insert(dt, words0);//pour initialiser un new search
         DataTable dtns = nsta.GetSearchIDbyDate(dt);
         string searchID0 = dtns.Rows[0]["SearchID"].ToString();//pour prendre le search id
         searchID = Convert.ToInt32(searchID0);

         //Pour Trouver les resultats du search par rapport au nom du produit
         DataTable dtp = pta.SearchByProdName(words0, vid);
         if (dtp.Rows.Count != 0)
         {
             foreach (DataRow prn in dtp.Rows)
             {
                 string pid0 = prn["ProduitID"].ToString();
                 int pid = Convert.ToInt32(pid0);
                 DataTable dtsta = sta.ExistPIdSearchId(searchID, pid);
                 if (dtsta.Rows.Count == 0)
                 {
                     sta.Insert(searchID, pid, 100);
                 }
                 else
                 {
                     string ctr0 = dtsta.Rows[0]["ct"].ToString();
                     int ctr = Convert.ToInt32(ctr0);
                     ctr = ctr + 100;
                     sta.UpdateCompteur(ctr, searchID, pid);
                 }
             }
         }

         //Pour trouver les resultats du search par rapport au categories
         string[] stringSeparators = new string[] { " " };
         string[] words;
         words = words0.Split(stringSeparators, StringSplitOptions.None);
         foreach (string word in words)
         {
             DataTable dtpc = pcta.GetProdByCategorie(word, vid);
             if (dtpc.Rows.Count != 0)
             {
                 foreach (DataRow pr in dtpc.Rows)
                 {
                     string pid0 = pr["ProduitID"].ToString();
                     int pid = Convert.ToInt32(pid0);
                     int cid = Convert.ToInt32(c);
                     DataTable dtsta = sta.ExistPIdSearchId(searchID, pid);
                     if (dtsta.Rows.Count == 0)
                     {
                         sta.Insert(searchID, pid, 1);
                     }
                     else
                     {
                         string ctr0 = dtsta.Rows[0]["ct"].ToString();
                         int ctr = Convert.ToInt32(ctr0);
                         ctr++;
                         sta.UpdateCompteur(ctr, searchID, pid);
                     }
                 }
             }
 
         }
         Response.Redirect("SearchResult.aspx?SId=" + vid0 + "&SearchID=" + searchID);
     }
}
