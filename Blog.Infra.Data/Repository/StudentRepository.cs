using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Infra.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext dbContext) : base(dbContext)
        {
            
        }

        public Student GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(c => c.Email == email);
        }

    }
}
