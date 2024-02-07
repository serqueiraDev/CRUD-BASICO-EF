using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Blog.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // Table
            builder.ToTable("Post");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Identity
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(p => p.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME") // DATETIME NOT NULL DEFAULT(GETDATE())
                .HasDefaultValueSql("GETDATE()");
            // .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.HasIndex(p => p.Slug, "IX_Post_Slug")
                .IsUnique();

            // Relacionamento um para muitos
            builder.HasOne(p => p.Author)
                .WithMany(p => p.Post)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p=>p.Category)
                .WithMany(p=>p.Post)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento muitos para muitos
            builder.HasMany(p => p.tags)
                .WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
