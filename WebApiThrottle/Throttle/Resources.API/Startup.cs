using DataAccess;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Newtonsoft.Json.Serialization;
using Owin;
using Resources.API.Resolver;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Tracing;
using Unity;
using Unity.Lifetime;
using WebApiThrottle;

[assembly: OwinStartup(typeof(Resources.API.Startup))]

namespace Resources.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(httpConfig);

            ConfigureThrottle(httpConfig);

            app.UseWebApi(httpConfig);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            //var issuer = "http://localhost:60135";
            var issuer = "http://localhost/Bsi.Authentication.API";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AllowedAudiences = new[] { audienceId },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                }
            });
        }

        private void ConfigureThrottle(HttpConfiguration config)
        {
            ////Register throttling handler
            //config.MessageHandlers.Add(new ThrottlingHandler()
            //{
            //    Policy = new ThrottlePolicy(perSecond: 3, perMinute: 20, perHour: 200, perDay: 1500, perWeek: 3000)
            //    {
            //        IpThrottling = true
            //    },
            //    Repository = new CacheRepository()
            //});

            //trace provider
            var traceWriter = new SystemDiagnosticsTraceWriter()
            {
                IsVerbose = true
            };
            config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), traceWriter);
            config.EnableSystemDiagnosticsTracing();

            //Web API throttling handler
            config.MessageHandlers.Add(new ThrottlingHandler(
                policy: new ThrottlePolicy(perMinute: 20, perHour: 30, perDay: 35, perWeek: 3000)
                {
                    ////scope to IPs
                    //IpThrottling = true,
                    //IpRules = new Dictionary<string, RateLimits>
                    //{
                    //    { "::1/10", new RateLimits { PerSecond = 2 } },
                    //    { "192.168.2.1", new RateLimits { PerMinute = 30, PerHour = 30*60, PerDay = 30*60*24 } }
                    //},

                    ////white list the "::1" IP to disable throttling on localhost for Win8
                    //IpWhitelist = new List<string> { "127.0.0.1", "192.168.0.0/24" },

                    ////scope to clients (if IP throttling is applied then the scope becomes a combination of IP and client key)
                    //ClientThrottling = true,
                    //ClientRules = new Dictionary<string, RateLimits>
                    //{
                    //    { "api-client-key-1", new RateLimits { PerMinute = 60, PerHour = 600 } },
                    //    { "api-client-key-9", new RateLimits { PerDay = 5000 } }
                    //},
                    ////white list API keys that don’t require throttling
                    //ClientWhitelist = new List<string> { "admin-key" },

                    //scope to endpoints
                    EndpointThrottling = true,
                    EndpointRules = new Dictionary<string, RateLimits>
                    {
                        { "api/users", new RateLimits { PerSecond = 10, PerMinute = 100, PerHour = 1000 } }
                    }
                },
                policyRepository: new PolicyCacheRepository(),
                repository: new CacheRepository(),
                logger: new TracingThrottleLogger(traceWriter),
                ipAddressParser: new CustomIpAddressParser()));

        }
    }
}
