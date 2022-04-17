namespace Poc.CQRS.Mediator.Domain.Model
{
    using System.Collections.Generic;
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string BirthDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}