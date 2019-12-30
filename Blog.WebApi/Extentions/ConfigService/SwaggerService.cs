using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Extentions.ConfigService
{
    public static class SwaggerService
    {
        /// <summary>
        /// Swagger服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.1.0",
                    Title = "Blog. API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Blog",
                        Email = "Blog@xxx.com",
                        Url = "https://abc.com"
                    }
                });
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var interfacePath = Path.Combine(basePath, "Blog.WebApi.xml");
                c.IncludeXmlComments(interfacePath, true);
                var viewModelPath = Path.Combine(basePath, "Blog.Application.xml");
                c.IncludeXmlComments(viewModelPath);

            });
        }
    }
}
