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
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_Search(pager);
        }

        [HttpGet("{id}")]
        public object Select(int id)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_Select(id);
        }

        [HttpGet("new/{groupe}")]
        public object New(string groupe)
        {
            //app.RequirePermission(Perm.Lookup_Edit);
            return app.Lookup_New(groupe);
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




        [HttpGet("lutGroup")]
        public List<Dico> Lookup_LutGroup()
        {
            return app.Lookup_LutGroup();
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
