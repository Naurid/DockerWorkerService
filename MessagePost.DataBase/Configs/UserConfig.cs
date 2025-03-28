using MessagePost.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePost.DataBase.Configs
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(t => t.Id);
            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(u=>u.FullName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
