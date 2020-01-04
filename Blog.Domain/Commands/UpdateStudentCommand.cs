using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Commands
{
    public class UpdateStudentCommand : StudentCommand
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
