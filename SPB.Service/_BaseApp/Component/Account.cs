// File: Component/Account.cs

namespace BaseApp.DAL
{
    using BaseApp.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    internal partial class Repo
    {
        DTO.Account_Select _account_reader(SqlDataReader reader)
        {
            if (reader.Read())
            {
                var entity = new DTO.Account_Select();
                var ix = -1;
                ix++; entity.id = reader.GetInt32(ix);
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

        public DTO.Account_Select spAccount_Select(int id)
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

        public DTO.Account_Select spAccount_New()
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

                uto.id = (int)id.Value;
            }
        }

        public void spAccount_Update(UTO.Account_Update uto)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", uto.id);
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

        public List<DTO.Lookup> spAccount_Lookup(int? id, int? uid)
        {
            var list = new List<DTO.Lookup>();

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_Lookup";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", (object)id ?? DBNull.Value);
                command.Parameters.AddWithValue("@uid", (object)uid ?? DBNull.Value);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new DTO.Lookup();
                        var ix = -1;
                        ix++; entity.id = reader.GetInt32(ix);
                        ix++; entity.description = reader.GetString(ix);
                        list.Add(entity);
                    }
                }
            }
            return list;
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

    public class Account_Select : Account_Select_PK
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

        internal Account_Select Decrypt(Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            by = crypto.Decrypt(by);
            return this;
        }
    }

    public class Account_Select_PK
    {
        public int id { get; set; }
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

    public class Account_UK : DTO.Account_Select_PK
    {
        public DateTime updatedUtc { get; set; }
    }

    public class Account_Update : Account_UK
    {
        public string email { get; set; }
        public int roleMask { get; set; }
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiryUtc { get; set; }
        public DateTime? lastActivityUtc { get; set; }
        public bool archive { get; set; }
        public int updatedBy { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
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
        Account_Select Get_Account_Select(int id, string url);
        Account_Select GetNew_Account_Select();
        Account_Select_PK Account_Insert(UTO.Account_Update uto, string url);
        void Account_Update(UTO.Account_Update uto);
        void Account_Delete(int id, DateTime concurrencyUtc);
        List<Lookup> Account_Lookup();
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

        public Account_Select Get_Account_Select(int id, string url)
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

        public Account_Select GetNew_Account_Select()
        {
            //RequirePermission(Perm.TODO);

            var item = repo.spAccount_New();
            return item;
        }

        public Account_Select_PK Account_Insert(UTO.Account_Update uto, string url)
        {
            uto.email = sanitizeEmail(uto.email);
            uto.Validate();
            //uto.resetGuid = Guid.NewGuid();
            //uto.resetExpiryUtc = DateTime.UtcNow.AddDays(7);
            uto.archive = true;
            uto.updatedBy = user.Get_UID();
            repo.spAccount_Insert(uto);

            //url = url.Replace("{guid}", uto.resetGuid.ToString());
            //var emailFields = EmailFields.Build_Invitation(url);
            //SendEmail(uto.email, emailFields.subject, emailFields.bodyText);

            return new Account_Select_PK { id = uto.id };
        }

        public void Account_Update(UTO.Account_Update uto)
        {
            if (uto.id == 1 && user.Get_UID() != 1)
                throw new ValidationException("Only the administrator can update this account!");

            if (uto.id == user.Get_UID() && uto.archive)
                throw new ValidationException("You cannot archive your own account!");

            uto.email = sanitizeEmail(uto.email);
            uto.Validate();
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

        public List<Lookup> Account_Lookup()
        {
            return repo.spAccount_Lookup(null, null);
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
