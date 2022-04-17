using Microsoft.EntityFrameworkCore;
using Poc.CQRS.Mediator.Domain.Model;
using System.Diagnostics.CodeAnalysis;

namespace Poc.CQRS.Mediator.Infra.Context
{
    [ExcludeFromCodeCoverage]
    public partial class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
             : base(options) { }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Person>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasMany(x => x.Users)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
                

            });

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.Id);
            });
            
            modelBuilder.Entity<Article>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasMany(x => x.Comments)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comment>(entity => {
                entity.HasKey(e => e.Id);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("DateCreated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateCreated").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
