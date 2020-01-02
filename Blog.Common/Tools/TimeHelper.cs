using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.Tools
{
    public class TimeHelper
    {
        /// <summary>
        /// 统一获取当前时间
        /// </summary>
        public static DateTime Now => DateTime.Now;

        public static string NowString => DateTime.Now.ToString("yyyyMMddHHmmss");

        
    }
}
