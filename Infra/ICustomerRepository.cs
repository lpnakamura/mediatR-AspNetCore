using System.Collections.Generic;
using System.Threading.Tasks;
using MediatRSample.Domain.Customer.Entity;

namespace MediatRSample.Infra {
    public interface ICustomerRepository {
        Task Save(CustomerEntity customer);
        Task Update(int id, CustomerEntity customer);
        Task Delete(int id);
        Task<CustomerEntity> GetById(int id);
        Task<IEnumerable<CustomerEntity>> GetAll();
    }
}