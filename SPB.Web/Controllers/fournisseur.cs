﻿using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Service;
using BaseApp.UTO;
using BaseApp.Web.Controllers;
using BaseApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize, ApiController]
    public class FournisseurController : _CoreController
    {
        [HttpPost("search")]
        public object Search([FromBody] Dico pagerDico)
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            return app.Fournisseur_Search(pagerDico);
        }

        [HttpGet("{id}")]
        public object Select(string id)
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            return app.Fournisseur_Select(id);
        }

        [HttpGet("new")]
        public Account_Full New()
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            var cie = User.Get_CIE();
            return app.Account_New(cie);
        }

        [HttpPost]
        public Account_PK Insert([FromBody] Account_Insert uto)
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            return app.Account_Insert(uto, buildUIRouterUrl("accept-invitation/{guid}"));
        }

        [HttpPut]
        public ActionResult Update([FromBody] Account_Update uto)
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            app.Account_Update(uto);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Account_UpdateLock key)
        {
            app.RequirePermission(Perm.Fournisseur_Edit);
            app.Account_Delete(key.uid, key.updated);
            return NoContent();
        }
    }
}
