// File: Component/Account.cs

namespace BaseApp.DAL
{
    using BaseApp.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    internal partial class Repo
    {
        public DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter> spAccount_List(DTO.Pager<DTO.Account_Search_Filter> pagerData)
        {
            var pagedList = new DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter>();
            pagedList.pager = pagerData;
            pagedList.list = new List<DTO.Account_Search>();
            var list = pagedList.list;

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "app.Account_List";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Archive", (object)pagerData.filter.archive ?? DBNull.Value);
                command.Parameters.AddWithValue("@RegionLUID", (object)pagerData.filter.regionLUID ?? DBNull.Value);
                command.Parameters.AddWithValue("@DistrictLUID", (object)pagerData.filter.districtLUID ?? DBNull.Value);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new DTO.Account_Search();
                        var ix = -1;
                        ix++; entity.id = reader.GetInt32(ix);
                        ix++; entity.email = reader.GetString(ix);
                        ix++; entity.roleMask = reader.GetInt32(ix);
                        ix++; entity.roleMask_Text = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.resetGuid = reader.IsDBNull(ix) ? (Guid?)null : reader.GetGuid(ix);
                        ix++; entity.resetExpiryUtc = reader.IsDBNull(ix) ? (DateTime?)null : reader.GetDateTime(ix);
                        ix++; entity.lastActivityUtc = reader.IsDBNull(ix) ? (DateTime?)null : reader.GetDateTime(ix);
                        ix++; entity.archive = reader.GetBoolean(ix);
                        ix++; entity.createdUtc = reader.GetDateTime(ix);
                        ix++; entity.updatedUtc = reader.GetDateTime(ix);
                        ix++; entity.updatedBy = reader.GetInt32(ix);
                        ix++; entity.firstName = reader.GetString(ix);
                        ix++; entity.lastName = reader.GetString(ix);
                        ix++; entity.regionLUID = reader.GetInt32(ix);
                        ix++; entity.regionLUID_Text = reader.GetString(ix);
                        ix++; entity.districtLUID = reader.GetInt32(ix);
                        ix++; entity.districtLUID_Text = reader.GetString(ix);
                        ix++; entity.phone1 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.phone2 = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.fax = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.readyToArchive = reader.GetBoolean(ix);
                        ix++; entity.address = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.town = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.postalCode = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        list.Add(entity.Decrypt(crypto));
                    }
                }
            }

            if (pagerData.filter.readyToArchive.HasValue)
            {
                list = list.Where(one => one.readyToArchive == pagerData.filter.readyToArchive.Value).ToList();
            }

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

                    case "rolemask_text":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.roleMask_Text, b.roleMask_Text, true) :
                            string.Compare(b.roleMask_Text, a.roleMask_Text, true));
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

                    case "regionluid_text":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.regionLUID_Text, b.regionLUID_Text, true) :
                            string.Compare(b.regionLUID_Text, a.regionLUID_Text, true));
                        break;

                    case "districtluid_text":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.districtLUID_Text, b.districtLUID_Text, true) :
                            string.Compare(b.districtLUID_Text, a.districtLUID_Text, true));
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

                    case "haspendingemail":
                        list.Sort((a, b) => ascending ?
                            (a.hasPendingEmail ? 1 : 0) - (b.hasPendingEmail ? 1 : 0) :
                            (b.hasPendingEmail ? 1 : 0) - (a.hasPendingEmail ? 1 : 0));
                        break;

                    case "lastactivityutc":
                        list.Sort((a, b) => ascending ?
                            DateTime.Compare(a.lastActivityUtc ?? DateTime.MinValue, b.lastActivityUtc ?? DateTime.MinValue) :
                            DateTime.Compare(b.lastActivityUtc ?? DateTime.MinValue, a.lastActivityUtc ?? DateTime.MinValue));
                        break;

                    case "address":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.address, b.address, true) :
                            string.Compare(b.address, a.address, true));
                        break;

                    case "town":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.town, b.town, true) :
                            string.Compare(b.town, a.town, true));
                        break;

                    case "postalcode":
                        list.Sort((a, b) => ascending ?
                            string.Compare(a.postalCode, b.postalCode, true) :
                            string.Compare(b.postalCode, a.postalCode, true));
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

        DTO.Account_Full _account_reader(SqlDataReader reader)
        {
            if (reader.Read())
            {
                var entity = new DTO.Account_Full();
                var ix = -1;
                ix++; entity.uid = reader.GetInt32(ix);
                ix++; entity.cid = reader.GetInt32(ix);
                ix++; entity.cid_Text = reader.GetString(ix);
                ix++; entity.email = reader.GetString(ix);
                ix++; entity.roleLUID = reader.GetInt32(ix);
                ix++; entity.roleLUID_Text = reader.GetString(ix);
                ix++; entity.resetGuid = reader.IsDBNull(ix) ? (Guid?)null : reader.GetGuid(ix);
                ix++; entity.resetExpiry = reader.IsDBNull(ix) ? (DateTime?)null : reader.GetDateTime(ix);
                ix++; entity.lastActivity = reader.IsDBNull(ix) ? (DateTime?)null : reader.GetDateTime(ix);
                ix++; entity.isAdminReset = reader.GetBoolean(ix);
                ix++; entity.firstName = reader.GetString(ix);
                ix++; entity.lastName = reader.GetString(ix);
                ix++; entity.comment = reader.GetString(ix);
                ix++; entity.archive = reader.GetBoolean(ix);
                ix++; entity.created = reader.GetDateTime(ix);
                ix++; entity.updated = reader.GetDateTime(ix);
                ix++; entity.updatedBy = reader.GetInt32(ix);
                ix++; entity.by = reader.GetString(ix);
                return entity.Decrypt(crypto);
            }
            return null;
        }

        public DTO.Account_Full spAccount_Select(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Select";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    return _account_reader(reader);
                }
            }
        }

        public DTO.Account_Full spAccount_New()
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_New";
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    return _account_reader(reader);
                }
            }
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

        public DTO.Account_Summary spAccount_Summary(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Summary";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var entity = new DTO.Account_Summary();
                        var ix = -1;
                        ix++; entity.title = reader.IsDBNull(ix) ? null : reader.GetString(ix);
                        ix++; entity.fileCount = reader.GetInt32(ix);

                        entity.title = crypto.Decrypt(entity.title);
                        return entity;
                    }
                    return null;
                }
            }
        }
    }
}

namespace BaseApp.DTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

    public class Account_Search
    {
        public int totalCount { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public int roleMask { get; set; }
        public string roleMask_Text { get; set; }
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiryUtc { get; set; }
        public DateTime? lastActivityUtc { get; set; }
        public bool archive { get; set; }
        public DateTime createdUtc { get; set; }
        public DateTime updatedUtc { get; set; }
        public int updatedBy { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int regionLUID { get; set; }
        public string regionLUID_Text { get; set; }
        public int districtLUID { get; set; }
        public string districtLUID_Text { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string fax { get; set; }
        public bool readyToArchive { get; set; }
        public string address { get; set; }
        public string town { get; set; }
        public string postalCode { get; set; }
        //
        public bool hasPendingEmail { get; set; }

        internal Account_Search Decrypt(Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            phone1 = crypto.Decrypt(phone1);
            phone2 = crypto.Decrypt(phone2);
            fax = crypto.Decrypt(fax);
            address = crypto.Decrypt(address);
            town = crypto.Decrypt(town);
            postalCode = crypto.Decrypt(postalCode);

            hasPendingEmail = (resetExpiryUtc.HasValue && resetExpiryUtc > DateTime.UtcNow);

            return this;
        }
    }

    public class Account_Search_FK
    {
    }

    public class Account_Search_Filter : Account_Search_FK
    {
        public bool? archive { get; set; }
        public int? regionLUID { get; set; }
        public int? districtLUID { get; set; }
        public bool? readyToArchive { get; set; }
    }

    public class Account_Full : Account_PK
    {
        public object xtra { get; set; }
        public int cid { get; set; }
        public string cid_Text { get; set; }
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
        public string emailBody { get; set; }
        public string emailSubject { get; set; }
        public bool canExtendInvitation { get; set; }
        public bool canResetPassword { get; set; }
        public bool canCreateInvitation { get; set; }

        internal Account_Full Decrypt(Crypto crypto)
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

    public class Account_Summary : DTO_Summary
    {
        public int fileCount { get; set; }
    }
}

namespace BaseApp.UTO
{
    using System;
    using System.Collections.Generic;
    using BaseApp.Common;

    public class Account_UK : DTO.Account_PK
    {
        public DateTime updatedUtc { get; set; }
    }

    public class Account_Update : Account_UK
    {
        public int cid { get; set; }
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
                throw new ValidationException("Email requires an '@' character");

            if (email.Length > 50)
                throw new ValidationException("Email is too long (max length = 50)");

            if (firstName.Length > 50)
                throw new ValidationException("FirstName is too long (max length = 50)");

            if (lastName.Length > 50)
                throw new ValidationException("LastName is too long (max length = 50)");
        }
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
        PagedList<Account_Search, Account_Search_Filter> Account_Search(Pager<Account_Search_Filter> pagerData);
        Account_Full Get_Account_Select(int id, string url);
        Account_Full GetNew_Account_Select();
        Account_PK Account_Insert(UTO.Account_Update uto, string url);
        void Account_Update(UTO.Account_Update uto);
        void Account_Delete(int id, DateTime concurrencyUtc);
        void Auto_Archive();
        void Reset_PasswordBy_Admin(int id, string url);
        void Create_Invitation(int id, string url);
    }

    public partial class AppService
    {
        public PagedList<Account_Search, Account_Search_Filter> Account_Search(Pager<Account_Search_Filter> pagerData)
        {
            var list = repo.spAccount_List(pagerData);
            return list;
        }

        public Account_Full Get_Account_Select(int id, string url)
        {
            var item = repo.spAccount_Select(id);
            var xtra = repo.spAccount_Summary(id);
            item.xtra = xtra;
            item.canExtendInvitation = (item.resetGuid != null && item.resetExpiry != null && item.resetExpiry < DateTime.UtcNow && item.lastActivity == null && !item.archive);
            item.canResetPassword = (item.resetGuid != null && item.resetExpiry != null && item.lastActivity != null && !item.archive);
            item.canCreateInvitation = (item.resetGuid == null && item.resetExpiry == null && item.lastActivity == null && item.archive);
            if (item.resetExpiry.HasValue && item.resetExpiry > DateTime.UtcNow)
            {
                url = url.Replace("{guid}", item.resetGuid.ToString());
                var emailFields = (item.isAdminReset ? EmailFields.Build_ResetPasswordBy_Admin(url) : EmailFields.Build_Invitation(url));
                item.emailSubject = emailFields.subject;
                item.emailBody = emailFields.bodyText.Replace("\n", "%0D%0A");
            }
            return item;
        }

        public Account_Full GetNew_Account_Select()
        {
            //RequirePermission(Perm.TODO);

            var item = repo.spAccount_New();
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

                var account = repo.Account_SelectBy_Email(uto.email, uto.cid);
                var company = account.cid_Text;

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

        public void Auto_Archive()
        {
            repo.queryNonQuery("app.Account_AutoArchive");
        }

        public void Reset_PasswordBy_Admin(int id, string url)
        {
            if (id == 1 && user.Get_UID() != 1)
                throw new ValidationException("Only the administrator can reset his password!");

            var email = repo.spAccount_Select(id).email;

            var guid = Guid.NewGuid();
            var expiry = DateTime.Now.AddDays(7);
            repo.Account_ResetPassword(email, guid, expiry, forcedReset: true, unArchive: true);

            url = url.Replace("{guid}", guid.ToString());

            var emailFields = EmailFields.Build_ResetPasswordBy_Admin(url);
            SendEmail(email, emailFields.subject, emailFields.bodyText);
        }

        public void Create_Invitation(int id, string url)
        {
            var email = repo.spAccount_Select(id).email;

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
