using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace TestTask
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetProducts",
                routeTemplate: "api/{controller}/{action}/{page}",
                defaults: new { page = RouteParameter.Optional},
                constraints: new
                {
                    page = new IntRouteConstraint()
                }
            );

            config.Routes.MapHttpRoute(
                name: "GetProductsSort",
                routeTemplate: "api/{controller}/{action}/{sort}",
                defaults: new { sort = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetProductsFilter",
                routeTemplate: "api/{controller}/{action}/{page}/{sort}/{nameProduct}/{nameMarker}/{priceFrom}/{priceTo}",
                defaults: new { }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
