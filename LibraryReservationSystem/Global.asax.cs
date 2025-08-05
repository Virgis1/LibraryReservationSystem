using System;
using System.Web;

namespace LibraryReservationSystem
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BundleConfig.RegisterJQueryScriptManager();
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string lang = HttpContext.Current.Request.QueryString["lang"];
            string culture = string.IsNullOrEmpty(lang) ? "lt-LT" : lang;

            try
            {
                var ci = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }
            catch
            {
                // Fallback to Lithuanian if invalid culture provided
                var ci = new System.Globalization.CultureInfo("lt-LT");
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }
        }
    }
}
