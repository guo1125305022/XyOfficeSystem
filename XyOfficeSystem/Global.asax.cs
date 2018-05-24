using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace XyOfficeSystem
{
    public class MvcApplication : HttpApplication
    {
        private static int IsCheck = 0;
        protected void Application_Start()
        {
            if (IsCheck < 1) {
                SystemRepair.Program.Main();
                IsCheck++;
            }
           
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    
    }
}
