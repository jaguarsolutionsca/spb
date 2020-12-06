using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Service;
    using BaseApp.Web.Models;
    using Belgrade.SqlClient;
    using Belgrade.SqlClient.SqlDb;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    public class PortalBag
    {
        public bool isDev { get; set; }
        public string instance { get; set; }
        public int cie { get; set; }
        public object feature { get; set; }
    }

    public abstract class _CoreController : Controller
    {
        private ILogger _logger;
        protected ILogger logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<object>>());

        private IAppService _app;
        protected IAppService app => _app ?? (_app = HttpContext.RequestServices.GetService<IAppService>());

        private IConfiguration _config;
        protected IConfiguration config => _config ?? (_config = HttpContext.RequestServices.GetService<IConfiguration>());

        private IWebHostEnvironment _hosting;
        protected IWebHostEnvironment hosting => _hosting ?? (_hosting = HttpContext.RequestServices.GetService<IWebHostEnvironment>());

        //private IReportService _report;
        //protected IReportService report => _report ?? (_report = HttpContext.RequestServices.GetRequiredService<IReportService>());

        //private IMapService _map;
        //protected IMapService map => _map ?? (_map = HttpContext.RequestServices.GetRequiredService<IMapService>());

        private QueryPipe _sqlPipe;
        protected QueryPipe sqlPipe => _sqlPipe ?? (_sqlPipe = (QueryPipe)HttpContext.RequestServices.GetService<IQueryPipe>());

        private Command _sqlCommand;
        protected Command sqlCommand => _sqlCommand ?? (_sqlCommand = (Command)HttpContext.RequestServices.GetService<ICommand>());


        #region IDisposable Support

        bool disposedValue = false; // To detect redundant Dispose() calls

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    app.Dispose();
                }
                disposedValue = true;
            }
        }

        #endregion


        public AuthorizationData populateAuthorizationData(UserCaps usercaps)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, usercaps.email));
            claims.Add(new Claim(UserData.ClaimType_Name, usercaps.name));
            claims.Add(new Claim(UserData.ClaimType_UID, usercaps.uid.ToString()));
            claims.Add(new Claim(UserData.ClaimType_CIE, usercaps.cie.ToString()));
            foreach (var permission in usercaps.permissions)
            {
                claims.Add(new Claim(UserData.ClaimType_Perms, permission.ToString(), ClaimValueTypes.Integer));
            }
            claims.Add(new Claim(ClaimTypes.Role, usercaps.role.ToString(), ClaimValueTypes.Integer));

            var secretKey = new SymmetricSecurityKey(app.IssuerSigningKey);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: app.Issuer,
                audience: app.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(app.FormsAuthenticationTimeoutTotalMinutes),
                signingCredentials: signinCredentials
            );

            return new AuthorizationData
            {
                token = new JwtSecurityTokenHandler().WriteToken(tokenOptions)
            };
        }

        public string buildUIRouterUrl(string route)
        {
            var referer = HttpContext.Request.Headers["Referer"].ToString();
            if (referer.EndsWith("/"))
                referer = referer.Substring(0, referer.Length - 1);
            return $"{referer}#/{route}";
        }

        public PortalBag buildPortalBag(Uri uri)
        {
            var isDev = hosting.IsDevelopment();
            var instance = config.GetValue<string>("AppSettings:instance") ?? "_instance_not_set_";


            //
            // Get the company that is specified in the query (/?company_from_query#).
            // This value is the *actual* company used in the application (if specified).
            // The company in the domain name (if any) will be used if the company name is not specified on the query.
            // Will throw an exception if the company is not found.
            //
            var company_from_query = HttpRequestHelper.CompanyFromQuery(uri);
            var company_from_domain = HttpRequestHelper.CompanyFromDomain(uri);

            var id = app.Company_GetID(company_from_query) ?? app.Company_GetID(company_from_domain);
            var cie = id.Value;


            //
            // Get network features from the database
            //
            var feature = app.Company_GetFeature(cie);


            return new PortalBag
            {
                isDev = isDev,
                instance = instance,
                cie = cie,
                feature = feature
            };
        }
    }
}