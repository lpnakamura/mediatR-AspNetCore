using MediatR;

namespace MediatRSample.Notifications {
    public class CustomerActionNotification : INotification {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IActionNotification Action { get; set; }
    }
}