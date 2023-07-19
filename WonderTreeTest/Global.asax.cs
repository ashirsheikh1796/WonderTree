using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WonderTreeTest.Models;

namespace WonderTreeTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private Scheduler scheduler;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DatabaseInitializer());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            scheduler = new Scheduler();
        }

        protected void Application_End()
        {
            scheduler.Dispose();
        }
    }
}
