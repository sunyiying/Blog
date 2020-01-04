using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.ViewModel;
using Blog.Domain.Commands;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        public StudentService(IMapper mapper, IMediatorHandler bus, IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
            this._bus = bus;
        }

        /// <summary>
        /// StudentAppService 添加新 Student 
        /// </summary>
        public void Register(StudentViewModel studentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterStudentCommand>(studentViewModel);
            _bus.SendCommand(registerCommand);
        }
    }
}
