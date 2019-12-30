using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Infra.Data.Repository
{
    /// <summary>
    /// Customer仓储，操作对象还是领域对象
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StudyContext studyContext) : base(studyContext)
        {
        }

        //对特例接口进行实现
        public Customer GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(c => c.Email == email);
        }
    }
}
