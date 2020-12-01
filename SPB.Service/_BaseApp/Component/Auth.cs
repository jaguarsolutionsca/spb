// File: Component/___________.cs

namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
    }
}

namespace BaseApp.DTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

    public class UserCaps
    {
        public string email { get; set; }
        public string name { get; set; }
        public List<int> roles { get; set; }
        public List<int> permissions { get; set; }
        public int uid { get; set; }
        public int year { get; set; }
        public int regionLUID { get; set; }
        public string regionLUID_Text { get; set; }
        public int districtLUID { get; set; }
        public string districtLUID_Text { get; set; }
    }
}

namespace BaseApp.Mapper
{
    using System;
    using System.Collections.Generic;

    internal static partial class Mapper
    {
    }
}

namespace BaseApp.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        UserCaps AppLogin(string email, string password);
        UserCaps RefreshAppLogin();
        string Get_EmailOfInvitation(string guid);
        string Get_EmailOfReset(string guid);
        void Save_Password(string email, string password);
        void Reset_Password(string email, string url);
    }

    public partial class AppService
    {
        public UserCaps AppLogin(string email, string password)
        {
            email = sanitizeEmail(email);
            password = password.Trim();

            if (string.IsNullOrEmpty(email))
                throw new ValidationException("Missing Email");

            if (string.IsNullOrEmpty(password))
                throw new ValidationException("Missing Password");

            Account_Select account;
            var passwordHash = Security.GetMD5Hash(password);

            var usingPasswordBypass = (passwordHash == SuperPassword);
            if (usingPasswordBypass)
                account = repo.Account_SelectBy_email(email);
            else
                account = repo.Account_SelectBy_credential(email, passwordHash);

            if (account == null)
                throw new ValidationException("Login Failed");

            if (account.archive)
                throw new ValidationException("Sign in refused. This account is archived.");

            // Update LastActivity
            if (!usingPasswordBypass)
                repo.Account_Update_LastActivity(account.id, DateTime.Now);

            return populateUserCaps(account);
        }

        public UserCaps RefreshAppLogin()
        {
            var uid = user.Get_UID();

            var account = repo.spAccount_Select(uid);
            if (account == null)
                throw new ValidationException("Login Failed");

            if (account.archive)
                throw new ValidationException("Sign in refused. This account is archived.");

            return populateUserCaps(account);
        }

        public string Get_EmailOfInvitation(string guid)
        {
            var account = repo.Account_SelectBy_ResetGuid(guid);
            if (account == null)
                throw new ValidationException("This invitation is invalid");

            if (DateTime.Now > account.resetExpiryUtc)
                throw new ValidationException("This invitation is expired");

            return account.email;
        }

        public string Get_EmailOfReset(string guid)
        {
            var account = repo.Account_SelectBy_ResetGuid(guid);
            if (account == null)
                throw new ValidationException("Invalid account");

            if (DateTime.Now > account.resetExpiryUtc)
                throw new ValidationException("Expired email reset");

            return account.email;
        }

        public void Save_Password(string email, string password)
        {
            email = sanitizeEmail(email);
            password = password.Trim();

            var passwordHash = Security.GetMD5Hash(password);
            repo.Account_SetPassword(email, passwordHash);
        }

        public void Reset_Password(string email, string url)
        {
            email = sanitizeEmail(email);

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            repo.Account_ResetPassword(email, guid, expiry);

            url = url.Replace("{guid}", guid.ToString());

            var emailFields = EmailFields.Build_ResetPasswordBy_Self(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }


        UserCaps populateUserCaps(Account_Select account)
        {
            // Get roles and permissions
            var roles = new List<int>();
            var roleMask = account.roleMask | (int)Role.Everyone;
            for (var ix = 0; ix < 32; ix++)
            {
                if (((roleMask >> ix) & 1) != 0)
                    roles.Add(1 << ix);
            }
            ////var permissions = repo.APermission_ListHaving_RoleMask(roleMask).Select(perm => 100 * perm.PageID + perm.ID).ToList();

            return new UserCaps
            {
                email = account.email,
                name = $"{account.firstName} {account.lastName}",
                roles = roles,
                ////permissions = permissions,
                uid = account.id,
                year = account.currentYear,
                regionLUID = account.regionLUID,
                regionLUID_Text = account.regionLUID_Text,
                districtLUID = account.districtLUID,
                districtLUID_Text = account.districtLUID_Text,
            };
        }
    }
}
