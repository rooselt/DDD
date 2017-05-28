using Sisacon.UI.AutoMapper;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sisacon.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
