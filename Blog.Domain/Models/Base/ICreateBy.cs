using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models.Base
{
    public interface ICreateBy
    {
        string CreateBy { get; set; }

        DateTime CreateTime { get; set; }
    }
}
