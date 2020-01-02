using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.WebApi.Extentions.ConfigService
{
    public static class CustomerInject
    {

        /// <summary>
        /// 通过反射 自动注入 仓储服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        /// <param name="postFix"></param>
        public static void AddRepository(this IServiceCollection services, string assemblyName, string postFix)
        {
            AddServices(services, assemblyName, postFix);
        }


        /// <summary>
        /// 通过 反射 自动注入服务应用接口
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        /// <param name="postFix"></param>
        public static void AddServices(this IServiceCollection services, string assemblyName, string postFix)
        {

            if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(postFix))
            {
                throw new Exception("参数为空！");
            }
            var assembly = Assembly.Load(assemblyName);
            if (assembly == null)
            {
                throw new Exception($"{assemblyName}注入失败！");
            }
            var types = assembly.GetTypes().ToList();
            if (types != null && types.Count > 0)
            {
                foreach (var impl in types)
                {
                    if (impl.IsClass
                        && !impl.IsGenericType
                        && !impl.IsAbstract
                        && impl.Name.EndsWith(postFix, StringComparison.OrdinalIgnoreCase))
                    {
                        var inter = impl.GetInterfaces().FirstOrDefault(c => c.Name.EndsWith(postFix, StringComparison.OrdinalIgnoreCase));
                        if (inter != null)
                            services.AddTransient(inter, impl);
                    }
                }
            }
        }




    }
}
