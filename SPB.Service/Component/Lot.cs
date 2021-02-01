// File: Component/Lot.cs

namespace BaseApp.Service
{
    using BaseApp.Common;

    public partial interface IAppService
    {
        object Lot_Search(Dico pager, string proprietaireid);
        object Lot_Select(int id);
        object Lot_New();
        object Lot_New_ByProprietaire(string proprietaireid);
        object Lot_Insert(Dico uto);
        void Lot_Update(Dico uto);
        void Lot_Delete(Dico key);
    }

    public partial class AppService
    {
        public object Lot_Search(Dico pager, string proprietaireid)
        {
            var uto = pager.TrimRowCount().ReviveUTO();
            var parameters = KVList.Build(uto);
            parameters.Add("@proprietaireid", proprietaireid);
            var list = repo.queryDicoList(GP("Lot_Search"), parameters, uid: true);
            list.ForEach(one => one.TrimKeys(new string[] { "plusorder", "rn" }));

            return new
            {
                list = list,
                pager = pager.ReviveRowCount(list),
                xtra = repo.queryDico(GP("Fournisseur_Summary"), "@id", proprietaireid, uid: true)

            };
        }

        public object Lot_Select(int id)
        {
            return new
            {
                item = repo.queryDico(GP("Lot_Select"), "@id", id, uid: true),
                xtra = repo.queryDico(GP("Fournisseur_Summary"), "@lot_id", id, uid: true)
            };
        }

        public object Lot_New()
        {
            return new
            {
                item = repo.queryDico(GP("Lot_New"), uid: true),
                xtra = (object)null
            };
        }

        public object Lot_New_ByProprietaire(string proprietaireid)
        {
            return new
            {
                item = repo.queryDico(GP("Lot_New"), uid: true),
                xtra = repo.queryDico(GP("Fournisseur_Summary"), "@id", proprietaireid, uid: true)

            };
        }

        public object Lot_Insert(Dico uto)
        {
            uto.TrimKeys(new string[] { "cantonid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text", "municipaliteid_text", "created", "by" });
            var parameters = KVList.Build(uto.ReviveUTO());
            var id = repo.queryScalar<int>(GP("Lot_Insert"), parameters, uid: true);
            return new
            {
                id = id
            };
        }

        public void Lot_Update(Dico uto)
        {
            uto.TrimKeys(new string[] { "cantonid_text", "proprietaireid_text", "contingentid_text", "droit_coupeid_text", "entente_paiementid_text", "zoneid_text", "municipaliteid_text", "created", "by" });
            repo.queryNonQuery(GP("Lot_Update"), KVList.Build(uto.ReviveUTO()), uid: true);
        }

        public void Lot_Delete(Dico key)
        {
            repo.queryNonQuery(GP("Lot_Delete"), KVList.Build(key.ReviveUTO()), uid: true);
        }
    }
}
