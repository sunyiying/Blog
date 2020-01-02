using Blog.Application.Interfaces;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            this._personRepository = personRepository;
        }

        public Person GetPersonByPassWord(string userName, string password)
        {
            return _personRepository.GetAll().FirstOrDefault(c => c.PersonCode == userName && c.PassWord == password);
        }

    }
}
