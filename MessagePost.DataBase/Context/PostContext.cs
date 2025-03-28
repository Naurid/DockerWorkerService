using MessagePost.DataBase.Entities;
using MessagePost.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MessagePost.DataBase.Context
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions options):base(options) 
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
