using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models.UserInfo
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
