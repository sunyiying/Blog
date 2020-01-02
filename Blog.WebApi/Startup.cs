using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Common.Engineer;
using Blog.Common.JWT;
using Blog.Domain.Interfaces;
using Blog.Infra.Data.Context;
using Blog.Infra.Data.Repository;
using Blog.WebApi.Extentions.Config;
using Blog.WebApi.Extentions.ConfigService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Blog.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudyContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddRepository("Blog.Infra.Data", "Repository");
            services.AddServices("Blog.Application", "Service");
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddTransient(typeof(IUserTokenAppService), typeof(UserTokenAppService));
            services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));

            //添加jwt验证：
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(o =>
              {
                  o.SecurityTokenValidators.Clear();
                  o.SecurityTokenValidators.Add(new JwtValidator());
              });

            services.AddMvc()
                .AddJsonOptions(o => { o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapperSetup();
            services.AddSwagger();


            ///仓储引擎注入
            EngineerContext.Initialize(new GeneralEngineer(services.BuildServiceProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            IdentityModelEventSource.ShowPII = true;
            app.UseMvc();
            app.UseSwaggerMiddleWare();
        }
    }
}
