using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataSet1TableAdapters;
using System.Data;
using System.Web.Security;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
	{
        
	}
}
/* another alternative is to make a base page class that all of your pages inherit:

public class BasePage : System.Web.UI.Page
{
     public string GetUserInfo()
     {...}

}
All of the aspx pages that need this method can inherit the BasePage class. Since BasePage 
inherits from System.Web.UI.Page, they will get access to all of the page methods and properties
 as well.
*/