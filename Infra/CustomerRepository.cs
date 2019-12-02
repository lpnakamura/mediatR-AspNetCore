using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Data;
using MediatRSample.Domain.Customer.Entity;

namespace MediatRSample.Infra {
    public class CustomerRepository : ICustomerRepository {
        private readonly DataContext _context;
        public CustomerRepository (DataContext dataContext) {
            _context = dataContext;
        }
        public async Task Delete (int id) {
            var customerToRemove = _context.Customers.FirstOrDefault (w => w.Id == id);

            if (customerToRemove != null)
                await Task.Run (() => {
                    _context.Customers.Remove (customerToRemove);
                    _context.SaveChanges ();
                });
        }

        public async Task<IEnumerable<CustomerEntity>> GetAll () {
            return await Task.FromResult (_context.Customers);
        }

        public async Task<CustomerEntity> GetById (int id) {
            var customer = _context.Customers.FirstOrDefault (w => w.Id == id);
            return await Task.FromResult (customer);
        }

        public async Task Save (CustomerEntity customer) {
            await Task.Run (() => {
                _context.Customers.Add (customer);
                _context.SaveChanges ();
            });
        }

        public async Task Update (int id, CustomerEntity customer) {
            _context.Attach (customer);
            _context.SaveChanges ();

            await Task.Run (() => {
                _context.Customers.Update (customer);
                _context.SaveChanges ();
            });
        }
    }
}