namespace MediatRSample.Notifications
{
    public interface IActionNotification
    {
         string Notification(CustomerActionNotification customerActionNotification);
    }
}