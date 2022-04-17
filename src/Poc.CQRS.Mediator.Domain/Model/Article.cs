namespace Poc.CQRS.Mediator.Domain.Model{ 

    public class Article{ 

        public int Id { get; set; }
        public UserId User { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<Comments> Comments { get; set; }
    }

}