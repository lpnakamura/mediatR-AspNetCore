using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatRSample.Notifications;
using MediatR;

namespace MediatRSample.EventsHandlers {
    public class LogHandler : INotificationHandler<CustomerActionNotification> {
        private readonly string path = $"{Environment.CurrentDirectory}/log.txt";
        public Task Handle (CustomerActionNotification notification, CancellationToken cancellationToken) {
            return Task.Run (() => {
                using (var tw = new StreamWriter (path, File.Exists (path))) {
                    tw.WriteLine (notification.Action.Notification(notification));
                }
            });
        }
    }
}