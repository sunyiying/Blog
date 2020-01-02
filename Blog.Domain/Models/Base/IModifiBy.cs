using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Models.Base
{
    interface IModifiBy
    {
        string ModifyBy { get; set; }
        DateTime ModifyTime { get; set; }
    }
}
