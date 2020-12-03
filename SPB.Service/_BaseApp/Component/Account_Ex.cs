
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
        public DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter> spAccount_List(DTO.Pager<DTO.Account_Search_Filter> pagerData)
        {
            var pagedList = new DTO.PagedList<DTO.Account_Search, DTO.Account_Search_Filter>();
            pagedList.pager = pagerData;
            pagedList.list = new List<DTO.Account_Search>();
            var list = pagedList.list;

            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_List";
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

        public DTO.Account_Select Account_SelectBy_credential(string email, string password, int? cid)
        {
            var query = "app.Account_SelectBy_Credential";
            var parameters = new Service.KVList()
                .AddParam("@email", crypto.Encrypt(email))
                .AddParam("@password", password)
                .AddParam("@cid", cid);
            return queryEntity<DTO.Account_Select>(query, parameters).Decrypt(crypto);
        }

        public DTO.Account_Select Account_SelectBy_email(string email, int? cid)
        {
            var query = "app.Account_SelectBy_Email";
            var parameters = new Service.KVList()
                .AddParam("@email", crypto.Encrypt(email))
                .AddParam("@cid", cid);
            return queryEntity<DTO.Account_Select>(query, parameters).Decrypt(crypto);
        }

        public void Account_Update_LastActivity(int id, DateTime lastActivity)
        {
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Account]";
                var column = "LastActivity";
                var where = "ID=@p1";

                command.CommandText = $"UPDATE {table} SET {column}=@p2, ResetGuid=NULL, ResetExpiry=NULL WHERE {where}";
                command.Parameters.AddWithValue("@p1", id);
                command.Parameters.AddWithValue("@p2", lastActivity);
                command.ExecuteNonQuery();
            }
        }

        public DTO.Account_Select Account_SelectBy_ResetGuid(string guid)
        {
            var id = -1;
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Account]";
                var columns = "ID";
                var where = "ResetGuid=@p1";

                command.CommandText = @"SELECT " + columns + " FROM " + table + " WHERE " + where;
                command.Parameters.AddWithValue("@p1", guid);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }
            return (id == -1 ? null : spAccount_Select(id));
        }

        public void Account_SetPassword(string email, string password)
        {
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Account]";
                var column = "Password";
                var where = "Email=@p1";

                command.CommandText = $"UPDATE {table} SET {column}=@p2 WHERE {where}";
                command.Parameters.AddWithValue("@p1", crypto.Encrypt(email));
                command.Parameters.AddWithValue("@p2", password);
                command.ExecuteNonQuery();
            }
        }

        public void Account_ResetPassword(string email, Guid guid, DateTime expiry, bool forcedReset = false, bool unArchive = false)
        {
            using (var command = connex.CreateCommand())
            {
                var table = "[dbo].[Account]";
                var where = "Email=@p1";
                var archive = $"{(unArchive ? "0" : "Archive")}";

                command.CommandText = $"UPDATE {table} SET Password=NULL, ResetGuid=@p2, ResetExpiry=@p3, IsReset=@p4, Archive={archive} WHERE {where}";
                command.Parameters.AddWithValue("@p1", crypto.Encrypt(email));
                command.Parameters.AddWithValue("@p2", guid);
                command.Parameters.AddWithValue("@p3", expiry);
                command.Parameters.AddWithValue("@p4", forcedReset);
                command.ExecuteNonQuery();
            }
        }

        public void Account_AutoArchive()
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_AutoArchive";
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public DTO.Account_Select Account_FixLookup(int id)
        {
            using (var command = connex.CreateCommand())
            {
                command.CommandText = "dbo.Account_FixLookup";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
            return spAccount_Select(id);
        }

        public List<int> Account_GetPermissionList(int id)
        {
            var query = "app.Account_GetPermissionList";
            return queryList<int>(query, "@uid", id);
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

    internal class EmailFields
    {
        public string subject { get; set; }
        public string bodyHtml { get; set; }
        public string bodyText { get; set; }

        public static EmailFields Build_Invitation(string url)
        {
            var line1 = "You have been invited to join OpsFMS by your administrator.";
            var line2 = "Click this link to set your account password:";
            var line3 = "This link will expire in one week.";

            var subject = $"OpsFMS Invitation";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }

        public static EmailFields Build_ResetPasswordBy_Admin(string url)
        {
            var line1 = "Your OpsFMS administrator has requested a password reset for your account.";
            var line2 = "Click this link to create a new password:";
            var line3 = "This link will expire in one week.";

            var subject = $"OpsFMS Password Reset by Administrator";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }

        public static EmailFields Build_ResetPasswordBy_Self(string url)
        {
            var line1 = "Let's fix that password thing!";
            var line2 = "Click this link to create a new password:";
            var line3 = "This link will expire in one week.";
            var line4 = "NOTE: If you didn't request this email, you may safely ignore it";

            var subject = $"OpsFMS Password Reset";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                    <p>{line4}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}

{line4}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }
    }
}