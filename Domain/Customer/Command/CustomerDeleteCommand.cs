using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Domain.Customer.Command 
{
    public class CustomerDeleteCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}