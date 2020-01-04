using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;
        private IMemoryCache _cache;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler mediatorHandler, IMemoryCache cache)
        {
            this._unitOfWork = unitOfWork;
            this._bus = mediatorHandler;
            this._cache = cache;
        }

        /// <summary>
        /// 工作单元进行提交，
        /// 如果提交有异常 则进行领导通知的处理
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            if (_unitOfWork.Commit()) return true;
            return false;
        }

        protected void NotifyValidattionErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);
            }
            _cache.Set("ErrorData", errorInfo);
        }



    }
}
