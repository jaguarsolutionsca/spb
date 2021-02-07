// File: controllers/job.cs

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
    public class JobController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            //app.RequirePermission(Perm.Job_Edit);
            return app.Job_Search(pager);
        }

        [HttpGet("{id}")]
        public object Select(int id)
        {
            //app.RequirePermission(Perm.Job_Edit);
            return app.Job_Select(id);
        }

        [HttpGet("new")]
        public object New()
        {
            //app.RequirePermission(Perm.Job_Edit);
            return app.Job_New();
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Job_Edit);
            return app.Job_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Job_Edit);
            app.Job_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            //app.RequirePermission(Perm.Job_Edit);
            app.Job_Delete(key);
            return NoContent();
        }

        [HttpGet("lookup")]
        public object Lookup()
        {
            return app.Job_Lookup();
        }
    }
}
