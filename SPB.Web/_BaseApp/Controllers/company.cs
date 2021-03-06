﻿// File: controllers/company.cs

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
    public class CompanyController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            app.RequirePermission(Perm.Company_Edit);
            return app.Company_Search(pager);
        }

        [HttpGet("{id}")]
        public object Select(int id)
        {
            app.RequirePermission(Perm.Company_Edit);
            return app.Company_Select(id);
        }

        [HttpGet("new")]
        public object New()
        {
            app.RequirePermission(Perm.Company_Edit);
            return app.Company_New();
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            app.RequirePermission(Perm.Company_Edit);
            return app.Company_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            app.RequirePermission(Perm.Company_Edit);
            app.Company_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            app.RequirePermission(Perm.Company_Edit);
            app.Company_Delete(key);
            return NoContent();
        }
    }
}
