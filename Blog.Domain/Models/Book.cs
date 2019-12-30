using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Domain.Models
{
    [Owned]
    public class Book
    {
       // [Key]
        public int Id { get; set; }
        public string BookName { get; set; }

        public int BookPrice { get; set; }

        public int personId { get; set; }

        //[ForeignKey("personId")]
        public virtual Person PersonInfo {get;set;}

    }
}
