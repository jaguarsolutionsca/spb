using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseApp.Web
{
    public class HttpRequestHelper
    {
        internal static Uri GetUri(HttpRequest request)
        {
            var protocol = (request.IsHttps ? "https" : "http");
            var host = request.Host.Value;
            var path = request.Path.Value;
            var queryString = request.QueryString.Value;
            var url = $"{protocol}://{host}{path}{queryString}";
            return new Uri(url);
        }

        internal static string CompanyFromDomain(Uri uri)
        {
            //
            // Extract company and locationid from the domain part of the url, if present
            // domain can be "nbc", "gray", "vship", ..., "portal", "ct", "localhost"
            // locationid == 0 for generic location, locationid == 1 for NYC, locationid == 2 for ATL
            //
            var domain = uri.Host.ToLower().Split('.')[0];

            var company_name_from_domain = domain;
            var locationid = 0;

            var pattern = @"(.+)(\d)$";
            var match = Regex.Match(company_name_from_domain, pattern);
            if (match.Groups.Count == 3)
            {
                company_name_from_domain = match.Groups[1].Value;
                locationid = int.Parse(match.Groups[2].Value);
            }

            return company_name_from_domain;
        }

        internal static string CompanyFromQuery(Uri uri)
        {
            //
            // Get the company that is specified in the query (/?company_name_from_query#).
            //
            string company_name_from_query = null;

            if (!string.IsNullOrEmpty(uri.Query))
                company_name_from_query = uri.Query.Replace("?", "").Split('&')[0];

            return company_name_from_query;
        }
    }
}
