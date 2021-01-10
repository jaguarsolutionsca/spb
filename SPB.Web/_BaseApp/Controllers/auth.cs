using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using BaseApp.Common;
using BaseApp.DTO;
using BaseApp.Service;
using BaseApp.Web.Models;
using BaseApp.UTO;

namespace BaseApp.Web.Models
{
    public class AuthorizationData
    {
        public string token { get; set; }
    }
}

namespace BaseApp.Web.Controllers
{
    //
    // This file contains only anonymous controller actions
    //

    [Route("api/[controller]")]
    [AllowAnonymous, ApiController]
    public partial class AuthController : _CoreController
    {
        [HttpPost("signin")]
        public AuthorizationData Signin([FromBody]LoginModel uto)
        {
            var usercaps = app.AppLogin(uto.email, uto.password, uto.cie);
            return populateAuthorizationData(usercaps);
        }

        [HttpPost("signout")]
        public ActionResult Signout()
        {
            return NoContent();
        }

        [HttpPost("invited")]
        public AuthorizationData Invited([FromBody] LoginModel uto)
        {
            app.Save_Password(uto.email, uto.password);
            return Signin(uto);
        }

        [HttpPost("resetted")]
        public AuthorizationData Resetted([FromBody] LoginModel uto)
        {
            app.Save_Password(uto.email, uto.password);
            return Signin(uto);
        }

        [HttpPost("request-password-reset")]
        public ActionResult RequestPasswordReset([FromBody] LoginModel uto)
        {
            app.Reset_Password(uto.email, buildUIRouterUrl("reset-password/{guid}"), uto.cie);
            return NoContent();
        }


        //
        // Link from email
        //
        [HttpGet("accept-invitation/{guid}")]
        public LoginModel AcceptInvitation(string guid)
        {
            return new LoginModel
            {
                email = app.Get_EmailOfInvitation(guid)
            };
        }

        //
        // Link from email
        //
        [HttpGet("reset-password/{guid}")]
        public LoginModel ResetPassword(string guid)
        {
            return new LoginModel
            {
                email = app.Get_EmailOfReset(guid)
            };
        }
    }
}