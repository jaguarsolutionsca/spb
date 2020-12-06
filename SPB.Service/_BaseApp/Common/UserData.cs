using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Common
{
    public class UserData
    {
        public const string ClaimType_Name = "name";
        public const string ClaimType_UID = "uid";
        public const string ClaimType_CIE = "cie";
        public const string ClaimType_Perms = "perms";

        public static bool HasBearerAuthorization(string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader))
                return false;
            return authorizationHeader.StartsWith("Bearer ");
        }

        public static string WrapBearerAuthorization(string token64)
        {
            return "Bearer " + token64;
        }

        public static string UnWrapBearerAuthorization(string authorizationHeader)
        {
            return authorizationHeader.Substring("Bearer ".Length);
        }

        #region obsolete

        /*
        public int uid { get; set; }
        public int[] roles { get; set; }
        public int[] perms { get; set; }

        public static UserData Build(int uid, List<int> roles, List<int> perms)
        {
            return new UserData
            {
                uid = uid,
                roles = roles.ToArray(),
                perms = perms.ToArray(),
            };
        }

        public static UserData Parse(string userData)
        {
            var parts = userData.Split('|');
            var uid = int.Parse(parts[0]);
            var roles = string.IsNullOrEmpty(parts[1]) ? new List<int>() : parts[1].Split(',').Select(int.Parse).ToList();
            var perms = string.IsNullOrEmpty(parts[2]) ? new List<int>() : parts[2].Split(',').Select(int.Parse).ToList();
            return Build(uid, roles, perms);
        }

        override public string ToString()
        {
            return $"{uid}|{string.Join(",", roles)}|{string.Join(",", perms)}";
        }
        */

        #endregion
    }
}
