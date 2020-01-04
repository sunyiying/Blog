using Blog.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Validations
{
    public class UpdateStudentCommandValidation : StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation()
        {
            ValidateEmail();
            ValidatePhone();
        }
    }
}
