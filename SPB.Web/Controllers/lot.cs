﻿// File: controllers/lot.cs

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
    public class LotController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pager)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_Search(pager, null);
        }

        [HttpPost("search/{proprietaireid}")]
        public object Search_ByProprietaire([FromBody] Dico pager, string proprietaireid)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_Search(pager, proprietaireid);
        }

        [HttpGet("{id}")]
        public object Select(int id)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_Select(id);
        }

        [HttpGet("new")]
        public object New()
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_New();
        }

        [HttpGet("new/{proprietaireid}")]
        public object New_ByProprietaire(string proprietaireid)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_New_ByProprietaire(proprietaireid);
        }

        [HttpPost]
        public object Insert([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            return app.Lot_Insert(uto);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Dico uto)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            app.Lot_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Dico key)
        {
            //app.RequirePermission(Perm.Lot_Edit);
            app.Lot_Delete(key);
            return NoContent();
        }
    }
}
