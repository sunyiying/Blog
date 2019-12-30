using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    /// <summary>
    /// 定义领域对象 Customer
    /// </summary>
    public class Customer
    {
        protected Customer() { }
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            this.Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
