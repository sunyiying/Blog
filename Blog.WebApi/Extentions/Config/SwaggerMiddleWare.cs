using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Extentions.Config
{
    public static class SwaggerMiddleWare
    {
        /// <summary>
        /// swaggle中间件
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerMiddleWare(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                c.RoutePrefix = "";
            });
        }
    }
}
