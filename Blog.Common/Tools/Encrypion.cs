using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Common.Tools
{
    public class Encrypion
    {
        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>加密后字符串</returns>
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// MD5流加密
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static string GenerateMD5(Stream inputStream)
        {
            using (MD5 mi = MD5.Create())
            {
                //开始加密
                byte[] newBuffer = mi.ComputeHash(inputStream);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Base64加密，解密方法
        /// </summary>
        /// <paramname="s">输入字符串</param>
        /// <paramname="c">true-加密,false-解密</param>
        public static string base64(string s, bool c)
        {
            if (c)
            {
                return System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s));
            }
            else
            {
                try
                {
                    return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(s));
                }
                catch (Exception exp)
                {
                    return exp.Message;
                }
            }
        }







    }
}
