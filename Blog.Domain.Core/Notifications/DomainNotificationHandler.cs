using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications = null;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }
        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取当前生命周期内的全部通知信息
        /// </summary>
        /// <returns></returns>
        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        /// 判断在当前总线对象周期中，是否存在通知信息
        /// </summary>
        /// <returns></returns>
        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        /// <summary>
        /// 手动回收（清空通知）
        /// </summary>
        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

    }
}
