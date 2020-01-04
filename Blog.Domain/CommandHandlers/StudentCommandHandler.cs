using Blog.Domain.Commands;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler
         , IRequestHandler<RegisterStudentCommand, Unit>
    //,IRequestHandler<UpdateStudentCommand,Unit>
    //,IRequestHandler<RemoveStudentCommand,Unit>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler _bus;
        private IMemoryCache _cache;

        public StudentCommandHandler(IStudentRepository studentRepository
            , IUnitOfWork unitOfWork
            , IMediatorHandler bus
            , IMemoryCache cache
            ) : base(unitOfWork, bus, cache)
        {
            this._studentRepository = studentRepository;
            this._bus = bus;
            this._cache = cache;
        }

        public Task<Unit> Handle(RegisterStudentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidattionErrors(message);
                return Task.FromResult(new Unit());
            }

            var address = new Address(message.Province, message.City, message.County, message.Street);
            var customer = new Student(Guid.NewGuid(), message.Name, message.Email, message.Phone, message.BirthDate, address);

            if (_studentRepository.GetByEmail(customer.Email) != null)
            {
                List<string> errorInfo = new List<string>() { "此邮箱已存在！！" };
                _cache.Set("ErrorData", errorInfo);
                return Task.FromResult(new Unit());
            }

            _studentRepository.Add(customer);

            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等
                // waiting....
            }
            return Task.FromResult(new Unit());
        }
    }
}
