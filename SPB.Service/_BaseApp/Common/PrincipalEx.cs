using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public static class PrincipalEx
    {
        public static bool HasRole(this IPrincipal principal, int role)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            if (claimsPrincipal.IsInRole(((int)Service.Role.Admin).ToString()))
                return true;

            return claimsPrincipal.IsInRole(role.ToString());
        }

        public static string Get_Email(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            return claimsPrincipal.Claims.SingleOrDefault(one => one.Type == ClaimTypes.Email)?.Value;
        }

        public static int Get_UID(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            int.TryParse(claimsPrincipal.Claims.SingleOrDefault(one => one.Type == UserData.ClaimType_UID)?.Value, out int uid);
            return uid;
        }

        public static int Get_CIE(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            int.TryParse(claimsPrincipal.Claims.SingleOrDefault(one => one.Type == UserData.ClaimType_CIE)?.Value, out int cie);
            return cie;
        }

        public static List<int> Get_Permissions(this IPrincipal principal)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            return claimsPrincipal.Claims
                .Where(one => one.Type == UserData.ClaimType_Perms)
                .Select(one => int.Parse(one.Value))
                .ToList();
        }

        public static bool HasPermission(this IPrincipal principal, int permission)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            if (claimsPrincipal.IsInRole(((int)Service.Role.Admin).ToString()))
                return true;

            var perms = principal.Get_Permissions();
            return perms.Contains(permission);
        }

        public static bool HasPermission(this IPrincipal principal, Service.Perm permission)
        {
            return principal.HasPermission((int)permission);
        }

        public static bool DoesNotHavePermission(this IPrincipal principal, int permission)
        {
            var claimsPrincipal = (ClaimsPrincipal)principal;
            if (claimsPrincipal.IsInRole(((int)Service.Role.Admin).ToString()))
                return false;

            var perms = principal.Get_Permissions();
            return !perms.Contains(permission);
        }
    }
}
