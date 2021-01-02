// File: Component/Company.cs

namespace BaseApp.Service
{
    using BaseApp.Common;
    using System.Text.Json;

    public partial interface IAppService
    {
        object Company_Search(Dico pager);
        object Company_Select(string cie);
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
            var parameters = KVList.Build(pager.TrimRowCount().ReviveUTO());
            var list = repo.queryDicoList("app.Company_Search", parameters, uid: true);
            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = (object)null
            };
        }

        public object Company_Select(string cie)
        {
            var graylist = "caneditundeliveredpermits,fournisseur_planconjoint,fournisseur_surcharge,fournisseur_fond_roulement,fournisseur_fond_forestier,fournisseur_preleve_divers,gpversion,showyearsinpermislistview".Split(',');
            return new
            {
                item = repo.queryDico("app.Company_Select", "@cie", cie, uid: true).ReviveDTO(graylist: graylist),
                xtra = repo.queryDico("app.Company_Summary", "@cie", cie, uid: true)
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
            var parameters = KVList.Build(uto.ReviveUTO());
            var cie = repo.queryScalar<string>("app.Company_Insert", parameters, uid: true);
            return new
            {
                cie = cie
            };
        }

        public void Company_Update(Dico uto)
        {
            uto.Remove("created");

            var appProps = new string[] { "cie", "name", "features", "archive", "updated", "updatedby" };
            var appUTO = uto.ReviveUTO(whitelist: appProps);
            var dboUTO = uto.ReviveUTO(blacklist: appProps);

            appUTO.Add("profileJson", Dico.Serialize(dboUTO));

            repo.queryNonQuery("app.Company_Update", KVList.Build(appUTO), uid: true);
        }

        public void Company_Delete(Dico key)
        {
            repo.queryNonQuery("app.Company_Delete", KVList.Build(key.ReviveUTO()), uid: true);
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
