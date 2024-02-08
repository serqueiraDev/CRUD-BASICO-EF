using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Blog.Mappings
{
    public class UserBlogMap : IEntityTypeConfiguration<UserBlog>
    {
        public void Configure(EntityTypeBuilder<UserBlog> builder)
        {
            // Table
            builder.ToTable("UserBlog");

            // Chave primária
            builder.HasKey(ub => ub.Id);

            // Identity
            builder.Property(ub => ub.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedade
            builder.Property(ub => ub.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(ub => ub.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(ub=>ub.GitHub)
                .HasColumnName("GitHub")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150); 

            // Indices
            builder.HasIndex(ub => ub.Slug, "IX_User_Slug")
                .IsUnique();

            // Relacionamento muitos para muitos
            builder.HasMany(ub => ub.Roles)
                .WithMany(ub => ub.UserBlogs)
                .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserBlogRole_RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                userBlog => userBlog.HasOne<UserBlog>()
                        .WithMany()
                        .HasForeignKey("UserBlogId")
                        .HasConstraintName("FK_UserBlogRole_UserBlogId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
