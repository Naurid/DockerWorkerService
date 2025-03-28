using MessagePost.API.Entities;
using MessagePost.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MessagePost.API.Context
{
    public class GetContext : DbContext
    {
        public GetContext(DbContextOptions<GetContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<UserEntity> Users { get { return Set<UserEntity>(); } }
        public DbSet<MessageEntity> Messages { get { return Set<MessageEntity>(); } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
