using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace LibraryReservationSystem
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleConfig.RegisterJQueryScriptManager();
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string lang = HttpContext.Current.Request.QueryString["lang"];
            var culture = string.IsNullOrEmpty(lang) ? "lt-LT" : lang;

            try
            {
                var ci = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }
            catch
            {
                var ci = new System.Globalization.CultureInfo("lt-LT");
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }
        }
    }
}
