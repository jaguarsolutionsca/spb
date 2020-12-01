using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BaseApp.Common;
using BaseApp.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BaseApp.Web
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAppService app;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAppService userService)
            : base(options, logger, encoder, clock)
        {
            app = userService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            DTO.UserCaps usercaps = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                usercaps = app.AppLogin(username, password);
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }

            if (usercaps == null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usercaps.email));
            claims.Add(new Claim(UserData.ClaimType_UID, usercaps.uid.ToString()));
            claims.Add(new Claim(UserData.ClaimType_Year, usercaps.year.ToString()));
            claims.Add(new Claim(UserData.ClaimType_RegionLUID, usercaps.regionLUID.ToString()));
            claims.Add(new Claim(UserData.ClaimType_RegionLUID_Text, usercaps.regionLUID_Text));
            claims.Add(new Claim(UserData.ClaimType_DistrictLUID, usercaps.districtLUID.ToString()));
            claims.Add(new Claim(UserData.ClaimType_DistrictLUID_Text, usercaps.districtLUID_Text));
            foreach (var permission in usercaps.permissions)
            {
                claims.Add(new Claim(UserData.ClaimType_Perms, permission.ToString(), ClaimValueTypes.Integer));
            }
            foreach (var role in usercaps.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString(), ClaimValueTypes.Integer));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
