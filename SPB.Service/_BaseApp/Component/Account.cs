// File: Component/Account.cs

using System;
using System.Collections.Generic;

namespace BaseApp.DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    internal partial class Repo
    {
        public DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter> spAccount_List(DTO.Pager<DTO.Account_Search_Filter> pagerData)
        {
            var pagedList = new DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter>();
            pagedList.pager = pagerData;

            var list = queryList<DTO.Account_Search>("app.Account_List", Service.KVList.Build()
                .Add("@archive", pagerData.filter.archive)
                .Add("@readyToArchive", pagerData.filter.readyToArchive)
                );
            list.ForEach(one => one.Decrypt(crypto));

            if (!string.IsNullOrEmpty(pagerData.searchText))
            {
                var search = pagerData.searchText.ToLower();
                list = list.Where(one => {
                    return one.email.ToLower().Contains(search) ||
                        one.firstName.ToLower().Contains(search) ||
                        one.lastName.ToLower().Contains(search);
                }).ToList();
            }

            foreach (var entity in list)
            {
                entity.totalCount = list.Count;
            }

            if (!string.IsNullOrEmpty(pagedList.pager.sortColumn))
            {
                var sortBy = pagedList.pager.sortColumn.ToLower();
                var ascending = string.Compare(pagedList.pager.sortDirection ?? "ASC", "ASC", true) == 0;
                switch (sortBy)
                {
                    case "email":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.email, b.email, true) :
                            string.Compare(b.email, a.email, true));
                        break;

                    case "firstname":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.firstName, b.firstName, true) :
                            string.Compare(b.firstName, a.firstName, true));
                        break;

                    case "lastname":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.lastName, b.lastName, true) :
                            string.Compare(b.lastName, a.lastName, true));
                        break;

                    case "roleluid_text":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.roleLUID_Text, b.roleLUID_Text, true) :
                            string.Compare(b.roleLUID_Text, a.roleLUID_Text, true));
                        break;

                    case "archive":
                        list.Sort((a, b) => ascending ?
                            (a.archive ? 1 : 0) - (b.archive ? 1 : 0) :
                            (b.archive ? 1 : 0) - (a.archive ? 1 : 0));
                        break;

                    case "readytoarchive":
                        list.Sort((a, b) => ascending ?
                            (a.readyToArchive ? 1 : 0) - (b.readyToArchive ? 1 : 0) :
                            (b.readyToArchive ? 1 : 0) - (a.readyToArchive ? 1 : 0));
                        break;

                    //case "haspendingemail":
                    //    list.Sort((a, b) => ascending ?
                    //        (a.hasPendingEmail ? 1 : 0) - (b.hasPendingEmail ? 1 : 0) :
                    //        (b.hasPendingEmail ? 1 : 0) - (a.hasPendingEmail ? 1 : 0));
                    //    break;

                    case "lastactivity":
                        list.Sort((a, b) => ascending ?
                            DateTime.Compare(a.lastActivity ?? DateTime.MinValue, b.lastActivity ?? DateTime.MinValue) :
                            DateTime.Compare(b.lastActivity ?? DateTime.MinValue, a.lastActivity ?? DateTime.MinValue));
                        break;

                    default:
                        break;
                }
            }

            pagedList.list = list
                .Skip((pagedList.pager.pageNo - 1) * pagedList.pager.pageSize)
                .Take(pagedList.pager.pageSize)
                .ToList();

            pagedList.pager.rowCount = (pagedList.list.Count > 0 ? pagedList.list[0].totalCount : 0);
            return pagedList;
        }

        public DTO.Account_Full spAccount_Select(int uid)
        {
            return queryEntity<DTO.Account_Full>("app.Account_Select", "@uid", uid)?.Decrypt(crypto);
        }

        public DTO.Account_Full spAccount_New(int cie)
        {
            return queryEntity<DTO.Account_Full>("app.Account_New", "@cie", cie);
        }

        public void spAccount_Insert(UTO.Account_Update uto)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Insert";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", crypto.Encrypt(uto.email));
                command.Parameters.AddWithValue("@RoleMask", uto.roleMask);
                command.Parameters.AddWithValue("@ResetGuid", (object)uto.resetGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@ResetExpiry", uto.resetExpiryUtc == null ? DBNull.Value : (object)uto.resetExpiryUtc?.ToLocalTime());
                command.Parameters.AddWithValue("@LastActivity", uto.lastActivityUtc == null ? DBNull.Value : (object)uto.lastActivityUtc?.ToLocalTime());
                command.Parameters.AddWithValue("@Archive", uto.archive);
                command.Parameters.AddWithValue("@UpdatedBy", uto.updatedBy);
                command.Parameters.AddWithValue("@FirstName", crypto.Encrypt(uto.firstName));
                command.Parameters.AddWithValue("@LastName", crypto.Encrypt(uto.lastName));
                command.Parameters.AddWithValue("@AutoArchive", uto.autoArchive);
                command.Parameters.AddWithValue("@AutoLock", uto.autoLock);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(uto.address) ? DBNull.Value : (object)crypto.Encrypt(uto.address));
                command.Parameters.AddWithValue("@Town", string.IsNullOrEmpty(uto.town) ? DBNull.Value : (object)crypto.Encrypt(uto.town));
                command.Parameters.AddWithValue("@PostalCode", string.IsNullOrEmpty(uto.postalCode) ? DBNull.Value : (object)crypto.Encrypt(uto.postalCode));

                var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(id);
                command.ExecuteNonQuery();

                uto.uid = (int)id.Value;
            }
        }

        public void spAccount_Update(UTO.Account_Update uto)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", uto.uid);
                command.Parameters.AddWithValue("@Email", crypto.Encrypt(uto.email));
                command.Parameters.AddWithValue("@RoleMask", uto.roleMask);
                command.Parameters.AddWithValue("@ResetGuid", (object)uto.resetGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@ResetExpiry", uto.resetExpiryUtc == null ? DBNull.Value : (object)uto.resetExpiryUtc?.ToLocalTime());
                command.Parameters.AddWithValue("@LastActivity", uto.lastActivityUtc == null ? DBNull.Value : (object)uto.lastActivityUtc?.ToLocalTime());
                command.Parameters.AddWithValue("@Archive", uto.archive);
                command.Parameters.AddWithValue("@Updated", uto.updatedUtc.ToLocalTime());
                command.Parameters.AddWithValue("@UpdatedBy", uto.updatedBy);
                command.Parameters.AddWithValue("@FirstName", crypto.Encrypt(uto.firstName));
                command.Parameters.AddWithValue("@LastName", crypto.Encrypt(uto.lastName));
                command.Parameters.AddWithValue("@AutoArchive", uto.autoArchive);
                command.Parameters.AddWithValue("@AutoLock", uto.autoLock);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(uto.address) ? DBNull.Value : (object)crypto.Encrypt(uto.address));
                command.Parameters.AddWithValue("@Town", string.IsNullOrEmpty(uto.town) ? DBNull.Value : (object)crypto.Encrypt(uto.town));
                command.Parameters.AddWithValue("@PostalCode", string.IsNullOrEmpty(uto.postalCode) ? DBNull.Value : (object)crypto.Encrypt(uto.postalCode));
                command.ExecuteNonQuery();

            }
        }

        public void spAccount_Delete(int id, DateTime updatedUtc)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Updated", updatedUtc.ToLocalTime());
                command.ExecuteNonQuery();

            }
        }

        public DTO.Account_Summary spAccount_Summary(int uid)
        {
            return queryEntity<DTO.Account_Summary>("app.Account_Summary", "@uid", uid);
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
        public int year { get; set; }
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
    public class Account_UK : DTO.Account_PK
    {
        public DateTime updatedUtc { get; set; }
    }

    public class Account_Update : Account_UK
    {
        public int cie { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int roleMask { get; set; }
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiryUtc { get; set; }
        public DateTime? lastActivityUtc { get; set; }
        public bool archive { get; set; }
        public int updatedBy { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool useRealEmail { get; set; }
        public bool autoArchive { get; set; }
        public bool autoLock { get; set; }
        public string address { get; set; }
        public string town { get; set; }
        public string postalCode { get; set; }

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
        PagedList<Account_Search, Account_Search_Filter> Account_Search(Pager<Account_Search_Filter> pagerData);
        Account_Full Account_Select(int uid, string url);
        Account_Full Account_New(int cie);
        Account_PK Account_Insert(UTO.Account_Update uto, string url);
        void Account_Update(UTO.Account_Update uto);
        void Account_Delete(int id, DateTime concurrencyUtc);
        void Auto_Archive(int cie);
        void Reset_PasswordBy_Admin(int uid, string url);
        void Create_Invitation(int uid, string url);
    }

    public partial class AppService
    {
        public PagedList<Account_Search, Account_Search_Filter> Account_Search(Pager<Account_Search_Filter> pagerData)
        {
            return repo.spAccount_List(pagerData);
        }

        public Account_Full Account_Select(int uid, string url)
        {
            var item = repo.spAccount_Select(uid);
            var xtra = repo.spAccount_Summary(uid);
            item.xtra = xtra;
            item.canExtendInvitation = (item.resetGuid != null && item.resetExpiry != null && item.resetExpiry < DateTime.UtcNow && item.lastActivity == null && !item.archive);
            item.canResetPassword = (item.resetGuid != null && item.resetExpiry != null && item.lastActivity != null && !item.archive);
            item.canCreateInvitation = (item.resetGuid == null && item.resetExpiry == null && item.lastActivity == null && item.archive);
            return item;
        }

        public Account_Full Account_New(int cie)
        {
            var item = repo.spAccount_New(cie);
            return item;
        }

        public Account_PK Account_Insert(UTO.Account_Update uto, string url)
        {
            uto.email = sanitizeEmail(uto.email);
            uto.Validate();

            if (uto.useRealEmail)
            {
                uto.resetGuid = Guid.NewGuid();
                uto.updatedBy = user.Get_UID();
                repo.spAccount_Insert(uto);

                var account = repo.Account_SelectBy_Email(uto.email, uto.cie);
                var company = account.cie_Text;

                url = url.Replace("{company}", company);
                url = url.Replace("{guid}", uto.resetGuid.ToString());

                var emailFields = EmailFields.Build_Invitation(url);
                SendEmail(uto.email, emailFields.subject, emailFields.bodyText);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(uto.password))
                    uto.password = get_PasswordHash(uto.password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(uto.password);

                uto.updatedBy = user.Get_UID();
                repo.spAccount_Insert(uto);
            }

            return new Account_PK { uid = uto.uid };
        }

        public void Account_Update(UTO.Account_Update uto)
        {
            if (uto.uid == 1 && user.Get_UID() != 1)
                throw new ValidationException("Only the administrator can update this account!");

            if (uto.uid == user.Get_UID() && uto.archive)
                throw new ValidationException("You cannot archive your own account!");

            uto.email = sanitizeEmail(uto.email);
            uto.Validate();
            if (!uto.useRealEmail)
            {
                if (!string.IsNullOrWhiteSpace(uto.password))
                    uto.password = get_PasswordHash(uto.password);
                else
                    throw new ValidationException("The password cannot be empty");

                validate_PasswordHash(uto.password);

                uto.resetGuid = null;
                uto.resetExpiryUtc = null;
            }
            uto.updatedBy = user.Get_UID();
            repo.spAccount_Update(uto);
        }

        public void Account_Delete(int id, DateTime concurrencyUtc)
        {
            if (id == 1 && user.Get_UID() != 1)
                throw new ValidationException("You cannot delete the administrator account!");

            if (id == user.Get_UID())
                throw new ValidationException("You cannot delete your own account!");

            repo.spAccount_Delete(id, concurrencyUtc);
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
