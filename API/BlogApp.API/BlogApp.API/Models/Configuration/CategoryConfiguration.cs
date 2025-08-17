using BlogApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.API.Models.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(c => c.UrlHandle)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.HasMany(c => c.BlogPosts)
                .WithMany(b => b.Categories);
        }
    }
}