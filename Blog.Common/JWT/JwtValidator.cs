using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Blog.Common.Engineer;
using Blog.Common.Tools;

namespace Blog.Common.JWT
{
    public class JwtValidator11 : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            //securityToken = @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOiIxNTc3NzU5NzcwIiwiZXhwIjoxNTc3NzYxNTcwLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWFhYWFhIiwiaXNzIjoiaHR0cDovL3N1bnl5OS5jb20iLCJhdWQiOiJodHRwOi8vc3VueXk5LmNvbSJ9.jw_L0a4xm3lkdFr1XNtUyDFuCsC1QBVUg9M90ISOWdU";

            //SecurityToken security = new JwtSecurityTokenHandler().ReadToken(securityToken);
            //((JwtSecurityToken)security).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            JwtSecurityToken token = parse2Token(securityToken);
            string md5Id = Encrypion.GenerateMD5(securityToken);
            //给Identity赋值
            ClaimsIdentity identity = null;
            List<Claim> claims = new List<Claim>();
            long nowValue = new DateTimeOffset(TimeHelper.Now).ToUnixTimeSeconds();
            if (token != null)
            {
                string userCode = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                long.TryParse(token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nbf).Value, out long nbf);
                long.TryParse(token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp).Value, out long exp);
                if (exp < nowValue || nbf > nowValue)// token的时间非法
                {
                    //token过期
                    identity = new ClaimsIdentity("NoPower");
                }
                else
                {
                    //EngineerContext.Current.Resolve<IRepository<UserToken>>();
                }
            }
            else
            {
                identity = new ClaimsIdentity("NoPower");
            }

            identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, "admin"));

            var principle = new ClaimsPrincipal(identity);
            return principle;
        }

        /// <summary>
        /// 校验所传递的token字符串是否有效
        /// </summary>
        /// <param name="securityToken"></param>
        /// <returns></returns>
        JwtSecurityToken parse2Token(string securityToken)
        {
            try
            {
                SecurityToken security = new JwtSecurityTokenHandler().ReadToken(securityToken);
                return ((JwtSecurityToken)security);
            }
            catch (Exception)
            {
            }
            return null;
        }





    }
}
