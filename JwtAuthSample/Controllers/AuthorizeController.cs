using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using JwtAuthSample;
using System.Security.Claims; 
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAuthSample
{
    //      api/  Authorize   /test
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private JwtSettings _jewSettings;
        public AuthorizeController(IOptions<JwtSettings> _jewSettingsAccesser)
        {
            _jewSettings=_jewSettingsAccesser.Value;

        }

        [HttpPost]
        public ActionResult Token(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                if(!(viewModel.User=="jesse"&& viewModel.Password=="123456"))
                {
                    return BadRequest();

                }
                var claims=new Claim[]{
                    new Claim(ClaimTypes.Name,"jesse"),
                    new Claim(ClaimTypes.Role,"admin")
                };
                var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jewSettings.Secretkey));
                var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token=new JwtSecurityToken(
                    _jewSettings.Issuer,
                    _jewSettings.Audience,
                    claims,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    creds);
                    return Ok(new{token=new JwtSecurityTokenHandler().WriteToken(token)});
            }
            return BadRequest();
 

        }


    }


}