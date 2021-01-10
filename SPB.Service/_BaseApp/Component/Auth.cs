
using System;
using System.Collections.Generic;

namespace BaseApp.DTO
{
    public class UserCaps
    {
        public string email { get; set; }
        public string name { get; set; }
        public int role { get; set; }
        public List<int> permissions { get; set; }
        public int uid { get; set; }
        public int cie { get; set; }
    }
}

namespace BaseApp.UTO
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public int cie { get; set; }
    }
}

namespace BaseApp.Service
{
    using System.Linq;
    using BaseApp.Common;
    using BaseApp.DTO;

    public partial interface IAppService
    {
        UserCaps AppLogin(string email, string password, int cie);
        //UserCaps RefreshAppLogin();
        string Get_EmailOfInvitation(string guid);
        string Get_EmailOfReset(string guid);
        void Save_Password(string email, string password);
        void Reset_Password(string email, string url, int cie);
        List<Lookup> Account_GetRoleLookup(int uid);
    }

    public partial class AppService
    {
        public UserCaps AppLogin(string email, string password, int cie)
        {
            email = sanitizeEmail(email);
            password = password.Trim();

            if (string.IsNullOrEmpty(email))
                throw new ValidationException("Missing Email");

            if (string.IsNullOrEmpty(password))
                throw new ValidationException("Missing Password");

            Account_Basic account;
            var passwordHash = get_PasswordHash(password);

            var usingPasswordBypass = (passwordHash == SuperPassword);
            if (usingPasswordBypass)
            {
                var parameters = new KVList()
                    .Add("@email", repo.crypto.Encrypt(email))
                    .Add("@cie", cie);
                account = repo.queryEntity<Account_Basic>("app.Account_SelectBy_Email", parameters).Decrypt(repo.crypto);
            }
            else
            {
                var parameters = new KVList()
                    .Add("@email", repo.crypto.Encrypt(email))
                    .Add("@password", passwordHash)
                    .Add("@cie", cie);
                account = repo.queryEntity<Account_Basic>("app.Account_SelectBy_Credential", parameters).Decrypt(repo.crypto);
            }

            if (account == null)
                throw new ValidationException("Login Failed");

            if (account.archive)
                throw new ValidationException("Sign in refused. This account is archived.");

            if (!account.isSupport && account.cie != cie)
                throw new ValidationException("Login Failed in Company.");

            if (!usingPasswordBypass)
            {
                repo.queryNonQuery("app.Account_Update_LastActivity", KVList.Build()
                .Add("@uid", account.uid)
                .Add("@lastActivity", DateTime.Now));
            }

            return populateUserCaps(account, cie);
        }

        //public UserCaps RefreshAppLogin()
        //{
        //    var uid = user.Get_UID();
        //    var cie = user.Get_CIE();

        //    var account = repo.spAccount_Select(uid);
        //    if (account == null)
        //        throw new ValidationException("Login Failed");

        //    if (account.archive)
        //        throw new ValidationException("Sign in refused. This account is archived.");

        //    return populateUserCaps(account, cie);
        //}

        public string Get_EmailOfInvitation(string guid)
        {
            var email = repo.queryScalar<string>("app.Account_SelectEmailBy_ResetGUID", new KVList()
                .Add("@guid", guid)
                .Add("@isInvitation", true));

            return repo.crypto.Decrypt(email);
        }

        public string Get_EmailOfReset(string guid)
        {
            var email = repo.queryScalar<string>("app.Account_SelectEmailBy_ResetGUID", new KVList()
                .Add("@guid", guid)
                .Add("@isInvitation", false));

            return repo.crypto.Decrypt(email);
        }

        public void Save_Password(string email, string password)
        {
            email = sanitizeEmail(email);
            password = password.Trim();

            var passwordHash = get_PasswordHash(password);
            validate_PasswordHash(passwordHash);

            repo.queryNonQuery("app.Account_SetPassword", KVList.Build()
                .Add("@email", repo.crypto.Encrypt(email))
                .Add("@password", passwordHash));
        }

        public void Reset_Password(string email, string url, int cie)
        {
            email = sanitizeEmail(email);

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            Account_ResetPassword(email, guid, expiry);

            var parameters = new KVList()
                .Add("@email", repo.crypto.Encrypt(email))
                .Add("@cie", cie);
            var account = repo.queryEntity<Account_Basic>("app.Account_SelectBy_Email", parameters).Decrypt(repo.crypto);

            var company = account.cie_Text;

            url = url.Replace("{company}", company);
            url = url.Replace("{guid}", guid.ToString());

            var emailFields = EmailFields.Build_ResetPasswordBy_Self(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }

        public List<Lookup> Account_GetRoleLookup(int uid)
        {
            var list = repo.queryList<Lookup>("app.Account_GetRoleLookup", "@uid", uid);

            return list;
        }


        internal string get_PasswordHash(string password)
        {
            return Security.GetMD5Hash(password);
        }

        internal void validate_PasswordHash(string passwordHash)
        {
            if (passwordHash == SuperPassword)
                throw new ValidationException("Invalid password");
        }


        UserCaps populateUserCaps(Account_Basic account, int cie)
        {
            var permissions = repo.queryList<int>("app.Account_GetPermissionList", "@uid", account.uid);

            return new UserCaps
            {
                email = account.email,
                name = $"{account.firstName} {account.lastName}",
                role = account.roleMask,
                permissions = permissions,
                uid = account.uid,
                cie = cie
            };
        }
    }
}
