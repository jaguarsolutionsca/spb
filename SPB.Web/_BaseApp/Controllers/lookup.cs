using BaseApp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public partial class LookupController : _CoreController
    {
        [HttpGet]
        public PagedList<Lookup_Search, Lookup_Search_Filter> Search(string groupe, int? year, int pn, int ps, string sc, string sd, string st)
        {
            var pager = new Pager<Lookup_Search_Filter>(pn, ps, sc, sd, st);
            pager.filter.groupe = groupe;
            pager.filter.year = year;
            return app.Search_Lookup(pager);
        }

        [HttpGet("{id}")]
        public Lookup_Detail Get(int id)
        {
            return app.Get_Lookup(id);
        }

        [HttpGet("new/{groupe}")]
        public Lookup_Detail GetNew(string groupe)
        {
            return app.GetNew_Lookup(groupe);
        }

        [HttpPost]
        public Lookup_Detail_PK Create([FromBody] Lookup_Model model)
        {
            return app.Create_Lookup(model);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Lookup_Model model)
        {
            app.Update_Lookup(model);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Lookup_Detail_PK key)
        {
            app.Delete_Lookup(key.id, key.updatedUtc);
            return NoContent();
        }
    }
}
