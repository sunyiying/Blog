using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.JWT
{
    /// <summary>
    /// 自定的tokeninfo
    /// </summary>
    public class JwtTokenInfo
    {
        /// <summary>
        /// tokenId
        /// </summary>
        public string TokenId { get; set; }
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
