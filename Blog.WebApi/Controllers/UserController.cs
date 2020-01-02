using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Common.JWT;
using Blog.Common.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.WebApi.Controllers
{
    /// <summary>
    /// 用户相关操作的方法集合
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IPersonAppService _personAppService;
        private readonly IUserTokenAppService _userTokenAppService;

        public UserController(IOptions<JwtSettings> jwtSettings
            , IPersonAppService personAppService
            , IUserTokenAppService userTokenAppService
            )
        {
            this._jwtSettings = jwtSettings.Value;
            this._personAppService = personAppService;
            this._userTokenAppService = userTokenAppService;
        }




        //获取用户token信息
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string userName, string pwd)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(pwd))
            {
                var entity = _personAppService.GetPersonByPassWord(userName, pwd);
                if (entity != null)
                {
                    var tokeninfo = GenerateToken(userName);
                    _userTokenAppService.SaveUserToken(token: tokeninfo);
                    return Ok(new
                    {
                        data = tokeninfo
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        message = "用户名或密码错误"
                    });
                }
            }
            else
            {
                return BadRequest(new { message = "username or password is incorrect." });
            }
        }


        /// <summary>
        /// 生成用户token信息
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        JwtTokenInfo GenerateToken(string userCode)
        {
            DateTime now = DateTime.Now;
            JwtTokenInfo tokenInfo = new JwtTokenInfo();

            var claims = new[]
                          {
                              new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(now).ToUnixTimeSeconds()}") ,
                              new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(now.AddMinutes(_jwtSettings.EffectMinutes)).ToUnixTimeSeconds()}"),
                              new Claim(ClaimTypes.Name, userCode),
                              new Claim(ClaimTypes.Role,"roleAdmin")
                            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
              issuer: _jwtSettings.Domain,
              audience: _jwtSettings.Domain,
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);
            tokenInfo.Token = new JwtSecurityTokenHandler().WriteToken(token);
            tokenInfo.TokenId = Encrypion.GenerateMD5(tokenInfo.Token);
            tokenInfo.IssuedAt = now;
            tokenInfo.Expires = now.AddMinutes(_jwtSettings.EffectMinutes);
            tokenInfo.Issuer = _jwtSettings.Domain;
            return tokenInfo;
        }


        [Authorize]
        [HttpGet("Good")]
        public IActionResult GetData()
        {
            var a = HttpContext.User.Identity.IsAuthenticated;
            return Ok("ok");
        }

    }
}