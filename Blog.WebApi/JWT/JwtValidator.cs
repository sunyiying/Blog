using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using Blog.Common.Engineer;
using Blog.Common.Tools;
using Blog.Application.Interfaces;

namespace Blog.Common.JWT
{
    public class JwtValidator : ISecurityTokenValidator
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
                if (!(exp < nowValue || nbf > nowValue))// token的时间非法
                {
                    IUserTokenAppService userService = EngineerContext.Current.Resolve<IUserTokenAppService>();
                    var userTokenInfo = userService.GetTokenById(md5Id);
                    if (userTokenInfo != null && string.Equals(userTokenInfo.Token, securityToken, StringComparison.OrdinalIgnoreCase))
                    {
                        identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                        identity.AddClaims(token.Claims);
                    }
                }
            }
            if (identity == null) identity = new ClaimsIdentity("");
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
