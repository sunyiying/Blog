using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Core.Commands
{
    /// <summary>
    /// 抽象基类命令
    /// </summary>
    public abstract class Command: IRequest
    {
        public DateTime Timpstamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            this.Timpstamp = DateTime.Now;
        }

        /// <summary>
        /// 用户验证是否验证有效
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();

    }
}
