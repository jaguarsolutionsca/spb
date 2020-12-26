// File: Component/Fournisseur.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BaseApp.DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class Fournisseur_Insert : UTO.Fournisseur_Insert
    {
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiry { get; set; }
        public int updatedBy { get; set; }

        internal Fournisseur_Insert ToLocalTime()
        {
            return this;
        }
    }

    public class Fournisseur_Update : UTO.Fournisseur_Update
    {
        public Guid? resetGuid { get; set; }
        public DateTime? resetExpiry { get; set; }

        public Fournisseur_Update ToLocalTime()
        {
            resetExpiry = resetExpiry?.ToLocalTime();
            updated = updated.ToLocalTime();
            return this;
        }
    }

    internal partial class Repo
    {
        public DTO.PagedList<DTO.Fournisseur_Search, DTO.Fournisseur_Search_Filter> spFournisseur_List(DTO.Pager<DTO.Fournisseur_Search_Filter> pagerData)
        {
            var pagedList = new DTO.PagedList<DTO.Fournisseur_Search, DTO.Fournisseur_Search_Filter>();
            pagedList.pager = pagerData;
            pagedList.list = queryList<DTO.Fournisseur_Search>("app.Fournisseur_List", Service.KVList.Build()
                .Add("@archive", pagerData.filter.archive)
                .Add("@readyToArchive", pagerData.filter.readyToArchive)
                );
            return pagedList;
        }

        public DTO.Fournisseur_Full spFournisseur_Select(int uid)
        {
            return queryEntity<DTO.Fournisseur_Full>("app.Fournisseur_Select", "@uid", uid);
        }

        public DTO.Fournisseur_Full spFournisseur_New(int cie)
        {
            return queryEntity<DTO.Fournisseur_Full>("app.Fournisseur_New", "@cie", cie);
        }

        public string spFournisseur_Insert(Fournisseur_Insert entity)
        {
            entity.ToLocalTime();
            return queryScalar<string>("app.Fournisseur_Insert", Service.KVList.Build<Fournisseur_Insert>(entity));
        }

        public void spFournisseur_Update(Fournisseur_Update entity)
        {
            entity.ToLocalTime();
            queryNonQuery("app.Fournisseur_Update", Service.KVList.Build<Fournisseur_Update>(entity));
        }

        public void spFournisseur_Delete(int uid, DateTime updated)
        {
            queryNonQuery("app.Fournisseur_Delete", Service.KVList.Build()
                .Add("@uid", uid)
                .Add("@updated", updated.ToLocalTime())
                );
        }

        public DTO.Fournisseur_Summary spFournisseur_Summary(int uid)
        {
            var summary = queryEntity<DTO.Fournisseur_Summary>("app.Fournisseur_Summary", "@uid", uid);
            summary.title = crypto.Decrypt(summary.title);
            return summary;
        }
    }
}

namespace BaseApp.DTO
{
    public class Fournisseur_Search : Fournisseur_PK
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

        internal Fournisseur_Search Decrypt(Common.Crypto crypto)
        {
            email = crypto.Decrypt(email);
            firstName = crypto.Decrypt(firstName);
            lastName = crypto.Decrypt(lastName);
            return this;
        }
    }

    public class Fournisseur_Search_FK
    {
        public int uid { get; set; }
        public int? cie { get; set; }
    }

    public class Fournisseur_Search_Filter : Fournisseur_Search_FK
    {
        public bool? archive { get; set; }
        public bool? readyToArchive { get; set; }
    }

    public class Fournisseur_Full : Fournisseur_PK
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
    }

    public class Fournisseur_PK
    {
        public string id { get; set; }
    }

    public class Fournisseur_Summary
    {
        public string title { get; set; }
        public int fileCount { get; set; }
    }
}

namespace BaseApp.UTO
{
    public class Fournisseur_Insert
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
            //if (!email.Contains("@"))
            //    throw new Common.ValidationException("Email requires an '@' character");
        }
    }

    internal interface IFournisseur_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
    }

    public class Fournisseur_UpdateLock : IFournisseur_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
    }

    public class Fournisseur_Update : Fournisseur_Insert, IFournisseur_UpdateLock
    {
        public int uid { get; set; }
        public DateTime updated { get; set; }
        public int updatedBy { get; set; }
    }
}

namespace BaseApp.Service
{
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using BaseApp.Common;
    using BaseApp.DTO;

    public partial interface IAppService
    {
        PagedList<Fournisseur_Search, Fournisseur_Search_Filter> Fournisseur_Search(Pager<Fournisseur_Search_Filter> pagerData);
        Fournisseur_Full Fournisseur_Select(string id);
        Fournisseur_Full Fournisseur_New(int cie);
        Fournisseur_PK Fournisseur_Insert(UTO.Fournisseur_Insert uto, string url);
        void Fournisseur_Update(UTO.Fournisseur_Update uto);
        void Fournisseur_Delete(int id, DateTime concurrencyUtc);
    }

    public partial class AppService
    {
        private string ZoneDD = "ZoneDD";

        public PagedList<Fournisseur_Search, Fournisseur_Search_Filter> Fournisseur_Search(Pager<Fournisseur_Search_Filter> pagerData)
        {
            return repo.spFournisseur_List(pagerData);
        }

        public Fournisseur_Full Fournisseur_Select(string id)
        {
            //var record = new Gestion_Paie.BusinessComponents.Fournisseur_Record(gpConnString, id);
            //record.Refresh();
            //return null;

            var Param = new Gestion_Paie.DataClasses.Parameters.spS_Fournisseur_Full();
            Param.SetUpConnection(gpConnString);
            Param.Param_ID = id;

            var SP = new Gestion_Paie.DataClasses.StoredProcedures.spS_Fournisseur_Full(true);
            SP.Execute(ref Param, out SqlDataReader reader);
            reader.Close();

            return null;

            //var item = repo.spFournisseur_Select(id);
            //var xtra = repo.spFournisseur_Summary(id);
            //item.xtra = xtra;
            //return item;
        }

        public Fournisseur_Full Fournisseur_New(int cie)
        {
            var item = repo.spFournisseur_New(cie);
            return item;
        }

        public Fournisseur_PK Fournisseur_Insert(UTO.Fournisseur_Insert uto, string url)
        {
            string id;
            var entity = mapTo<UTO.Fournisseur_Insert, DAL.Fournisseur_Insert>(uto);

            var email = sanitizeEmail(entity.email);
            entity.email = email;
            entity.Validate();
            entity.updatedBy = user.Get_UID();
            id = repo.spFournisseur_Insert(entity);

            return new Fournisseur_PK { id = id };
        }

        public void Fournisseur_Update(UTO.Fournisseur_Update uto)
        {
            var entity = mapTo<UTO.Fournisseur_Update, DAL.Fournisseur_Update>(uto);
            entity.email = sanitizeEmail(entity.email);
            entity.Validate();
            entity.updatedBy = user.Get_UID();
            repo.spFournisseur_Update(entity);
        }

        public void Fournisseur_Delete(int uid, DateTime concurrencyUtc)
        {
            repo.spFournisseur_Delete(uid, concurrencyUtc);
        }
    }
}
