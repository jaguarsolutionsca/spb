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

namespace BaseApp.Web.Models
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public int cie { get; set; }
    }

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
        public AuthorizationData Signin([FromBody]LoginModel model)
        {
            var usercaps = app.AppLogin(model.email, model.password, model.cie);
            return populateAuthorizationData(usercaps);
        }

        [HttpPost("signout")]
        public ActionResult Signout()
        {
            return NoContent();
        }

        [HttpPost("invited")]
        public AuthorizationData Invited([FromBody] LoginModel model)
        {
            app.Save_Password(model.email, model.password);
            return Signin(model);
        }

        [HttpPost("resetted")]
        public AuthorizationData Resetted([FromBody] LoginModel model)
        {
            app.Save_Password(model.email, model.password);
            return Signin(model);
        }

        [HttpPost("request-password-reset")]
        public ActionResult RequestPasswordReset([FromBody] LoginModel model)
        {
            app.Reset_Password(model.email, buildUIRouterUrl("reset-password/{guid}"), model.cie);
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