// File: Component/Account.cs

using BaseApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BaseApp.DAL
{
    using BaseApp.Common;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class Account_Insert : UTO.Account_Insert
    {
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiry { get; set; }
        public int updatedBy { get; set; }

        internal Account_Insert ToLocalTime()
        {
            return this;
        }
    }

    public class Account_Update : UTO.Account_Update
    {
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiry { get; set; }

        public Account_Update ToLocalTime()
        {
            resetExpiry = resetExpiry?.ToLocalTime();
            updated = updated.ToLocalTime();
            return this;
        }
    }

    internal partial class Repo
    {
        public DTO.Account_Full spAccount_Select(int uid)
        {
            return queryEntity<DTO.Account_Full>("app.Account_Select", "@uid", uid)?
                .Decrypt(crypto)
                .Deserialize();
        }

        public DTO.Account_Full spAccount_New(int cie)
        {
            return queryEntity<DTO.Account_Full>("app.Account_New", "@cie", cie)
                .Decrypt(crypto)
                .Deserialize();
        }

        public int spAccount_Insert(Account_Insert entity)
        {
            entity.Serialize();
            entity.Encrypt(crypto);
            entity.ToLocalTime();
            return queryScalar<int>("app.Account_Insert", KVList.Build<Account_Insert>(entity));
        }

        public void spAccount_Update(Account_Update entity)
        {
            entity.Serialize();
            entity.Encrypt(crypto);
            entity.ToLocalTime();
            queryNonQuery("app.Account_Update", KVList.Build<Account_Update>(entity));
        }

        public void spAccount_Delete(int uid, DateTime updated)
        {
            queryNonQuery("app.Account_Delete", KVList.Build()
                .Add("@uid", uid)
                .Add("@updated", updated.ToLocalTime())
                );
        }

        public DTO.Account_Summary spAccount_Summary(int uid)
        {
            var summary = queryEntity<DTO.Account_Summary>("app.Account_Summary", "@uid", uid);
            summary.title = crypto.Decrypt(summary.title);
            return summary;
        }
    }
}

namespace BaseApp.DTO
{
    public class Account_Search : Account_PK
    {
        public int totalCount { get; set; }
        public string cie_Text { get; set; }
        public string email { get; set; }
        public string roleLUID_Text { get; set; }
        public DateTime? lastActivity { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool readyToArchive { get; set; }
        public int year { get; set; }
        public bool archive { get; set; }

        internal Account_Search Decrypt(Common.Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            return this;
        }
    }

    public class Account_Search_FK
    {
        public int uid { get; set; }
        public int? cie { get; set; }
    }

    public class Account_Search_Filter : Account_Search_FK
    {
        public bool? archive { get; set; }
        public bool? readyToArchive { get; set; }
    }

    public class Account_Full : Account_PK
    {
        public object xtra { get; set; }
        public int cie { get; set; }
        public string cie_Text { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int roleLUID { get; set; }
        public string roleLUID_Text { get; set; }
        public int roleMask { get; set; }
        public bool isSupport { get; set; }
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiry { get; set; }
        public DateTime? lastActivity { get; set; }
        public bool isAdminReset { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool useRealEmail { get; set; }
        public int? archiveDays { get; set; }
        public bool readyToArchive { get; set; }
        public int currentYear { get; set; }
        public Dictionary<string, object> profile { get; set; }
        public string profileJson { get; set; }
        public string comment { get; set; }
        public bool archive { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public int updatedBy { get; set; }
        public string by { get; set; }
        //
        public bool canExtendInvitation { get; set; }
        public bool canResetPassword { get; set; }
        public bool canCreateInvitation { get; set; }

        internal Account_Full Deserialize()
        {
            profile = Dico.Deserialize(profileJson);
            profileJson = null;
            return this;
        }

        internal Account_Full Decrypt(Common.Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            by = crypto.Decrypt(by);
            return this;
        }
    }

    public class Account_PK
    {
        public int uid { get; set; }
    }

    public class Account_Summary
    {
        public string title { get; set; }
        public int fileCount { get; set; }
    }
}

namespace BaseApp.UTO
{
    public class Account_Insert
    {
        public int cie { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int roleLUID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool useRealEmail { get; set; }
        public int? archiveDays { get; set; }
        public int currentYear { get; set; }
        public Dictionary<string, object> profile { get; set; }
        public string profileJson { get; set; }
        public string comment { get; set; }
        public bool archive { get; set; }

        internal void Validate()
        {
            if (!email.Contains("@"))
                throw new Common.ValidationException("Email requires an '@' character");

            if (email.Length > 50)
                throw new Common.ValidationException("Email is too long (max length = 50)");

            if (firstName.Length > 50)
                throw new Common.ValidationException("FirstName is too long (max length = 50)");

            if (lastName.Length > 50)
                throw new Common.ValidationException("LastName is too long (max length = 50)");
        }

        internal Account_Insert Serialize()
        {
            profileJson = null;
            if (profile != null)
                profileJson = JsonSerializer.Serialize(profile);

            profile = null;
            return this;
        }

        internal Account_Insert Encrypt(Common.Crypto crypto)
        {
            email = crypto.Encrypt(email);
            firstName = crypto.Encrypt(firstName);
            lastName = crypto.Encrypt(lastName);
            return this;
        }
    }

    internal interface IAccount_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
    }

    public class Account_UpdateLock : IAccount_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
    }

    public class Account_Update : Account_Insert, IAccount_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
        public int updatedBy { get; set; }
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
        Account_Full Account_New(int cie);
        Account_PK Account_Insert(UTO.Account_Insert uto, string url);
        void Account_Update(UTO.Account_Update uto);
        void Account_Delete(int id, DateTime concurrencyUtc);
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
            var parameters = KVList.Build(filter);
            var list = repo.queryDicoList("app.Account_List", parameters, uid: true);

            list.ForEach(one =>
            {
                one["email"] = repo.crypto.Decrypt(one.Parse<string>("email"));
                one["firstname"] = repo.crypto.Decrypt(one.Parse<string>("firstname"));
                one["lastname"] = repo.crypto.Decrypt(one.Parse<string>("lastname"));
                one["by"] = repo.crypto.Decrypt(one.Parse<string>("by"));
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
            var item = repo.queryDico("app.Account_Select", "@uid", uid, uid: true).ReviveDTO();

            item["email"] = repo.crypto.Decrypt(item.Parse<string>("email"));
            item["firstname"] = repo.crypto.Decrypt(item.Parse<string>("firstname"));
            item["lastname"] = repo.crypto.Decrypt(item.Parse<string>("lastname"));
            item["by"] = repo.crypto.Decrypt(item.Parse<string>("by"));

            //    .Deserialize();

            var xtra = repo.queryDico("app.Account_Summary", "@uid", uid);
            xtra["title"] = repo.crypto.Decrypt(xtra.Parse<string>("title"));

            return new
            {
                item = item,
                xtra = xtra
            };
        }

        public Account_Full Account_New(int cie)
        {
            var item = repo.spAccount_New(cie);
            return item;
        }

        public Account_PK Account_Insert(UTO.Account_Insert uto, string url)
        {
            int uid;
            var entity = Common.Mapper.mapTo<UTO.Account_Insert, DAL.Account_Insert>(uto);

            var email = sanitizeEmail(entity.email);
            entity.email = email;
            entity.Validate();

            if (entity.useRealEmail)
            {
                entity.resetGuid = Guid.NewGuid();
                entity.resetExpiry = DateTime.Now.AddDays(14);
                entity.updatedBy = user.Get_UID();
                uid = repo.spAccount_Insert(entity);

                var account = repo.Account_SelectBy_Email(email, entity.cie);
                var company = account.cie_Text;

                url = url.Replace("{company}", company);
                url = url.Replace("{guid}", entity.resetGuid.ToString());

                var emailFields = EmailFields.Build_Invitation(url);
                SendEmail(email, emailFields.subject, emailFields.bodyText);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(entity.password))
                    entity.password = get_PasswordHash(entity.password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(entity.password);

                entity.updatedBy = user.Get_UID();
                uid = repo.spAccount_Insert(entity);
            }

            return new Account_PK { uid = uid };
        }

        public void Account_Update(UTO.Account_Update uto)
        {
            var entity = Common.Mapper.mapTo<UTO.Account_Update, DAL.Account_Update>(uto);

            if (entity.uid == 1 && user.Get_UID() != 1)
                throw new ValidationException("Only the administrator can update this account!");

            if (entity.uid == user.Get_UID() && entity.archive)
                throw new ValidationException("You cannot archive your own account!");

            entity.email = sanitizeEmail(entity.email);
            entity.Validate();
            if (!entity.useRealEmail)
            {
                if (!string.IsNullOrWhiteSpace(entity.password))
                    entity.password = get_PasswordHash(entity.password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(entity.password);

                entity.resetGuid = null;
                entity.resetExpiry = null;
            }
            entity.updatedBy = user.Get_UID();
            repo.spAccount_Update(entity);
        }

        public void Account_Delete(int uid, DateTime concurrencyUtc)
        {
            if (uid == SupportUID && user.Get_UID() != SupportUID)
                throw new ValidationException("You cannot delete the support account!");

            if (uid == user.Get_UID())
                throw new ValidationException("You cannot delete your own account!");

            repo.spAccount_Delete(uid, concurrencyUtc);
        }

        public void Auto_Archive(int cie)
        {
            repo.queryNonQuery("app.Account_AutoArchive", "@cie", cie);
        }

        public void Reset_PasswordBy_Admin(int uid, string url)
        {
            if (uid == 1 && user.Get_UID() != 1)
                throw new ValidationException("Only the administrator can reset his password!");

            var email = repo.spAccount_Select(uid).email;

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            repo.Account_ResetPassword(email, guid, expiry, forcedReset: true, unArchive: true);

            url = url.Replace("{guid}", guid.ToString());

            var emailFields = EmailFields.Build_ResetPasswordBy_Admin(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }

        public void Create_Invitation(int uid, string url)
        {
            var email = repo.spAccount_Select(uid).email;

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            repo.Account_ResetPassword(email, guid, expiry, unArchive: true);

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
