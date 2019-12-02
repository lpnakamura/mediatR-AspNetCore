namespace MediatRSample.Notifications
{
    public class CustomerCreateActionNotification : IActionNotification
    {
        public string Notification(CustomerActionNotification customerActionNotification)
        {
            return $"The customer {customerActionNotification.FirstName} {customerActionNotification.LastName} was successfully created";
        }
    }
}