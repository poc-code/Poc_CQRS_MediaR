namespace Poc.CQRS.Mediator.Domain.Model{ 

    using System.Collections.Generic;

    public class Article
    {

        public Article() => Comments = new List<Comment>();

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }

        public User User {get; set;}
        public virtual IEnumerable<Comment> Comments { get; set; }
    }

}