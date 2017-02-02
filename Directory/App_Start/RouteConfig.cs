// <copyright file="RouteConfig.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // allow for static default page
            routes.IgnoreRoute(string.Empty);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
