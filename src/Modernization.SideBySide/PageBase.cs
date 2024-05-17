using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modernization.SideBySide
{
    public class PageBase : System.Web.UI.Page
    {

        public string SelectedCurrency
        {
            get
            {
                if (Session["SelectedCurrency"] == null)
                {
                    return "USD";
                }
                return (string)Session["SelectedCurrency"];
            }
        }

        public void SetCurrency(string currency)
        {
            Session["SelectedCurrency"] = currency;
            Response.Redirect(Request.RawUrl);
        }
    }
}