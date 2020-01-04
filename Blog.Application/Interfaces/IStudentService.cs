using Blog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// StudentAppService 添加新 Student 
        /// </summary>
        void Register(StudentViewModel studentViewModel);
    }
}
