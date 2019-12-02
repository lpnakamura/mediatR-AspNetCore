using System.ComponentModel.DataAnnotations;

namespace MediatRSample.Domain.Customer.Entity {
    public class CustomerEntity {
        public CustomerEntity (int id, string firstName, string lastName, string email, string phone) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}