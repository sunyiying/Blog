using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Core.Bus
{
    /// <summary>
    /// 中介者处理接口，后续将定义多个处理程序
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// 发布命令，将我们的命令模型发布到中价者模块中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;

        Task RaiseEvent<T>(T @event) where T :Event;

    }
}
