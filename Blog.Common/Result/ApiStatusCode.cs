using Blog.Common.Attrubutes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Result
{
    /// <summary>
    /// 自定义 接口返回值 码值 检举
    /// </summary>
    public enum ApiStatusCode
    {
        ///<summary>
        ///成功
        ///</summary>
        [Remark("成功")]
        Success = 200,

        ///<summary>
        ///创建成功
        ///</summary>
        [Remark("创建成功")]
        SuccessCreate = 201,

        ///<summary>
        ///执行成功无数据返回
        ///</summary>
        [Remark("执行成功无数据返回")]
        NoContent = 204,

        ///<summary>
        ///请求参数异常
        ///</summary>
        [Remark("请求参数异常")]
        BadRequest = 400,

        ///<summary>
        ///无权限访问
        ///</summary>
        [Remark("无权限访问")]
        Unauthorized = 401,

        ///<summary>
        ///无权限访问
        ///</summary>
        [Remark("访问被拒绝")]
        Forbidden = 403,

        ///<summary>
        ///所请求资源不存在
        ///</summary>
        [Remark("所请求资源不存在")]
        NotFound = 404,

        ///<summary>
        ///服务器错误
        ///</summary>
        [Remark("服务器错误")]
        InnerError = 500

    }
}
