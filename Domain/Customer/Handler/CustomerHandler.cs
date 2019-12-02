using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Domain.Customer.Command;
using MediatRSample.Domain.Customer.Entity;
using MediatRSample.Infra;
using MediatRSample.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Domain.Customer.Handler {
    public class CustomerHandler:
        IRequestHandler<CustomerCreateCommand, IActionResult>,
        IRequestHandler<CustomerUpdateCommand, IActionResult>,
        IRequestHandler<CustomerDeleteCommand, IActionResult> {
            private readonly IMediator _mediator;
            private readonly ICustomerRepository _customerRepository;

            public CustomerHandler (IMediator mediator, ICustomerRepository customerRepository) {
                _mediator = mediator;
                _customerRepository = customerRepository;
            }

            public async Task<IActionResult> Handle (CustomerDeleteCommand request, CancellationToken cancellationToken) {
                var client = await _customerRepository.GetById (request.Id);

                if (client == null) {
                    return new NotFoundResult();
                }

                await _customerRepository.Delete (request.Id);

                await _mediator.Publish (new CustomerActionNotification {
                    FirstName = client.FirstName,
                        LastName = client.LastName,
                        Email = client.Email,
                        Action = new CustomerDeleteActionNotification ()
                }, cancellationToken);

                return new OkResult ();
            }

            public async Task<IActionResult> Handle (CustomerCreateCommand request, CancellationToken cancellationToken) {
                var customer = new CustomerEntity (request.Id, request.FirstName, request.LastName, request.Email, request.Phone);
                await _customerRepository.Save (customer);

                await _mediator.Publish (new CustomerActionNotification {
                    FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        Action = new CustomerCreateActionNotification ()
                }, cancellationToken);

                return new OkResult ();
            }

            public async Task<IActionResult> Handle (CustomerUpdateCommand request, CancellationToken cancellationToken) {
                var customer = new CustomerEntity (request.Id, request.FirstName, request.LastName, request.Email, request.Phone);
                await _customerRepository.Update (request.Id, customer);

                await _mediator.Publish (new CustomerActionNotification {
                    FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        Action = new CustomerUpdateActionNotification ()
                }, cancellationToken);

                return new ObjectResult (customer);
            }
        }
}