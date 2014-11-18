using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

public partial class CompleteTemplate : System.Web.UI.Page
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
    }

    protected void SubmitPix_Click(object sender, EventArgs e)
    {
        int idV = Convert.ToInt32(user);
        if ((Pic1.PostedFile.ContentType == "image/jpeg" || Pic1.PostedFile.ContentType == "image/png" || Pic1.PostedFile.ContentType == "image/bmp") && (Pic2.PostedFile.ContentType == "image/jpeg" || Pic2.PostedFile.ContentType == "image/png" || Pic2.PostedFile.ContentType == "image/bmp") && ( Pic3.PostedFile.ContentType == "image/jpeg" || Pic3.PostedFile.ContentType == "image/png" || Pic3.PostedFile.ContentType == "image/bmp"))
            {
                string filename1 = Page.User.Identity.Name + Guid.NewGuid() + Pic1.FileName.ToString();
                Pic1.SaveAs(Server.MapPath("~/Cover Photos/") + filename1);
                string filename2 = Page.User.Identity.Name + Guid.NewGuid() + Pic1.FileName.ToString();
                Pic2.SaveAs(Server.MapPath("~/Cover Photos/") + filename2);
                string filename3 = Page.User.Identity.Name + Guid.NewGuid() + Pic1.FileName.ToString();
                Pic3.SaveAs(Server.MapPath("~/Cover Photos/") + filename3);

                TempInfo0TableAdapter ti = new TempInfo0TableAdapter();
                int? nbvid = ti.GetNbVid(idV);
                if (nbvid != 0)
                {
                    ti.UpdateTemplateInfo(filename1, filename2, filename3, "0", "0", "0", idV);
                }
                else
                {
                    ti.Insert(idV, filename1, filename2, filename3, "0", "0", "0");
                }
                Response.Redirect("Create_Comp_Step3.aspx?Step=3");
            }

            else
            {
                FormatError.Visible = true;
            }
    }
}