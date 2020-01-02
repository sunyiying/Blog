using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.JWT
{
    /// <summary>
    /// 配置 jwt token时所需要的基本配置信息
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// 自定义密钥
        /// </summary>
        public string SecurityKey { get; set; }
        /// <summary>
        /// token的发放站点名称
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// token有效时长，（分钏）
        /// </summary>
        public int EffectMinutes { get; set; } = 30;

        /// <summary>
        /// token 允许刷新的最小时长(分钏）
        /// </summary>
        public int RefreshMinutes { get; set; } = 10;
    }
}
