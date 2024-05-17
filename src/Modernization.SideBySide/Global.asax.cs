using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Modernization.BackendClient;

namespace Modernization.SideBySide
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Login", "login", "~/Pages/Login.aspx");

            RouteTable.Routes.MapPageRoute("Products", "", "~/Pages/Default.aspx");
            RouteTable.Routes.MapPageRoute("ProductDetail", "products/{id}", "~/Pages/ProductDetail.aspx");

            RouteTable.Routes.MapPageRoute("Admin", "admin/products", "~/Pages/Admin/Products.aspx");
        }

        public static ApiClient GetApiClient()
        {
            return new ApiClient(new HttpClient()
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"])
            });
        }
    }
}