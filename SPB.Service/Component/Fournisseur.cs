// File: Component/Fournisseur.cs

namespace BaseApp.Service
{
    public partial interface IAppService
    {
        object Fournisseur_Search(Dico pager);
        object Fournisseur_Select(string id);
        object Fournisseur_New();
        object Fournisseur_Insert(Dico uto);
        void Fournisseur_Update(Dico uto);
        void Fournisseur_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Fournisseur_Search(Dico pager)
        {
            var parameters = KVList.Build(pager.FromUTO(blacklist: new string[] { "rowCount" }));
            return new
            {
                list = repo.queryDicoList("Fournisseur_Search", parameters),
                pager = pager
            };
        }

        public object Fournisseur_Select(string id)
        {
            return new
            {
                item = repo.queryDico(GP("spS_Fournisseur_Full"), "@id", id),
                xtra = "repo.spFournisseur_Summary(id)"
            };
        }

        public object Fournisseur_New()
        {
            return repo.queryDico(GP("spS_Fournisseur_Full"), "@id", "----");
        }

        public object Fournisseur_Insert(Dico uto)
        {
            var parameters = KVList.Build(uto.FromUTO());
            var id = repo.queryScalar<string>(GP("spI_Fournisseur"), parameters);
            return new
            {
                id = id
            };
        }

        public void Fournisseur_Update(Dico uto)
        {
            repo.queryNonQuery(GP("spU_Fournisseur"), KVList.Build(uto.FromUTO()));
        }

        public void Fournisseur_Delete(Dico key)
        {
            repo.queryNonQuery(GP("spD_Fournisseur"), KVList.Build(key.FromUTO()));
            //.Add("@updated", concurrencyUtc.ToLocalTime())
        }
    }
}
