using Blog.Common.JWT;
using Blog.Domain.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces
{
    public interface IUserTokenAppService
    {
        /// <summary>
        /// 根据Id 获取 用户的Token信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserToken GetTokenById(string id);

        /// <summary>
        /// 保存用户的token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        void SaveUserToken(JwtTokenInfo token);

    }
}
