using MessageGet.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageGet.API.Context
{
    public class GetContext : DbContext
    {
        public GetContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MessageEntity> Messages { get { return Set<MessageEntity>(); } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
