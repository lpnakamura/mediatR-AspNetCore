namespace MediatRSample.Notifications
{
    public class CustomerUpdateActionNotification : IActionNotification
    {
        public string Notification(CustomerActionNotification customerActionNotification)
        {
            return $"The customer {customerActionNotification.FirstName} {customerActionNotification.LastName} was successfully updated";
        }
    }
}