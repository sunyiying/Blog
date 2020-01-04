using Blog.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Commands
{
    public class RegisterStudentCommand : StudentCommand
    {
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone, string province, string city, string country, string street)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Province = province;
            City = city;
            County = country;
            Street = street;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
