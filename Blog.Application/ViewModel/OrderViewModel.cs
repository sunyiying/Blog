﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Application.ViewModel
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Order Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public List<OrderItemViewModel> Items { get; set; }
    }
}
