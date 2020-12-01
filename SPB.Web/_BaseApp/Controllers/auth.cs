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

    [AllowAnonymous, ApiController]
    [Route("api/[controller]")]
    public partial class AuthController : _CoreController
    {
        [HttpPost("signin")]
        public AuthorizationData Signin([FromBody]LoginModel model)
        {
            var usercaps = app.AppLogin(model.email, model.password);
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
            app.Reset_Password(model.email, buildUIRouterUrl("reset-password/{guid}"));
            return NoContent();
        }

        [Authorize]
        [HttpPost("refresh")]
        public AuthorizationData Refresh()
        {
            var usercaps = app.RefreshAppLogin();
            return populateAuthorizationData(usercaps);
        }

        AuthorizationData populateAuthorizationData(UserCaps usercaps)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, usercaps.email));
            claims.Add(new Claim(UserData.ClaimType_Name, usercaps.name));
            claims.Add(new Claim(UserData.ClaimType_UID, usercaps.uid.ToString()));
            claims.Add(new Claim(UserData.ClaimType_Year, usercaps.year.ToString()));
            claims.Add(new Claim(UserData.ClaimType_RegionLUID, usercaps.regionLUID.ToString()));
            claims.Add(new Claim(UserData.ClaimType_RegionLUID_Text, usercaps.regionLUID_Text));
            claims.Add(new Claim(UserData.ClaimType_DistrictLUID, usercaps.districtLUID.ToString()));
            claims.Add(new Claim(UserData.ClaimType_DistrictLUID_Text, usercaps.districtLUID_Text));
            foreach (var permission in usercaps.permissions)
            {
                claims.Add(new Claim(UserData.ClaimType_Perms, permission.ToString(), ClaimValueTypes.Integer));
            }
            foreach (var role in usercaps.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString(), ClaimValueTypes.Integer));
            }

            var secretKey = new SymmetricSecurityKey(app.IssuerSigningKey);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: app.Issuer,
                audience: app.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(app.FormsAuthenticationTimeoutTotalMinutes),
                signingCredentials: signinCredentials
            );

            return new AuthorizationData
            {
                token = new JwtSecurityTokenHandler().WriteToken(tokenOptions)
            };
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