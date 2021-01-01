// File: Component/Company.cs

namespace BaseApp.Service
{
    using BaseApp.Common;
    using System.Text.Json;

    public partial interface IAppService
    {
        object Company_Search(Dico pager);
        object Company_Select(string id);
        object Company_New();
        object Company_Insert(Dico uto);
        void Company_Update(Dico uto);
        void Company_Delete(Dico key);
        int? Company_GetID(string company);
        object Company_GetFeature(int cie);
    }

    public partial class AppService
    {
        public object Company_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.TrimRowCount().Revive());
            var list = repo.queryDicoList("app.Company_Search", parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Company_Select(string id)
        {
            return new
            {
                item = repo.queryDico("appCompany_Select", "@id", id, uid: true),
                xtra = repo.queryDico("app.Company_Summary", "@id", id, uid: true)
            };
        }

        public object Company_New()
        {
            return new
            {
                item = repo.queryDico("app.Company_New", uid: true),
                xtra = (object)null
            };
        }

        public object Company_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.Revive());
            var cie = repo.queryScalar<string>("app.Company_Insert", parameters, uid: true);
            return new
            {
                cie = cie
            };
        }

        public void Company_Update(Dico uto)
        {
            repo.queryNonQuery("app.Company_Update", KVList.Build(uto.Revive()), uid: true);
        }

        public void Company_Delete(Dico key)
        {
            repo.queryNonQuery("app.Company_Delete", KVList.Build(key.Revive()), uid: true);
        }

        public int? Company_GetID(string company)
        {
            var query = "select cie from app.Company where Name=@name";
            return repo.queryScalar<int?>(query, "@name", company);
        }

        public object Company_GetFeature(int cie)
        {
            var query = "select Features from app.Company where CIE=@cie";
            var scalar = repo.queryScalar<string>(query, "@cie", cie);
            var json = scalar ?? "{}";

            var feature = JsonSerializer.Deserialize<object>(json);
            return feature;
        }
    }
}
