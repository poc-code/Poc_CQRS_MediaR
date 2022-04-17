namespace Poc.CQRS.Mediator.Domain.Model{ 

    public class Comments
    { 

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}