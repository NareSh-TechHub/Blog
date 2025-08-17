using BlogApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.API.Models.Configuration
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(b => b.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(b => b.Content)
                .IsRequired();
            
            builder.Property(b => b.UrlHandle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Categories)
                .WithMany(c => c.BlogPosts);
        }
    }
}