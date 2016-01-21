using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Expressly.Api;
using Expressly.SDK.Sample.MVC.Services;

namespace Expressly.SDK.Sample.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Set Up ExpresslyPlugin Merchant interface Implementation (this is IMerchantProvider interface implementation)
            ExpresslyPlugin.SetMerchantProvider<ExpresslyMerchantProvider>();
        }
    }
}
