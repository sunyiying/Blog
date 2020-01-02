using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces
{
    public interface IPersonAppService
    {
        /// <summary>
        /// 根据用户名及密码获取 用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Person GetPersonByPassWord(string userName, string password);
    }
}
