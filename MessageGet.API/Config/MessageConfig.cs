using MessageGet.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageGet.API.Config
{
    public class MessageConfig : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.ToTable("messages");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.User)
                .HasMaxLength(50);

            builder
                .Property(m => m.Content)
                .HasMaxLength(500);
        }
    }
}
