﻿using Blog.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Blog.Domain.Models;
using Blog.Domain.Models.UserInfo;
using System.Reflection;
using System.Linq;

namespace Blog.Infra.Data.Context
{
    /// <summary>
    /// 定义核心子领域——学习上下文
    /// </summary>
    public class StudyContext : DbContext
    {
        public StudyContext(DbContextOptions<StudyContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //此处后续将修改为反射处理，动态构建
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());



            //var assembly = Assembly.Load("Blog.Infra.Data");
            //if (assembly != null)
            //{
            //    var types = assembly?.GetTypes().Where(c => c.IsClass
            //    && c.IsGenericType
            //    && c.Name.EndsWith("Map", StringComparison.OrdinalIgnoreCase)
            //    && c.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null
            //    ).ToList();
            //    if (types != null && types.Count > 0)
            //    {
            //        foreach (var ts in types)
            //        {
            //            dynamic instances = Activator.CreateInstance(ts);
            //            modelBuilder.ApplyConfiguration(instances);
            //        }
            //    }
            //}


            base.OnModelCreating(modelBuilder);
        }

        ///// <summary>
        ///// 重写连接数据库
        ///// </summary>
        ///// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // 从 appsetting.json 中获取配置信息
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    // 定义要使用的数据库
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
    }
}
