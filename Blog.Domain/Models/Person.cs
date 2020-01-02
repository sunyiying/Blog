using Blog.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonCode { get; set; }
        public string PassWord { get; set; }
        public int Age { get; set; }
        public virtual List<Book> BookStore { get; set; }
    }
}
