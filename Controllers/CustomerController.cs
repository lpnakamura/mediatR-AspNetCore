using System.Threading.Tasks;
using MediatRSample.Domain.Customer.Command;
using MediatRSample.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class CustomerController : ControllerBase {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController (IMediator mediator, ICustomerRepository customerRepository) {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post (CustomerCreateCommand command) {
            var response = await _mediator.Send (command);
            return response;
        }

        [HttpPut]
        public async Task<IActionResult> Put (CustomerUpdateCommand command) {
            var response = await _mediator.Send (command);
            return response;
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {
            var dto = new CustomerDeleteCommand { Id = id };
            var response = await _mediator.Send (dto);
            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll () {
            var result = await _customerRepository.GetAll ();
            return Ok(result);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {
            var result = await _customerRepository.GetById (id);
            return Ok (result);
        }
    }
}