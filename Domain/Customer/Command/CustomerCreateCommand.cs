using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Domain.Customer.Command 
{
    public class CustomerCreateCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}