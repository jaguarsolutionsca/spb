// File: Component/Account.cs

using BaseApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BaseApp.DTO
{
    public class Account_Basic
    {
        public int uid { get; set; }
        public int cie { get; set; }
        public string cie_Text { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int roleMask { get; set; }
        public bool isSupport { get; set; }
        public bool archive { get; set; }

        internal Account_Basic Decrypt(Common.Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            return this;
        }
    }

    public class Account_PK
    {
        public int uid { get; set; }
    }
}

namespace BaseApp.Service
{
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;
    using BaseApp.Mapper;

    public partial interface IAppService
    {
        object Account_Search(Dico pager);
        object Account_Select(int uid);
        object Account_New(int cie);
        object Account_Insert(Dico uto, string url);
        void Account_Update(Dico uto);
        void Account_Delete(Dico key);
        void Auto_Archive(int cie);
        void Reset_PasswordBy_Admin(int uid, string url);
        void Create_Invitation(int uid, string url);
    }

    public partial class AppService
    {
        public object Account_Search(Dico pager)
        {
            pager = pager.ReviveUTO(flatten: false);
            var pn = pager.Parse<int>("pageNo");
            var ps = pager.Parse<int>("pageSize");
            var sc = pager.Parse<string>("sortColumn");
            var sd = pager.Parse<string>("sortDirection");
            var txt = pager.Parse<string>("searchText");

            var filter = pager["filter"] as Dico;
            var list = repo.queryDicoList("app.Account_List", KVList.Build(filter), uid: true);

            list.ForEach(one =>
            {
                one["email"] = crypto.Decrypt(one.Parse<string>("email"));
                one["firstname"] = crypto.Decrypt(one.Parse<string>("firstname"));
                one["lastname"] = crypto.Decrypt(one.Parse<string>("lastname"));
                one["by"] = crypto.Decrypt(one.Parse<string>("by"));
            });

            if (!string.IsNullOrEmpty(txt))
            {
                var search = txt.ToLower();
                list = list.Where(one => {
                    var email = one.Parse<string>("email");
                    var firstName = one.Parse<string>("firstName");
                    var lastName = one.Parse<string>("lastName");
                    return email.ToLower().Contains(search) ||
                        firstName.ToLower().Contains(search) ||
                        lastName.ToLower().Contains(search);
                }).ToList();
            }

            list.ForEach(one => one["totalcount"] = list.Count);
            pager["rowCount"] = list.Count;

            if (!string.IsNullOrEmpty(sc))
            {
                var sortBy = sc.ToLower();
                var ascending = string.Compare(sd ?? "ASC", "ASC", true) == 0;
                switch (sortBy)
                {
                    case "email":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.Parse<string>("email"), b.Parse<string>("email"), true) :
                            string.Compare(b.Parse<string>("email"), a.Parse<string>("email"), true));
                        break;

                    case "firstname":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.Parse<string>("firstname"), b.Parse<string>("firstname"), true) :
                            string.Compare(b.Parse<string>("firstname"), a.Parse<string>("firstname"), true));
                        break;

                    case "lastname":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.Parse<string>("lastname"), b.Parse<string>("lastname"), true) :
                            string.Compare(b.Parse<string>("lastname"), a.Parse<string>("lastname"), true));
                        break;

                    case "roleluid_text":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.Parse<string>("roleluid_text"), b.Parse<string>("roleluid_text"), true) :
                            string.Compare(b.Parse<string>("roleluid_text"), a.Parse<string>("roleluid_text"), true));
                        break;

                    case "archive":
                        list.Sort((a, b) => ascending ?
                            (a.Parse<bool>("archive") ? 1 : 0) - (b.Parse<bool>("archive") ? 1 : 0) :
                            (b.Parse<bool>("archive") ? 1 : 0) - (a.Parse<bool>("archive") ? 1 : 0));
                        break;

                    case "readytoarchive":
                        list.Sort((a, b) => ascending ?
                            (a.Parse<bool>("readytoarchive") ? 1 : 0) - (b.Parse<bool>("readytoarchive") ? 1 : 0) :
                            (b.Parse<bool>("readytoarchive") ? 1 : 0) - (a.Parse<bool>("readytoarchive") ? 1 : 0));
                        break;

                    case "lastactivity":
                        list.Sort((a, b) => ascending ?
                            DateTime.Compare(a.ParseDateTime("lastactivity") ?? DateTime.MinValue, b.ParseDateTime("lastactivity") ?? DateTime.MinValue) :
                            DateTime.Compare(b.ParseDateTime("lastactivity") ?? DateTime.MinValue, a.ParseDateTime("lastactivity") ?? DateTime.MinValue));
                        break;

                    default:
                        break;
                }
            }

            list = list
                .Skip((pn - 1) * ps)
                .Take(ps)
                .ToList();

            return new
            {
                list = list,
                pager = pager,
                xtra = (object)null
            };
        }

        public object Account_Select(int uid)
        {
            var item = repo.queryDico("app.Account_Select", "@uid", uid, uid: true)
                .ReviveDTO()
                .Decrypt(crypto, new string[] { "email", "firstname", "lastname", "by" });

            var xtra = repo.queryDico("app.Account_Summary", "@uid", uid)
                .ReviveDTO()
                .Decrypt(crypto, "title");

            return new
            {
                item = item,
                xtra = xtra
            };
        }

        public object Account_New(int cie)
        {
            return new
            {
                item = repo.queryDico("app.Account_New", "@cie", cie, uid: true)
                    .ReviveDTO()
                    .Decrypt(crypto, "by"),
                xtra = (object)null
            };
        }

        public object Account_Insert(Dico uto, string url)
        {
            uto.TrimKeys(new string[] { "uid", "cie_text", "roleluid_text", "rolemask", "resetguid", "resetexpiry", "issupport", "lastactivity", "isadminreset", "readytoarchive", "canextendinvitation", "canresetpassword", "cancreateinvitation", "created", "updated", "updatedby", "by" });

            var appProps = new string[] { "cie", "email", "password", "roleluid", "firstname", "lastname", "userealemail", "archivedays", "currentyear", "comment", "archive" };
            var appUTO = uto.ReviveUTO(whitelist: appProps);
            var dboUTO = uto.ReviveUTO(blacklist: appProps);

            appUTO.Add("profileJson", Dico.Serialize(dboUTO));

            var archive = appUTO.Parse<bool>("archive");
            var email = appUTO.Parse<string>("email");
            var firstname = appUTO.Parse<string>("firstname");
            var lastname = appUTO.Parse<string>("lastname");
            var cie = appUTO.Parse<int>("cie");
            email = sanitizeEmail(email);

            appUTO["email"] = crypto.Encrypt(email);
            appUTO["firstname"] = crypto.Encrypt(firstname);
            appUTO["lastname"] = crypto.Encrypt(lastname);


            if (!email.Contains("@"))
                throw new ValidationException("Email requires an '@' character");

            if (email.Length > 50)
                throw new ValidationException("Email is too long (max length = 50)");

            if (firstname.Length > 50)
                throw new ValidationException("First name is too long (max length = 50)");

            if (lastname.Length > 50)
                throw new ValidationException("Last name is too long (max length = 50)");


            int uid;
            if (appUTO.Parse<bool>("userealemail"))
            {
                var resetGuid = Guid.NewGuid();
                appUTO["resetGuid"] = resetGuid;
                appUTO["resetExpiry"] = DateTime.Now.AddDays(7); // one week from now

                uid = repo.queryScalar<int>("app.Account_Insert", KVList.Build(appUTO), uid: true);
                var company = appUTO.Parse<string>("company_text");

                url = url.Replace("{company}", company);
                url = url.Replace("{guid}", resetGuid.ToString());

                var emailFields = EmailFields.Build_Invitation(url);
                SendEmail(email, emailFields.subject, emailFields.bodyText);
            }
            else
            {
                var password = appUTO.Parse<string>("password");

                if (!string.IsNullOrWhiteSpace(password))
                    password = get_PasswordHash(password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(password);

                uid = repo.queryScalar<int>("app.Account_Insert", KVList.Build(appUTO), uid: true);
            }

            return new
            {
                uid = uid
            };
        }

        public void Account_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "cie_text", "roleluid_text", "rolemask", "resetguid", "resetexpiry", "issupport", "lastactivity", "isadminreset", "readytoarchive", "canextendinvitation", "canresetpassword", "cancreateinvitation", "created", "updatedby", "by" });

            var appProps = new string[] { "uid", "cie", "email", "password", "roleluid", "firstname", "lastname", "userealemail", "archivedays", "currentyear", "comment", "archive", "updated" };
            var appUTO = uto.ReviveUTO(whitelist: appProps);
            var dboUTO = uto.ReviveUTO(blacklist: appProps);

            appUTO.Add("profileJson", Dico.Serialize(dboUTO));

            var uid = appUTO.Parse<int>("uid");
            var archive = appUTO.Parse<bool>("archive");
            var email = appUTO.Parse<string>("email");
            var firstname = appUTO.Parse<string>("firstname");
            var lastname = appUTO.Parse<string>("lastname");
            email = sanitizeEmail(email);

            appUTO["email"] = crypto.Encrypt(email);
            appUTO["firstname"] = crypto.Encrypt(firstname);
            appUTO["lastname"] = crypto.Encrypt(lastname);


            if (uid == 0 && user.Get_UID() != 0)
                throw new ValidationException("Only the administrator can update this account!");

            if (uid == user.Get_UID() && archive)
                throw new ValidationException("You cannot archive your own account!");

            if (!email.Contains("@"))
                throw new ValidationException("Email requires an '@' character");

            if (email.Length > 50)
                throw new ValidationException("Email is too long (max length = 50)");

            if (firstname.Length > 50)
                throw new ValidationException("First name is too long (max length = 50)");

            if (lastname.Length > 50)
                throw new ValidationException("Last name is too long (max length = 50)");


            if (!appUTO.Parse<bool>("userealemail"))
            {
                var password = appUTO.Parse<string>("password");

                if (!string.IsNullOrWhiteSpace(password))
                    password = get_PasswordHash(password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(password);
            }

            repo.queryNonQuery("app.Account_Update", KVList.Build(appUTO), uid: true);
        }

        public void Account_Delete(Dico key)
        {
            repo.queryNonQuery("app.Account_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }

        public void Auto_Archive(int cie)
        {
            repo.queryNonQuery("app.Account_AutoArchive", "@cie", cie);
        }

        void Account_ResetPassword(string email, Guid guid, DateTime expiry, bool forcedReset = false, bool unArchive = false)
        {
            repo.queryNonQuery("app.Account_ResetPassword", new KVList()
                .Add("@email", crypto.Encrypt(email))
                .Add("@guid", guid)
                .Add("@expiry", expiry)
                .Add("@isAdminReset", forcedReset)
                .Add("@unArchive", unArchive));
        }

        public void Reset_PasswordBy_Admin(int uid, string url)
        {
            if (uid == 0 && user.Get_UID() != 0)
                throw new ValidationException("Only the administrator can reset his password!");

            var item = repo.queryDico("app.Account_Select", "@uid", uid, uid: true).ReviveDTO();
            var email = crypto.Decrypt(item.Parse<string>("email"));

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            Account_ResetPassword(email, guid, expiry, forcedReset: true, unArchive: true);

            url = url.Replace("{guid}", guid.ToString());

            var emailFields = EmailFields.Build_ResetPasswordBy_Admin(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }

        public void Create_Invitation(int uid, string url)
        {
            var item = repo.queryDico("app.Account_Select", "@uid", uid, uid: true).ReviveDTO();
            var email = crypto.Decrypt(item.Parse<string>("email"));

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            Account_ResetPassword(email, guid, expiry, unArchive: true);

            url = url.Replace("{guid}", guid.ToString());
            var emailFields = EmailFields.Build_Invitation(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }

        internal static string sanitizeEmail(string email)
        {
            return email.ToLower().Replace(" ", "").Trim();
        }
    }
}
