using Blog.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Validations
{
    public class RegisterStudentCommandValidation : StudentValidation<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
