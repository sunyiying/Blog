using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByEmail(string email);
    }
}
