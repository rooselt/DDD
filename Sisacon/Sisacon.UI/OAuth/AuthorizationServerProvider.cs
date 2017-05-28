using Microsoft.Owin.Security.OAuth;
using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Sisacon.UI.OAuth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var username = context.UserName;
                var password = context.Password;


                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, username));

                var roles = new List<string>
                {
                    "Admin",
                    "User"
                };

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch
            {
                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }

        private Client Logon(string username, string pass)
        {
            var client = new Client();
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(string.Format("{0}/api/user", _apiUrl)),
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add

            return client;
        }
    }
}