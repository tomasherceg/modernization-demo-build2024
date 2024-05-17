using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modernization.SideBySide
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            if (Login1.UserName == "admin" && Login1.Password == "admin")
            {
                e.Authenticated = true;
                FormsAuthentication.SetAuthCookie(Login1.UserName, false);
                
                Response.RedirectToRoute("Admin");
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}