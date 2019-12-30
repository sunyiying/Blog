using AutoMapper;
using Blog.Application.ViewModel;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
