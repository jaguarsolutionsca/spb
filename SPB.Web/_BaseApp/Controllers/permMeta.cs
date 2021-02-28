
// File: controllers/permmeta.cs

using BaseApp.Common;
using BaseApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class PermMetaController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            return app.PermMeta_Search(pager);
        }

        [HttpGet("{id}")]
        public object Select(int id)
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            return app.PermMeta_Select(id);
        }

        [HttpGet("new")]
        public object New()
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            return app.PermMeta_New();
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            return app.PermMeta_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            app.PermMeta_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            //app.RequirePermission(Perm.PermMeta_Edit);
            app.PermMeta_Delete(key);
            return NoContent();
        }

        [HttpGet("lookup_groupe")]
        public object Lookup_Groupe()
        {
            return app.PermMeta_Lookup_Groupe();
        }

        [HttpGet("lookup_parent")]
        public object Lookup_Parent()
        {
            return app.PermMeta_Lookup_Parent();
        }

    }
}
