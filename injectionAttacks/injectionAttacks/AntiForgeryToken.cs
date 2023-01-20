using System;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public class AntiForgeryToken
{
    public static void Check(Page page, HiddenField hiddenField)
    {
        if (!page.IsPostBack)
        {
            Guid token = Guid.NewGuid();
            hiddenField.Value = token.ToString();
            page.Session["token"] = token;
        }
        else
        {
            Guid client = new Guid(hiddenField.Value);
            Guid server = (Guid)page.Session["token"];

            if (client != server)
            {
                throw new SecurityException("CSRF Atağı saptandı");
            }
        }
    }
}