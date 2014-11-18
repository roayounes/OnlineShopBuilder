using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class TemplateFreeViewProduct : System.Web.UI.Page
{
    static string user,pid,sid,c,source,type,pn,qv;
    static int ppid;

    void Page_PreInit(Object sender, EventArgs e)
    {
        string temp = "";
        temp=Request.QueryString["temp"];
        if (temp == "0")
        {
            this.MasterPageFile = "~/MasterAdmin.master";
        }
    }

   protected void Page_Load(object sender, EventArgs e)
   {
       source = Page.User.Identity.Name;
       string[] stringSeparators = new string[] { "_" };
       if (source != null)
       {
           string[] result;
           result = source.Split(stringSeparators, StringSplitOptions.None);
           type = result[0];
           user = result[1];
           c = result[2];
       }
       int idV=Convert.ToInt32(user);
       pid="";
       sid="";

       sid=Request.QueryString["SId"];
       pid = Request.QueryString["PId"];
       if ((sid == null)||(pid == null))
       {
           Response.Redirect("~/Default00.aspx");
       }
       else
       {

           ProduitsTableAdapter pt = new ProduitsTableAdapter();
           int pid0 = Convert.ToInt32(pid);
           DataTable pdt = pt.GetProductByID(pid0);
           string imgp = pdt.Rows[0]["ImgProd"].ToString();
           pn = pdt.Rows[0]["ProduitNom"].ToString();
           string dsc = pdt.Rows[0]["Desc"].ToString();
           string pp = pdt.Rows[0]["Prix"].ToString();
           qv = pdt.Rows[0]["QtValable"].ToString();
           string pd = pdt.Rows[0]["ProdDate"].ToString();
           ImgProd.ImageUrl = "~/Products_Photos/" + imgp;
           //ProdName.Text =  pn;
           ProdName.InnerText = pn;
           ProdPrice.Text = "Price: " + pp + "$";
           Desc.Text = "Description: " + dsc;
           qt.Text = "Quantity Available: " + qv;
           ProdDate.Text = "Date :" + pd;
       }
       if ((type == "c") && (sid == user)) {
           string errors = psi.InnerText;
           if (errors == "Please Sign in First!")
           { psi.Visible = false; }
       
      }
       if (Request.QueryString["pqt"] != null)
       {
           int qtp0 = Convert.ToInt32(qv);
           if (qtp0 == 0)
           {
               psi.InnerText = "Sorry Sold Out!!";
               psi.Visible = true;

           }
           else
           {
               if ((source == null) || (type != "c") || (sid != user))
               {
                   psi.Visible = true;
               }


               else
               {
                   qtp.Text = Request.QueryString["pqt"];
                   BuyProd.Visible = false;
                   addCart.Visible = false;
                   BP.Visible = true;
                   ac.Visible = true;
                   atc.Visible = false;
                   BuyProds.Visible = true;

               }
           }


       }
       //Pour afficher les commentaires
       CommentsProdTableAdapter cpta = new CommentsProdTableAdapter();
       int pidi = Convert.ToInt32(pid);
       DataTable dtcom = cpta.GetCommentsByProd(pidi);
       if (dtcom != null)
       {
           Comments.Text = "";
           foreach (DataRow cm in dtcom.Rows) {
               string ComText = cm["Text"].ToString();
               string PrC = cm["Prenom"].ToString();
               string NomC = cm["Nom"].ToString();
               string DateC = cm["Date"].ToString();
               string PaysC = cm["Pays"].ToString();
               Comments.Text += "<div class=\"panel panel-default\">"+
                                   "<div class=\"panel-heading\">"+
                                "<h3 class=\"panel-title\"><b>"+PrC+" "+NomC+"</b></h3>"+
                                   " </div>"+
                           " <div class=\"panel-body\">"+
                                 "<div class=\"media\">" +
                                       " <div class=\"media-body\">" +
                                         "  <a class=\"pull-left\" href=\"#\">" +
                          " <img class=\"media-object\" src=\"Com-Icon.png\" style=\"max-width:70px\" alt=\"...\">" +
                                         " </a>" +
                         " <h4 class=\"media-heading\"> <small>" + DateC + "</small></h4>" +
                           ComText +
                             " </div>" +
                             "</div></div></div>";
           }
       }

    }
   protected void AddTocart(object sender, EventArgs e)
   {
       if ((source == null) || (type != "c") || (sid != user))
       {
           psi.Visible = true;}

       
       else
       {
           BuyProd.Visible = false;
           addCart.Visible = false;
           ac.Visible = true;
       }
   }
   protected void atc_Click(object sender, EventArgs e)
   {
       ContientCTableAdapter ccta = new ContientCTableAdapter();
       int? qt0=Convert.ToInt32(qtp.Text);
       int cid = Convert.ToInt32(c);
       int pid0 = Convert.ToInt32(pid);
       DataTable dtcc = ccta.GetDataByCidPid(cid, pid0);
       if (dtcc.Rows == null)
       {
           psi.InnerText = "The Product is Already in your Cart";
           psi.Visible = true;
       }
       else
       {
           ccta.Insert(cid, pid0, qt0, DateTime.Now);
           ac.Visible = false;
           BuyProd.Visible = true;
           addCart.Visible = true;
           atcs.Visible = true;
       }
 
   }

   protected void Buy_Prod(object sender, EventArgs e)
   {
       int qtp = Convert.ToInt32(qv);
       if (qtp == 0)
       {
           psi.InnerText = "Sorry Sold Out!!";
           psi.Visible = true;

       }
       else
       {
           if ((source == null) || (type != "c") || (sid != user))
           {
               psi.Visible = true;
           }


           else
           {
               BuyProd.Visible = false;
               addCart.Visible = false;
               BP.Visible = true;
               ac.Visible = true;
               atc.Visible = false;
               BuyProds.Visible = true;
           }
       }
   }
   protected void BuyProds_Click(object sender, EventArgs e)
   {
       ProduitsTableAdapter pta=new ProduitsTableAdapter();
       int pid0 = Convert.ToInt32(pid);
       DataTable pdt = pta.GetProductByID(pid0);
       string pp = pdt.Rows[0]["Prix"].ToString();
       qv = pdt.Rows[0]["QtValable"].ToString();
       int qvp=Convert.ToInt32(qv);
       int qtpc = Convert.ToInt32(qtp.Text);
       if (qtpc > qvp)
       {
           psi.InnerText = "You can Buy " + qv + " " + pn + " Maximum..";
           psi.Visible = true;
       }
       else
       {
           CommandesTableAdapter cta = new CommandesTableAdapter();
           int cid = Convert.ToInt32(c);
           ppid = Convert.ToInt32(pid);
           DateTime dt = DateTime.Now;
           cta.Insert(dt, cid);
           DataTable dtco = cta.GetDataByCmData(dt, cid);
           string comID0 = dtco.Rows[0]["CommandeID"].ToString();
           int i = Convert.ToInt32(comID0);
           ContientTableAdapter cota = new ContientTableAdapter();
           cota.Insert(i, ppid, Convert.ToInt32(qtp.Text));
           int qtpn = qvp - qtpc;
           pta.UpdateQtProd(qtpn, ppid);
           ContientCTableAdapter ccta = new ContientCTableAdapter();
           DataTable dtcc = ccta.GetDataByCidPid(cid, ppid);
           if (dtcc.Rows != null) {
               ccta.DeleteItemFromCart(cid, ppid);
           }
           atcs.InnerText = "Congratulation! You Have bought " + qtp.Text + " " + pn;
           atcs.Visible = true;
           BP.Visible = false;
           ac.Visible = false;
       }
   }
   protected void addComment(object sender, EventArgs e)
   {
       if ((source == null) || (type != "c") || (sid != user))
       {
           psi.Visible = true;
       }


       else
       {
           CommentsTableAdapter comta = new CommentsTableAdapter();
           int cid = Convert.ToInt32(c);
           ppid = Convert.ToInt32(pid);
           comta.Insert(AddComText.Text, DateTime.Now, cid, ppid, 0);
           Response.Redirect("TemplateFreeViewProduct.aspx?SId=" + sid + "&PId=" + pid);
       }
   }

    
}