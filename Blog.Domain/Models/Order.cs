﻿using Blog.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models
{
    public class Order : Entity
    {
        protected Order()
        {
        }
        public Order(Guid id, string name, List<OrderItem> orderItem)
        {
            Id = id;
            Name = name;
            OrderItem = orderItem;
        }
        /// <summary>
        /// 订单名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public virtual ICollection<OrderItem> OrderItem { get; private set; }

    }
}
