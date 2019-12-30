using Blog.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    public class OrderItem : Entity
    {

        /// <summary>
        /// 详情名
        /// </summary>
        public string Name { get; private set; }

        public virtual Order Order { get; set; }
    }
}
