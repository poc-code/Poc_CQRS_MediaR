namespace Poc.CQRS.Mediator.Infra.DataSeed
{
    using Poc.CQRS.Mediator.Domain.Model;
    using Poc.CQRS.Mediator.Infra.Context;

    public class Seed
    {
        public static void SeedData(EntityContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;
            }

            var people = new Person[]
            {
                new Person{
                    Name = "John",
                    LastName = "Doe",
                    Email = "john@doe.com",
                    Phone = "11-1111-1111",
                    Address = "Street 1",
                    City = "City 1",
                    State = "State 1",
                    ZipCode = "Zip 1",
                    Country = "Country 1",
                    Cpf = "111.111.111-11",
                    Rg = "111111111",
                    BirthDate = "01/01/2000",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Person{ 
                    Name = "Jane",
                    LastName = "Doe",
                    Email = "Jane@email.com",
                    Phone = "11-2222-2222",
                    Address = "Street 2",
                    City = "City 2",
                    State = "State 2",
                    ZipCode = "Zip 2",
                    Country = "Country 2",
                    Cpf = "222.222.222-22",
                    Rg = "222222222",
                    BirthDate = "02/02/2000",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                }                
            };

            context.Person.AddRange(people);
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Password = "admin",
                    AccessIdentity = Guid.NewGuid(),
                    LastLogin = DateTime.Now,
                    Description = "Administrator",
                    PersonId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Username = "user",
                    Password = "user",
                    AccessIdentity = Guid.NewGuid(),
                    LastLogin = DateTime.Now,
                    Description = "User",
                    PersonId = 2,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                }
            };

            context.User.AddRange(users);
            context.SaveChanges();

            var articles = new List<Article>
            {
                new Article
                {
                    User = users[0],
                    Description = "Article 1",
                    Tag = "Tag 1",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Article
                {
                    User = users[0],
                    Description = "Article 2",
                    Tag = "Tag 2",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Article
                {
                    User = users[1],
                    Description = "Article 3",
                    Tag = "Tag 3",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Article
                {
                    User = users[1],
                    Description = "Article 4",
                    Tag = "Tag 4",
                    DateCreated = DateTime.Now,
                }
            };

            context.Article.AddRange(articles);
            context.SaveChanges();

            var comments = new List<Comment>{
                new Comment
                {
                    Article = articles[0],
                    User = users[0],
                    Description = "Comment 1",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Comment
                {
                    Article = articles[0],
                    User = users[0],
                    Description = "Comment 2",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Comment{
                    Article = articles[1],
                    User = users[0],
                    Description = "Comment 3",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                },
                new Comment
                {
                    Article = articles[1],
                    User = users[1],
                    Description = "Comment 4",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true
                }
            };
            context.Comment.AddRange(comments);
            context.SaveChanges();

        }
    }

}