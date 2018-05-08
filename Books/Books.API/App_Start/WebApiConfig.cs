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
            //// Web API configuration and services
            //config.MessageHandlers.Add(new ThrottlingHandler()
            //{
            //    // Default limit
            //    //Policy = new ThrottlePolicy(perSecond: 1, perMinute: 60)
            //    Policy = new ThrottlePolicy()
            //    {
            //        IpThrottling = true, //Configure or throttling by id
            //        EndpointThrottling = true,//enabled to differentiate by endpoint
            //        //ClientThrottling = true, //configure throttling from the header Authorization-Token
            //        //IpWhitelist = new List<string>() { }
            //        //ClientWhitelist = new List<string>() { "2222"}
            //        EndpointRules = new Dictionary<string, RateLimits>()
            //        {
            //            // Override default limit
            //            {"api/books", new RateLimits(){ PerSecond= 1, PerMinute = 60}}
            //        },
            //        StackBlockedRequests = true //count block request
            //    },
            //    Repository = new CacheRepository()
            //});

            // Define rate limits in web.config or app.config
            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                Policy = ThrottlePolicy.FromStore(new PolicyConfigurationProvider()),
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
