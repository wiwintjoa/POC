using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiThrottle;

namespace Books.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                Policy = new ThrottlePolicy(perSecond: 1, perMinute: 2)
                {
                    IpThrottling = true, //Configure or throttling by id
                    EndpointThrottling = true,//enabled to differentiate by endpoint
                    ClientThrottling = true, //configure throttling from the header Authorization-Token
                    //IpWhitelist = new List<string>() { }
                    //ClientWhitelist = new List<string>() { "2222"}
                    EndpointRules = new Dictionary<string, RateLimits>()
                    {
                        {"api/books/fantasy", new RateLimits(){PerMinute = 1}}
                    },
                    StackBlockedRequests = true //count block request
                },
                Repository = new CacheRepository()
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
