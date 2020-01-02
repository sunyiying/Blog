using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models.UserInfo
{
    public class UserToken
    {
        /// <summary>
        /// tokenId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// token信息
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Token发放人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Token的发放时间
        /// </summary>
        public DateTime IssuedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expires { get; set; }

    }
}
