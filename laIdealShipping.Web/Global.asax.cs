using laIdealShipping.Web.DataContexts.laIdealShippingMigrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace laIdealShipping.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<laIdealShipping.Web.DataContexts.laIdealShippingsDb>(null);
            //Database.SetInitializer<laIdealShipping.Web.DataContexts.IdentityDb>(null);
        }
    }
}
