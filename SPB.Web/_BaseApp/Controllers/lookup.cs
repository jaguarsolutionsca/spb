// File: controllers/lookup.cs

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
    public class LookupController : _CoreController
    {
        [HttpPost("search/{pid}/{parent}")]
        public object Search([FromBody] Dico pager, int? pid, string parent)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_Search(pager, pid, parent);
        }

        [HttpGet("{id}/{parent}")]
        public object Select(int id, string parent)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_Select(id, parent);
        }

        [HttpGet("new/{pid}/{parent}")]
        public object New(int? pid, string parent)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_New(pid, parent);
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            app.Lookup_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            app.Lookup_Delete(key);
            return NoContent();
        }



        //
        // FIXME: Issue with the AuthorizeAttribute and the signout process.
        // The "Not authenticated" message shows up in the Signin form after a signout.
        // This will have to be fixed in the ts files but for the time being we accept non authenticated api calls.
        //
       [AllowAnonymous]
        [HttpGet("by/{groupe}")]
        public List<Dico> Lookup_By(string groupe)
        {
            return app.Lookup_By(groupe);
        }
    }
}
