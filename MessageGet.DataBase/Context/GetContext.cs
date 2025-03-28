using MessageGet.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageGet.DataBase.Context
{
    public class GetContext : DbContext
    {
        public GetContext(DbContextOptions options) : base(options)
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
