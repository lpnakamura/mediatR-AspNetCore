namespace MediatRSample.Notifications
{
    public class CustomerDeleteActionNotification : IActionNotification
    {
        public string Notification(CustomerActionNotification customerActionNotification)
        {
            return $"The customer {customerActionNotification.FirstName} {customerActionNotification.LastName} was successfully deleted";
        }
    }
}