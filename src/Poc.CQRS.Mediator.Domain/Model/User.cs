namespace Poc.CQRS.Mediator.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid AccessIdentity { get; set;}
        public DateTime LastLogin { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }

        public virtual Person Person { get; set; }
    }
}