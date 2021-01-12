// File: Component/Lookup.cs

namespace BaseApp.DTO
{
    public class Lookup
    {
        public int id { get; set; }
        public int cie { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public int started { get; set; }
        public int? ended { get; set; }
        public int? sortOrder { get; set; }
        public bool? disabled { get; set; }
    }
}

namespace BaseApp.Service
{
    using BaseApp.Common;
    using BaseApp.DTO;
    using System.Collections.Generic;

    public partial interface IAppService
    {
        object Lookup_Search(Dico pager);
        object Lookup_Select(int id);
        object Lookup_New(string groupe);
        object Lookup_Insert(Dico uto);
        void Lookup_Update(Dico uto);
        void Lookup_Delete(Dico key);
        //
        List<Dico> Lookup_By(string groupe, int? year = null);
        List<Dico> Lookup_LutGroup();
    }

    public partial class AppService
    {
        public object Lookup_Search(Dico pager)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            var list = repo.queryDicoList("app.Lookup_Search", parameters, uid: true);

            var groupe = uto.Parse<string>("groupe");
            var title = repo.queryScalar<string>("select Description from app.Lookup where Code=@code", "@code", groupe);

            return new
            {
                list,
                pager = pager.ReviveRowCount(list),
                xtra = new { title }
            };
        }

        public object Lookup_Select(int id)
        {
            var item = repo.queryDico("app.Lookup_Select", "@id", id, uid: true).ReviveDTO().Decrypt(crypto, "by");
            return new
            {
                item,
                xtra = repo.queryDico("app.Lookup_Summary", "@id", id, uid: true)
            };
        }

        public object Lookup_New(string groupe)
        {
            var title = repo.queryScalar<string>("select Description from app.Lookup where Code=@code", "@code", groupe);

            return new
            {
                item = repo.queryDico("app.Lookup_New", "@groupe", groupe, uid: true),
                xtra = new { title }
            };
        }

        public object Lookup_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>("app.Lookup_Insert", parameters, uid: true);
            return new
            {
                id
            };
        }

        public void Lookup_Update(Dico uto)
        {
            repo.queryNonQuery("app.Lookup_Update", KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lookup_Delete(Dico key)
        {
            repo.queryNonQuery("app.Lookup_Delete", KVList.Build(key.ReviveUTO()), uid: true);
        }



        //
        //
        //
        
        public List<Dico> Lookup_By(string groupe, int? year = null)
        {
            return repo.queryDicoList("app.Lookup_ListBy_Groupe", KVList.Build()
                .Add("@groupe", groupe)
                .Add("@year", year)
                );
        }

        public List<Dico> Lookup_LutGroup()
        {
            return repo.queryDicoList("app.Lookup_ListBy_Groupe", KVList.Build()
                .Add("@groupe", "EDIT.LUT")
                .Add("@year", null)
                );
        }

    }
}
