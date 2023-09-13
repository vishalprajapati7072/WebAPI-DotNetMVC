using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebAPI_DotNetMVC.Filters
{
    public class CustomAuthFilter : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            System.Net.Http.HttpRequestMessage request = context.Request;
            System.Net.Http.Headers.AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            //if (string.IsNullOrEmpty(authorization.Parameter))
            //{
            //    context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
            //    return;
            //}

            string token = authorization.Parameter;
            IPrincipal principal = await AuthenticateJwtToken(token);
            if (principal == null) return;

            //if (principal == null)
            //    context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            else
                context.Principal = principal;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            // Challenge(context);
            return Task.FromResult(0);
        }

        private static bool ValidateToken(string token, out string username)
        {
            ClaimsPrincipal simplePrinciple = TokenManager.GetPrincipal(token);
            ClaimsIdentity identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
            {
                username = null;
                return false;
            }

            if (!identity.IsAuthenticated)
            {
                username = null;
                return false;
            }

            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            if (ValidateToken(token, out string username))
            {
                // based on username to get more information from database in order to build local identity
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    // Add more claims if needed: Roles, ...
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }
    }
}