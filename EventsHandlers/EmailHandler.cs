using System;
using System.Threading;
using System.Threading.Tasks;
using MediatRSample.Notifications;
using MediatR;

namespace MediatRSample.EventsHandlers
{
    public class EmailHandler : INotificationHandler<CustomerActionNotification> {
        public Task Handle (CustomerActionNotification notification, CancellationToken cancellationToken) {
            return Task.Run (() => {
                Console.WriteLine(notification.Action.Notification(notification));
            });
        }
    }
}