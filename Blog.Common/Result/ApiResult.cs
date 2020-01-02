using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Result
{
    /// <summary>
    /// WebApi自定义返回结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 自定义码值
        /// </summary>
        public ApiStatusCode StatusCode { get; set; } = ApiStatusCode.Success;
        /// <summary>
        /// 自定义接口消息说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 接口实际返回结果
        /// </summary>
        public object Data { get; set; }
    }
}
