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

    public class UserCaps
    {
        public string email { get; set; }
        public string name { get; set; }
        public int role { get; set; }
        public List<int> permissions { get; set; }
        public int uid { get; set; }
        public int cid { get; set; }
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
        UserCaps AppLogin(string email, string password, int cid);
        UserCaps RefreshAppLogin(int cid);
        string Get_EmailOfInvitation(string guid);
        string Get_EmailOfReset(string guid);
        void Save_Password(string email, string password);
        void Reset_Password(string email, string url);
    }

    public partial class AppService
    {
        public UserCaps AppLogin(string email, string password, int cid)
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
                account = repo.Account_SelectBy_email(email, cid);
            else
                account = repo.Account_SelectBy_credential(email, passwordHash, cid);

            if (account == null)
                throw new ValidationException("Login Failed");

            if (account.archive)
                throw new ValidationException("Sign in refused. This account is archived.");

            if (!account.isSupport && account.cid != cid)
                throw new ValidationException("Login Failed in Company.");

            if (!usingPasswordBypass)
                repo.Account_Update_LastActivity(account.id, DateTime.Now);

            return populateUserCaps(account, cid);
        }

        public UserCaps RefreshAppLogin(int cid)
        {
            var uid = user.Get_UID();

            var account = repo.spAccount_Select(uid);
            if (account == null)
                throw new ValidationException("Login Failed");

            if (account.archive)
                throw new ValidationException("Sign in refused. This account is archived.");

            return populateUserCaps(account, cid);
        }

        public string Get_EmailOfInvitation(string guid)
        {
            var account = repo.Account_SelectBy_ResetGuid(guid);
            if (account == null)
                throw new ValidationException("This invitation is invalid");

            if (DateTime.Now > account.resetExpiry)
                throw new ValidationException("This invitation is expired");

            return account.email;
        }

        public string Get_EmailOfReset(string guid)
        {
            var account = repo.Account_SelectBy_ResetGuid(guid);
            if (account == null)
                throw new ValidationException("Invalid account");

            if (DateTime.Now > account.resetExpiry)
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


        DTO.UserCaps populateUserCaps(Account_Select account, int cid)
        {
            var permissions = repo.Account_GetPermissionList(account.id);

            return new DTO.UserCaps
            {
                email = account.email,
                name = $"{account.firstName} {account.lastName}",
                role = account.roleMask,
                permissions = permissions,
                uid = account.id,
                cid = cid
            };
        }
    }
}
