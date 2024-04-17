using Microsoft.AspNet.FriendlyUrls;
using System.Web.Http;
using System.Web.Routing;

namespace FlowSagicorInsurance
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Enable Friendly URLs for Web Forms pages
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
