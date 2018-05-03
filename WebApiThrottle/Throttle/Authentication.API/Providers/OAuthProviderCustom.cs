using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Authentication.API.Providers
{
    public class OAuthProviderCustom : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //// this is use to validate audience id and secret id if it's listed on db
            //string clientId = string.Empty;
            //string clientSecret = string.Empty;
            //string symmetricKeyAsBase64 = string.Empty;

            //if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            //{
            //    context.TryGetFormCredentials(out clientId, out clientSecret);
            //}

            //if (context.ClientId == null)
            //{
            //    context.SetError("invalid_clientId", "client_Id is not set");
            //    return Task.FromResult<object>(null);
            //}

            //var audience = AudiencesStore.FindAudience(context.ClientId);

            //if (audience == null)
            //{
            //    context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
            //    return Task.FromResult<object>(null);
            //}
            //// end of validate audience/client id

            context.Validated();
            return Task.FromResult<Object>(null);
        }

        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    var allowedOrigin = "*";
        //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

        //    //var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

        //    //ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

        //    if (user == null)
        //    {
        //        context.SetError("invalid_grant", "The user name or password is incorrect.");
        //        return;
        //    }

        //    if (!user.EmailConfirmed)
        //    {
        //        context.SetError("invalid_grant", "User did not confirm email.");
        //        return;
        //    }

        //    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

        //    //oAuthIdentity.AddClaims(ExtendedClaimsProvider.GetClaims(user));

        //    //oAuthIdentity.AddClaims(RolesFromClaims.CreateRolesBasedOnClaims(oAuthIdentity));

        //    var ticket = new AuthenticationTicket(oAuthIdentity, null);

        //    context.Validated(ticket);

        //}
    }
}