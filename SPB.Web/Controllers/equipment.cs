﻿// File: controllers/equipment.cs

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
    public class EquipmentController : _CoreController
    {
        [HttpPost("search/{pid}/{parent}")]
        public object Search([FromBody] Dico pager, int? pid, string parent)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            return app.Equipment_Search(pager, pid, parent);
        }

        [HttpGet("{id}/{parent}")]
        public object Select(int id, string parent)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            return app.Equipment_Select(id, parent);
        }

        [HttpGet("new/{pid}/{parent}")]
        public object New(int? pid, string parent)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            return app.Equipment_New(pid, parent);
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            return app.Equipment_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            app.Equipment_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            //app.RequirePermission(Perm.Equipment_Edit);
            app.Equipment_Delete(key);
            return NoContent();
        }

        [HttpGet("lookup")]
        public object Lookup()
        {
            return app.Equipment_Lookup();
        }
    }
}
